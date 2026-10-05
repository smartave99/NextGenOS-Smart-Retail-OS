Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020001D7 RID: 471
	<DesignerGenerated()>
	Public Partial Class frmProductDefault
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06007DBE RID: 32190 RVA: 0x005DB558 File Offset: 0x005D9758
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmProductDefault_Load
			AddHandler MyBase.Click, AddressOf Me.Card_Click
			AddHandler MyBase.FormClosing, AddressOf Me.frmProductDefault_FormClosing
			Me.InitializeComponent()
		End Sub

		' Token: 0x17002E1E RID: 11806
		' (get) Token: 0x06007DC1 RID: 32193 RVA: 0x0003DCDC File Offset: 0x0003BEDC
		' (set) Token: 0x06007DC2 RID: 32194 RVA: 0x0003DCE6 File Offset: 0x0003BEE6
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17002E1F RID: 11807
		' (get) Token: 0x06007DC3 RID: 32195 RVA: 0x0003DCEF File Offset: 0x0003BEEF
		' (set) Token: 0x06007DC4 RID: 32196 RVA: 0x005DD614 File Offset: 0x005DB814
		Private _btnSubCategroy As GelButton
		Friend Overridable Property btnSubCategroy As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSubCategroy
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSubCategroy_Click
				Dim gelButton As GelButton = Me._btnSubCategroy
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSubCategroy = value
				gelButton = Me._btnSubCategroy
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002E20 RID: 11808
		' (get) Token: 0x06007DC5 RID: 32197 RVA: 0x0003DCF9 File Offset: 0x0003BEF9
		' (set) Token: 0x06007DC6 RID: 32198 RVA: 0x0003DD03 File Offset: 0x0003BF03
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17002E21 RID: 11809
		' (get) Token: 0x06007DC7 RID: 32199 RVA: 0x0003DD0C File Offset: 0x0003BF0C
		' (set) Token: 0x06007DC8 RID: 32200 RVA: 0x005DD658 File Offset: 0x005DB858
		Private _btnUnit As GelButton
		Friend Overridable Property btnUnit As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUnit
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUnit_Click
				Dim gelButton As GelButton = Me._btnUnit
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnUnit = value
				gelButton = Me._btnUnit
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002E22 RID: 11810
		' (get) Token: 0x06007DC9 RID: 32201 RVA: 0x0003DD16 File Offset: 0x0003BF16
		' (set) Token: 0x06007DCA RID: 32202 RVA: 0x0003DD20 File Offset: 0x0003BF20
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17002E23 RID: 11811
		' (get) Token: 0x06007DCB RID: 32203 RVA: 0x0003DD29 File Offset: 0x0003BF29
		' (set) Token: 0x06007DCC RID: 32204 RVA: 0x005DD69C File Offset: 0x005DB89C
		Private _btnGST As GelButton
		Friend Overridable Property btnGST As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnGST
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnGST_Click
				Dim gelButton As GelButton = Me._btnGST
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnGST = value
				gelButton = Me._btnGST
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002E24 RID: 11812
		' (get) Token: 0x06007DCD RID: 32205 RVA: 0x0003DD33 File Offset: 0x0003BF33
		' (set) Token: 0x06007DCE RID: 32206 RVA: 0x0003DD3D File Offset: 0x0003BF3D
		Friend Overridable Property lblSource As Label

		' Token: 0x17002E25 RID: 11813
		' (get) Token: 0x06007DCF RID: 32207 RVA: 0x0003DD46 File Offset: 0x0003BF46
		' (set) Token: 0x06007DD0 RID: 32208 RVA: 0x0003DD50 File Offset: 0x0003BF50
		Friend Overridable Property cmbGST As ComboBox

		' Token: 0x17002E26 RID: 11814
		' (get) Token: 0x06007DD1 RID: 32209 RVA: 0x0003DD59 File Offset: 0x0003BF59
		' (set) Token: 0x06007DD2 RID: 32210 RVA: 0x0003DD63 File Offset: 0x0003BF63
		Friend Overridable Property cmbSubCategory As ComboBox

		' Token: 0x17002E27 RID: 11815
		' (get) Token: 0x06007DD3 RID: 32211 RVA: 0x0003DD6C File Offset: 0x0003BF6C
		' (set) Token: 0x06007DD4 RID: 32212 RVA: 0x0003DD76 File Offset: 0x0003BF76
		Friend Overridable Property cmbSalesUnit As ComboBox

		' Token: 0x17002E28 RID: 11816
		' (get) Token: 0x06007DD5 RID: 32213 RVA: 0x0003DD7F File Offset: 0x0003BF7F
		' (set) Token: 0x06007DD6 RID: 32214 RVA: 0x0003DD89 File Offset: 0x0003BF89
		Friend Overridable Property chkSubCategroy As CheckBox

		' Token: 0x17002E29 RID: 11817
		' (get) Token: 0x06007DD7 RID: 32215 RVA: 0x0003DD92 File Offset: 0x0003BF92
		' (set) Token: 0x06007DD8 RID: 32216 RVA: 0x0003DD9C File Offset: 0x0003BF9C
		Friend Overridable Property ChkUnit As CheckBox

		' Token: 0x17002E2A RID: 11818
		' (get) Token: 0x06007DD9 RID: 32217 RVA: 0x0003DDA5 File Offset: 0x0003BFA5
		' (set) Token: 0x06007DDA RID: 32218 RVA: 0x0003DDAF File Offset: 0x0003BFAF
		Friend Overridable Property ChkGST As CheckBox

		' Token: 0x17002E2B RID: 11819
		' (get) Token: 0x06007DDB RID: 32219 RVA: 0x0003DDB8 File Offset: 0x0003BFB8
		' (set) Token: 0x06007DDC RID: 32220 RVA: 0x005DD6E0 File Offset: 0x005DB8E0
		Private _dgwBill As DataGridView
		Friend Overridable Property dgwBill As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgwBill
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgwBill_CellContentClick
				Dim dataGridView As DataGridView = Me._dgwBill
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._dgwBill = value
				dataGridView = Me._dgwBill
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002E2C RID: 11820
		' (get) Token: 0x06007DDD RID: 32221 RVA: 0x0003DDC2 File Offset: 0x0003BFC2
		' (set) Token: 0x06007DDE RID: 32222 RVA: 0x0003DDCC File Offset: 0x0003BFCC
		Friend Overridable Property PictureBox5 As PictureBox

		' Token: 0x17002E2D RID: 11821
		' (get) Token: 0x06007DDF RID: 32223 RVA: 0x0003DDD5 File Offset: 0x0003BFD5
		' (set) Token: 0x06007DE0 RID: 32224 RVA: 0x005DD724 File Offset: 0x005DB924
		Private _GelButton11 As GelButton
		Friend Overridable Property GelButton11 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton11
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton11_Click
				Dim gelButton As GelButton = Me._GelButton11
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton11 = value
				gelButton = Me._GelButton11
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002E2E RID: 11822
		' (get) Token: 0x06007DE1 RID: 32225 RVA: 0x0003DDDF File Offset: 0x0003BFDF
		' (set) Token: 0x06007DE2 RID: 32226 RVA: 0x0003DDE9 File Offset: 0x0003BFE9
		Friend Overridable Property DataGridViewTextBoxColumn46 As DataGridViewTextBoxColumn

		' Token: 0x17002E2F RID: 11823
		' (get) Token: 0x06007DE3 RID: 32227 RVA: 0x0003DDF2 File Offset: 0x0003BFF2
		' (set) Token: 0x06007DE4 RID: 32228 RVA: 0x0003DDFC File Offset: 0x0003BFFC
		Friend Overridable Property DataGridViewTextBoxColumn48 As DataGridViewTextBoxColumn

		' Token: 0x17002E30 RID: 11824
		' (get) Token: 0x06007DE5 RID: 32229 RVA: 0x0003DE05 File Offset: 0x0003C005
		' (set) Token: 0x06007DE6 RID: 32230 RVA: 0x0003DE0F File Offset: 0x0003C00F
		Friend Overridable Property DataGridViewTextBoxColumn53 As DataGridViewTextBoxColumn

		' Token: 0x17002E31 RID: 11825
		' (get) Token: 0x06007DE7 RID: 32231 RVA: 0x0003DE18 File Offset: 0x0003C018
		' (set) Token: 0x06007DE8 RID: 32232 RVA: 0x0003DE22 File Offset: 0x0003C022
		Friend Overridable Property DataGridViewTextBoxColumn54 As DataGridViewTextBoxColumn

		' Token: 0x17002E32 RID: 11826
		' (get) Token: 0x06007DE9 RID: 32233 RVA: 0x0003DE2B File Offset: 0x0003C02B
		' (set) Token: 0x06007DEA RID: 32234 RVA: 0x0003DE35 File Offset: 0x0003C035
		Friend Overridable Property cmbSTax As ComboBox

		' Token: 0x17002E33 RID: 11827
		' (get) Token: 0x06007DEB RID: 32235 RVA: 0x0003DE3E File Offset: 0x0003C03E
		' (set) Token: 0x06007DEC RID: 32236 RVA: 0x0003DE48 File Offset: 0x0003C048
		Friend Overridable Property cmbPTax As ComboBox

		' Token: 0x17002E34 RID: 11828
		' (get) Token: 0x06007DED RID: 32237 RVA: 0x0003DE51 File Offset: 0x0003C051
		' (set) Token: 0x06007DEE RID: 32238 RVA: 0x0003DE5B File Offset: 0x0003C05B
		Friend Overridable Property Label25 As Label

		' Token: 0x17002E35 RID: 11829
		' (get) Token: 0x06007DEF RID: 32239 RVA: 0x0003DE64 File Offset: 0x0003C064
		' (set) Token: 0x06007DF0 RID: 32240 RVA: 0x0003DE6E File Offset: 0x0003C06E
		Friend Overridable Property Label24 As Label

		' Token: 0x17002E36 RID: 11830
		' (get) Token: 0x06007DF1 RID: 32241 RVA: 0x0003DE77 File Offset: 0x0003C077
		' (set) Token: 0x06007DF2 RID: 32242 RVA: 0x005DD768 File Offset: 0x005DB968
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

		' Token: 0x17002E37 RID: 11831
		' (get) Token: 0x06007DF3 RID: 32243 RVA: 0x0003DE81 File Offset: 0x0003C081
		' (set) Token: 0x06007DF4 RID: 32244 RVA: 0x005DD7AC File Offset: 0x005DB9AC
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

		' Token: 0x17002E38 RID: 11832
		' (get) Token: 0x06007DF5 RID: 32245 RVA: 0x0003DE8B File Offset: 0x0003C08B
		' (set) Token: 0x06007DF6 RID: 32246 RVA: 0x005DD7F0 File Offset: 0x005DB9F0
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

		' Token: 0x17002E39 RID: 11833
		' (get) Token: 0x06007DF7 RID: 32247 RVA: 0x0003DE95 File Offset: 0x0003C095
		' (set) Token: 0x06007DF8 RID: 32248 RVA: 0x005DD834 File Offset: 0x005DBA34
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

		' Token: 0x17002E3A RID: 11834
		' (get) Token: 0x06007DF9 RID: 32249 RVA: 0x0003DE9F File Offset: 0x0003C09F
		' (set) Token: 0x06007DFA RID: 32250 RVA: 0x0003DEA9 File Offset: 0x0003C0A9
		Friend Overridable Property Label1 As Label

		' Token: 0x17002E3B RID: 11835
		' (get) Token: 0x06007DFB RID: 32251 RVA: 0x0003DEB2 File Offset: 0x0003C0B2
		' (set) Token: 0x06007DFC RID: 32252 RVA: 0x0003DEBC File Offset: 0x0003C0BC
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17002E3C RID: 11836
		' (get) Token: 0x06007DFD RID: 32253 RVA: 0x0003DEC5 File Offset: 0x0003C0C5
		' (set) Token: 0x06007DFE RID: 32254 RVA: 0x0003DECF File Offset: 0x0003C0CF
		Friend Overridable Property Label2 As Label

		' Token: 0x17002E3D RID: 11837
		' (get) Token: 0x06007DFF RID: 32255 RVA: 0x0003DED8 File Offset: 0x0003C0D8
		' (set) Token: 0x06007E00 RID: 32256 RVA: 0x0003DEE2 File Offset: 0x0003C0E2
		Friend Overridable Property lblform As Label

		' Token: 0x17002E3E RID: 11838
		' (get) Token: 0x06007E01 RID: 32257 RVA: 0x0003DEEB File Offset: 0x0003C0EB
		' (set) Token: 0x06007E02 RID: 32258 RVA: 0x0003DEF5 File Offset: 0x0003C0F5
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x17002E3F RID: 11839
		' (get) Token: 0x06007E03 RID: 32259 RVA: 0x0003DEFE File Offset: 0x0003C0FE
		' (set) Token: 0x06007E04 RID: 32260 RVA: 0x005DD878 File Offset: 0x005DBA78
		Private _btnDiscount As GelButton
		Friend Overridable Property btnDiscount As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDiscount
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDiscount_Click
				Dim gelButton As GelButton = Me._btnDiscount
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDiscount = value
				gelButton = Me._btnDiscount
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002E40 RID: 11840
		' (get) Token: 0x06007E05 RID: 32261 RVA: 0x0003DF08 File Offset: 0x0003C108
		' (set) Token: 0x06007E06 RID: 32262 RVA: 0x0003DF12 File Offset: 0x0003C112
		Friend Overridable Property Label3 As Label

		' Token: 0x17002E41 RID: 11841
		' (get) Token: 0x06007E07 RID: 32263 RVA: 0x0003DF1B File Offset: 0x0003C11B
		' (set) Token: 0x06007E08 RID: 32264 RVA: 0x0003DF25 File Offset: 0x0003C125
		Friend Overridable Property txtDiscountRate As TextBox

		' Token: 0x17002E42 RID: 11842
		' (get) Token: 0x06007E09 RID: 32265 RVA: 0x0003DF2E File Offset: 0x0003C12E
		' (set) Token: 0x06007E0A RID: 32266 RVA: 0x0003DF38 File Offset: 0x0003C138
		Friend Overridable Property FlowPanelBill As FlowLayoutPanel

		' Token: 0x06007E0B RID: 32267 RVA: 0x005DD8BC File Offset: 0x005DBABC
		Private Sub frmProductDefault_Load(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = Me.cmbSubCategory
			clsfun.FillDropDownList(comboBox, "SELECT Id,RTRIM(SubCategoryName) as Subcatgname FROM SubCategory order by SubCategoryName ASC", "Subcatgname", "ID", "")
			Me.cmbSubCategory = comboBox
			comboBox = Me.cmbGST
			clsfun.FillDropDownList(comboBox, "SELECT Id,RTRIM(Rate) as Rate FROM TaxCat order by Rate ASC", "Rate", "ID", "")
			Me.cmbGST = comboBox
			comboBox = Me.cmbSalesUnit
			clsfun.FillDropDownList(comboBox, "SELECT distinct RTRIM(Unit) as Unit,Description FROM UnitMaster order by 1", "Description", "Unit", "")
			Me.cmbSalesUnit = comboBox
			Me.Getdata_BarcodeLayout()
			Me.DefaultBarcode_Printer()
			Me.DefaultTaxType()
			Me.DefaultLoyality()
			Me.DefaultDiscount()
		End Sub

		' Token: 0x06007E0C RID: 32268 RVA: 0x005DD970 File Offset: 0x005DBB70
		Public Sub DefaultDiscount()
			Try
				Dim text As String = "SELECT Rate FROM tbl_DiscountDefault WHERE id = 1"
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlConnection.Open()
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Dim flag As Boolean = sqlDataReader.Read()
							If flag Then
								Me.txtDiscountRate.Text = sqlDataReader("Rate").ToString()
							End If
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007E0D RID: 32269 RVA: 0x005DDA58 File Offset: 0x005DBC58
		Public Sub DefaultLoyality()
			Try
				Dim text As String = "SELECT * FROM tbl_loyalty_setting WHERE id = 1"
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlConnection.Open()
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Dim flag As Boolean = sqlDataReader.Read()
							If flag Then
								Me.ComboBox1.Text = sqlDataReader("mode").ToString()
								Me.TextBox1.Text = sqlDataReader("points").ToString()
							End If
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007E0E RID: 32270 RVA: 0x005DDB5C File Offset: 0x005DBD5C
		Public Sub DefaultTaxType()
			Try
				Dim text As String = "SELECT * FROM Defaulttaxtype WHERE id = 1"
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlConnection.Open()
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Dim flag As Boolean = sqlDataReader.Read()
							If flag Then
								Me.cmbSTax.Text = sqlDataReader("stax_type").ToString()
								Me.cmbPTax.Text = sqlDataReader("ptax_type").ToString()
							End If
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007E0F RID: 32271 RVA: 0x005DDC60 File Offset: 0x005DBE60
		Public Sub Getdata_BarcodeLayout()
			Try
				Me.FlowPanelBill.Controls.Clear()
				Dim text As String = ""
				Dim flag As Boolean = Operators.CompareString(Me.lblform.Text, "DProduct", False) = 0
				Dim text2 As String
				If flag Then
					text2 = "Select BarcodeStyleId,BarcodeStyleName,PrintPreviewType,BarcodeStyleImage from GorillaBarcodePreview where 1=1"
				Else
					text2 = "Select BarcodeStyleId,BarcodeStyleName,PrintPreviewType,BarcodeStyleImage from BarcodePreview where 1=1"
				End If
				Dim flag2 As Boolean = Operators.CompareString(text, "", False) <> 0
				If flag2 Then
					text2 = text2 + " AND PrintPreviewType='" + text + "'"
				End If
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Using sqlCommand As SqlCommand = New SqlCommand(text2, sqlConnection)
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							While sqlDataReader.Read()
								Dim card As Panel = New Panel() With { .Width = 200, .Height = 200, .Margin = New Padding(6), .BackColor = Color.White, .BorderStyle = BorderStyle.FixedSingle, .Tag = RuntimeHelpers.GetObjectValue(sqlDataReader("BarcodeStyleId")) }
								Dim text3 As String = sqlDataReader("BarcodeStyleImage").ToString().Trim()
								Dim text4 As String = Application.StartupPath + "\Bill_Barcode\" + text3
								Dim pictureBox As PictureBox = New PictureBox() With { .Dock = DockStyle.Fill, .SizeMode = PictureBoxSizeMode.Zoom, .BackColor = Color.White }
								Dim flag3 As Boolean = File.Exists(text4)
								If flag3 Then
									pictureBox.Image = Image.FromFile(text4)
								Else
									pictureBox.BackColor = Color.LightGray
								End If
								AddHandler pictureBox.Click, AddressOf Me.Card_Click
								AddHandler card.Click, AddressOf Me.Card_Click
								AddHandler card.MouseEnter, Sub(a0 As Object, a1 As EventArgs)
									card.BorderStyle = BorderStyle.Fixed3D
								End Sub
								AddHandler card.MouseLeave, Sub(a0 As Object, a1 As EventArgs)
									card.BorderStyle = BorderStyle.FixedSingle
								End Sub
								AddHandler pictureBox.MouseEnter, Sub(a0 As Object, a1 As EventArgs)
									card.BorderStyle = BorderStyle.Fixed3D
								End Sub
								AddHandler pictureBox.MouseLeave, Sub(a0 As Object, a1 As EventArgs)
									card.BorderStyle = BorderStyle.FixedSingle
								End Sub
								card.Controls.Add(pictureBox)
								Me.FlowPanelBill.Controls.Add(card)
							End While
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007E10 RID: 32272 RVA: 0x005DDF70 File Offset: 0x005DC170
		Private Sub Card_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = TypeOf sender Is Panel
				Dim panel As Panel
				If flag Then
					panel = CType(sender, Panel)
				Else
					panel = CType(CType(sender, Control).Parent, Panel)
				End If
				Dim flag2 As Boolean = panel Is Nothing
				If Not flag2 Then
					Dim flag3 As Boolean = panel.Tag Is Nothing
					If Not flag3 Then
						Dim num As Integer = Conversions.ToInteger(panel.Tag)
						Me.StyleId = Conversions.ToString(num)
						Dim text As String = ""
						Dim flag4 As Boolean = Operators.CompareString(Me.lblform.Text, "DProduct", False) = 0
						Dim text2 As String
						If flag4 Then
							text2 = "Select BarcodeStyleId,BarcodeStyleName,PrintPreviewType,BarcodeStyleImage from GorillaBarcodePreview where BarcodeStyleId=" + Conversions.ToString(num)
						Else
							text2 = "Select BarcodeStyleId,BarcodeStyleName,PrintPreviewType,BarcodeStyleImage from BarcodePreview WHERE BarcodeStyleId=" + Conversions.ToString(num)
						End If
						Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection.Open()
							Using sqlCommand As SqlCommand = New SqlCommand(text2, sqlConnection)
								Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
									Dim flag5 As Boolean = sqlDataReader.Read()
									If Not flag5 Then
										MessageBox.Show("Record not found!", "Warning")
										Return
									End If
									Me.StyleId = sqlDataReader("BarcodeStyleId").ToString()
									text = sqlDataReader("BarcodeStyleImage").ToString()
								End Using
							End Using
						End Using
						Dim flag6 As Boolean = Operators.CompareString(text, "", False) <> 0
						If flag6 Then
							Dim text3 As String = Application.StartupPath + "\Bill_Barcode\" + text
							Dim flag7 As Boolean = File.Exists(text3)
							If flag7 Then
								Me.PictureBox5.Image = Image.FromFile(text3)
							Else
								MessageBox.Show("Image file not found: " + text3)
							End If
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06007E11 RID: 32273 RVA: 0x005DE1CC File Offset: 0x005DC3CC
		Public Sub Getdata_BarcodeLayout_4Grid()
			Try
				Dim text As String = ""
				Dim flag As Boolean = Operators.CompareString(Me.lblform.Text, "DProduct", False) = 0
				Dim text2 As String
				If flag Then
					text2 = "Select BarcodeStyleId,BarcodeStyleName,PrintPreviewType,BarcodeStyleImage from GorillaBarcodePreview where 1=1"
				Else
					text2 = "Select BarcodeStyleId,BarcodeStyleName,PrintPreviewType,BarcodeStyleImage from BarcodePreview where 1=1"
				End If
				Dim flag2 As Boolean = Operators.CompareString(text, "", False) <> 0
				If flag2 Then
					text2 = text2 + " and PrintPreviewType='" + text + "'"
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgwBill.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgwBill.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
				End While
				Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag3 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
				Me.dgwBill.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007E12 RID: 32274 RVA: 0x005DE368 File Offset: 0x005DC568
		Public Sub DefaultBarcode_Printer()
			Try
				Dim text As String = ""
				Dim flag As Boolean = Operators.CompareString(Me.lblform.Text, "DProduct", False) = 0
				Dim text2 As String
				If flag Then
					text2 = "Select BarcodeStyleId,BarcodeStyleName,PrintPreviewType,BarcodeStyleImage from GorillaBarcodePreview where is_active=1"
				Else
					text2 = "Select BarcodeStyleId,BarcodeStyleName,PrintPreviewType,BarcodeStyleImage from BarcodePreview where is_active=1"
				End If
				Dim flag2 As Boolean = Operators.CompareString(text, "", False) <> 0
				If flag2 Then
					text2 = text2 + " and PrintPreviewType='" + text + "'"
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
				If flag3 Then
					Dim text3 As String = Application.StartupPath + "\Bill_Barcode\" + ModCommonClasses.rdr(3).ToString()
					Dim flag4 As Boolean = File.Exists(text3)
					If flag4 Then
						Me.PictureBox5.Image = Image.FromFile(text3)
					Else
						Me.PictureBox5.Image = Nothing
						MessageBox.Show("Image not found at: " + text3, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End If
					Me.StyleId = ModCommonClasses.rdr(0).ToString()
				End If
				Try
					For Each obj As Object In CType(Me.dgwBill.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Dim flag5 As Boolean = Operators.CompareString(dataGridViewRow.Cells(2).Value.ToString(), ModCommonClasses.rdr(2).ToString(), False) = 0
						If flag5 Then
							dataGridViewRow.DefaultCellStyle.BackColor = Color.Yellow
							Exit For
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag6 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007E13 RID: 32275 RVA: 0x005DE5C8 File Offset: 0x005DC7C8
		Private Sub btnSubCategroy_Click(sender As Object, e As EventArgs)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Update SubCategory set  IsDefault='No';  update SubCategory set IsDefault='Yes' where ID=", Me.cmbSubCategory.SelectedValue), ""))
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			Dim memoryStream As MemoryStream = New MemoryStream()
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
			MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
		End Sub

		' Token: 0x06007E14 RID: 32276 RVA: 0x005DE660 File Offset: 0x005DC860
		Private Sub btnUnit_Click(sender As Object, e As EventArgs)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Update UnitMaster set  IsDefault='No';update UnitMaster set IsDefault='Yes' where Unit='", Me.cmbSalesUnit.SelectedValue), "'"))
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			Dim memoryStream As MemoryStream = New MemoryStream()
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
			MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
		End Sub

		' Token: 0x06007E15 RID: 32277 RVA: 0x005DE6F8 File Offset: 0x005DC8F8
		Private Sub btnGST_Click(sender As Object, e As EventArgs)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Update TaxCat set IsDefault='No';update TaxCat set IsDefault='Yes' where ID=", Me.cmbGST.SelectedValue), ""))
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			Dim memoryStream As MemoryStream = New MemoryStream()
			ModCommonClasses.cmd.ExecuteReader()
			ModCommonClasses.con.Close()
			MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
		End Sub

		' Token: 0x06007E16 RID: 32278 RVA: 0x005DE790 File Offset: 0x005DC990
		Private Sub frmProductDefault_FormClosing(sender As Object, e As FormClosingEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblform.Text, "import", False) = 0
			If flag Then
				MyBase.Dispose()
				MyProject.Forms.frmExportImportExcel_ProductsRecord1.ShowDialog()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.lblform.Text, "DProduct", False) = 0
				If flag2 Then
					MyBase.Dispose()
					MyProject.Forms.frmProductEntry.ShowDialog()
				Else
					Dim flag3 As Boolean = Operators.CompareString(Me.lblform.Text, "frmProductRec1", False) = 0
					If flag3 Then
						MyBase.Dispose()
						MyProject.Forms.frmProductRec.ShowDialog()
					Else
						Dim flag4 As Boolean = Operators.CompareString(Me.lblform.Text, "frmProductRec2", False) = 0
						If flag4 Then
							MyBase.Dispose()
							MyProject.Forms.frmPdfReader.ShowDialog()
						Else
							MyBase.Dispose()
							MyProject.Forms.frmProductSmart.ShowDialog()
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06007E17 RID: 32279 RVA: 0x005DE89C File Offset: 0x005DCA9C
		Private Sub defaulyprinterUpdate()
			Try
				ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con1.Open()
				Dim flag As Boolean = Operators.CompareString(Me.lblform.Text, "DProduct", False) = 0
				Dim text As String
				If flag Then
					text = "update GorillaBarcodePreview set is_active=0"
				Else
					text = "update BarcodePreview set is_active=0"
				End If
				ModCommonClasses.cmd1 = New SqlCommand(text)
				ModCommonClasses.cmd1.Connection = ModCommonClasses.con1
				ModCommonClasses.cmd1.ExecuteReader()
				ModCommonClasses.con1.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag2 As Boolean = Operators.CompareString(Me.lblform.Text, "DProduct", False) = 0
				Dim text2 As String
				If flag2 Then
					text2 = "update GorillaBarcodePreview set is_active=1 where BarcodeStyleId=@d1"
				Else
					text2 = "update BarcodePreview set is_active=1 where BarcodeStyleId=@d1"
				End If
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.StyleId)
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
				MessageBox.Show("Successfully Updated", "Terminal Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007E18 RID: 32280 RVA: 0x005DEA10 File Offset: 0x005DCC10
		Private Sub GelButton11_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.StyleId, "", False) <> 0
			If flag Then
				Me.defaulyprinterUpdate()
				Me.Getdata_BarcodeLayout()
				Me.DefaultBarcode_Printer()
			Else
				MessageBox.Show("Barcode Style Not Selected!")
			End If
		End Sub

		' Token: 0x06007E19 RID: 32281 RVA: 0x005DEA5C File Offset: 0x005DCC5C
		Private Sub dgwBill_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgwBill.SelectedRows(0)
				Dim text As String = Application.StartupPath + "\Bill_Barcode\" + dataGridViewRow.Cells(3).Value.ToString().Trim()
				Dim flag As Boolean = File.Exists(text)
				If flag Then
					Me.PictureBox5.Image = Image.FromFile(text)
				Else
					Me.PictureBox5.Image = Nothing
					MessageBox.Show("Image not found at: " + text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
				Me.StyleId = dataGridViewRow.Cells(0).Value.ToString()
			Catch ex As Exception
				MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007E1A RID: 32282 RVA: 0x005DEB4C File Offset: 0x005DCD4C
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Update Defaulttaxtype Set stax_type=@d1 where id=1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbSTax.Text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteNonQuery()
			ModCommonClasses.con.Close()
			MessageBox.Show("Updated Succefully!")
		End Sub

		' Token: 0x06007E1B RID: 32283 RVA: 0x005DEBD8 File Offset: 0x005DCDD8
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Update Defaulttaxtype Set ptax_type=@d1 where id=1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbPTax.Text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.ExecuteNonQuery()
			ModCommonClasses.con.Close()
			MessageBox.Show("Updated Succefully!")
		End Sub

		' Token: 0x06007E1C RID: 32284 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06007E1D RID: 32285 RVA: 0x005DEC64 File Offset: 0x005DCE64
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Update tbl_loyalty_setting Set mode=@d1, points=@d2 where id=1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.ComboBox1.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Convert.ToDecimal(Me.TextBox1.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
				MessageBox.Show("Updated Succefully!")
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06007E1E RID: 32286 RVA: 0x005DED3C File Offset: 0x005DCF3C
		Private Sub btnDiscount_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Update tbl_DiscountDefault Set Rate=@d1 where id=1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Convert.ToDecimal(Me.txtDiscountRate.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
				MessageBox.Show("Updated Succefully!")
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x040037B9 RID: 14265
		Private StyleId As String
	End Class
End Namespace
