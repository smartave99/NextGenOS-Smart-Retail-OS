Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200007A RID: 122
	<DesignerGenerated()>
	Public Partial Class frmBankList
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001476 RID: 5238 RVA: 0x000DCC18 File Offset: 0x000DAE18
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmTables_Load
			AddHandler MyBase.Shown, AddressOf Me.frmBankList_Shown
			Me.UserButtons = New List(Of Button)()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000845 RID: 2117
		' (get) Token: 0x06001479 RID: 5241 RVA: 0x00010F73 File Offset: 0x0000F173
		' (set) Token: 0x0600147A RID: 5242 RVA: 0x00010F7D File Offset: 0x0000F17D
		Friend Overridable Property lblSet As Label

		' Token: 0x17000846 RID: 2118
		' (get) Token: 0x0600147B RID: 5243 RVA: 0x00010F86 File Offset: 0x0000F186
		' (set) Token: 0x0600147C RID: 5244 RVA: 0x000DD0F4 File Offset: 0x000DB2F4
		Private _btnClose As Button
		Friend Overridable Property btnClose As Button
			<CompilerGenerated()>
			Get
				Return Me._btnClose
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnLogout_Click
				Dim button As Button = Me._btnClose
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnClose = value
				button = Me._btnClose
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000847 RID: 2119
		' (get) Token: 0x0600147D RID: 5245 RVA: 0x00010F90 File Offset: 0x0000F190
		' (set) Token: 0x0600147E RID: 5246 RVA: 0x00010F9A File Offset: 0x0000F19A
		Friend Overridable Property Label5 As Label

		' Token: 0x17000848 RID: 2120
		' (get) Token: 0x0600147F RID: 5247 RVA: 0x00010FA3 File Offset: 0x0000F1A3
		' (set) Token: 0x06001480 RID: 5248 RVA: 0x00010FAD File Offset: 0x0000F1AD
		Friend Overridable Property flpTables As FlowLayoutPanel

		' Token: 0x17000849 RID: 2121
		' (get) Token: 0x06001481 RID: 5249 RVA: 0x00010FB6 File Offset: 0x0000F1B6
		' (set) Token: 0x06001482 RID: 5250 RVA: 0x00010FC0 File Offset: 0x0000F1C0
		Friend Overridable Property lblControl As Label

		' Token: 0x06001483 RID: 5251 RVA: 0x000DD138 File Offset: 0x000DB338
		Public Sub FillWallet()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT distinct RTRIM(AccountNo) FROM BankAccountRegistration where Active='Yes' order by 1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.flpTables.Controls.Clear()
				Dim flag As Boolean = True
				While ModCommonClasses.rdr.Read()
					Dim button As Button = New Button()
					button.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					button.TextAlign = ContentAlignment.MiddleCenter
					Dim steelBlue As Color = Color.SteelBlue
					button.BackColor = steelBlue
					button.ForeColor = Color.White
					button.FlatStyle = FlatStyle.Popup
					button.Width = 180
					button.Height = 80
					button.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0)
					Me.UserButtons.Add(button)
					Me.flpTables.Controls.Add(button)
					Dim flag2 As Boolean = flag
					If flag2 Then
						button.Focus()
						button.[Select]()
					End If
					AddHandler button.Click, AddressOf Me.Button2_Click
					flag = False
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001484 RID: 5252 RVA: 0x000DD2D0 File Offset: 0x000DB4D0
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblControl.Text, "frmPOSTouch", False) = 0
			If flag Then
				Try
					Dim button As Button = CType(sender, Button)
					Dim text As String = button.Text.Trim()
					MyProject.Forms.frmPOSTouch.cmbPaymentMode.SelectedIndex = Conversions.ToInteger(Me.lblSet.Text.Trim())
					MyProject.Forms.frmPOSTouch.cmbAccountNo.Text = button.Text.Trim()
					MyBase.Hide()
					MyProject.Forms.frmPOSTouch.Show()
					Dim flag2 As Boolean = MyProject.Forms.frmPOSTouch.DataGridView1.Rows.Count = 0
					If flag2 Then
						MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Return
					End If
					Dim flag3 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSTouch.cmbPaymentMode.Text, "", False) = 0
					If flag3 Then
						MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Return
					End If
					Dim flag4 As Boolean = MyProject.Forms.frmPOSTouch.cmbPaymentMode.SelectedIndex = 1 OrElse MyProject.Forms.frmPOSTouch.cmbPaymentMode.SelectedIndex = 2 OrElse MyProject.Forms.frmPOSTouch.cmbPaymentMode.SelectedIndex = 3 OrElse MyProject.Forms.frmPOSTouch.cmbPaymentMode.SelectedIndex = 4 OrElse MyProject.Forms.frmPOSTouch.cmbPaymentMode.SelectedIndex = 5 OrElse MyProject.Forms.frmPOSTouch.cmbPaymentMode.SelectedIndex = 6 OrElse MyProject.Forms.frmPOSTouch.cmbPaymentMode.SelectedIndex = 7
					If flag4 Then
						Dim flag5 As Boolean = MyProject.Forms.frmPOSTouch.cmbAccountNo.SelectedIndex = -1
						If flag5 Then
							MessageBox.Show("Please select bank account number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							MyProject.Forms.frmPOSTouch.cmbAccountNo.Focus()
							Return
						End If
					End If
					Dim flag6 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSTouch.txtPayment.Text, "", False) = 0
					If flag6 Then
						MessageBox.Show("Please enter payment", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						MyProject.Forms.frmPOSTouch.txtPayment.Focus()
						Return
					End If
					Dim flag7 As Boolean = Conversion.Val(MyProject.Forms.frmPOSTouch.txtPayment.Text) <= 0.0
					If flag7 Then
						MessageBox.Show("Payment must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						MyProject.Forms.frmPOSTouch.txtPayment.Focus()
						MyProject.Forms.frmPOSTouch.btnListReset1.PerformClick()
						Return
					End If
					Try
						For Each obj As Object In MyProject.Forms.frmPOSTouch.DataGridView2.SelectedRows
							Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
							Dim flag8 As Boolean = Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dataGridViewRow.Cells(0).Value, "Credit Terms - Adjust", False), MyProject.Forms.frmPOSTouch.cmbPaymentMode.SelectedIndex = 15))
							If flag8 Then
								MessageBox.Show("Sorry, you are not allowed to double Adjust Entry", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Return
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Dim flag9 As Boolean = (Conversion.Val(MyProject.Forms.frmPOSTouch.txtPayment.Text) > Conversion.Val(MyProject.Forms.frmPOSTouch.TextBox18.Text)) And (MyProject.Forms.frmPOSTouch.cmbPaymentMode.SelectedIndex = 15)
					If flag9 Then
						MessageBox.Show("Sorry, you are not allowed to adjust excess amount than balance", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Return
					End If
					MyProject.Forms.frmPOSTouch.DataGridView2.Rows.Add(New Object() { MyProject.Forms.frmPOSTouch.cmbPaymentMode.Text, Strings.Format(Math.Round(Conversion.Val(MyProject.Forms.frmPOSTouch.txtPayment.Text), 2), "0.00"), MyProject.Forms.frmPOSTouch.dtpPaymentDate.Value.[Date], MyProject.Forms.frmPOSTouch.cmbAccountNo.Text })
					Dim num As Double = MyProject.Forms.frmPOSTouch.TotalPayment()
					num = Conversions.ToDouble(Strings.Format(Math.Round(num, 2), "0.00"))
					MyProject.Forms.frmPOSTouch.txtTotalPayment.Text = Conversions.ToString(num)
					MyProject.Forms.frmPOSTouch.Compute()
					MyProject.Forms.frmPOSTouch.Clear1()
					MyProject.Forms.frmPOSTouch.caldgv2()
					MyProject.Forms.frmPOSTouch.OPCode2()
					MyProject.Forms.frmPOSTouch.Bankcondn()
					MyProject.Forms.frmPOSTouch.btnSave_Click(RuntimeHelpers.GetObjectValue(sender), e)
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
			Dim flag10 As Boolean = Operators.CompareString(Me.lblControl.Text, "frmPOSNewTuch", False) = 0
			If flag10 Then
				Try
					Dim button2 As Button = CType(sender, Button)
					Dim text2 As String = button2.Text.Trim()
					MyProject.Forms.frmPOSNewTuch.cmbPaymentMode.SelectedIndex = Conversions.ToInteger(Me.lblSet.Text.Trim())
					MyProject.Forms.frmPOSNewTuch.cmbAccountNo.Text = button2.Text.Trim()
					MyBase.Hide()
					MyProject.Forms.frmPOSNewTuch.Show()
					Dim flag11 As Boolean = MyProject.Forms.frmPOSNewTuch.DataGridView1.Rows.Count = 0
					If flag11 Then
						MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Dim flag12 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch.cmbPaymentMode.Text, "", False) = 0
						If flag12 Then
							MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							Dim flag13 As Boolean = MyProject.Forms.frmPOSNewTuch.cmbPaymentMode.SelectedIndex = 1 OrElse MyProject.Forms.frmPOSNewTuch.cmbPaymentMode.SelectedIndex = 2 OrElse MyProject.Forms.frmPOSNewTuch.cmbPaymentMode.SelectedIndex = 3 OrElse MyProject.Forms.frmPOSNewTuch.cmbPaymentMode.SelectedIndex = 4 OrElse MyProject.Forms.frmPOSNewTuch.cmbPaymentMode.SelectedIndex = 5 OrElse MyProject.Forms.frmPOSNewTuch.cmbPaymentMode.SelectedIndex = 6 OrElse MyProject.Forms.frmPOSNewTuch.cmbPaymentMode.SelectedIndex = 7
							If flag13 Then
								Dim flag14 As Boolean = MyProject.Forms.frmPOSNewTuch.cmbAccountNo.SelectedIndex = -1
								If flag14 Then
									MessageBox.Show("Please select bank account number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									MyProject.Forms.frmPOSNewTuch.cmbAccountNo.Focus()
									Return
								End If
							End If
							Dim flag15 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch.txtPayment.Text, "", False) = 0
							If flag15 Then
								MessageBox.Show("Please enter payment", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								MyProject.Forms.frmPOSNewTuch.txtPayment.Focus()
							Else
								Dim flag16 As Boolean = Conversion.Val(MyProject.Forms.frmPOSNewTuch.txtPayment.Text) <= 0.0
								If flag16 Then
									MessageBox.Show("Payment must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									MyProject.Forms.frmPOSNewTuch.txtPayment.Focus()
									MyProject.Forms.frmPOSNewTuch.btnListReset1.PerformClick()
								Else
									Try
										For Each obj2 As Object In MyProject.Forms.frmPOSNewTuch.DataGridView2.SelectedRows
											Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
											Dim flag17 As Boolean = Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dataGridViewRow2.Cells(0).Value, "Credit Terms - Adjust", False), MyProject.Forms.frmPOSNewTuch.cmbPaymentMode.SelectedIndex = 15))
											If flag17 Then
												MessageBox.Show("Sorry, you are not allowed to double Adjust Entry", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Return
											End If
										Next
									Finally
										Dim enumerator2 As IEnumerator
										If TypeOf enumerator2 Is IDisposable Then
											TryCast(enumerator2, IDisposable).Dispose()
										End If
									End Try
									Dim flag18 As Boolean = (Conversion.Val(MyProject.Forms.frmPOSNewTuch.txtPayment.Text) > Conversion.Val(MyProject.Forms.frmPOSNewTuch.TextBox18.Text)) And (MyProject.Forms.frmPOSNewTuch.cmbPaymentMode.SelectedIndex = 15)
									If flag18 Then
										MessageBox.Show("Sorry, you are not allowed to adjust excess amount than balance", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Else
										MyProject.Forms.frmPOSNewTuch.DataGridView2.Rows.Add(New Object() { MyProject.Forms.frmPOSNewTuch.cmbPaymentMode.Text, Strings.Format(Math.Round(Conversion.Val(MyProject.Forms.frmPOSNewTuch.txtPayment.Text), 2), "0.00"), MyProject.Forms.frmPOSNewTuch.dtpPaymentDate.Value.[Date], MyProject.Forms.frmPOSNewTuch.cmbAccountNo.Text })
										Dim num2 As Double = MyProject.Forms.frmPOSNewTuch.TotalPayment()
										num2 = Conversions.ToDouble(Strings.Format(Math.Round(num2, 2), "0.00"))
										MyProject.Forms.frmPOSNewTuch.txtTotalPayment.Text = Conversions.ToString(num2)
										MyProject.Forms.frmPOSNewTuch.Compute()
										MyProject.Forms.frmPOSNewTuch.Clear1()
										MyProject.Forms.frmPOSNewTuch.caldgv2()
										MyProject.Forms.frmPOSNewTuch.OPCode2()
										MyProject.Forms.frmPOSNewTuch.Bankcondn()
										MyProject.Forms.frmPOSNewTuch.btnSave_Click(RuntimeHelpers.GetObjectValue(sender), e)
									End If
								End If
							End If
						End If
					End If
				Catch ex2 As Exception
					MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x06001485 RID: 5253 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmTables_Load(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06001486 RID: 5254 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnLogout_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x06001487 RID: 5255 RVA: 0x00010FD3 File Offset: 0x0000F1D3
		Private Sub frmBankList_Shown(sender As Object, e As EventArgs)
			MyBase.BringToFront()
			Me.FillWallet()
		End Sub

		' Token: 0x040006FA RID: 1786
		Private UserButtons As List(Of Button)
	End Class
End Namespace
