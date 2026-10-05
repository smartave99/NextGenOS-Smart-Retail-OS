Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004DB RID: 1243
	<DesignerGenerated()>
	Public Partial Class frmSetBillDiscount
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FD1F RID: 64799 RVA: 0x00976348 File Offset: 0x00974548
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSetBillDiscount_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSetBillDiscount_KeyDown
			Me.sign_Indicator = 0
			Me.fl = False
			Me.InitializeComponent()
		End Sub

		' Token: 0x170060C4 RID: 24772
		' (get) Token: 0x0600FD22 RID: 64802 RVA: 0x0006EF90 File Offset: 0x0006D190
		' (set) Token: 0x0600FD23 RID: 64803 RVA: 0x0006EF9A File Offset: 0x0006D19A
		Friend Overridable Property Label1 As Label

		' Token: 0x170060C5 RID: 24773
		' (get) Token: 0x0600FD24 RID: 64804 RVA: 0x0006EFA3 File Offset: 0x0006D1A3
		' (set) Token: 0x0600FD25 RID: 64805 RVA: 0x00977DF0 File Offset: 0x00975FF0
		Private _txtDiscount As TextBox
		Friend Overridable Property txtDiscount As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDiscount
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtDiscount_KeyPress
				Dim textBox As TextBox = Me._txtDiscount
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._txtDiscount = value
				textBox = Me._txtDiscount
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x170060C6 RID: 24774
		' (get) Token: 0x0600FD26 RID: 64806 RVA: 0x0006EFAD File Offset: 0x0006D1AD
		' (set) Token: 0x0600FD27 RID: 64807 RVA: 0x00977E34 File Offset: 0x00976034
		Private _btnOkay As Button
		Friend Overridable Property btnOkay As Button
			<CompilerGenerated()>
			Get
				Return Me._btnOkay
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnOkay_Click
				Dim button As Button = Me._btnOkay
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnOkay = value
				button = Me._btnOkay
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060C7 RID: 24775
		' (get) Token: 0x0600FD28 RID: 64808 RVA: 0x0006EFB7 File Offset: 0x0006D1B7
		' (set) Token: 0x0600FD29 RID: 64809 RVA: 0x0006EFC1 File Offset: 0x0006D1C1
		Friend Overridable Property TableLayoutPanel3 As TableLayoutPanel

		' Token: 0x170060C8 RID: 24776
		' (get) Token: 0x0600FD2A RID: 64810 RVA: 0x0006EFCA File Offset: 0x0006D1CA
		' (set) Token: 0x0600FD2B RID: 64811 RVA: 0x00977E78 File Offset: 0x00976078
		Private _btnTAx As Button
		Friend Overridable Property btnTAx As Button
			<CompilerGenerated()>
			Get
				Return Me._btnTAx
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnTAx_Click
				Dim button As Button = Me._btnTAx
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnTAx = value
				button = Me._btnTAx
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060C9 RID: 24777
		' (get) Token: 0x0600FD2C RID: 64812 RVA: 0x0006EFD4 File Offset: 0x0006D1D4
		' (set) Token: 0x0600FD2D RID: 64813 RVA: 0x00977EBC File Offset: 0x009760BC
		Private _btnTA0 As Button
		Friend Overridable Property btnTA0 As Button
			<CompilerGenerated()>
			Get
				Return Me._btnTA0
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnTA0_Click
				Dim button As Button = Me._btnTA0
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnTA0 = value
				button = Me._btnTA0
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060CA RID: 24778
		' (get) Token: 0x0600FD2E RID: 64814 RVA: 0x0006EFDE File Offset: 0x0006D1DE
		' (set) Token: 0x0600FD2F RID: 64815 RVA: 0x00977F00 File Offset: 0x00976100
		Private _btnTAComma As Button
		Friend Overridable Property btnTAComma As Button
			<CompilerGenerated()>
			Get
				Return Me._btnTAComma
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnTAComma_Click
				Dim button As Button = Me._btnTAComma
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnTAComma = value
				button = Me._btnTAComma
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060CB RID: 24779
		' (get) Token: 0x0600FD30 RID: 64816 RVA: 0x0006EFE8 File Offset: 0x0006D1E8
		' (set) Token: 0x0600FD31 RID: 64817 RVA: 0x00977F44 File Offset: 0x00976144
		Private _btnTA9 As Button
		Friend Overridable Property btnTA9 As Button
			<CompilerGenerated()>
			Get
				Return Me._btnTA9
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnTA9_Click
				Dim button As Button = Me._btnTA9
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnTA9 = value
				button = Me._btnTA9
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060CC RID: 24780
		' (get) Token: 0x0600FD32 RID: 64818 RVA: 0x0006EFF2 File Offset: 0x0006D1F2
		' (set) Token: 0x0600FD33 RID: 64819 RVA: 0x00977F88 File Offset: 0x00976188
		Private _btnTA8 As Button
		Friend Overridable Property btnTA8 As Button
			<CompilerGenerated()>
			Get
				Return Me._btnTA8
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnTA8_Click
				Dim button As Button = Me._btnTA8
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnTA8 = value
				button = Me._btnTA8
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060CD RID: 24781
		' (get) Token: 0x0600FD34 RID: 64820 RVA: 0x0006EFFC File Offset: 0x0006D1FC
		' (set) Token: 0x0600FD35 RID: 64821 RVA: 0x00977FCC File Offset: 0x009761CC
		Private _btnTA4 As Button
		Friend Overridable Property btnTA4 As Button
			<CompilerGenerated()>
			Get
				Return Me._btnTA4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnTA4_Click
				Dim button As Button = Me._btnTA4
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnTA4 = value
				button = Me._btnTA4
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060CE RID: 24782
		' (get) Token: 0x0600FD36 RID: 64822 RVA: 0x0006F006 File Offset: 0x0006D206
		' (set) Token: 0x0600FD37 RID: 64823 RVA: 0x00978010 File Offset: 0x00976210
		Private _btnTA6 As Button
		Friend Overridable Property btnTA6 As Button
			<CompilerGenerated()>
			Get
				Return Me._btnTA6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnTA6_Click
				Dim button As Button = Me._btnTA6
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnTA6 = value
				button = Me._btnTA6
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060CF RID: 24783
		' (get) Token: 0x0600FD38 RID: 64824 RVA: 0x0006F010 File Offset: 0x0006D210
		' (set) Token: 0x0600FD39 RID: 64825 RVA: 0x00978054 File Offset: 0x00976254
		Private _btnTA5 As Button
		Friend Overridable Property btnTA5 As Button
			<CompilerGenerated()>
			Get
				Return Me._btnTA5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnTA5_Click
				Dim button As Button = Me._btnTA5
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnTA5 = value
				button = Me._btnTA5
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060D0 RID: 24784
		' (get) Token: 0x0600FD3A RID: 64826 RVA: 0x0006F01A File Offset: 0x0006D21A
		' (set) Token: 0x0600FD3B RID: 64827 RVA: 0x00978098 File Offset: 0x00976298
		Private _btnTA7 As Button
		Friend Overridable Property btnTA7 As Button
			<CompilerGenerated()>
			Get
				Return Me._btnTA7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnTA7_Click
				Dim button As Button = Me._btnTA7
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnTA7 = value
				button = Me._btnTA7
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060D1 RID: 24785
		' (get) Token: 0x0600FD3C RID: 64828 RVA: 0x0006F024 File Offset: 0x0006D224
		' (set) Token: 0x0600FD3D RID: 64829 RVA: 0x009780DC File Offset: 0x009762DC
		Private _btnTA3 As Button
		Friend Overridable Property btnTA3 As Button
			<CompilerGenerated()>
			Get
				Return Me._btnTA3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnTA3_Click
				Dim button As Button = Me._btnTA3
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnTA3 = value
				button = Me._btnTA3
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060D2 RID: 24786
		' (get) Token: 0x0600FD3E RID: 64830 RVA: 0x0006F02E File Offset: 0x0006D22E
		' (set) Token: 0x0600FD3F RID: 64831 RVA: 0x00978120 File Offset: 0x00976320
		Private _btnTA1 As Button
		Friend Overridable Property btnTA1 As Button
			<CompilerGenerated()>
			Get
				Return Me._btnTA1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnTA1_Click
				Dim button As Button = Me._btnTA1
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnTA1 = value
				button = Me._btnTA1
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060D3 RID: 24787
		' (get) Token: 0x0600FD40 RID: 64832 RVA: 0x0006F038 File Offset: 0x0006D238
		' (set) Token: 0x0600FD41 RID: 64833 RVA: 0x00978164 File Offset: 0x00976364
		Private _btnTA2 As Button
		Friend Overridable Property btnTA2 As Button
			<CompilerGenerated()>
			Get
				Return Me._btnTA2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnTA2_Click
				Dim button As Button = Me._btnTA2
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnTA2 = value
				button = Me._btnTA2
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060D4 RID: 24788
		' (get) Token: 0x0600FD42 RID: 64834 RVA: 0x0006F042 File Offset: 0x0006D242
		' (set) Token: 0x0600FD43 RID: 64835 RVA: 0x009781A8 File Offset: 0x009763A8
		Private _btnClear As Button
		Friend Overridable Property btnClear As Button
			<CompilerGenerated()>
			Get
				Return Me._btnClear
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnClear_Click
				Dim button As Button = Me._btnClear
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnClear = value
				button = Me._btnClear
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060D5 RID: 24789
		' (get) Token: 0x0600FD44 RID: 64836 RVA: 0x0006F04C File Offset: 0x0006D24C
		' (set) Token: 0x0600FD45 RID: 64837 RVA: 0x0006F056 File Offset: 0x0006D256
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170060D6 RID: 24790
		' (get) Token: 0x0600FD46 RID: 64838 RVA: 0x0006F05F File Offset: 0x0006D25F
		' (set) Token: 0x0600FD47 RID: 64839 RVA: 0x009781EC File Offset: 0x009763EC
		Private _RadioButton1 As RadioButton
		Friend Overridable Property RadioButton1 As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._RadioButton1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.Radiobutton1_CheckedChanged
				Dim radioButton As RadioButton = Me._RadioButton1
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._RadioButton1 = value
				radioButton = Me._RadioButton1
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060D7 RID: 24791
		' (get) Token: 0x0600FD48 RID: 64840 RVA: 0x0006F069 File Offset: 0x0006D269
		' (set) Token: 0x0600FD49 RID: 64841 RVA: 0x00978230 File Offset: 0x00976430
		Private _RadioButton2 As RadioButton
		Friend Overridable Property RadioButton2 As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._RadioButton2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.Radiobutton2_CheckedChanged
				Dim radioButton As RadioButton = Me._RadioButton2
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._RadioButton2 = value
				radioButton = Me._RadioButton2
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060D8 RID: 24792
		' (get) Token: 0x0600FD4A RID: 64842 RVA: 0x0006F073 File Offset: 0x0006D273
		' (set) Token: 0x0600FD4B RID: 64843 RVA: 0x00978274 File Offset: 0x00976474
		Private _RadioButton3 As RadioButton
		Friend Overridable Property RadioButton3 As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._RadioButton3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.Radiobutton3_CheckedChanged
				Dim radioButton As RadioButton = Me._RadioButton3
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._RadioButton3 = value
				radioButton = Me._RadioButton3
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060D9 RID: 24793
		' (get) Token: 0x0600FD4C RID: 64844 RVA: 0x0006F07D File Offset: 0x0006D27D
		' (set) Token: 0x0600FD4D RID: 64845 RVA: 0x009782B8 File Offset: 0x009764B8
		Private _RadioButton4 As RadioButton
		Friend Overridable Property RadioButton4 As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._RadioButton4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.RadioButton4_CheckedChanged
				Dim radioButton As RadioButton = Me._RadioButton4
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._RadioButton4 = value
				radioButton = Me._RadioButton4
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170060DA RID: 24794
		' (get) Token: 0x0600FD4E RID: 64846 RVA: 0x0006F087 File Offset: 0x0006D287
		' (set) Token: 0x0600FD4F RID: 64847 RVA: 0x009782FC File Offset: 0x009764FC
		Private _RadioButton5 As RadioButton
		Friend Overridable Property RadioButton5 As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._RadioButton5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.RadioButton5_CheckedChanged
				Dim radioButton As RadioButton = Me._RadioButton5
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._RadioButton5 = value
				radioButton = Me._RadioButton5
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600FD50 RID: 64848 RVA: 0x00978340 File Offset: 0x00976540
		Private Sub btnOkay_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Not Me.RadioButton1.Checked And Not Me.RadioButton2.Checked And Not Me.RadioButton3.Checked And Not Me.RadioButton4.Checked And Not Me.RadioButton5.Checked
			If flag Then
				MessageBox.Show("Please select the category ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Try
					Dim checked As Boolean = Me.RadioButton1.Checked
					If checked Then
						Dim flag2 As Boolean = Operators.CompareString(Me.txtDiscount.Text, "", False) = 0
						If flag2 Then
							MessageBox.Show("Please enter the value ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.txtDiscount.Focus()
							Return
						End If
						Dim flag3 As Boolean = MyProject.Forms.frmPOS.cmbDiscountType.SelectedIndex = 0
						If flag3 Then
							MyProject.Forms.frmPOS.txtDiscPer.Text = Me.txtDiscount.Text
						End If
						Dim flag4 As Boolean = MyProject.Forms.frmPOS.cmbDiscountType.SelectedIndex = 1
						If flag4 Then
							MyProject.Forms.frmPOS.txtDiscAmtPerQty.Text = Me.txtDiscount.Text
						End If
					End If
					Dim checked2 As Boolean = Me.RadioButton2.Checked
					If checked2 Then
						Dim flag5 As Boolean = Operators.CompareString(Me.txtDiscount.Text, "", False) = 0
						If flag5 Then
							MessageBox.Show("Please enter the value ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.txtDiscount.Focus()
							Return
						End If
						MyProject.Forms.frmPOS.txtSalesRate.Text = Me.txtDiscount.Text
					End If
					Dim checked3 As Boolean = Me.RadioButton3.Checked
					If checked3 Then
						Dim flag6 As Boolean = Operators.CompareString(Me.txtDiscount.Text, "", False) = 0
						If flag6 Then
							MessageBox.Show("Please enter the value ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.txtDiscount.Focus()
							Return
						End If
						MyProject.Forms.frmPOS.txtQty.Text = Me.txtDiscount.Text
					End If
					Dim checked4 As Boolean = Me.RadioButton4.Checked
					If checked4 Then
						Dim flag7 As Boolean = Operators.CompareString(Me.txtDiscount.Text, "", False) = 0
						If flag7 Then
							MessageBox.Show("Please enter the value ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.txtDiscount.Focus()
							Return
						End If
						MyProject.Forms.frmPOS.txtbilldisc.Text = Me.txtDiscount.Text
					End If
					Dim checked5 As Boolean = Me.RadioButton5.Checked
					If checked5 Then
						Dim flag8 As Boolean = Operators.CompareString(Me.txtDiscount.Text, "", False) = 0
						If flag8 Then
							MessageBox.Show("Please enter the value ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.txtDiscount.Focus()
						Else
							MyProject.Forms.frmPOS.txtApplyPoint.Text = Me.txtDiscount.Text
						End If
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600FD51 RID: 64849 RVA: 0x009786A8 File Offset: 0x009768A8
		Private Sub txtDiscount_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtDiscount.Text
					Dim selectionStart As Integer = Me.txtDiscount.SelectionStart
					Dim selectionLength As Integer = Me.txtDiscount.SelectionLength
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

		' Token: 0x0600FD52 RID: 64850 RVA: 0x009787A0 File Offset: 0x009769A0
		Private Sub btnTA1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.sign_Indicator = 0
			If flag Then
				Me.txtDiscount.Text = Me.txtDiscount.Text + Convert.ToString(1)
			Else
				Dim flag2 As Boolean = Me.sign_Indicator = 1
				If flag2 Then
					Me.txtDiscount.Text = Convert.ToString(1)
					Me.sign_Indicator = 0
				End If
			End If
			Me.fl = True
		End Sub

		' Token: 0x0600FD53 RID: 64851 RVA: 0x00978810 File Offset: 0x00976A10
		Private Sub btnTA2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.sign_Indicator = 0
			If flag Then
				Me.txtDiscount.Text = Me.txtDiscount.Text + Convert.ToString(2)
			Else
				Dim flag2 As Boolean = Me.sign_Indicator = 1
				If flag2 Then
					Me.txtDiscount.Text = Convert.ToString(2)
					Me.sign_Indicator = 0
				End If
			End If
			Me.fl = True
		End Sub

		' Token: 0x0600FD54 RID: 64852 RVA: 0x00978880 File Offset: 0x00976A80
		Private Sub btnTA3_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.sign_Indicator = 0
			If flag Then
				Me.txtDiscount.Text = Me.txtDiscount.Text + Convert.ToString(3)
			Else
				Dim flag2 As Boolean = Me.sign_Indicator = 1
				If flag2 Then
					Me.txtDiscount.Text = Convert.ToString(3)
					Me.sign_Indicator = 0
				End If
			End If
			Me.fl = True
		End Sub

		' Token: 0x0600FD55 RID: 64853 RVA: 0x009788F0 File Offset: 0x00976AF0
		Private Sub btnTA4_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.sign_Indicator = 0
			If flag Then
				Me.txtDiscount.Text = Me.txtDiscount.Text + Convert.ToString(4)
			Else
				Dim flag2 As Boolean = Me.sign_Indicator = 1
				If flag2 Then
					Me.txtDiscount.Text = Convert.ToString(4)
					Me.sign_Indicator = 0
				End If
			End If
			Me.fl = True
		End Sub

		' Token: 0x0600FD56 RID: 64854 RVA: 0x00978960 File Offset: 0x00976B60
		Private Sub btnTA5_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.sign_Indicator = 0
			If flag Then
				Me.txtDiscount.Text = Me.txtDiscount.Text + Convert.ToString(5)
			Else
				Dim flag2 As Boolean = Me.sign_Indicator = 1
				If flag2 Then
					Me.txtDiscount.Text = Convert.ToString(5)
					Me.sign_Indicator = 0
				End If
			End If
			Me.fl = True
		End Sub

		' Token: 0x0600FD57 RID: 64855 RVA: 0x009789D0 File Offset: 0x00976BD0
		Private Sub btnTA6_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.sign_Indicator = 0
			If flag Then
				Me.txtDiscount.Text = Me.txtDiscount.Text + Convert.ToString(6)
			Else
				Dim flag2 As Boolean = Me.sign_Indicator = 1
				If flag2 Then
					Me.txtDiscount.Text = Convert.ToString(6)
					Me.sign_Indicator = 0
				End If
			End If
			Me.fl = True
		End Sub

		' Token: 0x0600FD58 RID: 64856 RVA: 0x00978A40 File Offset: 0x00976C40
		Private Sub btnTA7_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.sign_Indicator = 0
			If flag Then
				Me.txtDiscount.Text = Me.txtDiscount.Text + Convert.ToString(7)
			Else
				Dim flag2 As Boolean = Me.sign_Indicator = 1
				If flag2 Then
					Me.txtDiscount.Text = Convert.ToString(7)
					Me.sign_Indicator = 0
				End If
			End If
			Me.fl = True
		End Sub

		' Token: 0x0600FD59 RID: 64857 RVA: 0x00978AB0 File Offset: 0x00976CB0
		Private Sub btnTA8_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.sign_Indicator = 0
			If flag Then
				Me.txtDiscount.Text = Me.txtDiscount.Text + Convert.ToString(8)
			Else
				Dim flag2 As Boolean = Me.sign_Indicator = 1
				If flag2 Then
					Me.txtDiscount.Text = Convert.ToString(8)
					Me.sign_Indicator = 0
				End If
			End If
			Me.fl = True
		End Sub

		' Token: 0x0600FD5A RID: 64858 RVA: 0x00978B20 File Offset: 0x00976D20
		Private Sub btnTA9_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.sign_Indicator = 0
			If flag Then
				Me.txtDiscount.Text = Me.txtDiscount.Text + Convert.ToString(9)
			Else
				Dim flag2 As Boolean = Me.sign_Indicator = 1
				If flag2 Then
					Me.txtDiscount.Text = Convert.ToString(9)
					Me.sign_Indicator = 0
				End If
			End If
			Me.fl = True
		End Sub

		' Token: 0x0600FD5B RID: 64859 RVA: 0x00978B90 File Offset: 0x00976D90
		Private Sub btnTAComma_Click(sender As Object, e As EventArgs)
			Dim num As Integer = 0
			Dim num2 As Integer = Me.txtDiscount.Text.Length - 1
			Dim flag As Boolean = Me.sign_Indicator <> 1
			If flag Then
				Dim num3 As Integer = num2
				For i As Integer = 0 To num3
					Dim c As Char = Me.txtDiscount.Text(i)
					Dim flag2 As Boolean = c = "."c
					If flag2 Then
						num = 1
					End If
				Next
				Dim flag3 As Boolean = num <> 1
				If flag3 Then
					Me.txtDiscount.Text = Me.txtDiscount.Text + Convert.ToString(".")
				End If
			End If
		End Sub

		' Token: 0x0600FD5C RID: 64860 RVA: 0x00978C34 File Offset: 0x00976E34
		Private Sub btnTA0_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.sign_Indicator = 0
			If flag Then
				Me.txtDiscount.Text = Me.txtDiscount.Text + Convert.ToString(0)
			Else
				Dim flag2 As Boolean = Me.sign_Indicator = 1
				If flag2 Then
					Me.txtDiscount.Text = Convert.ToString(0)
					Me.sign_Indicator = 0
				End If
			End If
			Me.fl = True
		End Sub

		' Token: 0x0600FD5D RID: 64861 RVA: 0x00978CA4 File Offset: 0x00976EA4
		Private Sub btnTAx_Click(sender As Object, e As EventArgs)
			Me.s = Me.txtDiscount.Text
			Dim length As Integer = Me.s.Length
			Dim num As Integer = length - 2
			For i As Integer = 0 To num
				Me.x = Me.x + Conversions.ToString(Me.s(i))
			Next
			Me.txtDiscount.Text = Me.x
			Me.x = ""
		End Sub

		' Token: 0x0600FD5E RID: 64862 RVA: 0x00978D20 File Offset: 0x00976F20
		Private Sub btnClear_Click(sender As Object, e As EventArgs)
			Me.txtDiscount.Text = ""
			Me.RadioButton1.Checked = False
			Me.RadioButton2.Checked = False
			Me.RadioButton3.Checked = False
			Me.RadioButton4.Checked = False
			Me.RadioButton5.Checked = False
		End Sub

		' Token: 0x0600FD5F RID: 64863 RVA: 0x0006F091 File Offset: 0x0006D291
		Private Sub Radiobutton2_CheckedChanged(sender As Object, e As EventArgs)
			Me.cbcondition()
		End Sub

		' Token: 0x0600FD60 RID: 64864 RVA: 0x0006F091 File Offset: 0x0006D291
		Private Sub Radiobutton3_CheckedChanged(sender As Object, e As EventArgs)
			Me.cbcondition()
		End Sub

		' Token: 0x0600FD61 RID: 64865 RVA: 0x0006F091 File Offset: 0x0006D291
		Private Sub Radiobutton1_CheckedChanged(sender As Object, e As EventArgs)
			Me.cbcondition()
		End Sub

		' Token: 0x0600FD62 RID: 64866 RVA: 0x0006F091 File Offset: 0x0006D291
		Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs)
			Me.cbcondition()
		End Sub

		' Token: 0x0600FD63 RID: 64867 RVA: 0x0006F091 File Offset: 0x0006D291
		Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs)
			Me.cbcondition()
		End Sub

		' Token: 0x0600FD64 RID: 64868 RVA: 0x00978D20 File Offset: 0x00976F20
		Private Sub frmSetBillDiscount_Load(sender As Object, e As EventArgs)
			Me.txtDiscount.Text = ""
			Me.RadioButton1.Checked = False
			Me.RadioButton2.Checked = False
			Me.RadioButton3.Checked = False
			Me.RadioButton4.Checked = False
			Me.RadioButton5.Checked = False
		End Sub

		' Token: 0x0600FD65 RID: 64869 RVA: 0x00978D80 File Offset: 0x00976F80
		Private Sub cbcondition()
			Dim checked As Boolean = Me.RadioButton1.Checked
			If checked Then
				Me.RadioButton2.Checked = False
				Me.RadioButton3.Checked = False
				Me.RadioButton4.Checked = False
				Me.RadioButton5.Checked = False
			Else
				Dim checked2 As Boolean = Me.RadioButton2.Checked
				If checked2 Then
					Me.RadioButton1.Checked = False
					Me.RadioButton3.Checked = False
					Me.RadioButton4.Checked = False
					Me.RadioButton5.Checked = False
				Else
					Dim checked3 As Boolean = Me.RadioButton3.Checked
					If checked3 Then
						Me.RadioButton1.Checked = False
						Me.RadioButton2.Checked = False
						Me.RadioButton4.Checked = False
						Me.RadioButton5.Checked = False
					Else
						Dim checked4 As Boolean = Me.RadioButton4.Checked
						If checked4 Then
							Me.RadioButton1.Checked = False
							Me.RadioButton2.Checked = False
							Me.RadioButton3.Checked = False
							Me.RadioButton5.Checked = False
						Else
							Dim checked5 As Boolean = Me.RadioButton5.Checked
							If checked5 Then
								Me.RadioButton1.Checked = False
								Me.RadioButton2.Checked = False
								Me.RadioButton3.Checked = False
								Me.RadioButton4.Checked = False
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600FD66 RID: 64870 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSetBillDiscount_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x04006101 RID: 24833
		Private sign_Indicator As Integer

		' Token: 0x04006102 RID: 24834
		Private variable1 As Double

		' Token: 0x04006103 RID: 24835
		Private variable2 As Double

		' Token: 0x04006104 RID: 24836
		Private fl As Boolean

		' Token: 0x04006105 RID: 24837
		Private s As String

		' Token: 0x04006106 RID: 24838
		Private x As String
	End Class
End Namespace
