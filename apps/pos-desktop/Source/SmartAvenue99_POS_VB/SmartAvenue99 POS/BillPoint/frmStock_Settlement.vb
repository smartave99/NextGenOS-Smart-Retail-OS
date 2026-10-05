Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x020001FC RID: 508
	<DesignerGenerated()>
	Public Partial Class frmStock_Settlement
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060091B7 RID: 37303 RVA: 0x00047418 File Offset: 0x00045618
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmStock_Settlement_Load
			Me.SkipListViewReset = False
			Me.InitializeComponent()
		End Sub

		' Token: 0x170035F4 RID: 13812
		' (get) Token: 0x060091BA RID: 37306 RVA: 0x00047442 File Offset: 0x00045642
		' (set) Token: 0x060091BB RID: 37307 RVA: 0x0004744C File Offset: 0x0004564C
		Friend Overridable Property listView1 As ListView

		' Token: 0x170035F5 RID: 13813
		' (get) Token: 0x060091BC RID: 37308 RVA: 0x00047455 File Offset: 0x00045655
		' (set) Token: 0x060091BD RID: 37309 RVA: 0x0004745F File Offset: 0x0004565F
		Protected Overridable Property ColumnHeader1 As ColumnHeader

		' Token: 0x170035F6 RID: 13814
		' (get) Token: 0x060091BE RID: 37310 RVA: 0x00047468 File Offset: 0x00045668
		' (set) Token: 0x060091BF RID: 37311 RVA: 0x00047472 File Offset: 0x00045672
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x170035F7 RID: 13815
		' (get) Token: 0x060091C0 RID: 37312 RVA: 0x0004747B File Offset: 0x0004567B
		' (set) Token: 0x060091C1 RID: 37313 RVA: 0x00047485 File Offset: 0x00045685
		Friend Overridable Property ColumnHeader31 As ColumnHeader

		' Token: 0x170035F8 RID: 13816
		' (get) Token: 0x060091C2 RID: 37314 RVA: 0x0004748E File Offset: 0x0004568E
		' (set) Token: 0x060091C3 RID: 37315 RVA: 0x00047498 File Offset: 0x00045698
		Friend Overridable Property ColumnHeader3 As ColumnHeader

		' Token: 0x170035F9 RID: 13817
		' (get) Token: 0x060091C4 RID: 37316 RVA: 0x000474A1 File Offset: 0x000456A1
		' (set) Token: 0x060091C5 RID: 37317 RVA: 0x000474AB File Offset: 0x000456AB
		Friend Overridable Property ColumnHeader4 As ColumnHeader

		' Token: 0x170035FA RID: 13818
		' (get) Token: 0x060091C6 RID: 37318 RVA: 0x000474B4 File Offset: 0x000456B4
		' (set) Token: 0x060091C7 RID: 37319 RVA: 0x000474BE File Offset: 0x000456BE
		Friend Overridable Property ColumnHeader5 As ColumnHeader

		' Token: 0x170035FB RID: 13819
		' (get) Token: 0x060091C8 RID: 37320 RVA: 0x000474C7 File Offset: 0x000456C7
		' (set) Token: 0x060091C9 RID: 37321 RVA: 0x000474D1 File Offset: 0x000456D1
		Friend Overridable Property ColumnHeader6 As ColumnHeader

		' Token: 0x170035FC RID: 13820
		' (get) Token: 0x060091CA RID: 37322 RVA: 0x000474DA File Offset: 0x000456DA
		' (set) Token: 0x060091CB RID: 37323 RVA: 0x000474E4 File Offset: 0x000456E4
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x170035FD RID: 13821
		' (get) Token: 0x060091CC RID: 37324 RVA: 0x000474ED File Offset: 0x000456ED
		' (set) Token: 0x060091CD RID: 37325 RVA: 0x000474F7 File Offset: 0x000456F7
		Friend Overridable Property ColumnHeader19 As ColumnHeader

		' Token: 0x170035FE RID: 13822
		' (get) Token: 0x060091CE RID: 37326 RVA: 0x00047500 File Offset: 0x00045700
		' (set) Token: 0x060091CF RID: 37327 RVA: 0x0004750A File Offset: 0x0004570A
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x170035FF RID: 13823
		' (get) Token: 0x060091D0 RID: 37328 RVA: 0x00047513 File Offset: 0x00045713
		' (set) Token: 0x060091D1 RID: 37329 RVA: 0x0004751D File Offset: 0x0004571D
		Friend Overridable Property ColumnHeader9 As ColumnHeader

		' Token: 0x17003600 RID: 13824
		' (get) Token: 0x060091D2 RID: 37330 RVA: 0x00047526 File Offset: 0x00045726
		' (set) Token: 0x060091D3 RID: 37331 RVA: 0x00047530 File Offset: 0x00045730
		Friend Overridable Property ColumnHeader10 As ColumnHeader

		' Token: 0x17003601 RID: 13825
		' (get) Token: 0x060091D4 RID: 37332 RVA: 0x00047539 File Offset: 0x00045739
		' (set) Token: 0x060091D5 RID: 37333 RVA: 0x00047543 File Offset: 0x00045743
		Friend Overridable Property ColumnHeader11 As ColumnHeader

		' Token: 0x17003602 RID: 13826
		' (get) Token: 0x060091D6 RID: 37334 RVA: 0x0004754C File Offset: 0x0004574C
		' (set) Token: 0x060091D7 RID: 37335 RVA: 0x00047556 File Offset: 0x00045756
		Friend Overridable Property ColumnHeader12 As ColumnHeader

		' Token: 0x17003603 RID: 13827
		' (get) Token: 0x060091D8 RID: 37336 RVA: 0x0004755F File Offset: 0x0004575F
		' (set) Token: 0x060091D9 RID: 37337 RVA: 0x00047569 File Offset: 0x00045769
		Friend Overridable Property ColumnHeader13 As ColumnHeader

		' Token: 0x17003604 RID: 13828
		' (get) Token: 0x060091DA RID: 37338 RVA: 0x00047572 File Offset: 0x00045772
		' (set) Token: 0x060091DB RID: 37339 RVA: 0x0004757C File Offset: 0x0004577C
		Friend Overridable Property ColumnHeader15 As ColumnHeader

		' Token: 0x17003605 RID: 13829
		' (get) Token: 0x060091DC RID: 37340 RVA: 0x00047585 File Offset: 0x00045785
		' (set) Token: 0x060091DD RID: 37341 RVA: 0x0004758F File Offset: 0x0004578F
		Friend Overridable Property ColumnHeader16 As ColumnHeader

		' Token: 0x17003606 RID: 13830
		' (get) Token: 0x060091DE RID: 37342 RVA: 0x00047598 File Offset: 0x00045798
		' (set) Token: 0x060091DF RID: 37343 RVA: 0x000475A2 File Offset: 0x000457A2
		Friend Overridable Property ColumnHeader17 As ColumnHeader

		' Token: 0x17003607 RID: 13831
		' (get) Token: 0x060091E0 RID: 37344 RVA: 0x000475AB File Offset: 0x000457AB
		' (set) Token: 0x060091E1 RID: 37345 RVA: 0x000475B5 File Offset: 0x000457B5
		Friend Overridable Property ColumnHeader18 As ColumnHeader

		' Token: 0x17003608 RID: 13832
		' (get) Token: 0x060091E2 RID: 37346 RVA: 0x000475BE File Offset: 0x000457BE
		' (set) Token: 0x060091E3 RID: 37347 RVA: 0x000475C8 File Offset: 0x000457C8
		Friend Overridable Property ColumnHeader14 As ColumnHeader

		' Token: 0x17003609 RID: 13833
		' (get) Token: 0x060091E4 RID: 37348 RVA: 0x000475D1 File Offset: 0x000457D1
		' (set) Token: 0x060091E5 RID: 37349 RVA: 0x000475DB File Offset: 0x000457DB
		Friend Overridable Property ColumnHeader20 As ColumnHeader

		' Token: 0x1700360A RID: 13834
		' (get) Token: 0x060091E6 RID: 37350 RVA: 0x000475E4 File Offset: 0x000457E4
		' (set) Token: 0x060091E7 RID: 37351 RVA: 0x000475EE File Offset: 0x000457EE
		Friend Overridable Property ColumnHeader21 As ColumnHeader

		' Token: 0x1700360B RID: 13835
		' (get) Token: 0x060091E8 RID: 37352 RVA: 0x000475F7 File Offset: 0x000457F7
		' (set) Token: 0x060091E9 RID: 37353 RVA: 0x00047601 File Offset: 0x00045801
		Friend Overridable Property ColumnHeader22 As ColumnHeader

		' Token: 0x1700360C RID: 13836
		' (get) Token: 0x060091EA RID: 37354 RVA: 0x0004760A File Offset: 0x0004580A
		' (set) Token: 0x060091EB RID: 37355 RVA: 0x00047614 File Offset: 0x00045814
		Friend Overridable Property ColumnHeader23 As ColumnHeader

		' Token: 0x1700360D RID: 13837
		' (get) Token: 0x060091EC RID: 37356 RVA: 0x0004761D File Offset: 0x0004581D
		' (set) Token: 0x060091ED RID: 37357 RVA: 0x00047627 File Offset: 0x00045827
		Friend Overridable Property ColumnHeader24 As ColumnHeader

		' Token: 0x1700360E RID: 13838
		' (get) Token: 0x060091EE RID: 37358 RVA: 0x00047630 File Offset: 0x00045830
		' (set) Token: 0x060091EF RID: 37359 RVA: 0x0004763A File Offset: 0x0004583A
		Friend Overridable Property ColumnHeader25 As ColumnHeader

		' Token: 0x1700360F RID: 13839
		' (get) Token: 0x060091F0 RID: 37360 RVA: 0x00047643 File Offset: 0x00045843
		' (set) Token: 0x060091F1 RID: 37361 RVA: 0x0004764D File Offset: 0x0004584D
		Friend Overridable Property ColumnHeader26 As ColumnHeader

		' Token: 0x17003610 RID: 13840
		' (get) Token: 0x060091F2 RID: 37362 RVA: 0x00047656 File Offset: 0x00045856
		' (set) Token: 0x060091F3 RID: 37363 RVA: 0x00047660 File Offset: 0x00045860
		Friend Overridable Property ColumnHeader27 As ColumnHeader

		' Token: 0x17003611 RID: 13841
		' (get) Token: 0x060091F4 RID: 37364 RVA: 0x00047669 File Offset: 0x00045869
		' (set) Token: 0x060091F5 RID: 37365 RVA: 0x00047673 File Offset: 0x00045873
		Friend Overridable Property ColumnHeader28 As ColumnHeader

		' Token: 0x17003612 RID: 13842
		' (get) Token: 0x060091F6 RID: 37366 RVA: 0x0004767C File Offset: 0x0004587C
		' (set) Token: 0x060091F7 RID: 37367 RVA: 0x00047686 File Offset: 0x00045886
		Friend Overridable Property ColumnHeader29 As ColumnHeader

		' Token: 0x17003613 RID: 13843
		' (get) Token: 0x060091F8 RID: 37368 RVA: 0x0004768F File Offset: 0x0004588F
		' (set) Token: 0x060091F9 RID: 37369 RVA: 0x00047699 File Offset: 0x00045899
		Friend Overridable Property ColumnHeader30 As ColumnHeader

		' Token: 0x17003614 RID: 13844
		' (get) Token: 0x060091FA RID: 37370 RVA: 0x000476A2 File Offset: 0x000458A2
		' (set) Token: 0x060091FB RID: 37371 RVA: 0x000476AC File Offset: 0x000458AC
		Friend Overridable Property ColumnHeader32 As ColumnHeader

		' Token: 0x17003615 RID: 13845
		' (get) Token: 0x060091FC RID: 37372 RVA: 0x000476B5 File Offset: 0x000458B5
		' (set) Token: 0x060091FD RID: 37373 RVA: 0x000476BF File Offset: 0x000458BF
		Friend Overridable Property ColumnHeader33 As ColumnHeader

		' Token: 0x17003616 RID: 13846
		' (get) Token: 0x060091FE RID: 37374 RVA: 0x000476C8 File Offset: 0x000458C8
		' (set) Token: 0x060091FF RID: 37375 RVA: 0x000476D2 File Offset: 0x000458D2
		Friend Overridable Property ColumnHeader34 As ColumnHeader

		' Token: 0x17003617 RID: 13847
		' (get) Token: 0x06009200 RID: 37376 RVA: 0x000476DB File Offset: 0x000458DB
		' (set) Token: 0x06009201 RID: 37377 RVA: 0x000476E5 File Offset: 0x000458E5
		Friend Overridable Property ColumnHeader35 As ColumnHeader

		' Token: 0x17003618 RID: 13848
		' (get) Token: 0x06009202 RID: 37378 RVA: 0x000476EE File Offset: 0x000458EE
		' (set) Token: 0x06009203 RID: 37379 RVA: 0x000476F8 File Offset: 0x000458F8
		Friend Overridable Property ColumnHeader36 As ColumnHeader

		' Token: 0x17003619 RID: 13849
		' (get) Token: 0x06009204 RID: 37380 RVA: 0x00047701 File Offset: 0x00045901
		' (set) Token: 0x06009205 RID: 37381 RVA: 0x0004770B File Offset: 0x0004590B
		Friend Overridable Property ColumnHeader37 As ColumnHeader

		' Token: 0x1700361A RID: 13850
		' (get) Token: 0x06009206 RID: 37382 RVA: 0x00047714 File Offset: 0x00045914
		' (set) Token: 0x06009207 RID: 37383 RVA: 0x0004771E File Offset: 0x0004591E
		Friend Overridable Property ColumnHeader38 As ColumnHeader

		' Token: 0x1700361B RID: 13851
		' (get) Token: 0x06009208 RID: 37384 RVA: 0x00047727 File Offset: 0x00045927
		' (set) Token: 0x06009209 RID: 37385 RVA: 0x00047731 File Offset: 0x00045931
		Friend Overridable Property ColumnHeader40 As ColumnHeader

		' Token: 0x1700361C RID: 13852
		' (get) Token: 0x0600920A RID: 37386 RVA: 0x0004773A File Offset: 0x0004593A
		' (set) Token: 0x0600920B RID: 37387 RVA: 0x00047744 File Offset: 0x00045944
		Friend Overridable Property ColumnHeader41 As ColumnHeader

		' Token: 0x1700361D RID: 13853
		' (get) Token: 0x0600920C RID: 37388 RVA: 0x0004774D File Offset: 0x0004594D
		' (set) Token: 0x0600920D RID: 37389 RVA: 0x006A1658 File Offset: 0x0069F858
		Private _btnDToken As GelButton
		Friend Overridable Property btnDToken As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDToken
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDToken_Click
				Dim gelButton As GelButton = Me._btnDToken
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDToken = value
				gelButton = Me._btnDToken
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700361E RID: 13854
		' (get) Token: 0x0600920E RID: 37390 RVA: 0x00047757 File Offset: 0x00045957
		' (set) Token: 0x0600920F RID: 37391 RVA: 0x00047761 File Offset: 0x00045961
		Friend Overridable Property GroupBox5 As GroupBox

		' Token: 0x1700361F RID: 13855
		' (get) Token: 0x06009210 RID: 37392 RVA: 0x0004776A File Offset: 0x0004596A
		' (set) Token: 0x06009211 RID: 37393 RVA: 0x00047774 File Offset: 0x00045974
		Friend Overridable Property txtCompany_to As TextBox

		' Token: 0x17003620 RID: 13856
		' (get) Token: 0x06009212 RID: 37394 RVA: 0x0004777D File Offset: 0x0004597D
		' (set) Token: 0x06009213 RID: 37395 RVA: 0x00047787 File Offset: 0x00045987
		Friend Overridable Property txtCompany_id_from As TextBox

		' Token: 0x17003621 RID: 13857
		' (get) Token: 0x06009214 RID: 37396 RVA: 0x00047790 File Offset: 0x00045990
		' (set) Token: 0x06009215 RID: 37397 RVA: 0x0004779A File Offset: 0x0004599A
		Friend Overridable Property Label136 As Label

		' Token: 0x17003622 RID: 13858
		' (get) Token: 0x06009216 RID: 37398 RVA: 0x000477A3 File Offset: 0x000459A3
		' (set) Token: 0x06009217 RID: 37399 RVA: 0x000477AD File Offset: 0x000459AD
		Friend Overridable Property Label135 As Label

		' Token: 0x17003623 RID: 13859
		' (get) Token: 0x06009218 RID: 37400 RVA: 0x000477B6 File Offset: 0x000459B6
		' (set) Token: 0x06009219 RID: 37401 RVA: 0x000477C0 File Offset: 0x000459C0
		Friend Overridable Property cmbToCompany As ComboBox

		' Token: 0x17003624 RID: 13860
		' (get) Token: 0x0600921A RID: 37402 RVA: 0x000477C9 File Offset: 0x000459C9
		' (set) Token: 0x0600921B RID: 37403 RVA: 0x000477D3 File Offset: 0x000459D3
		Friend Overridable Property DataGridView1 As DataGridView

		' Token: 0x17003625 RID: 13861
		' (get) Token: 0x0600921C RID: 37404 RVA: 0x000477DC File Offset: 0x000459DC
		' (set) Token: 0x0600921D RID: 37405 RVA: 0x000477E6 File Offset: 0x000459E6
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17003626 RID: 13862
		' (get) Token: 0x0600921E RID: 37406 RVA: 0x000477EF File Offset: 0x000459EF
		' (set) Token: 0x0600921F RID: 37407 RVA: 0x000477F9 File Offset: 0x000459F9
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17003627 RID: 13863
		' (get) Token: 0x06009220 RID: 37408 RVA: 0x00047802 File Offset: 0x00045A02
		' (set) Token: 0x06009221 RID: 37409 RVA: 0x0004780C File Offset: 0x00045A0C
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17003628 RID: 13864
		' (get) Token: 0x06009222 RID: 37410 RVA: 0x00047815 File Offset: 0x00045A15
		' (set) Token: 0x06009223 RID: 37411 RVA: 0x0004781F File Offset: 0x00045A1F
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17003629 RID: 13865
		' (get) Token: 0x06009224 RID: 37412 RVA: 0x00047828 File Offset: 0x00045A28
		' (set) Token: 0x06009225 RID: 37413 RVA: 0x00047832 File Offset: 0x00045A32
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700362A RID: 13866
		' (get) Token: 0x06009226 RID: 37414 RVA: 0x0004783B File Offset: 0x00045A3B
		' (set) Token: 0x06009227 RID: 37415 RVA: 0x00047845 File Offset: 0x00045A45
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700362B RID: 13867
		' (get) Token: 0x06009228 RID: 37416 RVA: 0x0004784E File Offset: 0x00045A4E
		' (set) Token: 0x06009229 RID: 37417 RVA: 0x00047858 File Offset: 0x00045A58
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x1700362C RID: 13868
		' (get) Token: 0x0600922A RID: 37418 RVA: 0x00047861 File Offset: 0x00045A61
		' (set) Token: 0x0600922B RID: 37419 RVA: 0x0004786B File Offset: 0x00045A6B
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x1700362D RID: 13869
		' (get) Token: 0x0600922C RID: 37420 RVA: 0x00047874 File Offset: 0x00045A74
		' (set) Token: 0x0600922D RID: 37421 RVA: 0x0004787E File Offset: 0x00045A7E
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x1700362E RID: 13870
		' (get) Token: 0x0600922E RID: 37422 RVA: 0x00047887 File Offset: 0x00045A87
		' (set) Token: 0x0600922F RID: 37423 RVA: 0x00047891 File Offset: 0x00045A91
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x1700362F RID: 13871
		' (get) Token: 0x06009230 RID: 37424 RVA: 0x0004789A File Offset: 0x00045A9A
		' (set) Token: 0x06009231 RID: 37425 RVA: 0x000478A4 File Offset: 0x00045AA4
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17003630 RID: 13872
		' (get) Token: 0x06009232 RID: 37426 RVA: 0x000478AD File Offset: 0x00045AAD
		' (set) Token: 0x06009233 RID: 37427 RVA: 0x000478B7 File Offset: 0x00045AB7
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17003631 RID: 13873
		' (get) Token: 0x06009234 RID: 37428 RVA: 0x000478C0 File Offset: 0x00045AC0
		' (set) Token: 0x06009235 RID: 37429 RVA: 0x000478CA File Offset: 0x00045ACA
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17003632 RID: 13874
		' (get) Token: 0x06009236 RID: 37430 RVA: 0x000478D3 File Offset: 0x00045AD3
		' (set) Token: 0x06009237 RID: 37431 RVA: 0x000478DD File Offset: 0x00045ADD
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17003633 RID: 13875
		' (get) Token: 0x06009238 RID: 37432 RVA: 0x000478E6 File Offset: 0x00045AE6
		' (set) Token: 0x06009239 RID: 37433 RVA: 0x000478F0 File Offset: 0x00045AF0
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17003634 RID: 13876
		' (get) Token: 0x0600923A RID: 37434 RVA: 0x000478F9 File Offset: 0x00045AF9
		' (set) Token: 0x0600923B RID: 37435 RVA: 0x00047903 File Offset: 0x00045B03
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17003635 RID: 13877
		' (get) Token: 0x0600923C RID: 37436 RVA: 0x0004790C File Offset: 0x00045B0C
		' (set) Token: 0x0600923D RID: 37437 RVA: 0x00047916 File Offset: 0x00045B16
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17003636 RID: 13878
		' (get) Token: 0x0600923E RID: 37438 RVA: 0x0004791F File Offset: 0x00045B1F
		' (set) Token: 0x0600923F RID: 37439 RVA: 0x00047929 File Offset: 0x00045B29
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17003637 RID: 13879
		' (get) Token: 0x06009240 RID: 37440 RVA: 0x00047932 File Offset: 0x00045B32
		' (set) Token: 0x06009241 RID: 37441 RVA: 0x0004793C File Offset: 0x00045B3C
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17003638 RID: 13880
		' (get) Token: 0x06009242 RID: 37442 RVA: 0x00047945 File Offset: 0x00045B45
		' (set) Token: 0x06009243 RID: 37443 RVA: 0x0004794F File Offset: 0x00045B4F
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17003639 RID: 13881
		' (get) Token: 0x06009244 RID: 37444 RVA: 0x00047958 File Offset: 0x00045B58
		' (set) Token: 0x06009245 RID: 37445 RVA: 0x00047962 File Offset: 0x00045B62
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x1700363A RID: 13882
		' (get) Token: 0x06009246 RID: 37446 RVA: 0x0004796B File Offset: 0x00045B6B
		' (set) Token: 0x06009247 RID: 37447 RVA: 0x00047975 File Offset: 0x00045B75
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x1700363B RID: 13883
		' (get) Token: 0x06009248 RID: 37448 RVA: 0x0004797E File Offset: 0x00045B7E
		' (set) Token: 0x06009249 RID: 37449 RVA: 0x00047988 File Offset: 0x00045B88
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x1700363C RID: 13884
		' (get) Token: 0x0600924A RID: 37450 RVA: 0x00047991 File Offset: 0x00045B91
		' (set) Token: 0x0600924B RID: 37451 RVA: 0x0004799B File Offset: 0x00045B9B
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x1700363D RID: 13885
		' (get) Token: 0x0600924C RID: 37452 RVA: 0x000479A4 File Offset: 0x00045BA4
		' (set) Token: 0x0600924D RID: 37453 RVA: 0x000479AE File Offset: 0x00045BAE
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x1700363E RID: 13886
		' (get) Token: 0x0600924E RID: 37454 RVA: 0x000479B7 File Offset: 0x00045BB7
		' (set) Token: 0x0600924F RID: 37455 RVA: 0x000479C1 File Offset: 0x00045BC1
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x1700363F RID: 13887
		' (get) Token: 0x06009250 RID: 37456 RVA: 0x000479CA File Offset: 0x00045BCA
		' (set) Token: 0x06009251 RID: 37457 RVA: 0x000479D4 File Offset: 0x00045BD4
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17003640 RID: 13888
		' (get) Token: 0x06009252 RID: 37458 RVA: 0x000479DD File Offset: 0x00045BDD
		' (set) Token: 0x06009253 RID: 37459 RVA: 0x000479E7 File Offset: 0x00045BE7
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x17003641 RID: 13889
		' (get) Token: 0x06009254 RID: 37460 RVA: 0x000479F0 File Offset: 0x00045BF0
		' (set) Token: 0x06009255 RID: 37461 RVA: 0x000479FA File Offset: 0x00045BFA
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x17003642 RID: 13890
		' (get) Token: 0x06009256 RID: 37462 RVA: 0x00047A03 File Offset: 0x00045C03
		' (set) Token: 0x06009257 RID: 37463 RVA: 0x00047A0D File Offset: 0x00045C0D
		Friend Overridable Property Column36 As DataGridViewTextBoxColumn

		' Token: 0x17003643 RID: 13891
		' (get) Token: 0x06009258 RID: 37464 RVA: 0x00047A16 File Offset: 0x00045C16
		' (set) Token: 0x06009259 RID: 37465 RVA: 0x00047A20 File Offset: 0x00045C20
		Friend Overridable Property Column37 As DataGridViewTextBoxColumn

		' Token: 0x17003644 RID: 13892
		' (get) Token: 0x0600925A RID: 37466 RVA: 0x00047A29 File Offset: 0x00045C29
		' (set) Token: 0x0600925B RID: 37467 RVA: 0x00047A33 File Offset: 0x00045C33
		Friend Overridable Property Column38 As DataGridViewTextBoxColumn

		' Token: 0x17003645 RID: 13893
		' (get) Token: 0x0600925C RID: 37468 RVA: 0x00047A3C File Offset: 0x00045C3C
		' (set) Token: 0x0600925D RID: 37469 RVA: 0x00047A46 File Offset: 0x00045C46
		Friend Overridable Property Column39 As DataGridViewTextBoxColumn

		' Token: 0x17003646 RID: 13894
		' (get) Token: 0x0600925E RID: 37470 RVA: 0x00047A4F File Offset: 0x00045C4F
		' (set) Token: 0x0600925F RID: 37471 RVA: 0x00047A59 File Offset: 0x00045C59
		Friend Overridable Property Column40 As DataGridViewTextBoxColumn

		' Token: 0x17003647 RID: 13895
		' (get) Token: 0x06009260 RID: 37472 RVA: 0x00047A62 File Offset: 0x00045C62
		' (set) Token: 0x06009261 RID: 37473 RVA: 0x00047A6C File Offset: 0x00045C6C
		Friend Overridable Property Column41 As DataGridViewTextBoxColumn

		' Token: 0x17003648 RID: 13896
		' (get) Token: 0x06009262 RID: 37474 RVA: 0x00047A75 File Offset: 0x00045C75
		' (set) Token: 0x06009263 RID: 37475 RVA: 0x00047A7F File Offset: 0x00045C7F
		Friend Overridable Property Column42 As DataGridViewTextBoxColumn

		' Token: 0x17003649 RID: 13897
		' (get) Token: 0x06009264 RID: 37476 RVA: 0x00047A88 File Offset: 0x00045C88
		' (set) Token: 0x06009265 RID: 37477 RVA: 0x00047A92 File Offset: 0x00045C92
		Friend Overridable Property Column52 As DataGridViewTextBoxColumn

		' Token: 0x1700364A RID: 13898
		' (get) Token: 0x06009266 RID: 37478 RVA: 0x00047A9B File Offset: 0x00045C9B
		' (set) Token: 0x06009267 RID: 37479 RVA: 0x00047AA5 File Offset: 0x00045CA5
		Friend Overridable Property Column53 As DataGridViewTextBoxColumn

		' Token: 0x1700364B RID: 13899
		' (get) Token: 0x06009268 RID: 37480 RVA: 0x00047AAE File Offset: 0x00045CAE
		' (set) Token: 0x06009269 RID: 37481 RVA: 0x00047AB8 File Offset: 0x00045CB8
		Friend Overridable Property Column54 As DataGridViewTextBoxColumn

		' Token: 0x1700364C RID: 13900
		' (get) Token: 0x0600926A RID: 37482 RVA: 0x00047AC1 File Offset: 0x00045CC1
		' (set) Token: 0x0600926B RID: 37483 RVA: 0x00047ACB File Offset: 0x00045CCB
		Friend Overridable Property Column55 As DataGridViewTextBoxColumn

		' Token: 0x1700364D RID: 13901
		' (get) Token: 0x0600926C RID: 37484 RVA: 0x00047AD4 File Offset: 0x00045CD4
		' (set) Token: 0x0600926D RID: 37485 RVA: 0x00047ADE File Offset: 0x00045CDE
		Friend Overridable Property Column56 As DataGridViewTextBoxColumn

		' Token: 0x1700364E RID: 13902
		' (get) Token: 0x0600926E RID: 37486 RVA: 0x00047AE7 File Offset: 0x00045CE7
		' (set) Token: 0x0600926F RID: 37487 RVA: 0x00047AF1 File Offset: 0x00045CF1
		Friend Overridable Property Column57 As DataGridViewTextBoxColumn

		' Token: 0x1700364F RID: 13903
		' (get) Token: 0x06009270 RID: 37488 RVA: 0x00047AFA File Offset: 0x00045CFA
		' (set) Token: 0x06009271 RID: 37489 RVA: 0x00047B04 File Offset: 0x00045D04
		Friend Overridable Property Column58 As DataGridViewTextBoxColumn

		' Token: 0x17003650 RID: 13904
		' (get) Token: 0x06009272 RID: 37490 RVA: 0x00047B0D File Offset: 0x00045D0D
		' (set) Token: 0x06009273 RID: 37491 RVA: 0x00047B17 File Offset: 0x00045D17
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x17003651 RID: 13905
		' (get) Token: 0x06009274 RID: 37492 RVA: 0x00047B20 File Offset: 0x00045D20
		' (set) Token: 0x06009275 RID: 37493 RVA: 0x00047B2A File Offset: 0x00045D2A
		Public Overridable Property Picture As PictureBox

		' Token: 0x17003652 RID: 13906
		' (get) Token: 0x06009276 RID: 37494 RVA: 0x00047B33 File Offset: 0x00045D33
		' (set) Token: 0x06009277 RID: 37495 RVA: 0x00047B3D File Offset: 0x00045D3D
		Friend Overridable Property lblUserType As Label

		' Token: 0x17003653 RID: 13907
		' (get) Token: 0x06009278 RID: 37496 RVA: 0x00047B46 File Offset: 0x00045D46
		' (set) Token: 0x06009279 RID: 37497 RVA: 0x00047B50 File Offset: 0x00045D50
		Friend Overridable Property lblUser As Label

		' Token: 0x17003654 RID: 13908
		' (get) Token: 0x0600927A RID: 37498 RVA: 0x00047B59 File Offset: 0x00045D59
		' (set) Token: 0x0600927B RID: 37499 RVA: 0x00047B63 File Offset: 0x00045D63
		Friend Overridable Property txtID As TextBox

		' Token: 0x17003655 RID: 13909
		' (get) Token: 0x0600927C RID: 37500 RVA: 0x00047B6C File Offset: 0x00045D6C
		' (set) Token: 0x0600927D RID: 37501 RVA: 0x00047B76 File Offset: 0x00045D76
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17003656 RID: 13910
		' (get) Token: 0x0600927E RID: 37502 RVA: 0x00047B7F File Offset: 0x00045D7F
		' (set) Token: 0x0600927F RID: 37503 RVA: 0x00047B89 File Offset: 0x00045D89
		Friend Overridable Property txtProductCode As TextBox

		' Token: 0x17003657 RID: 13911
		' (get) Token: 0x06009280 RID: 37504 RVA: 0x00047B92 File Offset: 0x00045D92
		' (set) Token: 0x06009281 RID: 37505 RVA: 0x00047B9C File Offset: 0x00045D9C
		Friend Overridable Property txtID1 As TextBox

		' Token: 0x17003658 RID: 13912
		' (get) Token: 0x06009282 RID: 37506 RVA: 0x00047BA5 File Offset: 0x00045DA5
		' (set) Token: 0x06009283 RID: 37507 RVA: 0x00047BAF File Offset: 0x00045DAF
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17003659 RID: 13913
		' (get) Token: 0x06009284 RID: 37508 RVA: 0x00047BB8 File Offset: 0x00045DB8
		' (set) Token: 0x06009285 RID: 37509 RVA: 0x00047BC2 File Offset: 0x00045DC2
		Friend Overridable Property txtFrom_company_id As TextBox

		' Token: 0x06009286 RID: 37510 RVA: 0x006A169C File Offset: 0x0069F89C
		Private Sub frmStock_Settlement_Load(sender As Object, e As EventArgs)
			Me.auto()
			Me.TextBox1.Text = ""
			Dim flag As Boolean = Not Me.SkipListViewReset
			If flag Then
				Me.listView1.Items.Clear()
				Me.listView1.Columns.Clear()
			End If
		End Sub

		' Token: 0x06009287 RID: 37511 RVA: 0x006A16F4 File Offset: 0x0069F8F4
		Public Sub LoadTransferItems(dt As DataTable)
			Me.listView1.Items.Clear()
			Me.listView1.FullRowSelect = True
			Me.listView1.GridLines = True
			Dim flag As Boolean = Me.listView1.Columns.Count = 0
			If flag Then
				Try
					For Each obj As Object In dt.Columns
						Dim dataColumn As DataColumn = CType(obj, DataColumn)
						Me.listView1.Columns.Add(dataColumn.ColumnName, 100)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			End If
			Try
				For Each obj2 As Object In dt.Rows
					Dim dataRow As DataRow = CType(obj2, DataRow)
					Dim listViewItem As ListViewItem = New ListViewItem(dataRow(0).ToString())
					Dim num As Integer = dt.Columns.Count - 1
					For i As Integer = 1 To num
						listViewItem.SubItems.Add(dataRow(i).ToString())
					Next
					Me.listView1.Items.Add(listViewItem)
				Next
			Finally
				Dim enumerator2 As IEnumerator
				If TypeOf enumerator2 Is IDisposable Then
					TryCast(enumerator2, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06009288 RID: 37512 RVA: 0x006A1860 File Offset: 0x0069FA60
		Private Sub btnDToken_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
			If flag Then
				MessageBox.Show("Please Check your internet connection!")
			Else
				Dim flag2 As Boolean = Me.listView1.Items.Count > 0
				If flag2 Then
					Try
						Dim text2 As String
						Try
							For Each obj As Object In Me.listView1.Items
								Dim listViewItem As ListViewItem = CType(obj, ListViewItem)
								Me.CheckCategory(listViewItem.SubItems(38).Text)
								Dim text As String = Me.SubCategoryCheck(listViewItem.SubItems(38).Text, listViewItem.SubItems(39).Text)
								text2 = listViewItem.SubItems(0).Text.ToString()
								Dim text3 As String = listViewItem.SubItems(3).Text.ToString()
								Dim text4 As String = text
								Dim text5 As String = listViewItem.SubItems(6).Text.ToString()
								Dim num As Double = Double.Parse(listViewItem.SubItems(7).Text)
								Dim num2 As Double = Double.Parse(Conversions.ToString(0.0))
								Dim num3 As Double = Double.Parse(listViewItem.SubItems(12).Text)
								Dim text6 As String = listViewItem.SubItems(2).Text.ToString()
								Dim text7 As String = listViewItem.SubItems(15).Text.ToString()
								Dim text8 As String = listViewItem.SubItems(16).Text.ToString()
								Dim num4 As Double = Double.Parse(listViewItem.SubItems(13).Text)
								Dim text9 As String = listViewItem.SubItems(4).Text.ToString()
								Dim text10 As String = listViewItem.SubItems(5).Text.ToString()
								Dim num5 As Double = Double.Parse(listViewItem.SubItems(14).Text)
								Dim text11 As String = listViewItem.SubItems(17).Text.ToString()
								Dim num6 As Double = Double.Parse(listViewItem.SubItems(18).Text)
								Dim num7 As Double = Double.Parse(listViewItem.SubItems(19).Text)
								Dim text12 As String = "Yes"
								Dim text13 As String = "Inclusive"
								Dim text14 As String = "Exclusive"
								Dim text15 As String = listViewItem.SubItems(20).Text.ToString()
								Dim text16 As String = listViewItem.SubItems(21).Text.ToString()
								Dim num8 As Double = Double.Parse(listViewItem.SubItems(8).Text)
								Dim num9 As Double = Double.Parse(listViewItem.SubItems(9).Text)
								Dim num10 As Double = Double.Parse(listViewItem.SubItems(10).Text)
								Dim num11 As Double = Double.Parse(Conversions.ToString(0.0))
								Dim today As DateTime = DateAndTime.Today
								Dim num12 As Double = Double.Parse(listViewItem.SubItems(22).Text)
								Dim text17 As String = ""
								Dim num13 As Double = Double.Parse(listViewItem.SubItems(25).Text)
								Dim num14 As Double = Double.Parse(listViewItem.SubItems(26).Text)
								Dim num15 As Double = Double.Parse(Conversions.ToString(0.0))
								Dim text18 As String = listViewItem.SubItems(27).Text.ToString()
								Dim text19 As String = listViewItem.SubItems(28).Text.ToString()
								Dim text20 As String = listViewItem.SubItems(29).Text.ToString()
								Dim text21 As String = listViewItem.SubItems(31).Text.ToString()
								Dim text22 As String = listViewItem.SubItems(30).Text.ToString()
								Dim num16 As Double = Double.Parse(listViewItem.SubItems(25).Text)
								Dim num17 As Double = Double.Parse(listViewItem.SubItems(26).Text)
								Dim text23 As String = ""
								Dim text24 As String = listViewItem.SubItems(32).Text.ToString()
								Dim text25 As String = listViewItem.SubItems(33).Text.ToString()
								Dim num18 As Double = Double.Parse(listViewItem.SubItems(7).Text)
								Dim num19 As Double = Double.Parse(listViewItem.SubItems(7).Text)
								Dim num20 As Double = Double.Parse(listViewItem.SubItems(36).Text)
								Dim text26 As String = listViewItem.SubItems(37).Text.ToString()
								Me.InsertProduct(text6, text3, text4, text5, num, num2, num3, text7, text8, num4, text9, text10, num5, text11, num6, num7, text12, text13, text14, text15, text16, num8, num9, num10, num11, Conversions.ToString(today), Conversions.ToString(num12), text17, num13, num14, num15, text18, text19, text20, text21, text22, num16, num17, text23, text24, text25, num18, num19, Conversions.ToString(num20), text26)
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						Me.updateto_StockInward(Me.txtFrom_company_id.Text, Me.txtCompany_id_from.Text, text2)
						Me.updateto_StockInward_local(Me.txtFrom_company_id.Text, Me.txtCompany_id_from.Text, text2)
						Me.listView1.Items.Clear()
						Me.TextBox1.Text = ""
						MessageBox.Show("✅ Stock settlement completed and marked as inward done.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						MyBase.Dispose()
						MyProject.Forms.frmStock_Inward_Notification.lblSet.Text = "transfer"
						MyProject.Forms.frmStock_Inward_Notification.lblUser.Text = Me.lblUserType.Text
						MyProject.Forms.frmStock_Inward_Notification.lblUserType.Text = Me.lblUserType.Text
						MyProject.Forms.frmStock_Inward_Notification.lblFrom_Company_id.Text = Me.txtCompany_id_from.Text
						MyProject.Forms.frmStock_Inward_Notification.Getdata(Me.txtCompany_id_from.Text)
					Catch ex As Exception
						MessageBox.Show("❌ Settlement failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x06009289 RID: 37513 RVA: 0x006A1F28 File Offset: 0x006A0128
		Public Function CheckCategory(categoryName As String) As Object
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT categoryname FROM category WHERE categoryname = @categoryName"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@categoryName", categoryName.Trim())
						Dim flag As Boolean = sqlCommand.ExecuteScalar() IsNot Nothing
						Dim flag2 As Boolean = flag
						If Not flag2 Then
							Dim text2 As String = "INSERT INTO category(categoryName, CPhoto) VALUES (@categoryName, @photo)"
							Using sqlCommand2 As SqlCommand = New SqlCommand(text2, sqlConnection)
								sqlCommand2.Parameters.AddWithValue("@categoryName", categoryName.Trim())
								Dim flag3 As Boolean = Me.Picture.Image IsNot Nothing
								If flag3 Then
									Using memoryStream As MemoryStream = New MemoryStream()
										Using bitmap As Bitmap = New Bitmap(Me.Picture.Image)
											bitmap.Save(memoryStream, ImageFormat.Jpeg)
											Dim array As Byte() = memoryStream.ToArray()
											sqlCommand2.Parameters.AddWithValue("@photo", array)
										End Using
									End Using
								Else
									MessageBox.Show("Please select an image for the category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								End If
								sqlCommand2.ExecuteNonQuery()
							End Using
							ModFunc.LogFunc(Me.lblUser.Text, "added the new category '" + categoryName + "'")
						End If
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x0600928A RID: 37514 RVA: 0x006A2164 File Offset: 0x006A0364
		Public Function SubCategoryCheck(category As String, subcategory As String) As String
			Dim text As String = ""
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text2 As String = "Select ID,SubCategoryName, Category FROM SubCategory WHERE SubCategoryName = @subCategoryName And Category = @category"
					Using sqlCommand As SqlCommand = New SqlCommand(text2, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@subCategoryName", subcategory)
						sqlCommand.Parameters.AddWithValue("@category", subcategory)
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Dim flag As Boolean = sqlDataReader.Read()
							If flag Then
								subcategory = ""
								Dim text3 As String = sqlDataReader(0).ToString()
								text = text3
							Else
								Dim text4 As String = "INSERT INTO SubCategory (SubCategoryName, Category, ID, SCPhoto) VALUES (@subCategoryName, @category, @id, @photo)"
								Using sqlCommand2 As SqlCommand = New SqlCommand(text4, sqlConnection)
									Try
										sqlCommand2.Parameters.AddWithValue("@subCategoryName", subcategory)
										sqlCommand2.Parameters.AddWithValue("@category", category)
										Me.auto()
										sqlCommand2.Parameters.AddWithValue("@id", Me.txtID.Text)
										Using memoryStream As MemoryStream = New MemoryStream()
											Using bitmap As Bitmap = New Bitmap(Me.Picture.Image)
												bitmap.Save(memoryStream, ImageFormat.Jpeg)
												Dim array As Byte() = memoryStream.ToArray()
												sqlCommand2.Parameters.AddWithValue("@photo", array)
											End Using
										End Using
										sqlCommand2.ExecuteNonQuery()
										text = Me.txtID.Text
									Catch ex As Exception
										MessageBox.Show(ex.Message)
									End Try
								End Using
								ModFunc.LogFunc(Me.lblUser.Text, String.Concat(New String() { "added the New subcategory '", subcategory, "' having Category '", category, "'" }))
							End If
						End Using
					End Using
				End Using
			Catch ex2 As Exception
				MessageBox.Show("Error: " + ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Return text
		End Function

		' Token: 0x0600928B RID: 37515 RVA: 0x006A2468 File Offset: 0x006A0668
		Private Sub auto()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT MAX(ID) FROM SubCategory"
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

		' Token: 0x0600928C RID: 37516 RVA: 0x006A256C File Offset: 0x006A076C
		Public Sub InsertProduct(barcode As String, pName As String, SubCategoryID As String, PDescription As String, PCostPrice As Double, PDiscount As Double, PCGST As Double, PPurchaseUnit As String, PSalesUnit As String, PPSGST As Double, PPHSNCode As String, PPartNo As String, PCess As Double, PSalesAltUnit As String, PConv As Double, PMinStock As Double, PStatus As String, PSTax As String, PPTax As String, PGDown As String, PRack As String, PMRP As Double, PSellingPrice As Double, PReorderPoint As Double, POpeningStock As Double, PAddDate As String, PDefQty As String, PKitchen As String, SPrice As Double, WPrice As Double, StLimit As Double, Batch As String, Mfgdate As String, Expdate As String, Size As String, Colour As String, SalePrice As Double, WSalePrice As Double, SuplName As String, IMEI1 As String, IMEI2 As String, PPrice As Double, EPPrice As Double, TQty As String, TocknNo As String)
			' The following expression was wrapped in a checked-statement
			Try
				ModCS.cs = ModCS.ReadCS()
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT Barcode FROM Temp_Stock WHERE Barcode = @d1"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@d1", barcode)
						Dim objectValue As Object = RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar())
						Dim flag As Boolean = objectValue IsNot Nothing
						If flag Then
							Me.CheckBarcodeExists(barcode, Conversions.ToDouble(TQty))
						Else
							Me.GenerateNewProductID()
							Dim num As Integer = CInt(Math.Round(Conversion.Val(Me.txtID1.Text)))
							Dim text2 As String = "INSERT INTO Product (PID,ProductCode,ProductName,SubCategoryID,Description,CostPrice,Discount,CGST,Barcode, " & vbCrLf & "                                                                          PurchaseUnit,SalesUnit,SGST,HSNCode,PartNo,Cess,SalesAltUnit,Conv,MinStock,Status, " & vbCrLf & "                                                                          STax,PTax,GDown,Rack,MRP,SellingPrice,ReorderPoint,OpeningStock,AddDate,DefQty,Kitchen) VALUES" & vbCrLf & "                                                                          (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8," & vbCrLf & "                                                                           @d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18," & vbCrLf & "                                                                           @d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29)"
							Using sqlCommand2 As SqlCommand = New SqlCommand(text2, sqlConnection)
								sqlCommand2.Parameters.AddWithValue("@d0", num)
								sqlCommand2.Parameters.AddWithValue("@d1", Me.txtProductCode.Text)
								sqlCommand2.Parameters.AddWithValue("@d2", pName)
								sqlCommand2.Parameters.AddWithValue("@d3", SubCategoryID)
								sqlCommand2.Parameters.AddWithValue("@d4", PDescription)
								sqlCommand2.Parameters.AddWithValue("@d5", PCostPrice)
								sqlCommand2.Parameters.AddWithValue("@d6", PDiscount)
								sqlCommand2.Parameters.AddWithValue("@d7", PCGST)
								sqlCommand2.Parameters.AddWithValue("@d8", "0")
								sqlCommand2.Parameters.AddWithValue("@d9", PPurchaseUnit)
								sqlCommand2.Parameters.AddWithValue("@d10", PSalesUnit)
								sqlCommand2.Parameters.AddWithValue("@d11", PPSGST)
								sqlCommand2.Parameters.AddWithValue("@d12", PPHSNCode)
								sqlCommand2.Parameters.AddWithValue("@d13", PPartNo)
								sqlCommand2.Parameters.AddWithValue("@d14", PCess)
								sqlCommand2.Parameters.AddWithValue("@d15", PSalesAltUnit)
								sqlCommand2.Parameters.AddWithValue("@d16", PConv)
								sqlCommand2.Parameters.AddWithValue("@d17", PMinStock)
								sqlCommand2.Parameters.AddWithValue("@d18", PStatus)
								sqlCommand2.Parameters.AddWithValue("@d19", PSTax)
								sqlCommand2.Parameters.AddWithValue("@d20", PPTax)
								sqlCommand2.Parameters.AddWithValue("@d21", PGDown)
								sqlCommand2.Parameters.AddWithValue("@d22", PRack)
								sqlCommand2.Parameters.AddWithValue("@d23", PMRP)
								sqlCommand2.Parameters.AddWithValue("@d24", PSellingPrice)
								sqlCommand2.Parameters.AddWithValue("@d25", PReorderPoint)
								sqlCommand2.Parameters.AddWithValue("@d26", POpeningStock)
								sqlCommand2.Parameters.AddWithValue("@d27", DateAndTime.Today)
								sqlCommand2.Parameters.AddWithValue("@d28", PDefQty)
								sqlCommand2.Parameters.AddWithValue("@d29", PKitchen)
								sqlCommand2.ExecuteNonQuery()
							End Using
							Dim text3 As String = "INSERT INTO Product_Join (ProductID, photo) VALUES (@productID, @imageData)"
							Using sqlCommand3 As SqlCommand = New SqlCommand(text3, sqlConnection)
								sqlCommand3.Parameters.AddWithValue("@productID", num)
								Using memoryStream As MemoryStream = New MemoryStream()
									Using bitmap As Bitmap = New Bitmap(Me.Picture.Image)
										bitmap.Save(memoryStream, ImageFormat.Jpeg)
										Dim array As Byte() = memoryStream.ToArray()
										sqlCommand3.Parameters.AddWithValue("@imageData", array)
									End Using
								End Using
								sqlCommand3.ExecuteNonQuery()
								sqlCommand3.Parameters.Clear()
							End Using
							Using sqlConnection2 As SqlConnection = New SqlConnection(ModCS.cs)
								sqlConnection2.Open()
								Dim text4 As String = "insert into Temp_Stock(ProductID,Qty,Barcode,SPrice,WPrice,StLimit,MRP,Batch,Mfgdate,Expdate,Size,Colour,SalePrice," & vbCrLf & "                                                                         WSalePrice,SuplName,IMEI1,IMEI2,PPrice,EPPrice,QrBarcode) VALUES " & vbCrLf & "                                                                        (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12," & vbCrLf & "                                                                        @d13,@d14,@d15,@d16,@d17,@d18,@d19)"
								Using sqlCommand4 As SqlCommand = New SqlCommand(text4, sqlConnection2)
									sqlCommand4.Connection = sqlConnection2
									sqlCommand4.Prepare()
									Me.Generate_GiftQR(barcode)
									sqlCommand4.Parameters.AddWithValue("@d0", num)
									sqlCommand4.Parameters.AddWithValue("@d1", Conversion.Val(TQty))
									sqlCommand4.Parameters.AddWithValue("@d2", barcode)
									sqlCommand4.Parameters.AddWithValue("@d3", Conversion.Val(PSellingPrice))
									sqlCommand4.Parameters.AddWithValue("@d4", Conversion.Val(WPrice))
									sqlCommand4.Parameters.AddWithValue("@d5", 0)
									sqlCommand4.Parameters.AddWithValue("@d6", Conversion.Val(PMRP))
									sqlCommand4.Parameters.AddWithValue("@d7", Batch)
									sqlCommand4.Parameters.AddWithValue("@d8", Mfgdate)
									sqlCommand4.Parameters.AddWithValue("@d9", Expdate)
									sqlCommand4.Parameters.AddWithValue("@d10", Size)
									sqlCommand4.Parameters.AddWithValue("@d11", Colour)
									sqlCommand4.Parameters.AddWithValue("@d12", SalePrice)
									sqlCommand4.Parameters.AddWithValue("@d13", WSalePrice)
									sqlCommand4.Parameters.AddWithValue("@d14", "T Stock")
									sqlCommand4.Parameters.AddWithValue("@d15", IMEI1)
									sqlCommand4.Parameters.AddWithValue("@d16", IMEI2)
									sqlCommand4.Parameters.AddWithValue("@d17", Conversion.Val(PPrice))
									sqlCommand4.Parameters.AddWithValue("@d18", Conversion.Val(EPPrice))
									Dim memoryStream2 As MemoryStream = New MemoryStream()
									Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
									bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
									Dim buffer As Byte() = memoryStream2.GetBuffer()
									Dim sqlParameter As SqlParameter = New SqlParameter("@d19", SqlDbType.Image)
									sqlParameter.Value = buffer
									sqlCommand4.Parameters.Add(sqlParameter)
									sqlCommand4.ExecuteNonQuery()
									sqlCommand4.Parameters.Clear()
									sqlConnection2.Close()
								End Using
							End Using
							Dim flag2 As Boolean = Conversion.Val(POpeningStock) <= 0.0
							If flag2 Then
								Using sqlConnection3 As SqlConnection = New SqlConnection(ModCS.cs)
									sqlConnection3.Open()
									Dim text5 As String = "Select ProductID from StockMovement where ProductID=@d1"
									ModCommonClasses.cmd = New SqlCommand(text5)
									ModCommonClasses.cmd.Connection = sqlConnection
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID1.Text))
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag3 As Boolean = Not ModCommonClasses.rdr.Read()
									If flag3 Then
										ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(Me.txtID.Text))), 0D, New Decimal(Conversion.Val(10)), 0D, DateAndTime.Today, Me.txtProductCode.Text)
									Else
										Using sqlConnection4 As SqlConnection = New SqlConnection(ModCS.cs)
											sqlConnection4.Open()
											Dim text6 As String = "Select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 And Date < @d3"
											ModCommonClasses.cmd = New SqlCommand(text6)
											ModCommonClasses.cmd.Connection = sqlConnection
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID1.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d3", DateAndTime.Today)
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
											Dim num2 As Double
											If flag4 Then
												num2 = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
											Else
												num2 = 0.0
											End If
											ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(Me.txtID1.Text))), New Decimal(num2), New Decimal(Conversion.Val(10)), 0D, DateAndTime.Today, Me.txtProductCode.Text)
										End Using
									End If
								End Using
							End If
						End If
						Using sqlConnection5 As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection5.Open()
							Dim text7 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
							ModCommonClasses.cmd = New SqlCommand(text7)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", PSalesAltUnit)
							ModCommonClasses.cmd.Connection = sqlConnection
							ModCommonClasses.cmd.ExecuteReader()
						End Using
						Using sqlConnection6 As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection6.Open()
							Dim text8 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
							ModCommonClasses.cmd = New SqlCommand(text8)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", PSalesAltUnit)
							ModCommonClasses.cmd.Connection = sqlConnection
							ModCommonClasses.cmd.ExecuteReader()
							Dim flag5 As Boolean = Operators.CompareString(Me.txtProductCode.Text, "", False) = 0
							If flag5 Then
								ModFunc.LogFunc(Me.lblUser.Text, String.Concat(New String() { "added the new Product '", pName, "' having Product code '", Conversions.ToString(Conversion.Val(Me.txtID.Text)), "'" }))
							Else
								ModFunc.LogFunc(Me.lblUser.Text, String.Concat(New String() { "added the new Product '", pName, "' having Product code '", Me.txtProductCode.Text, "'" }))
							End If
						End Using
					End Using
					Me.updatetoOffline(barcode, TocknNo)
				End Using
			Catch ex As Exception
				MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600928D RID: 37517 RVA: 0x006A31D4 File Offset: 0x006A13D4
		Public Function updatetoOffline(barcode As String, TocknNo As String) As Object
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = String.Concat(New String() { "Update p_transfer_in set PStatus=@d1 where barcode= '", barcode, "' and TocknNo= '", TocknNo, "'" })
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", "f")
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x0600928E RID: 37518 RVA: 0x006A32B4 File Offset: 0x006A14B4
		Public Function updateto_StockInward(strFrom_Company As String, strTo_Company As String, strInv_Id As String) As Object
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.RaintechMaster_Online_connection())
				ModCommonClasses.con.Open()
				Dim text As String = String.Concat(New String() { "Update invoiceinfo_stockTransfer set status=@d1 where from_company_id= '", strFrom_Company, "' and to_company_id= '", strTo_Company, "'  and Inv_ID= '", strInv_Id, "'" })
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", 2)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x0600928F RID: 37519 RVA: 0x006A33A0 File Offset: 0x006A15A0
		Public Function updateto_StockInward_local(strFrom_Company As String, strTo_Company As String, strInv_Id As String) As Object
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = String.Concat(New String() { "Update invoiceinfo_stockInward set status=@d1 where from_company_id= '", strFrom_Company, "' and to_company_id= '", strTo_Company, "'  and Inv_ID= '", strInv_Id, "'" })
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", 1)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x06009290 RID: 37520 RVA: 0x006A348C File Offset: 0x006A168C
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x06009291 RID: 37521 RVA: 0x0020DD08 File Offset: 0x0020BF08
		Private Function GenerateID1() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ID FROM Product_OpeningStock ORDER BY ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("ID"))
				End If
				ModCommonClasses.rdr.Close()
				text = Conversions.ToString(Conversions.ToDouble(text) + 1.0)
				Dim flag As Boolean = Conversions.ToDouble(text) <= 9.0
				If flag Then
					text = "000" + text
				Else
					Dim flag2 As Boolean = Conversions.ToDouble(text) <= 99.0
					If flag2 Then
						text = "00" + text
					Else
						Dim flag3 As Boolean = Conversions.ToDouble(text) <= 999.0
						If flag3 Then
							text = "0" + text
						End If
					End If
				End If
			Catch ex As Exception
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x06009292 RID: 37522 RVA: 0x0011427C File Offset: 0x0011247C
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 PID FROM Product ORDER BY PID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("PID"))
				End If
				ModCommonClasses.rdr.Close()
				text = Conversions.ToString(Conversions.ToDouble(text) + 1.0)
				Dim flag As Boolean = Conversions.ToDouble(text) <= 9.0
				If flag Then
					text = "000" + text
				Else
					Dim flag2 As Boolean = Conversions.ToDouble(text) <= 99.0
					If flag2 Then
						text = "00" + text
					Else
						Dim flag3 As Boolean = Conversions.ToDouble(text) <= 999.0
						If flag3 Then
							text = "0" + text
						End If
					End If
				End If
			Catch ex As Exception
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x06009293 RID: 37523 RVA: 0x006A3510 File Offset: 0x006A1710
		Public Sub GenerateNewProductID()
			Try
				Me.txtID1.Text = Me.GenerateID()
				Me.txtProductCode.Text = "P-" + Me.GenerateID()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06009294 RID: 37524 RVA: 0x006A3584 File Offset: 0x006A1784
		Public Function CheckBarcodeExists(barcode As String, TQty As Double) As Object
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select ProductID,Barcode from Temp_Stock where Barcode=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", barcode)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "update Temp_stock set qty = qty + (" + Conversions.ToString(TQty) + ") where ProductID=@d1 and Barcode=@d2"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(ModCommonClasses.rdr(0).ToString()))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", barcode)
					ModCommonClasses.cmd.ExecuteNonQuery()
					ModCommonClasses.con.Close()
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
				End If
				MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
			Dim obj As Object
			Return obj
		End Function

		' Token: 0x040040E9 RID: 16617
		Public SkipListViewReset As Boolean
	End Class
End Namespace
