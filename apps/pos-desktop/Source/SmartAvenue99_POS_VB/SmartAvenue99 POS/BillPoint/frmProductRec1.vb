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
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x020001E3 RID: 483
	<DesignerGenerated()>
	Public Partial Class frmProductRec1
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06008139 RID: 33081 RVA: 0x005F8FCC File Offset: 0x005F71CC
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmProductRecord_Load
			AddHandler MyBase.VisibleChanged, AddressOf Me.frmProductRec1_VisibleChanged
			AddHandler MyBase.Shown, AddressOf Me.frmProductRec1_Shown
			AddHandler MyBase.KeyDown, AddressOf Me.frmProductRec1_KeyDown
			Me.shouldHandleSelectedIndexChanged = False
			Me.dt = New DataTable()
			Me.Dst = New DataSet()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17002F6F RID: 12143
		' (get) Token: 0x0600813C RID: 33084 RVA: 0x0003F69D File Offset: 0x0003D89D
		' (set) Token: 0x0600813D RID: 33085 RVA: 0x005FB3EC File Offset: 0x005F95EC
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DataGridView1_KeyDown
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView1_CellContentClick
				Dim dataGridViewCellCancelEventHandler As DataGridViewCellCancelEventHandler = AddressOf Me.DataGridView1_CellBeginEdit
				Dim dataGridViewDataErrorEventHandler As DataGridViewDataErrorEventHandler = AddressOf Me.DataGridView1_DataError
				Dim dataGridViewEditingControlShowingEventHandler As DataGridViewEditingControlShowingEventHandler = AddressOf Me.DataGridView1_EditingControlShowing
				Dim dataGridViewCellEventHandler2 As DataGridViewCellEventHandler = AddressOf Me.DataGridView1_CellClick
				Dim dataGridViewCellEventHandler3 As DataGridViewCellEventHandler = AddressOf Me.DataGridView1_CellDoubleClick
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					RemoveHandler dataGridView.CellBeginEdit, dataGridViewCellCancelEventHandler
					RemoveHandler dataGridView.DataError, dataGridViewDataErrorEventHandler
					RemoveHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
					RemoveHandler dataGridView.CellClick, dataGridViewCellEventHandler2
					RemoveHandler dataGridView.CellContentDoubleClick, dataGridViewCellEventHandler3
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					AddHandler dataGridView.CellBeginEdit, dataGridViewCellCancelEventHandler
					AddHandler dataGridView.DataError, dataGridViewDataErrorEventHandler
					AddHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
					AddHandler dataGridView.CellClick, dataGridViewCellEventHandler2
					AddHandler dataGridView.CellContentDoubleClick, dataGridViewCellEventHandler3
				End If
			End Set
		End Property

		' Token: 0x17002F70 RID: 12144
		' (get) Token: 0x0600813E RID: 33086 RVA: 0x0003F6A7 File Offset: 0x0003D8A7
		' (set) Token: 0x0600813F RID: 33087 RVA: 0x0003F6B1 File Offset: 0x0003D8B1
		Friend Overridable Property txtBar As TextBox

		' Token: 0x17002F71 RID: 12145
		' (get) Token: 0x06008140 RID: 33088 RVA: 0x0003F6BA File Offset: 0x0003D8BA
		' (set) Token: 0x06008141 RID: 33089 RVA: 0x0003F6C4 File Offset: 0x0003D8C4
		Friend Overridable Property txtBarcodeTempStock As TextBox

		' Token: 0x17002F72 RID: 12146
		' (get) Token: 0x06008142 RID: 33090 RVA: 0x0003F6CD File Offset: 0x0003D8CD
		' (set) Token: 0x06008143 RID: 33091 RVA: 0x0003F6D7 File Offset: 0x0003D8D7
		Friend Overridable Property txtID As TextBox

		' Token: 0x17002F73 RID: 12147
		' (get) Token: 0x06008144 RID: 33092 RVA: 0x0003F6E0 File Offset: 0x0003D8E0
		' (set) Token: 0x06008145 RID: 33093 RVA: 0x0003F6EA File Offset: 0x0003D8EA
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x17002F74 RID: 12148
		' (get) Token: 0x06008146 RID: 33094 RVA: 0x0003F6F3 File Offset: 0x0003D8F3
		' (set) Token: 0x06008147 RID: 33095 RVA: 0x0003F6FD File Offset: 0x0003D8FD
		Friend Overridable Property txtProductCode As TextBox

		' Token: 0x17002F75 RID: 12149
		' (get) Token: 0x06008148 RID: 33096 RVA: 0x0003F706 File Offset: 0x0003D906
		' (set) Token: 0x06008149 RID: 33097 RVA: 0x0003F710 File Offset: 0x0003D910
		Friend Overridable Property txtNP As TextBox

		' Token: 0x17002F76 RID: 12150
		' (get) Token: 0x0600814A RID: 33098 RVA: 0x0003F719 File Offset: 0x0003D919
		' (set) Token: 0x0600814B RID: 33099 RVA: 0x0003F723 File Offset: 0x0003D923
		Friend Overridable Property txtBarcode As TextBox

		' Token: 0x17002F77 RID: 12151
		' (get) Token: 0x0600814C RID: 33100 RVA: 0x0003F72C File Offset: 0x0003D92C
		' (set) Token: 0x0600814D RID: 33101 RVA: 0x0003F736 File Offset: 0x0003D936
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x17002F78 RID: 12152
		' (get) Token: 0x0600814E RID: 33102 RVA: 0x0003F73F File Offset: 0x0003D93F
		' (set) Token: 0x0600814F RID: 33103 RVA: 0x005FB4EC File Offset: 0x005F96EC
		Private _GelButtonNewRecord As GelButton
		Friend Overridable Property GelButtonNewRecord As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButtonNewRecord
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButtonNewRecord_Click
				Dim gelButton As GelButton = Me._GelButtonNewRecord
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButtonNewRecord = value
				gelButton = Me._GelButtonNewRecord
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002F79 RID: 12153
		' (get) Token: 0x06008150 RID: 33104 RVA: 0x0003F749 File Offset: 0x0003D949
		' (set) Token: 0x06008151 RID: 33105 RVA: 0x0003F753 File Offset: 0x0003D953
		Friend Overridable Property PID As DataGridViewTextBoxColumn

		' Token: 0x17002F7A RID: 12154
		' (get) Token: 0x06008152 RID: 33106 RVA: 0x0003F75C File Offset: 0x0003D95C
		' (set) Token: 0x06008153 RID: 33107 RVA: 0x0003F766 File Offset: 0x0003D966
		Friend Overridable Property ProductCode As DataGridViewTextBoxColumn

		' Token: 0x17002F7B RID: 12155
		' (get) Token: 0x06008154 RID: 33108 RVA: 0x0003F76F File Offset: 0x0003D96F
		' (set) Token: 0x06008155 RID: 33109 RVA: 0x0003F779 File Offset: 0x0003D979
		Friend Overridable Property ProductName As DataGridViewTextBoxColumn

		' Token: 0x17002F7C RID: 12156
		' (get) Token: 0x06008156 RID: 33110 RVA: 0x0003F782 File Offset: 0x0003D982
		' (set) Token: 0x06008157 RID: 33111 RVA: 0x0003F78C File Offset: 0x0003D98C
		Friend Overridable Property cmbCategory As DataGridViewComboBoxColumn

		' Token: 0x17002F7D RID: 12157
		' (get) Token: 0x06008158 RID: 33112 RVA: 0x0003F795 File Offset: 0x0003D995
		' (set) Token: 0x06008159 RID: 33113 RVA: 0x0003F79F File Offset: 0x0003D99F
		Friend Overridable Property btnAddCategory As DataGridViewButtonColumn

		' Token: 0x17002F7E RID: 12158
		' (get) Token: 0x0600815A RID: 33114 RVA: 0x0003F7A8 File Offset: 0x0003D9A8
		' (set) Token: 0x0600815B RID: 33115 RVA: 0x0003F7B2 File Offset: 0x0003D9B2
		Friend Overridable Property cmbSubCategory As DataGridViewComboBoxColumn

		' Token: 0x17002F7F RID: 12159
		' (get) Token: 0x0600815C RID: 33116 RVA: 0x0003F7BB File Offset: 0x0003D9BB
		' (set) Token: 0x0600815D RID: 33117 RVA: 0x0003F7C5 File Offset: 0x0003D9C5
		Friend Overridable Property btnAddSubCategory As DataGridViewButtonColumn

		' Token: 0x17002F80 RID: 12160
		' (get) Token: 0x0600815E RID: 33118 RVA: 0x0003F7CE File Offset: 0x0003D9CE
		' (set) Token: 0x0600815F RID: 33119 RVA: 0x0003F7D8 File Offset: 0x0003D9D8
		Friend Overridable Property txtSubCategoryID As DataGridViewTextBoxColumn

		' Token: 0x17002F81 RID: 12161
		' (get) Token: 0x06008160 RID: 33120 RVA: 0x0003F7E1 File Offset: 0x0003D9E1
		' (set) Token: 0x06008161 RID: 33121 RVA: 0x0003F7EB File Offset: 0x0003D9EB
		Friend Overridable Property txtHSNCode As DataGridViewTextBoxColumn

		' Token: 0x17002F82 RID: 12162
		' (get) Token: 0x06008162 RID: 33122 RVA: 0x0003F7F4 File Offset: 0x0003D9F4
		' (set) Token: 0x06008163 RID: 33123 RVA: 0x0003F7FE File Offset: 0x0003D9FE
		Friend Overridable Property txtPartNo As DataGridViewTextBoxColumn

		' Token: 0x17002F83 RID: 12163
		' (get) Token: 0x06008164 RID: 33124 RVA: 0x0003F807 File Offset: 0x0003DA07
		' (set) Token: 0x06008165 RID: 33125 RVA: 0x0003F811 File Offset: 0x0003DA11
		Friend Overridable Property txtFeatures As DataGridViewTextBoxColumn

		' Token: 0x17002F84 RID: 12164
		' (get) Token: 0x06008166 RID: 33126 RVA: 0x0003F81A File Offset: 0x0003DA1A
		' (set) Token: 0x06008167 RID: 33127 RVA: 0x0003F824 File Offset: 0x0003DA24
		Friend Overridable Property txtCostPrice As DataGridViewTextBoxColumn

		' Token: 0x17002F85 RID: 12165
		' (get) Token: 0x06008168 RID: 33128 RVA: 0x0003F82D File Offset: 0x0003DA2D
		' (set) Token: 0x06008169 RID: 33129 RVA: 0x0003F837 File Offset: 0x0003DA37
		Friend Overridable Property RSPrice As DataGridViewTextBoxColumn

		' Token: 0x17002F86 RID: 12166
		' (get) Token: 0x0600816A RID: 33130 RVA: 0x0003F840 File Offset: 0x0003DA40
		' (set) Token: 0x0600816B RID: 33131 RVA: 0x0003F84A File Offset: 0x0003DA4A
		Friend Overridable Property txtDiscount As DataGridViewTextBoxColumn

		' Token: 0x17002F87 RID: 12167
		' (get) Token: 0x0600816C RID: 33132 RVA: 0x0003F853 File Offset: 0x0003DA53
		' (set) Token: 0x0600816D RID: 33133 RVA: 0x0003F85D File Offset: 0x0003DA5D
		Friend Overridable Property cmbGST As DataGridViewComboBoxColumn

		' Token: 0x17002F88 RID: 12168
		' (get) Token: 0x0600816E RID: 33134 RVA: 0x0003F866 File Offset: 0x0003DA66
		' (set) Token: 0x0600816F RID: 33135 RVA: 0x0003F870 File Offset: 0x0003DA70
		Friend Overridable Property btnAddGSTPer As DataGridViewButtonColumn

		' Token: 0x17002F89 RID: 12169
		' (get) Token: 0x06008170 RID: 33136 RVA: 0x0003F879 File Offset: 0x0003DA79
		' (set) Token: 0x06008171 RID: 33137 RVA: 0x0003F883 File Offset: 0x0003DA83
		Friend Overridable Property txtCGST As DataGridViewTextBoxColumn

		' Token: 0x17002F8A RID: 12170
		' (get) Token: 0x06008172 RID: 33138 RVA: 0x0003F88C File Offset: 0x0003DA8C
		' (set) Token: 0x06008173 RID: 33139 RVA: 0x0003F896 File Offset: 0x0003DA96
		Friend Overridable Property txtSGST As DataGridViewTextBoxColumn

		' Token: 0x17002F8B RID: 12171
		' (get) Token: 0x06008174 RID: 33140 RVA: 0x0003F89F File Offset: 0x0003DA9F
		' (set) Token: 0x06008175 RID: 33141 RVA: 0x0003F8A9 File Offset: 0x0003DAA9
		Friend Overridable Property txtIGST As DataGridViewTextBoxColumn

		' Token: 0x17002F8C RID: 12172
		' (get) Token: 0x06008176 RID: 33142 RVA: 0x0003F8B2 File Offset: 0x0003DAB2
		' (set) Token: 0x06008177 RID: 33143 RVA: 0x0003F8BC File Offset: 0x0003DABC
		Friend Overridable Property txtCESS As DataGridViewTextBoxColumn

		' Token: 0x17002F8D RID: 12173
		' (get) Token: 0x06008178 RID: 33144 RVA: 0x0003F8C5 File Offset: 0x0003DAC5
		' (set) Token: 0x06008179 RID: 33145 RVA: 0x0003F8CF File Offset: 0x0003DACF
		Friend Overridable Property WSPrice As DataGridViewTextBoxColumn

		' Token: 0x17002F8E RID: 12174
		' (get) Token: 0x0600817A RID: 33146 RVA: 0x0003F8D8 File Offset: 0x0003DAD8
		' (set) Token: 0x0600817B RID: 33147 RVA: 0x0003F8E2 File Offset: 0x0003DAE2
		Friend Overridable Property Barcode As DataGridViewTextBoxColumn

		' Token: 0x17002F8F RID: 12175
		' (get) Token: 0x0600817C RID: 33148 RVA: 0x0003F8EB File Offset: 0x0003DAEB
		' (set) Token: 0x0600817D RID: 33149 RVA: 0x0003F8F5 File Offset: 0x0003DAF5
		Friend Overridable Property OpeningStock As DataGridViewTextBoxColumn

		' Token: 0x17002F90 RID: 12176
		' (get) Token: 0x0600817E RID: 33150 RVA: 0x0003F8FE File Offset: 0x0003DAFE
		' (set) Token: 0x0600817F RID: 33151 RVA: 0x0003F908 File Offset: 0x0003DB08
		Friend Overridable Property cmbPurchaseUnit As DataGridViewComboBoxColumn

		' Token: 0x17002F91 RID: 12177
		' (get) Token: 0x06008180 RID: 33152 RVA: 0x0003F911 File Offset: 0x0003DB11
		' (set) Token: 0x06008181 RID: 33153 RVA: 0x0003F91B File Offset: 0x0003DB1B
		Friend Overridable Property cmbSalesUnit As DataGridViewComboBoxColumn

		' Token: 0x17002F92 RID: 12178
		' (get) Token: 0x06008182 RID: 33154 RVA: 0x0003F924 File Offset: 0x0003DB24
		' (set) Token: 0x06008183 RID: 33155 RVA: 0x0003F92E File Offset: 0x0003DB2E
		Friend Overridable Property cmbAltunit As DataGridViewComboBoxColumn

		' Token: 0x17002F93 RID: 12179
		' (get) Token: 0x06008184 RID: 33156 RVA: 0x0003F937 File Offset: 0x0003DB37
		' (set) Token: 0x06008185 RID: 33157 RVA: 0x0003F941 File Offset: 0x0003DB41
		Friend Overridable Property Conv As DataGridViewTextBoxColumn

		' Token: 0x17002F94 RID: 12180
		' (get) Token: 0x06008186 RID: 33158 RVA: 0x0003F94A File Offset: 0x0003DB4A
		' (set) Token: 0x06008187 RID: 33159 RVA: 0x0003F954 File Offset: 0x0003DB54
		Friend Overridable Property txtMinStock As DataGridViewTextBoxColumn

		' Token: 0x17002F95 RID: 12181
		' (get) Token: 0x06008188 RID: 33160 RVA: 0x0003F95D File Offset: 0x0003DB5D
		' (set) Token: 0x06008189 RID: 33161 RVA: 0x0003F967 File Offset: 0x0003DB67
		Friend Overridable Property DefMRP As DataGridViewTextBoxColumn

		' Token: 0x17002F96 RID: 12182
		' (get) Token: 0x0600818A RID: 33162 RVA: 0x0003F970 File Offset: 0x0003DB70
		' (set) Token: 0x0600818B RID: 33163 RVA: 0x0003F97A File Offset: 0x0003DB7A
		Friend Overridable Property Active As DataGridViewTextBoxColumn

		' Token: 0x17002F97 RID: 12183
		' (get) Token: 0x0600818C RID: 33164 RVA: 0x0003F983 File Offset: 0x0003DB83
		' (set) Token: 0x0600818D RID: 33165 RVA: 0x0003F98D File Offset: 0x0003DB8D
		Friend Overridable Property cmbSalesTaxType As DataGridViewComboBoxColumn

		' Token: 0x17002F98 RID: 12184
		' (get) Token: 0x0600818E RID: 33166 RVA: 0x0003F996 File Offset: 0x0003DB96
		' (set) Token: 0x0600818F RID: 33167 RVA: 0x0003F9A0 File Offset: 0x0003DBA0
		Friend Overridable Property cmbPurchaseTaxType As DataGridViewComboBoxColumn

		' Token: 0x17002F99 RID: 12185
		' (get) Token: 0x06008190 RID: 33168 RVA: 0x0003F9A9 File Offset: 0x0003DBA9
		' (set) Token: 0x06008191 RID: 33169 RVA: 0x0003F9B3 File Offset: 0x0003DBB3
		Friend Overridable Property ddlGdown As DataGridViewComboBoxColumn

		' Token: 0x17002F9A RID: 12186
		' (get) Token: 0x06008192 RID: 33170 RVA: 0x0003F9BC File Offset: 0x0003DBBC
		' (set) Token: 0x06008193 RID: 33171 RVA: 0x0003F9C6 File Offset: 0x0003DBC6
		Friend Overridable Property ddlRack As DataGridViewComboBoxColumn

		' Token: 0x17002F9B RID: 12187
		' (get) Token: 0x06008194 RID: 33172 RVA: 0x0003F9CF File Offset: 0x0003DBCF
		' (set) Token: 0x06008195 RID: 33173 RVA: 0x0003F9D9 File Offset: 0x0003DBD9
		Friend Overridable Property txtSaleQty As DataGridViewTextBoxColumn

		' Token: 0x17002F9C RID: 12188
		' (get) Token: 0x06008196 RID: 33174 RVA: 0x0003F9E2 File Offset: 0x0003DBE2
		' (set) Token: 0x06008197 RID: 33175 RVA: 0x0003F9EC File Offset: 0x0003DBEC
		Friend Overridable Property txtOpeningStock As DataGridViewTextBoxColumn

		' Token: 0x17002F9D RID: 12189
		' (get) Token: 0x06008198 RID: 33176 RVA: 0x0003F9F5 File Offset: 0x0003DBF5
		' (set) Token: 0x06008199 RID: 33177 RVA: 0x0003F9FF File Offset: 0x0003DBFF
		Friend Overridable Property txtBarcode_TempStock As DataGridViewTextBoxColumn

		' Token: 0x17002F9E RID: 12190
		' (get) Token: 0x0600819A RID: 33178 RVA: 0x0003FA08 File Offset: 0x0003DC08
		' (set) Token: 0x0600819B RID: 33179 RVA: 0x0003FA12 File Offset: 0x0003DC12
		Friend Overridable Property txtDefMRP As DataGridViewTextBoxColumn

		' Token: 0x17002F9F RID: 12191
		' (get) Token: 0x0600819C RID: 33180 RVA: 0x0003FA1B File Offset: 0x0003DC1B
		' (set) Token: 0x0600819D RID: 33181 RVA: 0x0003FA25 File Offset: 0x0003DC25
		Friend Overridable Property txtRSP As DataGridViewTextBoxColumn

		' Token: 0x17002FA0 RID: 12192
		' (get) Token: 0x0600819E RID: 33182 RVA: 0x0003FA2E File Offset: 0x0003DC2E
		' (set) Token: 0x0600819F RID: 33183 RVA: 0x0003FA38 File Offset: 0x0003DC38
		Friend Overridable Property txtWSP As DataGridViewTextBoxColumn

		' Token: 0x17002FA1 RID: 12193
		' (get) Token: 0x060081A0 RID: 33184 RVA: 0x0003FA41 File Offset: 0x0003DC41
		' (set) Token: 0x060081A1 RID: 33185 RVA: 0x0003FA4B File Offset: 0x0003DC4B
		Friend Overridable Property txtBatch As DataGridViewTextBoxColumn

		' Token: 0x17002FA2 RID: 12194
		' (get) Token: 0x060081A2 RID: 33186 RVA: 0x0003FA54 File Offset: 0x0003DC54
		' (set) Token: 0x060081A3 RID: 33187 RVA: 0x0003FA5E File Offset: 0x0003DC5E
		Friend Overridable Property MfgDate As DataGridViewTextBoxColumn

		' Token: 0x17002FA3 RID: 12195
		' (get) Token: 0x060081A4 RID: 33188 RVA: 0x0003FA67 File Offset: 0x0003DC67
		' (set) Token: 0x060081A5 RID: 33189 RVA: 0x0003FA71 File Offset: 0x0003DC71
		Friend Overridable Property ExpDate As DataGridViewTextBoxColumn

		' Token: 0x17002FA4 RID: 12196
		' (get) Token: 0x060081A6 RID: 33190 RVA: 0x0003FA7A File Offset: 0x0003DC7A
		' (set) Token: 0x060081A7 RID: 33191 RVA: 0x0003FA84 File Offset: 0x0003DC84
		Friend Overridable Property cmbSize As DataGridViewTextBoxColumn

		' Token: 0x17002FA5 RID: 12197
		' (get) Token: 0x060081A8 RID: 33192 RVA: 0x0003FA8D File Offset: 0x0003DC8D
		' (set) Token: 0x060081A9 RID: 33193 RVA: 0x0003FA97 File Offset: 0x0003DC97
		Friend Overridable Property cmbColour As DataGridViewTextBoxColumn

		' Token: 0x17002FA6 RID: 12198
		' (get) Token: 0x060081AA RID: 33194 RVA: 0x0003FAA0 File Offset: 0x0003DCA0
		' (set) Token: 0x060081AB RID: 33195 RVA: 0x0003FAAA File Offset: 0x0003DCAA
		Friend Overridable Property txtIMEI1 As DataGridViewTextBoxColumn

		' Token: 0x17002FA7 RID: 12199
		' (get) Token: 0x060081AC RID: 33196 RVA: 0x0003FAB3 File Offset: 0x0003DCB3
		' (set) Token: 0x060081AD RID: 33197 RVA: 0x0003FABD File Offset: 0x0003DCBD
		Friend Overridable Property txtIMEI2 As DataGridViewTextBoxColumn

		' Token: 0x17002FA8 RID: 12200
		' (get) Token: 0x060081AE RID: 33198 RVA: 0x0003FAC6 File Offset: 0x0003DCC6
		' (set) Token: 0x060081AF RID: 33199 RVA: 0x0003FAD0 File Offset: 0x0003DCD0
		Friend Overridable Property Kitchen As DataGridViewTextBoxColumn

		' Token: 0x17002FA9 RID: 12201
		' (get) Token: 0x060081B0 RID: 33200 RVA: 0x0003FAD9 File Offset: 0x0003DCD9
		' (set) Token: 0x060081B1 RID: 33201 RVA: 0x0003FAE3 File Offset: 0x0003DCE3
		Friend Overridable Property Photo As DataGridViewImageColumn

		' Token: 0x17002FAA RID: 12202
		' (get) Token: 0x060081B2 RID: 33202 RVA: 0x0003FAEC File Offset: 0x0003DCEC
		' (set) Token: 0x060081B3 RID: 33203 RVA: 0x0003FAF6 File Offset: 0x0003DCF6
		Friend Overridable Property InsertButtonColumn As DataGridViewButtonColumn

		' Token: 0x17002FAB RID: 12203
		' (get) Token: 0x060081B4 RID: 33204 RVA: 0x0003FAFF File Offset: 0x0003DCFF
		' (set) Token: 0x060081B5 RID: 33205 RVA: 0x0003FB09 File Offset: 0x0003DD09
		Friend Overridable Property UpdateButtonColumn As DataGridViewButtonColumn

		' Token: 0x17002FAC RID: 12204
		' (get) Token: 0x060081B6 RID: 33206 RVA: 0x0003FB12 File Offset: 0x0003DD12
		' (set) Token: 0x060081B7 RID: 33207 RVA: 0x0003FB1C File Offset: 0x0003DD1C
		Friend Overridable Property DeleteButtonColumn As DataGridViewButtonColumn

		' Token: 0x17002FAD RID: 12205
		' (get) Token: 0x060081B8 RID: 33208 RVA: 0x0003FB25 File Offset: 0x0003DD25
		' (set) Token: 0x060081B9 RID: 33209 RVA: 0x0003FB2F File Offset: 0x0003DD2F
		Friend Overridable Property PrintBarcodeButton As DataGridViewButtonColumn

		' Token: 0x17002FAE RID: 12206
		' (get) Token: 0x060081BA RID: 33210 RVA: 0x0003FB38 File Offset: 0x0003DD38
		' (set) Token: 0x060081BB RID: 33211 RVA: 0x0003FB42 File Offset: 0x0003DD42
		Friend Overridable Property Mark As DataGridViewCheckBoxColumn

		' Token: 0x17002FAF RID: 12207
		' (get) Token: 0x060081BC RID: 33212 RVA: 0x0003FB4B File Offset: 0x0003DD4B
		' (set) Token: 0x060081BD RID: 33213 RVA: 0x0003FB55 File Offset: 0x0003DD55
		Friend Overridable Property variantName As DataGridViewButtonColumn

		' Token: 0x060081BE RID: 33214 RVA: 0x005FB530 File Offset: 0x005F9730
		Private Sub DataforNP()
			Me.con = New SqlConnection(ModCS.cs)
			Me.con.Close()
			Me.CurrentRow = 0
			Me.con.Open()
			Me.Dad = New SqlDataAdapter("Select * FROM Product", Me.con)
			Me.Dad.Fill(Me.Dst, "Product")
			Try
				Me.txtNP.Text = Conversions.ToString(Me.Dst.Tables("Product").Rows(Conversions.ToInteger(Me.CurrentRow))("PID"))
				Me.con.Close()
			Catch ex As Exception
			End Try
			Me.con.Close()
		End Sub

		' Token: 0x060081BF RID: 33215 RVA: 0x005FB620 File Offset: 0x005F9820
		Public Sub fillCategory()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.adp = New SqlDataAdapter()
				Me.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(CategoryName) FROM Category order by 1", Me.con)
				Me.ds = New DataSet("ds")
				Me.adp.Fill(Me.ds)
				Me.dtable = Me.ds.Tables(0)
				Me.cmbCategory.Items.Clear()
				Me.cmbCategory.Items.Add("Select")
				Try
					For Each obj As Object In Me.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbCategory.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter("SELECT distinct RTRIM(SubCategoryName) As SubCategoryName,CategoryName,SubCategory.ID FROM SubCategory,Category where SubCategory.Category=Category.CategoryName order by 1", ModCS.cs)
				Me.subcategories = New DataTable()
				sqlDataAdapter.Fill(Me.subcategories)
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060081C0 RID: 33216 RVA: 0x005FB7B4 File Offset: 0x005F99B4
		Public Sub fillUnit()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.adp = New SqlDataAdapter()
				Me.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Unit) FROM UnitMaster order by 1", Me.con)
				Me.ds = New DataSet("ds")
				Me.adp.Fill(Me.ds)
				Me.dtable = Me.ds.Tables(0)
				Me.cmbSalesUnit.Items.Clear()
				Me.cmbPurchaseUnit.Items.Clear()
				Me.cmbAltunit.Items.Clear()
				Try
					For Each obj As Object In Me.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbSalesUnit.Items.Add(dataRow(0).ToString())
						Me.cmbPurchaseUnit.Items.Add(dataRow(0).ToString())
						Me.cmbAltunit.Items.Add(dataRow(0).ToString())
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

		' Token: 0x060081C1 RID: 33217 RVA: 0x005FB964 File Offset: 0x005F9B64
		Private Sub CustomizeRowHeaders()
			Me.DataGridView1.Columns("ProductName").HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns("ProductName").HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns("ProductName").HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns("cmbCategory").HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns("cmbCategory").HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns("cmbCategory").HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns("cmbSubCategory").HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns("cmbSubCategory").HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns("cmbSubCategory").HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns("txtPartNo").HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns("txtPartNo").HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns("txtPartNo").HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns("txtCostPrice").HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns("txtCostPrice").HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns("txtCostPrice").HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns("cmbGST").HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns("cmbGST").HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns("cmbGST").HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns("txtMinStock").HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns("txtMinStock").HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns("txtMinStock").HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns("cmbPurchaseUnit").HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns("cmbPurchaseUnit").HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns("cmbPurchaseUnit").HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns("txtSaleQty").HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns("txtSaleQty").HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns("txtSaleQty").HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns("txtBarcode_TempStock").HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns("txtBarcode_TempStock").HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns("txtBarcode_TempStock").HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
		End Sub

		' Token: 0x060081C2 RID: 33218 RVA: 0x005FBECC File Offset: 0x005FA0CC
		Private Sub ComboBox1_DropDownClosed(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewComboBoxEditingControl.EditingControlDataGridView
			Dim rowIndex As Integer = editingControlDataGridView.CurrentCell.RowIndex
			Dim flag As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 3
			Dim num As Integer
			If flag Then
				' The following expression was wrapped in a checked-expression
				num = editingControlDataGridView.CurrentCell.ColumnIndex + 2
			Else
				Dim flag2 As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 5
				If flag2 Then
					Dim flag3 As Boolean = Operators.CompareString(Me.DataGridView1.Columns(editingControlDataGridView.CurrentCell.ColumnIndex).Name, "cmbSubCategory", False) = 0
					If flag3 Then
						num = editingControlDataGridView.CurrentCell.ColumnIndex
					End If
				End If
			End If
			editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(rowIndex).Cells(num)
			editingControlDataGridView.BeginEdit(True)
			comboBox.Focus()
		End Sub

		' Token: 0x060081C3 RID: 33219 RVA: 0x005FBFA8 File Offset: 0x005FA1A8
		Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					Dim dataGridView As DataGridView = CType(sender, DataGridView)
					e.Handled = True
					Dim flag2 As Boolean = dataGridView.CurrentCell.ColumnIndex < dataGridView.ColumnCount - 1
					If flag2 Then
						Dim flag3 As Boolean = dataGridView.CurrentCell.ColumnIndex = 3
						If flag3 Then
							dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 2, dataGridView.CurrentCell.RowIndex)
						Else
							Dim flag4 As Boolean = dataGridView.CurrentCell.ColumnIndex = 5
							If flag4 Then
								dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 6, dataGridView.CurrentCell.RowIndex)
							Else
								Dim flag5 As Boolean = dataGridView.CurrentCell.ColumnIndex = 29
								If flag5 Then
									dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 6, dataGridView.CurrentCell.RowIndex)
								Else
									Dim flag6 As Boolean = dataGridView.CurrentCell.ColumnIndex = 39
									If flag6 Then
										dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 6, dataGridView.CurrentCell.RowIndex)
									Else
										Dim flag7 As Boolean = dataGridView.CurrentCell.ColumnIndex = 48
										If flag7 Then
											dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 1, dataGridView.CurrentCell.RowIndex)
										Else
											Dim rowIndex As Integer = dataGridView.CurrentCell.RowIndex
											Dim num As Integer = dataGridView.CurrentCell.ColumnIndex
											While num < dataGridView.ColumnCount AndAlso Not dataGridView.Columns(num).Visible
												num += 1
											End While
											dataGridView.BeginEdit(True)
											dataGridView.CurrentCell = dataGridView(num, rowIndex)
										End If
									End If
								End If
							End If
						End If
					Else
						Dim flag8 As Boolean = dataGridView.CurrentCell.RowIndex < dataGridView.RowCount - 1
						If flag8 Then
							dataGridView.CurrentCell = dataGridView(0, dataGridView.CurrentCell.RowIndex + 1)
						End If
					End If
					Dim rowIndex2 As Integer = Me.DataGridView1.CurrentCell.RowIndex
					Dim columnIndex As Integer = Me.DataGridView1.CurrentCell.ColumnIndex
					Dim flag9 As Boolean = TypeOf dataGridView.CurrentCell Is DataGridViewButtonCell
					If flag9 Then
						Dim name As String = dataGridView.CurrentCell.OwningColumn.Name
						If Operators.CompareString(name, "InsertButtonColumn", False) = 0 Then
							Me.DataGridView1_CellContentClick(Me.DataGridView1, New DataGridViewCellEventArgs(columnIndex, rowIndex2))
						End If
					Else
						dataGridView.BeginEdit(True)
					End If
				End If
				Dim flag10 As Boolean = e.KeyCode = Keys.Left
				If flag10 Then
					Dim flag11 As Boolean = Not(TypeOf Me.DataGridView1.CurrentCell Is DataGridViewComboBoxCell)
					If flag11 Then
						e.Handled = True
						Dim flag12 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex > 0
						If flag12 Then
							Me.DataGridView1.CurrentCell = Me.DataGridView1(Me.DataGridView1.CurrentCell.ColumnIndex - 1, Me.DataGridView1.CurrentCell.RowIndex)
						End If
						Me.DataGridView1.BeginEdit(True)
						e.SuppressKeyPress = True
					End If
				Else
					Dim flag13 As Boolean = e.KeyCode = Keys.Right
					If flag13 Then
						Dim flag14 As Boolean = Not(TypeOf Me.DataGridView1.CurrentCell Is DataGridViewComboBoxCell)
						If flag14 Then
							e.Handled = True
							Dim flag15 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex < Me.DataGridView1.ColumnCount - 1
							If flag15 Then
								Me.DataGridView1.CurrentCell = Me.DataGridView1(Me.DataGridView1.CurrentCell.ColumnIndex + 1, Me.DataGridView1.CurrentCell.RowIndex)
							End If
							Me.DataGridView1.BeginEdit(True)
							e.SuppressKeyPress = True
						End If
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060081C4 RID: 33220 RVA: 0x005FC3D8 File Offset: 0x005FA5D8
		Private Sub ComboBox_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim comboBox As ComboBox = CType(sender, ComboBox)
				Dim text As String = comboBox.Text.Trim()
				Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(Me.DataGridView1.EditingControl, DataGridViewComboBoxEditingControl)
				Dim flag2 As Boolean = Not dataGridViewComboBoxEditingControl.Items.Contains(text)
				If flag2 Then
					dataGridViewComboBoxEditingControl.Items.Add(text)
				End If
				Me.DataGridView1.CurrentCell.Value = text
				Me.DataGridView1.EndEdit()
				Dim flag3 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex < Me.DataGridView1.Columns.Count - 1
				If flag3 Then
					Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(Me.DataGridView1.CurrentCell.RowIndex).Cells(Me.DataGridView1.CurrentCell.ColumnIndex + 1)
				End If
			End If
		End Sub

		' Token: 0x060081C5 RID: 33221 RVA: 0x0003FB5E File Offset: 0x0003DD5E
		Public Sub Reset()
			Me.DataGridView1.Rows.Clear()
			Me.DataGridView1.ClearSelection()
		End Sub

		' Token: 0x060081C6 RID: 33222 RVA: 0x0003FB7E File Offset: 0x0003DD7E
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060081C7 RID: 33223 RVA: 0x005FC4D4 File Offset: 0x005FA6D4
		Private Sub frmProductRecord_Load(sender As Object, e As EventArgs)
			Me.fillGdown()
			Me.fillRack()
			AddHandler Me.DataGridView1.DataError, AddressOf Me.DataGridView1_DataError
			Me.DataGridView1.AutoGenerateColumns = False
			Me.auto()
			Me.GenerateBarcode()
			AddHandler Me.DataGridView1.CellBeginEdit, AddressOf Me.DataGridView1_CellBeginEdit
			Me.DataforNP()
			Me.fillCategory()
			Me.FillSubCat()
			Me.fillUnit()
			Me.fillTaxRate()
			Me.fillProductID()
			Me.fillGdown()
			Me.fillRack()
			Me.SetupDataGridViewColumns()
			Me.default_fill_tax()
			Me.default_fill_Category_data()
			Me.default_fillUnit_Default()
			Me.default_Tax_type1()
		End Sub

		' Token: 0x060081C8 RID: 33224 RVA: 0x005FC598 File Offset: 0x005FA798
		Public Sub default_Tax_type1()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Using sqlCommand As SqlCommand = sqlConnection.CreateCommand()
						sqlCommand.CommandText = "SELECT * FROM Defaulttaxtype WHERE id = @d1"
						sqlCommand.Parameters.AddWithValue("@d1", "1")
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Dim flag As Boolean = sqlDataReader.Read()
							If flag Then
								Dim text As String = sqlDataReader.GetValue(1).ToString()
								Dim text2 As String = sqlDataReader.GetValue(2).ToString()
								Dim num As Integer = 0
								Dim index As Integer = Me.DataGridView1.Columns("cmbSalesTaxType").Index
								Dim index2 As Integer = Me.DataGridView1.Columns("cmbPurchaseTaxType").Index
								Dim dataGridViewComboBoxCell As DataGridViewComboBoxCell = CType(Me.DataGridView1.Rows(num).Cells(index), DataGridViewComboBoxCell)
								Dim flag2 As Boolean = dataGridViewComboBoxCell.Items.Contains(text)
								If flag2 Then
									dataGridViewComboBoxCell.Value = text
								End If
								Dim dataGridViewComboBoxCell2 As DataGridViewComboBoxCell = CType(Me.DataGridView1.Rows(num).Cells(index2), DataGridViewComboBoxCell)
								Dim flag3 As Boolean = dataGridViewComboBoxCell2.Items.Contains(text2)
								If flag3 Then
									dataGridViewComboBoxCell2.Value = text2
								End If
							End If
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060081C9 RID: 33225 RVA: 0x005FC794 File Offset: 0x005FA994
		Public Sub default_Tax_type()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.cmd = Me.con.CreateCommand()
				Me.cmd.CommandText = "SELECT * FROM Defaulttaxtype WHERE id = @d1"
				Me.cmd.Parameters.AddWithValue("@d1", "1")
				Me.rdr = Me.cmd.ExecuteReader()
				Dim flag As Boolean = Me.rdr.Read()
				If flag Then
					Me.strStax = Me.rdr.GetValue(1).ToString()
					Me.strPtax = Me.rdr.GetValue(2).ToString()
					Dim num As Integer = Me.DataGridView1.Rows.Count - 1
					Dim index As Integer = Me.DataGridView1.Columns("cmbSalesTaxType").Index
					Me.DataGridView1.Rows(num).Cells(index).Value = Me.strStax
					Dim index2 As Integer = Me.DataGridView1.Columns("cmbPurchaseTaxType").Index
					Me.DataGridView1.Rows(num).Cells(index2).Value = Me.strPtax
				End If
				Dim flag2 As Boolean = Me.rdr IsNot Nothing
				If flag2 Then
					Me.rdr.Close()
				End If
				Dim flag3 As Boolean = Me.con.State = ConnectionState.Open
				If flag3 Then
					Me.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060081CA RID: 33226 RVA: 0x005FC96C File Offset: 0x005FAB6C
		Public Sub default_fillUnit_Default()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.cmd = Me.con.CreateCommand()
				Me.cmd.CommandText = "SELECT RTRIM(Unit) as Unit, IsDefault FROM UnitMaster where isDefault=@d1"
				Me.cmd.Parameters.AddWithValue("@d1", "Yes")
				Me.rdr = Me.cmd.ExecuteReader()
				Dim flag As Boolean = Me.rdr.Read()
				If flag Then
					Dim text As String = Me.rdr.GetValue(0).ToString()
					Dim num As Integer = Me.DataGridView1.Rows.Count - 1
					Dim index As Integer = Me.DataGridView1.Columns("cmbPurchaseUnit").Index
					Me.DataGridView1.Rows(num).Cells(index).Value = text
					Dim index2 As Integer = Me.DataGridView1.Columns("cmbSalesUnit").Index
					Me.DataGridView1.Rows(num).Cells(index2).Value = text
					Dim index3 As Integer = Me.DataGridView1.Columns("cmbAltunit").Index
					Me.DataGridView1.Rows(num).Cells(index3).Value = text
				End If
				Dim flag2 As Boolean = Me.rdr IsNot Nothing
				If flag2 Then
					Me.rdr.Close()
				End If
				Dim flag3 As Boolean = Me.con.State = ConnectionState.Open
				If flag3 Then
					Me.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060081CB RID: 33227 RVA: 0x005FCB60 File Offset: 0x005FAD60
		Public Sub default_fill_tax()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.cmd = Me.con.CreateCommand()
				Me.cmd.CommandText = "SELECT RTRIM(Rate),RTRIM(IsDefault) from TaxCat where IsDefault=@d1"
				Me.cmd.Parameters.AddWithValue("@d1", "Yes")
				Me.rdr = Me.cmd.ExecuteReader()
				Dim flag As Boolean = Me.rdr.Read()
				If flag Then
					Dim text As String = Me.rdr.GetValue(0).ToString()
					Dim text2 As String = Me.rdr.GetValue(1).ToString()
					Dim dataRow As DataRow = Me.dtable.NewRow()
					dataRow("Column1") = text
					Dim num As Integer = Me.DataGridView1.Rows.Count - 1
					Dim index As Integer = Me.DataGridView1.Columns("cmbGST").Index
					Me.DataGridView1.Rows(num).Cells(index).Value = text
					Dim index2 As Integer = Me.DataGridView1.Columns("txtCGST").Index
					Me.DataGridView1.Rows(num).Cells(index2).Value = Conversions.ToDouble(text) / 2.0
					Dim index3 As Integer = Me.DataGridView1.Columns("txtSGST").Index
					Me.DataGridView1.Rows(num).Cells(index3).Value = Conversions.ToDouble(text) / 2.0
					Dim index4 As Integer = Me.DataGridView1.Columns("txtIGST").Index
					Me.DataGridView1.Rows(num).Cells(index4).Value = text
				End If
				Dim flag2 As Boolean = Me.rdr IsNot Nothing
				If flag2 Then
					Me.rdr.Close()
				End If
				Dim flag3 As Boolean = Me.con.State = ConnectionState.Open
				If flag3 Then
					Me.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060081CC RID: 33228 RVA: 0x005FCDF0 File Offset: 0x005FAFF0
		Public Sub default_fill_Category_data()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.cmd = Me.con.CreateCommand()
				Me.cmd.CommandText = "SELECT ID, RTRIM(SubCategoryName) As SubCategoryName, RTRIM(Category) as CategoryName from SubCategory where isDefault=@d1"
				Me.cmd.Parameters.AddWithValue("@d1", "Yes")
				Me.rdr = Me.cmd.ExecuteReader()
				Dim flag As Boolean = Me.rdr.Read()
				If flag Then
					Dim text As String = Me.rdr.GetValue(0).ToString()
					Dim text2 As String = Me.rdr.GetValue(1).ToString()
					Dim text3 As String = Me.rdr.GetValue(2).ToString()
					Dim num As Integer = Me.DataGridView1.Rows.Count - 1
					Dim index As Integer = Me.DataGridView1.Columns("txtSubCategoryID").Index
					Me.DataGridView1.Rows(num).Cells(index).Value = text
					Dim index2 As Integer = Me.DataGridView1.Columns("cmbCategory").Index
					Me.DataGridView1.Rows(num).Cells(index2).Value = text3
					Dim index3 As Integer = Me.DataGridView1.Columns("cmbSubCategory").Index
					Me.DataGridView1.Rows(num).Cells(index3).Value = text2
				End If
				Dim flag2 As Boolean = Me.rdr IsNot Nothing
				If flag2 Then
					Me.rdr.Close()
				End If
				Dim flag3 As Boolean = Me.con.State = ConnectionState.Open
				If flag3 Then
					Me.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060081CD RID: 33229 RVA: 0x005FD010 File Offset: 0x005FB210
		Public Sub fillTaxRate()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.adp = New SqlDataAdapter()
				Me.adp.SelectCommand = New SqlCommand("SELECT RTRIM(Rate) FROM TaxCat order by Rate ASC", Me.con)
				Me.ds = New DataSet("ds")
				Me.adp.Fill(Me.ds)
				Me.dtable = Me.ds.Tables(0)
				Me.cmbGST.Items.Clear()
				Try
					For Each obj As Object In Me.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbGST.Items.Add(dataRow(0).ToString())
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

		' Token: 0x060081CE RID: 33230 RVA: 0x005FD14C File Offset: 0x005FB34C
		Private Function GenerateID1() As String
			Me.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				Me.con.Open()
				Me.cmd = New SqlCommand("SELECT TOP 1 ID FROM Product_OpeningStock ORDER BY ID DESC", Me.con)
				Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = Me.rdr.HasRows
				If hasRows Then
					Me.rdr.Read()
					text = Conversions.ToString(Me.rdr("ID"))
				End If
				Me.rdr.Close()
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
				Dim flag4 As Boolean = Me.con.State = ConnectionState.Open
				If flag4 Then
					Me.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x060081CF RID: 33231 RVA: 0x005FD2D0 File Offset: 0x005FB4D0
		Public Sub GenerateBarcode()
			Try
				Me.BCodeDisplay()
				Dim text As String = Conversions.ToString(1000.0 + Conversions.ToDouble(Me.GenerateID1()))
				Me.txtBarcodeTempStock.Text = Me.txtBar.Text + text
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060081D0 RID: 33232 RVA: 0x005FD354 File Offset: 0x005FB554
		Public Sub BCodeDisplay()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim sqlCommand As SqlCommand = Me.con.CreateCommand()
				sqlCommand.CommandText = "SELECT RTRIM(BCode) FROM Company"
				sqlCommand.Parameters.Clear()
				Me.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = Me.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.txtBar.Text = Me.rdr.GetValue(0).ToString()
				Else
					Me.txtBar.Text = ""
				End If
				Me.rdr.Close()
				Me.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060081D1 RID: 33233 RVA: 0x005FD444 File Offset: 0x005FB644
		Public Sub ScrollToSelectedCell(rowIndex As Short, colIndex As Short)
			Me.DataGridView1.FirstDisplayedScrollingRowIndex = CInt(rowIndex)
			Me.DataGridView1.FirstDisplayedScrollingColumnIndex = CInt(colIndex)
			Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(CInt(rowIndex)).Cells(CInt(colIndex))
		End Sub

		' Token: 0x060081D2 RID: 33234 RVA: 0x005FD494 File Offset: 0x005FB694
		Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("variantName").Index AndAlso e.RowIndex >= 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
				Me.id = Conversions.ToShort(dataGridViewRow.Cells("PID").Value)
			End If
			Dim flag2 As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("btnAddCategory").Index AndAlso e.RowIndex >= 0
			If flag2 Then
				MyProject.Forms.frmCategory.lblSource.Text = "ProductRec1"
				MyProject.Forms.frmCategory.Reset()
				MyProject.Forms.frmCategory.ShowDialog()
				MyProject.Forms.frmCategory.Dispose()
			End If
			Dim flag3 As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("btnAddSubCategory").Index AndAlso e.RowIndex >= 0
			If flag3 Then
				MyProject.Forms.frmSubCategory.lblSource.Text = "ProductRec1"
				MyProject.Forms.frmSubCategory.lblCurrentCellIndex.Text = Conversions.ToString(e.RowIndex)
				MyProject.Forms.frmSubCategory.Reset()
				MyProject.Forms.frmSubCategory.ShowDialog()
				MyProject.Forms.frmSubCategory.Dispose()
			End If
			Dim flag4 As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("btnAddGSTPer").Index AndAlso e.RowIndex >= 0
			If flag4 Then
				MyProject.Forms.frmTaxCategory.lblSource.Text = "ProductRec1"
				MyProject.Forms.frmTaxCategory.Reset()
				MyProject.Forms.frmTaxCategory.ShowDialog()
				MyProject.Forms.frmTaxCategory.Dispose()
			End If
			Dim flag5 As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("InsertButtonColumn").Index AndAlso e.RowIndex >= 0
			If flag5 Then
				Dim dataGridViewRow2 As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
				Dim flag6 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow2.Cells("ProductName").Value))) = 0
				If flag6 Then
					MessageBox.Show("Please enter product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.ScrollToSelectedCell(CShort(e.RowIndex), 1S)
				Else
					Dim flag7 As Boolean = (Operators.CompareString(Strings.Trim(Conversions.ToString(dataGridViewRow2.Cells("cmbCategory").Value)), "Select", False) = 0) Or (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow2.Cells("cmbCategory").Value))) = 0)
					If flag7 Then
						MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.ScrollToSelectedCell(CShort(e.RowIndex), 3S)
					Else
						Dim flag8 As Boolean = (Operators.CompareString(Strings.Trim(Conversions.ToString(dataGridViewRow2.Cells("cmbSubCategory").Value)), "Select", False) = 0) Or (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow2.Cells("cmbSubCategory").Value))) = 0)
						If flag8 Then
							MessageBox.Show("Please select sub category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.ScrollToSelectedCell(CShort(e.RowIndex), 5S)
						Else
							Dim flag9 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtCostPrice").Value))))) = 0) Or (dataGridViewRow2.Cells("txtCostPrice").Value Is Nothing)
							If flag9 Then
								MessageBox.Show("Please enter purchase price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.ScrollToSelectedCell(CShort(e.RowIndex), 11S)
							Else
								Dim flag10 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow2.Cells("cmbGST").Value))) = 0
								If flag10 Then
									MessageBox.Show("Please select your GST %", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.ScrollToSelectedCell(CShort(e.RowIndex), 14S)
								Else
									Dim flag11 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow2.Cells("cmbPurchaseUnit").Value))) = 0) Or (dataGridViewRow2.Cells("cmbPurchaseUnit").Value Is Nothing)
									If flag11 Then
										MessageBox.Show("Please select purchase unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.ScrollToSelectedCell(CShort(e.RowIndex), 23S)
									Else
										Dim flag12 As Boolean = Strings.Len(Strings.Trim(dataGridViewRow2.Cells("cmbSalesUnit").Value.ToString())) = 0
										If flag12 Then
											MessageBox.Show("Please select sales main unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.ScrollToSelectedCell(CShort(e.RowIndex), 24S)
										Else
											Dim flag13 As Boolean = Strings.Len(Strings.Trim(dataGridViewRow2.Cells("cmbAltunit").Value.ToString())) = 0
											If flag13 Then
												MessageBox.Show("Please select alter unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Me.ScrollToSelectedCell(CShort(e.RowIndex), 25S)
											Else
												Dim flag14 As Boolean = Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataGridViewRow2.Cells("txtSaleQty").Value, 0.0, False), Operators.CompareObjectEqual(dataGridViewRow2.Cells("txtSaleQty").Value, 0, False)))
												If flag14 Then
													MessageBox.Show("Please enter default sale qty", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Me.ScrollToSelectedCell(CShort(e.RowIndex), 34S)
												Else
													Dim flag15 As Boolean = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtDefMRP").Value)) <= 0.0
													If flag15 Then
														MessageBox.Show("Please enter MRP", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
														Me.ScrollToSelectedCell(CShort(e.RowIndex), 37S)
													Else
														Dim flag16 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow2.Cells("txtBarcode_TempStock").Value, "", False)
														If flag16 Then
															MessageBox.Show("Please enter Barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
															Me.ScrollToSelectedCell(CShort(e.RowIndex), 36S)
														Else
															Dim flag17 As Boolean = Me.DataGridView1.Rows.Count > 0
															If flag17 Then
																Try
																	For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
																		Dim dataGridViewRow3 As DataGridViewRow = CType(obj, DataGridViewRow)
																		Me.con = New SqlConnection(ModCS.cs)
																		Me.con.Open()
																		Dim text As String = "select Barcode from Product_OpeningStock where Barcode=@d1"
																		Me.cmd = New SqlCommand(text)
																		Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtBarcode_TempStock").Value))
																		Me.cmd.Connection = Me.con
																		Me.rdr = Me.cmd.ExecuteReader()
																		Dim flag18 As Boolean = Me.rdr.Read()
																		If flag18 Then
																			MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																			Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow3.Cells("txtBarcode_TempStock").ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
																			Dim flag19 As Boolean = Me.rdr IsNot Nothing
																			If flag19 Then
																				Me.rdr.Close()
																			End If
																			Return
																		End If
																		Me.con = New SqlConnection(ModCS.cs)
																		Me.con.Open()
																		Dim text2 As String = "select Barcode from Temp_Stock where Barcode=@d1"
																		Me.cmd = New SqlCommand(text2)
																		Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtBarcode_TempStock").Value))
																		Me.cmd.Connection = Me.con
																		Me.rdr = Me.cmd.ExecuteReader()
																		Dim flag20 As Boolean = Me.rdr.Read()
																		If flag20 Then
																			MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																			Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow3.Cells("txtBarcode_TempStock").ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
																			Dim flag21 As Boolean = Me.rdr IsNot Nothing
																			If flag21 Then
																				Me.rdr.Close()
																			End If
																			Return
																		End If
																	Next
																Finally
																	Dim enumerator As IEnumerator
																	If TypeOf enumerator Is IDisposable Then
																		TryCast(enumerator, IDisposable).Dispose()
																	End If
																End Try
															Else
																Dim flag22 As Boolean = Me.DataGridView1.Rows.Count <= 0
																If flag22 Then
																	Me.con = New SqlConnection(ModCS.cs)
																	Me.con.Open()
																	Dim text3 As String = "select Barcode from Product_OpeningStock where Barcode=@d1"
																	Me.cmd = New SqlCommand(text3)
																	Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtBarcode_TempStock").Value))
																	Me.cmd.Connection = Me.con
																	Me.rdr = Me.cmd.ExecuteReader()
																	Dim flag23 As Boolean = Me.rdr.Read()
																	If flag23 Then
																		MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																		Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow2.Cells("txtBarcode_TempStock").ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
																		Dim flag24 As Boolean = Me.rdr IsNot Nothing
																		If flag24 Then
																			Me.rdr.Close()
																		End If
																		Return
																	End If
																	Me.con = New SqlConnection(ModCS.cs)
																	Me.con.Open()
																	Dim text4 As String = "select Barcode from Temp_Stock where Barcode=@d1"
																	Me.cmd = New SqlCommand(text4)
																	Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtBarcode_TempStock").Value))
																	Me.cmd.Connection = Me.con
																	Me.rdr = Me.cmd.ExecuteReader()
																	Dim flag25 As Boolean = Me.rdr.Read()
																	If flag25 Then
																		MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																		Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow2.Cells("txtBarcode_TempStock").ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
																		Dim flag26 As Boolean = Me.rdr IsNot Nothing
																		If flag26 Then
																			Me.rdr.Close()
																		End If
																		Return
																	End If
																End If
															End If
															Me.auto()
															Dim text5 As String = "insert into Product(PID,ProductCode, Productname, SubCategoryID, Description, CostPrice, Discount,CGST, " & vbCrLf & "Barcode,PurchaseUnit,SalesUnit,SGST,HSNCode,PartNo,Cess,SalesAltUnit,Conv,MinStock,Status,STax,PTax,GDown,Rack,MRP,SellingPrice,ReorderPoint,OpeningStock,AddDate,DefQty,Kitchen) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d7,@d8,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31,@d32,@d33)"
															Me.cmd = New SqlCommand(text5)
															Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
															Me.cmd.Parameters.AddWithValue("@d1", dataGridViewRow2.Cells("ProductCode").Value.ToString())
															Me.cmd.Parameters.AddWithValue("@d2", dataGridViewRow2.Cells("ProductName").Value.ToString())
															Dim flag27 As Boolean = dataGridViewRow2.Cells("txtSubCategoryID").Value IsNot Nothing
															If flag27 Then
																Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(dataGridViewRow2.Cells("txtSubCategoryID").Value.ToString()))
															Else
																Me.cmd.Parameters.AddWithValue("@d3", "")
															End If
															Dim flag28 As Boolean = dataGridViewRow2.Cells("txtFeatures").Value IsNot Nothing
															If flag28 Then
																Me.cmd.Parameters.AddWithValue("@d4", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtFeatures").Value))
															Else
																Me.cmd.Parameters.AddWithValue("@d4", dataGridViewRow2.Cells("ProductName").Value.ToString())
															End If
															Dim flag29 As Boolean = dataGridViewRow2.Cells("txtCostPrice").Value IsNot Nothing
															If flag29 Then
																Me.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtCostPrice").Value)))
															Else
																Me.cmd.Parameters.AddWithValue("@d5", 0)
															End If
															Dim flag30 As Boolean = dataGridViewRow2.Cells("txtDiscount").Value IsNot Nothing
															If flag30 Then
																Me.cmd.Parameters.AddWithValue("@d7", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtDiscount").Value)))
															Else
																Me.cmd.Parameters.AddWithValue("@d7", 0)
															End If
															Dim flag31 As Boolean = dataGridViewRow2.Cells("txtCGST").Value IsNot Nothing
															If flag31 Then
																Me.cmd.Parameters.AddWithValue("@d8", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtCGST").Value)))
															Else
																Me.cmd.Parameters.AddWithValue("@d8", 0)
															End If
															Me.cmd.Parameters.AddWithValue("@d11", "0")
															Me.cmd.Parameters.AddWithValue("@d12", dataGridViewRow2.Cells("cmbPurchaseUnit").Value.ToString())
															Me.cmd.Parameters.AddWithValue("@d13", dataGridViewRow2.Cells("cmbSalesUnit").Value.ToString())
															Dim flag32 As Boolean = dataGridViewRow2.Cells("txtSGST").Value IsNot Nothing
															If flag32 Then
																Me.cmd.Parameters.AddWithValue("@d14", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtSGST").Value)))
															Else
																Me.cmd.Parameters.AddWithValue("@d14", 0)
															End If
															Me.cmd.Parameters.AddWithValue("@d15", dataGridViewRow2.Cells("txtHSNCode").Value.ToString())
															Dim flag33 As Boolean = dataGridViewRow2.Cells("txtPartNo").Value IsNot Nothing
															If flag33 Then
																Me.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtPartNo").Value))
															Else
																Me.cmd.Parameters.AddWithValue("@d16", "0")
															End If
															Dim flag34 As Boolean = dataGridViewRow2.Cells("txtCESS").Value IsNot Nothing
															If flag34 Then
																Me.cmd.Parameters.AddWithValue("@d17", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtCESS").Value)))
															Else
																Me.cmd.Parameters.AddWithValue("@d17", 0)
															End If
															Me.cmd.Parameters.AddWithValue("@d18", dataGridViewRow2.Cells("cmbAltunit").Value.ToString())
															Me.cmd.Parameters.AddWithValue("@d19", Conversion.Val(dataGridViewRow2.Cells("Conv").Value.ToString()))
															Dim flag35 As Boolean = dataGridViewRow2.Cells("txtMinStock").Value IsNot Nothing
															If flag35 Then
																Me.cmd.Parameters.AddWithValue("@d20", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtMinStock").Value)))
															Else
																Me.cmd.Parameters.AddWithValue("@d20", 1)
															End If
															Me.cmd.Parameters.AddWithValue("@d22", "Yes")
															Me.cmd.Parameters.AddWithValue("@d23", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("cmbSalesTaxType").Value))
															Me.cmd.Parameters.AddWithValue("@d24", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("cmbPurchaseTaxType").Value))
															Dim flag36 As Boolean = dataGridViewRow2.Cells("ddlGDown").Value IsNot Nothing
															If flag36 Then
																Me.cmd.Parameters.AddWithValue("@d25", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("ddlGDown").Value))
															Else
																Me.cmd.Parameters.AddWithValue("@d25", "")
															End If
															Dim flag37 As Boolean = dataGridViewRow2.Cells("ddlRack").Value IsNot Nothing
															If flag37 Then
																Me.cmd.Parameters.AddWithValue("@d26", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("ddlRack").Value))
															Else
																Me.cmd.Parameters.AddWithValue("@d26", "")
															End If
															Dim flag38 As Boolean = dataGridViewRow2.Cells("txtDefMRP").Value IsNot Nothing
															If flag38 Then
																Me.cmd.Parameters.AddWithValue("@d27", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtDefMRP").Value))
															Else
																Me.cmd.Parameters.AddWithValue("@d27", 0)
															End If
															Dim flag39 As Boolean = dataGridViewRow2.Cells("txtRSP").Value IsNot Nothing
															If flag39 Then
																Me.cmd.Parameters.AddWithValue("@d28", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtRSP").Value))
															Else
																Me.cmd.Parameters.AddWithValue("@d28", 0)
															End If
															Dim flag40 As Boolean = dataGridViewRow2.Cells("txtWSP").Value IsNot Nothing
															If flag40 Then
																Me.cmd.Parameters.AddWithValue("@d29", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtWSP").Value))
															Else
																Me.cmd.Parameters.AddWithValue("@d29", 0)
															End If
															Me.cmd.Parameters.AddWithValue("@d30", "0")
															Me.cmd.Parameters.AddWithValue("@d31", DateTime.Today)
															Dim flag41 As Boolean = Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataGridViewRow2.Cells("txtSaleQty").Value, 0.0, False), Operators.CompareObjectEqual(dataGridViewRow2.Cells("txtSaleQty").Value, 0, False)))
															If flag41 Then
																Me.cmd.Parameters.AddWithValue("@d32", "1")
															Else
																Me.cmd.Parameters.AddWithValue("@d32", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtSaleQty").Value))
															End If
															Me.cmd.Parameters.AddWithValue("@d33", "")
															Me.con = New SqlConnection(ModCS.cs)
															Try
																Me.con.Open()
																Me.cmd.Connection = Me.con
																Me.cmd.ExecuteNonQuery()
																Me.con.Close()
																Me.con.Open()
																Dim text6 As String = "insert into Product_Join(ProductID,photo) VALUES (" + Me.txtID.Text + ",@d2)"
																Me.cmd = New SqlCommand(text6)
																Me.cmd.Connection = Me.con
																Me.cmd.Prepare()
																Try
																	For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
																		Dim dataGridViewRow4 As DataGridViewRow = CType(obj2, DataGridViewRow)
																		Dim isNewRow As Boolean = dataGridViewRow4.IsNewRow
																		If isNewRow Then
																			Dim memoryStream As MemoryStream = New MemoryStream()
																			Dim image As Image = CType(dataGridViewRow4.Cells("Photo").Value, Image)
																			Dim bitmap As Bitmap = New Bitmap(image)
																			bitmap.Save(memoryStream, ImageFormat.Jpeg)
																			Dim buffer As Byte() = memoryStream.GetBuffer()
																			Dim sqlParameter As SqlParameter = New SqlParameter("@d2", SqlDbType.Image)
																			sqlParameter.Value = buffer
																			Me.cmd.Parameters.Add(sqlParameter)
																			Me.cmd.ExecuteNonQuery()
																			Me.cmd.Parameters.Clear()
																		End If
																	Next
																Finally
																	Dim enumerator2 As IEnumerator
																	If TypeOf enumerator2 Is IDisposable Then
																		TryCast(enumerator2, IDisposable).Dispose()
																	End If
																End Try
																Me.con.Close()
																Me.con.Open()
																Dim text7 As String = "insert into Product_OpeningStock(ProductID,Qty,MRP,SalePrice,WSalePrice,Batch,Mfgdate,Expdate,Size,Colour,Barcode,PAddDate,RCipher,WCipher,PPrice,OPSValue,IMEI1,IMEI2) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)"
																Me.cmd = New SqlCommand(text7)
																Me.cmd.Connection = Me.con
																Me.cmd.Prepare()
																Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
																Dim flag42 As Boolean = dataGridViewRow2.Cells("txtOpeningStock").Value IsNot Nothing
																If flag42 Then
																	Me.cmd.Parameters.AddWithValue("@d1", 0.0)
																Else
																	Me.cmd.Parameters.AddWithValue("@d1", 0)
																End If
																Dim flag43 As Boolean = dataGridViewRow2.Cells("txtDefMRP").Value IsNot Nothing
																If flag43 Then
																	Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtDefMRP").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d2", 0)
																End If
																Dim flag44 As Boolean = dataGridViewRow2.Cells("txtRSP").Value IsNot Nothing
																If flag44 Then
																	Me.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtRSP").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d3", 0)
																End If
																Dim flag45 As Boolean = dataGridViewRow2.Cells("txtWSP").Value IsNot Nothing
																If flag45 Then
																	Me.cmd.Parameters.AddWithValue("@d4", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtWSP").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d4", 0)
																End If
																Dim flag46 As Boolean = dataGridViewRow2.Cells("txtBatch").Value IsNot Nothing
																If flag46 Then
																	Me.cmd.Parameters.AddWithValue("@d5", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtBatch").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d5", "")
																End If
																Dim flag47 As Boolean = dataGridViewRow2.Cells("MfgDate").Value IsNot Nothing
																If flag47 Then
																	Me.cmd.Parameters.AddWithValue("@d6", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("MfgDate").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d6", "")
																End If
																Dim flag48 As Boolean = dataGridViewRow2.Cells("ExpDate").Value IsNot Nothing
																If flag48 Then
																	Me.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("ExpDate").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d7", "")
																End If
																Dim flag49 As Boolean = dataGridViewRow2.Cells("cmbSize").Value IsNot Nothing
																If flag49 Then
																	Me.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("cmbSize").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d8", "")
																End If
																Dim flag50 As Boolean = dataGridViewRow2.Cells("cmbColour").Value IsNot Nothing
																If flag50 Then
																	Me.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("cmbColour").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d9", "")
																End If
																Me.cmd.Parameters.AddWithValue("@d10", Me.txtBarcodeTempStock.Text)
																Me.cmd.Parameters.AddWithValue("@d11", DateTime.Today)
																Me.cmd.Parameters.AddWithValue("@d12", "")
																Me.cmd.Parameters.AddWithValue("@d13", "")
																Dim flag51 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow2.Cells("cmbPurchaseTaxType").Value, "Inclusive", False)
																Dim num As Double
																If flag51 Then
																	num = Conversions.ToDouble(String.Format(Conversions.ToString(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtCostPrice").Value)), 2)), "0.00"))
																Else
																	num = Conversions.ToDouble(String.Format(Conversions.ToString(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtCostPrice").Value)), 2)), "0.00"))
																End If
																Me.cmd.Parameters.AddWithValue("@d14", num)
																Me.cmd.Parameters.AddWithValue("@d15", String.Format(Conversions.ToString(Math.Round(num * Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtOpeningStock").Value)), 2)), "0.00"))
																Dim flag52 As Boolean = dataGridViewRow2.Cells("txtIMEI1").Value IsNot Nothing
																If flag52 Then
																	Me.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtIMEI1").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d16", "")
																End If
																Dim flag53 As Boolean = dataGridViewRow2.Cells("txtIMEI2").Value IsNot Nothing
																If flag53 Then
																	Me.cmd.Parameters.AddWithValue("@d17", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtIMEI2").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d17", "")
																End If
																Me.cmd.ExecuteNonQuery()
																Me.cmd.Parameters.Clear()
																Me.con.Close()
																Me.con = New SqlConnection(ModCS.cs)
																Me.con.Open()
																Dim text8 As String = "insert into Temp_Stock(ProductID, Qty, Barcode, SPrice, WPrice, StLimit, MRP, " & vbCrLf & "Batch, MfgDate, ExpDate, Size, Colour, SalePrice, WSalePrice, SuplName, IMEI1, IMEI2, PPrice, EPPrice, QrBarcode, SalesManPur, Variant_id) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21)"
																Me.cmd = New SqlCommand(text8)
																Me.cmd.Connection = Me.con
																Me.cmd.Prepare()
																Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
																Dim flag54 As Boolean = dataGridViewRow2.Cells("txtOpeningStock").Value IsNot Nothing
																If flag54 Then
																	Me.cmd.Parameters.AddWithValue("@d1", 0.0)
																Else
																	Me.cmd.Parameters.AddWithValue("@d1", 0)
																End If
																Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtBarcode_TempStock").Value))
																Dim flag55 As Boolean = dataGridViewRow2.Cells("txtRSP").Value IsNot Nothing
																If flag55 Then
																	Me.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtRSP").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d3", 0)
																End If
																Dim flag56 As Boolean = dataGridViewRow2.Cells("txtWSP").Value IsNot Nothing
																If flag56 Then
																	Me.cmd.Parameters.AddWithValue("@d4", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtWSP").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d4", 0)
																End If
																Dim flag57 As Boolean = dataGridViewRow2.Cells("txtMinStock").Value IsNot Nothing
																If flag57 Then
																	Me.cmd.Parameters.AddWithValue("@d5", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtMinStock").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d5", 0)
																End If
																Dim flag58 As Boolean = dataGridViewRow2.Cells("txtDefMRP").Value IsNot Nothing
																If flag58 Then
																	Me.cmd.Parameters.AddWithValue("@d6", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtDefMRP").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d6", 0)
																End If
																Dim flag59 As Boolean = dataGridViewRow2.Cells("txtBatch").Value IsNot Nothing
																If flag59 Then
																	Me.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtBatch").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d7", "")
																End If
																Dim flag60 As Boolean = dataGridViewRow2.Cells("MfgDate").Value IsNot Nothing
																If flag60 Then
																	Me.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("MfgDate").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d8", "")
																End If
																Dim flag61 As Boolean = dataGridViewRow2.Cells("ExpDate").Value IsNot Nothing
																If flag61 Then
																	Me.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("ExpDate").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d9", "")
																End If
																Dim flag62 As Boolean = dataGridViewRow2.Cells("cmbSize").Value IsNot Nothing
																If flag62 Then
																	Me.cmd.Parameters.AddWithValue("@d10", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("cmbSize").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d10", "")
																End If
																Dim flag63 As Boolean = dataGridViewRow2.Cells("cmbColour").Value IsNot Nothing
																If flag63 Then
																	Me.cmd.Parameters.AddWithValue("@d11", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("cmbColour").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d11", "")
																End If
																Dim flag64 As Boolean = dataGridViewRow2.Cells("txtRSP").Value IsNot Nothing
																If flag64 Then
																	Me.cmd.Parameters.AddWithValue("@d12", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtRSP").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d12", 0)
																End If
																Dim flag65 As Boolean = dataGridViewRow2.Cells("txtWSP").Value IsNot Nothing
																If flag65 Then
																	Me.cmd.Parameters.AddWithValue("@d13", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtWSP").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d13", 0)
																End If
																Me.cmd.Parameters.AddWithValue("@d14", "Opening Stock")
																Dim flag66 As Boolean = dataGridViewRow2.Cells("txtIMEI1").Value IsNot Nothing
																If flag66 Then
																	Me.cmd.Parameters.AddWithValue("@d15", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtIMEI1").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d15", "")
																End If
																Dim flag67 As Boolean = dataGridViewRow2.Cells("txtIMEI2").Value IsNot Nothing
																If flag67 Then
																	Me.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtIMEI2").Value))
																Else
																	Me.cmd.Parameters.AddWithValue("@d16", "")
																End If
																Dim flag68 As Boolean = dataGridViewRow2.Cells("txtCostPrice").Value IsNot Nothing
																If flag68 Then
																	Me.cmd.Parameters.AddWithValue("@d17", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtCostPrice").Value)))
																	Me.cmd.Parameters.AddWithValue("@d18", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("txtCostPrice").Value)))
																Else
																	Me.cmd.Parameters.AddWithValue("@d17", 0)
																	Me.cmd.Parameters.AddWithValue("@d18", 0)
																End If
																Me.Generate_GiftQR(Conversions.ToString(dataGridViewRow2.Cells("txtBarcode_TempStock").Value))
																Dim memoryStream2 As MemoryStream = New MemoryStream()
																Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
																bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
																Dim buffer2 As Byte() = memoryStream2.GetBuffer()
																Dim sqlParameter2 As SqlParameter = New SqlParameter("@d19", SqlDbType.Image)
																sqlParameter2.Value = buffer2
																Me.cmd.Parameters.AddWithValue("@d20", 0.0)
																Me.cmd.Parameters.AddWithValue("@d21", Conversion.Val(Me.txtID.Text))
																Me.cmd.Parameters.Add(sqlParameter2)
																Me.cmd.ExecuteNonQuery()
																Me.cmd.Parameters.Clear()
																Me.con.Close()
																Me.con = New SqlConnection(ModCS.cs)
																Me.con.Open()
																Dim text9 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
																Me.cmd = New SqlCommand(text9)
																Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
																Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("cmbSalesUnit").Value))
																Me.cmd.Connection = Me.con
																Me.cmd.ExecuteReader()
																Me.con.Close()
																Me.con = New SqlConnection(ModCS.cs)
																Me.con.Open()
																Dim text10 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
																Me.cmd = New SqlCommand(text10)
																Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
																Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells("cmbAltunit").Value))
																Me.cmd.Connection = Me.con
																Me.cmd.ExecuteReader()
																Me.con.Close()
																MessageBox.Show("Successfully Saved", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
																Me.con.Close()
																Me.DataGridView1.CurrentCell = Me.DataGridView1(2, e.RowIndex)
																Dim text11 As String = Conversions.ToString(dataGridViewRow2.Cells("txtBarcode_TempStock").Value)
																Dim num2 As Decimal = Conversions.ToDecimal(dataGridViewRow2.Cells("txtOpeningStock").Value)
																MyProject.Forms.frmPurchaseEntry.ReceivedValue1 = Convert.ToDouble(num2)
																MyProject.Forms.frmPurchaseEntry.ReceivedValue = text11
																MyBase.Dispose()
															Catch ex As Exception
																MessageBox.Show(String.Format("Error inserting row: {0}", ex.Message))
															Finally
																Me.con.Close()
															End Try
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
		End Sub

		' Token: 0x060081D3 RID: 33235 RVA: 0x005FFDD0 File Offset: 0x005FDFD0
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x060081D4 RID: 33236 RVA: 0x005FFE54 File Offset: 0x005FE054
		Public Sub DBoperation(rowNo As Integer, Operation As String)
			Dim flag As Boolean = Operators.CompareString(Operation, "Insert", False) = 0 AndAlso rowNo >= 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.Rows(rowNo)
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("ProductName").Value))) = 0
				If flag2 Then
					MessageBox.Show("Please enter product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Dim flag3 As Boolean = (Operators.CompareString(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("cmbCategory").Value)), "Select", False) = 0) Or (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("cmbCategory").Value))) = 0)
					If flag3 Then
						MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Dim flag4 As Boolean = (Operators.CompareString(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("cmbSubCategory").Value)), "Select", False) = 0) Or (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("cmbSubCategory").Value))) = 0)
						If flag4 Then
							MessageBox.Show("Please select sub category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							Dim flag5 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtPartNo").Value))))) = 0) Or (dataGridViewRow.Cells("txtPartNo").Value Is Nothing)
							If flag5 Then
								MessageBox.Show("Please enter Part No", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Else
								Dim flag6 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtCostPrice").Value))))) = 0) Or (dataGridViewRow.Cells("txtCostPrice").Value Is Nothing)
								If flag6 Then
									MessageBox.Show("Please enter purchase price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Else
									Dim flag7 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(Conversion.Val(dataGridViewRow.Cells("txtDiscount").Value.ToString())))) = 0
									If flag7 Then
										MessageBox.Show("Please enter Discount%", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Else
										Dim flag8 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("cmbGST").Value))) = 0
										If flag8 Then
											MessageBox.Show("Please select your GST %", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Else
											Dim flag9 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells("txtMinStock").Value, "", False)
											If flag9 Then
												MessageBox.Show("Please enter minimum stock", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Else
												Dim flag10 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("cmbPurchaseUnit").Value))) = 0) Or (dataGridViewRow.Cells("cmbPurchaseUnit").Value Is Nothing)
												If flag10 Then
													MessageBox.Show("Please select purchase unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Else
													Dim flag11 As Boolean = Strings.Len(Strings.Trim(dataGridViewRow.Cells("cmbSalesUnit").Value.ToString())) = 0
													If flag11 Then
														MessageBox.Show("Please select sales main unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Else
														Dim flag12 As Boolean = Strings.Len(Strings.Trim(dataGridViewRow.Cells("cmbAltunit").Value.ToString())) = 0
														If flag12 Then
															MessageBox.Show("Please select alter unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
														Else
															Dim flag13 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("Conv").Value))))) = 0) Or (dataGridViewRow.Cells("Conv").Value Is Nothing)
															If flag13 Then
																MessageBox.Show("Please enter conversion value", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
															Else
																Dim flag14 As Boolean = Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataGridViewRow.Cells("txtSaleQty").Value, 0.0, False), Operators.CompareObjectEqual(dataGridViewRow.Cells("txtSaleQty").Value, 0, False)))
																If flag14 Then
																	MessageBox.Show("Please enter default sale qty", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																Else
																	Dim flag15 As Boolean = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtDefMRP").Value)) <= 0.0
																	If flag15 Then
																		MessageBox.Show("Please enter MRP", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																	Else
																		Dim flag16 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells("txtBarcode_TempStock").Value, "", False)
																		If flag16 Then
																			MessageBox.Show("Please enter Barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																			Me.txtBarcode.Focus()
																		Else
																			Dim flag17 As Boolean = Me.DataGridView1.Rows.Count > 0
																			If flag17 Then
																				Try
																					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
																						Dim dataGridViewRow2 As DataGridViewRow = CType(obj, DataGridViewRow)
																						Me.con = New SqlConnection(ModCS.cs)
																						Me.con.Open()
																						Dim text As String = "select Barcode from Product_OpeningStock where Barcode=@d1"
																						Me.cmd = New SqlCommand(text)
																						Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtBarcode_TempStock").Value))
																						Me.cmd.Connection = Me.con
																						Me.rdr = Me.cmd.ExecuteReader()
																						Dim flag18 As Boolean = Me.rdr.Read()
																						If flag18 Then
																							MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																							Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow2.Cells("txtBarcode_TempStock").ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
																							Dim flag19 As Boolean = Me.rdr IsNot Nothing
																							If flag19 Then
																								Me.rdr.Close()
																							End If
																							Return
																						End If
																						Me.con = New SqlConnection(ModCS.cs)
																						Me.con.Open()
																						Dim text2 As String = "select Barcode from Temp_Stock where Barcode=@d1"
																						Me.cmd = New SqlCommand(text2)
																						Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtBarcode_TempStock").Value))
																						Me.cmd.Connection = Me.con
																						Me.rdr = Me.cmd.ExecuteReader()
																						Dim flag20 As Boolean = Me.rdr.Read()
																						If flag20 Then
																							MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																							Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow2.Cells("txtBarcode_TempStock").ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
																							Dim flag21 As Boolean = Me.rdr IsNot Nothing
																							If flag21 Then
																								Me.rdr.Close()
																							End If
																							Return
																						End If
																					Next
																				Finally
																					Dim enumerator As IEnumerator
																					If TypeOf enumerator Is IDisposable Then
																						TryCast(enumerator, IDisposable).Dispose()
																					End If
																				End Try
																			Else
																				Dim flag22 As Boolean = Me.DataGridView1.Rows.Count <= 0
																				If flag22 Then
																					Me.con = New SqlConnection(ModCS.cs)
																					Me.con.Open()
																					Dim text3 As String = "select Barcode from Product_OpeningStock where Barcode=@d1"
																					Me.cmd = New SqlCommand(text3)
																					Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtBarcode_TempStock").Value))
																					Me.cmd.Connection = Me.con
																					Me.rdr = Me.cmd.ExecuteReader()
																					Dim flag23 As Boolean = Me.rdr.Read()
																					If flag23 Then
																						MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																						Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow.Cells("txtBarcode_TempStock").ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
																						Dim flag24 As Boolean = Me.rdr IsNot Nothing
																						If flag24 Then
																							Me.rdr.Close()
																						End If
																						Return
																					End If
																					Me.con = New SqlConnection(ModCS.cs)
																					Me.con.Open()
																					Dim text4 As String = "select Barcode from Temp_Stock where Barcode=@d1"
																					Me.cmd = New SqlCommand(text4)
																					Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtBarcode_TempStock").Value))
																					Me.cmd.Connection = Me.con
																					Me.rdr = Me.cmd.ExecuteReader()
																					Dim flag25 As Boolean = Me.rdr.Read()
																					If flag25 Then
																						MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																						Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow.Cells("txtBarcode_TempStock").ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
																						Dim flag26 As Boolean = Me.rdr IsNot Nothing
																						If flag26 Then
																							Me.rdr.Close()
																						End If
																						Return
																					End If
																				End If
																			End If
																			Me.auto()
																			Dim text5 As String = "insert into Product(PID,ProductCode, Productname, SubCategoryID, Description, CostPrice, Discount,CGST, " & vbCrLf & "Barcode,PurchaseUnit,SalesUnit,SGST,HSNCode,PartNo,Cess,SalesAltUnit,Conv,MinStock,Status,STax,PTax,GDown,Rack,MRP,SellingPrice,ReorderPoint,OpeningStock,AddDate,DefQty,Kitchen) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d7,@d8,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31,@d32,@d33)"
																			Me.cmd = New SqlCommand(text5)
																			Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
																			Me.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells("ProductCode").Value.ToString())
																			Me.cmd.Parameters.AddWithValue("@d2", dataGridViewRow.Cells("ProductName").Value.ToString())
																			Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(dataGridViewRow.Cells("txtSubCategoryID").Value.ToString()))
																			Dim flag27 As Boolean = dataGridViewRow.Cells("txtFeatures").Value IsNot Nothing
																			If flag27 Then
																				Me.cmd.Parameters.AddWithValue("@d4", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtFeatures").Value))
																			Else
																				Me.cmd.Parameters.AddWithValue("@d4", dataGridViewRow.Cells("ProductName").Value.ToString())
																			End If
																			Me.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtCostPrice").Value)))
																			Me.cmd.Parameters.AddWithValue("@d7", Conversion.Val(dataGridViewRow.Cells("txtDiscount").Value.ToString()))
																			Me.cmd.Parameters.AddWithValue("@d8", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtCGST").Value)))
																			Me.cmd.Parameters.AddWithValue("@d11", "0")
																			Me.cmd.Parameters.AddWithValue("@d12", dataGridViewRow.Cells("cmbPurchaseUnit").Value.ToString())
																			Me.cmd.Parameters.AddWithValue("@d13", dataGridViewRow.Cells("cmbSalesUnit").Value.ToString())
																			Me.cmd.Parameters.AddWithValue("@d14", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtSGST").Value)))
																			Me.cmd.Parameters.AddWithValue("@d15", dataGridViewRow.Cells("txtHSNCode").Value.ToString())
																			Me.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtPartNo").Value))
																			Me.cmd.Parameters.AddWithValue("@d17", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtCESS").Value)))
																			Me.cmd.Parameters.AddWithValue("@d18", dataGridViewRow.Cells("cmbAltunit").Value.ToString())
																			Me.cmd.Parameters.AddWithValue("@d19", Conversion.Val(dataGridViewRow.Cells("Conv").Value.ToString()))
																			Me.cmd.Parameters.AddWithValue("@d20", Conversion.Val(dataGridViewRow.Cells("txtMinStock").Value.ToString()))
																			Me.cmd.Parameters.AddWithValue("@d22", "Yes")
																			Me.cmd.Parameters.AddWithValue("@d23", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbSalesTaxType").Value))
																			Me.cmd.Parameters.AddWithValue("@d24", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbPurchaseTaxType").Value))
																			Dim flag28 As Boolean = dataGridViewRow.Cells("ddlGDown").Value IsNot Nothing
																			If flag28 Then
																				Me.cmd.Parameters.AddWithValue("@d25", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("ddlGDown").Value))
																			Else
																				Me.cmd.Parameters.AddWithValue("@d25", "")
																			End If
																			Dim flag29 As Boolean = dataGridViewRow.Cells("ddlRack").Value IsNot Nothing
																			If flag29 Then
																				Me.cmd.Parameters.AddWithValue("@d26", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("ddlRack").Value))
																			Else
																				Me.cmd.Parameters.AddWithValue("@d26", "")
																			End If
																			Me.cmd.Parameters.AddWithValue("@d27", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtDefMRP").Value)))
																			Me.cmd.Parameters.AddWithValue("@d28", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtRSP").Value)))
																			Me.cmd.Parameters.AddWithValue("@d29", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtWSP").Value)))
																			Me.cmd.Parameters.AddWithValue("@d30", "0")
																			Me.cmd.Parameters.AddWithValue("@d31", DateTime.Today)
																			Dim flag30 As Boolean = Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataGridViewRow.Cells("txtSaleQty").Value, 0.0, False), Operators.CompareObjectEqual(dataGridViewRow.Cells("txtSaleQty").Value, 0, False)))
																			If flag30 Then
																				Me.cmd.Parameters.AddWithValue("@d32", "1")
																			Else
																				Me.cmd.Parameters.AddWithValue("@d32", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtSaleQty").Value))
																			End If
																			Me.cmd.Parameters.AddWithValue("@d33", "")
																			Me.con = New SqlConnection(ModCS.cs)
																			Try
																				Me.con.Open()
																				Me.cmd.Connection = Me.con
																				Me.cmd.ExecuteNonQuery()
																				Me.con.Close()
																				Me.con.Open()
																				Dim text6 As String = "insert into Product_Join(ProductID,photo) VALUES (" + Me.txtID.Text + ",@d2)"
																				Me.cmd = New SqlCommand(text6)
																				Me.cmd.Connection = Me.con
																				Me.cmd.Prepare()
																				Try
																					For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
																						Dim dataGridViewRow3 As DataGridViewRow = CType(obj2, DataGridViewRow)
																						Dim isNewRow As Boolean = dataGridViewRow3.IsNewRow
																						If isNewRow Then
																							Dim memoryStream As MemoryStream = New MemoryStream()
																							Dim image As Image = CType(dataGridViewRow3.Cells("Photo").Value, Image)
																							Dim bitmap As Bitmap = New Bitmap(image)
																							bitmap.Save(memoryStream, ImageFormat.Jpeg)
																							Dim buffer As Byte() = memoryStream.GetBuffer()
																							Dim sqlParameter As SqlParameter = New SqlParameter("@d2", SqlDbType.Image)
																							sqlParameter.Value = buffer
																							Me.cmd.Parameters.Add(sqlParameter)
																							Me.cmd.ExecuteNonQuery()
																							Me.cmd.Parameters.Clear()
																						End If
																					Next
																				Finally
																					Dim enumerator2 As IEnumerator
																					If TypeOf enumerator2 Is IDisposable Then
																						TryCast(enumerator2, IDisposable).Dispose()
																					End If
																				End Try
																				Me.con.Close()
																				Me.con.Open()
																				Dim text7 As String = "insert into Product_OpeningStock(ProductID,Qty,MRP,SalePrice,WSalePrice,Batch,Mfgdate,Expdate,Size,Colour,Barcode,PAddDate,RCipher,WCipher,PPrice,OPSValue,IMEI1,IMEI2) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)"
																				Me.cmd = New SqlCommand(text7)
																				Me.cmd.Connection = Me.con
																				Me.cmd.Prepare()
																				Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
																				Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtOpeningStock").Value)))
																				Me.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtDefMRP").Value)))
																				Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtRSP").Value)))
																				Me.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtWSP").Value)))
																				Dim flag31 As Boolean = dataGridViewRow.Cells("txtBatch").Value IsNot Nothing
																				If flag31 Then
																					Me.cmd.Parameters.AddWithValue("@d5", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtBatch").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d5", "")
																				End If
																				Dim flag32 As Boolean = dataGridViewRow.Cells("MfgDate").Value IsNot Nothing
																				If flag32 Then
																					Me.cmd.Parameters.AddWithValue("@d6", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("MfgDate").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d6", "")
																				End If
																				Dim flag33 As Boolean = dataGridViewRow.Cells("ExpDate").Value IsNot Nothing
																				If flag33 Then
																					Me.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("ExpDate").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d7", "")
																				End If
																				Dim flag34 As Boolean = dataGridViewRow.Cells("cmbSize").Value IsNot Nothing
																				If flag34 Then
																					Me.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbSize").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d8", "")
																				End If
																				Dim flag35 As Boolean = dataGridViewRow.Cells("cmbColour").Value IsNot Nothing
																				If flag35 Then
																					Me.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbColour").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d9", "")
																				End If
																				Me.cmd.Parameters.AddWithValue("@d10", Me.txtBarcodeTempStock.Text)
																				Me.cmd.Parameters.AddWithValue("@d11", DateTime.Today)
																				Me.cmd.Parameters.AddWithValue("@d12", "")
																				Me.cmd.Parameters.AddWithValue("@d13", "")
																				Dim flag36 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells("cmbPurchaseTaxType").Value, "Inclusive", False)
																				Dim num As Double
																				If flag36 Then
																					num = Conversions.ToDouble(String.Format(Conversions.ToString(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtCostPrice").Value)), 2)), "0.00"))
																				Else
																					num = Conversions.ToDouble(String.Format(Conversions.ToString(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtCostPrice").Value)), 2)), "0.00"))
																				End If
																				Me.cmd.Parameters.AddWithValue("@d14", num)
																				Me.cmd.Parameters.AddWithValue("@d15", String.Format(Conversions.ToString(Math.Round(num * Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtOpeningStock").Value)), 2)), "0.00"))
																				Dim flag37 As Boolean = dataGridViewRow.Cells("txtIMEI1").Value IsNot Nothing
																				If flag37 Then
																					Me.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtIMEI1").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d16", "")
																				End If
																				Dim flag38 As Boolean = dataGridViewRow.Cells("txtIMEI2").Value IsNot Nothing
																				If flag38 Then
																					Me.cmd.Parameters.AddWithValue("@d17", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtIMEI2").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d17", "")
																				End If
																				Me.cmd.ExecuteNonQuery()
																				Me.cmd.Parameters.Clear()
																				Me.con.Close()
																				Me.con = New SqlConnection(ModCS.cs)
																				Me.con.Open()
																				Dim text8 As String = "insert into Temp_Stock(ProductID, Qty, Barcode, SPrice, WPrice, StLimit, MRP, " & vbCrLf & "Batch, MfgDate, ExpDate, Size, Colour, SalePrice, WSalePrice, SuplName, IMEI1, IMEI2, PPrice, EPPrice, QrBarcode, SalesManPur,Variant_id) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21)"
																				Me.cmd = New SqlCommand(text8)
																				Me.cmd.Connection = Me.con
																				Me.cmd.Prepare()
																				Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
																				Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtOpeningStock").Value)))
																				Me.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtBarcode_TempStock").Value)))
																				Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtRSP").Value)))
																				Me.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtWSP").Value)))
																				Me.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtMinStock").Value)))
																				Me.cmd.Parameters.AddWithValue("@d6", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtDefMRP").Value)))
																				Dim flag39 As Boolean = dataGridViewRow.Cells("txtBatch").Value IsNot Nothing
																				If flag39 Then
																					Me.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtBatch").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d7", "")
																				End If
																				Dim flag40 As Boolean = dataGridViewRow.Cells("MfgDate").Value IsNot Nothing
																				If flag40 Then
																					Me.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("MfgDate").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d8", "")
																				End If
																				Dim flag41 As Boolean = dataGridViewRow.Cells("ExpDate").Value IsNot Nothing
																				If flag41 Then
																					Me.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("ExpDate").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d9", "")
																				End If
																				Me.cmd.Parameters.AddWithValue("@d10", "")
																				Me.cmd.Parameters.AddWithValue("@d11", "")
																				Me.cmd.Parameters.AddWithValue("@d12", "")
																				Me.cmd.Parameters.AddWithValue("@d13", "")
																				Me.cmd.Parameters.AddWithValue("@d14", "Opening Stock")
																				Dim flag42 As Boolean = dataGridViewRow.Cells("txtIMEI1").Value IsNot Nothing
																				If flag42 Then
																					Me.cmd.Parameters.AddWithValue("@d15", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtIMEI1").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d15", "")
																				End If
																				Dim flag43 As Boolean = dataGridViewRow.Cells("txtIMEI2").Value IsNot Nothing
																				If flag43 Then
																					Me.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtIMEI2").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d16", "")
																				End If
																				Me.cmd.Parameters.AddWithValue("@d17", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtCostPrice").Value)))
																				Me.cmd.Parameters.AddWithValue("@d18", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtCostPrice").Value)))
																				Dim memoryStream2 As MemoryStream = New MemoryStream()
																				Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
																				bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
																				Dim buffer2 As Byte() = memoryStream2.GetBuffer()
																				Dim sqlParameter2 As SqlParameter = New SqlParameter("@d19", SqlDbType.Image)
																				sqlParameter2.Value = buffer2
																				Me.cmd.Parameters.AddWithValue("@d20", 0.0)
																				Me.cmd.Parameters.AddWithValue("@d21", Conversion.Val(Me.txtID.Text))
																				Me.cmd.Parameters.Add(sqlParameter2)
																				Me.cmd.ExecuteNonQuery()
																				Me.cmd.Parameters.Clear()
																				Me.con.Close()
																				Me.con = New SqlConnection(ModCS.cs)
																				Me.con.Open()
																				Dim text9 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
																				Me.cmd = New SqlCommand(text9)
																				Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
																				Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbSalesUnit").Value))
																				Me.cmd.Connection = Me.con
																				Me.cmd.ExecuteReader()
																				Me.con.Close()
																				Me.con = New SqlConnection(ModCS.cs)
																				Me.con.Open()
																				Dim text10 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
																				Me.cmd = New SqlCommand(text10)
																				Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
																				Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbAltunit").Value))
																				Me.cmd.Connection = Me.con
																				Me.cmd.ExecuteReader()
																				Me.con.Close()
																				MessageBox.Show("Successfully Saved", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
																				Me.fillProductID()
																				Me.con.Close()
																				Me.auto()
																				Me.GenerateBarcode()
																				Me.strPcode = ""
																			Catch ex As Exception
																				MessageBox.Show(String.Format("Error inserting row: {0}", ex.Message))
																			Finally
																				Me.con.Close()
																			End Try
																			Me.DataforNP()
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
		End Sub

		' Token: 0x060081D5 RID: 33237 RVA: 0x00601F20 File Offset: 0x00600120
		Public Sub fillProductID()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.adp = New SqlDataAdapter()
				Me.adp.SelectCommand = New SqlCommand("SELECT RTRIM(PID) FROM Product order by PID ASC", Me.con)
				Me.ds = New DataSet("ds")
				Me.adp.Fill(Me.ds)
				Me.dtable = Me.ds.Tables(0)
				Me.cmbNP.Items.Clear()
				Try
					For Each obj As Object In Me.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbNP.Items.Add(dataRow(0).ToString())
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

		' Token: 0x060081D6 RID: 33238 RVA: 0x0060205C File Offset: 0x0060025C
		Private Sub DataGridView1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs)
			Dim flag As Boolean = e.RowIndex = Me.DataGridView1.NewRowIndex
			If flag Then
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value)
				Dim dataGridViewCell As DataGridViewCell = Me.DataGridView1.Rows(e.RowIndex).Cells(0)
				Dim dataGridViewCell2 As DataGridViewCell = Me.DataGridView1.Rows(e.RowIndex).Cells(1)
				Dim dataGridViewCell3 As DataGridViewCell = Me.DataGridView1.Rows(e.RowIndex).Cells("txtBarcode_TempStock")
				dataGridViewCell3.Value = Me.txtBarcodeTempStock.Text
				dataGridViewCell.Value = Conversion.Val(Me.txtID.Text)
				Dim flag2 As Boolean = Operators.CompareString(Me.strPcode, Me.txtProductCode.Text, False) <> 0
				If flag2 Then
					Me.strPcode = Me.txtProductCode.Text
					dataGridViewCell2.Value = Me.strPcode
				End If
			End If
		End Sub

		' Token: 0x060081D7 RID: 33239 RVA: 0x0060218C File Offset: 0x0060038C
		Public Sub auto()
			Try
				Me.txtID.Text = Me.GenerateID()
				Me.txtProductCode.Text = "P-" + Me.GenerateID()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060081D8 RID: 33240 RVA: 0x00602200 File Offset: 0x00600400
		Private Function GenerateID() As String
			Me.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				Me.con.Open()
				Me.cmd = New SqlCommand("SELECT TOP 1 PID FROM Product ORDER BY PID DESC", Me.con)
				Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = Me.rdr.HasRows
				If hasRows Then
					Me.rdr.Read()
					text = Conversions.ToString(Me.rdr("PID"))
				End If
				Me.rdr.Close()
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
				Dim flag4 As Boolean = Me.con.State = ConnectionState.Open
				If flag4 Then
					Me.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x060081D9 RID: 33241 RVA: 0x00012199 File Offset: 0x00010399
		Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
			e.ThrowException = False
		End Sub

		' Token: 0x060081DA RID: 33242 RVA: 0x00602384 File Offset: 0x00600584
		Public Sub fillGdown()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.adp = New SqlDataAdapter()
				Me.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(GDown) FROM Product", Me.con)
				Me.ds = New DataSet("ds")
				Me.adp.Fill(Me.ds)
				Me.dtable = Me.ds.Tables(0)
				Me.ddlGdown.Items.Clear()
				Dim flag As Boolean = Me.dtable.Rows.Count > 1
				If flag Then
					Try
						For Each obj As Object In Me.dtable.Rows
							Dim dataRow As DataRow = CType(obj, DataRow)
							Me.ddlGdown.Items.Add(dataRow(0).ToString())
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				Else
					Me.FillGdown_Custom()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060081DB RID: 33243 RVA: 0x00602500 File Offset: 0x00600700
		Public Sub FillGdown_Custom()
			Dim list As List(Of String) = New List(Of String)() From { "1", "2", "3", "4", "5" }
			Me.ddlGdown.Items.AddRange(list.ToArray())
		End Sub

		' Token: 0x060081DC RID: 33244 RVA: 0x00602568 File Offset: 0x00600768
		Public Sub fillRack()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.adp = New SqlDataAdapter()
				Me.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Rack) FROM Product", Me.con)
				Me.ds = New DataSet("ds")
				Me.adp.Fill(Me.ds)
				Me.dtable = Me.ds.Tables(0)
				Me.ddlRack.Items.Clear()
				Dim flag As Boolean = Me.dtable.Rows.Count > 1
				If flag Then
					Try
						For Each obj As Object In Me.dtable.Rows
							Dim dataRow As DataRow = CType(obj, DataRow)
							Me.ddlRack.Items.Add(dataRow(0).ToString())
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				Else
					Me.fillRack_Custom()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060081DD RID: 33245 RVA: 0x006026E4 File Offset: 0x006008E4
		Public Sub fillRack_Custom()
			Dim list As List(Of String) = New List(Of String)() From { "1", "2", "3", "4", "5" }
			Me.ddlRack.Items.AddRange(list.ToArray())
		End Sub

		' Token: 0x060081DE RID: 33246 RVA: 0x000F58F4 File Offset: 0x000F3AF4
		Private Sub ComboBox_Enter(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			comboBox.DroppedDown = True
		End Sub

		' Token: 0x060081DF RID: 33247 RVA: 0x0060274C File Offset: 0x0060094C
		Private Sub ComboBox_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = e.KeyChar = vbCr
			If flag Then
				Dim comboBox As ComboBox = CType(sender, ComboBox)
				Dim text As String = comboBox.Text
				Dim dataGridViewComboBoxCell As DataGridViewComboBoxCell = CType(Me.DataGridView1.CurrentCell, DataGridViewComboBoxCell)
				MessageBox.Show(String.Format("Enter key pressed for '{0}' in cell ({1}, {2})", text, dataGridViewComboBoxCell.RowIndex, dataGridViewComboBoxCell.ColumnIndex))
				e.Handled = True
			End If
		End Sub

		' Token: 0x060081E0 RID: 33248 RVA: 0x006027B8 File Offset: 0x006009B8
		Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
			Try
				Dim flag As Boolean = TypeOf Me.DataGridView1.CurrentCell Is DataGridViewComboBoxCell
				If flag Then
					Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(e.Control, DataGridViewComboBoxEditingControl)
					Dim flag2 As Boolean = dataGridViewComboBoxEditingControl IsNot Nothing
					If flag2 Then
						AddHandler dataGridViewComboBoxEditingControl.Enter, AddressOf Me.ComboBox_Enter
					End If
				Else
					Dim flag3 As Boolean = TypeOf Me.DataGridView1.CurrentCell Is DataGridViewTextBoxCell
					If flag3 Then
						Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = CType(e.Control, DataGridViewTextBoxEditingControl)
						RemoveHandler dataGridViewTextBoxEditingControl.PreviewKeyDown, AddressOf Me.PreTranslateDGV_PreviewKeyDown
						AddHandler dataGridViewTextBoxEditingControl.PreviewKeyDown, AddressOf Me.PreTranslateDGV_PreviewKeyDown
					End If
				End If
			Catch ex As Exception
			End Try
			Dim flag4 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = 3 AndAlso TypeOf e.Control Is ComboBox
			If flag4 Then
				Dim comboBox As ComboBox = CType(e.Control, ComboBox)
				RemoveHandler comboBox.SelectedIndexChanged, AddressOf Me.ComboBox_SelectedIndexChanged
				AddHandler comboBox.SelectedIndexChanged, AddressOf Me.ComboBox_SelectedIndexChanged
				RemoveHandler comboBox.DropDownClosed, AddressOf Me.ComboBox_DropDownClosed
				AddHandler comboBox.DropDownClosed, AddressOf Me.ComboBox_DropDownClosed
			Else
				Dim flag5 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = 5 AndAlso TypeOf e.Control Is ComboBox
				If flag5 Then
					Dim comboBox2 As ComboBox = CType(e.Control, ComboBox)
					RemoveHandler comboBox2.SelectedIndexChanged, AddressOf Me.cmbSubCategory_SelectedIndexChanged
					AddHandler comboBox2.SelectedIndexChanged, AddressOf Me.cmbSubCategory_SelectedIndexChanged
					RemoveHandler comboBox2.DropDownClosed, AddressOf Me.ComboBox_DropDownClosed
					AddHandler comboBox2.DropDownClosed, AddressOf Me.ComboBox_DropDownClosed
				Else
					Dim flag6 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = 23 AndAlso TypeOf e.Control Is ComboBox
					If flag6 Then
						Dim comboBox3 As ComboBox = CType(e.Control, ComboBox)
						RemoveHandler comboBox3.SelectedIndexChanged, AddressOf Me.cmbPurchaseUnit_SelectedIndexChanged
						AddHandler comboBox3.SelectedIndexChanged, AddressOf Me.cmbPurchaseUnit_SelectedIndexChanged
						RemoveHandler comboBox3.DropDownClosed, AddressOf Me.cmbPurchaseUnit_DropDownClosed
						AddHandler comboBox3.DropDownClosed, AddressOf Me.cmbPurchaseUnit_DropDownClosed
					Else
						Dim flag7 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = 24 AndAlso TypeOf e.Control Is ComboBox
						If flag7 Then
							Dim comboBox4 As ComboBox = CType(e.Control, ComboBox)
							AddHandler comboBox4.SelectedIndexChanged, AddressOf Me.cmbSalesUnit_SelectedIndexChanged
						Else
							Dim flag8 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = Me.DataGridView1.Columns("cmbGST").Index AndAlso TypeOf e.Control Is ComboBox
							If flag8 Then
								Dim comboBox5 As ComboBox = CType(e.Control, ComboBox)
								RemoveHandler comboBox5.SelectedIndexChanged, AddressOf Me.cmbGST_SelectedIndexChanged
								AddHandler comboBox5.SelectedIndexChanged, AddressOf Me.cmbGST_SelectedIndexChanged
								RemoveHandler comboBox5.DropDownClosed, AddressOf Me.cmbGST_DropDownClosed
								AddHandler comboBox5.DropDownClosed, AddressOf Me.cmbGST_DropDownClosed
							Else
								Dim flag9 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = Me.DataGridView1.Columns("txtCGST").Index AndAlso TypeOf e.Control Is TextBox
								If flag9 Then
									Dim textBox As TextBox = CType(e.Control, TextBox)
									AddHandler textBox.TextChanged, AddressOf Me.txtCGST_TextChanged
								Else
									Dim flag10 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = Me.DataGridView1.Columns("txtSGST").Index AndAlso TypeOf e.Control Is TextBox
									If flag10 Then
										Dim textBox2 As TextBox = CType(e.Control, TextBox)
										AddHandler textBox2.TextChanged, AddressOf Me.txtSGST_TextChanged
									Else
										Dim flag11 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = Me.DataGridView1.Columns("txtIGST").Index AndAlso TypeOf e.Control Is TextBox
										If flag11 Then
											Dim textBox3 As TextBox = CType(e.Control, TextBox)
											AddHandler textBox3.TextChanged, AddressOf Me.txtIGST_TextChanged
										Else
											Dim flag12 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = 21 AndAlso TypeOf e.Control Is Button
											If Not flag12 Then
												Dim flag13 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = 32
												If flag13 Then
													Dim comboBox6 As ComboBox = CType(e.Control, ComboBox)
													RemoveHandler comboBox6.DropDownClosed, AddressOf Me.cmbGdown_DropDownClosed
													AddHandler comboBox6.DropDownClosed, AddressOf Me.cmbGdown_DropDownClosed
												Else
													Dim flag14 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = 33
													If flag14 Then
														Dim comboBox7 As ComboBox = CType(e.Control, ComboBox)
														RemoveHandler comboBox7.DropDownClosed, AddressOf Me.cmbRack_DropDownClosed
														AddHandler comboBox7.DropDownClosed, AddressOf Me.cmbRack_DropDownClosed
													Else
														Dim flag15 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex = 46 AndAlso TypeOf e.Control Is TextBox
														If flag15 Then
															Dim textBox4 As TextBox = CType(e.Control, TextBox)
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
		End Sub

		' Token: 0x060081E1 RID: 33249 RVA: 0x00602D6C File Offset: 0x00600F6C
		Private Sub cmbGdown_LostFocus(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim list As List(Of ComboBoxItem) = New List(Of ComboBoxItem)()
			list.Add(New ComboBoxItem("Item 1", 1))
			list.Add(New ComboBoxItem("Item 2", 2))
			list.Add(New ComboBoxItem("Item 3", 3))
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
			dataGridViewComboBoxEditingControl.Items.Add(list)
		End Sub

		' Token: 0x060081E2 RID: 33250 RVA: 0x00602DD4 File Offset: 0x00600FD4
		Private Sub cmbSubCategory_DropDownClosed(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewComboBoxEditingControl.EditingControlDataGridView
			Dim rowIndex As Integer = editingControlDataGridView.CurrentCell.RowIndex
			Dim flag As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 5
			Dim num As Integer
			If flag Then
				' The following expression was wrapped in a checked-expression
				num = editingControlDataGridView.CurrentCell.ColumnIndex + 4
			Else
				num = editingControlDataGridView.CurrentCell.ColumnIndex
			End If
			editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(rowIndex).Cells(num)
			editingControlDataGridView.BeginEdit(True)
		End Sub

		' Token: 0x060081E3 RID: 33251 RVA: 0x00602E60 File Offset: 0x00601060
		Private Sub cmbPurchaseUnit_DropDownClosed(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewComboBoxEditingControl.EditingControlDataGridView
			Dim rowIndex As Integer = editingControlDataGridView.CurrentCell.RowIndex
			Dim flag As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 23
			Dim num As Integer
			If flag Then
				' The following expression was wrapped in a checked-expression
				num = editingControlDataGridView.CurrentCell.ColumnIndex + 12
			Else
				num = editingControlDataGridView.CurrentCell.ColumnIndex
			End If
			editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(rowIndex).Cells(num)
			editingControlDataGridView.BeginEdit(True)
		End Sub

		' Token: 0x060081E4 RID: 33252 RVA: 0x00602EF0 File Offset: 0x006010F0
		Private Sub cmbGdown_DropDownClosed(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewComboBoxEditingControl.EditingControlDataGridView
			Dim rowIndex As Integer = editingControlDataGridView.CurrentCell.RowIndex
			Dim flag As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 32
			Dim num As Integer
			If flag Then
				' The following expression was wrapped in a checked-expression
				num = editingControlDataGridView.CurrentCell.ColumnIndex + 1
			Else
				num = editingControlDataGridView.CurrentCell.ColumnIndex
			End If
			editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(rowIndex).Cells(num)
			editingControlDataGridView.EndEdit(CType((-1), DataGridViewDataErrorContexts))
		End Sub

		' Token: 0x060081E5 RID: 33253 RVA: 0x00602F7C File Offset: 0x0060117C
		Private Sub cmbRack_DropDownClosed(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewComboBoxEditingControl.EditingControlDataGridView
			Dim rowIndex As Integer = editingControlDataGridView.CurrentCell.RowIndex
			Dim flag As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 33
			Dim num As Integer
			If flag Then
				' The following expression was wrapped in a checked-expression
				num = editingControlDataGridView.CurrentCell.ColumnIndex + 1
			Else
				num = editingControlDataGridView.CurrentCell.ColumnIndex
			End If
			editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(rowIndex).Cells(num)
			editingControlDataGridView.EndEdit(CType((-1), DataGridViewDataErrorContexts))
		End Sub

		' Token: 0x060081E6 RID: 33254 RVA: 0x00603008 File Offset: 0x00601208
		Private Sub cmbSize_DropDownClosed(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewComboBoxEditingControl.EditingControlDataGridView
			Dim rowIndex As Integer = editingControlDataGridView.CurrentCell.RowIndex
			Dim num As Integer = editingControlDataGridView.CurrentCell.ColumnIndex
			Dim flag As Boolean = num = 43
			If flag Then
				num += 1
			End If
			While num < editingControlDataGridView.ColumnCount AndAlso (Not editingControlDataGridView.Columns(num).Visible OrElse Not editingControlDataGridView.Rows(rowIndex).Cells(num).Visible)
				num += 1
			End While
			Dim flag2 As Boolean = num < editingControlDataGridView.ColumnCount
			If flag2 Then
				editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(rowIndex).Cells(num)
				editingControlDataGridView.BeginEdit(True)
			End If
		End Sub

		' Token: 0x060081E7 RID: 33255 RVA: 0x006030E4 File Offset: 0x006012E4
		Private Sub cmbColour_DropDownClosed(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewComboBoxEditingControl.EditingControlDataGridView
			Dim rowIndex As Integer = editingControlDataGridView.CurrentCell.RowIndex
			Dim flag As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 44
			Dim num As Integer
			If flag Then
				' The following expression was wrapped in a checked-expression
				num = editingControlDataGridView.CurrentCell.ColumnIndex + 1
			Else
				num = editingControlDataGridView.CurrentCell.ColumnIndex
			End If
			editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(rowIndex).Cells(num)
			editingControlDataGridView.EndEdit(CType((-1), DataGridViewDataErrorContexts))
		End Sub

		' Token: 0x060081E8 RID: 33256 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub SetComboBoxColumnSelectedIndex(rowIndex As Integer, name As String, selectedIndex As Integer)
		End Sub

		' Token: 0x060081E9 RID: 33257 RVA: 0x00603170 File Offset: 0x00601370
		Private Sub cmbGST_DropDownClosed(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewComboBoxEditingControl.EditingControlDataGridView
			Dim rowIndex As Integer = editingControlDataGridView.CurrentCell.RowIndex
			Dim flag As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 14
			Dim num As Integer
			If flag Then
				' The following expression was wrapped in a checked-expression
				num = editingControlDataGridView.CurrentCell.ColumnIndex + 5
			Else
				num = editingControlDataGridView.CurrentCell.ColumnIndex
			End If
			editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(rowIndex).Cells(num)
			editingControlDataGridView.BeginEdit(True)
		End Sub

		' Token: 0x060081EA RID: 33258 RVA: 0x006031FC File Offset: 0x006013FC
		Private Sub PreTranslateDGV_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
			Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = CType(sender, DataGridViewTextBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewTextBoxEditingControl.EditingControlDataGridView
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = editingControlDataGridView.ColumnCount - 1
				Dim num As Integer
				Dim num2 As Integer
				If flag2 Then
					num = editingControlDataGridView.CurrentCell.RowIndex + 1
					num2 = 0
					Dim flag3 As Boolean = num = editingControlDataGridView.RowCount
					If flag3 Then
						editingControlDataGridView.Rows.Add(1)
					End If
				Else
					num = editingControlDataGridView.CurrentCell.RowIndex
					num2 = editingControlDataGridView.CurrentCell.ColumnIndex + 1
					While num2 < editingControlDataGridView.ColumnCount AndAlso Not editingControlDataGridView.Columns(num2).Visible
						num2 += 1
					End While
				End If
				Dim flag4 As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 19
				If flag4 Then
					num = editingControlDataGridView.CurrentCell.RowIndex
					num2 = editingControlDataGridView.CurrentCell.ColumnIndex + 4
				End If
				Dim flag5 As Boolean = TypeOf Me.DataGridView1.CurrentCell Is DataGridViewButtonCell
				If flag5 Then
					Dim name As String = Me.DataGridView1.CurrentCell.OwningColumn.Name
					If Operators.CompareString(name, "InsertButtonColumn", False) = 0 Then
						Me.DBoperation(num, "Insert")
					End If
				Else
					Me.DataGridView1.BeginEdit(True)
				End If
				While num2 < editingControlDataGridView.ColumnCount AndAlso Not editingControlDataGridView.Columns(num2).Visible
					num2 += 1
				End While
				Dim flag6 As Boolean = num2 < editingControlDataGridView.ColumnCount
				If flag6 Then
					editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(num).Cells(num2)
					Dim flag7 As Boolean = New Integer() { 3, 5, 8, 14, 23, 32, 33 }.Contains(num2)
					If flag7 Then
						editingControlDataGridView.BeginEdit(True)
					End If
				End If
			End If
		End Sub

		' Token: 0x060081EB RID: 33259 RVA: 0x006033E8 File Offset: 0x006015E8
		Private Sub txtSGST_TextChanged(sender As Object, byvale As EventArgs)
			Dim currentCellAddress As Point = Me.DataGridView1.CurrentCellAddress
			Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = TryCast(sender, DataGridViewTextBoxEditingControl)
			Dim dataGridViewTextBoxCell As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells("txtCGST"), DataGridViewTextBoxCell)
			Dim dataGridViewTextBoxCell2 As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells("txtIGST"), DataGridViewTextBoxCell)
			dataGridViewTextBoxEditingControl.EditingControlFormattedValue = Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewTextBoxCell.Value)), 2), "0.00")
			dataGridViewTextBoxCell2.Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewTextBoxCell.Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewTextBoxEditingControl.EditingControlFormattedValue))
		End Sub

		' Token: 0x060081EC RID: 33260 RVA: 0x006034BC File Offset: 0x006016BC
		Private Sub txtIGST_TextChanged(sender As Object, e As EventArgs)
			Dim currentCellAddress As Point = Me.DataGridView1.CurrentCellAddress
			Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = TryCast(sender, DataGridViewTextBoxEditingControl)
			Dim dataGridViewTextBoxCell As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells("txtCGST"), DataGridViewTextBoxCell)
			Dim dataGridViewTextBoxCell2 As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells("txtSGST"), DataGridViewTextBoxCell)
			dataGridViewTextBoxEditingControl.EditingControlFormattedValue = Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewTextBoxCell.Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewTextBoxCell2.Value)), 2), "0.00")
		End Sub

		' Token: 0x060081ED RID: 33261 RVA: 0x00603574 File Offset: 0x00601774
		Private Sub txtCGST_TextChanged(sender As Object, e As EventArgs)
			Dim currentCellAddress As Point = Me.DataGridView1.CurrentCellAddress
			Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = TryCast(sender, DataGridViewTextBoxEditingControl)
			Dim dataGridViewTextBoxCell As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells("txtSGST"), DataGridViewTextBoxCell)
			Dim dataGridViewTextBoxCell2 As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells("txtIGST"), DataGridViewTextBoxCell)
			dataGridViewTextBoxCell.Value = RuntimeHelpers.GetObjectValue(dataGridViewTextBoxEditingControl.EditingControlFormattedValue)
			dataGridViewTextBoxCell2.Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewTextBoxEditingControl.EditingControlFormattedValue)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewTextBoxCell.Value))
		End Sub

		' Token: 0x060081EE RID: 33262 RVA: 0x0060362C File Offset: 0x0060182C
		Private Sub cmbPurchaseUnit_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim currentCellAddress As Point = Me.DataGridView1.CurrentCellAddress
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = TryCast(sender, DataGridViewComboBoxEditingControl)
			Dim dataGridViewComboBoxCell As DataGridViewComboBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells(24), DataGridViewComboBoxCell)
			dataGridViewComboBoxCell.Value = dataGridViewComboBoxEditingControl.EditingControlFormattedValue.ToString()
			Dim dataGridViewComboBoxCell2 As DataGridViewComboBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells(25), DataGridViewComboBoxCell)
			dataGridViewComboBoxCell2.Value = dataGridViewComboBoxEditingControl.EditingControlFormattedValue.ToString()
		End Sub

		' Token: 0x060081EF RID: 33263 RVA: 0x006036C4 File Offset: 0x006018C4
		Private Sub cmbSalesUnit_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim currentCellAddress As Point = Me.DataGridView1.CurrentCellAddress
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = TryCast(sender, DataGridViewComboBoxEditingControl)
			Dim dataGridViewComboBoxCell As DataGridViewComboBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells("cmbPurchaseUnit"), DataGridViewComboBoxCell)
			dataGridViewComboBoxEditingControl.EditingControlFormattedValue = RuntimeHelpers.GetObjectValue(dataGridViewComboBoxCell.Value)
			Dim dataGridViewComboBoxCell2 As DataGridViewComboBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells(25), DataGridViewComboBoxCell)
			dataGridViewComboBoxCell2.Value = RuntimeHelpers.GetObjectValue(dataGridViewComboBoxEditingControl.EditingControlFormattedValue)
		End Sub

		' Token: 0x060081F0 RID: 33264 RVA: 0x00603760 File Offset: 0x00601960
		Private Sub cmbGST_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim currentCellAddress As Point = Me.DataGridView1.CurrentCellAddress
			Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = TryCast(sender, DataGridViewComboBoxEditingControl)
			Dim dataGridViewTextBoxCell As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells("txtCGST"), DataGridViewTextBoxCell)
			dataGridViewTextBoxCell.Value = Strings.Format(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewComboBoxEditingControl.EditingControlFormattedValue)) / 2.0, 2), "0.00")
			Dim dataGridViewTextBoxCell2 As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells("txtSGST"), DataGridViewTextBoxCell)
			Dim dataGridViewTextBoxCell3 As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells("txtIGST"), DataGridViewTextBoxCell)
			dataGridViewTextBoxCell2.Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewTextBoxCell.Value))
			dataGridViewTextBoxCell3.Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewTextBoxCell.Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewTextBoxCell2.Value))
		End Sub

		' Token: 0x060081F1 RID: 33265 RVA: 0x0003FB88 File Offset: 0x0003DD88
		Private Sub btnAdd_Click(sender As Object, e As EventArgs)
			MessageBox.Show("clicked")
			Throw New NotImplementedException()
		End Sub

		' Token: 0x060081F2 RID: 33266 RVA: 0x000098CC File Offset: 0x00007ACC
		Private Sub LastColumnComboSelectionChanged(sender As Object, e As EventArgs)
			Throw New NotImplementedException()
		End Sub

		' Token: 0x060081F3 RID: 33267 RVA: 0x00603888 File Offset: 0x00601A88
		Private Function ShouldRemoveItem(item As Object) As Boolean
			Return item.ToString().Equals("X")
		End Function

		' Token: 0x060081F4 RID: 33268 RVA: 0x006038AC File Offset: 0x00601AAC
		Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Dim currentCellAddress As Point = Me.DataGridView1.CurrentCellAddress
				Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = TryCast(sender, DataGridViewComboBoxEditingControl)
				Dim dataGridViewTextBoxCell As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells(0), DataGridViewTextBoxCell)
				dataGridViewTextBoxCell.Value = dataGridViewComboBoxEditingControl.EditingControlFormattedValue.ToString()
				Dim dataGridViewComboBoxCell As DataGridViewComboBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells(5), DataGridViewComboBoxCell)
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim text As String = "SELECT distinct RTRIM(SubCategoryName) FROM SubCategory,Category where SubCategory.Category=Category.CategoryName and CategoryName=@d1"
				Me.cmd = New SqlCommand(text)
				Me.cmd.Connection = Me.con
				Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewTextBoxCell.Value))
				Me.rdr = Me.cmd.ExecuteReader()
				While Me.rdr.Read()
					Dim list As List(Of Object) = New List(Of Object)()
					Try
						For Each obj As Object In dataGridViewComboBoxCell.Items
							Dim objectValue As Object = RuntimeHelpers.GetObjectValue(obj)
							Dim flag As Boolean = Not objectValue.Equals(RuntimeHelpers.GetObjectValue(Me.rdr(0)))
							If flag Then
								list.Add(RuntimeHelpers.GetObjectValue(objectValue))
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj2 As Object In list
							Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(obj2)
							dataGridViewComboBoxCell.Items.Remove(RuntimeHelpers.GetObjectValue(objectValue2))
						Next
					Finally
						Dim enumerator2 As List(Of Object).Enumerator
						CType(enumerator2, IDisposable).Dispose()
					End Try
				End While
				Me.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060081F5 RID: 33269 RVA: 0x00603AF4 File Offset: 0x00601CF4
		Private Sub ComboBox_DropDownClosed(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			Dim columnIndex As Integer = Me.DataGridView1.CurrentCell.ColumnIndex
			Dim rowIndex As Integer = Me.DataGridView1.CurrentCell.RowIndex
			Me.DataGridView1.CurrentCell = Me.DataGridView1(columnIndex, rowIndex)
			Me.DataGridView1.EndEdit()
			AddHandler Me.DataGridView1.CellClick, AddressOf Me.DataGridView1_CellClick
		End Sub

		' Token: 0x060081F6 RID: 33270 RVA: 0x00603B68 File Offset: 0x00601D68
		Private Sub DataGridView12_CellClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = TypeOf Me.DataGridView1.Columns(e.ColumnIndex)Is DataGridViewComboBoxColumn AndAlso e.RowIndex >= 0
			If flag Then
				' The following expression was wrapped in a checked-expression
				Me.DataGridView1.CurrentCell = Me.DataGridView1(e.ColumnIndex + 1, e.RowIndex)
				Me.DataGridView1.BeginEdit(True)
			End If
		End Sub

		' Token: 0x060081F7 RID: 33271 RVA: 0x00603BDC File Offset: 0x00601DDC
		Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = TypeOf Me.DataGridView1.Columns(e.ColumnIndex)Is DataGridViewComboBoxColumn AndAlso e.RowIndex >= 0
			If flag Then
				Me.DataGridView1.CurrentCell = Me.DataGridView1(e.ColumnIndex, e.RowIndex)
				Me.DataGridView1.BeginEdit(True)
			End If
		End Sub

		' Token: 0x060081F8 RID: 33272 RVA: 0x00603C4C File Offset: 0x00601E4C
		Private Sub ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = TryCast(sender, ComboBox)
			Dim flag As Boolean = comboBox IsNot Nothing AndAlso TypeOf Me.DataGridView1.CurrentCell Is DataGridViewComboBoxCell
			If flag Then
				Dim columnIndex As Integer = Me.DataGridView1.CurrentCell.ColumnIndex
				Dim rowIndex As Integer = Me.DataGridView1.CurrentCell.RowIndex
				Dim flag2 As Boolean = columnIndex = 3
				If flag2 Then
					Dim dataGridViewComboBoxCell As DataGridViewComboBoxCell = CType(Me.DataGridView1.Rows(rowIndex).Cells("cmbSubCategory"), DataGridViewComboBoxCell)
					dataGridViewComboBoxCell.Items.Clear()
					dataGridViewComboBoxCell.Items.Add("Select")
					Dim flag3 As Boolean = comboBox.SelectedItem IsNot Nothing
					If flag3 Then
						Dim flag4 As Boolean = Operators.CompareString(comboBox.SelectedItem.ToString(), "System.Data.DataRowView", False) <> 0
						If flag4 Then
							Dim text As String = comboBox.SelectedItem.ToString()
							Dim array As DataRow() = Me.subcategories.[Select]("CategoryName = '" + text + "'")
							For Each dataRow As DataRow In array
								dataGridViewComboBoxCell.Items.Add(RuntimeHelpers.GetObjectValue(dataRow("SubcategoryName")))
							Next
							comboBox.Focus()
						End If
					End If
				Else
					Dim flag5 As Boolean = columnIndex = 5
					If flag5 Then
					End If
				End If
			End If
		End Sub

		' Token: 0x060081F9 RID: 33273 RVA: 0x00603DB0 File Offset: 0x00601FB0
		Public Sub FillSubCat()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.adp = New SqlDataAdapter()
				Me.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(SubCategoryName) FROM SubCategory order by 1", Me.con)
				Me.ds = New DataSet("ds")
				Me.adp.Fill(Me.ds)
				Me.dtable = Me.ds.Tables(0)
				Me.cmbSubCategory.Items.Clear()
				Try
					For Each obj As Object In Me.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbSubCategory.Items.Add(dataRow(0).ToString())
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

		' Token: 0x060081FA RID: 33274 RVA: 0x00603EEC File Offset: 0x006020EC
		Public Sub FillSubCat(Val As String, CurrentCellNo As Integer)
			Dim text As String = "SELECT distinct RTRIM(SubCategoryName) FROM SubCategory,Category where SubCategory.Category=Category.CategoryName and CategoryName=@d1"
			Me.cmd = New SqlCommand(text)
			Dim flag As Boolean = Me.con.State = ConnectionState.Closed
			If flag Then
				Me.con.Open()
			End If
			Me.cmd.Connection = Me.con
			Me.cmd.Parameters.AddWithValue("@d1", Val)
			Me.rdr = Me.cmd.ExecuteReader()
			Dim dataGridViewComboBoxCell As DataGridViewComboBoxCell = CType(Me.DataGridView1.Rows(CurrentCellNo).Cells(5), DataGridViewComboBoxCell)
			While Me.rdr.Read()
				dataGridViewComboBoxCell.Items.Add(RuntimeHelpers.GetObjectValue(Me.rdr(0)))
			End While
			Me.con.Close()
		End Sub

		' Token: 0x060081FB RID: 33275 RVA: 0x00603FC4 File Offset: 0x006021C4
		Private Sub cmbSubCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Dim currentCellAddress As Point = Me.DataGridView1.CurrentCellAddress
				Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = TryCast(sender, DataGridViewComboBoxEditingControl)
				Dim dataGridViewTextBoxCell As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells(0), DataGridViewTextBoxCell)
				dataGridViewTextBoxCell.Value = dataGridViewComboBoxEditingControl.EditingControlFormattedValue.ToString()
				Dim dataGridViewTextBoxCell2 As DataGridViewTextBoxCell = CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells(7), DataGridViewTextBoxCell)
				Try
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Me.cmd = Me.con.CreateCommand()
					Me.cmd.CommandText = "SELECT ID from SubCategory where Category=@d1 and SubCategoryName=@d2"
					Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(CType(Me.DataGridView1.Rows(currentCellAddress.Y).Cells(3), DataGridViewComboBoxCell).Value))
					Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewTextBoxCell.Value))
					Me.rdr = Me.cmd.ExecuteReader()
					Dim flag As Boolean = Me.rdr.Read()
					If flag Then
						dataGridViewTextBoxCell2.Value = RuntimeHelpers.GetObjectValue(Me.rdr.GetValue(0))
					End If
					Dim flag2 As Boolean = Me.rdr IsNot Nothing
					If flag2 Then
						Me.rdr.Close()
					End If
					Dim flag3 As Boolean = Me.con.State = ConnectionState.Open
					If flag3 Then
						Me.con.Close()
					End If
				Catch ex As Exception
				End Try
			Catch ex2 As Exception
			End Try
		End Sub

		' Token: 0x060081FC RID: 33276 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub cmbCategory_KeyDown(sender As Object, e As KeyEventArgs)
		End Sub

		' Token: 0x060081FD RID: 33277 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbSubCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060081FE RID: 33278 RVA: 0x006041C4 File Offset: 0x006023C4
		Private Sub GelButtonNewRecord_Click(sender As Object, e As EventArgs)
			Me.DataGridView1.[ReadOnly] = False
			Dim num As Integer = Me.DataGridView1.Rows.Count - 1
			Dim num2 As Integer = 2
			Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(num).Cells(num2)
			Try
				For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim isNewRow As Boolean = dataGridViewRow.IsNewRow
					If isNewRow Then
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(2).Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(2).Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(3).Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(3).Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(5).Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(5).Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtCostPrice").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtCostPrice").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtDiscount").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtDiscount").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtMinStock").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtMinStock").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbPurchaseUnit").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbPurchaseUnit").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbSalesUnit").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbSalesUnit").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbAltunit").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbAltunit").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("Conv").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("Conv").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtSaleQty").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtSaleQty").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtDefMRP").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtDefMRP").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("RSPrice").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("RSPrice").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("WSPrice").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("WSPrice").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtBarcode_TempStock").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtBarcode_TempStock").Style.ForeColor = Color.White
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Me.DataGridView1.Rows(num).Cells(8).Value = 0
			Me.DataGridView1.Rows(num).Cells(13).Value = 0.0
			Me.DataGridView1.Rows(num).Cells("txtCESS").Value = "0.00"
			Me.DataGridView1.Rows(num).Cells("txtMinStock").Value = "0.00"
			Me.DataGridView1.Rows(num).Cells("Conv").Value = 1
			Me.DataGridView1.Rows(num).Cells("txtSaleQty").Value = 1
			Me.SetComboBoxColumnSelectedIndex(num, "cmbSalesTaxType", 0)
			Me.SetComboBoxColumnSelectedIndex(num, "cmbPurchaseTaxType", 0)
			Me.DataGridView1.BeginEdit(True)
		End Sub

		' Token: 0x060081FF RID: 33279 RVA: 0x0003FB9B File Offset: 0x0003DD9B
		Private Sub btnProductSeting_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProductSeting.ShowDialog()
		End Sub

		' Token: 0x06008200 RID: 33280 RVA: 0x006049E0 File Offset: 0x00602BE0
		Private Sub btnBulkImageUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = (Me.DataGridView1.Columns.Count = 0) Or (Me.DataGridView1.Rows.Count = 0)
			If flag Then
				MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim num As Integer = 0
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Dim flag2 As Boolean = Conversions.ToBoolean(Operators.AndObject(dataGridViewRow.Cells(11).Value IsNot Nothing, Operators.CompareObjectEqual(dataGridViewRow.Cells(53).Value, True, False)))
						If flag2 Then
							num += 1
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim flag3 As Boolean = num <= 0
				If flag3 Then
					MessageBox.Show("Please select item list", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			End If
		End Sub

		' Token: 0x06008201 RID: 33281 RVA: 0x00604AF8 File Offset: 0x00602CF8
		Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim num As Integer = Me.DataGridView1.Rows.Count - 1
			Dim num2 As Integer = 2
			Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(num).Cells(num2)
			Try
				For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim isNewRow As Boolean = dataGridViewRow.IsNewRow
					If isNewRow Then
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(2).Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(2).Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(3).Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(3).Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(5).Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells(5).Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtCostPrice").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtCostPrice").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtDiscount").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtDiscount").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtMinStock").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtMinStock").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbPurchaseUnit").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbPurchaseUnit").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbSalesUnit").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbSalesUnit").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbAltunit").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("cmbAltunit").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("Conv").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("Conv").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtSaleQty").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtSaleQty").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtDefMRP").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtDefMRP").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("RSPrice").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("RSPrice").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("WSPrice").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("WSPrice").Style.ForeColor = Color.White
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtBarcode_TempStock").Style.BackColor = Color.Red
						Me.DataGridView1.Rows(dataGridViewRow.Index).Cells("txtBarcode_TempStock").Style.ForeColor = Color.White
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Me.DataGridView1.Rows(num).Cells(8).Value = 0
			Me.DataGridView1.Rows(num).Cells(13).Value = 0.0
			Me.DataGridView1.Rows(num).Cells("txtCESS").Value = "0.00"
			Me.DataGridView1.Rows(num).Cells("txtMinStock").Value = "0.00"
			Me.DataGridView1.Rows(num).Cells("Conv").Value = 1
			Me.DataGridView1.Rows(num).Cells("txtSaleQty").Value = 1
			Me.SetComboBoxColumnSelectedIndex(num, "cmbSalesTaxType", 0)
			Me.SetComboBoxColumnSelectedIndex(num, "cmbPurchaseTaxType", 0)
		End Sub

		' Token: 0x06008202 RID: 33282 RVA: 0x006052FC File Offset: 0x006034FC
		Private Sub SetupDataGridViewColumns()
			Me.Gridmenusetting()
			Dim num As Integer = 0
			Do
				Me.DataGridView1.Columns(num).Frozen = True
				num += 1
			Loop While num <= 4
			Me.DataGridView1.ScrollBars = ScrollBars.Both
		End Sub

		' Token: 0x06008203 RID: 33283 RVA: 0x00605340 File Offset: 0x00603540
		Private Sub Gridmenusetting()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				sqlDataAdapter.SelectCommand = New SqlCommand("SELECT menu_name, is_active FROM product_menu_setting", Me.con)
				Dim dataSet As DataSet = New DataSet("ds1")
				sqlDataAdapter.Fill(dataSet, "menu_setting")
				Dim dataTable As DataTable = dataSet.Tables("menu_setting")
				Try
					For Each obj As Object In dataTable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Dim text As String = dataRow("menu_name").ToString()
						Dim num As Short = Conversions.ToShort(dataRow("is_active").ToString())
						Try
							For Each obj2 As Object In Me.DataGridView1.Columns
								Dim dataGridViewColumn As DataGridViewColumn = CType(obj2, DataGridViewColumn)
								Dim flag As Boolean = Operators.CompareString(dataGridViewColumn.DataPropertyName, text, False) = 0
								If flag Then
									Dim flag2 As Boolean = num = 0S
									If flag2 Then
										dataGridViewColumn.Visible = False
									Else
										dataGridViewColumn.Visible = True
									End If
									Exit For
								End If
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
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008204 RID: 33284 RVA: 0x0060551C File Offset: 0x0060371C
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim text As String = Conversions.ToString(Me.dt.Rows(0)("Productname"))
			Dim text2 As String = Conversions.ToString(Me.dt.Rows(0)("CategoryName"))
			Me.txtID.Text = Me.GenerateID()
			Me.txtProductCode.Text = "P-" + Me.GenerateID()
			Me.BCodeDisplay()
			Dim text3 As String = Conversions.ToString(1000.0 + Conversions.ToDouble(Me.GenerateID1()))
			Me.txtBarcodeTempStock.Text = Me.txtBar.Text + text3
		End Sub

		' Token: 0x06008205 RID: 33285 RVA: 0x006055DC File Offset: 0x006037DC
		Private Sub frmProductRec1_VisibleChanged(sender As Object, e As EventArgs)
			Dim visible As Boolean = MyBase.Visible
			If Not visible Then
				Me.btnReset_Click(RuntimeHelpers.GetObjectValue(sender), e)
			End If
		End Sub

		' Token: 0x06008206 RID: 33286 RVA: 0x0003FBAE File Offset: 0x0003DDAE
		Private Sub frmProductRec1_Shown(sender As Object, e As EventArgs)
			Me.GelButtonNewRecord_Click(RuntimeHelpers.GetObjectValue(sender), e)
		End Sub

		' Token: 0x06008207 RID: 33287 RVA: 0x00180440 File Offset: 0x0017E640
		Private Sub frmProductRec1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				MyBase.Close()
			End If
		End Sub

		' Token: 0x0400394F RID: 14671
		Private barcode_Instance As frmPurchaseEntry

		' Token: 0x04003950 RID: 14672
		Private openingstock_Instance As frmPurchaseEntry

		' Token: 0x04003951 RID: 14673
		Private shouldHandleSelectedIndexChanged As Boolean

		' Token: 0x04003952 RID: 14674
		Private con As SqlConnection

		' Token: 0x04003953 RID: 14675
		Private cmd As SqlCommand

		' Token: 0x04003954 RID: 14676
		Private rdr As SqlDataReader

		' Token: 0x04003955 RID: 14677
		Private adp As SqlDataAdapter

		' Token: 0x04003956 RID: 14678
		Private ds As DataSet

		' Token: 0x04003957 RID: 14679
		Private dtable As DataTable

		' Token: 0x04003958 RID: 14680
		Private categories As DataTable

		' Token: 0x04003959 RID: 14681
		Private subcategories As DataTable

		' Token: 0x0400395A RID: 14682
		Private items As DataTable

		' Token: 0x0400395B RID: 14683
		Private insertBtn As String

		' Token: 0x0400395C RID: 14684
		Private updateBtn As String

		' Token: 0x0400395D RID: 14685
		Private strPcode As String

		' Token: 0x0400395E RID: 14686
		Private id As Short

		' Token: 0x0400395F RID: 14687
		Private strBarcode As String

		' Token: 0x04003960 RID: 14688
		Private dt As DataTable

		' Token: 0x04003961 RID: 14689
		Private Dad As SqlDataAdapter

		' Token: 0x04003962 RID: 14690
		Private Dst As DataSet

		' Token: 0x04003963 RID: 14691
		Private CurrentRow As Object

		' Token: 0x04003964 RID: 14692
		Private strStax As String

		' Token: 0x04003965 RID: 14693
		Private strPtax As String

		' Token: 0x04003966 RID: 14694
		Private isd As String
	End Class
End Namespace
