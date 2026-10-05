Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Management
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports CButtonLib
Imports ClosedXML.Excel
Imports FireSharp
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports FireSharp.Response
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Nancy.Json
Imports Newtonsoft.Json

Namespace BillPoint
	' Token: 0x0200011A RID: 282
	<DesignerGenerated()>
	Public Partial Class frmGodownOutward
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06003053 RID: 12371 RVA: 0x001E02F4 File Offset: 0x001DE4F4
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmGodownOutward_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmGodownOutward_KeyDown
			Me.DateTimeFormat = "yyyy/MM/dd HH:mm:ss"
			Me.otp = String.Empty
			Me.clearDGVCol = True
			Me.InitializeComponent()
		End Sub

		' Token: 0x170012CE RID: 4814
		' (get) Token: 0x06003056 RID: 12374 RVA: 0x0001E301 File Offset: 0x0001C501
		' (set) Token: 0x06003057 RID: 12375 RVA: 0x0001E30B File Offset: 0x0001C50B
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170012CF RID: 4815
		' (get) Token: 0x06003058 RID: 12376 RVA: 0x0001E314 File Offset: 0x0001C514
		' (set) Token: 0x06003059 RID: 12377 RVA: 0x0001E31E File Offset: 0x0001C51E
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x170012D0 RID: 4816
		' (get) Token: 0x0600305A RID: 12378 RVA: 0x0001E327 File Offset: 0x0001C527
		' (set) Token: 0x0600305B RID: 12379 RVA: 0x0001E331 File Offset: 0x0001C531
		Friend Overridable Property Label1 As Label

		' Token: 0x170012D1 RID: 4817
		' (get) Token: 0x0600305C RID: 12380 RVA: 0x0001E33A File Offset: 0x0001C53A
		' (set) Token: 0x0600305D RID: 12381 RVA: 0x0001E344 File Offset: 0x0001C544
		Friend Overridable Property txtBCode As TextBox

		' Token: 0x170012D2 RID: 4818
		' (get) Token: 0x0600305E RID: 12382 RVA: 0x0001E34D File Offset: 0x0001C54D
		' (set) Token: 0x0600305F RID: 12383 RVA: 0x0001E357 File Offset: 0x0001C557
		Friend Overridable Property Label5 As Label

		' Token: 0x170012D3 RID: 4819
		' (get) Token: 0x06003060 RID: 12384 RVA: 0x0001E360 File Offset: 0x0001C560
		' (set) Token: 0x06003061 RID: 12385 RVA: 0x001E4408 File Offset: 0x001E2608
		Private _txtQty As TextBox
		Friend Overridable Property txtQty As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtQty
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtQty_Leave
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtQty_KeyDown
				Dim textBox As TextBox = Me._txtQty
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Leave, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtQty = value
				textBox = Me._txtQty
				If textBox IsNot Nothing Then
					AddHandler textBox.Leave, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170012D4 RID: 4820
		' (get) Token: 0x06003062 RID: 12386 RVA: 0x0001E36A File Offset: 0x0001C56A
		' (set) Token: 0x06003063 RID: 12387 RVA: 0x001E4468 File Offset: 0x001E2668
		Private _txtProductName As TextBox
		Friend Overridable Property txtProductName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtProductName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtProductName_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtProductName_KeyUp
				Dim keyEventHandler2 As KeyEventHandler = AddressOf Me.txtProductName_KeyDown
				Dim textBox As TextBox = Me._txtProductName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyUp, keyEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler2
				End If
				Me._txtProductName = value
				textBox = Me._txtProductName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyUp, keyEventHandler
					AddHandler textBox.KeyDown, keyEventHandler2
				End If
			End Set
		End Property

		' Token: 0x170012D5 RID: 4821
		' (get) Token: 0x06003064 RID: 12388 RVA: 0x0001E374 File Offset: 0x0001C574
		' (set) Token: 0x06003065 RID: 12389 RVA: 0x0001E37E File Offset: 0x0001C57E
		Friend Overridable Property Label4 As Label

		' Token: 0x170012D6 RID: 4822
		' (get) Token: 0x06003066 RID: 12390 RVA: 0x0001E387 File Offset: 0x0001C587
		' (set) Token: 0x06003067 RID: 12391 RVA: 0x0001E391 File Offset: 0x0001C591
		Friend Overridable Property Label8 As Label

		' Token: 0x170012D7 RID: 4823
		' (get) Token: 0x06003068 RID: 12392 RVA: 0x0001E39A File Offset: 0x0001C59A
		' (set) Token: 0x06003069 RID: 12393 RVA: 0x001E44E4 File Offset: 0x001E26E4
		Private _dgw4 As DataGridView
		Friend Overridable Property dgw4 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw4_KeyUp
				Dim keyEventHandler2 As KeyEventHandler = AddressOf Me.dgw4_KeyDown
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw4_MouseClick
				Dim dataGridView As DataGridView = Me._dgw4
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyUp, keyEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler2
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgw4 = value
				dataGridView = Me._dgw4
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyUp, keyEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler2
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x170012D8 RID: 4824
		' (get) Token: 0x0600306A RID: 12394 RVA: 0x0001E3A4 File Offset: 0x0001C5A4
		' (set) Token: 0x0600306B RID: 12395 RVA: 0x0001E3AE File Offset: 0x0001C5AE
		Friend Overridable Property lblUnit As Label

		' Token: 0x170012D9 RID: 4825
		' (get) Token: 0x0600306C RID: 12396 RVA: 0x0001E3B7 File Offset: 0x0001C5B7
		' (set) Token: 0x0600306D RID: 12397 RVA: 0x0001E3C1 File Offset: 0x0001C5C1
		Friend Overridable Property lblPID As Label

		' Token: 0x170012DA RID: 4826
		' (get) Token: 0x0600306E RID: 12398 RVA: 0x0001E3CA File Offset: 0x0001C5CA
		' (set) Token: 0x0600306F RID: 12399 RVA: 0x0001E3D4 File Offset: 0x0001C5D4
		Friend Overridable Property lblDB As Label

		' Token: 0x170012DB RID: 4827
		' (get) Token: 0x06003070 RID: 12400 RVA: 0x0001E3DD File Offset: 0x0001C5DD
		' (set) Token: 0x06003071 RID: 12401 RVA: 0x0001E3E7 File Offset: 0x0001C5E7
		Friend Overridable Property lblCompID As Label

		' Token: 0x170012DC RID: 4828
		' (get) Token: 0x06003072 RID: 12402 RVA: 0x0001E3F0 File Offset: 0x0001C5F0
		' (set) Token: 0x06003073 RID: 12403 RVA: 0x0001E3FA File Offset: 0x0001C5FA
		Friend Overridable Property lblPCode As Label

		' Token: 0x170012DD RID: 4829
		' (get) Token: 0x06003074 RID: 12404 RVA: 0x0001E403 File Offset: 0x0001C603
		' (set) Token: 0x06003075 RID: 12405 RVA: 0x0001E40D File Offset: 0x0001C60D
		Friend Overridable Property lblCat As Label

		' Token: 0x170012DE RID: 4830
		' (get) Token: 0x06003076 RID: 12406 RVA: 0x0001E416 File Offset: 0x0001C616
		' (set) Token: 0x06003077 RID: 12407 RVA: 0x0001E420 File Offset: 0x0001C620
		Friend Overridable Property lblHSN As Label

		' Token: 0x170012DF RID: 4831
		' (get) Token: 0x06003078 RID: 12408 RVA: 0x0001E429 File Offset: 0x0001C629
		' (set) Token: 0x06003079 RID: 12409 RVA: 0x0001E433 File Offset: 0x0001C633
		Friend Overridable Property lblPartNo As Label

		' Token: 0x170012E0 RID: 4832
		' (get) Token: 0x0600307A RID: 12410 RVA: 0x0001E43C File Offset: 0x0001C63C
		' (set) Token: 0x0600307B RID: 12411 RVA: 0x0001E446 File Offset: 0x0001C646
		Friend Overridable Property lblPPrice As Label

		' Token: 0x170012E1 RID: 4833
		' (get) Token: 0x0600307C RID: 12412 RVA: 0x0001E44F File Offset: 0x0001C64F
		' (set) Token: 0x0600307D RID: 12413 RVA: 0x0001E459 File Offset: 0x0001C659
		Friend Overridable Property lblMRP As Label

		' Token: 0x170012E2 RID: 4834
		' (get) Token: 0x0600307E RID: 12414 RVA: 0x0001E462 File Offset: 0x0001C662
		' (set) Token: 0x0600307F RID: 12415 RVA: 0x0001E46C File Offset: 0x0001C66C
		Friend Overridable Property lblDisc As Label

		' Token: 0x170012E3 RID: 4835
		' (get) Token: 0x06003080 RID: 12416 RVA: 0x0001E475 File Offset: 0x0001C675
		' (set) Token: 0x06003081 RID: 12417 RVA: 0x0001E47F File Offset: 0x0001C67F
		Friend Overridable Property lblSGST As Label

		' Token: 0x170012E4 RID: 4836
		' (get) Token: 0x06003082 RID: 12418 RVA: 0x0001E488 File Offset: 0x0001C688
		' (set) Token: 0x06003083 RID: 12419 RVA: 0x0001E492 File Offset: 0x0001C692
		Friend Overridable Property lblCGST As Label

		' Token: 0x170012E5 RID: 4837
		' (get) Token: 0x06003084 RID: 12420 RVA: 0x0001E49B File Offset: 0x0001C69B
		' (set) Token: 0x06003085 RID: 12421 RVA: 0x0001E4A5 File Offset: 0x0001C6A5
		Friend Overridable Property lblCESS As Label

		' Token: 0x170012E6 RID: 4838
		' (get) Token: 0x06003086 RID: 12422 RVA: 0x0001E4AE File Offset: 0x0001C6AE
		' (set) Token: 0x06003087 RID: 12423 RVA: 0x0001E4B8 File Offset: 0x0001C6B8
		Friend Overridable Property DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn

		' Token: 0x170012E7 RID: 4839
		' (get) Token: 0x06003088 RID: 12424 RVA: 0x0001E4C1 File Offset: 0x0001C6C1
		' (set) Token: 0x06003089 RID: 12425 RVA: 0x0001E4CB File Offset: 0x0001C6CB
		Friend Overridable Property DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn

		' Token: 0x170012E8 RID: 4840
		' (get) Token: 0x0600308A RID: 12426 RVA: 0x0001E4D4 File Offset: 0x0001C6D4
		' (set) Token: 0x0600308B RID: 12427 RVA: 0x0001E4DE File Offset: 0x0001C6DE
		Friend Overridable Property DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn

		' Token: 0x170012E9 RID: 4841
		' (get) Token: 0x0600308C RID: 12428 RVA: 0x0001E4E7 File Offset: 0x0001C6E7
		' (set) Token: 0x0600308D RID: 12429 RVA: 0x0001E4F1 File Offset: 0x0001C6F1
		Friend Overridable Property DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn

		' Token: 0x170012EA RID: 4842
		' (get) Token: 0x0600308E RID: 12430 RVA: 0x0001E4FA File Offset: 0x0001C6FA
		' (set) Token: 0x0600308F RID: 12431 RVA: 0x0001E504 File Offset: 0x0001C704
		Friend Overridable Property DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn

		' Token: 0x170012EB RID: 4843
		' (get) Token: 0x06003090 RID: 12432 RVA: 0x0001E50D File Offset: 0x0001C70D
		' (set) Token: 0x06003091 RID: 12433 RVA: 0x0001E517 File Offset: 0x0001C717
		Friend Overridable Property DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn

		' Token: 0x170012EC RID: 4844
		' (get) Token: 0x06003092 RID: 12434 RVA: 0x0001E520 File Offset: 0x0001C720
		' (set) Token: 0x06003093 RID: 12435 RVA: 0x0001E52A File Offset: 0x0001C72A
		Friend Overridable Property DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn

		' Token: 0x170012ED RID: 4845
		' (get) Token: 0x06003094 RID: 12436 RVA: 0x0001E533 File Offset: 0x0001C733
		' (set) Token: 0x06003095 RID: 12437 RVA: 0x0001E53D File Offset: 0x0001C73D
		Friend Overridable Property DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn

		' Token: 0x170012EE RID: 4846
		' (get) Token: 0x06003096 RID: 12438 RVA: 0x0001E546 File Offset: 0x0001C746
		' (set) Token: 0x06003097 RID: 12439 RVA: 0x0001E550 File Offset: 0x0001C750
		Friend Overridable Property DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn

		' Token: 0x170012EF RID: 4847
		' (get) Token: 0x06003098 RID: 12440 RVA: 0x0001E559 File Offset: 0x0001C759
		' (set) Token: 0x06003099 RID: 12441 RVA: 0x0001E563 File Offset: 0x0001C763
		Friend Overridable Property DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn

		' Token: 0x170012F0 RID: 4848
		' (get) Token: 0x0600309A RID: 12442 RVA: 0x0001E56C File Offset: 0x0001C76C
		' (set) Token: 0x0600309B RID: 12443 RVA: 0x0001E576 File Offset: 0x0001C776
		Friend Overridable Property DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn

		' Token: 0x170012F1 RID: 4849
		' (get) Token: 0x0600309C RID: 12444 RVA: 0x0001E57F File Offset: 0x0001C77F
		' (set) Token: 0x0600309D RID: 12445 RVA: 0x0001E589 File Offset: 0x0001C789
		Friend Overridable Property DataGridViewTextBoxColumn34 As DataGridViewTextBoxColumn

		' Token: 0x170012F2 RID: 4850
		' (get) Token: 0x0600309E RID: 12446 RVA: 0x0001E592 File Offset: 0x0001C792
		' (set) Token: 0x0600309F RID: 12447 RVA: 0x0001E59C File Offset: 0x0001C79C
		Friend Overridable Property DataGridViewTextBoxColumn35 As DataGridViewTextBoxColumn

		' Token: 0x170012F3 RID: 4851
		' (get) Token: 0x060030A0 RID: 12448 RVA: 0x0001E5A5 File Offset: 0x0001C7A5
		' (set) Token: 0x060030A1 RID: 12449 RVA: 0x0001E5AF File Offset: 0x0001C7AF
		Friend Overridable Property DataGridViewTextBoxColumn36 As DataGridViewTextBoxColumn

		' Token: 0x170012F4 RID: 4852
		' (get) Token: 0x060030A2 RID: 12450 RVA: 0x0001E5B8 File Offset: 0x0001C7B8
		' (set) Token: 0x060030A3 RID: 12451 RVA: 0x0001E5C2 File Offset: 0x0001C7C2
		Friend Overridable Property DataGridViewTextBoxColumn37 As DataGridViewTextBoxColumn

		' Token: 0x170012F5 RID: 4853
		' (get) Token: 0x060030A4 RID: 12452 RVA: 0x0001E5CB File Offset: 0x0001C7CB
		' (set) Token: 0x060030A5 RID: 12453 RVA: 0x0001E5D5 File Offset: 0x0001C7D5
		Friend Overridable Property DataGridViewTextBoxColumn38 As DataGridViewTextBoxColumn

		' Token: 0x170012F6 RID: 4854
		' (get) Token: 0x060030A6 RID: 12454 RVA: 0x0001E5DE File Offset: 0x0001C7DE
		' (set) Token: 0x060030A7 RID: 12455 RVA: 0x0001E5E8 File Offset: 0x0001C7E8
		Friend Overridable Property DataGridViewTextBoxColumn39 As DataGridViewTextBoxColumn

		' Token: 0x170012F7 RID: 4855
		' (get) Token: 0x060030A8 RID: 12456 RVA: 0x0001E5F1 File Offset: 0x0001C7F1
		' (set) Token: 0x060030A9 RID: 12457 RVA: 0x0001E5FB File Offset: 0x0001C7FB
		Friend Overridable Property DataGridViewTextBoxColumn40 As DataGridViewTextBoxColumn

		' Token: 0x170012F8 RID: 4856
		' (get) Token: 0x060030AA RID: 12458 RVA: 0x0001E604 File Offset: 0x0001C804
		' (set) Token: 0x060030AB RID: 12459 RVA: 0x0001E60E File Offset: 0x0001C80E
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x170012F9 RID: 4857
		' (get) Token: 0x060030AC RID: 12460 RVA: 0x0001E617 File Offset: 0x0001C817
		' (set) Token: 0x060030AD RID: 12461 RVA: 0x0001E621 File Offset: 0x0001C821
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x170012FA RID: 4858
		' (get) Token: 0x060030AE RID: 12462 RVA: 0x0001E62A File Offset: 0x0001C82A
		' (set) Token: 0x060030AF RID: 12463 RVA: 0x0001E634 File Offset: 0x0001C834
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x170012FB RID: 4859
		' (get) Token: 0x060030B0 RID: 12464 RVA: 0x0001E63D File Offset: 0x0001C83D
		' (set) Token: 0x060030B1 RID: 12465 RVA: 0x0001E647 File Offset: 0x0001C847
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x170012FC RID: 4860
		' (get) Token: 0x060030B2 RID: 12466 RVA: 0x0001E650 File Offset: 0x0001C850
		' (set) Token: 0x060030B3 RID: 12467 RVA: 0x0001E65A File Offset: 0x0001C85A
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x170012FD RID: 4861
		' (get) Token: 0x060030B4 RID: 12468 RVA: 0x0001E663 File Offset: 0x0001C863
		' (set) Token: 0x060030B5 RID: 12469 RVA: 0x0001E66D File Offset: 0x0001C86D
		Friend Overridable Property Column39 As DataGridViewTextBoxColumn

		' Token: 0x170012FE RID: 4862
		' (get) Token: 0x060030B6 RID: 12470 RVA: 0x0001E676 File Offset: 0x0001C876
		' (set) Token: 0x060030B7 RID: 12471 RVA: 0x0001E680 File Offset: 0x0001C880
		Friend Overridable Property Column41 As DataGridViewTextBoxColumn

		' Token: 0x170012FF RID: 4863
		' (get) Token: 0x060030B8 RID: 12472 RVA: 0x0001E689 File Offset: 0x0001C889
		' (set) Token: 0x060030B9 RID: 12473 RVA: 0x0001E693 File Offset: 0x0001C893
		Friend Overridable Property Column42 As DataGridViewTextBoxColumn

		' Token: 0x17001300 RID: 4864
		' (get) Token: 0x060030BA RID: 12474 RVA: 0x0001E69C File Offset: 0x0001C89C
		' (set) Token: 0x060030BB RID: 12475 RVA: 0x0001E6A6 File Offset: 0x0001C8A6
		Friend Overridable Property Column43 As DataGridViewTextBoxColumn

		' Token: 0x17001301 RID: 4865
		' (get) Token: 0x060030BC RID: 12476 RVA: 0x0001E6AF File Offset: 0x0001C8AF
		' (set) Token: 0x060030BD RID: 12477 RVA: 0x0001E6B9 File Offset: 0x0001C8B9
		Friend Overridable Property Column44 As DataGridViewTextBoxColumn

		' Token: 0x17001302 RID: 4866
		' (get) Token: 0x060030BE RID: 12478 RVA: 0x0001E6C2 File Offset: 0x0001C8C2
		' (set) Token: 0x060030BF RID: 12479 RVA: 0x0001E6CC File Offset: 0x0001C8CC
		Friend Overridable Property Column45 As DataGridViewTextBoxColumn

		' Token: 0x17001303 RID: 4867
		' (get) Token: 0x060030C0 RID: 12480 RVA: 0x0001E6D5 File Offset: 0x0001C8D5
		' (set) Token: 0x060030C1 RID: 12481 RVA: 0x0001E6DF File Offset: 0x0001C8DF
		Friend Overridable Property Column47 As DataGridViewTextBoxColumn

		' Token: 0x17001304 RID: 4868
		' (get) Token: 0x060030C2 RID: 12482 RVA: 0x0001E6E8 File Offset: 0x0001C8E8
		' (set) Token: 0x060030C3 RID: 12483 RVA: 0x0001E6F2 File Offset: 0x0001C8F2
		Friend Overridable Property Column48 As DataGridViewTextBoxColumn

		' Token: 0x17001305 RID: 4869
		' (get) Token: 0x060030C4 RID: 12484 RVA: 0x0001E6FB File Offset: 0x0001C8FB
		' (set) Token: 0x060030C5 RID: 12485 RVA: 0x0001E705 File Offset: 0x0001C905
		Friend Overridable Property lblSAltUnit As Label

		' Token: 0x17001306 RID: 4870
		' (get) Token: 0x060030C6 RID: 12486 RVA: 0x0001E70E File Offset: 0x0001C90E
		' (set) Token: 0x060030C7 RID: 12487 RVA: 0x0001E718 File Offset: 0x0001C918
		Friend Overridable Property lblSUnit As Label

		' Token: 0x17001307 RID: 4871
		' (get) Token: 0x060030C8 RID: 12488 RVA: 0x0001E721 File Offset: 0x0001C921
		' (set) Token: 0x060030C9 RID: 12489 RVA: 0x0001E72B File Offset: 0x0001C92B
		Friend Overridable Property lblPUnit As Label

		' Token: 0x17001308 RID: 4872
		' (get) Token: 0x060030CA RID: 12490 RVA: 0x0001E734 File Offset: 0x0001C934
		' (set) Token: 0x060030CB RID: 12491 RVA: 0x0001E73E File Offset: 0x0001C93E
		Friend Overridable Property lblRPrice As Label

		' Token: 0x17001309 RID: 4873
		' (get) Token: 0x060030CC RID: 12492 RVA: 0x0001E747 File Offset: 0x0001C947
		' (set) Token: 0x060030CD RID: 12493 RVA: 0x0001E751 File Offset: 0x0001C951
		Friend Overridable Property lblWPrice As Label

		' Token: 0x1700130A RID: 4874
		' (get) Token: 0x060030CE RID: 12494 RVA: 0x0001E75A File Offset: 0x0001C95A
		' (set) Token: 0x060030CF RID: 12495 RVA: 0x0001E764 File Offset: 0x0001C964
		Friend Overridable Property lblConv As Label

		' Token: 0x1700130B RID: 4875
		' (get) Token: 0x060030D0 RID: 12496 RVA: 0x0001E76D File Offset: 0x0001C96D
		' (set) Token: 0x060030D1 RID: 12497 RVA: 0x0001E777 File Offset: 0x0001C977
		Friend Overridable Property lblMin As Label

		' Token: 0x1700130C RID: 4876
		' (get) Token: 0x060030D2 RID: 12498 RVA: 0x0001E780 File Offset: 0x0001C980
		' (set) Token: 0x060030D3 RID: 12499 RVA: 0x0001E78A File Offset: 0x0001C98A
		Friend Overridable Property lblPTax As Label

		' Token: 0x1700130D RID: 4877
		' (get) Token: 0x060030D4 RID: 12500 RVA: 0x0001E793 File Offset: 0x0001C993
		' (set) Token: 0x060030D5 RID: 12501 RVA: 0x0001E79D File Offset: 0x0001C99D
		Friend Overridable Property lblSTax As Label

		' Token: 0x1700130E RID: 4878
		' (get) Token: 0x060030D6 RID: 12502 RVA: 0x0001E7A6 File Offset: 0x0001C9A6
		' (set) Token: 0x060030D7 RID: 12503 RVA: 0x0001E7B0 File Offset: 0x0001C9B0
		Friend Overridable Property lblSize As Label

		' Token: 0x1700130F RID: 4879
		' (get) Token: 0x060030D8 RID: 12504 RVA: 0x0001E7B9 File Offset: 0x0001C9B9
		' (set) Token: 0x060030D9 RID: 12505 RVA: 0x0001E7C3 File Offset: 0x0001C9C3
		Friend Overridable Property lblColour As Label

		' Token: 0x17001310 RID: 4880
		' (get) Token: 0x060030DA RID: 12506 RVA: 0x0001E7CC File Offset: 0x0001C9CC
		' (set) Token: 0x060030DB RID: 12507 RVA: 0x0001E7D6 File Offset: 0x0001C9D6
		Friend Overridable Property lblBatch As Label

		' Token: 0x17001311 RID: 4881
		' (get) Token: 0x060030DC RID: 12508 RVA: 0x0001E7DF File Offset: 0x0001C9DF
		' (set) Token: 0x060030DD RID: 12509 RVA: 0x0001E7E9 File Offset: 0x0001C9E9
		Friend Overridable Property lblIMEI2 As Label

		' Token: 0x17001312 RID: 4882
		' (get) Token: 0x060030DE RID: 12510 RVA: 0x0001E7F2 File Offset: 0x0001C9F2
		' (set) Token: 0x060030DF RID: 12511 RVA: 0x0001E7FC File Offset: 0x0001C9FC
		Friend Overridable Property lblIMEI1 As Label

		' Token: 0x17001313 RID: 4883
		' (get) Token: 0x060030E0 RID: 12512 RVA: 0x0001E805 File Offset: 0x0001CA05
		' (set) Token: 0x060030E1 RID: 12513 RVA: 0x0001E80F File Offset: 0x0001CA0F
		Friend Overridable Property lblExp As Label

		' Token: 0x17001314 RID: 4884
		' (get) Token: 0x060030E2 RID: 12514 RVA: 0x0001E818 File Offset: 0x0001CA18
		' (set) Token: 0x060030E3 RID: 12515 RVA: 0x0001E822 File Offset: 0x0001CA22
		Friend Overridable Property lblMfg As Label

		' Token: 0x17001315 RID: 4885
		' (get) Token: 0x060030E4 RID: 12516 RVA: 0x0001E82B File Offset: 0x0001CA2B
		' (set) Token: 0x060030E5 RID: 12517 RVA: 0x0001E835 File Offset: 0x0001CA35
		Friend Overridable Property Label3 As Label

		' Token: 0x17001316 RID: 4886
		' (get) Token: 0x060030E6 RID: 12518 RVA: 0x0001E83E File Offset: 0x0001CA3E
		' (set) Token: 0x060030E7 RID: 12519 RVA: 0x0001E848 File Offset: 0x0001CA48
		Friend Overridable Property txtNewBCode As TextBox

		' Token: 0x17001317 RID: 4887
		' (get) Token: 0x060030E8 RID: 12520 RVA: 0x0001E851 File Offset: 0x0001CA51
		' (set) Token: 0x060030E9 RID: 12521 RVA: 0x0001E85B File Offset: 0x0001CA5B
		Friend Overridable Property Label2 As Label

		' Token: 0x17001318 RID: 4888
		' (get) Token: 0x060030EA RID: 12522 RVA: 0x0001E864 File Offset: 0x0001CA64
		' (set) Token: 0x060030EB RID: 12523 RVA: 0x001E4560 File Offset: 0x001E2760
		Private _btnSave As CButton
		Friend Overridable Property btnSave As CButton
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CButton)
				Dim clickButtonAreaEventHandler As CButton.ClickButtonAreaEventHandler = AddressOf Me.btnSave_ClickButtonArea
				Dim cbutton As CButton = Me._btnSave
				If cbutton IsNot Nothing Then
					RemoveHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
				Me._btnSave = value
				cbutton = Me._btnSave
				If cbutton IsNot Nothing Then
					AddHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
			End Set
		End Property

		' Token: 0x17001319 RID: 4889
		' (get) Token: 0x060030EC RID: 12524 RVA: 0x0001E86E File Offset: 0x0001CA6E
		' (set) Token: 0x060030ED RID: 12525 RVA: 0x0001E878 File Offset: 0x0001CA78
		Friend Overridable Property Label6 As Label

		' Token: 0x1700131A RID: 4890
		' (get) Token: 0x060030EE RID: 12526 RVA: 0x0001E881 File Offset: 0x0001CA81
		' (set) Token: 0x060030EF RID: 12527 RVA: 0x001E45A4 File Offset: 0x001E27A4
		Private _txtSendtoCompID As TextBox
		Friend Overridable Property txtSendtoCompID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSendtoCompID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSendtoCompID_KeyDown
				Dim textBox As TextBox = Me._txtSendtoCompID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtSendtoCompID = value
				textBox = Me._txtSendtoCompID
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700131B RID: 4891
		' (get) Token: 0x060030F0 RID: 12528 RVA: 0x0001E88B File Offset: 0x0001CA8B
		' (set) Token: 0x060030F1 RID: 12529 RVA: 0x001E45E8 File Offset: 0x001E27E8
		Private _btnGetData As CButton
		Friend Overridable Property btnGetData As CButton
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CButton)
				Dim clickButtonAreaEventHandler As CButton.ClickButtonAreaEventHandler = AddressOf Me.btnGetData_ClickButtonArea
				Dim cbutton As CButton = Me._btnGetData
				If cbutton IsNot Nothing Then
					RemoveHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
				Me._btnGetData = value
				cbutton = Me._btnGetData
				If cbutton IsNot Nothing Then
					AddHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700131C RID: 4892
		' (get) Token: 0x060030F2 RID: 12530 RVA: 0x0001E895 File Offset: 0x0001CA95
		' (set) Token: 0x060030F3 RID: 12531 RVA: 0x001E462C File Offset: 0x001E282C
		Private _DGVUserData As DataGridView
		Friend Overridable Property DGVUserData As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DGVUserData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DGVUserData_MouseUp
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.DGVUserData_RowPostPaint
				Dim dataGridView As DataGridView = Me._DGVUserData
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseUp, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._DGVUserData = value
				dataGridView = Me._DGVUserData
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseUp, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700131D RID: 4893
		' (get) Token: 0x060030F4 RID: 12532 RVA: 0x0001E89F File Offset: 0x0001CA9F
		' (set) Token: 0x060030F5 RID: 12533 RVA: 0x0001E8A9 File Offset: 0x0001CAA9
		Friend Overridable Property Button1 As Button

		' Token: 0x1700131E RID: 4894
		' (get) Token: 0x060030F6 RID: 12534 RVA: 0x0001E8B2 File Offset: 0x0001CAB2
		' (set) Token: 0x060030F7 RID: 12535 RVA: 0x001E468C File Offset: 0x001E288C
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

		' Token: 0x1700131F RID: 4895
		' (get) Token: 0x060030F8 RID: 12536 RVA: 0x0001E8BC File Offset: 0x0001CABC
		' (set) Token: 0x060030F9 RID: 12537 RVA: 0x0001E8C6 File Offset: 0x0001CAC6
		Friend Overridable Property TableLayoutPanel1 As TableLayoutPanel

		' Token: 0x17001320 RID: 4896
		' (get) Token: 0x060030FA RID: 12538 RVA: 0x0001E8CF File Offset: 0x0001CACF
		' (set) Token: 0x060030FB RID: 12539 RVA: 0x0001E8D9 File Offset: 0x0001CAD9
		Friend Overridable Property DateTimePicker2 As DateTimePicker

		' Token: 0x17001321 RID: 4897
		' (get) Token: 0x060030FC RID: 12540 RVA: 0x0001E8E2 File Offset: 0x0001CAE2
		' (set) Token: 0x060030FD RID: 12541 RVA: 0x0001E8EC File Offset: 0x0001CAEC
		Friend Overridable Property Label9 As Label

		' Token: 0x17001322 RID: 4898
		' (get) Token: 0x060030FE RID: 12542 RVA: 0x0001E8F5 File Offset: 0x0001CAF5
		' (set) Token: 0x060030FF RID: 12543 RVA: 0x0001E8FF File Offset: 0x0001CAFF
		Friend Overridable Property Label7 As Label

		' Token: 0x17001323 RID: 4899
		' (get) Token: 0x06003100 RID: 12544 RVA: 0x0001E908 File Offset: 0x0001CB08
		' (set) Token: 0x06003101 RID: 12545 RVA: 0x0001E912 File Offset: 0x0001CB12
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x17001324 RID: 4900
		' (get) Token: 0x06003102 RID: 12546 RVA: 0x0001E91B File Offset: 0x0001CB1B
		' (set) Token: 0x06003103 RID: 12547 RVA: 0x001E46D0 File Offset: 0x001E28D0
		Private _btnSearch As Button
		Friend Overridable Property btnSearch As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSearch
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSearch_Click
				Dim button As Button = Me._btnSearch
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSearch = value
				button = Me._btnSearch
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001325 RID: 4901
		' (get) Token: 0x06003104 RID: 12548 RVA: 0x0001E925 File Offset: 0x0001CB25
		' (set) Token: 0x06003105 RID: 12549 RVA: 0x001E4714 File Offset: 0x001E2914
		Private _btnReset As CButton
		Friend Overridable Property btnReset As CButton
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CButton)
				Dim clickButtonAreaEventHandler As CButton.ClickButtonAreaEventHandler = AddressOf Me.btnReset_ClickButtonArea
				Dim cbutton As CButton = Me._btnReset
				If cbutton IsNot Nothing Then
					RemoveHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
				Me._btnReset = value
				cbutton = Me._btnReset
				If cbutton IsNot Nothing Then
					AddHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
			End Set
		End Property

		' Token: 0x17001326 RID: 4902
		' (get) Token: 0x06003106 RID: 12550 RVA: 0x0001E92F File Offset: 0x0001CB2F
		' (set) Token: 0x06003107 RID: 12551 RVA: 0x0001E939 File Offset: 0x0001CB39
		Friend Overridable Property Button2 As Button

		' Token: 0x17001327 RID: 4903
		' (get) Token: 0x06003108 RID: 12552 RVA: 0x0001E942 File Offset: 0x0001CB42
		' (set) Token: 0x06003109 RID: 12553 RVA: 0x0001E94C File Offset: 0x0001CB4C
		Friend Overridable Property lblUser As Label

		' Token: 0x17001328 RID: 4904
		' (get) Token: 0x0600310A RID: 12554 RVA: 0x0001E955 File Offset: 0x0001CB55
		' (set) Token: 0x0600310B RID: 12555 RVA: 0x0001E95F File Offset: 0x0001CB5F
		Friend Overridable Property ContextMenuStrip1 As ContextMenuStrip

		' Token: 0x17001329 RID: 4905
		' (get) Token: 0x0600310C RID: 12556 RVA: 0x0001E968 File Offset: 0x0001CB68
		' (set) Token: 0x0600310D RID: 12557 RVA: 0x001E4758 File Offset: 0x001E2958
		Private _DeleteToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property DeleteToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._DeleteToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.DeleteToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._DeleteToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._DeleteToolStripMenuItem = value
				toolStripMenuItem = Me._DeleteToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700132A RID: 4906
		' (get) Token: 0x0600310E RID: 12558 RVA: 0x0001E972 File Offset: 0x0001CB72
		' (set) Token: 0x0600310F RID: 12559 RVA: 0x001E479C File Offset: 0x001E299C
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox1_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700132B RID: 4907
		' (get) Token: 0x06003110 RID: 12560 RVA: 0x0001E97C File Offset: 0x0001CB7C
		' (set) Token: 0x06003111 RID: 12561 RVA: 0x0001E986 File Offset: 0x0001CB86
		Friend Overridable Property Label10 As Label

		' Token: 0x1700132C RID: 4908
		' (get) Token: 0x06003112 RID: 12562 RVA: 0x0001E98F File Offset: 0x0001CB8F
		' (set) Token: 0x06003113 RID: 12563 RVA: 0x001E47E0 File Offset: 0x001E29E0
		Private _btnExportExcel As CButton
		Friend Overridable Property btnExportExcel As CButton
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CButton)
				Dim clickButtonAreaEventHandler As CButton.ClickButtonAreaEventHandler = AddressOf Me.btnExportExcel_ClickButtonArea
				Dim cbutton As CButton = Me._btnExportExcel
				If cbutton IsNot Nothing Then
					RemoveHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
				Me._btnExportExcel = value
				cbutton = Me._btnExportExcel
				If cbutton IsNot Nothing Then
					AddHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700132D RID: 4909
		' (get) Token: 0x06003114 RID: 12564 RVA: 0x0001E999 File Offset: 0x0001CB99
		' (set) Token: 0x06003115 RID: 12565 RVA: 0x0001E9A3 File Offset: 0x0001CBA3
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x1700132E RID: 4910
		' (get) Token: 0x06003116 RID: 12566 RVA: 0x0001E9AC File Offset: 0x0001CBAC
		' (set) Token: 0x06003117 RID: 12567 RVA: 0x0001E9B6 File Offset: 0x0001CBB6
		Friend Overridable Property lblCurStk As Label

		' Token: 0x06003118 RID: 12568 RVA: 0x001E4824 File Offset: 0x001E2A24
		Private Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(If(("SELECT RTRIM(ID), RTRIM(HardwareID), RTRIM(ActivationID) from Activation where ID=" + Conversions.ToString(1)), ""), ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.RealtimeDatabasePath = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.EmailSecretKey = ModCommonClasses.rdr.GetValue(2).ToString()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06003119 RID: 12569 RVA: 0x001E4908 File Offset: 0x001E2B08
		Private Sub frmGodownOutward_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Dim firebaseConfig As FirebaseConfig = New FirebaseConfig() With { .AuthSecret = Me.EmailSecretKey, .BasePath = Me.RealtimeDatabasePath }
			Try
				Me.client = New FirebaseClient(firebaseConfig)
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
			Try
				Dim managementObjectSearcher As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")
				Try
					For Each managementBaseObject As ManagementBaseObject In managementObjectSearcher.[Get]()
						Dim managementObject As ManagementObject = CType(managementBaseObject, ManagementObject)
						Dim text As String = Conversions.ToString(managementObject("SerialNumber"))
						Me.lblCompID.Text = ModFunc.MD5Encrypt(Me.lblDB.Text.TrimEnd(New Char(-1) {}).ToString() + Strings.StrReverse(text))
					Next
				Finally
					Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator
					If enumerator IsNot Nothing Then
						CType(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex2 As Exception
				Me.lblCompID.Text = ""
			End Try
		End Sub

		' Token: 0x0600311A RID: 12570 RVA: 0x001E4A40 File Offset: 0x001E2C40
		Private Sub getgriditemdata()
			Try
				Me.dgw4.Visible = True
				Me.dgw4.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw4.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Conversions.ToString(50), " PID, RTRIM(Product.ProductCode),RTRIM(Product.ProductName),RTRIM(Product.HSNCode),RTRIM(Product.PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.MRP),(Product.Discount),Product.CGST,Product.SGST,Product.CESS,Temp_Stock.Qty,RTRIM(Product.PurchaseUnit),(Temp_Stock.WPrice),(Temp_Stock.SPrice),RTRIM(Product.SalesUnit),RTRIM(Product.Conv),RTRIM(Product.SalesAltUnit),RTRIM(Product.STax),RTRIM(Temp_Stock.Damage),RTRIM(Product.MinStock),RTRIM(Product.PTax),RTRIM(Category),RTRIM(Colour),RTRIM(Size),RTRIM(Batch),RTRIM(Mfgdate),RTRIM(Expdate),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,Category,SubCategory where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and ProductName like N'", Me.txtProductName.Text, "%' order by ProductName" }), ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw4.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw4.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600311B RID: 12571 RVA: 0x001E4D44 File Offset: 0x001E2F44
		Private Sub txtProductName_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtProductName.Text.TrimEnd(New Char(-1) {}), "", False) > 0
			If flag Then
				Me.getgriditemdata()
			Else
				Me.dgw4.Visible = False
			End If
		End Sub

		' Token: 0x0600311C RID: 12572 RVA: 0x001E4D94 File Offset: 0x001E2F94
		Private Sub txtProductName_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Down
			If flag Then
				Dim visible As Boolean = Me.dgw4.Visible
				If visible Then
					Me.dgw4.Focus()
					SendKeys.Send("{DOWN}")
				End If
			End If
		End Sub

		' Token: 0x0600311D RID: 12573 RVA: 0x001E4DDC File Offset: 0x001E2FDC
		Private Sub dgw4_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				Me.dgw4.Visible = False
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = ""
			Else
				Dim flag2 As Boolean = e.KeyCode = Keys.Back
				If flag2 Then
					Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
					Me.txtProductName.Focus()
					Me.txtProductName.ScrollToCaret()
					Dim flag3 As Boolean = Operators.CompareString(Me.txtProductName.Text, "", False) > 0
					If flag3 Then
						' The following expression was wrapped in a checked-expression
						Me.txtProductName.Text = Me.txtProductName.Text.Remove(Me.txtProductName.Text.Length - 1, 1)
						Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
						Me.txtProductName.Focus()
						Me.txtProductName.ScrollToCaret()
					End If
				End If
			End If
			Dim flag4 As Boolean = e.KeyCode = Keys.A
			If flag4 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "a"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag5 As Boolean = e.KeyCode = Keys.B
			If flag5 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "b"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag6 As Boolean = e.KeyCode = Keys.C
			If flag6 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "c"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag7 As Boolean = e.KeyCode = Keys.D
			If flag7 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "d"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag8 As Boolean = e.KeyCode = Keys.E
			If flag8 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "e"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag9 As Boolean = e.KeyCode = Keys.F
			If flag9 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "f"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag10 As Boolean = e.KeyCode = Keys.G
			If flag10 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "g"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag11 As Boolean = e.KeyCode = Keys.H
			If flag11 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "h"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag12 As Boolean = e.KeyCode = Keys.I
			If flag12 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "i"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag13 As Boolean = e.KeyCode = Keys.J
			If flag13 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "j"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag14 As Boolean = e.KeyCode = Keys.K
			If flag14 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "k"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag15 As Boolean = e.KeyCode = Keys.L
			If flag15 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "l"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag16 As Boolean = e.KeyCode = Keys.M
			If flag16 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "m"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag17 As Boolean = e.KeyCode = Keys.N
			If flag17 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "n"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag18 As Boolean = e.KeyCode = Keys.O
			If flag18 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "o"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag19 As Boolean = e.KeyCode = Keys.P
			If flag19 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "p"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag20 As Boolean = e.KeyCode = Keys.Q
			If flag20 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "q"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag21 As Boolean = e.KeyCode = Keys.R
			If flag21 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "r"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag22 As Boolean = e.KeyCode = Keys.S
			If flag22 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "s"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag23 As Boolean = e.KeyCode = Keys.T
			If flag23 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "t"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag24 As Boolean = e.KeyCode = Keys.U
			If flag24 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "u"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag25 As Boolean = e.KeyCode = Keys.V
			If flag25 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "v"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag26 As Boolean = e.KeyCode = Keys.W
			If flag26 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "w"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag27 As Boolean = e.KeyCode = Keys.X
			If flag27 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "x"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag28 As Boolean = e.KeyCode = Keys.Y
			If flag28 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "y"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag29 As Boolean = e.KeyCode = Keys.Z
			If flag29 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "z"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag30 As Boolean = e.KeyCode = Keys.D0
			If flag30 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "0"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag31 As Boolean = e.KeyCode = Keys.D1
			If flag31 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "1"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag32 As Boolean = e.KeyCode = Keys.D2
			If flag32 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "2"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag33 As Boolean = e.KeyCode = Keys.D3
			If flag33 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "3"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag34 As Boolean = e.KeyCode = Keys.D4
			If flag34 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "4"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag35 As Boolean = e.KeyCode = Keys.D5
			If flag35 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "5"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag36 As Boolean = e.KeyCode = Keys.D6
			If flag36 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "6"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag37 As Boolean = e.KeyCode = Keys.D7
			If flag37 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "7"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag38 As Boolean = e.KeyCode = Keys.D8
			If flag38 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "8"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag39 As Boolean = e.KeyCode = Keys.D9
			If flag39 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "9"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag40 As Boolean = e.KeyCode = Keys.Oemplus
			If flag40 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "+"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag41 As Boolean = e.KeyCode = Keys.OemMinus
			If flag41 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "-"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag42 As Boolean = e.KeyCode = Keys.OemBackslash
			If flag42 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "\"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag43 As Boolean = e.KeyCode = Keys.Oemcomma
			If flag43 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + ","
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
		End Sub

		' Token: 0x0600311E RID: 12574 RVA: 0x0001E9BF File Offset: 0x0001CBBF
		Private Sub txtQty_Leave(sender As Object, e As EventArgs)
			Me.dgw4.Visible = False
		End Sub

		' Token: 0x0600311F RID: 12575 RVA: 0x001E6824 File Offset: 0x001E4A24
		Private Sub dgw4_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData1()
			End If
		End Sub

		' Token: 0x06003120 RID: 12576 RVA: 0x0001E9CF File Offset: 0x0001CBCF
		Private Sub dgw4_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData1()
		End Sub

		' Token: 0x06003121 RID: 12577 RVA: 0x001E684C File Offset: 0x001E4A4C
		Private Sub txtProductName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.txtProductName.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Enter the valid product name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Me.getgriditemdata()
					Me.dgw4.Visible = True
					Dim flag3 As Boolean = Me.dgw4.Rows.Count = 1
					If flag3 Then
						Me.dgw4.Focus()
						Me.RetrieveData1()
					Else
						Dim flag4 As Boolean = Me.dgw4.Rows.Count > 1
						If flag4 Then
							Me.dgw4.Focus()
							SendKeys.Send("{ENTER}")
						End If
					End If
					e.SuppressKeyPress = True
				End If
			End If
		End Sub

		' Token: 0x06003122 RID: 12578 RVA: 0x001E6918 File Offset: 0x001E4B18
		Public Sub Barcode_Gen()
			Dim text As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
			Dim text2 As String = DateAndTime.Now.ToString("ss")
			Dim text3 As String = "1234567890"
			Dim text4 As String = text3
			text4 = text4 + Convert.ToString(text + text2) + text3
			Dim num As Integer = Integer.Parse(Conversions.ToString(6))
			Me.otp = String.Empty
			Dim num2 As Integer = num - 1
			For i As Integer = 0 To num2
				Dim text5 As String = String.Empty
				Do
					Dim num3 As Integer = New Random().[Next](0, text4.Length)
					text5 = text4.ToCharArray()(num3).ToString()
				Loop While Me.otp.IndexOf(text5) <> -1
				Me.otp = Me.otp + text5
			Next
		End Sub

		' Token: 0x06003123 RID: 12579 RVA: 0x001E69E8 File Offset: 0x001E4BE8
		Public Sub RetrieveData1()
			Try
				Dim flag As Boolean = Operators.CompareString(Me.txtProductName.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please retrieve Product info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.dgw4.Visible = False
					Me.txtProductName.Focus()
				Else
					Me.Clear()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "select * from Company"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
					If flag2 Then
						MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag3 Then
							ModCommonClasses.rdr.Close()
						End If
					Else
						Dim dataGridViewRow As DataGridViewRow = Me.dgw4.SelectedRows(0)
						Me.lblPID.Text = dataGridViewRow.Cells(0).Value.ToString()
						Me.lblPCode.Text = dataGridViewRow.Cells(1).Value.ToString()
						Me.txtProductName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Me.lblHSN.Text = dataGridViewRow.Cells(3).Value.ToString()
						Me.lblPartNo.Text = dataGridViewRow.Cells(4).Value.ToString()
						Me.txtBCode.Text = dataGridViewRow.Cells(5).Value.ToString()
						Me.Barcode_Gen()
						Me.txtNewBCode.Text = dataGridViewRow.Cells(5).Value.ToString() + "*" + Me.otp
						Me.lblPPrice.Text = dataGridViewRow.Cells(6).Value.ToString()
						Me.lblMRP.Text = dataGridViewRow.Cells(7).Value.ToString()
						Me.lblDisc.Text = dataGridViewRow.Cells(8).Value.ToString()
						Me.lblCGST.Text = dataGridViewRow.Cells(9).Value.ToString()
						Me.lblSGST.Text = dataGridViewRow.Cells(10).Value.ToString()
						Me.lblCESS.Text = dataGridViewRow.Cells(11).Value.ToString()
						Me.lblCurStk.Text = dataGridViewRow.Cells(12).Value.ToString()
						Me.lblUnit.Text = dataGridViewRow.Cells(13).Value.ToString()
						Me.lblPUnit.Text = dataGridViewRow.Cells(13).Value.ToString()
						Me.lblWPrice.Text = dataGridViewRow.Cells(14).Value.ToString()
						Me.lblRPrice.Text = dataGridViewRow.Cells(15).Value.ToString()
						Me.lblSUnit.Text = dataGridViewRow.Cells(16).Value.ToString()
						Me.lblConv.Text = dataGridViewRow.Cells(17).Value.ToString()
						Me.lblSAltUnit.Text = dataGridViewRow.Cells(18).Value.ToString()
						Me.lblSTax.Text = dataGridViewRow.Cells(19).Value.ToString()
						Me.lblMin.Text = dataGridViewRow.Cells(21).Value.ToString()
						Me.lblPTax.Text = dataGridViewRow.Cells(22).Value.ToString()
						Me.lblCat.Text = dataGridViewRow.Cells(23).Value.ToString()
						Me.lblColour.Text = dataGridViewRow.Cells(24).Value.ToString()
						Me.lblSize.Text = dataGridViewRow.Cells(25).Value.ToString()
						Me.lblBatch.Text = dataGridViewRow.Cells(26).Value.ToString()
						Me.lblMfg.Text = dataGridViewRow.Cells(27).Value.ToString()
						Me.lblExp.Text = dataGridViewRow.Cells(28).Value.ToString()
						Me.lblIMEI1.Text = dataGridViewRow.Cells(29).Value.ToString()
						Me.lblIMEI2.Text = dataGridViewRow.Cells(30).Value.ToString()
						Me.txtQty.Text = Conversions.ToString(1)
						Me.txtQty.Focus()
						Me.dgw4.Visible = False
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06003124 RID: 12580 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmGodownOutward_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06003125 RID: 12581 RVA: 0x001E6FB8 File Offset: 0x001E51B8
		Private Sub Clear()
			Me.lblPID.Text = ""
			Me.lblPCode.Text = ""
			Me.lblHSN.Text = ""
			Me.lblPartNo.Text = ""
			Me.txtBCode.Text = ""
			Me.txtNewBCode.Text = ""
			Me.txtQty.Text = ""
			Me.lblCurStk.Text = ""
			Me.lblPPrice.Text = ""
			Me.lblMRP.Text = ""
			Me.lblDisc.Text = ""
			Me.lblCGST.Text = ""
			Me.lblSGST.Text = ""
			Me.lblCESS.Text = ""
			Me.lblUnit.Text = ""
			Me.lblPUnit.Text = ""
			Me.lblWPrice.Text = ""
			Me.lblRPrice.Text = ""
			Me.lblSUnit.Text = ""
			Me.lblConv.Text = ""
			Me.lblSAltUnit.Text = ""
			Me.lblSTax.Text = ""
			Me.lblMin.Text = ""
			Me.lblPTax.Text = ""
			Me.lblCat.Text = ""
			Me.lblColour.Text = ""
			Me.lblSize.Text = ""
			Me.lblBatch.Text = ""
			Me.lblMfg.Text = ""
			Me.lblExp.Text = ""
			Me.lblIMEI1.Text = ""
			Me.lblIMEI2.Text = ""
		End Sub

		' Token: 0x06003126 RID: 12582 RVA: 0x001E71E8 File Offset: 0x001E53E8
		Private Sub btnSave_ClickButtonArea(Sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
			If flag Then
				MessageBox.Show("Please check your internet connection", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.txtProductName.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please enter product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtProductName.Focus()
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtBCode.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please fill barcode number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtBCode.Focus()
					Else
						Dim flag4 As Boolean = Conversion.Val(Me.txtQty.Text) <= 0.0
						If flag4 Then
							MessageBox.Show("Please fill transferable qty", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtQty.Focus()
						Else
							Dim flag5 As Boolean = Conversion.Val(Me.txtQty.Text) > Conversion.Val(Me.lblCurStk.Text)
							If flag5 Then
								MessageBox.Show("Sufficient stock is not available !", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtQty.Focus()
							Else
								Dim flag6 As Boolean = Strings.Len(Strings.Trim(Me.txtSendtoCompID.Text)) = 0
								If flag6 Then
									MessageBox.Show("Please fill company / branch id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtSendtoCompID.Focus()
								Else
									Dim flag7 As Boolean = Operators.CompareString(Me.txtSendtoCompID.Text, Me.lblCompID.Text, False) = 0
									If flag7 Then
										MessageBox.Show("You are not allowed to transfer to same company !", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtSendtoCompID.Focus()
									Else
										Me.Cursor = Cursors.WaitCursor
										Me.Timer1.Enabled = True
										Me.Barcode_Gen()
										Try
											Dim firebaseCRUDData As FirebaseCRUDData = New FirebaseCRUDData() With { .PID = Conversions.ToString(Conversion.Val(Me.lblPID.Text)), .PCode = Me.lblPCode.Text, .PName = Me.txtProductName.Text, .HSN = Me.lblHSN.Text, .Part = Me.lblPartNo.Text, .Barcode = Me.txtBCode.Text, .NewBarcode = Me.txtNewBCode.Text, .PPrice = Me.lblPPrice.Text, .MRP = Me.lblMRP.Text, .WPrice = Me.lblWPrice.Text, .RPrice = Me.lblRPrice.Text, .Disc = Me.lblDisc.Text, .CGST = Me.lblCGST.Text, .SGST = Me.lblSGST.Text, .CESS = Me.lblCESS.Text, .PUnit = Me.lblPUnit.Text, .SUnit = Me.lblUnit.Text, .Conv = Me.lblConv.Text, .SAltUnit = Me.lblSAltUnit.Text, .STax = Me.lblSTax.Text, .PTax = Me.lblPTax.Text, .MinStk = Me.lblMin.Text, .Category = Me.lblCat.Text, .Colour = Me.lblColour.Text, .Size = Me.lblSize.Text, .Batch = Me.lblBatch.Text, .Mfg = Me.lblMfg.Text, .Exp = Me.lblExp.Text, .IMEI1 = Me.lblIMEI1.Text, .IMEI2 = Me.lblIMEI2.Text, .Qty = Conversions.ToString(Conversion.Val(Me.txtQty.Text)), .Sts = "Transferred", .Entrydate = DateAndTime.Now.ToString(Me.DateTimeFormat), .CompId = Me.lblCompID.Text + "_" + Me.otp }
											Dim setResponse As SetResponse = Me.client.[Set](Of FirebaseCRUDData)(String.Concat(New String() { Me.txtSendtoCompID.Text, "/", Me.lblCompID.Text, "_", Me.otp }), firebaseCRUDData)
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text As String = "Update Temp_Stock set qty=qty - " + Conversions.ToString(Conversion.Val(Me.txtQty.Text)) + " where ProductID=@d1 and Barcode=@d2"
											ModCommonClasses.cmd = New SqlCommand(text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.lblPID.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBCode.Text.ToString())
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.ExecuteNonQuery()
											ModCommonClasses.con.Close()
											Dim flag8 As Boolean = Conversion.Val(Me.txtQty.Text) > 0.0
											If flag8 Then
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text2 As String = "select ProductID from StockMovement where ProductID=@d1"
												ModCommonClasses.cmd = New SqlCommand(text2)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.lblPID.Text))
												ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
												Dim flag9 As Boolean = Not ModCommonClasses.rdr.Read()
												If flag9 Then
													ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(Me.lblPID.Text))), 0D, 0D, New Decimal(Conversion.Val(Me.txtQty.Text)), DateAndTime.Today.[Date], Me.lblPCode.Text)
												Else
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text3 As String = "select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 and Date < @d3"
													ModCommonClasses.cmd = New SqlCommand(text3)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.lblPID.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d3", DateAndTime.Today.[Date])
													ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
													Dim flag10 As Boolean = ModCommonClasses.rdr.Read()
													Dim num As Double
													If flag10 Then
														num = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
													Else
														num = 0.0
													End If
													ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(Me.lblPID.Text))), New Decimal(num), 0D, New Decimal(Conversion.Val(Me.txtQty.Text)), DateAndTime.Today.[Date], Me.lblPCode.Text)
												End If
												ModCommonClasses.con.Close()
											End If
											ModFunc.AuditTrial_Inventory(Dns.GetHostName(), Me.lblUser.Text, "Add", "Cloud Stock Out", Me.lblCompID.Text + "_" + Me.otp, DateAndTime.Today.[Date], "Cloud Outward Stock Transfer", Me.txtProductName.Text, New Decimal(Conversion.Val(Me.txtQty.Text)), 0D, 0D)
											ModFunc.LogFunc(Me.lblUser.Text, String.Concat(New String() { "added the new cloud stock out record having vch no. '", Me.lblCompID.Text, "_", Me.otp, "'" }))
											MessageBox.Show("Stock Transfered Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
											Thread.Sleep(1000)
											Me.Clear()
											Me.txtProductName.Text = ""
											Me.txtProductName.Focus()
											Try
												Me.DGVUserData.Columns(33).Visible = False
											Catch ex As Exception
											End Try
											Dim num2 As Integer = Me.DGVUserData.RowCount - 1
											For i As Integer = 0 To num2
												Try
													Me.dtTableGrd.DefaultView.RowFilter = ""
													TryCast(Me.DGVUserData.DataSource, DataTable).DefaultView.RowFilter = String.Concat(New String() { "[Entry Date] >= '", Strings.Format(Conversions.ToDate("1900/01/01").AddDays(0.0), "yyyy/MM/dd"), "' AND [Entry Date] <= '", Strings.Format(Conversions.ToDate("1900/01/01").AddDays(1.0), "yyyy/MM/dd"), "'" })
												Catch ex2 As Exception
												End Try
											Next
											Dim num3 As Integer = Me.DGVUserData.RowCount - 1
											For j As Integer = 0 To num3
												Me.DGVUserData.Sort(Me.DGVUserData.Columns(32), ListSortDirection.Descending)
												Dim flag11 As Boolean = Operators.CompareString(Me.DGVUserData.Rows(j).Cells(31).Value.ToString(), "Accepted", False) = 0
												If flag11 Then
													Me.DGVUserData.Rows(j).DefaultCellStyle.BackColor = Color.Lime
												End If
												Dim flag12 As Boolean = Operators.CompareString(Me.DGVUserData.Rows(j).Cells(31).Value.ToString(), "Rejected", False) = 0
												If flag12 Then
													Me.DGVUserData.Rows(j).DefaultCellStyle.BackColor = Color.OrangeRed
												End If
											Next
											Me.DGVUserData.ClearSelection()
										Catch ex3 As Exception
											MessageBox.Show(ex3.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										End Try
									End If
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06003127 RID: 12583 RVA: 0x001E7D60 File Offset: 0x001E5F60
		Private Sub btnGetData_ClickButtonArea(Sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
			If flag Then
				MessageBox.Show("Please check your internet connection", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.txtSendtoCompID.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please fill company / branch id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtSendtoCompID.Focus()
				Else
					Me.ShowRecord()
				End If
			End If
		End Sub

		' Token: 0x06003128 RID: 12584 RVA: 0x001E7DD8 File Offset: 0x001E5FD8
		Public Sub ShowRecord()
			' The following expression was wrapped in a checked-statement
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim dataTable As DataTable = New DataTable()
				dataTable.Columns.Add("PID")
				dataTable.Columns.Add("PCode")
				dataTable.Columns.Add("Product Name")
				dataTable.Columns.Add("HSNC")
				dataTable.Columns.Add("Part No")
				dataTable.Columns.Add("Barcode")
				dataTable.Columns.Add("New Barcode")
				dataTable.Columns.Add("Purc Price")
				dataTable.Columns.Add("MRP")
				dataTable.Columns.Add("W Price")
				dataTable.Columns.Add("R Price")
				dataTable.Columns.Add("Disc%")
				dataTable.Columns.Add("CGST%")
				dataTable.Columns.Add("SGST%")
				dataTable.Columns.Add("CESS%")
				dataTable.Columns.Add("P Unit")
				dataTable.Columns.Add("S Unit")
				dataTable.Columns.Add("Conv")
				dataTable.Columns.Add("Alt Unit")
				dataTable.Columns.Add("Sale Tax Type")
				dataTable.Columns.Add("Purc Tax Type")
				dataTable.Columns.Add("Min Stock")
				dataTable.Columns.Add("Category")
				dataTable.Columns.Add("Colour")
				dataTable.Columns.Add("Size")
				dataTable.Columns.Add("Batch")
				dataTable.Columns.Add("Mfg")
				dataTable.Columns.Add("Exp")
				dataTable.Columns.Add("IMEI1")
				dataTable.Columns.Add("IMEI2")
				dataTable.Columns.Add("Trfr Qty")
				dataTable.Columns.Add("Status")
				dataTable.Columns.Add("Entry Date")
				dataTable.Columns.Add("CompId")
				Dim flag As Boolean = Me.clearDGVCol
				If flag Then
					Me.DGVUserData.Columns.Clear()
					Me.clearDGVCol = False
				End If
				Dim firebaseResponse As FirebaseResponse = Me.client.[Get](If(Me.txtSendtoCompID.Text.ToString(), ""))
				Dim javaScriptSerializer As JavaScriptSerializer = New JavaScriptSerializer()
				Dim dictionary As Dictionary(Of String, FirebaseCRUDData) = JsonConvert.DeserializeObject(Of Dictionary(Of String, FirebaseCRUDData))(firebaseResponse.Body.ToString())
				Try
					Try
						For Each keyValuePair As KeyValuePair(Of String, FirebaseCRUDData) In dictionary
							Dim text As String = Conversions.ToDate(keyValuePair.Value.Entrydate).ToString("yyyy-MM-dd HH:mm:ss")
							dataTable.Rows.Add(New Object() { keyValuePair.Value.PID, keyValuePair.Value.PCode, keyValuePair.Value.PName, keyValuePair.Value.HSN, keyValuePair.Value.Part, keyValuePair.Value.Barcode, keyValuePair.Value.NewBarcode, keyValuePair.Value.PPrice, keyValuePair.Value.MRP, keyValuePair.Value.WPrice, keyValuePair.Value.RPrice, keyValuePair.Value.Disc, keyValuePair.Value.CGST, keyValuePair.Value.SGST, keyValuePair.Value.CESS, keyValuePair.Value.PUnit, keyValuePair.Value.SUnit, keyValuePair.Value.Conv, keyValuePair.Value.SAltUnit, keyValuePair.Value.STax, keyValuePair.Value.PTax, keyValuePair.Value.MinStk, keyValuePair.Value.Category, keyValuePair.Value.Colour, keyValuePair.Value.Size, keyValuePair.Value.Batch, keyValuePair.Value.Mfg, keyValuePair.Value.Exp, keyValuePair.Value.IMEI1, keyValuePair.Value.IMEI2, keyValuePair.Value.Qty, keyValuePair.Value.Sts, text, keyValuePair.Value.CompId })
						Next
					Finally
						Dim enumerator As Dictionary(Of String, FirebaseCRUDData).Enumerator
						CType(enumerator, IDisposable).Dispose()
					End Try
				Catch ex As Exception
					MessageBox.Show("Database not found or Database is empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End Try
				Me.DGVUserData.DataSource = dataTable
				Me.dtTableGrd = dataTable
				Try
					Me.DGVUserData.Columns(33).Visible = False
				Catch ex2 As Exception
				End Try
				Dim num As Integer = Me.DGVUserData.RowCount - 1
				For i As Integer = 0 To num
					Me.DGVUserData.Sort(Me.DGVUserData.Columns(32), ListSortDirection.Descending)
					Dim flag2 As Boolean = Operators.CompareString(Me.DGVUserData.Rows(i).Cells(31).Value.ToString(), "Accepted", False) = 0
					If flag2 Then
						Me.DGVUserData.Rows(i).DefaultCellStyle.BackColor = Color.Lime
					End If
					Dim flag3 As Boolean = Operators.CompareString(Me.DGVUserData.Rows(i).Cells(31).Value.ToString(), "Rejected", False) = 0
					If flag3 Then
						Me.DGVUserData.Rows(i).DefaultCellStyle.BackColor = Color.OrangeRed
					End If
				Next
				Me.DGVUserData.ClearSelection()
			Catch ex3 As Exception
				Dim flag4 As Boolean = Operators.CompareString(ex3.Message, "One or more errors occurred", False) = 0
				If flag4 Then
					MessageBox.Show("Cannot connect to firebase, check your network !", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim flag5 As Boolean = Operators.CompareString(ex3.Message, "Object reference not set to an instance of an object", False) = 0
					If flag5 Then
						Dim dataTable2 As DataTable = New DataTable()
						dataTable2.Columns.Add("PID")
						dataTable2.Columns.Add("PCode")
						dataTable2.Columns.Add("Product Name")
						dataTable2.Columns.Add("HSNC")
						dataTable2.Columns.Add("Part No")
						dataTable2.Columns.Add("Barcode")
						dataTable2.Columns.Add("New Barcode")
						dataTable2.Columns.Add("Purc Price")
						dataTable2.Columns.Add("MRP")
						dataTable2.Columns.Add("W Price")
						dataTable2.Columns.Add("R Price")
						dataTable2.Columns.Add("Disc%")
						dataTable2.Columns.Add("CGST%")
						dataTable2.Columns.Add("SGST%")
						dataTable2.Columns.Add("CESS%")
						dataTable2.Columns.Add("P Unit")
						dataTable2.Columns.Add("S Unit")
						dataTable2.Columns.Add("Conv")
						dataTable2.Columns.Add("Alt Unit")
						dataTable2.Columns.Add("Sale Tax Type")
						dataTable2.Columns.Add("Purc Tax Type")
						dataTable2.Columns.Add("Min Stock")
						dataTable2.Columns.Add("Category")
						dataTable2.Columns.Add("Colour")
						dataTable2.Columns.Add("Size")
						dataTable2.Columns.Add("Batch")
						dataTable2.Columns.Add("Mfg")
						dataTable2.Columns.Add("Exp")
						dataTable2.Columns.Add("IMEI1")
						dataTable2.Columns.Add("IMEI2")
						dataTable2.Columns.Add("Trfr Qty")
						dataTable2.Columns.Add("Status")
						dataTable2.Columns.Add("Entry Date")
						dataTable2.Columns.Add("CompId")
						Me.DGVUserData.DataSource = dataTable2
						MessageBox.Show("Database not found or Database is empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Else
						MessageBox.Show(ex3.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End If
				End If
			End Try
		End Sub

		' Token: 0x06003129 RID: 12585 RVA: 0x0001E9D9 File Offset: 0x0001CBD9
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600312A RID: 12586 RVA: 0x001E8810 File Offset: 0x001E6A10
		Private Sub btnSearch_Click(sender As Object, e As EventArgs)
			Try
				Me.dtTableGrd.DefaultView.RowFilter = ""
				TryCast(Me.DGVUserData.DataSource, DataTable).DefaultView.RowFilter = String.Concat(New String() { "[Entry Date] >= '", Strings.Format(Me.DateTimePicker1.Value.AddDays(0.0), "yyyy/MM/dd"), "' AND [Entry Date] <= '", Strings.Format(Me.DateTimePicker2.Value.AddDays(1.0), "yyyy/MM/dd"), "'" })
			Catch ex As Exception
			End Try
			Try
				Me.DGVUserData.Columns(33).Visible = False
			Catch ex2 As Exception
			End Try
			Dim num As Integer = Me.DGVUserData.RowCount - 1
			For i As Integer = 0 To num
				Me.DGVUserData.Sort(Me.DGVUserData.Columns(32), ListSortDirection.Descending)
				Dim flag As Boolean = Operators.CompareString(Me.DGVUserData.Rows(i).Cells(31).Value.ToString(), "Accepted", False) = 0
				If flag Then
					Me.DGVUserData.Rows(i).DefaultCellStyle.BackColor = Color.Lime
				End If
				Dim flag2 As Boolean = Operators.CompareString(Me.DGVUserData.Rows(i).Cells(31).Value.ToString(), "Rejected", False) = 0
				If flag2 Then
					Me.DGVUserData.Rows(i).DefaultCellStyle.BackColor = Color.OrangeRed
				End If
			Next
			Me.DGVUserData.ClearSelection()
		End Sub

		' Token: 0x0600312B RID: 12587 RVA: 0x001E8A38 File Offset: 0x001E6C38
		Private Sub btnReset_ClickButtonArea(Sender As Object, e As MouseEventArgs)
			Me.Clear()
			Me.txtProductName.Text = ""
			Me.txtProductName.Focus()
			Me.DateTimePicker1.Value = DateAndTime.Today
			Me.DateTimePicker2.Value = DateAndTime.Today
			Try
				Me.DGVUserData.Columns(33).Visible = False
			Catch ex As Exception
			End Try
			Dim num As Integer = Me.DGVUserData.RowCount - 1
			For i As Integer = 0 To num
				Try
					Me.dtTableGrd.DefaultView.RowFilter = ""
					TryCast(Me.DGVUserData.DataSource, DataTable).DefaultView.RowFilter = String.Concat(New String() { "[Entry Date] >= '", Strings.Format(Conversions.ToDate("1900/01/01").AddDays(0.0), "yyyy/MM/dd"), "' AND [Entry Date] <= '", Strings.Format(Conversions.ToDate("1900/01/01").AddDays(1.0), "yyyy/MM/dd"), "'" })
				Catch ex2 As Exception
				End Try
			Next
			Dim num2 As Integer = Me.DGVUserData.RowCount - 1
			For j As Integer = 0 To num2
				Me.DGVUserData.Sort(Me.DGVUserData.Columns(32), ListSortDirection.Descending)
				Dim flag As Boolean = Operators.CompareString(Me.DGVUserData.Rows(j).Cells(31).Value.ToString(), "Accepted", False) = 0
				If flag Then
					Me.DGVUserData.Rows(j).DefaultCellStyle.BackColor = Color.Lime
				End If
				Dim flag2 As Boolean = Operators.CompareString(Me.DGVUserData.Rows(j).Cells(31).Value.ToString(), "Rejected", False) = 0
				If flag2 Then
					Me.DGVUserData.Rows(j).DefaultCellStyle.BackColor = Color.OrangeRed
				End If
			Next
			Me.DGVUserData.ClearSelection()
		End Sub

		' Token: 0x0600312C RID: 12588 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtQty_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600312D RID: 12589 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtSendtoCompID_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600312E RID: 12590 RVA: 0x001E8CC8 File Offset: 0x001E6EC8
		Private Sub DGVUserData_MouseUp(sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = e.Button = MouseButtons.Right
			If flag Then
				Try
					Dim hitTestInfo As DataGridView.HitTestInfo = Me.DGVUserData.HitTest(e.X, e.Y)
					Me.DGVUserData.ClearSelection()
					frmGodownOutward.selectedIndex = hitTestInfo.RowIndex
					Me.DGVUserData.Rows(hitTestInfo.RowIndex).Selected = True
					Me.ContextMenuStrip1.Show(Me.DGVUserData, New Point(e.X, e.Y))
				Catch ex As Exception
				End Try
			End If
		End Sub

		' Token: 0x0600312F RID: 12591 RVA: 0x001E8D80 File Offset: 0x001E6F80
		Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
			If flag Then
				Dim flag2 As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag2 Then
					MessageBox.Show("Please check your internet connection", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtSendtoCompID.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please fill company / branch id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtSendtoCompID.Focus()
					Else
						Dim flag4 As Boolean = Me.DGVUserData.Rows.Count > 0
						If flag4 Then
							Try
								For Each obj As Object In Me.DGVUserData.SelectedRows
									Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
									Dim text As String = dataGridViewRow.Cells(33).Value.ToString()
									Dim array As String() = text.Split(New Char() { "_"c })
									Dim text2 As String = array(0)
									Dim flag5 As Boolean = Operators.CompareString(text2, Me.lblCompID.Text, False) <> 0
									If flag5 Then
										MessageBox.Show("Your Company/Branch ID is mismatched !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Return
									End If
								Next
							Finally
								Dim enumerator As IEnumerator
								If TypeOf enumerator Is IDisposable Then
									TryCast(enumerator, IDisposable).Dispose()
								End If
							End Try
						End If
						Dim flag6 As Boolean = Me.DGVUserData.Rows.Count > 0
						If flag6 Then
							Try
								For Each obj2 As Object In Me.DGVUserData.SelectedRows
									Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
									Dim firebaseResponse As FirebaseResponse = Me.client.[Get](Conversions.ToString(Operators.AddObject(Me.txtSendtoCompID.Text + "/", dataGridViewRow2.Cells(33).Value)))
									Dim firebaseCRUDData As FirebaseCRUDData = New FirebaseCRUDData()
									firebaseCRUDData = firebaseResponse.ResultAs(Of FirebaseCRUDData)()
									Dim flag7 As Boolean = Operators.CompareString(firebaseCRUDData.Sts, "Accepted", False) = 0
									If flag7 Then
										MessageBox.Show("You are not allowed to delete the 'Accepted' record", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Return
									End If
								Next
							Finally
								Dim enumerator2 As IEnumerator
								If TypeOf enumerator2 Is IDisposable Then
									TryCast(enumerator2, IDisposable).Dispose()
								End If
							End Try
						End If
						Try
							Dim flag8 As Boolean = Me.DGVUserData.Rows.Count > 0
							If flag8 Then
								Try
									For Each obj3 As Object In Me.DGVUserData.SelectedRows
										Dim dataGridViewRow3 As DataGridViewRow = CType(obj3, DataGridViewRow)
										Dim firebaseResponse2 As FirebaseResponse = Me.client.Delete(Conversions.ToString(Operators.AddObject(Me.txtSendtoCompID.Text + "/", dataGridViewRow3.Cells(33).Value)))
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text3 As String = "Update Temp_Stock set qty=qty + " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(30).Value))) + " where ProductID=@d1 and Barcode=@d2"
										ModCommonClasses.cmd = New SqlCommand(text3)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow3.Cells(5).Value.ToString())
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										Dim flag9 As Boolean = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(30).Value)) > 0.0
										If flag9 Then
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text4 As String = "select ProductID from StockMovement where ProductID=@d1"
											ModCommonClasses.cmd = New SqlCommand(text4)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag10 As Boolean = Not ModCommonClasses.rdr.Read()
											If flag10 Then
												ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))), 0D, New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(30).Value))), 0D, DateAndTime.Today.[Date], Conversions.ToString(dataGridViewRow3.Cells(1).Value))
											Else
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text5 As String = "select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 and Date < @d3"
												ModCommonClasses.cmd = New SqlCommand(text5)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d3", DateAndTime.Today.[Date])
												ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
												Dim flag11 As Boolean = ModCommonClasses.rdr.Read()
												Dim num As Double
												If flag11 Then
													num = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
												Else
													num = 0.0
												End If
												ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))), New Decimal(num), New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(30).Value))), 0D, DateAndTime.Today.[Date], Conversions.ToString(dataGridViewRow3.Cells(1).Value))
											End If
											ModCommonClasses.con.Close()
										End If
										ModFunc.AuditTrial_Inventory(Dns.GetHostName(), Me.lblUser.Text, "Delete", "Cloud Stock Out Cancel", Conversions.ToString(dataGridViewRow3.Cells(33).Value), DateAndTime.Today.[Date], "Cloud Outward Stock Transfer Cancel", Conversions.ToString(dataGridViewRow3.Cells(2).Value), New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(30).Value))), 0D, 0D)
										ModFunc.LogFunc(Me.lblUser.Text, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Deleted the cloud stock out record having vch no. '", dataGridViewRow3.Cells(33).Value), "'")))
										MessageBox.Show("Data Successfully deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										Thread.Sleep(1000)
										Me.DGVUserData.Rows.Remove(dataGridViewRow3)
										Me.DGVUserData.ClearSelection()
										Dim num2 As Integer = Me.DGVUserData.RowCount - 1
										For i As Integer = 0 To num2
											Try
												Me.dtTableGrd.DefaultView.RowFilter = ""
												TryCast(Me.DGVUserData.DataSource, DataTable).DefaultView.RowFilter = String.Concat(New String() { "[Entry Date] >= '", Strings.Format(Conversions.ToDate("1900/01/01").AddDays(0.0), "yyyy/MM/dd"), "' AND [Entry Date] <= '", Strings.Format(Conversions.ToDate("1900/01/01").AddDays(1.0), "yyyy/MM/dd"), "'" })
											Catch ex As Exception
											End Try
										Next
										Dim num3 As Integer = Me.DGVUserData.RowCount - 1
										For j As Integer = 0 To num3
											Dim flag12 As Boolean = Operators.CompareString(Me.DGVUserData.Rows(j).Cells(31).Value.ToString(), "Accepted", False) = 0
											If flag12 Then
												Me.DGVUserData.Rows(j).DefaultCellStyle.BackColor = Color.Lime
											End If
											Dim flag13 As Boolean = Operators.CompareString(Me.DGVUserData.Rows(j).Cells(31).Value.ToString(), "Rejected", False) = 0
											If flag13 Then
												Me.DGVUserData.Rows(j).DefaultCellStyle.BackColor = Color.OrangeRed
											End If
										Next
									Next
								Finally
									Dim enumerator3 As IEnumerator
									If TypeOf enumerator3 Is IDisposable Then
										TryCast(enumerator3, IDisposable).Dispose()
									End If
								End Try
							End If
						Catch ex2 As Exception
							MessageBox.Show(ex2.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x06003130 RID: 12592 RVA: 0x001E978C File Offset: 0x001E798C
		Private Sub DGVUserData_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.DGVUserData.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.DGVUserData.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim controlDarkDark As Brush = SystemBrushes.ControlDarkDark
			e.Graphics.DrawString(text, Me.Font, controlDarkDark, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x06003131 RID: 12593 RVA: 0x001E9874 File Offset: 0x001E7A74
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				TryCast(Me.DGVUserData.DataSource, DataTable).DefaultView.RowFilter = "Status Like '" + Me.ComboBox1.Text + "%'"
				Me.DGVUserData.ClearSelection()
			Catch ex As Exception
			End Try
			Try
				Me.DGVUserData.Columns(33).Visible = False
			Catch ex2 As Exception
			End Try
			Dim num As Integer = Me.DGVUserData.RowCount - 1
			For i As Integer = 0 To num
				Me.DGVUserData.Sort(Me.DGVUserData.Columns(32), ListSortDirection.Descending)
				Dim flag As Boolean = Operators.CompareString(Me.DGVUserData.Rows(i).Cells(31).Value.ToString(), "Accepted", False) = 0
				If flag Then
					Me.DGVUserData.Rows(i).DefaultCellStyle.BackColor = Color.Lime
				End If
				Dim flag2 As Boolean = Operators.CompareString(Me.DGVUserData.Rows(i).Cells(31).Value.ToString(), "Rejected", False) = 0
				If flag2 Then
					Me.DGVUserData.Rows(i).DefaultCellStyle.BackColor = Color.OrangeRed
				End If
			Next
			Me.DGVUserData.ClearSelection()
		End Sub

		' Token: 0x06003132 RID: 12594 RVA: 0x001E9A28 File Offset: 0x001E7C28
		Private Sub btnExportExcel_ClickButtonArea(Sender As Object, e As MouseEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = (Me.DGVUserData.Columns.Count = 0) Or (Me.DGVUserData.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.DGVUserData.Columns
							Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
							Dim visible As Boolean = dataGridViewColumn.Visible
							If visible Then
								dataTable.Columns.Add(dataGridViewColumn.HeaderText)
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj2 As Object In CType(Me.DGVUserData.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
							Dim dataRow As DataRow = dataTable.Rows.Add(New Object(-1) {})
							Dim num As Integer = 0
							Try
								For Each obj3 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
									Dim visible2 As Boolean = Me.DGVUserData.Columns(dataGridViewCell.ColumnIndex).Visible
									If visible2 Then
										Dim dataRow2 As DataRow = dataRow
										Dim num2 As Integer = num
										Dim value As Object = dataGridViewCell.Value
										dataRow2(num2) = If((value IsNot Nothing), value.ToString(), Nothing)
										num += 1
									End If
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
						Dim ixlworksheet As IXLWorksheet = xlworkbook.Worksheets.Add(dataTable, "Export File")
						Try
							For Each ixlcolumn As IXLColumn In ixlworksheet.Columns()
								ixlcolumn.AdjustToContents()
							Next
						Finally
							Dim enumerator4 As IEnumerator(Of IXLColumn)
							If enumerator4 IsNot Nothing Then
								enumerator4.Dispose()
							End If
						End Try
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0400150E RID: 5390
		Private client As IFirebaseClient

		' Token: 0x0400150F RID: 5391
		Private RealtimeDatabasePath As String

		' Token: 0x04001510 RID: 5392
		Private EmailSecretKey As String

		' Token: 0x04001511 RID: 5393
		Private DateTimeFormat As String

		' Token: 0x04001512 RID: 5394
		Private otp As String

		' Token: 0x04001513 RID: 5395
		Private clearDGVCol As Boolean

		' Token: 0x04001514 RID: 5396
		Private dtTableGrd As DataTable

		' Token: 0x04001515 RID: 5397
		Public Shared selectedIndex As Integer = 0
	End Class
End Namespace
