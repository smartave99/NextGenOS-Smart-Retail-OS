Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000292 RID: 658
	<DesignerGenerated()>
	Public Partial Class frmAutoUPI
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600A759 RID: 42841 RVA: 0x00702178 File Offset: 0x00700378
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmAutoUPI_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmAutoUPI_KeyDown
			AddHandler MyBase.Closed, AddressOf Me.frmAutoUPI_Closed
			Me.InitializeComponent()
		End Sub

		' Token: 0x170040E4 RID: 16612
		' (get) Token: 0x0600A75C RID: 42844 RVA: 0x0004E1F3 File Offset: 0x0004C3F3
		' (set) Token: 0x0600A75D RID: 42845 RVA: 0x0004E1FD File Offset: 0x0004C3FD
		Friend Overridable Property panel1 As Panel

		' Token: 0x170040E5 RID: 16613
		' (get) Token: 0x0600A75E RID: 42846 RVA: 0x0004E206 File Offset: 0x0004C406
		' (set) Token: 0x0600A75F RID: 42847 RVA: 0x0004E210 File Offset: 0x0004C410
		Friend Overridable Property pBoxQR As PictureBox

		' Token: 0x170040E6 RID: 16614
		' (get) Token: 0x0600A760 RID: 42848 RVA: 0x0004E219 File Offset: 0x0004C419
		' (set) Token: 0x0600A761 RID: 42849 RVA: 0x00702848 File Offset: 0x00700A48
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

		' Token: 0x170040E7 RID: 16615
		' (get) Token: 0x0600A762 RID: 42850 RVA: 0x0004E223 File Offset: 0x0004C423
		' (set) Token: 0x0600A763 RID: 42851 RVA: 0x0070288C File Offset: 0x00700A8C
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

		' Token: 0x170040E8 RID: 16616
		' (get) Token: 0x0600A764 RID: 42852 RVA: 0x0004E22D File Offset: 0x0004C42D
		' (set) Token: 0x0600A765 RID: 42853 RVA: 0x0004E237 File Offset: 0x0004C437
		Friend Overridable Property Label1 As Label

		' Token: 0x170040E9 RID: 16617
		' (get) Token: 0x0600A766 RID: 42854 RVA: 0x0004E240 File Offset: 0x0004C440
		' (set) Token: 0x0600A767 RID: 42855 RVA: 0x0004E24A File Offset: 0x0004C44A
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x170040EA RID: 16618
		' (get) Token: 0x0600A768 RID: 42856 RVA: 0x0004E253 File Offset: 0x0004C453
		' (set) Token: 0x0600A769 RID: 42857 RVA: 0x0004E25D File Offset: 0x0004C45D
		Friend Overridable Property Label2 As Label

		' Token: 0x0600A76A RID: 42858 RVA: 0x007028D0 File Offset: 0x00700AD0
		Public Sub Load_frmapartinfo_IntoPanel()
			Me.panel1.Controls.Clear()
			Dim frmF2 As New Form2() With { .Size = Me.panel1.Size, .TopLevel = False, .Parent = Me.panel1 } : frmF2.Show()
		End Sub

		' Token: 0x0600A76B RID: 42859 RVA: 0x00702924 File Offset: 0x00700B24
		Public Sub Load_frmapartinfo_IntoPanel_Close()
			Me.panel1.Controls.Clear()
			Dim frmF2Close As New Form2() With { .Size = Me.panel1.Size, .TopLevel = False, .Parent = Me.panel1 } : frmF2Close.Close()
			MyProject.Forms.Form2.Close()
		End Sub

		' Token: 0x0600A76C RID: 42860 RVA: 0x00702988 File Offset: 0x00700B88
		Public Sub GetCustomerDisplayPort()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(CDPort),RTRIM(SecDisplay) from POSPrinterSetting where TillID=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Dns.GetHostName())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.custsecdisplay = ModCommonClasses.rdr.GetValue(1).ToString()
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
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600A76D RID: 42861 RVA: 0x00702A98 File Offset: 0x00700C98
		Private Sub frmAutoUPI_Load(sender As Object, e As EventArgs)
			Dim bank As Bank = New Bank()
			bank.AccountNo = Me.acac
			bank.IfscCode = Me.ifscifsc
			bank.PayeeName = Me.payee
			Try
				bank.Amount = New Double?(Double.Parse(Conversions.ToString(Me.amtamt)))
			Catch ex As Exception
				bank.Amount = Nothing
			End Try
			bank.TxnNote = Me.note
			Dim bitmap As Bitmap = UPI.Generate(bank)
			Me.pBoxQR.Image = bitmap
			MyProject.Forms.Form2.PictureBox1.Image = Me.pBoxQR.Image
			Me.Load_frmapartinfo_IntoPanel()
			Me.GetCustomerDisplayPort()
			Try
				Dim flag As Boolean = Operators.CompareString(Me.custsecdisplay, "Yes", False) = 0
				If flag Then
					Dim screen As Screen = Screen.AllScreens(1)
					MyProject.Forms.Form2.StartPosition = FormStartPosition.Manual
					MyProject.Forms.Form2.Location = screen.Bounds.Location + CType(New Point(100, 100), Size)
					MyProject.Forms.Form2.Show()
				End If
			Catch ex2 As Exception
			End Try
		End Sub

		' Token: 0x0600A76E RID: 42862 RVA: 0x0004E266 File Offset: 0x0004C466
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Me.Load_frmapartinfo_IntoPanel_Close()
		End Sub

		' Token: 0x0600A76F RID: 42863 RVA: 0x00702C0C File Offset: 0x00700E0C
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.custsecdisplay, "Yes", False) <> 0
			If flag Then
				MessageBox.Show("Extend display monitor is not activated !", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				MyProject.Forms.Form2.PictureBox1.Image = Me.pBoxQR.Image
				Me.Load_frmapartinfo_IntoPanel()
				Try
					Dim flag2 As Boolean = Operators.CompareString(Me.custsecdisplay, "Yes", False) = 0
					If flag2 Then
						Dim screen As Screen = Screen.AllScreens(1)
						MyProject.Forms.Form2.StartPosition = FormStartPosition.Manual
						MyProject.Forms.Form2.Location = screen.Bounds.Location + CType(New Point(100, 100), Size)
						MyProject.Forms.Form2.Show()
					End If
				Catch ex As Exception
					MessageBox.Show("Extend display monitor not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600A770 RID: 42864 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmAutoUPI_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600A771 RID: 42865 RVA: 0x0004E266 File Offset: 0x0004C466
		Private Sub frmAutoUPI_Closed(sender As Object, e As EventArgs)
			Me.Load_frmapartinfo_IntoPanel_Close()
		End Sub

		' Token: 0x040045C9 RID: 17865
		Public acac As String

		' Token: 0x040045CA RID: 17866
		Public ifscifsc As String

		' Token: 0x040045CB RID: 17867
		Public payee As String

		' Token: 0x040045CC RID: 17868
		Public note As String

		' Token: 0x040045CD RID: 17869
		Public custsecdisplay As String

		' Token: 0x040045CE RID: 17870
		Public amtamt As Double
	End Class
End Namespace
