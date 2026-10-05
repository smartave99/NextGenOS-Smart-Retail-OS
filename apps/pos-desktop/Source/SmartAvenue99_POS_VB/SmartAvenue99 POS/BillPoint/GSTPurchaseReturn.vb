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
Imports CrystalDecisions.CrystalReports.Engine
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200037A RID: 890
	<DesignerGenerated()>
	Public Partial Class GSTPurchaseReturn
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600D152 RID: 53586 RVA: 0x0005D0FE File Offset: 0x0005B2FE
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.GSTPurchaseReturn_Load
			AddHandler MyBase.KeyDown, AddressOf Me.GSTPurchaseReturn_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005203 RID: 20995
		' (get) Token: 0x0600D155 RID: 53589 RVA: 0x0005D130 File Offset: 0x0005B330
		' (set) Token: 0x0600D156 RID: 53590 RVA: 0x0005D13A File Offset: 0x0005B33A
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005204 RID: 20996
		' (get) Token: 0x0600D157 RID: 53591 RVA: 0x0005D143 File Offset: 0x0005B343
		' (set) Token: 0x0600D158 RID: 53592 RVA: 0x0005D14D File Offset: 0x0005B34D
		Friend Overridable Property Label11 As Label

		' Token: 0x17005205 RID: 20997
		' (get) Token: 0x0600D159 RID: 53593 RVA: 0x0005D156 File Offset: 0x0005B356
		' (set) Token: 0x0600D15A RID: 53594 RVA: 0x0005D160 File Offset: 0x0005B360
		Friend Overridable Property TableLayoutPanel1 As TableLayoutPanel

		' Token: 0x17005206 RID: 20998
		' (get) Token: 0x0600D15B RID: 53595 RVA: 0x0005D169 File Offset: 0x0005B369
		' (set) Token: 0x0600D15C RID: 53596 RVA: 0x0005D173 File Offset: 0x0005B373
		Friend Overridable Property Label10 As Label

		' Token: 0x17005207 RID: 20999
		' (get) Token: 0x0600D15D RID: 53597 RVA: 0x0005D17C File Offset: 0x0005B37C
		' (set) Token: 0x0600D15E RID: 53598 RVA: 0x0005D186 File Offset: 0x0005B386
		Friend Overridable Property Label9 As Label

		' Token: 0x17005208 RID: 21000
		' (get) Token: 0x0600D15F RID: 53599 RVA: 0x0005D18F File Offset: 0x0005B38F
		' (set) Token: 0x0600D160 RID: 53600 RVA: 0x0005D199 File Offset: 0x0005B399
		Friend Overridable Property Label8 As Label

		' Token: 0x17005209 RID: 21001
		' (get) Token: 0x0600D161 RID: 53601 RVA: 0x0005D1A2 File Offset: 0x0005B3A2
		' (set) Token: 0x0600D162 RID: 53602 RVA: 0x0005D1AC File Offset: 0x0005B3AC
		Friend Overridable Property Label7 As Label

		' Token: 0x1700520A RID: 21002
		' (get) Token: 0x0600D163 RID: 53603 RVA: 0x0005D1B5 File Offset: 0x0005B3B5
		' (set) Token: 0x0600D164 RID: 53604 RVA: 0x0005D1BF File Offset: 0x0005B3BF
		Friend Overridable Property Label6 As Label

		' Token: 0x1700520B RID: 21003
		' (get) Token: 0x0600D165 RID: 53605 RVA: 0x0005D1C8 File Offset: 0x0005B3C8
		' (set) Token: 0x0600D166 RID: 53606 RVA: 0x0005D1D2 File Offset: 0x0005B3D2
		Friend Overridable Property Label5 As Label

		' Token: 0x1700520C RID: 21004
		' (get) Token: 0x0600D167 RID: 53607 RVA: 0x0005D1DB File Offset: 0x0005B3DB
		' (set) Token: 0x0600D168 RID: 53608 RVA: 0x0005D1E5 File Offset: 0x0005B3E5
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x1700520D RID: 21005
		' (get) Token: 0x0600D169 RID: 53609 RVA: 0x0005D1EE File Offset: 0x0005B3EE
		' (set) Token: 0x0600D16A RID: 53610 RVA: 0x0005D1F8 File Offset: 0x0005B3F8
		Friend Overridable Property TextBox7 As TextBox

		' Token: 0x1700520E RID: 21006
		' (get) Token: 0x0600D16B RID: 53611 RVA: 0x0005D201 File Offset: 0x0005B401
		' (set) Token: 0x0600D16C RID: 53612 RVA: 0x0005D20B File Offset: 0x0005B40B
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x1700520F RID: 21007
		' (get) Token: 0x0600D16D RID: 53613 RVA: 0x0005D214 File Offset: 0x0005B414
		' (set) Token: 0x0600D16E RID: 53614 RVA: 0x0005D21E File Offset: 0x0005B41E
		Friend Overridable Property TextBox6 As TextBox

		' Token: 0x17005210 RID: 21008
		' (get) Token: 0x0600D16F RID: 53615 RVA: 0x0005D227 File Offset: 0x0005B427
		' (set) Token: 0x0600D170 RID: 53616 RVA: 0x0005D231 File Offset: 0x0005B431
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x17005211 RID: 21009
		' (get) Token: 0x0600D171 RID: 53617 RVA: 0x0005D23A File Offset: 0x0005B43A
		' (set) Token: 0x0600D172 RID: 53618 RVA: 0x0005D244 File Offset: 0x0005B444
		Friend Overridable Property TextBox5 As TextBox

		' Token: 0x17005212 RID: 21010
		' (get) Token: 0x0600D173 RID: 53619 RVA: 0x0005D24D File Offset: 0x0005B44D
		' (set) Token: 0x0600D174 RID: 53620 RVA: 0x0005D257 File Offset: 0x0005B457
		Friend Overridable Property TextBox4 As TextBox

		' Token: 0x17005213 RID: 21011
		' (get) Token: 0x0600D175 RID: 53621 RVA: 0x0005D260 File Offset: 0x0005B460
		' (set) Token: 0x0600D176 RID: 53622 RVA: 0x0005D26A File Offset: 0x0005B46A
		Friend Overridable Property Label3 As Label

		' Token: 0x17005214 RID: 21012
		' (get) Token: 0x0600D177 RID: 53623 RVA: 0x0005D273 File Offset: 0x0005B473
		' (set) Token: 0x0600D178 RID: 53624 RVA: 0x0005D27D File Offset: 0x0005B47D
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17005215 RID: 21013
		' (get) Token: 0x0600D179 RID: 53625 RVA: 0x0005D286 File Offset: 0x0005B486
		' (set) Token: 0x0600D17A RID: 53626 RVA: 0x0005D290 File Offset: 0x0005B490
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17005216 RID: 21014
		' (get) Token: 0x0600D17B RID: 53627 RVA: 0x0005D299 File Offset: 0x0005B499
		' (set) Token: 0x0600D17C RID: 53628 RVA: 0x0005D2A3 File Offset: 0x0005B4A3
		Friend Overridable Property Label2 As Label

		' Token: 0x17005217 RID: 21015
		' (get) Token: 0x0600D17D RID: 53629 RVA: 0x0005D2AC File Offset: 0x0005B4AC
		' (set) Token: 0x0600D17E RID: 53630 RVA: 0x0005D2B6 File Offset: 0x0005B4B6
		Friend Overridable Property Label4 As Label

		' Token: 0x17005218 RID: 21016
		' (get) Token: 0x0600D17F RID: 53631 RVA: 0x0005D2BF File Offset: 0x0005B4BF
		' (set) Token: 0x0600D180 RID: 53632 RVA: 0x0005D2C9 File Offset: 0x0005B4C9
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17005219 RID: 21017
		' (get) Token: 0x0600D181 RID: 53633 RVA: 0x0005D2D2 File Offset: 0x0005B4D2
		' (set) Token: 0x0600D182 RID: 53634 RVA: 0x00826350 File Offset: 0x00824550
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

		' Token: 0x1700521A RID: 21018
		' (get) Token: 0x0600D183 RID: 53635 RVA: 0x0005D2DC File Offset: 0x0005B4DC
		' (set) Token: 0x0600D184 RID: 53636 RVA: 0x0005D2E6 File Offset: 0x0005B4E6
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700521B RID: 21019
		' (get) Token: 0x0600D185 RID: 53637 RVA: 0x0005D2EF File Offset: 0x0005B4EF
		' (set) Token: 0x0600D186 RID: 53638 RVA: 0x0005D2F9 File Offset: 0x0005B4F9
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700521C RID: 21020
		' (get) Token: 0x0600D187 RID: 53639 RVA: 0x0005D302 File Offset: 0x0005B502
		' (set) Token: 0x0600D188 RID: 53640 RVA: 0x0005D30C File Offset: 0x0005B50C
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x1700521D RID: 21021
		' (get) Token: 0x0600D189 RID: 53641 RVA: 0x0005D315 File Offset: 0x0005B515
		' (set) Token: 0x0600D18A RID: 53642 RVA: 0x0005D31F File Offset: 0x0005B51F
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700521E RID: 21022
		' (get) Token: 0x0600D18B RID: 53643 RVA: 0x0005D328 File Offset: 0x0005B528
		' (set) Token: 0x0600D18C RID: 53644 RVA: 0x0005D332 File Offset: 0x0005B532
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700521F RID: 21023
		' (get) Token: 0x0600D18D RID: 53645 RVA: 0x0005D33B File Offset: 0x0005B53B
		' (set) Token: 0x0600D18E RID: 53646 RVA: 0x0005D345 File Offset: 0x0005B545
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17005220 RID: 21024
		' (get) Token: 0x0600D18F RID: 53647 RVA: 0x0005D34E File Offset: 0x0005B54E
		' (set) Token: 0x0600D190 RID: 53648 RVA: 0x0005D358 File Offset: 0x0005B558
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17005221 RID: 21025
		' (get) Token: 0x0600D191 RID: 53649 RVA: 0x0005D361 File Offset: 0x0005B561
		' (set) Token: 0x0600D192 RID: 53650 RVA: 0x0005D36B File Offset: 0x0005B56B
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17005222 RID: 21026
		' (get) Token: 0x0600D193 RID: 53651 RVA: 0x0005D374 File Offset: 0x0005B574
		' (set) Token: 0x0600D194 RID: 53652 RVA: 0x0005D37E File Offset: 0x0005B57E
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17005223 RID: 21027
		' (get) Token: 0x0600D195 RID: 53653 RVA: 0x0005D387 File Offset: 0x0005B587
		' (set) Token: 0x0600D196 RID: 53654 RVA: 0x0005D391 File Offset: 0x0005B591
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17005224 RID: 21028
		' (get) Token: 0x0600D197 RID: 53655 RVA: 0x0005D39A File Offset: 0x0005B59A
		' (set) Token: 0x0600D198 RID: 53656 RVA: 0x0005D3A4 File Offset: 0x0005B5A4
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17005225 RID: 21029
		' (get) Token: 0x0600D199 RID: 53657 RVA: 0x0005D3AD File Offset: 0x0005B5AD
		' (set) Token: 0x0600D19A RID: 53658 RVA: 0x0005D3B7 File Offset: 0x0005B5B7
		Friend Overridable Property Label1 As Label

		' Token: 0x17005226 RID: 21030
		' (get) Token: 0x0600D19B RID: 53659 RVA: 0x0005D3C0 File Offset: 0x0005B5C0
		' (set) Token: 0x0600D19C RID: 53660 RVA: 0x00826394 File Offset: 0x00824594
		Private _Timer1 As Timer
		Friend Overridable Property Timer1 As Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer1_Tick
				Dim timer As Timer = Me._Timer1
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

		' Token: 0x17005227 RID: 21031
		' (get) Token: 0x0600D19D RID: 53661 RVA: 0x0005D3CA File Offset: 0x0005B5CA
		' (set) Token: 0x0600D19E RID: 53662 RVA: 0x0005D3D4 File Offset: 0x0005B5D4
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17005228 RID: 21032
		' (get) Token: 0x0600D19F RID: 53663 RVA: 0x0005D3DD File Offset: 0x0005B5DD
		' (set) Token: 0x0600D1A0 RID: 53664 RVA: 0x008263D8 File Offset: 0x008245D8
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

		' Token: 0x17005229 RID: 21033
		' (get) Token: 0x0600D1A1 RID: 53665 RVA: 0x0005D3E7 File Offset: 0x0005B5E7
		' (set) Token: 0x0600D1A2 RID: 53666 RVA: 0x0005D3F1 File Offset: 0x0005B5F1
		Friend Overridable Property btnAddCustomer As GelButton

		' Token: 0x1700522A RID: 21034
		' (get) Token: 0x0600D1A3 RID: 53667 RVA: 0x0005D3FA File Offset: 0x0005B5FA
		' (set) Token: 0x0600D1A4 RID: 53668 RVA: 0x0082641C File Offset: 0x0082461C
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

		' Token: 0x1700522B RID: 21035
		' (get) Token: 0x0600D1A5 RID: 53669 RVA: 0x0005D404 File Offset: 0x0005B604
		' (set) Token: 0x0600D1A6 RID: 53670 RVA: 0x00826460 File Offset: 0x00824660
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

		' Token: 0x1700522C RID: 21036
		' (get) Token: 0x0600D1A7 RID: 53671 RVA: 0x0005D40E File Offset: 0x0005B60E
		' (set) Token: 0x0600D1A8 RID: 53672 RVA: 0x008264A4 File Offset: 0x008246A4
		Private _GelButton4 As GelButton
		Friend Overridable Property GelButton4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton4_Click
				Dim gelButton As GelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton4 = value
				gelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600D1A9 RID: 53673 RVA: 0x008264E8 File Offset: 0x008246E8
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

		' Token: 0x0600D1AA RID: 53674 RVA: 0x008265BC File Offset: 0x008247BC
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(PurchaseReturn.PRNo), PurchaseReturn.Date, RTRIM(Supplier.Name),RTRIM(Supplier.GSTIN), PurchaseReturn.GrandTotal, ((PurchaseReturn.GrandTotal - PurchaseReturn.FreightCharges + PurchaseReturn.OtherCharges)-(PurchaseReturn.CGST + PurchaseReturn.SGST + PurchaseReturn.IGST + PurchaseReturn.CESS)), PurchaseReturn.CGST,PurchaseReturn.SGST,PurchaseReturn.IGST,PurchaseReturn.CESS, (PurchaseReturn.GrandTotal-(((PurchaseReturn.GrandTotal - PurchaseReturn.FreightCharges + PurchaseReturn.OtherCharges)-(PurchaseReturn.CGST + PurchaseReturn.SGST + PurchaseReturn.IGST + PurchaseReturn.CESS)) + (PurchaseReturn.CGST + PurchaseReturn.SGST + PurchaseReturn.IGST + PurchaseReturn.CESS))) from PurchaseReturn INNER JOIN PurchaseReturn_Join ON PurchaseReturn.PR_ID = PurchaseReturn_Join.PurchaseReturnID INNER JOIN Product ON PurchaseReturn_Join.ProductID = Product.PID INNER JOIN Stock ON PurchaseReturn.PurchaseID = Stock.ST_ID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID where PurchaseReturn.Date between @d1 and @d2 and NOT Stock.TaxType='NON GST' order by PurchaseReturn.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600D1AB RID: 53675 RVA: 0x008267BC File Offset: 0x008249BC
		Private Sub GSTPurchaseReturn_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.cal()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600D1AC RID: 53676 RVA: 0x00826854 File Offset: 0x00824A54
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

		' Token: 0x0600D1AD RID: 53677 RVA: 0x008269CC File Offset: 0x00824BCC
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim visible As Boolean = ctrl.Visible
			If visible Then
				Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
				If flag Then
					Dim text As String = ctrl.Text
					Dim flag2 As Boolean = translations.ContainsKey(text)
					If flag2 Then
						ctrl.Text = translations(text)
					End If
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

		' Token: 0x0600D1AE RID: 53678 RVA: 0x00826A98 File Offset: 0x00824C98
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

		' Token: 0x0600D1AF RID: 53679 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600D1B0 RID: 53680 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600D1B1 RID: 53681 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600D1B2 RID: 53682 RVA: 0x00826B64 File Offset: 0x00824D64
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

		' Token: 0x0600D1B3 RID: 53683 RVA: 0x00826C4C File Offset: 0x00824E4C
		Private Sub cal()
			Me.TextBox1.Text = "0.00"
			Me.TextBox2.Text = "0.00"
			Me.TextBox3.Text = "0.00"
			Me.TextBox4.Text = "0.00"
			Me.TextBox5.Text = "0.00"
			Me.TextBox6.Text = "0.00"
			Me.TextBox7.Text = "0.00"
			Dim num As Integer = Me.dgw.Rows.Count - 1
			Dim num2 As Double
			For i As Integer = 0 To num
				Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column5").Value))

					If flag Then
						num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column5").Value))
					End If

			Next
			Me.TextBox1.Text = Conversions.ToString(num2)
			Me.TextBox1.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox1.Text), 2), "0.00")
			Dim num3 As Integer = Me.dgw.Rows.Count - 1
			Dim num4 As Double
			For j As Integer = 0 To num3
				Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(j).Cells("Column6").Value))

					If flag2 Then
						num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(j).Cells("Column6").Value))
					End If

			Next
			Me.TextBox2.Text = Conversions.ToString(num4)
			Me.TextBox2.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox2.Text), 2), "0.00")
			Dim num5 As Integer = Me.dgw.Rows.Count - 1
			Dim num6 As Double
			For k As Integer = 0 To num5
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(k).Cells("Column7").Value))

					If flag3 Then
						num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(k).Cells("Column7").Value))
					End If

			Next
			Me.TextBox3.Text = Conversions.ToString(num6)
			Me.TextBox3.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox3.Text), 2), "0.00")
			Dim num7 As Integer = Me.dgw.Rows.Count - 1
			Dim num8 As Double
			For l As Integer = 0 To num7
				Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(l).Cells("Column8").Value))

					If flag4 Then
						num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(l).Cells("Column8").Value))
					End If

			Next
			Me.TextBox4.Text = Conversions.ToString(num8)
			Me.TextBox4.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox4.Text), 2), "0.00")
			Dim num9 As Integer = Me.dgw.Rows.Count - 1
			Dim num10 As Double
			For m As Integer = 0 To num9
				Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(m).Cells("Column9").Value))

					If flag5 Then
						num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(m).Cells("Column9").Value))
					End If

			Next
			Me.TextBox5.Text = Conversions.ToString(num10)
			Me.TextBox5.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox5.Text), 2), "0.00")
			Dim num11 As Integer = Me.dgw.Rows.Count - 1
			Dim num12 As Double
			For n As Integer = 0 To num11
				Dim flag6 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(n).Cells("Column10").Value))

					If flag6 Then
						num12 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(n).Cells("Column10").Value))
					End If

			Next
			Me.TextBox6.Text = Conversions.ToString(num12)
			Me.TextBox6.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox6.Text), 2), "0.00")
			Dim num13 As Integer = Me.dgw.Rows.Count - 1
			Dim num15 As Double
			For num14 As Integer = 0 To num13
				Dim flag7 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(num14).Cells("Column11").Value))

					If flag7 Then
						num15 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(num14).Cells("Column11").Value))
					End If

			Next
			Me.TextBox7.Text = Conversions.ToString(num15)
			Me.TextBox7.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox7.Text), 2), "0.00")
		End Sub

		' Token: 0x0600D1B4 RID: 53684 RVA: 0x0005D418 File Offset: 0x0005B618
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600D1B5 RID: 53685 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub GSTPurchaseReturn_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600D1B6 RID: 53686 RVA: 0x0005D434 File Offset: 0x0005B634
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.cal()
		End Sub

		' Token: 0x0600D1B7 RID: 53687 RVA: 0x0005D445 File Offset: 0x0005B645
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata()
			Me.cal()
		End Sub

		' Token: 0x0600D1B8 RID: 53688 RVA: 0x008272B4 File Offset: 0x008254B4
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.dgw.Columns.Count = 0) Or (Me.dgw.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
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
							dataTable.Rows.Add(New Object(-1) {})
							Try
								For Each obj3 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
									dataTable.Rows(dataTable.Rows.Count - 1)(dataGridViewCell.ColumnIndex) = dataGridViewCell.Value.ToString()
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
					Dim text As String = ""
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag2 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag2 Then
						text = Me.SaveFileDialog1.FileName
					End If
					Using xlworkbook As XLWorkbook = New XLWorkbook()
						xlworkbook.Worksheets.Add(dataTable, "Export File")
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600D1B9 RID: 53689 RVA: 0x00827560 File Offset: 0x00825760
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.dgw.RowCount = 0
			If flag Then
				MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim dataTable As DataTable = New DataTable()
				Dim dataTable2 As DataTable = dataTable
				dataTable2.Columns.Add("BillNo")
				dataTable2.Columns.Add("Date")
				dataTable2.Columns.Add("CName")
				dataTable2.Columns.Add("GSTIN")
				dataTable2.Columns.Add("BillAmt")
				dataTable2.Columns.Add("TxblAmt")
				dataTable2.Columns.Add("CGSTAmt")
				dataTable2.Columns.Add("SGSTAmt")
				dataTable2.Columns.Add("IGSTAmt")
				dataTable2.Columns.Add("CESSAmt")
				dataTable2.Columns.Add("OtherAmt")
				Try
					For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						dataTable.Rows.Add(New Object() { dataGridViewRow.Cells(0).Value, dataGridViewRow.Cells(1).Value, dataGridViewRow.Cells(2).Value, dataGridViewRow.Cells(3).Value, dataGridViewRow.Cells(4).Value, dataGridViewRow.Cells(5).Value, dataGridViewRow.Cells(6).Value, dataGridViewRow.Cells(7).Value, dataGridViewRow.Cells(8).Value, dataGridViewRow.Cells(9).Value, dataGridViewRow.Cells(10).Value })
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim reportDocument As ReportDocument = New rptGSTSale()
				reportDocument.SetDataSource(dataTable)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
				Dim textObject As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text27"), TextObject)
				textObject.Text = Me.dtpDateFrom.Text
				Dim textObject2 As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text28"), TextObject)
				textObject2.Text = Me.dtpDateTo.Text
				Dim textObject3 As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text22"), TextObject)
				textObject3.Text = Me.Label1.Text
				Dim textObject4 As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text3"), TextObject)
				textObject4.Text = "Supplier Name"
				MyProject.Forms.frmReport.ShowDialog()
				MyProject.Forms.frmReport.Dispose()
			End If
		End Sub
	End Class
End Namespace
