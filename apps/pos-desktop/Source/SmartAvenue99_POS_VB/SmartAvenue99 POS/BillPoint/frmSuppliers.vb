Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000B8 RID: 184
	<DesignerGenerated()>
	Public Partial Class frmSuppliers
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001A5E RID: 6750 RVA: 0x00013BAC File Offset: 0x00011DAC
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBulkPriceChange_Load
			Me.prevCell = Nothing
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000A47 RID: 2631
		' (get) Token: 0x06001A61 RID: 6753 RVA: 0x00013BD6 File Offset: 0x00011DD6
		' (set) Token: 0x06001A62 RID: 6754 RVA: 0x001227D8 File Offset: 0x001209D8
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewEditingControlShowingEventHandler As DataGridViewEditingControlShowingEventHandler = AddressOf Me.dgw_EditingControlShowing
				Dim eventHandler As EventHandler = AddressOf Me.dgw_CurrentCellChanged
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellContentClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
					RemoveHandler dataGridView.CurrentCellChanged, eventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
					AddHandler dataGridView.CurrentCellChanged, eventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A48 RID: 2632
		' (get) Token: 0x06001A63 RID: 6755 RVA: 0x00013BE0 File Offset: 0x00011DE0
		' (set) Token: 0x06001A64 RID: 6756 RVA: 0x00013BEA File Offset: 0x00011DEA
		Public Overridable Property Photo As PictureBox

		' Token: 0x17000A49 RID: 2633
		' (get) Token: 0x06001A65 RID: 6757 RVA: 0x00013BF3 File Offset: 0x00011DF3
		' (set) Token: 0x06001A66 RID: 6758 RVA: 0x00013BFD File Offset: 0x00011DFD
		Public Overridable Property pbgiftqr As PictureBox

		' Token: 0x17000A4A RID: 2634
		' (get) Token: 0x06001A67 RID: 6759 RVA: 0x00013C06 File Offset: 0x00011E06
		' (set) Token: 0x06001A68 RID: 6760 RVA: 0x00013C10 File Offset: 0x00011E10
		Friend Overridable Property lblUser As Label

		' Token: 0x17000A4B RID: 2635
		' (get) Token: 0x06001A69 RID: 6761 RVA: 0x00013C19 File Offset: 0x00011E19
		' (set) Token: 0x06001A6A RID: 6762 RVA: 0x00013C23 File Offset: 0x00011E23
		Friend Overridable Property lblUserType As Label

		' Token: 0x17000A4C RID: 2636
		' (get) Token: 0x06001A6B RID: 6763 RVA: 0x00013C2C File Offset: 0x00011E2C
		' (set) Token: 0x06001A6C RID: 6764 RVA: 0x00122854 File Offset: 0x00120A54
		Private _btnNewSupplier As Button
		Friend Overridable Property btnNewSupplier As Button
			<CompilerGenerated()>
			Get
				Return Me._btnNewSupplier
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButtonNewRecord_Click
				Dim button As Button = Me._btnNewSupplier
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnNewSupplier = value
				button = Me._btnNewSupplier
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A4D RID: 2637
		' (get) Token: 0x06001A6D RID: 6765 RVA: 0x00013C36 File Offset: 0x00011E36
		' (set) Token: 0x06001A6E RID: 6766 RVA: 0x00013C40 File Offset: 0x00011E40
		Friend Overridable Property lblCPhone As Label

		' Token: 0x17000A4E RID: 2638
		' (get) Token: 0x06001A6F RID: 6767 RVA: 0x00013C49 File Offset: 0x00011E49
		' (set) Token: 0x06001A70 RID: 6768 RVA: 0x00013C53 File Offset: 0x00011E53
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17000A4F RID: 2639
		' (get) Token: 0x06001A71 RID: 6769 RVA: 0x00013C5C File Offset: 0x00011E5C
		' (set) Token: 0x06001A72 RID: 6770 RVA: 0x00013C66 File Offset: 0x00011E66
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17000A50 RID: 2640
		' (get) Token: 0x06001A73 RID: 6771 RVA: 0x00013C6F File Offset: 0x00011E6F
		' (set) Token: 0x06001A74 RID: 6772 RVA: 0x00013C79 File Offset: 0x00011E79
		Friend Overridable Property Label17 As Label

		' Token: 0x17000A51 RID: 2641
		' (get) Token: 0x06001A75 RID: 6773 RVA: 0x00013C82 File Offset: 0x00011E82
		' (set) Token: 0x06001A76 RID: 6774 RVA: 0x00013C8C File Offset: 0x00011E8C
		Friend Overridable Property Panel7 As Panel

		' Token: 0x17000A52 RID: 2642
		' (get) Token: 0x06001A77 RID: 6775 RVA: 0x00013C95 File Offset: 0x00011E95
		' (set) Token: 0x06001A78 RID: 6776 RVA: 0x00013C9F File Offset: 0x00011E9F
		Friend Overridable Property Label19 As Label

		' Token: 0x17000A53 RID: 2643
		' (get) Token: 0x06001A79 RID: 6777 RVA: 0x00013CA8 File Offset: 0x00011EA8
		' (set) Token: 0x06001A7A RID: 6778 RVA: 0x00122898 File Offset: 0x00120A98
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

		' Token: 0x17000A54 RID: 2644
		' (get) Token: 0x06001A7B RID: 6779 RVA: 0x00013CB2 File Offset: 0x00011EB2
		' (set) Token: 0x06001A7C RID: 6780 RVA: 0x00013CBC File Offset: 0x00011EBC
		Friend Overridable Property Label18 As Label

		' Token: 0x17000A55 RID: 2645
		' (get) Token: 0x06001A7D RID: 6781 RVA: 0x00013CC5 File Offset: 0x00011EC5
		' (set) Token: 0x06001A7E RID: 6782 RVA: 0x00013CCF File Offset: 0x00011ECF
		Friend Overridable Property Label21 As Label

		' Token: 0x17000A56 RID: 2646
		' (get) Token: 0x06001A7F RID: 6783 RVA: 0x00013CD8 File Offset: 0x00011ED8
		' (set) Token: 0x06001A80 RID: 6784 RVA: 0x001228DC File Offset: 0x00120ADC
		Private _txtTopResult As TextBox
		Friend Overridable Property txtTopResult As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtTopResult
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtTopResult_TextChanged
				Dim textBox As TextBox = Me._txtTopResult
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtTopResult = value
				textBox = Me._txtTopResult
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A57 RID: 2647
		' (get) Token: 0x06001A81 RID: 6785 RVA: 0x00013CE2 File Offset: 0x00011EE2
		' (set) Token: 0x06001A82 RID: 6786 RVA: 0x00122920 File Offset: 0x00120B20
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

		' Token: 0x17000A58 RID: 2648
		' (get) Token: 0x06001A83 RID: 6787 RVA: 0x00013CEC File Offset: 0x00011EEC
		' (set) Token: 0x06001A84 RID: 6788 RVA: 0x00013CF6 File Offset: 0x00011EF6
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17000A59 RID: 2649
		' (get) Token: 0x06001A85 RID: 6789 RVA: 0x00013CFF File Offset: 0x00011EFF
		' (set) Token: 0x06001A86 RID: 6790 RVA: 0x00013D09 File Offset: 0x00011F09
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000A5A RID: 2650
		' (get) Token: 0x06001A87 RID: 6791 RVA: 0x00013D12 File Offset: 0x00011F12
		' (set) Token: 0x06001A88 RID: 6792 RVA: 0x00013D1C File Offset: 0x00011F1C
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17000A5B RID: 2651
		' (get) Token: 0x06001A89 RID: 6793 RVA: 0x00013D25 File Offset: 0x00011F25
		' (set) Token: 0x06001A8A RID: 6794 RVA: 0x00013D2F File Offset: 0x00011F2F
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17000A5C RID: 2652
		' (get) Token: 0x06001A8B RID: 6795 RVA: 0x00013D38 File Offset: 0x00011F38
		' (set) Token: 0x06001A8C RID: 6796 RVA: 0x00013D42 File Offset: 0x00011F42
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000A5D RID: 2653
		' (get) Token: 0x06001A8D RID: 6797 RVA: 0x00013D4B File Offset: 0x00011F4B
		' (set) Token: 0x06001A8E RID: 6798 RVA: 0x00013D55 File Offset: 0x00011F55
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17000A5E RID: 2654
		' (get) Token: 0x06001A8F RID: 6799 RVA: 0x00013D5E File Offset: 0x00011F5E
		' (set) Token: 0x06001A90 RID: 6800 RVA: 0x00013D68 File Offset: 0x00011F68
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17000A5F RID: 2655
		' (get) Token: 0x06001A91 RID: 6801 RVA: 0x00013D71 File Offset: 0x00011F71
		' (set) Token: 0x06001A92 RID: 6802 RVA: 0x00013D7B File Offset: 0x00011F7B
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17000A60 RID: 2656
		' (get) Token: 0x06001A93 RID: 6803 RVA: 0x00013D84 File Offset: 0x00011F84
		' (set) Token: 0x06001A94 RID: 6804 RVA: 0x00013D8E File Offset: 0x00011F8E
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17000A61 RID: 2657
		' (get) Token: 0x06001A95 RID: 6805 RVA: 0x00013D97 File Offset: 0x00011F97
		' (set) Token: 0x06001A96 RID: 6806 RVA: 0x00013DA1 File Offset: 0x00011FA1
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17000A62 RID: 2658
		' (get) Token: 0x06001A97 RID: 6807 RVA: 0x00013DAA File Offset: 0x00011FAA
		' (set) Token: 0x06001A98 RID: 6808 RVA: 0x00013DB4 File Offset: 0x00011FB4
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17000A63 RID: 2659
		' (get) Token: 0x06001A99 RID: 6809 RVA: 0x00013DBD File Offset: 0x00011FBD
		' (set) Token: 0x06001A9A RID: 6810 RVA: 0x00013DC7 File Offset: 0x00011FC7
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17000A64 RID: 2660
		' (get) Token: 0x06001A9B RID: 6811 RVA: 0x00013DD0 File Offset: 0x00011FD0
		' (set) Token: 0x06001A9C RID: 6812 RVA: 0x00013DDA File Offset: 0x00011FDA
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17000A65 RID: 2661
		' (get) Token: 0x06001A9D RID: 6813 RVA: 0x00013DE3 File Offset: 0x00011FE3
		' (set) Token: 0x06001A9E RID: 6814 RVA: 0x00013DED File Offset: 0x00011FED
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17000A66 RID: 2662
		' (get) Token: 0x06001A9F RID: 6815 RVA: 0x00013DF6 File Offset: 0x00011FF6
		' (set) Token: 0x06001AA0 RID: 6816 RVA: 0x00013E00 File Offset: 0x00012000
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17000A67 RID: 2663
		' (get) Token: 0x06001AA1 RID: 6817 RVA: 0x00013E09 File Offset: 0x00012009
		' (set) Token: 0x06001AA2 RID: 6818 RVA: 0x00013E13 File Offset: 0x00012013
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17000A68 RID: 2664
		' (get) Token: 0x06001AA3 RID: 6819 RVA: 0x00013E1C File Offset: 0x0001201C
		' (set) Token: 0x06001AA4 RID: 6820 RVA: 0x00013E26 File Offset: 0x00012026
		Friend Overridable Property btnAction As DataGridViewButtonColumn

		' Token: 0x17000A69 RID: 2665
		' (get) Token: 0x06001AA5 RID: 6821 RVA: 0x00013E2F File Offset: 0x0001202F
		' (set) Token: 0x06001AA6 RID: 6822 RVA: 0x00122964 File Offset: 0x00120B64
		Private _txtSearchProduct As TextBox
		Friend Overridable Property txtSearchProduct As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSearchProduct
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSearchProduct_TextChanged
				Dim textBox As TextBox = Me._txtSearchProduct
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSearchProduct = value
				textBox = Me._txtSearchProduct
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A6A RID: 2666
		' (get) Token: 0x06001AA7 RID: 6823 RVA: 0x00013E39 File Offset: 0x00012039
		' (set) Token: 0x06001AA8 RID: 6824 RVA: 0x001229A8 File Offset: 0x00120BA8
		Private _cmbSearchCat As ComboBox
		Friend Overridable Property cmbSearchCat As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbSearchCat
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbSearchCat_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbSearchCat
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbSearchCat = value
				comboBox = Me._cmbSearchCat
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A6B RID: 2667
		' (get) Token: 0x06001AA9 RID: 6825 RVA: 0x00013E43 File Offset: 0x00012043
		' (set) Token: 0x06001AAA RID: 6826 RVA: 0x00013E4D File Offset: 0x0001204D
		Friend Overridable Property Label1 As Label

		' Token: 0x06001AAB RID: 6827 RVA: 0x00013E56 File Offset: 0x00012056
		Private Sub frmBulkPriceChange_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			MyBase.KeyPreview = True
		End Sub

		' Token: 0x06001AAC RID: 6828 RVA: 0x001229EC File Offset: 0x00120BEC
		Public Sub Getdata()
			Try
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Format("select top {0} ID, RTrim(SupplierID), SCode, RTrim([Name]), RTrim(Address), RTrim(City), RTrim(State),RTrim(ZipCode),RTrim(ContactNo), RTrim(EmailID),RTrim(GSTIN),RTrim(CIN),RTrim(PAN), RTrim(OpeningBalance) + ' ' + RTRIM(isnull(openingbalancetype,'Cr')), RTrim(Remarks),RTrim(Limit) from Supplier where Lstatus= 'Yes' order by id desc", Me.txtTopResult.Text), ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim num As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15) })
					Me.dgw.Rows(num).Cells(16).Value = "Update"
				End While
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
				Dim flag As Boolean = Me.dgw.RowCount > 0
				If flag Then
					Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(3)
				End If
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001AAD RID: 6829 RVA: 0x00122C68 File Offset: 0x00120E68
		Private Sub dgw_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
			Dim list As List(Of Short) = New List(Of Short)(New Short() { 7S, 8S, 13S, 15S })
			Dim textBox As TextBox = TryCast(e.Control, TextBox)
			Dim flag As Boolean = textBox IsNot Nothing
			If flag Then
				RemoveHandler textBox.KeyPress, AddressOf Me.NumericDecimal_KeyPress
				Dim flag2 As Boolean = list.Contains(CShort(Me.dgw.CurrentCell.ColumnIndex))
				If flag2 Then
					AddHandler textBox.KeyPress, AddressOf Me.NumericDecimal_KeyPress
				End If
			End If
		End Sub

		' Token: 0x06001AAE RID: 6830 RVA: 0x0011AF1C File Offset: 0x0011911C
		Private Sub NumericDecimal_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim textBox As TextBox = CType(sender, TextBox)
			Dim flag As Boolean = Char.IsControl(e.KeyChar)
			If Not flag Then
				Dim flag2 As Boolean = e.KeyChar = "."c
				If flag2 Then
					Dim flag3 As Boolean = textBox.Text.Contains(".")
					If flag3 Then
						e.Handled = True
					End If
				Else
					Dim flag4 As Boolean = Not Char.IsDigit(e.KeyChar)
					If flag4 Then
						e.Handled = True
					End If
				End If
			End If
		End Sub

		' Token: 0x06001AAF RID: 6831 RVA: 0x00122CE8 File Offset: 0x00120EE8
		Private Sub dgw_CurrentCellChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.prevCell IsNot Nothing
			If flag Then
				Me.prevCell.Style.BackColor = Color.White
			End If
			Dim flag2 As Boolean = Me.dgw.CurrentCell IsNot Nothing
			If flag2 Then
				Me.dgw.CurrentCell.Style.BackColor = Color.Yellow
				Me.prevCell = Me.dgw.CurrentCell
			End If
		End Sub

		' Token: 0x06001AB0 RID: 6832 RVA: 0x00122D5C File Offset: 0x00120F5C
		Public Function MoveToNextAndClear() As Boolean
			Me.dgw.BeginEdit(True)
			Me.dgw.ClearSelection()
			Dim textBox As TextBox = TryCast(Me.dgw.EditingControl, TextBox)
			Dim flag As Boolean = textBox IsNot Nothing
			If flag Then
				textBox.SelectionStart = 0
				textBox.SelectionLength = textBox.Text.Length
			End If
			Return True
		End Function

		' Token: 0x06001AB1 RID: 6833 RVA: 0x00122DC0 File Offset: 0x00120FC0
		Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
			Dim flag As Boolean = Not Me.txtSearchProduct.Focused And Not Me.txtTopResult.Focused
			If flag Then
				Dim flag2 As Boolean = keyData = Keys.[Return]
				If flag2 Then
					Me.dgw.ClearSelection()
					Dim num As Integer = 1
					Dim num2 As Integer = 1
					Dim flag3 As Boolean = Me.dgw.CurrentCell IsNot Nothing
					If flag3 Then
						Dim rowIndex As Integer = Me.dgw.CurrentCell.RowIndex
						Dim columnIndex As Integer = Me.dgw.CurrentCell.ColumnIndex
						Dim flag4 As Boolean = keyData = Keys.[Return] AndAlso Me.dgw.CurrentCell.ColumnIndex > 1 AndAlso Me.dgw.CurrentCell.ColumnIndex < 16
						If flag4 Then
							Dim flag5 As Boolean = Not Me.txtSearchProduct.Focused
							If flag5 Then
								Dim flag6 As Boolean = columnIndex = 6
								If flag6 Then
									Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(rowIndex)
									Dim text As String = ""
									Dim flag7 As Boolean = dataGridViewRow.Cells(6).Value IsNot Nothing
									If flag7 Then
										Dim value As Object = dataGridViewRow.Cells(6).Value
										text = If((value IsNot Nothing), value.ToString(), Nothing)
									End If
									MyProject.Forms.frmState.txtStateName.Text = text
									MyProject.Forms.frmState.currentRow = rowIndex
									MyProject.Forms.frmState.currentColumn = columnIndex
									MyProject.Forms.frmState.Owner = Me
									MyProject.Forms.frmState.ShowDialog()
									Return True
								End If
							End If
							Dim flag8 As Boolean = columnIndex = 13 AndAlso msg.Msg > 0
							If flag8 Then
								Me.dgw.EndEdit()
								Me.dgw.CommitEdit(DataGridViewDataErrorContexts.Commit)
								Me.dgw.Refresh()
								Dim dataGridViewRow2 As DataGridViewRow = Me.dgw.Rows(rowIndex)
								MyProject.Forms.frmCreditDebit.currentRow = rowIndex
								MyProject.Forms.frmCreditDebit.currentColumn = columnIndex
								MyProject.Forms.frmCreditDebit.Owner = Me
								MyProject.Forms.frmCreditDebit.ShowDialog()
								Return True
							End If
							Dim flag9 As Boolean = columnIndex < Me.dgw.Columns.Count
							If flag9 Then
								Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex).Cells(columnIndex + num)
							End If
							Return Me.MoveToNextAndClear()
						Else
							Dim flag10 As Boolean = keyData = Keys.[Return] AndAlso Me.dgw.CurrentCell.ColumnIndex = 16
							If flag10 Then
								Dim flag11 As Boolean = Operators.ConditionalCompareObjectGreaterEqual(Me.dgw.Rows(rowIndex).Cells(0).Value, 0, False)
								If Not flag11 Then
									Return True
								End If
								Dim flag12 As Boolean = False
								Me.InsertNewSupplier(rowIndex, columnIndex, flag12)
								Dim flag13 As Boolean = flag12
								If flag13 Then
									Dim flag14 As Boolean = rowIndex < Me.dgw.Rows.Count - 1
									If flag14 Then
										Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex + 1).Cells(3)
									Else
										Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(3)
									End If
									Return Me.MoveToNextAndClear()
								End If
								Return True
							Else
								Select Case keyData
									Case Keys.Left
										Dim flag15 As Boolean = columnIndex > 3
										If flag15 Then
											Dim flag16 As Boolean = Not Me.dgw.Rows(rowIndex).Cells(columnIndex - num2).Visible
											If flag16 Then
												num2 += 1
											End If
											Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex).Cells(columnIndex - num2)
										Else
											Dim flag17 As Boolean = columnIndex = 3
											If flag17 Then
												Dim flag18 As Boolean = rowIndex > 0
												If flag18 Then
													Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex - 1).Cells(15)
												Else
													Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex).Cells(3)
												End If
											End If
										End If
										Return Me.MoveToNextAndClear()
									Case Keys.Up
										Dim flag19 As Boolean = rowIndex > 0
										If flag19 Then
											Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex - 1).Cells(columnIndex)
											Return Me.MoveToNextAndClear()
										End If
									Case Keys.Right
										Dim flag20 As Boolean = columnIndex < 16
										If flag20 Then
											Dim flag21 As Boolean = Not Me.dgw.Rows(rowIndex).Cells(columnIndex + num).Visible
											If flag21 Then
												num += 1
											End If
											Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex).Cells(columnIndex + num)
										Else
											Dim flag22 As Boolean = columnIndex = 16
											If flag22 Then
												Dim flag23 As Boolean = rowIndex >= Me.dgw.Rows.Count - 1
												If flag23 Then
													Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(3)
												Else
													Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex + 1).Cells(3)
												End If
											End If
										End If
										Return Me.MoveToNextAndClear()
									Case Keys.Down
										Dim flag24 As Boolean = rowIndex < Me.dgw.Rows.Count - 1
										If flag24 Then
											Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex + 1).Cells(columnIndex)
											Return Me.MoveToNextAndClear()
										End If
								End Select
								If keyData <> Keys.[Return] AndAlso keyData - Keys.Left > 3 Then
								End If
								Dim flag25 As Boolean = Not Me.txtSearchProduct.Focused
								If flag25 Then
									Me.dgw.BeginEdit(True)
									Me.dgw.ClearSelection()
								End If
							End If
						End If
					End If
				End If
			Else
				Dim flag26 As Boolean = keyData = Keys.[Return]
				If flag26 Then
					Dim flag27 As Boolean = Me.dgw.RowCount > 0
					If flag27 Then
						Dim focused As Boolean = Me.txtSearchProduct.Focused
						If focused Then
							Dim flag28 As Boolean = Me.cmbSearchCat.SelectedIndex = 1
							If flag28 Then
								Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(8)
							Else
								Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(3)
							End If
						Else
							Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(3)
						End If
						Me.dgw.BeginEdit(True)
						Me.dgw.ClearSelection()
					End If
				End If
			End If
			Return MyBase.ProcessCmdKey(msg, keyData)
		End Function

		' Token: 0x06001AB2 RID: 6834 RVA: 0x00123564 File Offset: 0x00121764
		Private Sub AddNewRow()
			For Each row As DataGridViewRow In Me.dgw.Rows
				If row.Cells(0).Value IsNot Nothing AndAlso Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(0).Value)) = 0.0 Then
					MessageBox.Show("A new row already exists. Please save it before adding another.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Return
				End If
			Next
			Me.dgw.ClearSelection()
			Dim num As Integer = Me.dgw.Rows.Add()
			Dim newRow As DataGridViewRow = Me.dgw.Rows(num)
			newRow.Cells(0).Value = 0
			newRow.Cells(1).Value = ""
			newRow.Cells(2).Value = ""
			newRow.Cells(3).Value = ""
			newRow.Cells(4).Value = ""
			newRow.Cells(5).Value = ""
			newRow.Cells(6).Value = ""
			newRow.Cells(7).Value = ""
			newRow.Cells(8).Value = ""
			newRow.Cells(9).Value = ""
			newRow.Cells(10).Value = ""
			newRow.Cells(11).Value = ""
			newRow.Cells(12).Value = ""
			newRow.Cells(13).Value = "0.00"
			newRow.Cells(14).Value = ""
			newRow.Cells(15).Value = "0.00"
			newRow.Cells(16).Value = "Save"
			Me.dgw.ClearSelection()
			MyBase.BeginInvoke(New MethodInvoker(Sub()
				Me.dgw.Focus()
				Me.dgw.CurrentCell = newRow.Cells(3)
				Me.dgw.BeginEdit(True)
				Me.dgw.ClearSelection()
			End Sub))
		End Sub

		' Token: 0x06001AB3 RID: 6835 RVA: 0x00123868 File Offset: 0x00121A68
		Private Sub dgw_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim rowIndex As Integer = e.RowIndex
			Dim columnIndex As Integer = e.ColumnIndex
			Dim flag As Boolean = False
			Me.InsertNewSupplier(rowIndex, columnIndex, flag)
		End Sub

		' Token: 0x06001AB4 RID: 6836 RVA: 0x00123890 File Offset: 0x00121A90
		Public Sub SetFocustoCurrentCell(rowindex As Integer, colindex As Integer)
			MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
				Me.dgw.Focus()
				Me.dgw.CurrentCell = Me.dgw.Rows(rowindex).Cells(colindex)
				Me.dgw.BeginEdit(True)
				Me.dgw.ClearSelection()
			End Sub))
		End Sub

		' Token: 0x06001AB5 RID: 6837 RVA: 0x001238CC File Offset: 0x00121ACC
		Public Sub InsertNewSupplier(RowIndex As Integer, ColumnIndex As Integer, ByRef isUpdate As Boolean)
			Dim flag As Boolean = ColumnIndex = Me.dgw.Columns(16).Index AndAlso RowIndex >= 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(RowIndex)
				Dim obj As Object = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)
				Dim value As Object = dataGridViewRow.Cells(1).Value
				Dim text As String = If(If((value IsNot Nothing), value.ToString().Trim(), Nothing), "")
				Dim value2 As Object = dataGridViewRow.Cells(2).Value
				Dim text2 As String = If(If((value2 IsNot Nothing), value2.ToString().Trim(), Nothing), "")
				Dim value3 As Object = dataGridViewRow.Cells(3).Value
				Dim text3 As String = If(If((value3 IsNot Nothing), value3.ToString().Trim(), Nothing), "")
				Dim value4 As Object = dataGridViewRow.Cells(4).Value
				Dim text4 As String = If(If((value4 IsNot Nothing), value4.ToString().Trim(), Nothing), "")
				Dim value5 As Object = dataGridViewRow.Cells(5).Value
				Dim text5 As String = If(If((value5 IsNot Nothing), value5.ToString().Trim(), Nothing), "")
				Dim value6 As Object = dataGridViewRow.Cells(6).Value
				Dim text6 As String = If(If((value6 IsNot Nothing), value6.ToString().Trim(), Nothing), "")
				Dim value7 As Object = dataGridViewRow.Cells(7).Value
				Dim text7 As String = If(If((value7 IsNot Nothing), value7.ToString().Trim(), Nothing), "")
				Dim value8 As Object = dataGridViewRow.Cells(8).Value
				Dim text8 As String = If(If((value8 IsNot Nothing), value8.ToString().Trim(), Nothing), "")
				Dim value9 As Object = dataGridViewRow.Cells(9).Value
				Dim text9 As String = If(If((value9 IsNot Nothing), value9.ToString().Trim(), Nothing), "")
				Dim value10 As Object = dataGridViewRow.Cells(10).Value
				Dim text10 As String = If(If((value10 IsNot Nothing), value10.ToString().Trim(), Nothing), "")
				Dim value11 As Object = dataGridViewRow.Cells(11).Value
				Dim text11 As String = If(If((value11 IsNot Nothing), value11.ToString().Trim(), Nothing), "")
				Dim value12 As Object = dataGridViewRow.Cells(12).Value
				Dim text12 As String = If(If((value12 IsNot Nothing), value12.ToString().Trim(), Nothing), "")
				Dim num As Decimal = 0D
				Dim text13 As String = "Cr"
				Dim flag2 As Boolean = dataGridViewRow.Cells(13).Value IsNot Nothing AndAlso Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(13).Value))
				If flag2 Then
					Dim text14 As String = dataGridViewRow.Cells(13).Value.ToString().Trim()
					Dim flag3 As Boolean = text14.Contains("Cr") Or text14.Contains("Dr")
					If flag3 Then
						text13 = text14.Substring(text14.Length - 2)
						text14 = text14.Substring(0, text14.Length - 3)
					End If
					num = New Decimal(Conversion.Val(text14.Trim()))
				End If
				Dim value13 As Object = dataGridViewRow.Cells(14).Value
				Dim text15 As String = If(If((value13 IsNot Nothing), value13.ToString().Trim(), Nothing), "")
				Dim num2 As Decimal = 0D
				Dim flag4 As Boolean = dataGridViewRow.Cells(15).Value IsNot Nothing AndAlso Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(15).Value))
				If flag4 Then
					Decimal.TryParse(dataGridViewRow.Cells(15).Value.ToString(), num2)
				End If
				Dim value14 As Object = dataGridViewRow.Cells(16).Value
				Dim text16 As String = If(If((value14 IsNot Nothing), value14.ToString().Trim(), Nothing), "")
				Dim flag5 As Boolean = String.IsNullOrWhiteSpace(text3)
				If flag5 Then
					MessageBox.Show("Supplier Name is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.SetFocustoCurrentCell(RowIndex, 3)
				Else
					Dim flag6 As Boolean = String.IsNullOrWhiteSpace(text6)
					If flag6 Then
						MessageBox.Show("State  is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.SetFocustoCurrentCell(RowIndex, 6)
					Else
						Dim flag7 As Boolean = dataGridViewRow.Cells(8).Value Is Nothing OrElse Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(8).Value)) OrElse String.IsNullOrWhiteSpace(dataGridViewRow.Cells(8).Value.ToString())
						If flag7 Then
							MessageBox.Show("Contact Number is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.SetFocustoCurrentCell(RowIndex, 8)
						Else
							Dim flag8 As Boolean = Not String.IsNullOrWhiteSpace(text8)
							If flag8 Then
								Dim flag9 As Boolean = Not Regex.IsMatch(text8, "^\d{10}$")
								If flag9 Then
									MessageBox.Show("Invalid Contact Number! Must be 10 digits.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.SetFocustoCurrentCell(RowIndex, 8)
									Return
								End If
							End If
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text17 As String = "select RTRIM(ContactNo) from Supplier where ContactNo=@d1"
							Dim flag10 As Boolean = Operators.CompareString(text16, "Save", False) <> 0
							If flag10 Then
								text17 = Conversions.ToString(Operators.ConcatenateObject(text17, Operators.ConcatenateObject(" and id != ", obj)))
							End If
							ModCommonClasses.cmd = New SqlCommand(text17)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", text8)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag11 As Boolean = ModCommonClasses.rdr.Read()
							If flag11 Then
								MessageBox.Show("Entered contact no. is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Me.SetFocustoCurrentCell(RowIndex, 8)
								Dim flag12 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag12 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								Dim flag13 As Boolean = Not String.IsNullOrWhiteSpace(text9)
								If flag13 Then
									Dim flag14 As Boolean = Not Regex.IsMatch(text9.Trim(), "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$")
									If flag14 Then
										MessageBox.Show("Invalid Email ID format!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.SetFocustoCurrentCell(RowIndex, 9)
										Return
									End If
								End If
								Dim flag15 As Boolean = Not String.IsNullOrWhiteSpace(text10)
								If flag15 Then
									Dim flag16 As Boolean = Not Regex.IsMatch(text10, "^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$")
									If flag16 Then
										MessageBox.Show("Invalid GSTIN format! Example: 22AAAAA0000A1Z5", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.SetFocustoCurrentCell(RowIndex, 10)
										Return
									End If
								End If
								Dim flag17 As Boolean = Not String.IsNullOrWhiteSpace(text11)
								If flag17 Then
									Dim flag18 As Boolean = Not Regex.IsMatch(text11, "^[LU]{1}[0-9]{5}[A-Z]{2}[0-9]{4}[A-Z]{3}[0-9]{6}$")
									If flag18 Then
										MessageBox.Show("Invalid CIN format! Example: U99999DL2010PLC123456", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.SetFocustoCurrentCell(RowIndex, 11)
										Return
									End If
								End If
								Dim flag19 As Boolean = Not String.IsNullOrWhiteSpace(text12)
								If flag19 Then
									Dim flag20 As Boolean = Not Regex.IsMatch(text12, "^[A-Z]{5}[0-9]{4}[A-Z]{1}$")
									If flag20 Then
										MessageBox.Show("Invalid PAN format! Example: ABCDE1234F", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.SetFocustoCurrentCell(RowIndex, 12)
										Return
									End If
								End If
								Dim flag21 As Boolean = dataGridViewRow.Cells(13).Value Is Nothing OrElse Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(13).Value)) OrElse String.IsNullOrWhiteSpace(dataGridViewRow.Cells(13).Value.ToString())
								If flag21 Then
									MessageBox.Show("Opening Balance is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.SetFocustoCurrentCell(RowIndex, 13)
								Else
									Dim flag22 As Boolean = Decimal.Compare(num, 0D) < 0
									If flag22 Then
										MessageBox.Show("Opening Balance cannot be negative.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.SetFocustoCurrentCell(RowIndex, 13)
									Else
										Dim num3 As Decimal = 100000000D
										Dim flag23 As Boolean = Decimal.Compare(num, num3) > 0
										If flag23 Then
											MessageBox.Show(String.Format("Opening Balance cannot exceed {0}.", num3), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.SetFocustoCurrentCell(RowIndex, 13)
										Else
											Dim flag24 As Boolean = Decimal.Compare(Decimal.Round(num, 2), num) <> 0
											If flag24 Then
												MessageBox.Show("Opening Balance can have at most 2 decimal places.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Me.SetFocustoCurrentCell(RowIndex, 13)
											Else
												Dim flag25 As Boolean = dataGridViewRow.Cells(15).Value Is Nothing OrElse Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(15).Value)) OrElse String.IsNullOrWhiteSpace(dataGridViewRow.Cells(15).Value.ToString())
												If flag25 Then
													MessageBox.Show("Credit Limit is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Me.SetFocustoCurrentCell(RowIndex, 15)
												Else
													Dim flag26 As Boolean = Decimal.Compare(num2, 0D) < 0
													If flag26 Then
														MessageBox.Show("Credit Limit cannot be negative.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
														Me.SetFocustoCurrentCell(RowIndex, 15)
													Else
														Dim flag27 As Boolean = Decimal.Compare(num2, num3) > 0
														If flag27 Then
															MessageBox.Show(String.Format("Credit Limit cannot exceed {0}.", num3), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
															Me.SetFocustoCurrentCell(RowIndex, 15)
														Else
															Dim flag28 As Boolean = Decimal.Compare(Decimal.Round(num2, 2), num2) <> 0
															If flag28 Then
																MessageBox.Show("Credit Limit can have at most 2 decimal places.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																Me.SetFocustoCurrentCell(RowIndex, 15)
															Else
																Dim flag29 As Boolean = True
																Dim flag30 As Boolean = Operators.CompareString(text16, "Save", False) = 0
																Dim text18 As String
																If flag30 Then
																	text18 = "INSERT INTO Supplier (ID,Scode, SupplierID, [Name], Address, City, State, ZipCode, ContactNo, EmailID, GSTIN, CIN, PAN, OpeningBalance, openingbalancetype, Remarks, Lstatus, [Limit])" & vbCrLf & "                  VALUES (@Id, @Scode, @SupplierID, @Name, @Address, @City, @State, @ZipCode, @ContactNo, @EmailID, @GSTIN, @CIN, @PAN, @OpeningBalance, @openingbalancetype, @Remarks, 'Yes', @Limit)"
																Else
																	text18 = "UPDATE Supplier SET " & vbCrLf & "                    [Name] = @Name," & vbCrLf & "                    Address = @Address," & vbCrLf & "                    City = @City," & vbCrLf & "                    State = @State," & vbCrLf & "                    ZipCode = @ZipCode," & vbCrLf & "                    ContactNo = @ContactNo," & vbCrLf & "                    EmailID = @EmailID," & vbCrLf & "                    GSTIN = @GSTIN," & vbCrLf & "                    CIN = @CIN," & vbCrLf & "                    PAN = @PAN," & vbCrLf & "                    OpeningBalance = @OpeningBalance," & vbCrLf & "                    openingbalancetype = @openingbalancetype," & vbCrLf & "                    Remarks = @Remarks," & vbCrLf & "                    Lstatus = 'Yes'," & vbCrLf & "                    [Limit] = @Limit" & vbCrLf & "                  WHERE SupplierID = @SupplierID and Id = @Id"
																	flag29 = False
																End If
																Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
																	Using sqlCommand As SqlCommand = New SqlCommand(text18, sqlConnection)
																		Dim flag31 As Boolean = Operators.CompareString(text16, "Save", False) = 0
																		If flag31 Then
																			obj = Me.GenerateID()
																			text = "S-" + Me.GenerateID()
																			Dim text19 As String = Me.GenerateScode(text3)
																			sqlCommand.Parameters.AddWithValue("@Scode", text19)
																			dataGridViewRow.Cells(16).Value = "Update"
																		End If
																		sqlCommand.Parameters.AddWithValue("@Id", RuntimeHelpers.GetObjectValue(obj))
																		dataGridViewRow.Cells(0).Value = RuntimeHelpers.GetObjectValue(obj)
																		sqlCommand.Parameters.AddWithValue("@SupplierID", text)
																		dataGridViewRow.Cells(1).Value = text
																		sqlCommand.Parameters.AddWithValue("@Name", text3)
																		sqlCommand.Parameters.AddWithValue("@Address", text4)
																		sqlCommand.Parameters.AddWithValue("@City", text5)
																		sqlCommand.Parameters.AddWithValue("@State", text6)
																		sqlCommand.Parameters.AddWithValue("@ZipCode", text7)
																		sqlCommand.Parameters.AddWithValue("@ContactNo", text8)
																		sqlCommand.Parameters.AddWithValue("@EmailID", text9)
																		sqlCommand.Parameters.AddWithValue("@GSTIN", text10)
																		sqlCommand.Parameters.AddWithValue("@CIN", text11)
																		sqlCommand.Parameters.AddWithValue("@PAN", text12)
																		sqlCommand.Parameters.AddWithValue("@OpeningBalance", num)
																		sqlCommand.Parameters.AddWithValue("@openingbalancetype", text13)
																		sqlCommand.Parameters.AddWithValue("@Remarks", text15)
																		sqlCommand.Parameters.AddWithValue("@Limit", num2)
																		sqlConnection.Open()
																		sqlCommand.ExecuteNonQuery()
																	End Using
																End Using
																MessageBox.Show("Record " + If((Operators.CompareString(text16, "Save", False) = 0), "inserted", "updated") + " successfully.")
																Dim flag32 As Boolean = flag29
																If flag32 Then
																	isUpdate = False
																	Me.AddNewRow()
																Else
																	isUpdate = True
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

		' Token: 0x06001AB6 RID: 6838 RVA: 0x00013E68 File Offset: 0x00012068
		Private Sub GelButtonNewRecord_Click(sender As Object, e As EventArgs)
			Me.AddNewRow()
		End Sub

		' Token: 0x06001AB7 RID: 6839 RVA: 0x00124550 File Offset: 0x00122750
		Private Sub txtTopResult_TextChanged(sender As Object, e As EventArgs)
			' Initial control values must not query SQL before the window loads.
			If Not Me.IsHandleCreated Then Return
			Dim flag As Boolean = Not String.IsNullOrEmpty(Me.txtTopResult.Text.Trim())
			If flag Then
				Me.Getdata()
			End If
		End Sub

		' Token: 0x06001AB8 RID: 6840 RVA: 0x00009E98 File Offset: 0x00008098
		Public Sub Reset()
		End Sub

		' Token: 0x06001AB9 RID: 6841 RVA: 0x00124584 File Offset: 0x00122784
		Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkSelectAll.Checked
			If checked Then
				Me.dgw.SelectAll()
			Else
				Me.dgw.ClearSelection()
			End If
		End Sub

		' Token: 0x06001ABA RID: 6842 RVA: 0x001245C0 File Offset: 0x001227C0
		Public Sub UpdateState(currentRow As Integer, currentColumn As Integer, selectedState As String)
			Me.dgw.Rows(currentRow).Cells(currentColumn).Value = ""
			Me.dgw.Rows(currentRow).Cells(currentColumn).Value = selectedState
			Me.dgw.EndEdit()
			Me.dgw.RefreshEdit()
			Me.dgw.Invalidate()
			Me.dgw.CurrentCell = Me.dgw.Rows(currentRow).Cells(currentColumn + 1)
			Me.dgw.BeginEdit(True)
		End Sub

		' Token: 0x06001ABB RID: 6843 RVA: 0x00124674 File Offset: 0x00122874
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ID FROM Supplier ORDER BY ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("ID"))
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

		' Token: 0x06001ABC RID: 6844 RVA: 0x001206CC File Offset: 0x0011E8CC
		Public Function GenerateScode(supplierName As String) As String
			Dim text As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
			Dim text2 As String = DateAndTime.Now.ToString("ss")
			Dim text3 As String = text2
			text3 = text3 + Convert.ToString(text + supplierName) + text2
			Dim num As Integer = Integer.Parse(Conversions.ToString(4))
			Dim text4 As String = String.Empty
			Dim num2 As Integer = num - 1
			For i As Integer = 0 To num2
				Dim text5 As String = String.Empty
				Do
					Dim num3 As Integer = New Random().[Next](0, text3.Length)
					text5 = text3.ToCharArray()(num3).ToString()
				Loop While text4.IndexOf(text5) <> -1
				text4 += text5
			Next
			Return text4
		End Function

		' Token: 0x06001ABD RID: 6845 RVA: 0x00013E72 File Offset: 0x00012072
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x06001ABE RID: 6846 RVA: 0x001247E0 File Offset: 0x001229E0
		Friend Async Sub UpdateAccountType(currentRow As Integer, currentColumn As Integer, selectedType As String)
			Dim opbal As String = Me.dgw.Rows(currentRow).Cells(currentColumn).Value.ToString().Trim()
			Dim flag As Boolean = opbal.Contains("Cr") Or opbal.Contains("Dr")
			If flag Then
				opbal = opbal.Substring(0, opbal.Length - 3)
			End If
			Dim openingBalance As Double = Conversion.Val(opbal.Trim())
			Me.dgw.Rows(currentRow).Cells(currentColumn).Value = openingBalance.ToString("0.00") + " " + selectedType
			Dim nextCol As Integer = currentColumn + 1
			Dim flag2 As Boolean = nextCol < Me.dgw.Columns.Count
			If flag2 Then
				Me.dgw.CurrentCell = Me.dgw.Rows(currentRow).Cells(nextCol)
			End If
			Me.dgw.Focus()
			Application.DoEvents()
			Await Task.Delay(50)
			Me.dgw.BeginEdit(True)
			Me.dgw.ClearSelection()
			Dim editingControl As TextBox = TryCast(Me.dgw.EditingControl, TextBox)
			If editingControl IsNot Nothing Then
				editingControl.SelectionStart = 0
				editingControl.SelectionLength = editingControl.Text.Length
			End If
		End Sub

		' Token: 0x06001ABF RID: 6847 RVA: 0x00124830 File Offset: 0x00122A30
		Public Sub Getdata_bySearch()
			Try
				Dim text As String = Me.txtSearchProduct.Text.Trim()
				Dim selectedIndex As Integer = Me.cmbSearchCat.SelectedIndex
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = selectedIndex = 0
				Dim text2 As String
				If flag Then
					text2 = String.Format("select top {0} ID, RTrim(SupplierID), SCode, RTrim([Name]), RTrim(Address), RTrim(City), RTrim(State),RTrim(ZipCode),RTrim(ContactNo), RTrim(EmailID),RTrim(GSTIN),RTrim(CIN),RTrim(PAN), RTrim(OpeningBalance) + ' ' + RTRIM(isnull(openingbalancetype,'Cr')), RTrim(Remarks),RTrim(Limit) from Supplier where Lstatus= 'Yes' and RTrim(Name) like @search order by id desc", Me.txtTopResult.Text)
				Else
					text2 = String.Format("select top {0} ID, RTrim(SupplierID), SCode, RTrim([Name]), RTrim(Address), RTrim(City), RTrim(State),RTrim(ZipCode),RTrim(ContactNo), RTrim(EmailID),RTrim(GSTIN),RTrim(CIN),RTrim(PAN), RTrim(OpeningBalance) + ' ' + RTRIM(isnull(openingbalancetype,'Cr')), RTrim(Remarks),RTrim(Limit) from Supplier where Lstatus= 'Yes' and RTrim(ContactNo) like @search order by id desc", Me.txtTopResult.Text)
				End If
				ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@search", "%" + text + "%")
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim num As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15) })
					Me.dgw.Rows(num).Cells(16).Value = "Update"
				End While
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
				Dim flag2 As Boolean = Me.dgw.RowCount > 0
				If flag2 Then
					Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(3)
				End If
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001AC0 RID: 6848 RVA: 0x00124B20 File Offset: 0x00122D20
		Private Sub txtSearchProduct_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbSearchCat.SelectedIndex <> -1
			If flag Then
				Me.Getdata_bySearch()
			End If
		End Sub

		' Token: 0x06001AC1 RID: 6849 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub cmbSearchCat_SelectedIndexChanged(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x04000A7B RID: 2683
		Public eventSender As Object

		' Token: 0x04000A7C RID: 2684
		Private prevCell As DataGridViewCell
	End Class
End Namespace
