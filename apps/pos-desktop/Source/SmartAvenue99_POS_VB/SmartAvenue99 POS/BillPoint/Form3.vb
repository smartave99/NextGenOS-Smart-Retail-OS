Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000068 RID: 104
	<DesignerGenerated()>
	Public Partial Class Form3
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001329 RID: 4905 RVA: 0x000105DC File Offset: 0x0000E7DC
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.Form3_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x170007D1 RID: 2001
		' (get) Token: 0x0600132C RID: 4908 RVA: 0x000105FC File Offset: 0x0000E7FC
		' (set) Token: 0x0600132D RID: 4909 RVA: 0x00010606 File Offset: 0x0000E806
		Friend Overridable Property Label1 As Label

		' Token: 0x170007D2 RID: 2002
		' (get) Token: 0x0600132E RID: 4910 RVA: 0x0001060F File Offset: 0x0000E80F
		' (set) Token: 0x0600132F RID: 4911 RVA: 0x00010619 File Offset: 0x0000E819
		Friend Overridable Property Label2 As Label

		' Token: 0x170007D3 RID: 2003
		' (get) Token: 0x06001330 RID: 4912 RVA: 0x00010622 File Offset: 0x0000E822
		' (set) Token: 0x06001331 RID: 4913 RVA: 0x0001062C File Offset: 0x0000E82C
		Friend Overridable Property Label3 As Label

		' Token: 0x170007D4 RID: 2004
		' (get) Token: 0x06001332 RID: 4914 RVA: 0x00010635 File Offset: 0x0000E835
		' (set) Token: 0x06001333 RID: 4915 RVA: 0x0001063F File Offset: 0x0000E83F
		Friend Overridable Property Label4 As Label

		' Token: 0x170007D5 RID: 2005
		' (get) Token: 0x06001334 RID: 4916 RVA: 0x00010648 File Offset: 0x0000E848
		' (set) Token: 0x06001335 RID: 4917 RVA: 0x00010652 File Offset: 0x0000E852
		Friend Overridable Property Label5 As Label

		' Token: 0x170007D6 RID: 2006
		' (get) Token: 0x06001336 RID: 4918 RVA: 0x0001065B File Offset: 0x0000E85B
		' (set) Token: 0x06001337 RID: 4919 RVA: 0x00010665 File Offset: 0x0000E865
		Friend Overridable Property Label6 As Label

		' Token: 0x170007D7 RID: 2007
		' (get) Token: 0x06001338 RID: 4920 RVA: 0x0001066E File Offset: 0x0000E86E
		' (set) Token: 0x06001339 RID: 4921 RVA: 0x00010678 File Offset: 0x0000E878
		Friend Overridable Property Label7 As Label

		' Token: 0x170007D8 RID: 2008
		' (get) Token: 0x0600133A RID: 4922 RVA: 0x00010681 File Offset: 0x0000E881
		' (set) Token: 0x0600133B RID: 4923 RVA: 0x0001068B File Offset: 0x0000E88B
		Friend Overridable Property Label8 As Label

		' Token: 0x170007D9 RID: 2009
		' (get) Token: 0x0600133C RID: 4924 RVA: 0x00010694 File Offset: 0x0000E894
		' (set) Token: 0x0600133D RID: 4925 RVA: 0x0001069E File Offset: 0x0000E89E
		Friend Overridable Property Label9 As Label

		' Token: 0x170007DA RID: 2010
		' (get) Token: 0x0600133E RID: 4926 RVA: 0x000106A7 File Offset: 0x0000E8A7
		' (set) Token: 0x0600133F RID: 4927 RVA: 0x000106B1 File Offset: 0x0000E8B1
		Friend Overridable Property Label10 As Label

		' Token: 0x170007DB RID: 2011
		' (get) Token: 0x06001340 RID: 4928 RVA: 0x000106BA File Offset: 0x0000E8BA
		' (set) Token: 0x06001341 RID: 4929 RVA: 0x000106C4 File Offset: 0x0000E8C4
		Friend Overridable Property Label11 As Label

		' Token: 0x170007DC RID: 2012
		' (get) Token: 0x06001342 RID: 4930 RVA: 0x000106CD File Offset: 0x0000E8CD
		' (set) Token: 0x06001343 RID: 4931 RVA: 0x000106D7 File Offset: 0x0000E8D7
		Friend Overridable Property Label12 As Label

		' Token: 0x170007DD RID: 2013
		' (get) Token: 0x06001344 RID: 4932 RVA: 0x000106E0 File Offset: 0x0000E8E0
		' (set) Token: 0x06001345 RID: 4933 RVA: 0x000106EA File Offset: 0x0000E8EA
		Friend Overridable Property Label13 As Label

		' Token: 0x170007DE RID: 2014
		' (get) Token: 0x06001346 RID: 4934 RVA: 0x000106F3 File Offset: 0x0000E8F3
		' (set) Token: 0x06001347 RID: 4935 RVA: 0x000106FD File Offset: 0x0000E8FD
		Friend Overridable Property Label14 As Label

		' Token: 0x170007DF RID: 2015
		' (get) Token: 0x06001348 RID: 4936 RVA: 0x00010706 File Offset: 0x0000E906
		' (set) Token: 0x06001349 RID: 4937 RVA: 0x00010710 File Offset: 0x0000E910
		Friend Overridable Property TableLayoutPanel1 As TableLayoutPanel

		' Token: 0x170007E0 RID: 2016
		' (get) Token: 0x0600134A RID: 4938 RVA: 0x00010719 File Offset: 0x0000E919
		' (set) Token: 0x0600134B RID: 4939 RVA: 0x00010723 File Offset: 0x0000E923
		Friend Overridable Property Label15 As Label

		' Token: 0x170007E1 RID: 2017
		' (get) Token: 0x0600134C RID: 4940 RVA: 0x0001072C File Offset: 0x0000E92C
		' (set) Token: 0x0600134D RID: 4941 RVA: 0x00010736 File Offset: 0x0000E936
		Friend Overridable Property Label16 As Label

		' Token: 0x170007E2 RID: 2018
		' (get) Token: 0x0600134E RID: 4942 RVA: 0x0001073F File Offset: 0x0000E93F
		' (set) Token: 0x0600134F RID: 4943 RVA: 0x000D3444 File Offset: 0x000D1644
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

		' Token: 0x170007E3 RID: 2019
		' (get) Token: 0x06001350 RID: 4944 RVA: 0x00010749 File Offset: 0x0000E949
		' (set) Token: 0x06001351 RID: 4945 RVA: 0x00010753 File Offset: 0x0000E953
		Friend Overridable Property Label17 As Label

		' Token: 0x170007E4 RID: 2020
		' (get) Token: 0x06001352 RID: 4946 RVA: 0x0001075C File Offset: 0x0000E95C
		' (set) Token: 0x06001353 RID: 4947 RVA: 0x00010766 File Offset: 0x0000E966
		Friend Overridable Property DataGridView1 As DataGridView

		' Token: 0x170007E5 RID: 2021
		' (get) Token: 0x06001354 RID: 4948 RVA: 0x0001076F File Offset: 0x0000E96F
		' (set) Token: 0x06001355 RID: 4949 RVA: 0x00010779 File Offset: 0x0000E979
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170007E6 RID: 2022
		' (get) Token: 0x06001356 RID: 4950 RVA: 0x00010782 File Offset: 0x0000E982
		' (set) Token: 0x06001357 RID: 4951 RVA: 0x0001078C File Offset: 0x0000E98C
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170007E7 RID: 2023
		' (get) Token: 0x06001358 RID: 4952 RVA: 0x00010795 File Offset: 0x0000E995
		' (set) Token: 0x06001359 RID: 4953 RVA: 0x0001079F File Offset: 0x0000E99F
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x170007E8 RID: 2024
		' (get) Token: 0x0600135A RID: 4954 RVA: 0x000107A8 File Offset: 0x0000E9A8
		' (set) Token: 0x0600135B RID: 4955 RVA: 0x000107B2 File Offset: 0x0000E9B2
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x170007E9 RID: 2025
		' (get) Token: 0x0600135C RID: 4956 RVA: 0x000107BB File Offset: 0x0000E9BB
		' (set) Token: 0x0600135D RID: 4957 RVA: 0x000107C5 File Offset: 0x0000E9C5
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170007EA RID: 2026
		' (get) Token: 0x0600135E RID: 4958 RVA: 0x000107CE File Offset: 0x0000E9CE
		' (set) Token: 0x0600135F RID: 4959 RVA: 0x000107D8 File Offset: 0x0000E9D8
		Friend Overridable Property lblGT As Label

		' Token: 0x170007EB RID: 2027
		' (get) Token: 0x06001360 RID: 4960 RVA: 0x000107E1 File Offset: 0x0000E9E1
		' (set) Token: 0x06001361 RID: 4961 RVA: 0x000107EB File Offset: 0x0000E9EB
		Friend Overridable Property Label18 As Label

		' Token: 0x06001362 RID: 4962 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Form3_Load(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06001363 RID: 4963 RVA: 0x000D3488 File Offset: 0x000D1688
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Label16.Text = DateAndTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
		End Sub
	End Class
End Namespace
