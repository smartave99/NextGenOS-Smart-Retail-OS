Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports DevNet.GS
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000213 RID: 531
	<DesignerGenerated()>
	Public Partial Class FrmValidate1
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600998E RID: 39310 RVA: 0x0004AFD8 File Offset: 0x000491D8
		Public Sub New()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17003906 RID: 14598
		' (get) Token: 0x06009991 RID: 39313 RVA: 0x0004AFE6 File Offset: 0x000491E6
		' (set) Token: 0x06009992 RID: 39314 RVA: 0x0004AFF0 File Offset: 0x000491F0
		Friend Overridable Property Label1 As Label

		' Token: 0x17003907 RID: 14599
		' (get) Token: 0x06009993 RID: 39315 RVA: 0x0004AFF9 File Offset: 0x000491F9
		' (set) Token: 0x06009994 RID: 39316 RVA: 0x0004B003 File Offset: 0x00049203
		Friend Overridable Property TBoxGSTIN As TextBox

		' Token: 0x17003908 RID: 14600
		' (get) Token: 0x06009995 RID: 39317 RVA: 0x0004B00C File Offset: 0x0004920C
		' (set) Token: 0x06009996 RID: 39318 RVA: 0x006E3E78 File Offset: 0x006E2078
		Private _BtnValidate As Button
		Friend Overridable Property BtnValidate As Button
			<CompilerGenerated()>
			Get
				Return Me._BtnValidate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.BtnValidate_Click
				Dim button As Button = Me._BtnValidate
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._BtnValidate = value
				button = Me._BtnValidate
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003909 RID: 14601
		' (get) Token: 0x06009997 RID: 39319 RVA: 0x0004B016 File Offset: 0x00049216
		' (set) Token: 0x06009998 RID: 39320 RVA: 0x0004B020 File Offset: 0x00049220
		Friend Overridable Property Label2 As Label

		' Token: 0x1700390A RID: 14602
		' (get) Token: 0x06009999 RID: 39321 RVA: 0x0004B029 File Offset: 0x00049229
		' (set) Token: 0x0600999A RID: 39322 RVA: 0x0004B033 File Offset: 0x00049233
		Friend Overridable Property Label3 As Label

		' Token: 0x1700390B RID: 14603
		' (get) Token: 0x0600999B RID: 39323 RVA: 0x0004B03C File Offset: 0x0004923C
		' (set) Token: 0x0600999C RID: 39324 RVA: 0x0004B046 File Offset: 0x00049246
		Friend Overridable Property Label4 As Label

		' Token: 0x1700390C RID: 14604
		' (get) Token: 0x0600999D RID: 39325 RVA: 0x0004B04F File Offset: 0x0004924F
		' (set) Token: 0x0600999E RID: 39326 RVA: 0x0004B059 File Offset: 0x00049259
		Friend Overridable Property Label5 As Label

		' Token: 0x1700390D RID: 14605
		' (get) Token: 0x0600999F RID: 39327 RVA: 0x0004B062 File Offset: 0x00049262
		' (set) Token: 0x060099A0 RID: 39328 RVA: 0x0004B06C File Offset: 0x0004926C
		Friend Overridable Property Label6 As Label

		' Token: 0x1700390E RID: 14606
		' (get) Token: 0x060099A1 RID: 39329 RVA: 0x0004B075 File Offset: 0x00049275
		' (set) Token: 0x060099A2 RID: 39330 RVA: 0x0004B07F File Offset: 0x0004927F
		Friend Overridable Property Label7 As Label

		' Token: 0x1700390F RID: 14607
		' (get) Token: 0x060099A3 RID: 39331 RVA: 0x0004B088 File Offset: 0x00049288
		' (set) Token: 0x060099A4 RID: 39332 RVA: 0x0004B092 File Offset: 0x00049292
		Friend Overridable Property Label8 As Label

		' Token: 0x17003910 RID: 14608
		' (get) Token: 0x060099A5 RID: 39333 RVA: 0x0004B09B File Offset: 0x0004929B
		' (set) Token: 0x060099A6 RID: 39334 RVA: 0x0004B0A5 File Offset: 0x000492A5
		Friend Overridable Property Label9 As Label

		' Token: 0x17003911 RID: 14609
		' (get) Token: 0x060099A7 RID: 39335 RVA: 0x0004B0AE File Offset: 0x000492AE
		' (set) Token: 0x060099A8 RID: 39336 RVA: 0x0004B0B8 File Offset: 0x000492B8
		Friend Overridable Property Label10 As Label

		' Token: 0x17003912 RID: 14610
		' (get) Token: 0x060099A9 RID: 39337 RVA: 0x0004B0C1 File Offset: 0x000492C1
		' (set) Token: 0x060099AA RID: 39338 RVA: 0x0004B0CB File Offset: 0x000492CB
		Friend Overridable Property Label11 As Label

		' Token: 0x17003913 RID: 14611
		' (get) Token: 0x060099AB RID: 39339 RVA: 0x0004B0D4 File Offset: 0x000492D4
		' (set) Token: 0x060099AC RID: 39340 RVA: 0x0004B0DE File Offset: 0x000492DE
		Friend Overridable Property Label12 As Label

		' Token: 0x17003914 RID: 14612
		' (get) Token: 0x060099AD RID: 39341 RVA: 0x0004B0E7 File Offset: 0x000492E7
		' (set) Token: 0x060099AE RID: 39342 RVA: 0x0004B0F1 File Offset: 0x000492F1
		Friend Overridable Property ValFilFreq As Label

		' Token: 0x17003915 RID: 14613
		' (get) Token: 0x060099AF RID: 39343 RVA: 0x0004B0FA File Offset: 0x000492FA
		' (set) Token: 0x060099B0 RID: 39344 RVA: 0x0004B104 File Offset: 0x00049304
		Friend Overridable Property ValLstValOn As Label

		' Token: 0x17003916 RID: 14614
		' (get) Token: 0x060099B1 RID: 39345 RVA: 0x0004B10D File Offset: 0x0004930D
		' (set) Token: 0x060099B2 RID: 39346 RVA: 0x0004B117 File Offset: 0x00049317
		Friend Overridable Property ValCanDate As Label

		' Token: 0x17003917 RID: 14615
		' (get) Token: 0x060099B3 RID: 39347 RVA: 0x0004B120 File Offset: 0x00049320
		' (set) Token: 0x060099B4 RID: 39348 RVA: 0x0004B12A File Offset: 0x0004932A
		Friend Overridable Property ValRegDate As Label

		' Token: 0x17003918 RID: 14616
		' (get) Token: 0x060099B5 RID: 39349 RVA: 0x0004B133 File Offset: 0x00049333
		' (set) Token: 0x060099B6 RID: 39350 RVA: 0x0004B13D File Offset: 0x0004933D
		Friend Overridable Property ValCoB As Label

		' Token: 0x17003919 RID: 14617
		' (get) Token: 0x060099B7 RID: 39351 RVA: 0x0004B146 File Offset: 0x00049346
		' (set) Token: 0x060099B8 RID: 39352 RVA: 0x0004B150 File Offset: 0x00049350
		Friend Overridable Property ValType As Label

		' Token: 0x1700391A RID: 14618
		' (get) Token: 0x060099B9 RID: 39353 RVA: 0x0004B159 File Offset: 0x00049359
		' (set) Token: 0x060099BA RID: 39354 RVA: 0x0004B163 File Offset: 0x00049363
		Friend Overridable Property ValState As Label

		' Token: 0x1700391B RID: 14619
		' (get) Token: 0x060099BB RID: 39355 RVA: 0x0004B16C File Offset: 0x0004936C
		' (set) Token: 0x060099BC RID: 39356 RVA: 0x0004B176 File Offset: 0x00049376
		Friend Overridable Property ValLegalName As Label

		' Token: 0x1700391C RID: 14620
		' (get) Token: 0x060099BD RID: 39357 RVA: 0x0004B17F File Offset: 0x0004937F
		' (set) Token: 0x060099BE RID: 39358 RVA: 0x0004B189 File Offset: 0x00049389
		Friend Overridable Property ValTradeName As Label

		' Token: 0x1700391D RID: 14621
		' (get) Token: 0x060099BF RID: 39359 RVA: 0x0004B192 File Offset: 0x00049392
		' (set) Token: 0x060099C0 RID: 39360 RVA: 0x0004B19C File Offset: 0x0004939C
		Friend Overridable Property ValStatus As Label

		' Token: 0x1700391E RID: 14622
		' (get) Token: 0x060099C1 RID: 39361 RVA: 0x0004B1A5 File Offset: 0x000493A5
		' (set) Token: 0x060099C2 RID: 39362 RVA: 0x0004B1AF File Offset: 0x000493AF
		Friend Overridable Property BtnQuit As Button

		' Token: 0x1700391F RID: 14623
		' (get) Token: 0x060099C3 RID: 39363 RVA: 0x0004B1B8 File Offset: 0x000493B8
		' (set) Token: 0x060099C4 RID: 39364 RVA: 0x0004B1C2 File Offset: 0x000493C2
		Friend Overridable Property Label24 As Label

		' Token: 0x17003920 RID: 14624
		' (get) Token: 0x060099C5 RID: 39365 RVA: 0x0004B1CB File Offset: 0x000493CB
		' (set) Token: 0x060099C6 RID: 39366 RVA: 0x0004B1D5 File Offset: 0x000493D5
		Friend Overridable Property ValPPoB As TextBox

		' Token: 0x17003921 RID: 14625
		' (get) Token: 0x060099C7 RID: 39367 RVA: 0x0004B1DE File Offset: 0x000493DE
		' (set) Token: 0x060099C8 RID: 39368 RVA: 0x0004B1E8 File Offset: 0x000493E8
		Friend Overridable Property BtnChkOnGSTINPortal As Button

		' Token: 0x060099C9 RID: 39369 RVA: 0x006E3EBC File Offset: 0x006E20BC
		Private Async Sub BtnValidate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = String.IsNullOrWhiteSpace(Me.TBoxGSTIN.Text)
			If flag Then
				MessageBox.Show("Please enter a valid GSTIN.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim validator As GSTINValidator = New GSTINValidator()
				Dim result As Dictionary(Of String, String) = Await validator.ValidateGSTINAsync(Me.TBoxGSTIN.Text)
				If result.ContainsKey("Error") Then
					MessageBox.Show(result("Error"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim valStatus As Label = Me.ValStatus
					Dim dictionary As Dictionary(Of String, String) = result
					Dim text As String = "Status"
					Dim text2 As String = ""
					valStatus.Text = If(dictionary.TryGetValue(text, text2), result("Status"), "NA")
					Dim valTradeName As Label = Me.ValTradeName
					Dim dictionary2 As Dictionary(Of String, String) = result
					Dim text3 As String = "TradeName"
					Dim text4 As String = ""
					valTradeName.Text = If(dictionary2.TryGetValue(text3, text4), result("TradeName"), "NA")
					Dim valLegalName As Label = Me.ValLegalName
					Dim dictionary3 As Dictionary(Of String, String) = result
					Dim text5 As String = "LegalName"
					Dim text6 As String = ""
					valLegalName.Text = If(dictionary3.TryGetValue(text5, text6), result("LegalName"), "NA")
					Dim valState As Label = Me.ValState
					Dim dictionary4 As Dictionary(Of String, String) = result
					Dim text7 As String = "State"
					Dim text8 As String = ""
					valState.Text = If(dictionary4.TryGetValue(text7, text8), result("State"), "NA")
					Dim valType As Label = Me.ValType
					Dim dictionary5 As Dictionary(Of String, String) = result
					Dim text9 As String = "Type"
					Dim text10 As String = ""
					valType.Text = If(dictionary5.TryGetValue(text9, text10), result("Type"), "NA")
					Dim valCoB As Label = Me.ValCoB
					Dim dictionary6 As Dictionary(Of String, String) = result
					Dim text11 As String = "ConstitutionOfBusiness"
					Dim text12 As String = ""
					valCoB.Text = If(dictionary6.TryGetValue(text11, text12), result("ConstitutionOfBusiness"), "NA")
					Dim valRegDate As Label = Me.ValRegDate
					Dim dictionary7 As Dictionary(Of String, String) = result
					Dim text13 As String = "RegistrationDate"
					Dim text14 As String = ""
					valRegDate.Text = If(dictionary7.TryGetValue(text13, text14), result("RegistrationDate"), "NA")
					Dim valCanDate As Label = Me.ValCanDate
					Dim dictionary8 As Dictionary(Of String, String) = result
					Dim text15 As String = "CancellationDate"
					Dim text16 As String = ""
					valCanDate.Text = If(dictionary8.TryGetValue(text15, text16), result("CancellationDate"), "NA")
					Dim valLstValOn As Label = Me.ValLstValOn
					Dim dictionary9 As Dictionary(Of String, String) = result
					Dim text17 As String = "LastValidatedOn"
					Dim text18 As String = ""
					valLstValOn.Text = If(dictionary9.TryGetValue(text17, text18), result("LastValidatedOn"), "NA")
					Dim valPPoB As TextBox = Me.ValPPoB
					Dim dictionary10 As Dictionary(Of String, String) = result
					Dim text19 As String = "PrincipalPlaceOfBusiness"
					Dim text20 As String = ""
					valPPoB.Text = If(dictionary10.TryGetValue(text19, text20), result("PrincipalPlaceOfBusiness"), "NA")
				End If
			End If
		End Sub
	End Class
End Namespace
