Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.VisualBasic.PowerPacks

Namespace BillPoint
	' Token: 0x020002AA RID: 682
	<DesignerGenerated()>
	Public Partial Class frmProfitloss
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600AE5A RID: 44634 RVA: 0x00745E24 File Offset: 0x00744024
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmProfitloss_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmProfitloss_KeyDown
			Me.rdr1 = Nothing
			Me.PrintDoc1 = New PrintDocument()
			Me.PrintPreviewDialog1 = New PrintPreviewDialog()
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700436A RID: 17258
		' (get) Token: 0x0600AE5D RID: 44637 RVA: 0x000511B3 File Offset: 0x0004F3B3
		' (set) Token: 0x0600AE5E RID: 44638 RVA: 0x000511BD File Offset: 0x0004F3BD
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700436B RID: 17259
		' (get) Token: 0x0600AE5F RID: 44639 RVA: 0x000511C6 File Offset: 0x0004F3C6
		' (set) Token: 0x0600AE60 RID: 44640 RVA: 0x000511D0 File Offset: 0x0004F3D0
		Friend Overridable Property ShapeContainer1 As ShapeContainer

		' Token: 0x1700436C RID: 17260
		' (get) Token: 0x0600AE61 RID: 44641 RVA: 0x000511D9 File Offset: 0x0004F3D9
		' (set) Token: 0x0600AE62 RID: 44642 RVA: 0x000511E3 File Offset: 0x0004F3E3
		Friend Overridable Property LineShape1 As LineShape

		' Token: 0x1700436D RID: 17261
		' (get) Token: 0x0600AE63 RID: 44643 RVA: 0x000511EC File Offset: 0x0004F3EC
		' (set) Token: 0x0600AE64 RID: 44644 RVA: 0x000511F6 File Offset: 0x0004F3F6
		Friend Overridable Property Label1 As Label

		' Token: 0x1700436E RID: 17262
		' (get) Token: 0x0600AE65 RID: 44645 RVA: 0x000511FF File Offset: 0x0004F3FF
		' (set) Token: 0x0600AE66 RID: 44646 RVA: 0x00051209 File Offset: 0x0004F409
		Friend Overridable Property Label3 As Label

		' Token: 0x1700436F RID: 17263
		' (get) Token: 0x0600AE67 RID: 44647 RVA: 0x00051212 File Offset: 0x0004F412
		' (set) Token: 0x0600AE68 RID: 44648 RVA: 0x0005121C File Offset: 0x0004F41C
		Friend Overridable Property Label2 As Label

		' Token: 0x17004370 RID: 17264
		' (get) Token: 0x0600AE69 RID: 44649 RVA: 0x00051225 File Offset: 0x0004F425
		' (set) Token: 0x0600AE6A RID: 44650 RVA: 0x0005122F File Offset: 0x0004F42F
		Friend Overridable Property Label7 As Label

		' Token: 0x17004371 RID: 17265
		' (get) Token: 0x0600AE6B RID: 44651 RVA: 0x00051238 File Offset: 0x0004F438
		' (set) Token: 0x0600AE6C RID: 44652 RVA: 0x00051242 File Offset: 0x0004F442
		Friend Overridable Property Label6 As Label

		' Token: 0x17004372 RID: 17266
		' (get) Token: 0x0600AE6D RID: 44653 RVA: 0x0005124B File Offset: 0x0004F44B
		' (set) Token: 0x0600AE6E RID: 44654 RVA: 0x00051255 File Offset: 0x0004F455
		Friend Overridable Property Label5 As Label

		' Token: 0x17004373 RID: 17267
		' (get) Token: 0x0600AE6F RID: 44655 RVA: 0x0005125E File Offset: 0x0004F45E
		' (set) Token: 0x0600AE70 RID: 44656 RVA: 0x00051268 File Offset: 0x0004F468
		Friend Overridable Property Label4 As Label

		' Token: 0x17004374 RID: 17268
		' (get) Token: 0x0600AE71 RID: 44657 RVA: 0x00051271 File Offset: 0x0004F471
		' (set) Token: 0x0600AE72 RID: 44658 RVA: 0x0005127B File Offset: 0x0004F47B
		Friend Overridable Property Label11 As Label

		' Token: 0x17004375 RID: 17269
		' (get) Token: 0x0600AE73 RID: 44659 RVA: 0x00051284 File Offset: 0x0004F484
		' (set) Token: 0x0600AE74 RID: 44660 RVA: 0x0005128E File Offset: 0x0004F48E
		Friend Overridable Property Label10 As Label

		' Token: 0x17004376 RID: 17270
		' (get) Token: 0x0600AE75 RID: 44661 RVA: 0x00051297 File Offset: 0x0004F497
		' (set) Token: 0x0600AE76 RID: 44662 RVA: 0x000512A1 File Offset: 0x0004F4A1
		Friend Overridable Property Label9 As Label

		' Token: 0x17004377 RID: 17271
		' (get) Token: 0x0600AE77 RID: 44663 RVA: 0x000512AA File Offset: 0x0004F4AA
		' (set) Token: 0x0600AE78 RID: 44664 RVA: 0x000512B4 File Offset: 0x0004F4B4
		Friend Overridable Property Label8 As Label

		' Token: 0x17004378 RID: 17272
		' (get) Token: 0x0600AE79 RID: 44665 RVA: 0x000512BD File Offset: 0x0004F4BD
		' (set) Token: 0x0600AE7A RID: 44666 RVA: 0x000512C7 File Offset: 0x0004F4C7
		Friend Overridable Property DateTimePicker2 As DateTimePicker

		' Token: 0x17004379 RID: 17273
		' (get) Token: 0x0600AE7B RID: 44667 RVA: 0x000512D0 File Offset: 0x0004F4D0
		' (set) Token: 0x0600AE7C RID: 44668 RVA: 0x000512DA File Offset: 0x0004F4DA
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x1700437A RID: 17274
		' (get) Token: 0x0600AE7D RID: 44669 RVA: 0x000512E3 File Offset: 0x0004F4E3
		' (set) Token: 0x0600AE7E RID: 44670 RVA: 0x000512ED File Offset: 0x0004F4ED
		Friend Overridable Property Label12 As Label

		' Token: 0x1700437B RID: 17275
		' (get) Token: 0x0600AE7F RID: 44671 RVA: 0x000512F6 File Offset: 0x0004F4F6
		' (set) Token: 0x0600AE80 RID: 44672 RVA: 0x00051300 File Offset: 0x0004F500
		Friend Overridable Property Label13 As Label

		' Token: 0x1700437C RID: 17276
		' (get) Token: 0x0600AE81 RID: 44673 RVA: 0x00051309 File Offset: 0x0004F509
		' (set) Token: 0x0600AE82 RID: 44674 RVA: 0x00748BE8 File Offset: 0x00746DE8
		Private _TextBox8 As TextBox
		Friend Overridable Property TextBox8 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox8
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox8_TextChanged
				Dim textBox As TextBox = Me._TextBox8
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox8 = value
				textBox = Me._TextBox8
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700437D RID: 17277
		' (get) Token: 0x0600AE83 RID: 44675 RVA: 0x00051313 File Offset: 0x0004F513
		' (set) Token: 0x0600AE84 RID: 44676 RVA: 0x00748C2C File Offset: 0x00746E2C
		Private _TextBox7 As TextBox
		Friend Overridable Property TextBox7 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox7_TextChanged
				Dim textBox As TextBox = Me._TextBox7
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox7 = value
				textBox = Me._TextBox7
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700437E RID: 17278
		' (get) Token: 0x0600AE85 RID: 44677 RVA: 0x0005131D File Offset: 0x0004F51D
		' (set) Token: 0x0600AE86 RID: 44678 RVA: 0x00748C70 File Offset: 0x00746E70
		Private _TextBox6 As TextBox
		Friend Overridable Property TextBox6 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox6_TextChanged
				Dim textBox As TextBox = Me._TextBox6
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox6 = value
				textBox = Me._TextBox6
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700437F RID: 17279
		' (get) Token: 0x0600AE87 RID: 44679 RVA: 0x00051327 File Offset: 0x0004F527
		' (set) Token: 0x0600AE88 RID: 44680 RVA: 0x00748CB4 File Offset: 0x00746EB4
		Private _TextBox5 As TextBox
		Friend Overridable Property TextBox5 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox5_TextChanged
				Dim textBox As TextBox = Me._TextBox5
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox5 = value
				textBox = Me._TextBox5
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004380 RID: 17280
		' (get) Token: 0x0600AE89 RID: 44681 RVA: 0x00051331 File Offset: 0x0004F531
		' (set) Token: 0x0600AE8A RID: 44682 RVA: 0x00748CF8 File Offset: 0x00746EF8
		Private _TextBox4 As TextBox
		Friend Overridable Property TextBox4 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox4_TextChanged
				Dim textBox As TextBox = Me._TextBox4
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox4 = value
				textBox = Me._TextBox4
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004381 RID: 17281
		' (get) Token: 0x0600AE8B RID: 44683 RVA: 0x0005133B File Offset: 0x0004F53B
		' (set) Token: 0x0600AE8C RID: 44684 RVA: 0x00748D3C File Offset: 0x00746F3C
		Private _TextBox3 As TextBox
		Friend Overridable Property TextBox3 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox3_TextChanged
				Dim textBox As TextBox = Me._TextBox3
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox3 = value
				textBox = Me._TextBox3
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004382 RID: 17282
		' (get) Token: 0x0600AE8D RID: 44685 RVA: 0x00051345 File Offset: 0x0004F545
		' (set) Token: 0x0600AE8E RID: 44686 RVA: 0x00748D80 File Offset: 0x00746F80
		Private _TextBox2 As TextBox
		Friend Overridable Property TextBox2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox2_TextChanged
				Dim textBox As TextBox = Me._TextBox2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox2 = value
				textBox = Me._TextBox2
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004383 RID: 17283
		' (get) Token: 0x0600AE8F RID: 44687 RVA: 0x0005134F File Offset: 0x0004F54F
		' (set) Token: 0x0600AE90 RID: 44688 RVA: 0x00748DC4 File Offset: 0x00746FC4
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_TextChanged
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004384 RID: 17284
		' (get) Token: 0x0600AE91 RID: 44689 RVA: 0x00051359 File Offset: 0x0004F559
		' (set) Token: 0x0600AE92 RID: 44690 RVA: 0x00051363 File Offset: 0x0004F563
		Friend Overridable Property Label15 As Label

		' Token: 0x17004385 RID: 17285
		' (get) Token: 0x0600AE93 RID: 44691 RVA: 0x0005136C File Offset: 0x0004F56C
		' (set) Token: 0x0600AE94 RID: 44692 RVA: 0x00051376 File Offset: 0x0004F576
		Friend Overridable Property Label14 As Label

		' Token: 0x17004386 RID: 17286
		' (get) Token: 0x0600AE95 RID: 44693 RVA: 0x0005137F File Offset: 0x0004F57F
		' (set) Token: 0x0600AE96 RID: 44694 RVA: 0x00748E08 File Offset: 0x00747008
		Private _TextBox10 As TextBox
		Friend Overridable Property TextBox10 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox10
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox10_TextChanged
				Dim textBox As TextBox = Me._TextBox10
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox10 = value
				textBox = Me._TextBox10
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004387 RID: 17287
		' (get) Token: 0x0600AE97 RID: 44695 RVA: 0x00051389 File Offset: 0x0004F589
		' (set) Token: 0x0600AE98 RID: 44696 RVA: 0x00748E4C File Offset: 0x0074704C
		Private _TextBox9 As TextBox
		Friend Overridable Property TextBox9 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox9
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox9_TextChanged
				Dim textBox As TextBox = Me._TextBox9
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox9 = value
				textBox = Me._TextBox9
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004388 RID: 17288
		' (get) Token: 0x0600AE99 RID: 44697 RVA: 0x00051393 File Offset: 0x0004F593
		' (set) Token: 0x0600AE9A RID: 44698 RVA: 0x00748E90 File Offset: 0x00747090
		Private _TextBox11 As TextBox
		Friend Overridable Property TextBox11 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox11
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox11_TextChanged
				Dim textBox As TextBox = Me._TextBox11
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox11 = value
				textBox = Me._TextBox11
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004389 RID: 17289
		' (get) Token: 0x0600AE9B RID: 44699 RVA: 0x0005139D File Offset: 0x0004F59D
		' (set) Token: 0x0600AE9C RID: 44700 RVA: 0x00748ED4 File Offset: 0x007470D4
		Private _Label16 As Label
		Friend Overridable Property Label16 As Label
			<CompilerGenerated()>
			Get
				Return Me._Label16
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim eventHandler As EventHandler = AddressOf Me.Label16_TextChanged
				Dim label As Label = Me._Label16
				If label IsNot Nothing Then
					RemoveHandler label.TextChanged, eventHandler
				End If
				Me._Label16 = value
				label = Me._Label16
				If label IsNot Nothing Then
					AddHandler label.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700438A RID: 17290
		' (get) Token: 0x0600AE9D RID: 44701 RVA: 0x000513A7 File Offset: 0x0004F5A7
		' (set) Token: 0x0600AE9E RID: 44702 RVA: 0x00748F18 File Offset: 0x00747118
		Private _TextBox12 As TextBox
		Friend Overridable Property TextBox12 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox12
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox12_TextChanged
				Dim textBox As TextBox = Me._TextBox12
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox12 = value
				textBox = Me._TextBox12
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700438B RID: 17291
		' (get) Token: 0x0600AE9F RID: 44703 RVA: 0x000513B1 File Offset: 0x0004F5B1
		' (set) Token: 0x0600AEA0 RID: 44704 RVA: 0x00748F5C File Offset: 0x0074715C
		Private _TextBox14 As TextBox
		Friend Overridable Property TextBox14 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox14
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox14_TextChanged
				Dim textBox As TextBox = Me._TextBox14
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox14 = value
				textBox = Me._TextBox14
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700438C RID: 17292
		' (get) Token: 0x0600AEA1 RID: 44705 RVA: 0x000513BB File Offset: 0x0004F5BB
		' (set) Token: 0x0600AEA2 RID: 44706 RVA: 0x00748FA0 File Offset: 0x007471A0
		Private _TextBox13 As TextBox
		Friend Overridable Property TextBox13 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox13
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox13_TextChanged
				Dim textBox As TextBox = Me._TextBox13
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox13 = value
				textBox = Me._TextBox13
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700438D RID: 17293
		' (get) Token: 0x0600AEA3 RID: 44707 RVA: 0x000513C5 File Offset: 0x0004F5C5
		' (set) Token: 0x0600AEA4 RID: 44708 RVA: 0x00748FE4 File Offset: 0x007471E4
		Private _TextBox16 As TextBox
		Friend Overridable Property TextBox16 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox16
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox16_TextChanged
				Dim textBox As TextBox = Me._TextBox16
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox16 = value
				textBox = Me._TextBox16
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700438E RID: 17294
		' (get) Token: 0x0600AEA5 RID: 44709 RVA: 0x000513CF File Offset: 0x0004F5CF
		' (set) Token: 0x0600AEA6 RID: 44710 RVA: 0x00749028 File Offset: 0x00747228
		Private _TextBox15 As TextBox
		Friend Overridable Property TextBox15 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox15
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox15_TextChanged
				Dim textBox As TextBox = Me._TextBox15
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox15 = value
				textBox = Me._TextBox15
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700438F RID: 17295
		' (get) Token: 0x0600AEA7 RID: 44711 RVA: 0x000513D9 File Offset: 0x0004F5D9
		' (set) Token: 0x0600AEA8 RID: 44712 RVA: 0x000513E3 File Offset: 0x0004F5E3
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004390 RID: 17296
		' (get) Token: 0x0600AEA9 RID: 44713 RVA: 0x000513EC File Offset: 0x0004F5EC
		' (set) Token: 0x0600AEAA RID: 44714 RVA: 0x000513F6 File Offset: 0x0004F5F6
		Friend Overridable Property Label17 As Label

		' Token: 0x17004391 RID: 17297
		' (get) Token: 0x0600AEAB RID: 44715 RVA: 0x000513FF File Offset: 0x0004F5FF
		' (set) Token: 0x0600AEAC RID: 44716 RVA: 0x0074906C File Offset: 0x0074726C
		Private _Button3 As Button
		Friend Overridable Property Button3 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button3_Click
				Dim button As Button = Me._Button3
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button3 = value
				button = Me._Button3
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004392 RID: 17298
		' (get) Token: 0x0600AEAD RID: 44717 RVA: 0x00051409 File Offset: 0x0004F609
		' (set) Token: 0x0600AEAE RID: 44718 RVA: 0x007490B0 File Offset: 0x007472B0
		Private _TextBox19 As TextBox
		Friend Overridable Property TextBox19 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox19
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox19_TextChanged
				Dim textBox As TextBox = Me._TextBox19
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox19 = value
				textBox = Me._TextBox19
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004393 RID: 17299
		' (get) Token: 0x0600AEAF RID: 44719 RVA: 0x00051413 File Offset: 0x0004F613
		' (set) Token: 0x0600AEB0 RID: 44720 RVA: 0x007490F4 File Offset: 0x007472F4
		Private _TextBox18 As TextBox
		Friend Overridable Property TextBox18 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox18
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox18_TextChanged
				Dim textBox As TextBox = Me._TextBox18
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox18 = value
				textBox = Me._TextBox18
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004394 RID: 17300
		' (get) Token: 0x0600AEB1 RID: 44721 RVA: 0x0005141D File Offset: 0x0004F61D
		' (set) Token: 0x0600AEB2 RID: 44722 RVA: 0x00749138 File Offset: 0x00747338
		Private _TextBox17 As TextBox
		Friend Overridable Property TextBox17 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox17
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox17_TextChanged
				Dim textBox As TextBox = Me._TextBox17
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox17 = value
				textBox = Me._TextBox17
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004395 RID: 17301
		' (get) Token: 0x0600AEB3 RID: 44723 RVA: 0x00051427 File Offset: 0x0004F627
		' (set) Token: 0x0600AEB4 RID: 44724 RVA: 0x00051431 File Offset: 0x0004F631
		Friend Overridable Property Label18 As Label

		' Token: 0x17004396 RID: 17302
		' (get) Token: 0x0600AEB5 RID: 44725 RVA: 0x0005143A File Offset: 0x0004F63A
		' (set) Token: 0x0600AEB6 RID: 44726 RVA: 0x00051444 File Offset: 0x0004F644
		Friend Overridable Property Label20 As Label

		' Token: 0x17004397 RID: 17303
		' (get) Token: 0x0600AEB7 RID: 44727 RVA: 0x0005144D File Offset: 0x0004F64D
		' (set) Token: 0x0600AEB8 RID: 44728 RVA: 0x00051457 File Offset: 0x0004F657
		Friend Overridable Property Label19 As Label

		' Token: 0x17004398 RID: 17304
		' (get) Token: 0x0600AEB9 RID: 44729 RVA: 0x00051460 File Offset: 0x0004F660
		' (set) Token: 0x0600AEBA RID: 44730 RVA: 0x0005146A File Offset: 0x0004F66A
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17004399 RID: 17305
		' (get) Token: 0x0600AEBB RID: 44731 RVA: 0x00051473 File Offset: 0x0004F673
		' (set) Token: 0x0600AEBC RID: 44732 RVA: 0x0005147D File Offset: 0x0004F67D
		Friend Overridable Property Panel5 As Panel

		' Token: 0x1700439A RID: 17306
		' (get) Token: 0x0600AEBD RID: 44733 RVA: 0x00051486 File Offset: 0x0004F686
		' (set) Token: 0x0600AEBE RID: 44734 RVA: 0x00051490 File Offset: 0x0004F690
		Friend Overridable Property Panel4 As Panel

		' Token: 0x1700439B RID: 17307
		' (get) Token: 0x0600AEBF RID: 44735 RVA: 0x00051499 File Offset: 0x0004F699
		' (set) Token: 0x0600AEC0 RID: 44736 RVA: 0x000514A3 File Offset: 0x0004F6A3
		Friend Overridable Property Panel3 As Panel

		' Token: 0x1700439C RID: 17308
		' (get) Token: 0x0600AEC1 RID: 44737 RVA: 0x000514AC File Offset: 0x0004F6AC
		' (set) Token: 0x0600AEC2 RID: 44738 RVA: 0x000514B6 File Offset: 0x0004F6B6
		Friend Overridable Property Panel7 As Panel

		' Token: 0x1700439D RID: 17309
		' (get) Token: 0x0600AEC3 RID: 44739 RVA: 0x000514BF File Offset: 0x0004F6BF
		' (set) Token: 0x0600AEC4 RID: 44740 RVA: 0x0074917C File Offset: 0x0074737C
		Private _Button4 As Button
		Friend Overridable Property Button4 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button4_Click
				Dim button As Button = Me._Button4
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button4 = value
				button = Me._Button4
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700439E RID: 17310
		' (get) Token: 0x0600AEC5 RID: 44741 RVA: 0x000514C9 File Offset: 0x0004F6C9
		' (set) Token: 0x0600AEC6 RID: 44742 RVA: 0x000514D3 File Offset: 0x0004F6D3
		Friend Overridable Property Label21 As Label

		' Token: 0x1700439F RID: 17311
		' (get) Token: 0x0600AEC7 RID: 44743 RVA: 0x000514DC File Offset: 0x0004F6DC
		' (set) Token: 0x0600AEC8 RID: 44744 RVA: 0x000514E6 File Offset: 0x0004F6E6
		Friend Overridable Property Label30 As Label

		' Token: 0x170043A0 RID: 17312
		' (get) Token: 0x0600AEC9 RID: 44745 RVA: 0x000514EF File Offset: 0x0004F6EF
		' (set) Token: 0x0600AECA RID: 44746 RVA: 0x000514F9 File Offset: 0x0004F6F9
		Friend Overridable Property Label22 As Label

		' Token: 0x170043A1 RID: 17313
		' (get) Token: 0x0600AECB RID: 44747 RVA: 0x00051502 File Offset: 0x0004F702
		' (set) Token: 0x0600AECC RID: 44748 RVA: 0x007491C0 File Offset: 0x007473C0
		Private _TextBox20 As TextBox
		Friend Overridable Property TextBox20 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox20
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox20_TextChanged
				Dim textBox As TextBox = Me._TextBox20
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox20 = value
				textBox = Me._TextBox20
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170043A2 RID: 17314
		' (get) Token: 0x0600AECD RID: 44749 RVA: 0x0005150C File Offset: 0x0004F70C
		' (set) Token: 0x0600AECE RID: 44750 RVA: 0x00749204 File Offset: 0x00747404
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

		' Token: 0x170043A3 RID: 17315
		' (get) Token: 0x0600AECF RID: 44751 RVA: 0x00051516 File Offset: 0x0004F716
		' (set) Token: 0x0600AED0 RID: 44752 RVA: 0x00749248 File Offset: 0x00747448
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

		' Token: 0x170043A4 RID: 17316
		' (get) Token: 0x0600AED1 RID: 44753 RVA: 0x00051520 File Offset: 0x0004F720
		' (set) Token: 0x0600AED2 RID: 44754 RVA: 0x0074928C File Offset: 0x0074748C
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

		' Token: 0x0600AED3 RID: 44755 RVA: 0x007492D0 File Offset: 0x007474D0
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo),RTRIM(CurSym) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.DateTimePicker1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.Label30.Text = "(" + NewLateBinding.LateGet(ModCommonClasses.rdr.GetValue(2), Nothing, "TrimEnd", New Object(-1) {}, Nothing, Nothing, Nothing).ToString() + ")"
					Me.Label21.Text = "(" + NewLateBinding.LateGet(ModCommonClasses.rdr.GetValue(2), Nothing, "TrimEnd", New Object(-1) {}, Nothing, Nothing, Nothing).ToString() + ")"
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

		' Token: 0x0600AED4 RID: 44756 RVA: 0x0074943C File Offset: 0x0074763C
		Private Sub frmProfitloss_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.DateTimePicker2.Value = DateAndTime.Today
			Me.OPS()
			Me.a1()
			Me.b1()
			Me.c1()
			Me.d1()
			Me.e1()
			Me.f1()
			Me.g1()
			Me.h1()
			Me.h123()
			Me.h124()
			Me.frtn1()
			Me.bpr1()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600AED5 RID: 44757 RVA: 0x007494C4 File Offset: 0x007476C4
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

		' Token: 0x0600AED6 RID: 44758 RVA: 0x0074963C File Offset: 0x0074783C
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
			If flag Then
				Dim text As String = ctrl.Text
				Dim flag2 As Boolean = translations.ContainsKey(text)
				If flag2 Then
					ctrl.Text = translations(text)
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

		' Token: 0x0600AED7 RID: 44759 RVA: 0x007496F8 File Offset: 0x007478F8
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

		' Token: 0x0600AED8 RID: 44760 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600AED9 RID: 44761 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600AEDA RID: 44762 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600AEDB RID: 44763 RVA: 0x007497C4 File Offset: 0x007479C4
		Private Sub OPS()
			Me.TextBox20.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(PPrice * Qty)) from Product_OpeningStock where PAddDate between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox20.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox20.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox20.Text), 2), "0.00")
		End Sub

		' Token: 0x0600AEDC RID: 44764 RVA: 0x0074993C File Offset: 0x00747B3C
		Private Sub a1()
			Me.TextBox1.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(GrandTotal)-(Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS))) from invoiceinfo where invoicedate between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox1.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox1.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox1.Text), 2), "0.00")
		End Sub

		' Token: 0x0600AEDD RID: 44765 RVA: 0x00749AB4 File Offset: 0x00747CB4
		Private Sub b1()
			Me.TextBox15.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(GrandTotal) from PurchaseReturn where date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox15.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox15.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox15.Text), 2), "0.00")
		End Sub

		' Token: 0x0600AEDE RID: 44766 RVA: 0x00749C2C File Offset: 0x00747E2C
		Private Sub bpr1()
			Me.TextBox16.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)) from PurchaseReturn where RCM='No' and date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox16.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox16.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox16.Text), 2), "0.00")
		End Sub

		' Token: 0x0600AEDF RID: 44767 RVA: 0x00749DA4 File Offset: 0x00747FA4
		Private Sub c1()
			Me.TextBox5.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(Amount) from Income_OtherDetails where Note in ('Income (Direct/Indirect)') and Date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox5.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox5.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox5.Text), 2), "0.00")
		End Sub

		' Token: 0x0600AEE0 RID: 44768 RVA: 0x00749F1C File Offset: 0x0074811C
		Private Sub d1()
			Me.TextBox3.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(AdvanceDeposit) from Service where ServiceCreationDate between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox3.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox3.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox3.Text), 2), "0.00")
		End Sub

		' Token: 0x0600AEE1 RID: 44769 RVA: 0x0074A094 File Offset: 0x00748294
		Private Sub e1()
			Me.TextBox4.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(RepairCharges)-Sum(Upfront)) from InvoiceInfo1 where InvoiceDate between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox4.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox4.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox4.Text), 2), "0.00")
		End Sub

		' Token: 0x0600AEE2 RID: 44770 RVA: 0x0074A20C File Offset: 0x0074840C
		Private Sub f1()
			Me.TextBox13.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(GrandTotal)-Sum(PreviousDue)) from stock where date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox13.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox13.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox13.Text), 2), "0.00")
		End Sub

		' Token: 0x0600AEE3 RID: 44771 RVA: 0x0074A384 File Offset: 0x00748584
		Private Sub frtn1()
			Me.TextBox14.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)) from stock where ReferenceNo2='No' and date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox14.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox14.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox14.Text), 2), "0.00")
		End Sub

		' Token: 0x0600AEE4 RID: 44772 RVA: 0x0074A4FC File Offset: 0x007486FC
		Private Sub g1()
			Me.TextBox7.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(GrandTotal)-(Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS))) from SalesReturn where date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox7.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox7.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox7.Text), 2), "0.00")
		End Sub

		' Token: 0x0600AEE5 RID: 44773 RVA: 0x0074A674 File Offset: 0x00748874
		Private Sub h1()
			Me.TextBox17.Text = ""
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT Sum(Amount) from Voucher_OtherDetails where Note not in ('Goods and Services Tax','Loan & Advance (Assets)','Fixed Assets') and Date between @f1  And  @f2"
				Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
				Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
				Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
				Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = Me.rdr1.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
					If flag3 Then
						Me.TextBox17.Text = Conversions.ToString(Me.rdr1.GetValue(0))
					End If
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
			Me.TextBox17.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox17.Text), 2), "0.00")
		End Sub

		' Token: 0x0600AEE6 RID: 44774 RVA: 0x0074A81C File Offset: 0x00748A1C
		Private Sub h123()
			Try
				Me.TextBox18.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT Sum(Amount) from AdvanceEntry where Workingdate  between @f1  And  @f2"
				Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
				Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
				Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(1.0)
				Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = Me.rdr1.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
					If flag3 Then
						Me.TextBox18.Text = Conversions.ToString(Me.rdr1.GetValue(0))
					End If
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
			Me.TextBox18.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox18.Text), 2), "0.00")
		End Sub

		' Token: 0x0600AEE7 RID: 44775 RVA: 0x0074A9C4 File Offset: 0x00748BC4
		Private Sub h124()
			Try
				Me.TextBox19.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT Sum(NetPay) from EmployeePayment where Paymentdate  between @f1  And  @f2"
				Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
				Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
				Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(1.0)
				Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = Me.rdr1.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
					If flag3 Then
						Me.TextBox19.Text = Conversions.ToString(Me.rdr1.GetValue(0))
					End If
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
			Me.TextBox19.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox19.Text), 2), "0.00")
		End Sub

		' Token: 0x0600AEE8 RID: 44776 RVA: 0x0074AB6C File Offset: 0x00748D6C
		Private Sub cal1()
			Me.TextBox9.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox6.Text) + Conversion.Val(Me.TextBox7.Text) + Conversion.Val(Me.TextBox8.Text) + Conversion.Val(Me.TextBox20.Text), 2), "0.00")
		End Sub

		' Token: 0x0600AEE9 RID: 44777 RVA: 0x0005152A File Offset: 0x0004F72A
		Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs)
			Me.cal1()
			Me.cal3()
		End Sub

		' Token: 0x0600AEEA RID: 44778 RVA: 0x0074ABE0 File Offset: 0x00748DE0
		Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox6.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox13.Text) - Conversion.Val(Me.TextBox14.Text), 2), "0.00")
			Me.cal1()
		End Sub

		' Token: 0x0600AEEB RID: 44779 RVA: 0x0005153B File Offset: 0x0004F73B
		Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs)
			Me.cal1()
		End Sub

		' Token: 0x0600AEEC RID: 44780 RVA: 0x0074AC38 File Offset: 0x00748E38
		Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox8.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox17.Text) + Conversion.Val(Me.TextBox18.Text) + Conversion.Val(Me.TextBox19.Text), 2), "0.00")
			Me.cal1()
		End Sub

		' Token: 0x0600AEED RID: 44781 RVA: 0x0005153B File Offset: 0x0004F73B
		Private Sub TextBox20_TextChanged(sender As Object, e As EventArgs)
			Me.cal1()
		End Sub

		' Token: 0x0600AEEE RID: 44782 RVA: 0x0074ACA0 File Offset: 0x00748EA0
		Private Sub cal2()
			Me.TextBox10.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox1.Text) + Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox4.Text) + Conversion.Val(Me.TextBox5.Text), 2), "0.00")
		End Sub

		' Token: 0x0600AEEF RID: 44783 RVA: 0x00051545 File Offset: 0x0004F745
		Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs)
			Me.cal2()
			Me.cal3()
		End Sub

		' Token: 0x0600AEF0 RID: 44784 RVA: 0x00051556 File Offset: 0x0004F756
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Me.cal2()
		End Sub

		' Token: 0x0600AEF1 RID: 44785 RVA: 0x0074AD24 File Offset: 0x00748F24
		Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox2.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox15.Text) - Conversion.Val(Me.TextBox16.Text), 2), "0.00")
			Me.cal2()
		End Sub

		' Token: 0x0600AEF2 RID: 44786 RVA: 0x00051556 File Offset: 0x0004F756
		Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)
			Me.cal2()
		End Sub

		' Token: 0x0600AEF3 RID: 44787 RVA: 0x00051556 File Offset: 0x0004F756
		Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)
			Me.cal2()
		End Sub

		' Token: 0x0600AEF4 RID: 44788 RVA: 0x00051556 File Offset: 0x0004F756
		Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs)
			Me.cal2()
		End Sub

		' Token: 0x0600AEF5 RID: 44789 RVA: 0x0074AD7C File Offset: 0x00748F7C
		Private Sub cal3()
			Me.TextBox11.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox10.Text) - Conversion.Val(Me.TextBox9.Text), 2), "0.00")
			Me.TextBox12.Text = Strings.Format(Math.Round(Math.Abs(Conversion.Val(Me.TextBox10.Text) - Conversion.Val(Me.TextBox9.Text)), 2), "0.00")
			Dim flag As Boolean = Conversion.Val(Me.TextBox11.Text) < 0.0
			If flag Then
				Me.Label16.Text = "Net Loss :"
				Me.TextBox12.ForeColor = Color.Red
				Me.TextBox12.BackColor = Color.White
			Else
				Dim flag2 As Boolean = Conversion.Val(Me.TextBox11.Text) > 0.0
				If flag2 Then
					Me.Label16.Text = "Net Profit :"
					Me.TextBox12.ForeColor = Color.Blue
					Me.TextBox12.BackColor = Color.White
				Else
					Dim flag3 As Boolean = Conversion.Val(Me.TextBox11.Text) = 0.0
					If flag3 Then
						Me.Label16.Text = "Profit / Loss :"
						Me.TextBox12.ForeColor = Color.Black
						Me.TextBox12.BackColor = Color.White
					End If
				End If
			End If
		End Sub

		' Token: 0x0600AEF6 RID: 44790 RVA: 0x00051560 File Offset: 0x0004F760
		Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs)
			Me.cal3()
		End Sub

		' Token: 0x0600AEF7 RID: 44791 RVA: 0x00051560 File Offset: 0x0004F760
		Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs)
			Me.cal3()
		End Sub

		' Token: 0x0600AEF8 RID: 44792 RVA: 0x00051560 File Offset: 0x0004F760
		Private Sub Label16_TextChanged(sender As Object, e As EventArgs)
			Me.cal3()
		End Sub

		' Token: 0x0600AEF9 RID: 44793 RVA: 0x0074AF14 File Offset: 0x00749114
		Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox6.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox13.Text) - Conversion.Val(Me.TextBox14.Text), 2), "0.00")
		End Sub

		' Token: 0x0600AEFA RID: 44794 RVA: 0x0074AF14 File Offset: 0x00749114
		Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox6.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox13.Text) - Conversion.Val(Me.TextBox14.Text), 2), "0.00")
		End Sub

		' Token: 0x0600AEFB RID: 44795 RVA: 0x0074AF64 File Offset: 0x00749164
		Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox2.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox15.Text) - Conversion.Val(Me.TextBox16.Text), 2), "0.00")
		End Sub

		' Token: 0x0600AEFC RID: 44796 RVA: 0x0074AF64 File Offset: 0x00749164
		Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox2.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox15.Text) - Conversion.Val(Me.TextBox16.Text), 2), "0.00")
		End Sub

		' Token: 0x0600AEFD RID: 44797 RVA: 0x0074AFB4 File Offset: 0x007491B4
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			Me.PrintPreviewDialog1.Document = Me.PrintDoc1
			Me.PrintDoc1.OriginAtMargins = False
			AddHandler Me.PrintDoc1.PrintPage, AddressOf Me.PDoc_PrintPage
			Me.PrintPreviewDialog1.ShowDialog()
		End Sub

		' Token: 0x0600AEFE RID: 44798 RVA: 0x006F3C90 File Offset: 0x006F1E90
		Private Sub PDoc_PrintPage(sender As Object, e As PrintPageEventArgs)
			Dim bitmap As Bitmap = New Bitmap(MyBase.Width, MyBase.Height)
			MyBase.DrawToBitmap(bitmap, New Rectangle(0, 0, bitmap.Width, bitmap.Height))
			Dim flag As Boolean = (MyBase.Width > 700) Or (MyBase.Height > 1100)
			If flag Then
				Dim bitmap2 As Bitmap = New Bitmap(bitmap)
				Dim num As Integer = CInt(Math.Round(700.0 * CDbl(MyBase.Height) / CDbl(MyBase.Width)))
				Dim bitmap3 As Bitmap = New Bitmap(bitmap2, 700, num)
				e.Graphics.DrawImage(bitmap3, 50, 50)
			Else
				e.Graphics.DrawImage(bitmap, 50, 50)
			End If
		End Sub

		' Token: 0x0600AEFF RID: 44799 RVA: 0x0074B008 File Offset: 0x00749208
		Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox8.Text = Conversions.ToString(Conversion.Val(Me.TextBox17.Text) + Conversion.Val(Me.TextBox18.Text) + Conversion.Val(Me.TextBox19.Text))
		End Sub

		' Token: 0x0600AF00 RID: 44800 RVA: 0x0074B008 File Offset: 0x00749208
		Private Sub TextBox18_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox8.Text = Conversions.ToString(Conversion.Val(Me.TextBox17.Text) + Conversion.Val(Me.TextBox18.Text) + Conversion.Val(Me.TextBox19.Text))
		End Sub

		' Token: 0x0600AF01 RID: 44801 RVA: 0x0074B008 File Offset: 0x00749208
		Private Sub TextBox19_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox8.Text = Conversions.ToString(Conversion.Val(Me.TextBox17.Text) + Conversion.Val(Me.TextBox18.Text) + Conversion.Val(Me.TextBox19.Text))
		End Sub

		' Token: 0x0600AF02 RID: 44802 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmProfitloss_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600AF03 RID: 44803 RVA: 0x0074B05C File Offset: 0x0074925C
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.Clear()
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Opening Stock", New Object() { Me.TextBox20.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Purchase", New Object() { Me.TextBox6.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Sales Return", New Object() { Me.TextBox7.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Express", New Object() { Me.TextBox8.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Sales", New Object() { Me.TextBox1.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Purchse Return", New Object() { Me.TextBox2.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Service Advance", New Object() { Me.TextBox3.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Service Bill", New Object() { Me.TextBox4.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Income", New Object() { Me.TextBox5.Text })
			MyProject.Forms.frmChat1.ShowDialog()
		End Sub

		' Token: 0x0600AF04 RID: 44804 RVA: 0x0074B2F8 File Offset: 0x007494F8
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Me.OPS()
			Me.a1()
			Me.b1()
			Me.c1()
			Me.d1()
			Me.e1()
			Me.f1()
			Me.g1()
			Me.h1()
			Me.h123()
			Me.h124()
			Me.frtn1()
			Me.bpr1()
		End Sub

		' Token: 0x0600AF05 RID: 44805 RVA: 0x0074B364 File Offset: 0x00749564
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.fyear()
			Me.DateTimePicker2.Value = DateAndTime.Today
			Me.OPS()
			Me.a1()
			Me.b1()
			Me.c1()
			Me.d1()
			Me.e1()
			Me.f1()
			Me.g1()
			Me.h1()
			Me.h123()
			Me.h124()
			Me.frtn1()
			Me.bpr1()
		End Sub

		' Token: 0x0600AF06 RID: 44806 RVA: 0x0005156A File Offset: 0x0004F76A
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBIllwise_ProfitReport.ShowDialog()
		End Sub

		' Token: 0x04004921 RID: 18721
		Private cmdimg As SqlCommand

		' Token: 0x04004922 RID: 18722
		Private rdr1 As SqlDataReader

		' Token: 0x04004923 RID: 18723
		Private exp1 As Double

		' Token: 0x04004924 RID: 18724
		Private exp2 As Double

		' Token: 0x04004925 RID: 18725
		Private exp3 As Double

		' Token: 0x04004926 RID: 18726
		Private PrintDoc1 As PrintDocument

		' Token: 0x04004927 RID: 18727
		Private PrintPreviewDialog1 As PrintPreviewDialog
	End Class
End Namespace
