Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000582 RID: 1410
	<DesignerGenerated()>
	Public Partial Class frmSalesmanLedger
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011113 RID: 69907 RVA: 0x0007560E File Offset: 0x0007380E
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSalesmanLedger_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalesmanLedger_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170069EB RID: 27115
		' (get) Token: 0x06011116 RID: 69910 RVA: 0x00075640 File Offset: 0x00073840
		' (set) Token: 0x06011117 RID: 69911 RVA: 0x0007564A File Offset: 0x0007384A
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170069EC RID: 27116
		' (get) Token: 0x06011118 RID: 69912 RVA: 0x00075653 File Offset: 0x00073853
		' (set) Token: 0x06011119 RID: 69913 RVA: 0x0007565D File Offset: 0x0007385D
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170069ED RID: 27117
		' (get) Token: 0x0601111A RID: 69914 RVA: 0x00075666 File Offset: 0x00073866
		' (set) Token: 0x0601111B RID: 69915 RVA: 0x00075670 File Offset: 0x00073870
		Friend Overridable Property Label1 As Label

		' Token: 0x170069EE RID: 27118
		' (get) Token: 0x0601111C RID: 69916 RVA: 0x00075679 File Offset: 0x00073879
		' (set) Token: 0x0601111D RID: 69917 RVA: 0x009E4CEC File Offset: 0x009E2EEC
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

		' Token: 0x170069EF RID: 27119
		' (get) Token: 0x0601111E RID: 69918 RVA: 0x00075683 File Offset: 0x00073883
		' (set) Token: 0x0601111F RID: 69919 RVA: 0x0007568D File Offset: 0x0007388D
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170069F0 RID: 27120
		' (get) Token: 0x06011120 RID: 69920 RVA: 0x00075696 File Offset: 0x00073896
		' (set) Token: 0x06011121 RID: 69921 RVA: 0x000756A0 File Offset: 0x000738A0
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x170069F1 RID: 27121
		' (get) Token: 0x06011122 RID: 69922 RVA: 0x000756A9 File Offset: 0x000738A9
		' (set) Token: 0x06011123 RID: 69923 RVA: 0x000756B3 File Offset: 0x000738B3
		Friend Overridable Property Label2 As Label

		' Token: 0x170069F2 RID: 27122
		' (get) Token: 0x06011124 RID: 69924 RVA: 0x000756BC File Offset: 0x000738BC
		' (set) Token: 0x06011125 RID: 69925 RVA: 0x000756C6 File Offset: 0x000738C6
		Friend Overridable Property Label4 As Label

		' Token: 0x170069F3 RID: 27123
		' (get) Token: 0x06011126 RID: 69926 RVA: 0x000756CF File Offset: 0x000738CF
		' (set) Token: 0x06011127 RID: 69927 RVA: 0x000756D9 File Offset: 0x000738D9
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x170069F4 RID: 27124
		' (get) Token: 0x06011128 RID: 69928 RVA: 0x000756E2 File Offset: 0x000738E2
		' (set) Token: 0x06011129 RID: 69929 RVA: 0x000756EC File Offset: 0x000738EC
		Friend Overridable Property Label3 As Label

		' Token: 0x170069F5 RID: 27125
		' (get) Token: 0x0601112A RID: 69930 RVA: 0x000756F5 File Offset: 0x000738F5
		' (set) Token: 0x0601112B RID: 69931 RVA: 0x000756FF File Offset: 0x000738FF
		Friend Overridable Property txtSalesmanName As TextBox

		' Token: 0x170069F6 RID: 27126
		' (get) Token: 0x0601112C RID: 69932 RVA: 0x00075708 File Offset: 0x00073908
		' (set) Token: 0x0601112D RID: 69933 RVA: 0x00075712 File Offset: 0x00073912
		Friend Overridable Property txtSalesmanID As TextBox

		' Token: 0x170069F7 RID: 27127
		' (get) Token: 0x0601112E RID: 69934 RVA: 0x0007571B File Offset: 0x0007391B
		' (set) Token: 0x0601112F RID: 69935 RVA: 0x00075725 File Offset: 0x00073925
		Friend Overridable Property Label5 As Label

		' Token: 0x170069F8 RID: 27128
		' (get) Token: 0x06011130 RID: 69936 RVA: 0x0007572E File Offset: 0x0007392E
		' (set) Token: 0x06011131 RID: 69937 RVA: 0x009E4D30 File Offset: 0x009E2F30
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

		' Token: 0x170069F9 RID: 27129
		' (get) Token: 0x06011132 RID: 69938 RVA: 0x00075738 File Offset: 0x00073938
		' (set) Token: 0x06011133 RID: 69939 RVA: 0x009E4D74 File Offset: 0x009E2F74
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

		' Token: 0x170069FA RID: 27130
		' (get) Token: 0x06011134 RID: 69940 RVA: 0x00075742 File Offset: 0x00073942
		' (set) Token: 0x06011135 RID: 69941 RVA: 0x009E4DB8 File Offset: 0x009E2FB8
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

		' Token: 0x06011136 RID: 69942 RVA: 0x009E4DFC File Offset: 0x009E2FFC
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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

		' Token: 0x06011137 RID: 69943 RVA: 0x0007574C File Offset: 0x0007394C
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.txtSalesmanName.Text = ""
			Me.txtSalesmanID.Text = ""
		End Sub

		' Token: 0x06011138 RID: 69944 RVA: 0x00075789 File Offset: 0x00073989
		Private Sub frmSalesmanLedger_Load(sender As Object, e As EventArgs)
			Me.fyear()
		End Sub

		' Token: 0x06011139 RID: 69945 RVA: 0x00075793 File Offset: 0x00073993
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0601113A RID: 69946 RVA: 0x009E4ED8 File Offset: 0x009E30D8
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtSalesmanName.Text)) = 0
				If flag Then
					MessageBox.Show("Please retrieve Salesman Name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtSalesmanName.Focus()
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "Select * FROM InvoiceInfo INNER JOIN SalesMan ON InvoiceInfo.SalesmanID = SalesMan.SM_ID INNER JOIN Salesman_Commission ON InvoiceInfo.Inv_ID = Salesman_Commission.InvoiceID where InvoiceDate between @d2 and @d3 and Salesman_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSalesmanID.Text)
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
					If flag2 Then
						MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag3 Then
							ModCommonClasses.rdr.Close()
						End If
					Else
						Me.Cursor = Cursors.WaitCursor
						Me.Timer1.Enabled = True
						Dim rptSalesmanLedger As rptSalesmanLedger = New rptSalesmanLedger()
						Dim sqlCommand As SqlCommand = New SqlCommand()
						Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
						Dim dataSet As DataSet = New DataSet()
						Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
						sqlCommand.Connection = sqlConnection
						sqlCommand.CommandText = "SELECT InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.Customer_ID, InvoiceInfo.SalesmanID, InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance, InvoiceInfo.Remarks,SalesMan.SM_ID, SalesMan.SalesMan_ID, SalesMan.Name, SalesMan.Address, SalesMan.City, SalesMan.State, SalesMan.ZipCode, SalesMan.ContactNo, SalesMan.EmailID, SalesMan.Remarks AS Expr1,SalesMan.Photo, SalesMan.CommissionPer, Salesman_Commission.ID, Salesman_Commission.InvoiceID, Salesman_Commission.CommissionPer AS Expr2, Salesman_Commission.Commission FROM InvoiceInfo INNER JOIN SalesMan ON InvoiceInfo.SalesmanID = SalesMan.SM_ID INNER JOIN Salesman_Commission ON InvoiceInfo.Inv_ID = Salesman_Commission.InvoiceID where InvoiceDate between @d2 and @d3 and Salesman_ID=@d1 order by Inv_ID"
						sqlCommand.Parameters.AddWithValue("@d1", Me.txtSalesmanID.Text)
						sqlCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						sqlCommand.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						sqlCommand.CommandType = CommandType.Text
						sqlDataAdapter.SelectCommand = sqlCommand
						sqlDataAdapter.Fill(dataSet, "InvoiceInfo")
						sqlDataAdapter.Fill(dataSet, "Salesman")
						sqlDataAdapter.Fill(dataSet, "Salesman_Commission")
						rptSalesmanLedger.SetDataSource(dataSet)
						rptSalesmanLedger.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
						rptSalesmanLedger.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptSalesmanLedger
						MyProject.Forms.frmReport.ShowDialog()
						rptSalesmanLedger.Close()
						rptSalesmanLedger.Dispose()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601113B RID: 69947 RVA: 0x000757AF File Offset: 0x000739AF
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0601113C RID: 69948 RVA: 0x000757B9 File Offset: 0x000739B9
		Private Sub btnSelection_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesmanRecord.lblSet.Text = "Salesman Ledger"
			MyProject.Forms.frmSalesmanRecord.Reset()
			MyProject.Forms.frmSalesmanRecord.ShowDialog()
		End Sub

		' Token: 0x0601113D RID: 69949 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSalesmanLedger_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x04006686 RID: 26246
		Private a As String

		' Token: 0x04006687 RID: 26247
		Private b As String

		' Token: 0x04006688 RID: 26248
		Private c As String

		' Token: 0x04006689 RID: 26249
		Private d As String
	End Class
End Namespace
