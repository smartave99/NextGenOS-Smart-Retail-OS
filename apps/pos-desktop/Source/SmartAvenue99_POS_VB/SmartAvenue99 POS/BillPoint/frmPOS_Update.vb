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
	' Token: 0x020001D1 RID: 465
	<DesignerGenerated()>
	Public Partial Class frmPOS_Update
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06007960 RID: 31072 RVA: 0x0003C1AB File Offset: 0x0003A3AB
		Public Sub New()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17002C90 RID: 11408
		' (get) Token: 0x06007963 RID: 31075 RVA: 0x0003C1B9 File Offset: 0x0003A3B9
		' (set) Token: 0x06007964 RID: 31076 RVA: 0x0003C1C3 File Offset: 0x0003A3C3
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17002C91 RID: 11409
		' (get) Token: 0x06007965 RID: 31077 RVA: 0x0003C1CC File Offset: 0x0003A3CC
		' (set) Token: 0x06007966 RID: 31078 RVA: 0x0003C1D6 File Offset: 0x0003A3D6
		Friend Overridable Property txtInput As TextBox

		' Token: 0x17002C92 RID: 11410
		' (get) Token: 0x06007967 RID: 31079 RVA: 0x0003C1DF File Offset: 0x0003A3DF
		' (set) Token: 0x06007968 RID: 31080 RVA: 0x005AAF50 File Offset: 0x005A9150
		Private _btnUpdate As Button
		Friend Overridable Property btnUpdate As Button
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim button As Button = Me._btnUpdate
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnUpdate = value
				button = Me._btnUpdate
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002C93 RID: 11411
		' (get) Token: 0x06007969 RID: 31081 RVA: 0x0003C1E9 File Offset: 0x0003A3E9
		' (set) Token: 0x0600796A RID: 31082 RVA: 0x0003C1F3 File Offset: 0x0003A3F3
		Friend Overridable Property Label1 As Label

		' Token: 0x17002C94 RID: 11412
		' (get) Token: 0x0600796B RID: 31083 RVA: 0x0003C1FC File Offset: 0x0003A3FC
		' (set) Token: 0x0600796C RID: 31084 RVA: 0x0003C206 File Offset: 0x0003A406
		Friend Overridable Property Label2 As Label

		' Token: 0x17002C95 RID: 11413
		' (get) Token: 0x0600796D RID: 31085 RVA: 0x0003C20F File Offset: 0x0003A40F
		' (set) Token: 0x0600796E RID: 31086 RVA: 0x0003C219 File Offset: 0x0003A419
		Friend Overridable Property Label3 As Label

		' Token: 0x0600796F RID: 31087 RVA: 0x005AAF94 File Offset: 0x005A9194
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.Label1.Text, "QtyG", False) = 0
			If flag Then
				MyProject.Forms.frmPOSTouch.txtQty.Text = Me.txtInput.Text
				MyProject.Forms.frmPOSTouch.Sale_D_Update(Me.Label3.Text, Conversions.ToInteger(Me.txtInput.Text))
				MyBase.Close()
			End If
			Dim flag2 As Boolean = Operators.CompareString(Me.Label1.Text, "Discount_PercentageG", False) = 0
			If flag2 Then
				MyProject.Forms.frmPOSTouch.txtDiscPer.Text = Me.txtInput.Text
				MyProject.Forms.frmPOSTouch.Sale_D_Update_DiscountPer(Me.Label3.Text, Conversions.ToDouble(Me.txtInput.Text))
				MyBase.Close()
			End If
			Dim flag3 As Boolean = Operators.CompareString(Me.Label1.Text, "Discount_AmountG", False) = 0
			If flag3 Then
				MyProject.Forms.frmPOSTouch.txtDisc.Text = Me.txtInput.Text
				MyProject.Forms.frmPOSTouch.Sale_D_Update_DiscountAmt(Me.Label3.Text, Conversions.ToDouble(Me.txtInput.Text))
				MyBase.Close()
			End If
			Dim flag4 As Boolean = Operators.CompareString(Me.Label1.Text, "Qty", False) = 0
			If flag4 Then
				MyProject.Forms.frmPOSTouch.txtQty.Text = Me.txtInput.Text
				MyProject.Forms.frmPOSTouch.btnListUpdate.PerformClick()
				MyBase.Close()
			End If
			Dim flag5 As Boolean = Operators.CompareString(Me.Label1.Text, "Discount_Percentage", False) = 0
			If flag5 Then
				MyProject.Forms.frmPOSTouch.cmbDiscountType.Text = "%"
				MyProject.Forms.frmPOSTouch.txtDiscPer.Text = Me.txtInput.Text
				MyProject.Forms.frmPOSTouch.btnListUpdate.PerformClick()
				MyBase.Close()
			End If
			Dim flag6 As Boolean = Operators.CompareString(Me.Label1.Text, "Discount_Amount", False) = 0
			If flag6 Then
				MyProject.Forms.frmPOSTouch.cmbDiscountType.Text = "Amt"
				MyProject.Forms.frmPOSTouch.txtDisc.Text = Me.txtInput.Text
				MyProject.Forms.frmPOSTouch.btnListUpdate.PerformClick()
				MyBase.Close()
			End If
			Dim flag7 As Boolean = Operators.CompareString(Me.Label1.Text, "Bill_Discount_Amount", False) = 0
			If flag7 Then
				MyProject.Forms.frmPOSTouch.Bill_Update_DiscountAmt(Conversions.ToDecimal(Me.txtInput.Text))
				MyBase.Close()
			End If
		End Sub
	End Class
End Namespace
