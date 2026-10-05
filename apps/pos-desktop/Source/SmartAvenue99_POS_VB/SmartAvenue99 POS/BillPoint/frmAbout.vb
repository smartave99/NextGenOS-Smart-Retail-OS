Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005DE RID: 1502
	<DesignerGenerated()>
	Public NotInheritable Partial Class frmAbout
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06012708 RID: 75528 RVA: 0x0007E84B File Offset: 0x0007CA4B
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmAbout_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmAbout_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17007274 RID: 29300
		' (get) Token: 0x0601270A RID: 75530 RVA: 0x0007E87D File Offset: 0x0007CA7D
		' (set) Token: 0x0601270B RID: 75531 RVA: 0x0007E887 File Offset: 0x0007CA87
		Friend Property TableLayoutPanel As TableLayoutPanel

		' Token: 0x17007275 RID: 29301
		' (get) Token: 0x0601270C RID: 75532 RVA: 0x0007E890 File Offset: 0x0007CA90
		' (set) Token: 0x0601270D RID: 75533 RVA: 0x0007E89A File Offset: 0x0007CA9A
		Friend Property LogoPictureBox As PictureBox

		' Token: 0x17007276 RID: 29302
		' (get) Token: 0x0601270E RID: 75534 RVA: 0x0007E8A3 File Offset: 0x0007CAA3
		' (set) Token: 0x0601270F RID: 75535 RVA: 0x0007E8AD File Offset: 0x0007CAAD
		Friend Property LabelProductName As Label

		' Token: 0x17007277 RID: 29303
		' (get) Token: 0x06012710 RID: 75536 RVA: 0x0007E8B6 File Offset: 0x0007CAB6
		' (set) Token: 0x06012711 RID: 75537 RVA: 0x0007E8C0 File Offset: 0x0007CAC0
		Friend Property LabelVersion As Label

		' Token: 0x17007278 RID: 29304
		' (get) Token: 0x06012712 RID: 75538 RVA: 0x0007E8C9 File Offset: 0x0007CAC9
		' (set) Token: 0x06012713 RID: 75539 RVA: 0x0007E8D3 File Offset: 0x0007CAD3
		Friend Property LabelCompanyName As Label

		' Token: 0x17007279 RID: 29305
		' (get) Token: 0x06012714 RID: 75540 RVA: 0x0007E8DC File Offset: 0x0007CADC
		' (set) Token: 0x06012715 RID: 75541 RVA: 0x0007E8E6 File Offset: 0x0007CAE6
		Friend Property TextBoxDescription As TextBox

		' Token: 0x1700727A RID: 29306
		' (get) Token: 0x06012716 RID: 75542 RVA: 0x0007E8EF File Offset: 0x0007CAEF
		' (set) Token: 0x06012717 RID: 75543 RVA: 0x0007E8F9 File Offset: 0x0007CAF9
		Friend Property LabelCopyright As Label

		' Token: 0x1700727B RID: 29307
		' (get) Token: 0x06012719 RID: 75545 RVA: 0x0007E902 File Offset: 0x0007CB02
		' (set) Token: 0x0601271A RID: 75546 RVA: 0x0007E90C File Offset: 0x0007CB0C
		Friend Property Panel1 As Panel

		' Token: 0x1700727C RID: 29308
		' (get) Token: 0x0601271B RID: 75547 RVA: 0x0007E915 File Offset: 0x0007CB15
		' (set) Token: 0x0601271C RID: 75548 RVA: 0x0007E91F File Offset: 0x0007CB1F
		Friend Property Label2 As Label

		' Token: 0x1700727D RID: 29309
		' (get) Token: 0x0601271D RID: 75549 RVA: 0x0007E928 File Offset: 0x0007CB28
		' (set) Token: 0x0601271E RID: 75550 RVA: 0x0007E932 File Offset: 0x0007CB32
		Friend Property Label1 As Label

		' Token: 0x1700727E RID: 29310
		' (get) Token: 0x0601271F RID: 75551 RVA: 0x0007E93B File Offset: 0x0007CB3B
		' (set) Token: 0x06012720 RID: 75552 RVA: 0x0007E945 File Offset: 0x0007CB45
		Friend Property Label4 As Label

		' Token: 0x1700727F RID: 29311
		' (get) Token: 0x06012721 RID: 75553 RVA: 0x0007E94E File Offset: 0x0007CB4E
		' (set) Token: 0x06012722 RID: 75554 RVA: 0x0007E958 File Offset: 0x0007CB58
		Friend Property Label3 As Label

		' Token: 0x17007280 RID: 29312
		' (get) Token: 0x06012723 RID: 75555 RVA: 0x0007E961 File Offset: 0x0007CB61
		' (set) Token: 0x06012724 RID: 75556 RVA: 0x0007E96B File Offset: 0x0007CB6B
		Friend Property Label5 As Label

		' Token: 0x17007281 RID: 29313
		' (get) Token: 0x06012725 RID: 75557 RVA: 0x0007E974 File Offset: 0x0007CB74
		' (set) Token: 0x06012726 RID: 75558 RVA: 0x00A9DD98 File Offset: 0x00A9BF98
		Private _LinkLabel1 As LinkLabel

		Friend Property LinkLabel1 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel1_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel1
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel1 = value
				linkLabel = Me._LinkLabel1
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007282 RID: 29314
		' (get) Token: 0x06012727 RID: 75559 RVA: 0x0007E97E File Offset: 0x0007CB7E
		' (set) Token: 0x06012728 RID: 75560 RVA: 0x0007E988 File Offset: 0x0007CB88
		Friend Property Label6 As Label

		' Token: 0x06012729 RID: 75561 RVA: 0x00A9DDDC File Offset: 0x00A9BFDC
		Private Sub frmAbout_Load(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(MyProject.Application.Info.Title, "", False) <> 0
			If flag Then
				Dim text As String = MyProject.Application.Info.Title
			Else
				Dim text As String = Path.GetFileNameWithoutExtension(MyProject.Application.Info.AssemblyName)
			End If
			Me.Text = String.Format("About", New Object(-1) {})
			Me.LabelProductName.Text = MyProject.Application.Info.ProductName
			Me.LabelVersion.Text = String.Format("Version {0}", MyProject.Application.Info.Version.ToString().Substring(0, 3))
			Me.LabelCopyright.Text = MyProject.Application.Info.Copyright
			Me.LabelCompanyName.Text = MyProject.Application.Info.CompanyName
			Me.LinkLabel1.TabStop = False
			Try
				Dim flag2 As Boolean = Operators.CompareString(ModFunc.GetValue1("Upd_Avl"), String.Format(MyProject.Application.Info.Version.ToString().Substring(0, 3), New Object(-1) {}), False) <> 0
				If flag2 Then
					Me.Label6.Text = "Update Avaliable"
					Me.LinkLabel1.Visible = True
				Else
					Me.Label6.Text = "You already have update version"
					Me.LinkLabel1.Visible = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0601272A RID: 75562 RVA: 0x00A9DF7C File Offset: 0x00A9C17C
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
			If flag Then
				Interaction.MsgBox("Internet Connection not avaliable !", MsgBoxStyle.Information, "Info")
			Else
				Dim flag2 As Boolean = Operators.CompareString(ModFunc.GetValue1("Upd_Avl"), String.Format(MyProject.Application.Info.Version.ToString().Substring(0, 3), New Object(-1) {}), False) <> 0
				If flag2 Then
					Try
						Process.Start(MyProject.Application.Info.DirectoryPath + "\Downloader.exe")
					Catch ex As Exception
					End Try
					Application.[Exit]()
				Else
					Me.Label6.Text = "You already have update version"
					Me.LinkLabel1.Visible = False
					MessageBox.Show("You already have update version", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
			End If
		End Sub

		' Token: 0x0601272B RID: 75563 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmAbout_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub
	End Class
End Namespace
