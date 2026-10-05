Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms
Imports BillPoint.My
Imports CButtonLib
Imports Microsoft.VisualBasic.CompilerServices
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome

Namespace BillPoint
	' Token: 0x02000212 RID: 530
	<DesignerGenerated()>
	Public Partial Class FrmValidate
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600994A RID: 39242 RVA: 0x0004ADB4 File Offset: 0x00048FB4
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.FrmValidate_Load
			AddHandler MyBase.KeyDown, AddressOf Me.FrmValidate_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170038EC RID: 14572
		' (get) Token: 0x0600994D RID: 39245 RVA: 0x0004ADE6 File Offset: 0x00048FE6
		' (set) Token: 0x0600994E RID: 39246 RVA: 0x0004ADF0 File Offset: 0x00048FF0
		Friend Overridable Property Label1 As Label

		' Token: 0x170038ED RID: 14573
		' (get) Token: 0x0600994F RID: 39247 RVA: 0x0004ADF9 File Offset: 0x00048FF9
		' (set) Token: 0x06009950 RID: 39248 RVA: 0x006E20C8 File Offset: 0x006E02C8
		Private _TBoxGSTIN As TextBox
		Friend Overridable Property TBoxGSTIN As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TBoxGSTIN
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TBoxGSTIN_KeyDown
				Dim textBox As TextBox = Me._TBoxGSTIN
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TBoxGSTIN = value
				textBox = Me._TBoxGSTIN
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170038EE RID: 14574
		' (get) Token: 0x06009951 RID: 39249 RVA: 0x0004AE03 File Offset: 0x00049003
		' (set) Token: 0x06009952 RID: 39250 RVA: 0x006E210C File Offset: 0x006E030C
		Private _BtnValidate As CButton
		Friend Overridable Property BtnValidate As CButton
			<CompilerGenerated()>
			Get
				Return Me._BtnValidate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CButton)
				Dim clickButtonAreaEventHandler As CButton.ClickButtonAreaEventHandler = AddressOf Me.BtnValidate_ClickButtonArea
				Dim cbutton As CButton = Me._BtnValidate
				If cbutton IsNot Nothing Then
					RemoveHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
				Me._BtnValidate = value
				cbutton = Me._BtnValidate
				If cbutton IsNot Nothing Then
					AddHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
			End Set
		End Property

		' Token: 0x170038EF RID: 14575
		' (get) Token: 0x06009953 RID: 39251 RVA: 0x0004AE0D File Offset: 0x0004900D
		' (set) Token: 0x06009954 RID: 39252 RVA: 0x0004AE17 File Offset: 0x00049017
		Friend Overridable Property Label3 As Label

		' Token: 0x170038F0 RID: 14576
		' (get) Token: 0x06009955 RID: 39253 RVA: 0x0004AE20 File Offset: 0x00049020
		' (set) Token: 0x06009956 RID: 39254 RVA: 0x0004AE2A File Offset: 0x0004902A
		Friend Overridable Property Label4 As Label

		' Token: 0x170038F1 RID: 14577
		' (get) Token: 0x06009957 RID: 39255 RVA: 0x0004AE33 File Offset: 0x00049033
		' (set) Token: 0x06009958 RID: 39256 RVA: 0x0004AE3D File Offset: 0x0004903D
		Friend Overridable Property Label5 As Label

		' Token: 0x170038F2 RID: 14578
		' (get) Token: 0x06009959 RID: 39257 RVA: 0x0004AE46 File Offset: 0x00049046
		' (set) Token: 0x0600995A RID: 39258 RVA: 0x0004AE50 File Offset: 0x00049050
		Friend Overridable Property Label6 As Label

		' Token: 0x170038F3 RID: 14579
		' (get) Token: 0x0600995B RID: 39259 RVA: 0x0004AE59 File Offset: 0x00049059
		' (set) Token: 0x0600995C RID: 39260 RVA: 0x0004AE63 File Offset: 0x00049063
		Friend Overridable Property Label7 As Label

		' Token: 0x170038F4 RID: 14580
		' (get) Token: 0x0600995D RID: 39261 RVA: 0x0004AE6C File Offset: 0x0004906C
		' (set) Token: 0x0600995E RID: 39262 RVA: 0x0004AE76 File Offset: 0x00049076
		Friend Overridable Property Label8 As Label

		' Token: 0x170038F5 RID: 14581
		' (get) Token: 0x0600995F RID: 39263 RVA: 0x0004AE7F File Offset: 0x0004907F
		' (set) Token: 0x06009960 RID: 39264 RVA: 0x0004AE89 File Offset: 0x00049089
		Friend Overridable Property Label9 As Label

		' Token: 0x170038F6 RID: 14582
		' (get) Token: 0x06009961 RID: 39265 RVA: 0x0004AE92 File Offset: 0x00049092
		' (set) Token: 0x06009962 RID: 39266 RVA: 0x0004AE9C File Offset: 0x0004909C
		Friend Overridable Property Label12 As Label

		' Token: 0x170038F7 RID: 14583
		' (get) Token: 0x06009963 RID: 39267 RVA: 0x0004AEA5 File Offset: 0x000490A5
		' (set) Token: 0x06009964 RID: 39268 RVA: 0x0004AEAF File Offset: 0x000490AF
		Friend Overridable Property ValCanDate As Label

		' Token: 0x170038F8 RID: 14584
		' (get) Token: 0x06009965 RID: 39269 RVA: 0x0004AEB8 File Offset: 0x000490B8
		' (set) Token: 0x06009966 RID: 39270 RVA: 0x0004AEC2 File Offset: 0x000490C2
		Friend Overridable Property ValRegDate As Label

		' Token: 0x170038F9 RID: 14585
		' (get) Token: 0x06009967 RID: 39271 RVA: 0x0004AECB File Offset: 0x000490CB
		' (set) Token: 0x06009968 RID: 39272 RVA: 0x0004AED5 File Offset: 0x000490D5
		Friend Overridable Property ValCoB As Label

		' Token: 0x170038FA RID: 14586
		' (get) Token: 0x06009969 RID: 39273 RVA: 0x0004AEDE File Offset: 0x000490DE
		' (set) Token: 0x0600996A RID: 39274 RVA: 0x0004AEE8 File Offset: 0x000490E8
		Friend Overridable Property ValType As Label

		' Token: 0x170038FB RID: 14587
		' (get) Token: 0x0600996B RID: 39275 RVA: 0x0004AEF1 File Offset: 0x000490F1
		' (set) Token: 0x0600996C RID: 39276 RVA: 0x0004AEFB File Offset: 0x000490FB
		Friend Overridable Property ValState As Label

		' Token: 0x170038FC RID: 14588
		' (get) Token: 0x0600996D RID: 39277 RVA: 0x0004AF04 File Offset: 0x00049104
		' (set) Token: 0x0600996E RID: 39278 RVA: 0x0004AF0E File Offset: 0x0004910E
		Friend Overridable Property ValLegalName As Label

		' Token: 0x170038FD RID: 14589
		' (get) Token: 0x0600996F RID: 39279 RVA: 0x0004AF17 File Offset: 0x00049117
		' (set) Token: 0x06009970 RID: 39280 RVA: 0x0004AF21 File Offset: 0x00049121
		Friend Overridable Property ValTradeName As Label

		' Token: 0x170038FE RID: 14590
		' (get) Token: 0x06009971 RID: 39281 RVA: 0x0004AF2A File Offset: 0x0004912A
		' (set) Token: 0x06009972 RID: 39282 RVA: 0x0004AF34 File Offset: 0x00049134
		Friend Overridable Property Label24 As Label

		' Token: 0x170038FF RID: 14591
		' (get) Token: 0x06009973 RID: 39283 RVA: 0x0004AF3D File Offset: 0x0004913D
		' (set) Token: 0x06009974 RID: 39284 RVA: 0x0004AF47 File Offset: 0x00049147
		Friend Overridable Property ValPPoB As TextBox

		' Token: 0x17003900 RID: 14592
		' (get) Token: 0x06009975 RID: 39285 RVA: 0x0004AF50 File Offset: 0x00049150
		' (set) Token: 0x06009976 RID: 39286 RVA: 0x006E2150 File Offset: 0x006E0350
		Private _BtnChkOnGSTINPortal As CButton
		Friend Overridable Property BtnChkOnGSTINPortal As CButton
			<CompilerGenerated()>
			Get
				Return Me._BtnChkOnGSTINPortal
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CButton)
				Dim clickButtonAreaEventHandler As CButton.ClickButtonAreaEventHandler = AddressOf Me.BtnChkOnGSTINPortal_ClickButtonArea
				Dim cbutton As CButton = Me._BtnChkOnGSTINPortal
				If cbutton IsNot Nothing Then
					RemoveHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
				Me._BtnChkOnGSTINPortal = value
				cbutton = Me._BtnChkOnGSTINPortal
				If cbutton IsNot Nothing Then
					AddHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003901 RID: 14593
		' (get) Token: 0x06009977 RID: 39287 RVA: 0x0004AF5A File Offset: 0x0004915A
		' (set) Token: 0x06009978 RID: 39288 RVA: 0x006E2194 File Offset: 0x006E0394
		Private _Button1 As CButton
		Friend Overridable Property Button1 As CButton
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CButton)
				Dim clickButtonAreaEventHandler As CButton.ClickButtonAreaEventHandler = AddressOf Me.Button1_ClickButtonArea
				Dim cbutton As CButton = Me._Button1
				If cbutton IsNot Nothing Then
					RemoveHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
				Me._Button1 = value
				cbutton = Me._Button1
				If cbutton IsNot Nothing Then
					AddHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003902 RID: 14594
		' (get) Token: 0x06009979 RID: 39289 RVA: 0x0004AF64 File Offset: 0x00049164
		' (set) Token: 0x0600997A RID: 39290 RVA: 0x006E21D8 File Offset: 0x006E03D8
		Private _Button2 As CButton
		Friend Overridable Property Button2 As CButton
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CButton)
				Dim clickButtonAreaEventHandler As CButton.ClickButtonAreaEventHandler = AddressOf Me.Button2_ClickButtonArea
				Dim cbutton As CButton = Me._Button2
				If cbutton IsNot Nothing Then
					RemoveHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
				Me._Button2 = value
				cbutton = Me._Button2
				If cbutton IsNot Nothing Then
					AddHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003903 RID: 14595
		' (get) Token: 0x0600997B RID: 39291 RVA: 0x0004AF6E File Offset: 0x0004916E
		' (set) Token: 0x0600997C RID: 39292 RVA: 0x0004AF78 File Offset: 0x00049178
		Friend Overridable Property txtNat As TextBox

		' Token: 0x17003904 RID: 14596
		' (get) Token: 0x0600997D RID: 39293 RVA: 0x0004AF81 File Offset: 0x00049181
		' (set) Token: 0x0600997E RID: 39294 RVA: 0x0004AF8B File Offset: 0x0004918B
		Friend Overridable Property Label2 As Label

		' Token: 0x17003905 RID: 14597
		' (get) Token: 0x0600997F RID: 39295 RVA: 0x0004AF94 File Offset: 0x00049194
		' (set) Token: 0x06009980 RID: 39296 RVA: 0x006E221C File Offset: 0x006E041C
		Private _Timer1 As Global.System.Windows.Forms.Timer
		Friend Overridable Property Timer1 As Global.System.Windows.Forms.Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Global.System.Windows.Forms.Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer1_Tick
				Dim timer As Global.System.Windows.Forms.Timer = Me._Timer1
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer1 = value
				timer = Me._Timer1
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x06009981 RID: 39297 RVA: 0x006E2260 File Offset: 0x006E0460
		Public Sub cl()
			Me.ValTradeName.Text = "NA"
			Me.ValLegalName.Text = "NA"
			Me.ValState.Text = "NA"
			Me.ValType.Text = "NA"
			Me.ValCoB.Text = "NA"
			Me.ValRegDate.Text = "NA"
			Me.ValCanDate.Text = "NA"
			Me.ValPPoB.Text = "NA"
			Me.txtNat.Text = "NA"
			Me.TBoxGSTIN.Focus()
		End Sub

		' Token: 0x06009982 RID: 39298 RVA: 0x0004AF9E File Offset: 0x0004919E
		Private Sub FrmValidate_Load(sender As Object, e As EventArgs)
			Me.cl()
		End Sub

		' Token: 0x06009983 RID: 39299 RVA: 0x00166A00 File Offset: 0x00164C00
		Private Sub FrmValidate_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = CDbl(e.KeyCode) = Conversions.ToDouble(OpenQA.Selenium.Keys.Escape)
				If flag Then
					e.Handled = True
					Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
					If flag2 Then
						MyBase.Close()
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06009984 RID: 39300 RVA: 0x006E2314 File Offset: 0x006E0514
		Private Sub TBoxGSTIN_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = CDbl(e.KeyCode) = Conversions.ToDouble(OpenQA.Selenium.Keys.Enter)
				If flag Then
					SendKeys.Send("{TAB}")
					SendKeys.Send("{Enter}")
					e.SuppressKeyPress = True
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06009985 RID: 39301 RVA: 0x0004AFA8 File Offset: 0x000491A8
		Private Sub Button2_ClickButtonArea(Sender As Object, e As MouseEventArgs)
			Me.TBoxGSTIN.Text = Clipboard.GetText()
		End Sub

		' Token: 0x06009986 RID: 39302 RVA: 0x006E237C File Offset: 0x006E057C
		Private Sub BtnValidate_ClickButtonArea(Sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
			If flag Then
				MessageBox.Show("Please check your internet connection", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.TBoxGSTIN.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please fill valid GST number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim text As String = Me.TBoxGSTIN.Text.Trim()
					Dim flag3 As Boolean = Not Me.IsValidGSTIN(text)
					If flag3 Then
						MessageBox.Show("Invalid GSTIN. Please enter a valid one.")
					Else
						Me.Cursor = Cursors.WaitCursor
						Me.Timer1.Enabled = True
						Me.InitializeDriver()
						Try
							Me.driver.Navigate().GoToUrl(Me._GSTValid("aHR0cHM6Ly93d3cua25vd3lvdXJnc3QuY29tL2dzdC1udW1iZXItc2VhcmNoLw=="))
							Dim webElement As IWebElement = Me.driver.FindElement(By.Id("gstnumber"))
							webElement.SendKeys(text)
							Me.driver.FindElement(By.ClassName("btn")).Click()
							Dim num As Integer = 10
							Dim i As Integer = 0
							Dim readOnlyCollection As IReadOnlyCollection(Of IWebElement) = Nothing
							While i < num
								Thread.Sleep(2000)
								readOnlyCollection = Me.driver.FindElements(By.TagName("td"))
								Dim flag4 As Boolean = readOnlyCollection.Count > 0
								If flag4 Then
									Exit While
								End If
								i += 1
							End While
							Dim flag5 As Boolean = readOnlyCollection IsNot Nothing AndAlso readOnlyCollection.Count > 0
							If flag5 Then
								Me.ValTradeName.Text = readOnlyCollection.ElementAtOrDefault(1).Text
								Me.ValLegalName.Text = readOnlyCollection.ElementAtOrDefault(5).Text
								Dim text2 As String = text.Substring(0, 2)
								Dim stateNameByCode As String = Me.GetStateNameByCode(text2)
								Dim flag6 As Boolean = stateNameByCode <> Nothing
								If flag6 Then
									Me.ValState.Text = stateNameByCode
								Else
									Me.ValState.Text = "Unknown State Code"
								End If
								Me.ValType.Text = readOnlyCollection.ElementAtOrDefault(9).Text
								Me.ValCoB.Text = readOnlyCollection.ElementAtOrDefault(11).Text
								Me.ValRegDate.Text = readOnlyCollection.ElementAtOrDefault(17).Text
								Me.ValCanDate.Text = readOnlyCollection.ElementAtOrDefault(3).Text
								Me.ValPPoB.Text = readOnlyCollection.ElementAtOrDefault(13).Text
								Me.txtNat.Text = readOnlyCollection.ElementAtOrDefault(15).Text
							Else
								MessageBox.Show("No GST details found after retrying.")
								Me.cl()
							End If
						Catch ex As Exception
							MessageBox.Show(String.Format("Error occurred: {0}", ex.Message))
							Me.cl()
						Finally
							Dim flag7 As Boolean = Me.driver IsNot Nothing
							If flag7 Then
								Me.driver.Quit()
							End If
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x06009987 RID: 39303 RVA: 0x006E26A8 File Offset: 0x006E08A8
		Private Sub InitializeDriver()
			Try
				Dim chromeOptions As ChromeOptions = New ChromeOptions()
				chromeOptions.AddArgument("--window-size=1000,600")
				chromeOptions.AddArgument("--headless=new")
				chromeOptions.AddArgument("--disable-gpu")
				chromeOptions.AddArgument("--disable-extensions")
				chromeOptions.AddArgument("--window-position=-10000,-10000")
				Dim chromeDriverService As ChromeDriverService = ChromeDriverService.CreateDefaultService()
				chromeDriverService.HideCommandPromptWindow = True
				Me.driver = New ChromeDriver(chromeDriverService, chromeOptions)
			Catch ex As Exception
				MessageBox.Show(String.Format("Failed to initialize WebDriver: {0}", ex.Message))
			End Try
		End Sub

		' Token: 0x06009988 RID: 39304 RVA: 0x006E274C File Offset: 0x006E094C
		Private Function IsValidGSTIN(gstin As String) As Boolean
			Return Regex.IsMatch(gstin, "^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[A-Z0-9]{1}[Z]{1}[A-Z0-9]{1}$")
		End Function

		' Token: 0x06009989 RID: 39305 RVA: 0x00199EB4 File Offset: 0x001980B4
		Private Function _GSTValid(axn As String) As String
			Dim empty As String = String.Empty
			Dim utf8Encoding As UTF8Encoding = New UTF8Encoding()
			Dim decoder As Decoder = utf8Encoding.GetDecoder()
			Dim array As Byte() = Convert.FromBase64String(axn)
			Dim charCount As Integer = decoder.GetCharCount(array, 0, array.Length)
			Dim array2 As Char() = New Char(charCount - 1 + 1 - 1) {}
			decoder.GetChars(array, 0, array.Length, array2, 0)
			Return New String(array2)
		End Function

		' Token: 0x0600998A RID: 39306 RVA: 0x006E276C File Offset: 0x006E096C
		Private Function GetStateNameByCode(code As String) As String
			Dim dictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)() From { { "01", "Jammu & Kashmir" }, { "02", "Himachal Pradesh" }, { "03", "Punjab" }, { "04", "Chandigarh" }, { "05", "Uttarakhand" }, { "06", "Haryana" }, { "07", "Delhi" }, { "08", "Rajasthan" }, { "09", "Uttar Pradesh" }, { "10", "Bihar" }, { "11", "Sikkim" }, { "12", "Arunachal Pradesh" }, { "13", "Nagaland" }, { "14", "Manipur" }, { "15", "Mizoram" }, { "16", "Tripura" }, { "17", "Meghalaya" }, { "18", "Assam" }, { "19", "West Bengal" }, { "20", "Jharkhand" }, { "21", "Odisha" }, { "22", "Chattisgarh" }, { "23", "Madhya Pradesh" }, { "24", "Gujarat" }, { "25", "Daman & Diu" }, { "26", "Dadra & Nagar Haveli" }, { "27", "Maharashtra" }, { "28", "Andhra Pradesh" }, { "29", "Karnataka" }, { "30", "Goa" }, { "31", "Lakshadweep" }, { "32", "Kerala" }, { "33", "Tamil Nadu" }, { "34", "Puducherry" }, { "35", "Andaman & Nicobar Islands" }, { "36", "Telangana" }, { "37", "Andhra Pradesh" }, { "38", "Ladakh" }, { "97", "Other Territory" }, { "99", "Centre Jurisdiction" } }
			Dim flag As Boolean = dictionary.ContainsKey(code)
			Dim text As String
			If flag Then
				text = dictionary(code)
			Else
				text = Nothing
			End If
			Return text
		End Function

		' Token: 0x0600998B RID: 39307 RVA: 0x006E2A44 File Offset: 0x006E0C44
		Private Sub Button1_ClickButtonArea(Sender As Object, e As MouseEventArgs)
			MyProject.Forms.frmCustomer.cmbCustomerName.Text = Me.ValTradeName.Text
			MyProject.Forms.frmCustomer.txtCity.Text = Me.ValState.Text
			MyProject.Forms.frmCustomer.cmbState.Text = Me.ValState.Text
			MyProject.Forms.frmCustomer.txtAddress.Text = Me.ValPPoB.Text
			MyProject.Forms.frmCustomer.txtGSTIN.Text = Me.TBoxGSTIN.Text
			MyProject.Forms.frmCustomer.txtPAN.Text = Me.ValCanDate.Text
			MyProject.Forms.frmSupplier.cmbSupplierName.Text = Me.ValTradeName.Text
			MyProject.Forms.frmSupplier.txtCity.Text = Me.ValState.Text
			MyProject.Forms.frmSupplier.cmbState.Text = Me.ValState.Text
			MyProject.Forms.frmSupplier.txtAddress.Text = Me.ValPPoB.Text
			MyProject.Forms.frmSupplier.txtGSTIN.Text = Me.TBoxGSTIN.Text
			MyProject.Forms.frmSupplier.txtPAN.Text = Me.ValCanDate.Text
			MyBase.Close()
		End Sub

		' Token: 0x0600998C RID: 39308 RVA: 0x006E2BDC File Offset: 0x006E0DDC
		Private Sub BtnChkOnGSTINPortal_ClickButtonArea(Sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
			If flag Then
				MessageBox.Show("Please check your internet connection", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Process.Start("https://services.gst.gov.in/services/searchtp")
			End If
		End Sub

		' Token: 0x0600998D RID: 39309 RVA: 0x0004AFBC File Offset: 0x000491BC
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x040043EA RID: 17386
		Private driver As IWebDriver
	End Class
End Namespace
