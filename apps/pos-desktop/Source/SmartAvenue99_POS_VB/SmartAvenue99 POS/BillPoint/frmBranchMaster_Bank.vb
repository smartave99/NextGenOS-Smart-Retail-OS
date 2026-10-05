Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200030F RID: 783
	<DesignerGenerated()>
	Public Partial Class frmBranchMaster_Bank
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600B9D7 RID: 47575 RVA: 0x0005325F File Offset: 0x0005145F
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmRegistration_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmBranchMaster_Bank_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004A19 RID: 18969
		' (get) Token: 0x0600B9DA RID: 47578 RVA: 0x00053291 File Offset: 0x00051491
		' (set) Token: 0x0600B9DB RID: 47579 RVA: 0x0005329B File Offset: 0x0005149B
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004A1A RID: 18970
		' (get) Token: 0x0600B9DC RID: 47580 RVA: 0x000532A4 File Offset: 0x000514A4
		' (set) Token: 0x0600B9DD RID: 47581 RVA: 0x000532AE File Offset: 0x000514AE
		Friend Overridable Property Label3 As Label

		' Token: 0x17004A1B RID: 18971
		' (get) Token: 0x0600B9DE RID: 47582 RVA: 0x000532B7 File Offset: 0x000514B7
		' (set) Token: 0x0600B9DF RID: 47583 RVA: 0x0077AB08 File Offset: 0x00778D08
		Private _txtBranchName As TextBox
		Friend Overridable Property txtBranchName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBranchName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBranchName_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtBranchName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtBranchName = value
				textBox = Me._txtBranchName
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A1C RID: 18972
		' (get) Token: 0x0600B9E0 RID: 47584 RVA: 0x000532C1 File Offset: 0x000514C1
		' (set) Token: 0x0600B9E1 RID: 47585 RVA: 0x0077AB68 File Offset: 0x00778D68
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
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A1D RID: 18973
		' (get) Token: 0x0600B9E2 RID: 47586 RVA: 0x000532CB File Offset: 0x000514CB
		' (set) Token: 0x0600B9E3 RID: 47587 RVA: 0x000532D5 File Offset: 0x000514D5
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004A1E RID: 18974
		' (get) Token: 0x0600B9E4 RID: 47588 RVA: 0x000532DE File Offset: 0x000514DE
		' (set) Token: 0x0600B9E5 RID: 47589 RVA: 0x000532E8 File Offset: 0x000514E8
		Friend Overridable Property Label1 As Label

		' Token: 0x17004A1F RID: 18975
		' (get) Token: 0x0600B9E6 RID: 47590 RVA: 0x000532F1 File Offset: 0x000514F1
		' (set) Token: 0x0600B9E7 RID: 47591 RVA: 0x000532FB File Offset: 0x000514FB
		Friend Overridable Property Label7 As Label

		' Token: 0x17004A20 RID: 18976
		' (get) Token: 0x0600B9E8 RID: 47592 RVA: 0x00053304 File Offset: 0x00051504
		' (set) Token: 0x0600B9E9 RID: 47593 RVA: 0x0005330E File Offset: 0x0005150E
		Friend Overridable Property Label6 As Label

		' Token: 0x17004A21 RID: 18977
		' (get) Token: 0x0600B9EA RID: 47594 RVA: 0x00053317 File Offset: 0x00051517
		' (set) Token: 0x0600B9EB RID: 47595 RVA: 0x0077ABC8 File Offset: 0x00778DC8
		Private _txtIFSCCode As TextBox
		Friend Overridable Property txtIFSCCode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtIFSCCode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtIFSCCode_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtIFSCCode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtIFSCCode = value
				textBox = Me._txtIFSCCode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A22 RID: 18978
		' (get) Token: 0x0600B9EC RID: 47596 RVA: 0x00053321 File Offset: 0x00051521
		' (set) Token: 0x0600B9ED RID: 47597 RVA: 0x0077AC28 File Offset: 0x00778E28
		Private _txtSwiftCode As TextBox
		Friend Overridable Property txtSwiftCode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSwiftCode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSwiftCode_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtSwiftCode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtSwiftCode = value
				textBox = Me._txtSwiftCode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A23 RID: 18979
		' (get) Token: 0x0600B9EE RID: 47598 RVA: 0x0005332B File Offset: 0x0005152B
		' (set) Token: 0x0600B9EF RID: 47599 RVA: 0x0077AC88 File Offset: 0x00778E88
		Private _txtContactNo As TextBox
		Friend Overridable Property txtContactNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtContactNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtContactNo_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtContactNo_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtContactNo = value
				textBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A24 RID: 18980
		' (get) Token: 0x0600B9F0 RID: 47600 RVA: 0x00053335 File Offset: 0x00051535
		' (set) Token: 0x0600B9F1 RID: 47601 RVA: 0x0005333F File Offset: 0x0005153F
		Friend Overridable Property Label4 As Label

		' Token: 0x17004A25 RID: 18981
		' (get) Token: 0x0600B9F2 RID: 47602 RVA: 0x00053348 File Offset: 0x00051548
		' (set) Token: 0x0600B9F3 RID: 47603 RVA: 0x00053352 File Offset: 0x00051552
		Friend Overridable Property Label2 As Label

		' Token: 0x17004A26 RID: 18982
		' (get) Token: 0x0600B9F4 RID: 47604 RVA: 0x0005335B File Offset: 0x0005155B
		' (set) Token: 0x0600B9F5 RID: 47605 RVA: 0x00053365 File Offset: 0x00051565
		Friend Overridable Property txtID As TextBox

		' Token: 0x17004A27 RID: 18983
		' (get) Token: 0x0600B9F6 RID: 47606 RVA: 0x0005336E File Offset: 0x0005156E
		' (set) Token: 0x0600B9F7 RID: 47607 RVA: 0x00053378 File Offset: 0x00051578
		Friend Overridable Property lblUser As Label

		' Token: 0x17004A28 RID: 18984
		' (get) Token: 0x0600B9F8 RID: 47608 RVA: 0x00053381 File Offset: 0x00051581
		' (set) Token: 0x0600B9F9 RID: 47609 RVA: 0x0077AD04 File Offset: 0x00778F04
		Private _txtAddress As TextBox
		Friend Overridable Property txtAddress As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAddress
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtAddress_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtAddress
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtAddress = value
				textBox = Me._txtAddress
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A29 RID: 18985
		' (get) Token: 0x0600B9FA RID: 47610 RVA: 0x0005338B File Offset: 0x0005158B
		' (set) Token: 0x0600B9FB RID: 47611 RVA: 0x0077AD64 File Offset: 0x00778F64
		Private _cmbBank As ComboBox
		Friend Overridable Property cmbBank As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbBank
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbBank_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbBank
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbBank = value
				comboBox = Me._cmbBank
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A2A RID: 18986
		' (get) Token: 0x0600B9FC RID: 47612 RVA: 0x00053395 File Offset: 0x00051595
		' (set) Token: 0x0600B9FD RID: 47613 RVA: 0x0005339F File Offset: 0x0005159F
		Friend Overridable Property Label14 As Label

		' Token: 0x17004A2B RID: 18987
		' (get) Token: 0x0600B9FE RID: 47614 RVA: 0x000533A8 File Offset: 0x000515A8
		' (set) Token: 0x0600B9FF RID: 47615 RVA: 0x000533B2 File Offset: 0x000515B2
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17004A2C RID: 18988
		' (get) Token: 0x0600BA00 RID: 47616 RVA: 0x000533BB File Offset: 0x000515BB
		' (set) Token: 0x0600BA01 RID: 47617 RVA: 0x000533C5 File Offset: 0x000515C5
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17004A2D RID: 18989
		' (get) Token: 0x0600BA02 RID: 47618 RVA: 0x000533CE File Offset: 0x000515CE
		' (set) Token: 0x0600BA03 RID: 47619 RVA: 0x000533D8 File Offset: 0x000515D8
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17004A2E RID: 18990
		' (get) Token: 0x0600BA04 RID: 47620 RVA: 0x000533E1 File Offset: 0x000515E1
		' (set) Token: 0x0600BA05 RID: 47621 RVA: 0x000533EB File Offset: 0x000515EB
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17004A2F RID: 18991
		' (get) Token: 0x0600BA06 RID: 47622 RVA: 0x000533F4 File Offset: 0x000515F4
		' (set) Token: 0x0600BA07 RID: 47623 RVA: 0x000533FE File Offset: 0x000515FE
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17004A30 RID: 18992
		' (get) Token: 0x0600BA08 RID: 47624 RVA: 0x00053407 File Offset: 0x00051607
		' (set) Token: 0x0600BA09 RID: 47625 RVA: 0x00053411 File Offset: 0x00051611
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17004A31 RID: 18993
		' (get) Token: 0x0600BA0A RID: 47626 RVA: 0x0005341A File Offset: 0x0005161A
		' (set) Token: 0x0600BA0B RID: 47627 RVA: 0x00053424 File Offset: 0x00051624
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17004A32 RID: 18994
		' (get) Token: 0x0600BA0C RID: 47628 RVA: 0x0005342D File Offset: 0x0005162D
		' (set) Token: 0x0600BA0D RID: 47629 RVA: 0x00053437 File Offset: 0x00051637
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17004A33 RID: 18995
		' (get) Token: 0x0600BA0E RID: 47630 RVA: 0x00053440 File Offset: 0x00051640
		' (set) Token: 0x0600BA0F RID: 47631 RVA: 0x0005344A File Offset: 0x0005164A
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17004A34 RID: 18996
		' (get) Token: 0x0600BA10 RID: 47632 RVA: 0x00053453 File Offset: 0x00051653
		' (set) Token: 0x0600BA11 RID: 47633 RVA: 0x0005345D File Offset: 0x0005165D
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17004A35 RID: 18997
		' (get) Token: 0x0600BA12 RID: 47634 RVA: 0x00053466 File Offset: 0x00051666
		' (set) Token: 0x0600BA13 RID: 47635 RVA: 0x0077ADC4 File Offset: 0x00778FC4
		Private _btnUpdate As GelButton
		Friend Overridable Property btnUpdate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim gelButton As GelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnUpdate = value
				gelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A36 RID: 18998
		' (get) Token: 0x0600BA14 RID: 47636 RVA: 0x00053470 File Offset: 0x00051670
		' (set) Token: 0x0600BA15 RID: 47637 RVA: 0x0077AE08 File Offset: 0x00779008
		Private _btnDelete As GelButton
		Friend Overridable Property btnDelete As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
				Dim gelButton As GelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDelete = value
				gelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004A37 RID: 18999
		' (get) Token: 0x0600BA16 RID: 47638 RVA: 0x0005347A File Offset: 0x0005167A
		' (set) Token: 0x0600BA17 RID: 47639 RVA: 0x00053484 File Offset: 0x00051684
		Friend Overridable Property btnNew As GelButton

		' Token: 0x17004A38 RID: 19000
		' (get) Token: 0x0600BA18 RID: 47640 RVA: 0x0005348D File Offset: 0x0005168D
		' (set) Token: 0x0600BA19 RID: 47641 RVA: 0x0077AE4C File Offset: 0x0077904C
		Private _btnSave As GelButton
		Friend Overridable Property btnSave As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSave = value
				gelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600BA1A RID: 47642 RVA: 0x0077AE90 File Offset: 0x00779090
		Private Sub auto()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT MAX(ID) FROM BankBranch"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim flag As Boolean = Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.cmd.ExecuteScalar()))
				If flag Then
					Dim num As Integer = 1
					Me.txtID.Text = num.ToString()
				Else
					Dim num As Integer = Conversions.ToInteger(Operators.AddObject(ModCommonClasses.cmd.ExecuteScalar(), 1))
					Me.txtID.Text = num.ToString()
				End If
				ModCommonClasses.cmd.Dispose()
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BA1B RID: 47643 RVA: 0x0077AF94 File Offset: 0x00779194
		Public Sub fillCombo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(BankName) FROM Bank", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbBank.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbBank.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BA1C RID: 47644 RVA: 0x0077B0C8 File Offset: 0x007792C8
		Public Sub Reset()
			Me.txtAddress.Text = ""
			Me.txtContactNo.Text = ""
			Me.txtIFSCCode.Text = ""
			Me.txtSwiftCode.Text = ""
			Me.txtBranchName.Text = ""
			Me.cmbBank.SelectedIndex = -1
			Me.btnSave.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.btnDelete.Enabled = False
			Me.auto()
			Me.Getdata()
			Me.cmbBank.Focus()
		End Sub

		' Token: 0x0600BA1D RID: 47645 RVA: 0x0077B17C File Offset: 0x0077937C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(BankName), RTRIM(BranchName), RTRIM(Address), RTRIM(ContactNo), RTRIM(SwiftCode), RTRIM(IFSCCode) from BankBranch order by BranchName", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BA1E RID: 47646 RVA: 0x0077B2B8 File Offset: 0x007794B8
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

		' Token: 0x0600BA1F RID: 47647 RVA: 0x0077B3A0 File Offset: 0x007795A0
		Private Sub frmRegistration_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.fillCombo()
			Me.Reset()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600BA20 RID: 47648 RVA: 0x0077B438 File Offset: 0x00779638
		Public Sub Convert_Language()
			Dim text As String = "SELECT RTRIM(default_lang_eng) as default_lang_eng, other_lang, lang_hin FROM Language_set WHERE lang_hin= '" + GlobalVariables.LoggedInLang_code + "'"
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
						Me.UpdateDataGridViewHeaders(Me.dgw, GlobalVariables.translations)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x0600BA21 RID: 47649 RVA: 0x0077B5B8 File Offset: 0x007797B8
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
			If flag Then
				Dim text As String = ctrl.Text
				Dim flag2 As Boolean = translations.ContainsKey(text)
				If flag2 Then
					ctrl.Text = translations(text)
				End If
			End If
			Dim flag3 As Boolean = TypeOf ctrl Is TabControl
			If flag3 Then
				Dim tabControl As TabControl = CType(ctrl, TabControl)
				Try
					For Each obj As Object In tabControl.TabPages
						Dim tabPage As TabPage = CType(obj, TabPage)
						Dim text2 As String = tabPage.Text
						Dim flag4 As Boolean = translations.ContainsKey(text2)
						If flag4 Then
							tabPage.Text = translations(text2)
						End If
						Try
							For Each obj2 As Object In tabPage.Controls
								Dim control As Control = CType(obj2, Control)
								Me.UpdateAllControls(control, translations)
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			End If
			Dim flag5 As Boolean = TypeOf ctrl Is MenuStrip
			If flag5 Then
				Dim menuStrip As MenuStrip = CType(ctrl, MenuStrip)
				Try
					For Each obj3 As Object In menuStrip.Items
						Dim toolStripMenuItem As ToolStripMenuItem = CType(obj3, ToolStripMenuItem)
						Me.UpdateMenuItems(toolStripMenuItem, translations)
					Next
				Finally
					Dim enumerator3 As IEnumerator
					If TypeOf enumerator3 Is IDisposable Then
						TryCast(enumerator3, IDisposable).Dispose()
					End If
				End Try
			End If
			Try
				For Each obj4 As Object In ctrl.Controls
					Dim control2 As Control = CType(obj4, Control)
					Me.UpdateAllControls(control2, translations)
				Next
			Finally
				Dim enumerator4 As IEnumerator
				If TypeOf enumerator4 Is IDisposable Then
					TryCast(enumerator4, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600BA22 RID: 47650 RVA: 0x00208B7C File Offset: 0x00206D7C
		Private Sub UpdateDataGridViewHeaders(dgv As DataGridView, translations As Dictionary(Of String, String))
			Try
				For Each obj As Object In dgv.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim headerText As String = dataGridViewColumn.HeaderText
					Dim flag As Boolean = translations.ContainsKey(headerText)
					If flag Then
						dataGridViewColumn.HeaderText = translations(headerText)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600BA23 RID: 47651 RVA: 0x0077B7E4 File Offset: 0x007799E4
		Private Sub UpdateMenuItems(menuItem As ToolStripMenuItem, translations As Dictionary(Of String, String))
			Dim text As String = menuItem.Text
			Dim flag As Boolean = translations.ContainsKey(text)
			If flag Then
				menuItem.Text = translations(text)
			End If
			Try
				For Each toolStripMenuItem As ToolStripMenuItem In menuItem.DropDownItems.OfType(Of ToolStripMenuItem)()
					Me.UpdateMenuItems(toolStripMenuItem, translations)
				Next
			Finally
				Dim enumerator As IEnumerator(Of ToolStripMenuItem)
				If enumerator IsNot Nothing Then
					enumerator.Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600BA24 RID: 47652 RVA: 0x0077B864 File Offset: 0x00779A64
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.cmbBank.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtBranchName.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtAddress.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.txtContactNo.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.txtSwiftCode.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.txtIFSCCode.Text = dataGridViewRow.Cells(6).Value.ToString()
					Me.btnUpdate.Enabled = True
					Me.btnSave.Enabled = False
					Me.btnDelete.Enabled = True
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600BA25 RID: 47653 RVA: 0x0077B9E4 File Offset: 0x00779BE4
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select BankBranch.ID from BankBranch,BankAccountRegistration where BankBranch.ID=BankAccountRegistration.BranchID and BankBranch.ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("Unable to delete..Already in use in Bank Accounts Registration", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = If(("delete from BankBranch where ID=" + Conversions.ToString(Conversion.Val(Me.txtID.Text))), "")
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
					Dim flag3 As Boolean = num > 0
					If flag3 Then
						Dim text3 As String = "deleted the Bank's branch '" + Me.txtBranchName.Text + "' record"
						ModFunc.LogFunc(Me.lblUser.Text, text3)
						MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Getdata()
						Me.Reset()
					Else
						MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Reset()
					End If
					Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag4 Then
						ModCommonClasses.con.Close()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BA26 RID: 47654 RVA: 0x0077BBFC File Offset: 0x00779DFC
		Private Sub txtContactNo_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "+", False) <> 0 AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "-", False) <> 0 AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0600BA27 RID: 47655 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbBank_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BA28 RID: 47656 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtBranchName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BA29 RID: 47657 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAddress_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BA2A RID: 47658 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtContactNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BA2B RID: 47659 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtSwiftCode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BA2C RID: 47660 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtIFSCCode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BA2D RID: 47661 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmBranchMaster_Bank_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600BA2E RID: 47662 RVA: 0x0077BC6C File Offset: 0x00779E6C
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtSwiftCode.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtSwiftCode, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtSwiftCode, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtIFSCCode.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtIFSCCode, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtIFSCCode, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.txtContactNo.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.txtContactNo, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtContactNo, String.Empty)
			End If
			Dim flag4 As Boolean = String.IsNullOrEmpty(Me.txtBranchName.Text.Trim())
			If flag4 Then
				Me.ErrorProvider1.SetError(Me.txtBranchName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtBranchName, String.Empty)
			End If
			Dim flag5 As Boolean = String.IsNullOrEmpty(Me.txtAddress.Text.Trim())
			If flag5 Then
				Me.ErrorProvider1.SetError(Me.txtAddress, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtAddress, String.Empty)
			End If
			Dim flag6 As Boolean = String.IsNullOrEmpty(Me.cmbBank.Text.Trim())
			If flag6 Then
				Me.ErrorProvider1.SetError(Me.cmbBank, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbBank, String.Empty)
			End If
		End Sub

		' Token: 0x0600BA2F RID: 47663 RVA: 0x0077BE48 File Offset: 0x0077A048
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "select * from Company"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
			If flag Then
				MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
			Else
				Dim flag3 As Boolean = Operators.CompareString(Me.cmbBank.Text, "", False) = 0
				If flag3 Then
					MessageBox.Show("Please select bank", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbBank.Focus()
				Else
					Dim flag4 As Boolean = Operators.CompareString(Me.txtBranchName.Text, "", False) = 0
					If flag4 Then
						MessageBox.Show("Please enter branch name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtBranchName.Focus()
					Else
						Dim flag5 As Boolean = Operators.CompareString(Me.txtAddress.Text, "", False) = 0
						If flag5 Then
							MessageBox.Show("Please enter address", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtAddress.Focus()
						Else
							Dim flag6 As Boolean = Operators.CompareString(Me.txtContactNo.Text, "", False) = 0
							If flag6 Then
								MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtContactNo.Focus()
							Else
								Try
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text2 As String = "select BranchName from BankBranch where BranchName=@d1"
									ModCommonClasses.cmd = New SqlCommand(text2)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBranchName.Text)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
									If flag7 Then
										MessageBox.Show("Branch Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Me.txtBranchName.Text = ""
										Me.txtBranchName.Focus()
										Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
										If flag8 Then
											ModCommonClasses.rdr.Close()
										End If
									Else
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text3 As String = "insert into BankBranch(ID,BranchName,Address,ContactNo,SwiftCode,IFSCCode,BankName) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)"
										ModCommonClasses.cmd = New SqlCommand(text3)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBranchName.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtAddress.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtContactNo.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtSwiftCode.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtIFSCCode.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.cmbBank.Text)
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										Dim text4 As String = "added the new bank's branch '" + Me.txtBranchName.Text + "' info"
										ModFunc.LogFunc(Me.lblUser.Text, text4)
										MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										Me.btnSave.Enabled = False
										Me.Getdata()
									End If
								Catch ex As Exception
									MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								End Try
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600BA30 RID: 47664 RVA: 0x0077C2A4 File Offset: 0x0077A4A4
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.cmbBank.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please select bank", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbBank.Focus()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.txtBranchName.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please enter branch name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtBranchName.Focus()
				Else
					Dim flag3 As Boolean = Operators.CompareString(Me.txtAddress.Text, "", False) = 0
					If flag3 Then
						MessageBox.Show("Please enter address", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtAddress.Focus()
					Else
						Dim flag4 As Boolean = Operators.CompareString(Me.txtContactNo.Text, "", False) = 0
						If flag4 Then
							MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtContactNo.Focus()
						Else
							Try
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text As String = "Update BankBranch set BranchName=@d2,Address=@d3,ContactNo=@d4,SwiftCode=@d5,IFSCCode=@d6,BankName=@d7 where ID=@d1"
								ModCommonClasses.cmd = New SqlCommand(text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBranchName.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtAddress.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtContactNo.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtSwiftCode.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtIFSCCode.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.cmbBank.Text)
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.con.Close()
								Dim text2 As String = "updated the bank's branch '" + Me.txtBranchName.Text + "' info"
								ModFunc.LogFunc(Me.lblUser.Text, text2)
								MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.btnUpdate.Enabled = False
								Me.Getdata()
							Catch ex As Exception
								MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600BA31 RID: 47665 RVA: 0x0077C594 File Offset: 0x0077A794
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
