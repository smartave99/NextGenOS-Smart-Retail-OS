Imports System
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000210 RID: 528
	<DesignerGenerated()>
	Public Partial Class frmUnitButton
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06009906 RID: 39174 RVA: 0x006DDB38 File Offset: 0x006DBD38
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmUnitButton_Load
			AddHandler MyBase.Closed, AddressOf Me.frmUnitButton_Closed
			AddHandler MyBase.KeyDown, AddressOf Me.frmUnitButton_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170038D6 RID: 14550
		' (get) Token: 0x06009909 RID: 39177 RVA: 0x0004ABE4 File Offset: 0x00048DE4
		' (set) Token: 0x0600990A RID: 39178 RVA: 0x006DE4E0 File Offset: 0x006DC6E0
		Private _Button3 As Button
		Friend Overridable Property Button3 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button3_Click
				Dim button As Button = Me._Button3
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button3 = value
				button = Me._Button3
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170038D7 RID: 14551
		' (get) Token: 0x0600990B RID: 39179 RVA: 0x0004ABEE File Offset: 0x00048DEE
		' (set) Token: 0x0600990C RID: 39180 RVA: 0x006DE524 File Offset: 0x006DC724
		Private _Button2 As Button
		Friend Overridable Property Button2 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click
				Dim button As Button = Me._Button2
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button2 = value
				button = Me._Button2
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170038D8 RID: 14552
		' (get) Token: 0x0600990D RID: 39181 RVA: 0x0004ABF8 File Offset: 0x00048DF8
		' (set) Token: 0x0600990E RID: 39182 RVA: 0x0004AC02 File Offset: 0x00048E02
		Friend Overridable Property Label1 As Label

		' Token: 0x170038D9 RID: 14553
		' (get) Token: 0x0600990F RID: 39183 RVA: 0x0004AC0B File Offset: 0x00048E0B
		' (set) Token: 0x06009910 RID: 39184 RVA: 0x0004AC15 File Offset: 0x00048E15
		Friend Overridable Property lblBarcode As Label

		' Token: 0x170038DA RID: 14554
		' (get) Token: 0x06009911 RID: 39185 RVA: 0x0004AC1E File Offset: 0x00048E1E
		' (set) Token: 0x06009912 RID: 39186 RVA: 0x0004AC28 File Offset: 0x00048E28
		Friend Overridable Property Label2 As Label

		' Token: 0x170038DB RID: 14555
		' (get) Token: 0x06009913 RID: 39187 RVA: 0x0004AC31 File Offset: 0x00048E31
		' (set) Token: 0x06009914 RID: 39188 RVA: 0x0004AC3B File Offset: 0x00048E3B
		Friend Overridable Property Label3 As Label

		' Token: 0x170038DC RID: 14556
		' (get) Token: 0x06009915 RID: 39189 RVA: 0x0004AC44 File Offset: 0x00048E44
		' (set) Token: 0x06009916 RID: 39190 RVA: 0x0004AC4E File Offset: 0x00048E4E
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170038DD RID: 14557
		' (get) Token: 0x06009917 RID: 39191 RVA: 0x0004AC57 File Offset: 0x00048E57
		' (set) Token: 0x06009918 RID: 39192 RVA: 0x0004AC61 File Offset: 0x00048E61
		Friend Overridable Property Label4 As Label

		' Token: 0x170038DE RID: 14558
		' (get) Token: 0x06009919 RID: 39193 RVA: 0x0004AC6A File Offset: 0x00048E6A
		' (set) Token: 0x0600991A RID: 39194 RVA: 0x006DE568 File Offset: 0x006DC768
		Private _txtDefQty As TextBox
		Friend Overridable Property txtDefQty As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDefQty
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtDefQty_KeyDown
				Dim textBox As TextBox = Me._txtDefQty
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtDefQty = value
				textBox = Me._txtDefQty
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170038DF RID: 14559
		' (get) Token: 0x0600991B RID: 39195 RVA: 0x0004AC74 File Offset: 0x00048E74
		' (set) Token: 0x0600991C RID: 39196 RVA: 0x0004AC7E File Offset: 0x00048E7E
		Friend Overridable Property Label5 As Label

		' Token: 0x170038E0 RID: 14560
		' (get) Token: 0x0600991D RID: 39197 RVA: 0x0004AC87 File Offset: 0x00048E87
		' (set) Token: 0x0600991E RID: 39198 RVA: 0x0004AC91 File Offset: 0x00048E91
		Friend Overridable Property Label6 As Label

		' Token: 0x0600991F RID: 39199 RVA: 0x006DE5AC File Offset: 0x006DC7AC
		Private Sub frmUnitButton_Load(sender As Object, e As EventArgs)
			Me.txtDefQty.Focus()
			Me.txtDefQty.ScrollToCaret()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
			ModCommonClasses.cmd.CommandText = "SELECT PID, RTRIM(ProductName),RTRIM(SalesUnit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(Product.DefQty) from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Temp_Stock.Barcode=@d1"
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.lblBarcode.Text)
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = ModCommonClasses.rdr.Read()
			If flag Then
				Me.mainunit = ModCommonClasses.rdr.GetValue(2).ToString()
				Me.alterunit = ModCommonClasses.rdr.GetValue(3).ToString()
				Me.alterunit1 = ModCommonClasses.rdr.GetValue(3).ToString()
				Me.textbox3unit = ModCommonClasses.rdr.GetValue(4).ToString()
				Me.lblalterunit = ModCommonClasses.rdr.GetValue(4).ToString()
				Me.defqtyx = ModCommonClasses.rdr.GetValue(5).ToString()
				Me.txtDefQty.Text = ModCommonClasses.rdr.GetValue(5).ToString()
				Me.Button2.Text = Me.mainunit + vbCrLf & vbCrLf & "Value = 1"
				Me.Button3.Text = Me.alterunit + vbCrLf & vbCrLf & "Value = " + ModCommonClasses.rdr.GetValue(4).ToString()
			End If
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x06009920 RID: 39200 RVA: 0x006DE740 File Offset: 0x006DC940
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.Label6.Text, "POINT OF SALE", False) = 0
			If flag Then
				MyProject.Forms.frmPOS.cmbUnit.Text = Me.mainunit
				MyProject.Forms.frmPOS.cmbaltunit.Text = Me.alterunit
				MyProject.Forms.frmPOS.lblAltUnit.Text = Me.alterunit1
				MyProject.Forms.frmPOS.TextBox3.Text = Me.textbox3unit
				MyProject.Forms.frmPOS.lblAltValue.Text = Me.lblalterunit
				MyProject.Forms.frmPOS.txtQty.Text = Me.txtDefQty.Text
				MyProject.Forms.frmPOS.BarcodeProgram()
			End If
			Dim flag2 As Boolean = Operators.CompareString(Me.Label6.Text, "POINT OF SALE TOUCH", False) = 0
			If flag2 Then
				MyProject.Forms.frmPOSTouch.cmbUnit.Text = Me.mainunit
				MyProject.Forms.frmPOSTouch.cmbaltunit.Text = Me.alterunit
				MyProject.Forms.frmPOSTouch.lblAltUnit.Text = Me.alterunit1
				MyProject.Forms.frmPOSTouch.TextBox3.Text = Me.textbox3unit
				MyProject.Forms.frmPOSTouch.lblAltValue.Text = Me.lblalterunit
				MyProject.Forms.frmPOSTouch.txtQty.Text = Me.txtDefQty.Text
				MyProject.Forms.frmPOSTouch.BarcodeProgram()
			End If
			Dim flag3 As Boolean = Operators.CompareString(Me.Label6.Text, "POINT OF SALE TOUCHnew", False) = 0
			If flag3 Then
				MyProject.Forms.frmPOSNewTuch.cmbUnit.Text = Me.mainunit
				MyProject.Forms.frmPOSNewTuch.cmbaltunit.Text = Me.alterunit
				MyProject.Forms.frmPOSNewTuch.lblAltUnit.Text = Me.alterunit1
				MyProject.Forms.frmPOSNewTuch.TextBox3.Text = Me.textbox3unit
				MyProject.Forms.frmPOSNewTuch.lblAltValue.Text = Me.lblalterunit
				MyProject.Forms.frmPOSNewTuch.txtQty.Text = Me.txtDefQty.Text
				MyProject.Forms.frmPOSNewTuch.BarcodeProgram()
			End If
			Dim flag4 As Boolean = Operators.CompareString(Me.Label6.Text, "BARCODE_POINT OF SALE", False) = 0
			If flag4 Then
				MyProject.Forms.frmPOS.cmbUnit.Text = Me.mainunit
				MyProject.Forms.frmPOS.cmbaltunit.Text = Me.alterunit
				MyProject.Forms.frmPOS.lblAltUnit.Text = Me.alterunit1
				MyProject.Forms.frmPOS.TextBox3.Text = Me.textbox3unit
				MyProject.Forms.frmPOS.lblAltValue.Text = Me.lblalterunit
				MyProject.Forms.frmPOS.txtQty.Text = Me.txtDefQty.Text
				MyProject.Forms.frmPOS.Barcode_Entry1()
			End If
			Dim flag5 As Boolean = Operators.CompareString(Me.Label6.Text, "BARCODE_POINT OF SALE TOUCH", False) = 0
			If flag5 Then
				MyProject.Forms.frmPOSTouch.cmbUnit.Text = Me.mainunit
				MyProject.Forms.frmPOSTouch.cmbaltunit.Text = Me.alterunit
				MyProject.Forms.frmPOSTouch.lblAltUnit.Text = Me.alterunit1
				MyProject.Forms.frmPOSTouch.TextBox3.Text = Me.textbox3unit
				MyProject.Forms.frmPOSTouch.lblAltValue.Text = Me.lblalterunit
				MyProject.Forms.frmPOSTouch.txtQty.Text = Me.txtDefQty.Text
				MyProject.Forms.frmPOSTouch.Barcode_Entry1()
			End If
			Dim flag6 As Boolean = Operators.CompareString(Me.Label6.Text, "BARCODE_POINT OF SALE TOUCHnew", False) = 0
			If flag6 Then
				MyProject.Forms.frmPOSNewTuch.cmbUnit.Text = Me.mainunit
				MyProject.Forms.frmPOSNewTuch.cmbaltunit.Text = Me.alterunit
				MyProject.Forms.frmPOSNewTuch.lblAltUnit.Text = Me.alterunit1
				MyProject.Forms.frmPOSNewTuch.TextBox3.Text = Me.textbox3unit
				MyProject.Forms.frmPOSNewTuch.lblAltValue.Text = Me.lblalterunit
				MyProject.Forms.frmPOSNewTuch.txtQty.Text = Me.txtDefQty.Text
				MyProject.Forms.frmPOSNewTuch.Barcode_Entry1()
			End If
			MyBase.Close()
		End Sub

		' Token: 0x06009921 RID: 39201 RVA: 0x006DEC70 File Offset: 0x006DCE70
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.Label6.Text, "POINT OF SALE", False) = 0
			If flag Then
				Me.unitcalc()
				MyProject.Forms.frmPOS.cmbUnit.Text = Me.mainunit
				MyProject.Forms.frmPOS.cmbaltunit.Text = Me.alterunit
				MyProject.Forms.frmPOS.lblAltUnit.Text = Me.alterunit1
				MyProject.Forms.frmPOS.TextBox3.Text = Me.textbox3unit
				MyProject.Forms.frmPOS.lblAltValue.Text = Me.lblalterunit
				MyProject.Forms.frmPOS.txtQty.Text = Conversions.ToString(Me.calvalue)
				MyProject.Forms.frmPOS.BarcodeProgram()
			End If
			Dim flag2 As Boolean = Operators.CompareString(Me.Label6.Text, "POINT OF SALE TOUCH", False) = 0
			If flag2 Then
				Me.unitcalc()
				MyProject.Forms.frmPOSTouch.cmbUnit.Text = Me.mainunit
				MyProject.Forms.frmPOSTouch.cmbaltunit.Text = Me.alterunit
				MyProject.Forms.frmPOSTouch.lblAltUnit.Text = Me.alterunit1
				MyProject.Forms.frmPOSTouch.TextBox3.Text = Me.textbox3unit
				MyProject.Forms.frmPOSTouch.lblAltValue.Text = Me.lblalterunit
				MyProject.Forms.frmPOSTouch.txtQty.Text = Conversions.ToString(Me.calvalue)
				MyProject.Forms.frmPOSTouch.BarcodeProgram()
			End If
			Dim flag3 As Boolean = Operators.CompareString(Me.Label6.Text, "POINT OF SALE TOUCHNew", False) = 0
			If flag3 Then
				Me.unitcalc()
				MyProject.Forms.frmPOSNewTuch.cmbUnit.Text = Me.mainunit
				MyProject.Forms.frmPOSNewTuch.cmbaltunit.Text = Me.alterunit
				MyProject.Forms.frmPOSNewTuch.lblAltUnit.Text = Me.alterunit1
				MyProject.Forms.frmPOSNewTuch.TextBox3.Text = Me.textbox3unit
				MyProject.Forms.frmPOSNewTuch.lblAltValue.Text = Me.lblalterunit
				MyProject.Forms.frmPOSNewTuch.txtQty.Text = Conversions.ToString(Me.calvalue)
				MyProject.Forms.frmPOSNewTuch.BarcodeProgram()
			End If
			Dim flag4 As Boolean = Operators.CompareString(Me.Label6.Text, "BARCODE_POINT OF SALE", False) = 0
			If flag4 Then
				Me.unitcalc()
				MyProject.Forms.frmPOS.cmbUnit.Text = Me.mainunit
				MyProject.Forms.frmPOS.cmbaltunit.Text = Me.alterunit
				MyProject.Forms.frmPOS.lblAltUnit.Text = Me.alterunit1
				MyProject.Forms.frmPOS.TextBox3.Text = Me.textbox3unit
				MyProject.Forms.frmPOS.lblAltValue.Text = Me.lblalterunit
				MyProject.Forms.frmPOS.txtQty.Text = Conversions.ToString(Me.calvalue)
				MyProject.Forms.frmPOS.Barcode_Entry1()
			End If
			Dim flag5 As Boolean = Operators.CompareString(Me.Label6.Text, "BARCODE_POINT OF SALE TOUCH", False) = 0
			If flag5 Then
				Me.unitcalc()
				MyProject.Forms.frmPOSTouch.cmbUnit.Text = Me.mainunit
				MyProject.Forms.frmPOSTouch.cmbaltunit.Text = Me.alterunit
				MyProject.Forms.frmPOSTouch.lblAltUnit.Text = Me.alterunit1
				MyProject.Forms.frmPOSTouch.TextBox3.Text = Me.textbox3unit
				MyProject.Forms.frmPOSTouch.lblAltValue.Text = Me.lblalterunit
				MyProject.Forms.frmPOSTouch.txtQty.Text = Conversions.ToString(Me.calvalue)
				MyProject.Forms.frmPOSTouch.Barcode_Entry1()
			End If
			Dim flag6 As Boolean = Operators.CompareString(Me.Label6.Text, "BARCODE_POINT OF SALE TOUCHnew", False) = 0
			If flag6 Then
				Me.unitcalc()
				MyProject.Forms.frmPOSNewTuch.cmbUnit.Text = Me.mainunit
				MyProject.Forms.frmPOSNewTuch.cmbaltunit.Text = Me.alterunit
				MyProject.Forms.frmPOSNewTuch.lblAltUnit.Text = Me.alterunit1
				MyProject.Forms.frmPOSNewTuch.TextBox3.Text = Me.textbox3unit
				MyProject.Forms.frmPOSNewTuch.lblAltValue.Text = Me.lblalterunit
				MyProject.Forms.frmPOSNewTuch.txtQty.Text = Conversions.ToString(Me.calvalue)
				MyProject.Forms.frmPOSNewTuch.Barcode_Entry1()
			End If
			MyBase.Close()
		End Sub

		' Token: 0x06009922 RID: 39202 RVA: 0x006DF1CC File Offset: 0x006DD3CC
		Public Sub unitcalc()
			Me.calvalue = 1.0 / Conversion.Val(Me.lblalterunit) * Conversion.Val(Me.txtDefQty.Text)
			Me.Label1.Text = Conversions.ToString(Me.calvalue)
		End Sub

		' Token: 0x06009923 RID: 39203 RVA: 0x0004AC9A File Offset: 0x00048E9A
		Private Sub frmUnitButton_Closed(sender As Object, e As EventArgs)
			Me.lblBarcode.Text = ""
			Me.txtDefQty.Focus()
			Me.txtDefQty.ScrollToCaret()
		End Sub

		' Token: 0x06009924 RID: 39204 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtDefQty_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06009925 RID: 39205 RVA: 0x00180440 File Offset: 0x0017E640
		Private Sub frmUnitButton_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				MyBase.Close()
			End If
		End Sub

		' Token: 0x040043BC RID: 17340
		Private mainunit As String

		' Token: 0x040043BD RID: 17341
		Private alterunit As String

		' Token: 0x040043BE RID: 17342
		Private alterunit1 As String

		' Token: 0x040043BF RID: 17343
		Private textbox3unit As String

		' Token: 0x040043C0 RID: 17344
		Private lblalterunit As String

		' Token: 0x040043C1 RID: 17345
		Private defqtyx As String

		' Token: 0x040043C2 RID: 17346
		Private calvalue As Double
	End Class
End Namespace
