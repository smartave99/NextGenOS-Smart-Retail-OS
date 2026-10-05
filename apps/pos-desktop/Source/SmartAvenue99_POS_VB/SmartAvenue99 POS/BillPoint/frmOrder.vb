Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200005D RID: 93
	<DesignerGenerated()>
	Public Partial Class frmOrder
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600112E RID: 4398 RVA: 0x000C3C48 File Offset: 0x000C1E48
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmOrder_Load
			Me.json = Nothing
			Me.ujson = Nothing
			Me.pjson = Nothing
			Me.ajson = Nothing
			Me.lblType = ""
			Me.rec = New Record()
			Me.inputString = ""
			Me.outputString = ""
			Me.datePart = ""
			Me.strb = New StringBuilder()
			Me.lstBarcode = New List(Of String)()
			Me.lstMRP = New List(Of String)()
			Me.InitializeComponent()
		End Sub

		' Token: 0x170006FA RID: 1786
		' (get) Token: 0x06001131 RID: 4401 RVA: 0x0000F603 File Offset: 0x0000D803
		' (set) Token: 0x06001132 RID: 4402 RVA: 0x0000F60D File Offset: 0x0000D80D
		Friend Overridable Property Label8 As Label

		' Token: 0x170006FB RID: 1787
		' (get) Token: 0x06001133 RID: 4403 RVA: 0x0000F616 File Offset: 0x0000D816
		' (set) Token: 0x06001134 RID: 4404 RVA: 0x0000F620 File Offset: 0x0000D820
		Friend Overridable Property txtCustomerID As TextBox

		' Token: 0x170006FC RID: 1788
		' (get) Token: 0x06001135 RID: 4405 RVA: 0x0000F629 File Offset: 0x0000D829
		' (set) Token: 0x06001136 RID: 4406 RVA: 0x0000F633 File Offset: 0x0000D833
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x170006FD RID: 1789
		' (get) Token: 0x06001137 RID: 4407 RVA: 0x0000F63C File Offset: 0x0000D83C
		' (set) Token: 0x06001138 RID: 4408 RVA: 0x0000F646 File Offset: 0x0000D846
		Friend Overridable Property txtGrandTotal As TextBox

		' Token: 0x170006FE RID: 1790
		' (get) Token: 0x06001139 RID: 4409 RVA: 0x0000F64F File Offset: 0x0000D84F
		' (set) Token: 0x0600113A RID: 4410 RVA: 0x0000F659 File Offset: 0x0000D859
		Friend Overridable Property Label10 As Label

		' Token: 0x170006FF RID: 1791
		' (get) Token: 0x0600113B RID: 4411 RVA: 0x0000F662 File Offset: 0x0000D862
		' (set) Token: 0x0600113C RID: 4412 RVA: 0x0000F66C File Offset: 0x0000D86C
		Friend Overridable Property txtDCharg As TextBox

		' Token: 0x17000700 RID: 1792
		' (get) Token: 0x0600113D RID: 4413 RVA: 0x0000F675 File Offset: 0x0000D875
		' (set) Token: 0x0600113E RID: 4414 RVA: 0x0000F67F File Offset: 0x0000D87F
		Friend Overridable Property Label9 As Label

		' Token: 0x17000701 RID: 1793
		' (get) Token: 0x0600113F RID: 4415 RVA: 0x0000F688 File Offset: 0x0000D888
		' (set) Token: 0x06001140 RID: 4416 RVA: 0x0000F692 File Offset: 0x0000D892
		Friend Overridable Property txtSubTotal As TextBox

		' Token: 0x17000702 RID: 1794
		' (get) Token: 0x06001141 RID: 4417 RVA: 0x0000F69B File Offset: 0x0000D89B
		' (set) Token: 0x06001142 RID: 4418 RVA: 0x0000F6A5 File Offset: 0x0000D8A5
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17000703 RID: 1795
		' (get) Token: 0x06001143 RID: 4419 RVA: 0x0000F6AE File Offset: 0x0000D8AE
		' (set) Token: 0x06001144 RID: 4420 RVA: 0x0000F6B8 File Offset: 0x0000D8B8
		Friend Overridable Property txtDtime As TextBox

		' Token: 0x17000704 RID: 1796
		' (get) Token: 0x06001145 RID: 4421 RVA: 0x0000F6C1 File Offset: 0x0000D8C1
		' (set) Token: 0x06001146 RID: 4422 RVA: 0x0000F6CB File Offset: 0x0000D8CB
		Friend Overridable Property txtDdate As TextBox

		' Token: 0x17000705 RID: 1797
		' (get) Token: 0x06001147 RID: 4423 RVA: 0x0000F6D4 File Offset: 0x0000D8D4
		' (set) Token: 0x06001148 RID: 4424 RVA: 0x0000F6DE File Offset: 0x0000D8DE
		Friend Overridable Property txtOdate As TextBox

		' Token: 0x17000706 RID: 1798
		' (get) Token: 0x06001149 RID: 4425 RVA: 0x0000F6E7 File Offset: 0x0000D8E7
		' (set) Token: 0x0600114A RID: 4426 RVA: 0x0000F6F1 File Offset: 0x0000D8F1
		Friend Overridable Property txtPaymentMode As TextBox

		' Token: 0x17000707 RID: 1799
		' (get) Token: 0x0600114B RID: 4427 RVA: 0x0000F6FA File Offset: 0x0000D8FA
		' (set) Token: 0x0600114C RID: 4428 RVA: 0x0000F704 File Offset: 0x0000D904
		Friend Overridable Property Label1 As Label

		' Token: 0x17000708 RID: 1800
		' (get) Token: 0x0600114D RID: 4429 RVA: 0x0000F70D File Offset: 0x0000D90D
		' (set) Token: 0x0600114E RID: 4430 RVA: 0x0000F717 File Offset: 0x0000D917
		Friend Overridable Property Label3 As Label

		' Token: 0x17000709 RID: 1801
		' (get) Token: 0x0600114F RID: 4431 RVA: 0x0000F720 File Offset: 0x0000D920
		' (set) Token: 0x06001150 RID: 4432 RVA: 0x0000F72A File Offset: 0x0000D92A
		Friend Overridable Property cmbCustomerName As ComboBox

		' Token: 0x1700070A RID: 1802
		' (get) Token: 0x06001151 RID: 4433 RVA: 0x0000F733 File Offset: 0x0000D933
		' (set) Token: 0x06001152 RID: 4434 RVA: 0x0000F73D File Offset: 0x0000D93D
		Friend Overridable Property txtEmailID As TextBox

		' Token: 0x1700070B RID: 1803
		' (get) Token: 0x06001153 RID: 4435 RVA: 0x0000F746 File Offset: 0x0000D946
		' (set) Token: 0x06001154 RID: 4436 RVA: 0x0000F750 File Offset: 0x0000D950
		Friend Overridable Property Label7 As Label

		' Token: 0x1700070C RID: 1804
		' (get) Token: 0x06001155 RID: 4437 RVA: 0x0000F759 File Offset: 0x0000D959
		' (set) Token: 0x06001156 RID: 4438 RVA: 0x0000F763 File Offset: 0x0000D963
		Friend Overridable Property Label6 As Label

		' Token: 0x1700070D RID: 1805
		' (get) Token: 0x06001157 RID: 4439 RVA: 0x0000F76C File Offset: 0x0000D96C
		' (set) Token: 0x06001158 RID: 4440 RVA: 0x0000F776 File Offset: 0x0000D976
		Friend Overridable Property txtContactNo As TextBox

		' Token: 0x1700070E RID: 1806
		' (get) Token: 0x06001159 RID: 4441 RVA: 0x0000F77F File Offset: 0x0000D97F
		' (set) Token: 0x0600115A RID: 4442 RVA: 0x0000F789 File Offset: 0x0000D989
		Friend Overridable Property txtZipCode As TextBox

		' Token: 0x1700070F RID: 1807
		' (get) Token: 0x0600115B RID: 4443 RVA: 0x0000F792 File Offset: 0x0000D992
		' (set) Token: 0x0600115C RID: 4444 RVA: 0x0000F79C File Offset: 0x0000D99C
		Friend Overridable Property Label12 As Label

		' Token: 0x17000710 RID: 1808
		' (get) Token: 0x0600115D RID: 4445 RVA: 0x0000F7A5 File Offset: 0x0000D9A5
		' (set) Token: 0x0600115E RID: 4446 RVA: 0x0000F7AF File Offset: 0x0000D9AF
		Friend Overridable Property Label2 As Label

		' Token: 0x17000711 RID: 1809
		' (get) Token: 0x0600115F RID: 4447 RVA: 0x0000F7B8 File Offset: 0x0000D9B8
		' (set) Token: 0x06001160 RID: 4448 RVA: 0x0000F7C2 File Offset: 0x0000D9C2
		Friend Overridable Property txtAddress As TextBox

		' Token: 0x17000712 RID: 1810
		' (get) Token: 0x06001161 RID: 4449 RVA: 0x0000F7CB File Offset: 0x0000D9CB
		' (set) Token: 0x06001162 RID: 4450 RVA: 0x0000F7D5 File Offset: 0x0000D9D5
		Friend Overridable Property Label5 As Label

		' Token: 0x17000713 RID: 1811
		' (get) Token: 0x06001163 RID: 4451 RVA: 0x0000F7DE File Offset: 0x0000D9DE
		' (set) Token: 0x06001164 RID: 4452 RVA: 0x0000F7E8 File Offset: 0x0000D9E8
		Friend Overridable Property txtCity As TextBox

		' Token: 0x17000714 RID: 1812
		' (get) Token: 0x06001165 RID: 4453 RVA: 0x0000F7F1 File Offset: 0x0000D9F1
		' (set) Token: 0x06001166 RID: 4454 RVA: 0x0000F7FB File Offset: 0x0000D9FB
		Friend Overridable Property Label4 As Label

		' Token: 0x17000715 RID: 1813
		' (get) Token: 0x06001167 RID: 4455 RVA: 0x0000F804 File Offset: 0x0000DA04
		' (set) Token: 0x06001168 RID: 4456 RVA: 0x0000F80E File Offset: 0x0000DA0E
		Friend Overridable Property txtOrderNo As TextBox

		' Token: 0x17000716 RID: 1814
		' (get) Token: 0x06001169 RID: 4457 RVA: 0x0000F817 File Offset: 0x0000DA17
		' (set) Token: 0x0600116A RID: 4458 RVA: 0x0000F821 File Offset: 0x0000DA21
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x17000717 RID: 1815
		' (get) Token: 0x0600116B RID: 4459 RVA: 0x0000F82A File Offset: 0x0000DA2A
		' (set) Token: 0x0600116C RID: 4460 RVA: 0x0000F834 File Offset: 0x0000DA34
		Friend Overridable Property Label11 As Label

		' Token: 0x17000718 RID: 1816
		' (get) Token: 0x0600116D RID: 4461 RVA: 0x0000F83D File Offset: 0x0000DA3D
		' (set) Token: 0x0600116E RID: 4462 RVA: 0x0000F847 File Offset: 0x0000DA47
		Friend Overridable Property txtOrderStatus As TextBox

		' Token: 0x17000719 RID: 1817
		' (get) Token: 0x0600116F RID: 4463 RVA: 0x0000F850 File Offset: 0x0000DA50
		' (set) Token: 0x06001170 RID: 4464 RVA: 0x0000F85A File Offset: 0x0000DA5A
		Friend Overridable Property txtOrderId As TextBox

		' Token: 0x1700071A RID: 1818
		' (get) Token: 0x06001171 RID: 4465 RVA: 0x0000F863 File Offset: 0x0000DA63
		' (set) Token: 0x06001172 RID: 4466 RVA: 0x000C66A8 File Offset: 0x000C48A8
		Private _btnCancle As GelButton
		Friend Overridable Property btnCancle As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnCancle
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton10_Click
				Dim gelButton As GelButton = Me._btnCancle
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnCancle = value
				gelButton = Me._btnCancle
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700071B RID: 1819
		' (get) Token: 0x06001173 RID: 4467 RVA: 0x0000F86D File Offset: 0x0000DA6D
		' (set) Token: 0x06001174 RID: 4468 RVA: 0x0000F877 File Offset: 0x0000DA77
		Friend Overridable Property lblUser As Label

		' Token: 0x1700071C RID: 1820
		' (get) Token: 0x06001175 RID: 4469 RVA: 0x0000F880 File Offset: 0x0000DA80
		' (set) Token: 0x06001176 RID: 4470 RVA: 0x000C66EC File Offset: 0x000C48EC
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellClick, dataGridViewCellEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700071D RID: 1821
		' (get) Token: 0x06001177 RID: 4471 RVA: 0x0000F88A File Offset: 0x0000DA8A
		' (set) Token: 0x06001178 RID: 4472 RVA: 0x0000F894 File Offset: 0x0000DA94
		Friend Overridable Property id As DataGridViewTextBoxColumn

		' Token: 0x1700071E RID: 1822
		' (get) Token: 0x06001179 RID: 4473 RVA: 0x0000F89D File Offset: 0x0000DA9D
		' (set) Token: 0x0600117A RID: 4474 RVA: 0x0000F8A7 File Offset: 0x0000DAA7
		Friend Overridable Property Orderid As DataGridViewTextBoxColumn

		' Token: 0x1700071F RID: 1823
		' (get) Token: 0x0600117B RID: 4475 RVA: 0x0000F8B0 File Offset: 0x0000DAB0
		' (set) Token: 0x0600117C RID: 4476 RVA: 0x0000F8BA File Offset: 0x0000DABA
		Friend Overridable Property customer As DataGridViewTextBoxColumn

		' Token: 0x17000720 RID: 1824
		' (get) Token: 0x0600117D RID: 4477 RVA: 0x0000F8C3 File Offset: 0x0000DAC3
		' (set) Token: 0x0600117E RID: 4478 RVA: 0x0000F8CD File Offset: 0x0000DACD
		Friend Overridable Property order_date As DataGridViewTextBoxColumn

		' Token: 0x17000721 RID: 1825
		' (get) Token: 0x0600117F RID: 4479 RVA: 0x0000F8D6 File Offset: 0x0000DAD6
		' (set) Token: 0x06001180 RID: 4480 RVA: 0x0000F8E0 File Offset: 0x0000DAE0
		Friend Overridable Property address As DataGridViewTextBoxColumn

		' Token: 0x17000722 RID: 1826
		' (get) Token: 0x06001181 RID: 4481 RVA: 0x0000F8E9 File Offset: 0x0000DAE9
		' (set) Token: 0x06001182 RID: 4482 RVA: 0x0000F8F3 File Offset: 0x0000DAF3
		Friend Overridable Property city As DataGridViewTextBoxColumn

		' Token: 0x17000723 RID: 1827
		' (get) Token: 0x06001183 RID: 4483 RVA: 0x0000F8FC File Offset: 0x0000DAFC
		' (set) Token: 0x06001184 RID: 4484 RVA: 0x0000F906 File Offset: 0x0000DB06
		Friend Overridable Property totalamount As DataGridViewTextBoxColumn

		' Token: 0x17000724 RID: 1828
		' (get) Token: 0x06001185 RID: 4485 RVA: 0x0000F90F File Offset: 0x0000DB0F
		' (set) Token: 0x06001186 RID: 4486 RVA: 0x0000F919 File Offset: 0x0000DB19
		Friend Overridable Property status As DataGridViewTextBoxColumn

		' Token: 0x17000725 RID: 1829
		' (get) Token: 0x06001187 RID: 4487 RVA: 0x0000F922 File Offset: 0x0000DB22
		' (set) Token: 0x06001188 RID: 4488 RVA: 0x0000F92C File Offset: 0x0000DB2C
		Friend Overridable Property paymentmode As DataGridViewTextBoxColumn

		' Token: 0x17000726 RID: 1830
		' (get) Token: 0x06001189 RID: 4489 RVA: 0x0000F935 File Offset: 0x0000DB35
		' (set) Token: 0x0600118A RID: 4490 RVA: 0x0000F93F File Offset: 0x0000DB3F
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17000727 RID: 1831
		' (get) Token: 0x0600118B RID: 4491 RVA: 0x0000F948 File Offset: 0x0000DB48
		' (set) Token: 0x0600118C RID: 4492 RVA: 0x0000F952 File Offset: 0x0000DB52
		Friend Overridable Property uid As DataGridViewTextBoxColumn

		' Token: 0x17000728 RID: 1832
		' (get) Token: 0x0600118D RID: 4493 RVA: 0x0000F95B File Offset: 0x0000DB5B
		' (set) Token: 0x0600118E RID: 4494 RVA: 0x0000F965 File Offset: 0x0000DB65
		Friend Overridable Property DataGridView1 As DataGridView

		' Token: 0x17000729 RID: 1833
		' (get) Token: 0x0600118F RID: 4495 RVA: 0x0000F96E File Offset: 0x0000DB6E
		' (set) Token: 0x06001190 RID: 4496 RVA: 0x0000F978 File Offset: 0x0000DB78
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x1700072A RID: 1834
		' (get) Token: 0x06001191 RID: 4497 RVA: 0x0000F981 File Offset: 0x0000DB81
		' (set) Token: 0x06001192 RID: 4498 RVA: 0x0000F98B File Offset: 0x0000DB8B
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x1700072B RID: 1835
		' (get) Token: 0x06001193 RID: 4499 RVA: 0x0000F994 File Offset: 0x0000DB94
		' (set) Token: 0x06001194 RID: 4500 RVA: 0x0000F99E File Offset: 0x0000DB9E
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700072C RID: 1836
		' (get) Token: 0x06001195 RID: 4501 RVA: 0x0000F9A7 File Offset: 0x0000DBA7
		' (set) Token: 0x06001196 RID: 4502 RVA: 0x0000F9B1 File Offset: 0x0000DBB1
		Friend Overridable Property MRP As DataGridViewTextBoxColumn

		' Token: 0x1700072D RID: 1837
		' (get) Token: 0x06001197 RID: 4503 RVA: 0x0000F9BA File Offset: 0x0000DBBA
		' (set) Token: 0x06001198 RID: 4504 RVA: 0x0000F9C4 File Offset: 0x0000DBC4
		Friend Overridable Property Dis As DataGridViewTextBoxColumn

		' Token: 0x1700072E RID: 1838
		' (get) Token: 0x06001199 RID: 4505 RVA: 0x0000F9CD File Offset: 0x0000DBCD
		' (set) Token: 0x0600119A RID: 4506 RVA: 0x0000F9D7 File Offset: 0x0000DBD7
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x1700072F RID: 1839
		' (get) Token: 0x0600119B RID: 4507 RVA: 0x0000F9E0 File Offset: 0x0000DBE0
		' (set) Token: 0x0600119C RID: 4508 RVA: 0x0000F9EA File Offset: 0x0000DBEA
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x17000730 RID: 1840
		' (get) Token: 0x0600119D RID: 4509 RVA: 0x0000F9F3 File Offset: 0x0000DBF3
		' (set) Token: 0x0600119E RID: 4510 RVA: 0x0000F9FD File Offset: 0x0000DBFD
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x17000731 RID: 1841
		' (get) Token: 0x0600119F RID: 4511 RVA: 0x0000FA06 File Offset: 0x0000DC06
		' (set) Token: 0x060011A0 RID: 4512 RVA: 0x0000FA10 File Offset: 0x0000DC10
		Friend Overridable Property DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn

		' Token: 0x17000732 RID: 1842
		' (get) Token: 0x060011A1 RID: 4513 RVA: 0x0000FA19 File Offset: 0x0000DC19
		' (set) Token: 0x060011A2 RID: 4514 RVA: 0x0000FA23 File Offset: 0x0000DC23
		Friend Overridable Property RadioButton3 As RadioButton

		' Token: 0x17000733 RID: 1843
		' (get) Token: 0x060011A3 RID: 4515 RVA: 0x0000FA2C File Offset: 0x0000DC2C
		' (set) Token: 0x060011A4 RID: 4516 RVA: 0x0000FA36 File Offset: 0x0000DC36
		Friend Overridable Property RadioButton2 As RadioButton

		' Token: 0x17000734 RID: 1844
		' (get) Token: 0x060011A5 RID: 4517 RVA: 0x0000FA3F File Offset: 0x0000DC3F
		' (set) Token: 0x060011A6 RID: 4518 RVA: 0x0000FA49 File Offset: 0x0000DC49
		Friend Overridable Property lblCode As Label

		' Token: 0x17000735 RID: 1845
		' (get) Token: 0x060011A7 RID: 4519 RVA: 0x0000FA52 File Offset: 0x0000DC52
		' (set) Token: 0x060011A8 RID: 4520 RVA: 0x0000FA5C File Offset: 0x0000DC5C
		Friend Overridable Property RadioButton1 As RadioButton

		' Token: 0x17000736 RID: 1846
		' (get) Token: 0x060011A9 RID: 4521 RVA: 0x0000FA65 File Offset: 0x0000DC65
		' (set) Token: 0x060011AA RID: 4522 RVA: 0x000C6730 File Offset: 0x000C4930
		Private _btnEcomPost As GelButton
		Friend Overridable Property btnEcomPost As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnEcomPost
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnEcomPost_Click
				Dim gelButton As GelButton = Me._btnEcomPost
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnEcomPost = value
				gelButton = Me._btnEcomPost
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000737 RID: 1847
		' (get) Token: 0x060011AB RID: 4523 RVA: 0x0000FA6F File Offset: 0x0000DC6F
		' (set) Token: 0x060011AC RID: 4524 RVA: 0x000C6774 File Offset: 0x000C4974
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

		' Token: 0x17000738 RID: 1848
		' (get) Token: 0x060011AD RID: 4525 RVA: 0x0000FA79 File Offset: 0x0000DC79
		' (set) Token: 0x060011AE RID: 4526 RVA: 0x0000FA83 File Offset: 0x0000DC83
		Friend Overridable Property RadioButton4 As RadioButton

		' Token: 0x060011AF RID: 4527 RVA: 0x000C67B8 File Offset: 0x000C49B8
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.RadioButton4.Checked
			If checked Then
				Me.BindGrid("completed")
			Else
				Dim checked2 As Boolean = Me.RadioButton2.Checked
				If checked2 Then
					Me.OrderSearch2("completed")
				Else
					Dim checked3 As Boolean = Me.RadioButton3.Checked
					If checked3 Then
						Me.OrderSearch2("cancelled")
					Else
						Me.OrderSearch()
					End If
				End If
			End If
		End Sub

		' Token: 0x060011B0 RID: 4528 RVA: 0x000C682C File Offset: 0x000C4A2C
		Public Sub OrderSearch2(serachtype As String)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag Then
					MessageBox.Show("Please Check your internet connection!")
				Else
					Me.strb.Clear()
					Dim dataTable As DataTable = New DataTable()
					dataTable = clsfun.ExecDataTable("Select c2,FtpUrl,FtpUser,FtpPassword,WebUrl from FTP_Category where c2='Enabled'")
					Dim text As String = dataTable.Rows(0)("WebUrl").ToString() + "/api/get-order?"
					Me.strb.Append(text)
					Me.btnEcomPost.Enabled = False
					Me.btnCancle.Enabled = False
					Me.strb.Append("type=" + serachtype)
					Dim text2 As String = Me.strb.ToString().Trim()
					Dim webRequest As WebRequest = WebRequest.Create(text2)
					Dim httpWebRequest As HttpWebRequest = CType(webRequest, HttpWebRequest)
					httpWebRequest.Method = "GET"
					httpWebRequest.ContentType = "application/json"
					Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
					Using streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
						Dim text3 As String = streamReader.ReadToEnd()
						Dim bytes As Byte() = Encoding.UTF8.GetBytes(text3)
						Dim memoryStream As MemoryStream = New MemoryStream(bytes)
						Dim dataContractJsonSerializer As DataContractJsonSerializer = New DataContractJsonSerializer(GetType(mOrder))
						Me.json = CType(dataContractJsonSerializer.ReadObject(memoryStream), mOrder)
						Dim success As Boolean = Me.json.success
						If success Then
							Me.dgw.Rows.Clear()
							Dim num As Integer = Me.json.records.Count() - 1
							For i As Integer = 0 To num
								Me.rec = Me.json.records(i)
								Me.dgw.Rows.Add(New Object() { Me.rec.id, Me.rec.oid, Me.rec.order_date })
							Next
						Else
							Me.dgw.Rows.Clear()
						End If
					End Using
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		' Token: 0x060011B1 RID: 4529 RVA: 0x000C6A90 File Offset: 0x000C4C90
		Private Sub OrderSearch()
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag Then
					MessageBox.Show("Please Check your internet connection!")
				Else
					Me.strb.Clear()
					Dim dataTable As DataTable = New DataTable()
					dataTable = clsfun.ExecDataTable("Select c2,FtpUrl,FtpUser,FtpPassword,WebUrl from FTP_Category where c2='Enabled'")
					Dim text As String = dataTable.Rows(0)("WebUrl").ToString() + "/api/get-order?"
					Me.strb.Append(text)
					Dim checked As Boolean = Me.RadioButton1.Checked
					Dim text2 As String
					If checked Then
						text2 = Me.RadioButton1.Text
					End If
					Me.btnEcomPost.Enabled = False
					Me.btnCancle.Enabled = False
					Me.strb.Append("type=" + text2)
					Dim text3 As String = Me.strb.ToString().Trim()
					Dim webRequest As WebRequest = WebRequest.Create(text3)
					Dim httpWebRequest As HttpWebRequest = CType(webRequest, HttpWebRequest)
					httpWebRequest.Method = "GET"
					httpWebRequest.ContentType = "application/json"
					Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
					Using streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
						Dim text4 As String = streamReader.ReadToEnd()
						Dim bytes As Byte() = Encoding.UTF8.GetBytes(text4)
						Dim memoryStream As MemoryStream = New MemoryStream(bytes)
						Dim dataContractJsonSerializer As DataContractJsonSerializer = New DataContractJsonSerializer(GetType(mOrder))
						Me.json = CType(dataContractJsonSerializer.ReadObject(memoryStream), mOrder)
						Dim success As Boolean = Me.json.success
						If success Then
							Me.dgw.Rows.Clear()
							Dim num As Integer = Me.json.records.Count() - 1
							For i As Integer = 0 To num
								Me.rec = Me.json.records(i)
								Me.UPDATESTATUS(CInt(Math.Round(Conversion.Val(Me.rec.id))))
							Next
						End If
					End Using
					Dim success2 As Boolean = Me.json.success
					If success2 Then
						Dim num2 As Integer = Me.json.records.Count() - 1
						For j As Integer = 0 To num2
							Me.rec = Me.json.records(j)
							ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
							ModCommonClasses.con1.Open()
							Dim text5 As String = "select RTRIM(OID) from orders where OID=@dx"
							ModCommonClasses.cmd1 = New SqlCommand(text5)
							ModCommonClasses.cmd1.Parameters.AddWithValue("@dx", Me.rec.oid)
							ModCommonClasses.cmd1.Connection = ModCommonClasses.con1
							ModCommonClasses.rdr1 = ModCommonClasses.cmd1.ExecuteReader()
							Dim flag2 As Boolean = ModCommonClasses.rdr1.Read()
							If flag2 Then
								MessageBox.Show("OID already available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag3 As Boolean = ModCommonClasses.rdr1 IsNot Nothing
								If flag3 Then
									ModCommonClasses.rdr1.Close()
								End If
							Else
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text6 As String = "insert into orders(ID, OID, UID, PName, PID, PType, PPrice, DDate, TimeSlot, Order_Date, Status, Qty, Total, Rate, P_Method, RID, A_Status, R_Status, Pickup, Tax, Address_ID, TID) VALUES (@d1,@d2,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d22,@d23,@d24,@d25,@d26)"
								ModCommonClasses.cmd = New SqlCommand(text6)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Prepare()
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.rec.id))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.rec.oid)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.rec.uid))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.rec.pname)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.rec.pid)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.rec.ptype)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.rec.pprice)
								Me.inputString = Me.rec.ddate
								Dim flag4 As Boolean = Me.inputString.StartsWith("--")
								If flag4 Then
									Me.datePart = Me.inputString.Substring(2)
									Dim flag5 As Boolean = DateTime.TryParseExact(Me.datePart, "dd-MM-yyyy", Nothing, DateTimeStyles.None, Me.parsedDate)
									If flag5 Then
										Me.outputString = Me.parsedDate.ToString("yyyy-MM-dd")
									Else
										Me.outputString = "Invalid date format"
									End If
									ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.outputString)
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.rec.ddate)
								End If
								ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.rec.timesloat)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.rec.order_date)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.rec.status)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.rec.qty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(Me.rec.total))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Conversion.Val(Me.rec.rate))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Me.rec.p_method)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Conversion.Val(Me.rec.rid))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(Me.rec.a_status))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Me.rec.r_status)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d23", Me.rec.pickup)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d24", Conversion.Val(Me.rec.tax))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d25", Conversion.Val(Me.rec.address_id))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d26", Me.rec.tid)
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.cmd.Parameters.Clear()
								ModCommonClasses.con.Close()
							End If
						Next
					End If
					Me.BindGrid("pending")
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		' Token: 0x060011B2 RID: 4530 RVA: 0x000C7208 File Offset: 0x000C5408
		Public Sub UPDATESTATUS(myid As Integer)
			Try
				Dim stringBuilder As StringBuilder = New StringBuilder()
				stringBuilder.Clear()
				Dim text As String = Conversions.ToString(myid)
				Dim text2 As String = "completed"
				Dim dataTable As DataTable = New DataTable()
				dataTable = clsfun.ExecDataTable("Select c2,FtpUrl,FtpUser,FtpPassword,WebUrl from FTP_Category where c2='Enabled'")
				Dim text3 As String = dataTable.Rows(0)("WebUrl").ToString() + "/api/OrderStatus?"
				stringBuilder.Append(text3)
				stringBuilder.Append("id=" + text)
				stringBuilder.Append("&status=" + text2)
				Dim text4 As String = stringBuilder.ToString().Trim()
				Dim webRequest As WebRequest = WebRequest.Create(text4)
				Dim httpWebRequest As HttpWebRequest = CType(webRequest, HttpWebRequest)
				httpWebRequest.Method = "GET"
				httpWebRequest.ContentType = "application/json"
				Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
				Using streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
					Dim text5 As String = streamReader.ReadToEnd()
				End Using
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060011B3 RID: 4531 RVA: 0x000C7340 File Offset: 0x000C5540
		Private Sub BindGrid(strStatus As String)
			' The following expression was wrapped in a checked-statement
			Try
				Dim text As String = "SELECT * FROM orders where status = @status order by id"
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, ModCS.cs)
				sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@status", strStatus)
				Dim dataTable As DataTable = New DataTable()
				sqlDataAdapter.Fill(dataTable)
				Me.dgw.Rows.Clear()
				Dim flag As Boolean = dataTable.Rows.Count > 0
				If flag Then
					Dim num As Integer = dataTable.Rows.Count - 1
					For i As Integer = 0 To num
						Me.dgw.Rows.Add(New Object() { dataTable.Rows(i)("id"), dataTable.Rows(i)("oid"), dataTable.Rows(i)("order_date") })
					Next
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060011B4 RID: 4532 RVA: 0x000C746C File Offset: 0x000C566C
		Public Sub Reset()
			Me.txtOrderId.Text = ""
			Me.txtOrderNo.Text = ""
			Me.txtOrderStatus.Text = ""
			Me.txtCustomerID.Text = ""
			Me.cmbCustomerName.Text = ""
			Me.txtAddress.Text = ""
			Me.txtZipCode.Text = ""
			Me.txtEmailID.Text = ""
			Me.txtCity.Text = ""
			Me.txtContactNo.Text = ""
			Me.txtPaymentMode.Text = ""
			Me.txtOdate.Text = ""
			Me.txtDdate.Text = ""
			Me.txtDtime.Text = ""
			Me.txtSubTotal.Text = ""
			Me.txtDCharg.Text = ""
			Me.txtGrandTotal.Text = ""
			Me.DataGridView1.Rows.Clear()
			Me.dgw.Rows.Clear()
			Me.btnEcomPost.Enabled = False
			Me.btnCancle.Enabled = False
		End Sub

		' Token: 0x060011B5 RID: 4533 RVA: 0x000C75D8 File Offset: 0x000C57D8
		Private Sub displayUser(uid As String)
			' The following expression was wrapped in a checked-statement
			Try
				Me.strb.Clear()
				Dim dataTable As DataTable = New DataTable()
				dataTable = clsfun.ExecDataTable("Select c2,FtpUrl,FtpUser,FtpPassword,WebUrl from FTP_Category where c2='Enabled'")
				Dim text As String = dataTable.Rows(0)("WebUrl").ToString() + "/api/get-user?"
				Me.strb.Append(text)
				Me.strb.Append("uid=" + uid)
				Dim text2 As String = Me.strb.ToString().Trim()
				Dim webRequest As WebRequest = WebRequest.Create(text2)
				Dim httpWebRequest As HttpWebRequest = CType(webRequest, HttpWebRequest)
				httpWebRequest.Method = "GET"
				httpWebRequest.ContentType = "application/json"
				Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
				Using streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
					Dim text3 As String = streamReader.ReadToEnd()
					Dim bytes As Byte() = Encoding.UTF8.GetBytes(text3)
					Dim memoryStream As MemoryStream = New MemoryStream(bytes)
					Dim dataContractJsonSerializer As DataContractJsonSerializer = New DataContractJsonSerializer(GetType(mUser))
					Me.ujson = CType(dataContractJsonSerializer.ReadObject(memoryStream), mUser)
					Dim success As Boolean = Me.ujson.success
					If success Then
						Dim uRecord As uRecord = New uRecord()
						Dim num As Integer = Me.ujson.records.Count() - 1
						For i As Integer = 0 To num
							uRecord = Me.ujson.records(i)
							Me.txtCustomerID.Text = uRecord.id
							Me.cmbCustomerName.Text = uRecord.name
							Me.txtCity.Text = uRecord.city
							Me.txtAddress.Text = uRecord.full_add
							Me.txtZipCode.Text = uRecord.pincode
							Me.txtContactNo.Text = uRecord.mobile
							Me.txtEmailID.Text = uRecord.email
						Next
					End If
				End Using
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060011B6 RID: 4534 RVA: 0x000C7820 File Offset: 0x000C5A20
		Private Sub ShowDeliveryCharge(uid As String)
			' The following expression was wrapped in a checked-statement
			Try
				Me.strb.Clear()
				Dim dataTable As DataTable = New DataTable()
				dataTable = clsfun.ExecDataTable("Select c2,FtpUrl,FtpUser,FtpPassword,WebUrl from FTP_Category where c2='Enabled'")
				Dim text As String = dataTable.Rows(0)("WebUrl").ToString() + "/api/get-dcharge?"
				Me.strb.Append(text)
				Me.strb.Append("uid=" + uid)
				Dim text2 As String = Me.strb.ToString().Trim()
				Dim webRequest As WebRequest = WebRequest.Create(text2)
				Dim httpWebRequest As HttpWebRequest = CType(webRequest, HttpWebRequest)
				httpWebRequest.Method = "GET"
				httpWebRequest.ContentType = "application/json"
				Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
				Using streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
					Dim text3 As String = streamReader.ReadToEnd()
					Dim bytes As Byte() = Encoding.UTF8.GetBytes(text3)
					Dim memoryStream As MemoryStream = New MemoryStream(bytes)
					Dim dataContractJsonSerializer As DataContractJsonSerializer = New DataContractJsonSerializer(GetType(mArea))
					Me.ajson = CType(dataContractJsonSerializer.ReadObject(memoryStream), mArea)
					Dim success As Boolean = Me.ajson.success
					If success Then
						Dim aRecord As aRecord = New aRecord()
						Dim num As Integer = Me.ajson.records.Count() - 1
						For i As Integer = 0 To num
							aRecord = Me.ajson.records(i)
							Me.txtDCharg.Text = aRecord.dcharge
						Next
					End If
				End Using
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060011B7 RID: 4535 RVA: 0x000C79EC File Offset: 0x000C5BEC
		Private Sub displaybarcode(uid As String)
			' The following expression was wrapped in a checked-statement
			Try
				Me.strb.Clear()
				Dim dataTable As DataTable = New DataTable()
				dataTable = clsfun.ExecDataTable("Select c2,FtpUrl,FtpUser,FtpPassword,WebUrl from FTP_Category where c2='Enabled'")
				Dim text As String = dataTable.Rows(0)("WebUrl").ToString() + "/api/get-product?"
				Me.strb.Append(text)
				Me.strb.Append("uid=" + uid)
				Dim text2 As String = Me.strb.ToString().Trim()
				Dim webRequest As WebRequest = WebRequest.Create(text2)
				Dim httpWebRequest As HttpWebRequest = CType(webRequest, HttpWebRequest)
				httpWebRequest.Method = "GET"
				httpWebRequest.ContentType = "application/json"
				Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
				Using streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
					Dim text3 As String = streamReader.ReadToEnd()
					Dim bytes As Byte() = Encoding.UTF8.GetBytes(text3)
					Dim memoryStream As MemoryStream = New MemoryStream(bytes)
					Dim dataContractJsonSerializer As DataContractJsonSerializer = New DataContractJsonSerializer(GetType(pProduct))
					Me.pjson = CType(dataContractJsonSerializer.ReadObject(memoryStream), pProduct)
					Dim success As Boolean = Me.pjson.success
					If success Then
						Dim pRecord As pRecord = New pRecord()
						Me.lstBarcode.Clear()
						Me.lstMRP.Clear()
						Dim num As Integer = Me.pjson.records.Count() - 1
						For i As Integer = 0 To num
							pRecord = Me.pjson.records(i)
							Me.lstBarcode.Add(pRecord.barcode + "$" + Conversions.ToString(pRecord.discount))
							Me.lstMRP.Add(pRecord.pprice)
						Next
					End If
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		' Token: 0x060011B8 RID: 4536 RVA: 0x000C7C08 File Offset: 0x000C5E08
		Private Sub dgw_CellClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = Me.dgw.SelectedRows.Count > 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con1.Open()
				Dim text As String = "select * from orders where id=@id"
				ModCommonClasses.cmd1 = New SqlCommand(text)
				ModCommonClasses.cmd1.Parameters.AddWithValue("@id", dataGridViewRow.Cells(0).Value.ToString())
				ModCommonClasses.cmd1.Connection = ModCommonClasses.con1
				ModCommonClasses.rdr1 = ModCommonClasses.cmd1.ExecuteReader()
				Dim flag2 As Boolean = ModCommonClasses.rdr1.Read()
				If flag2 Then
					Dim array As String() = CType(NewLateBinding.LateGet(ModCommonClasses.rdr1.GetValue(4), Nothing, "Split", New Object() { "$" }, Nothing, Nothing, Nothing), String())
					Dim array2 As String() = CType(NewLateBinding.LateGet(ModCommonClasses.rdr1.GetValue(3), Nothing, "Split", New Object() { "$" }, Nothing, Nothing, Nothing), String())
					Dim array3 As String() = CType(NewLateBinding.LateGet(ModCommonClasses.rdr1.GetValue(11), Nothing, "Split", New Object() { "$" }, Nothing, Nothing, Nothing), String())
					Dim array4 As String() = CType(NewLateBinding.LateGet(ModCommonClasses.rdr1.GetValue(5), Nothing, "Split", New Object() { "$" }, Nothing, Nothing, Nothing), String())
					Dim array5 As String() = CType(NewLateBinding.LateGet(ModCommonClasses.rdr1.GetValue(6), Nothing, "Split", New Object() { "$" }, Nothing, Nothing, Nothing), String())
					Dim text2 As String = Conversions.ToString(ModCommonClasses.rdr1.GetValue(2))
					Me.DataGridView1.Rows.Clear()
					Dim num As Integer = array.Count() - 1
					For i As Integer = 0 To num
						Dim text3 As String = array(i).Split(New Char() { ";"c }).Last().Trim()
						Me.displaybarcode(text3)
						Dim array6 As String() = Me.lstMRP.ToArray()
						Dim array7 As String() = Me.lstBarcode.ToArray()
						Dim text4 As String = array7(0).Split(New Char() { "$"c }).First()
						Dim text5 As String = array7(0).Split(New Char() { "$"c }).Last()
						Dim num2 As Integer = CInt(Math.Round(Conversion.Val(array3(i).Split(New Char() { ";"c }).Last().Trim())))
						Dim num3 As Integer = CInt(Math.Round(Conversion.Val(array5(i).Split(New Char() { ";"c }).Last().Trim())))
						Dim num4 As Integer = num2 * num3
						Me.DataGridView1.Rows.Add(New Object() { array(i).Split(New Char() { ";"c }).Last().Trim(), array2(i).Split(New Char() { ";"c }).Last(), text4, array6(0), text5, array3(i).Split(New Char() { ";"c }).Last().Trim(), array4(i).Split(New Char() { ";"c }).Last(), array5(i).Split(New Char() { ";"c }).Last().Trim(), num4 })
					Next
					Me.displayUser(text2)
					Me.ShowDeliveryCharge(Me.txtZipCode.Text)
					Me.txtOrderId.Text = Conversions.ToString(ModCommonClasses.rdr1.GetValue(0))
					Me.txtOrderNo.Text = Conversions.ToString(ModCommonClasses.rdr1.GetValue(1))
					Me.txtOrderStatus.Text = Conversions.ToString(ModCommonClasses.rdr1.GetValue(10))
					Me.txtPaymentMode.Text = Conversions.ToString(ModCommonClasses.rdr1.GetValue(14))
					Me.txtDdate.Text = Conversions.ToString(ModCommonClasses.rdr1.GetValue(7))
					Me.txtDtime.Text = Conversions.ToString(ModCommonClasses.rdr1.GetValue(8))
					Me.txtOdate.Text = Conversions.ToString(ModCommonClasses.rdr1.GetValue(9))
					Me.txtGrandTotal.Text = Conversions.ToString(ModCommonClasses.rdr1.GetValue(12))
					Dim num5 As Integer = CInt(Math.Round(Conversion.Val(Me.txtGrandTotal.Text)))
					Dim num6 As Integer = CInt(Math.Round(Conversion.Val(Me.txtDCharg.Text)))
					Dim num7 As Integer = num5 - num6
					Me.txtSubTotal.Text = Conversions.ToString(num7)
					Dim checked As Boolean = Me.RadioButton1.Checked
					If checked Then
						Me.btnEcomPost.Enabled = True
						Me.btnCancle.Enabled = True
					Else
						Dim checked2 As Boolean = Me.RadioButton2.Checked
						If checked2 Then
							Me.btnEcomPost.Enabled = False
							Me.btnCancle.Enabled = False
						Else
							Dim checked3 As Boolean = Me.RadioButton3.Checked
							If checked3 Then
								Me.btnEcomPost.Enabled = False
								Me.btnCancle.Enabled = False
							End If
						End If
					End If
					Dim flag3 As Boolean = ModCommonClasses.rdr1 IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr1.Close()
					End If
				End If
			End If
		End Sub

		' Token: 0x060011B9 RID: 4537 RVA: 0x000C8190 File Offset: 0x000C6390
		Private Sub btnEcomPost_Click(sender As Object, e As EventArgs)
			Dim num As Integer = clsfun.ExecScalarInt("Select TOP 30 count(1) from Customer where ContactNo  = '" + Me.txtContactNo.Text + "'")
			Dim flag As Boolean = num > 0
			If flag Then
				MyProject.Forms.frmPOSTouch.Show()
				MyBase.Hide()
				Me.GetDefaultCustomer()
				MyProject.Forms.frmPOSTouch.lblUser.Text = Me.lblUser.Text
				MyProject.Forms.frmPOSTouch.txtOrderId.Text = Me.txtOrderId.Text
				MyProject.Forms.frmPOSTouch.txtOrderNo.Text = Me.txtOrderNo.Text
				MyProject.Forms.frmPOSTouch.txtOrderStatus.Text = Me.txtOrderStatus.Text
				MyProject.Forms.frmPOSTouch.txtFreightCharges.Text = Me.txtDCharg.Text
				MyProject.Forms.frmPOSTouch.txtPaymentMode.Text = Me.txtPaymentMode.Text
				MyProject.Forms.frmPOSTouch.txtOdate.Text = Me.txtOdate.Text
				MyProject.Forms.frmPOSTouch.txtDdate.Text = Me.txtDdate.Text
				MyProject.Forms.frmPOSTouch.txtDtime.Text = Me.txtDtime.Text
				MyProject.Forms.frmPOSTouch.TextBox24.Text = Me.txtSubTotal.Text
				MyProject.Forms.frmPOSTouch.txtDCharg.Text = Me.txtDCharg.Text
				MyProject.Forms.frmPOSTouch.TextBox23.Text = Me.txtGrandTotal.Text
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						MyProject.Forms.frmPOSTouch.txtQty.Text = Conversions.ToString(dataGridViewRow.Cells(5).Value)
						MyProject.Forms.frmPOSTouch.txtBarcode.Text = Conversions.ToString(dataGridViewRow.Cells(2).Value)
						MyProject.Forms.frmPOSTouch.txtBarcode_KeyDownCustom()
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				MyProject.Forms.frmCustomer.Reset()
				MyProject.Forms.frmCustomer.lblUser.Text = Me.lblUser.Text
				MyProject.Forms.frmCustomer.cmbCustomerName.Text = Me.cmbCustomerName.Text
				MyProject.Forms.frmCustomer.txtContactNo.Text = Me.txtContactNo.Text
				MyProject.Forms.frmCustomer.txtCity.Text = Me.txtCity.Text
				MyProject.Forms.frmCustomer.txtAddress.Text = Me.txtAddress.Text
				MyProject.Forms.frmCustomer.txtZipCode.Text = Me.txtZipCode.Text
				MyProject.Forms.frmCustomer.txtEmailID.Text = Me.txtEmailID.Text
				MyProject.Forms.frmCustomer.Label19.Text = "Y"
				MyProject.Forms.frmCustomer.ShowDialog()
			End If
		End Sub

		' Token: 0x060011BA RID: 4538 RVA: 0x000C8544 File Offset: 0x000C6744
		Public Sub GetDefaultCustomer()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT Top 1 ID, CustomerID,RTRIM(ContactNo),RTRIM(State),RTRIM(GSTIN),RTRIM(Name),RTRIM(EmailID),RTRIM(PAN),RTRIM(Tcs),RTRIM(CardNo),RTRIM(Status),RTRIM(Address) from Customer where ContactNo = '" + Me.txtContactNo.Text + "' order by 1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					MyProject.Forms.frmPOSTouch.txtCID.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Dim text2 As String = ModCommonClasses.rdr.GetValue(1).ToString().Trim()
					MyProject.Forms.frmPOSTouch.txtCustomerID.Text = text2
					MyProject.Forms.frmPOSTouch.txtContactNo.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					MyProject.Forms.frmPOSTouch.CAddress = Conversions.ToString(ModCommonClasses.rdr.GetValue(11))
					MyProject.Forms.frmPOSTouch.cmbCustomerState.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(3))
					MyProject.Forms.frmPOSTouch.txtGSTIN.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(4))
					MyProject.Forms.frmPOSTouch.cmbCustomerName.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(5))
					MyProject.Forms.frmPOSTouch.textmailid.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(6))
					MyProject.Forms.frmPOSTouch.txtPan.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(7))
					MyProject.Forms.frmPOSTouch.txtTCSstatus.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(8))
					MyProject.Forms.frmPOSTouch.lblcard.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(9))
					MyProject.Forms.frmPOSTouch.txtLStatus.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(10))
				End If
				ModCommonClasses.con.Close()
				MyProject.Forms.frmPOSTouch.GetCustomerBalance()
				MyProject.Forms.frmPOSTouch.GetCustomerBalanceforTCS()
				MyProject.Forms.frmPOSTouch.Calculate12345()
				MyProject.Forms.frmPOSTouch.Calculate143()
				MyProject.Forms.frmPOSTouch.tcsconn()
				MyProject.Forms.frmPOSTouch.InvoiceTCSinfo()
				MyProject.Forms.frmPOSTouch.tcsconn1()
				Dim flag2 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSTouch.txtLStatus.Text, "Activated", False) = 0
				If flag2 Then
					MyProject.Forms.frmPOSTouch.usepoint()
				Else
					MyProject.Forms.frmPOSTouch.txtusepoint.Text = Conversions.ToString(0)
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060011BB RID: 4539 RVA: 0x000C8888 File Offset: 0x000C6A88
		Private Sub GelButton10_Click(sender As Object, e As EventArgs)
			Dim stringBuilder As StringBuilder = New StringBuilder()
			stringBuilder.Clear()
			Dim text As String = Me.txtOrderId.Text
			Dim text2 As String = Me.txtOrderNo.Text
			Dim text3 As String = "cancelled"
			Dim dataTable As DataTable = New DataTable()
			dataTable = clsfun.ExecDataTable("Select c2,FtpUrl,FtpUser,FtpPassword,WebUrl from FTP_Category where c2='Enabled'")
			Dim text4 As String = dataTable.Rows(0)("WebUrl").ToString() + "/api/OrderStatus?"
			stringBuilder.Append(text4)
			stringBuilder.Append("id=" + text)
			stringBuilder.Append("&status=" + text3)
			Dim text5 As String = stringBuilder.ToString().Trim()
			Dim webRequest As WebRequest = WebRequest.Create(text5)
			Dim httpWebRequest As HttpWebRequest = CType(webRequest, HttpWebRequest)
			httpWebRequest.Method = "GET"
			httpWebRequest.ContentType = "application/json"
			Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
			Using streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
				Dim text6 As String = streamReader.ReadToEnd()
				MessageBox.Show(text6)
				Me.OrderSearch()
			End Using
		End Sub

		' Token: 0x060011BC RID: 4540 RVA: 0x0000FA8C File Offset: 0x0000DC8C
		Private Sub frmOrder_Load(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Convert_Language()
		End Sub

		' Token: 0x060011BD RID: 4541 RVA: 0x000C89C0 File Offset: 0x000C6BC0
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

		' Token: 0x060011BE RID: 4542 RVA: 0x000C8B38 File Offset: 0x000C6D38
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

		' Token: 0x060011BF RID: 4543 RVA: 0x000C8BF4 File Offset: 0x000C6DF4
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

		' Token: 0x060011C0 RID: 4544 RVA: 0x000B726C File Offset: 0x000B546C
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

		' Token: 0x060011C1 RID: 4545 RVA: 0x000B72F4 File Offset: 0x000B54F4
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

		' Token: 0x04000578 RID: 1400
		Private json As mOrder

		' Token: 0x04000579 RID: 1401
		Private ujson As mUser

		' Token: 0x0400057A RID: 1402
		Private pjson As pProduct

		' Token: 0x0400057B RID: 1403
		Private ajson As mArea

		' Token: 0x0400057C RID: 1404
		Private lblType As String

		' Token: 0x0400057D RID: 1405
		Private rec As Record

		' Token: 0x0400057E RID: 1406
		Private inputString As String

		' Token: 0x0400057F RID: 1407
		Private outputString As String

		' Token: 0x04000580 RID: 1408
		Private datePart As String

		' Token: 0x04000581 RID: 1409
		Private parsedDate As DateTime

		' Token: 0x04000582 RID: 1410
		Private strb As StringBuilder

		' Token: 0x04000583 RID: 1411
		Private lstBarcode As List(Of String)

		' Token: 0x04000584 RID: 1412
		Private lstMRP As List(Of String)
	End Class
End Namespace
