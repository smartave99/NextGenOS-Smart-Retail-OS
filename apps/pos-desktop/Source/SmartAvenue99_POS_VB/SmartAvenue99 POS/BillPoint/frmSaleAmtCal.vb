Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000206 RID: 518
	<DesignerGenerated()>
	Public Partial Class frmSaleAmtCal
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060095B8 RID: 38328 RVA: 0x006BDF38 File Offset: 0x006BC138
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSaleAmtCal_Load
			AddHandler MyBase.FormClosed, AddressOf Me.frmSaleAmtCal_FormClosed
			AddHandler MyBase.KeyDown, AddressOf Me.frmSaleAmtCal_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17003799 RID: 14233
		' (get) Token: 0x060095BB RID: 38331 RVA: 0x0004946A File Offset: 0x0004766A
		' (set) Token: 0x060095BC RID: 38332 RVA: 0x00049474 File Offset: 0x00047674
		Friend Overridable Property Label1 As Label

		' Token: 0x1700379A RID: 14234
		' (get) Token: 0x060095BD RID: 38333 RVA: 0x0004947D File Offset: 0x0004767D
		' (set) Token: 0x060095BE RID: 38334 RVA: 0x00049487 File Offset: 0x00047687
		Friend Overridable Property lblTaxPer As Label

		' Token: 0x1700379B RID: 14235
		' (get) Token: 0x060095BF RID: 38335 RVA: 0x00049490 File Offset: 0x00047690
		' (set) Token: 0x060095C0 RID: 38336 RVA: 0x0004949A File Offset: 0x0004769A
		Friend Overridable Property lblDiscAmt As Label

		' Token: 0x1700379C RID: 14236
		' (get) Token: 0x060095C1 RID: 38337 RVA: 0x000494A3 File Offset: 0x000476A3
		' (set) Token: 0x060095C2 RID: 38338 RVA: 0x000494AD File Offset: 0x000476AD
		Friend Overridable Property lblTaxType As Label

		' Token: 0x1700379D RID: 14237
		' (get) Token: 0x060095C3 RID: 38339 RVA: 0x000494B6 File Offset: 0x000476B6
		' (set) Token: 0x060095C4 RID: 38340 RVA: 0x000494C0 File Offset: 0x000476C0
		Friend Overridable Property lblPrice As Label

		' Token: 0x1700379E RID: 14238
		' (get) Token: 0x060095C5 RID: 38341 RVA: 0x000494C9 File Offset: 0x000476C9
		' (set) Token: 0x060095C6 RID: 38342 RVA: 0x000494D3 File Offset: 0x000476D3
		Friend Overridable Property lblPOSType As Label

		' Token: 0x1700379F RID: 14239
		' (get) Token: 0x060095C7 RID: 38343 RVA: 0x000494DC File Offset: 0x000476DC
		' (set) Token: 0x060095C8 RID: 38344 RVA: 0x006BE71C File Offset: 0x006BC91C
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

		' Token: 0x170037A0 RID: 14240
		' (get) Token: 0x060095C9 RID: 38345 RVA: 0x000494E6 File Offset: 0x000476E6
		' (set) Token: 0x060095CA RID: 38346 RVA: 0x006BE760 File Offset: 0x006BC960
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

		' Token: 0x170037A1 RID: 14241
		' (get) Token: 0x060095CB RID: 38347 RVA: 0x000494F0 File Offset: 0x000476F0
		' (set) Token: 0x060095CC RID: 38348 RVA: 0x000494FA File Offset: 0x000476FA
		Friend Overridable Property Label2 As Label

		' Token: 0x060095CD RID: 38349 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmSaleAmtCal_Load(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x060095CE RID: 38350 RVA: 0x006BE7A4 File Offset: 0x006BC9A4
		Public Sub TotQtyCal()
			Dim flag As Boolean = Operators.CompareString(Me.lblTaxType.Text, "Exclusive", False) = 0
			If flag Then
				Me.CalQty = Conversion.Val(Me.TextBox1.Text) * 100.0 / (100.0 + Conversion.Val(Me.lblTaxPer.Text)) / (Conversion.Val(Me.lblPrice.Text) - Conversion.Val(Me.lblDiscAmt.Text))
			End If
			Dim flag2 As Boolean = Operators.CompareString(Me.lblTaxType.Text, "Inclusive", False) = 0
			If flag2 Then
				Me.CalQty = Conversion.Val(Me.TextBox1.Text) / (Conversion.Val(Me.lblPrice.Text) - Conversion.Val(Me.lblDiscAmt.Text))
			End If
		End Sub

		' Token: 0x060095CF RID: 38351 RVA: 0x006BE888 File Offset: 0x006BCA88
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = Conversion.Val(Me.TextBox1.Text) <= 0.0
				If flag2 Then
					MessageBox.Show("Please fill adjustable amount !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.TextBox1.Focus()
				Else
					Me.TotQtyCal()
					Dim flag3 As Boolean = Operators.CompareString(Me.lblPOSType.Text, "Sale Entry", False) = 0
					If flag3 Then
						MyProject.Forms.frmPOS.txtQty.Text = Conversions.ToString(Me.CalQty)
						MyBase.Close()
					End If
					Dim flag4 As Boolean = Operators.CompareString(Me.lblPOSType.Text, "Point of Sale Touch", False) = 0
					If flag4 Then
						MyProject.Forms.frmPOSTouch.txtQty.Text = Conversions.ToString(Me.CalQty)
						MyBase.Close()
					End If
				End If
			End If
		End Sub

		' Token: 0x060095D0 RID: 38352 RVA: 0x006BE984 File Offset: 0x006BCB84
		Private Sub frmSaleAmtCal_FormClosed(sender As Object, e As FormClosedEventArgs)
			Me.lblPOSType.Text = ""
			Me.lblTaxPer.Text = ""
			Me.lblPrice.Text = ""
			Me.lblDiscAmt.Text = ""
			Me.lblTaxType.Text = ""
		End Sub

		' Token: 0x060095D1 RID: 38353 RVA: 0x00180440 File Offset: 0x0017E640
		Private Sub frmSaleAmtCal_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				MyBase.Close()
			End If
		End Sub

		' Token: 0x060095D2 RID: 38354 RVA: 0x006BE9E8 File Offset: 0x006BCBE8
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Conversion.Val(Me.TextBox1.Text) <= 0.0
			If flag Then
				MessageBox.Show("Please fill adjustable amount !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.TextBox1.Focus()
			Else
				Me.TotQtyCal()
				Dim flag2 As Boolean = Operators.CompareString(Me.lblPOSType.Text, "Sale Entry", False) = 0
				If flag2 Then
					MyProject.Forms.frmPOS.txtQty.Text = Conversions.ToString(Me.CalQty)
					MyBase.Close()
				End If
				Dim flag3 As Boolean = Operators.CompareString(Me.lblPOSType.Text, "Point of Sale Touch", False) = 0
				If flag3 Then
					MyProject.Forms.frmPOSTouch.txtQty.Text = Conversions.ToString(Me.CalQty)
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x04004248 RID: 16968
		Private CalQty As Double
	End Class
End Namespace
