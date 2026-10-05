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
Imports BillPoint.My
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020001F0 RID: 496
	<DesignerGenerated()>
	Public Partial Class frmPurchaseStock
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06008BA0 RID: 35744 RVA: 0x00044165 File Offset: 0x00042365
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmGSTDetailsPur_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmPurchaseRecord_GSTR_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700335A RID: 13146
		' (get) Token: 0x06008BA3 RID: 35747 RVA: 0x00044197 File Offset: 0x00042397
		' (set) Token: 0x06008BA4 RID: 35748 RVA: 0x000441A1 File Offset: 0x000423A1
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x1700335B RID: 13147
		' (get) Token: 0x06008BA5 RID: 35749 RVA: 0x000441AA File Offset: 0x000423AA
		' (set) Token: 0x06008BA6 RID: 35750 RVA: 0x000441B4 File Offset: 0x000423B4
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700335C RID: 13148
		' (get) Token: 0x06008BA7 RID: 35751 RVA: 0x000441BD File Offset: 0x000423BD
		' (set) Token: 0x06008BA8 RID: 35752 RVA: 0x0066C420 File Offset: 0x0066A620
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

		' Token: 0x1700335D RID: 13149
		' (get) Token: 0x06008BA9 RID: 35753 RVA: 0x000441C7 File Offset: 0x000423C7
		' (set) Token: 0x06008BAA RID: 35754 RVA: 0x0066C464 File Offset: 0x0066A664
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

		' Token: 0x1700335E RID: 13150
		' (get) Token: 0x06008BAB RID: 35755 RVA: 0x000441D1 File Offset: 0x000423D1
		' (set) Token: 0x06008BAC RID: 35756 RVA: 0x000441DB File Offset: 0x000423DB
		Friend Overridable Property Label3 As Label

		' Token: 0x1700335F RID: 13151
		' (get) Token: 0x06008BAD RID: 35757 RVA: 0x000441E4 File Offset: 0x000423E4
		' (set) Token: 0x06008BAE RID: 35758 RVA: 0x0066C4A8 File Offset: 0x0066A6A8
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox1_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_TextChanged
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003360 RID: 13152
		' (get) Token: 0x06008BAF RID: 35759 RVA: 0x000441EE File Offset: 0x000423EE
		' (set) Token: 0x06008BB0 RID: 35760 RVA: 0x000441F8 File Offset: 0x000423F8
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x17003361 RID: 13153
		' (get) Token: 0x06008BB1 RID: 35761 RVA: 0x00044201 File Offset: 0x00042401
		' (set) Token: 0x06008BB2 RID: 35762 RVA: 0x0004420B File Offset: 0x0004240B
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17003362 RID: 13154
		' (get) Token: 0x06008BB3 RID: 35763 RVA: 0x00044214 File Offset: 0x00042414
		' (set) Token: 0x06008BB4 RID: 35764 RVA: 0x0066C508 File Offset: 0x0066A708
		Private _btnAddCustomer As GelButton
		Friend Overridable Property btnAddCustomer As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnAddCustomer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnAddCustomer_Click
				Dim gelButton As GelButton = Me._btnAddCustomer
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnAddCustomer = value
				gelButton = Me._btnAddCustomer
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003363 RID: 13155
		' (get) Token: 0x06008BB5 RID: 35765 RVA: 0x0004421E File Offset: 0x0004241E
		' (set) Token: 0x06008BB6 RID: 35766 RVA: 0x00044228 File Offset: 0x00042428
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17003364 RID: 13156
		' (get) Token: 0x06008BB7 RID: 35767 RVA: 0x00044231 File Offset: 0x00042431
		' (set) Token: 0x06008BB8 RID: 35768 RVA: 0x0004423B File Offset: 0x0004243B
		Friend Overridable Property Label2 As Label

		' Token: 0x17003365 RID: 13157
		' (get) Token: 0x06008BB9 RID: 35769 RVA: 0x00044244 File Offset: 0x00042444
		' (set) Token: 0x06008BBA RID: 35770 RVA: 0x0004424E File Offset: 0x0004244E
		Friend Overridable Property Label4 As Label

		' Token: 0x17003366 RID: 13158
		' (get) Token: 0x06008BBB RID: 35771 RVA: 0x00044257 File Offset: 0x00042457
		' (set) Token: 0x06008BBC RID: 35772 RVA: 0x00044261 File Offset: 0x00042461
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17003367 RID: 13159
		' (get) Token: 0x06008BBD RID: 35773 RVA: 0x0004426A File Offset: 0x0004246A
		' (set) Token: 0x06008BBE RID: 35774 RVA: 0x0066C54C File Offset: 0x0066A74C
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
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003368 RID: 13160
		' (get) Token: 0x06008BBF RID: 35775 RVA: 0x00044274 File Offset: 0x00042474
		' (set) Token: 0x06008BC0 RID: 35776 RVA: 0x0004427E File Offset: 0x0004247E
		Friend Overridable Property Label1 As Label

		' Token: 0x17003369 RID: 13161
		' (get) Token: 0x06008BC1 RID: 35777 RVA: 0x00044287 File Offset: 0x00042487
		' (set) Token: 0x06008BC2 RID: 35778 RVA: 0x0066C590 File Offset: 0x0066A790
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

		' Token: 0x1700336A RID: 13162
		' (get) Token: 0x06008BC3 RID: 35779 RVA: 0x00044291 File Offset: 0x00042491
		' (set) Token: 0x06008BC4 RID: 35780 RVA: 0x0004429B File Offset: 0x0004249B
		Friend Overridable Property Label5 As Label

		' Token: 0x1700336B RID: 13163
		' (get) Token: 0x06008BC5 RID: 35781 RVA: 0x000442A4 File Offset: 0x000424A4
		' (set) Token: 0x06008BC6 RID: 35782 RVA: 0x000442AE File Offset: 0x000424AE
		Friend Overridable Property txtBarcode As TextBox

		' Token: 0x1700336C RID: 13164
		' (get) Token: 0x06008BC7 RID: 35783 RVA: 0x000442B7 File Offset: 0x000424B7
		' (set) Token: 0x06008BC8 RID: 35784 RVA: 0x000442C1 File Offset: 0x000424C1
		Friend Overridable Property Panel3 As Panel

		' Token: 0x1700336D RID: 13165
		' (get) Token: 0x06008BC9 RID: 35785 RVA: 0x000442CA File Offset: 0x000424CA
		' (set) Token: 0x06008BCA RID: 35786 RVA: 0x000442D4 File Offset: 0x000424D4
		Friend Overridable Property txtSupplierName As TextBox

		' Token: 0x1700336E RID: 13166
		' (get) Token: 0x06008BCB RID: 35787 RVA: 0x000442DD File Offset: 0x000424DD
		' (set) Token: 0x06008BCC RID: 35788 RVA: 0x0066C5D4 File Offset: 0x0066A7D4
		Private _btnSelection As Button
		Friend Overridable Property btnSelection As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSelection
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSelection_Click
				Dim button As Button = Me._btnSelection
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSelection = value
				button = Me._btnSelection
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700336F RID: 13167
		' (get) Token: 0x06008BCD RID: 35789 RVA: 0x000442E7 File Offset: 0x000424E7
		' (set) Token: 0x06008BCE RID: 35790 RVA: 0x000442F1 File Offset: 0x000424F1
		Friend Overridable Property txtSupplierID As TextBox

		' Token: 0x17003370 RID: 13168
		' (get) Token: 0x06008BCF RID: 35791 RVA: 0x000442FA File Offset: 0x000424FA
		' (set) Token: 0x06008BD0 RID: 35792 RVA: 0x00044304 File Offset: 0x00042504
		Friend Overridable Property Label7 As Label

		' Token: 0x17003371 RID: 13169
		' (get) Token: 0x06008BD1 RID: 35793 RVA: 0x0004430D File Offset: 0x0004250D
		' (set) Token: 0x06008BD2 RID: 35794 RVA: 0x00044317 File Offset: 0x00042517
		Friend Overridable Property Label8 As Label

		' Token: 0x17003372 RID: 13170
		' (get) Token: 0x06008BD3 RID: 35795 RVA: 0x00044320 File Offset: 0x00042520
		' (set) Token: 0x06008BD4 RID: 35796 RVA: 0x0004432A File Offset: 0x0004252A
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17003373 RID: 13171
		' (get) Token: 0x06008BD5 RID: 35797 RVA: 0x00044333 File Offset: 0x00042533
		' (set) Token: 0x06008BD6 RID: 35798 RVA: 0x0004433D File Offset: 0x0004253D
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17003374 RID: 13172
		' (get) Token: 0x06008BD7 RID: 35799 RVA: 0x00044346 File Offset: 0x00042546
		' (set) Token: 0x06008BD8 RID: 35800 RVA: 0x00044350 File Offset: 0x00042550
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17003375 RID: 13173
		' (get) Token: 0x06008BD9 RID: 35801 RVA: 0x00044359 File Offset: 0x00042559
		' (set) Token: 0x06008BDA RID: 35802 RVA: 0x00044363 File Offset: 0x00042563
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17003376 RID: 13174
		' (get) Token: 0x06008BDB RID: 35803 RVA: 0x0004436C File Offset: 0x0004256C
		' (set) Token: 0x06008BDC RID: 35804 RVA: 0x00044376 File Offset: 0x00042576
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17003377 RID: 13175
		' (get) Token: 0x06008BDD RID: 35805 RVA: 0x0004437F File Offset: 0x0004257F
		' (set) Token: 0x06008BDE RID: 35806 RVA: 0x00044389 File Offset: 0x00042589
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17003378 RID: 13176
		' (get) Token: 0x06008BDF RID: 35807 RVA: 0x00044392 File Offset: 0x00042592
		' (set) Token: 0x06008BE0 RID: 35808 RVA: 0x0004439C File Offset: 0x0004259C
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17003379 RID: 13177
		' (get) Token: 0x06008BE1 RID: 35809 RVA: 0x000443A5 File Offset: 0x000425A5
		' (set) Token: 0x06008BE2 RID: 35810 RVA: 0x000443AF File Offset: 0x000425AF
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x1700337A RID: 13178
		' (get) Token: 0x06008BE3 RID: 35811 RVA: 0x000443B8 File Offset: 0x000425B8
		' (set) Token: 0x06008BE4 RID: 35812 RVA: 0x000443C2 File Offset: 0x000425C2
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x1700337B RID: 13179
		' (get) Token: 0x06008BE5 RID: 35813 RVA: 0x000443CB File Offset: 0x000425CB
		' (set) Token: 0x06008BE6 RID: 35814 RVA: 0x000443D5 File Offset: 0x000425D5
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x1700337C RID: 13180
		' (get) Token: 0x06008BE7 RID: 35815 RVA: 0x000443DE File Offset: 0x000425DE
		' (set) Token: 0x06008BE8 RID: 35816 RVA: 0x000443E8 File Offset: 0x000425E8
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x1700337D RID: 13181
		' (get) Token: 0x06008BE9 RID: 35817 RVA: 0x000443F1 File Offset: 0x000425F1
		' (set) Token: 0x06008BEA RID: 35818 RVA: 0x000443FB File Offset: 0x000425FB
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700337E RID: 13182
		' (get) Token: 0x06008BEB RID: 35819 RVA: 0x00044404 File Offset: 0x00042604
		' (set) Token: 0x06008BEC RID: 35820 RVA: 0x0004440E File Offset: 0x0004260E
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x1700337F RID: 13183
		' (get) Token: 0x06008BED RID: 35821 RVA: 0x00044417 File Offset: 0x00042617
		' (set) Token: 0x06008BEE RID: 35822 RVA: 0x00044421 File Offset: 0x00042621
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17003380 RID: 13184
		' (get) Token: 0x06008BEF RID: 35823 RVA: 0x0004442A File Offset: 0x0004262A
		' (set) Token: 0x06008BF0 RID: 35824 RVA: 0x00044434 File Offset: 0x00042634
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17003381 RID: 13185
		' (get) Token: 0x06008BF1 RID: 35825 RVA: 0x0004443D File Offset: 0x0004263D
		' (set) Token: 0x06008BF2 RID: 35826 RVA: 0x00044447 File Offset: 0x00042647
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17003382 RID: 13186
		' (get) Token: 0x06008BF3 RID: 35827 RVA: 0x00044450 File Offset: 0x00042650
		' (set) Token: 0x06008BF4 RID: 35828 RVA: 0x0004445A File Offset: 0x0004265A
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x17003383 RID: 13187
		' (get) Token: 0x06008BF5 RID: 35829 RVA: 0x00044463 File Offset: 0x00042663
		' (set) Token: 0x06008BF6 RID: 35830 RVA: 0x0004446D File Offset: 0x0004266D
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x17003384 RID: 13188
		' (get) Token: 0x06008BF7 RID: 35831 RVA: 0x00044476 File Offset: 0x00042676
		' (set) Token: 0x06008BF8 RID: 35832 RVA: 0x00044480 File Offset: 0x00042680
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17003385 RID: 13189
		' (get) Token: 0x06008BF9 RID: 35833 RVA: 0x00044489 File Offset: 0x00042689
		' (set) Token: 0x06008BFA RID: 35834 RVA: 0x00044493 File Offset: 0x00042693
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17003386 RID: 13190
		' (get) Token: 0x06008BFB RID: 35835 RVA: 0x0004449C File Offset: 0x0004269C
		' (set) Token: 0x06008BFC RID: 35836 RVA: 0x000444A6 File Offset: 0x000426A6
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17003387 RID: 13191
		' (get) Token: 0x06008BFD RID: 35837 RVA: 0x000444AF File Offset: 0x000426AF
		' (set) Token: 0x06008BFE RID: 35838 RVA: 0x000444B9 File Offset: 0x000426B9
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17003388 RID: 13192
		' (get) Token: 0x06008BFF RID: 35839 RVA: 0x000444C2 File Offset: 0x000426C2
		' (set) Token: 0x06008C00 RID: 35840 RVA: 0x000444CC File Offset: 0x000426CC
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17003389 RID: 13193
		' (get) Token: 0x06008C01 RID: 35841 RVA: 0x000444D5 File Offset: 0x000426D5
		' (set) Token: 0x06008C02 RID: 35842 RVA: 0x000444DF File Offset: 0x000426DF
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x1700338A RID: 13194
		' (get) Token: 0x06008C03 RID: 35843 RVA: 0x000444E8 File Offset: 0x000426E8
		' (set) Token: 0x06008C04 RID: 35844 RVA: 0x000444F2 File Offset: 0x000426F2
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x1700338B RID: 13195
		' (get) Token: 0x06008C05 RID: 35845 RVA: 0x000444FB File Offset: 0x000426FB
		' (set) Token: 0x06008C06 RID: 35846 RVA: 0x00044505 File Offset: 0x00042705
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x1700338C RID: 13196
		' (get) Token: 0x06008C07 RID: 35847 RVA: 0x0004450E File Offset: 0x0004270E
		' (set) Token: 0x06008C08 RID: 35848 RVA: 0x00044518 File Offset: 0x00042718
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700338D RID: 13197
		' (get) Token: 0x06008C09 RID: 35849 RVA: 0x00044521 File Offset: 0x00042721
		' (set) Token: 0x06008C0A RID: 35850 RVA: 0x0004452B File Offset: 0x0004272B
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x1700338E RID: 13198
		' (get) Token: 0x06008C0B RID: 35851 RVA: 0x00044534 File Offset: 0x00042734
		' (set) Token: 0x06008C0C RID: 35852 RVA: 0x0004453E File Offset: 0x0004273E
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x1700338F RID: 13199
		' (get) Token: 0x06008C0D RID: 35853 RVA: 0x00044547 File Offset: 0x00042747
		' (set) Token: 0x06008C0E RID: 35854 RVA: 0x00044551 File Offset: 0x00042751
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17003390 RID: 13200
		' (get) Token: 0x06008C0F RID: 35855 RVA: 0x0004455A File Offset: 0x0004275A
		' (set) Token: 0x06008C10 RID: 35856 RVA: 0x00044564 File Offset: 0x00042764
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17003391 RID: 13201
		' (get) Token: 0x06008C11 RID: 35857 RVA: 0x0004456D File Offset: 0x0004276D
		' (set) Token: 0x06008C12 RID: 35858 RVA: 0x00044577 File Offset: 0x00042777
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17003392 RID: 13202
		' (get) Token: 0x06008C13 RID: 35859 RVA: 0x00044580 File Offset: 0x00042780
		' (set) Token: 0x06008C14 RID: 35860 RVA: 0x0004458A File Offset: 0x0004278A
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x17003393 RID: 13203
		' (get) Token: 0x06008C15 RID: 35861 RVA: 0x00044593 File Offset: 0x00042793
		' (set) Token: 0x06008C16 RID: 35862 RVA: 0x0004459D File Offset: 0x0004279D
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x06008C17 RID: 35863 RVA: 0x0066C618 File Offset: 0x0066A818
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

		' Token: 0x06008C18 RID: 35864 RVA: 0x0066C6EC File Offset: 0x0066A8EC
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt) + (Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.TaxableAmt, (Stock_Product.CGSTPer + Stock_Product.SGSTPer + Stock_Product.IGSTPer), (Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt), Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and NOT Stock.TaxType='NON GST' order by Stock.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008C19 RID: 35865 RVA: 0x0066C9F4 File Offset: 0x0066ABF4
		Private Sub frmGSTDetailsPur_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Calculate()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06008C1A RID: 35866 RVA: 0x0066CA84 File Offset: 0x0066AC84
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

		' Token: 0x06008C1B RID: 35867 RVA: 0x0066CBFC File Offset: 0x0066ADFC
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

		' Token: 0x06008C1C RID: 35868 RVA: 0x0066CCB8 File Offset: 0x0066AEB8
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

		' Token: 0x06008C1D RID: 35869 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06008C1E RID: 35870 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06008C1F RID: 35871 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06008C20 RID: 35872 RVA: 0x0066CD84 File Offset: 0x0066AF84
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

		' Token: 0x06008C21 RID: 35873 RVA: 0x000445A6 File Offset: 0x000427A6
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.TextBox1.Text = ""
			Me.Getdata()
		End Sub

		' Token: 0x06008C22 RID: 35874 RVA: 0x00087110 File Offset: 0x00085310
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

		' Token: 0x06008C23 RID: 35875 RVA: 0x0066CE6C File Offset: 0x0066B06C
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

		' Token: 0x06008C24 RID: 35876 RVA: 0x0066CF84 File Offset: 0x0066B184
		Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.TextBox1.Text
					Dim selectionStart As Integer = Me.TextBox1.SelectionStart
					Dim selectionLength As Integer = Me.TextBox1.SelectionLength
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
			Dim flag5 As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), ".", False) <> 0 AndAlso e.KeyChar <> vbBack
			If flag5 Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x06008C25 RID: 35877 RVA: 0x0066D0C4 File Offset: 0x0066B2C4
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt) + (Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.TaxableAmt, (Stock_Product.CGSTPer + Stock_Product.SGSTPer + Stock_Product.IGSTPer), (Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt), Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 and (Stock_Product.CGSTPer + Stock_Product.SGSTPer + Stock_Product.IGSTPer)=@d3 and NOT Stock.TaxType='NON GST' order by Stock.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.TextBox1.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06008C26 RID: 35878 RVA: 0x0066D3F0 File Offset: 0x0066B5F0
		Private Sub btnAddCustomer_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt) + (Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.TaxableAmt, (Stock_Product.CGSTPer + Stock_Product.SGSTPer + Stock_Product.IGSTPer), (Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt), Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,Stock_Product.Qty,isnull(stock_Product.SQty,0) as SaleQty,isnull(Stock_Product.Qty, 0) - isnull(stock_Product.SQty, 0) As BalQty FROM Stock INNER JOIN Stock_Product On Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier On Stock.SupplierID = Supplier.ID INNER JOIN Product On Stock_Product.ProductID = Product.PID where Stock.Date between @d1 And @d2 And Not Stock.TaxType='NON GST' order by Stock.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06008C27 RID: 35879 RVA: 0x000445D9 File Offset: 0x000427D9
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x06008C28 RID: 35880 RVA: 0x0066D720 File Offset: 0x0066B920
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Columns.Count = 0 OrElse Me.dgw.Rows.Count = 0
				If flag Then
					MessageBox.Show("No record found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
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
							Dim flag2 As Boolean = Not dataGridViewRow.IsNewRow
							If flag2 Then
								Dim dataRow As DataRow = dataTable.NewRow()
								Try
									For Each obj3 As Object In dataGridViewRow.Cells
										Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
										dataRow(dataGridViewCell.ColumnIndex) = If((dataGridViewCell.Value IsNot Nothing), dataGridViewCell.Value.ToString(), "")
									Next
								Finally
									Dim enumerator3 As IEnumerator
									If TypeOf enumerator3 Is IDisposable Then
										TryCast(enumerator3, IDisposable).Dispose()
									End If
								End Try
								dataTable.Rows.Add(dataRow)
							End If
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag3 As Boolean = Me.SaveFileDialog1.ShowDialog() <> DialogResult.OK
					If Not flag3 Then
						Dim fileName As String = Me.SaveFileDialog1.FileName
						Using xlworkbook As XLWorkbook = New XLWorkbook()
							xlworkbook.Worksheets.Add(dataTable, "Export File")
							xlworkbook.SaveAs(fileName)
						End Using
						MessageBox.Show("Successfully exported.", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Export failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008C29 RID: 35881 RVA: 0x0066D9EC File Offset: 0x0066BBEC
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType,  RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt) + (Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.TaxableAmt, (Stock_Product.CGSTPer + Stock_Product.SGSTPer + Stock_Product.IGSTPer), (Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt), Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,Stock_Product.Qty,isnull(stock_Product.SQty,0) as SaleQty,isnull(Stock_Product.Qty, 0) - isnull(stock_Product.SQty, 0) As BalQty,Stock_Product.Barcode,Stock_Product.MRP,Stock_Product.RPrice,Stock_Product.WPrice FROM Stock INNER JOIN Stock_Product On Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier On Stock.SupplierID = Supplier.ID INNER JOIN Product On Stock_Product.ProductID = Product.PID where Stock_Product.Barcode=@d1 or Supplier.Name=@d2  order by Stock.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.VarChar, 30).Value = Me.txtBarcode.Text
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.VarChar, 30).Value = Me.txtSupplierName.Text
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06008C2A RID: 35882 RVA: 0x000445EA File Offset: 0x000427EA
		Private Sub btnSelection_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplierRecord.lblSet.Text = "Purchase Stock"
			MyProject.Forms.frmSupplierRecord.Reset()
			MyProject.Forms.frmSupplierRecord.ShowDialog()
		End Sub
	End Class
End Namespace
