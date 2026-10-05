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
Imports BillPoint.My
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020001FD RID: 509
	<DesignerGenerated()>
	Public Partial Class frmStock_TransferRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06009295 RID: 37525 RVA: 0x00047BCB File Offset: 0x00045DCB
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalesInvoiceRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700365A RID: 13914
		' (get) Token: 0x06009298 RID: 37528 RVA: 0x00047BFD File Offset: 0x00045DFD
		' (set) Token: 0x06009299 RID: 37529 RVA: 0x00047C07 File Offset: 0x00045E07
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700365B RID: 13915
		' (get) Token: 0x0600929A RID: 37530 RVA: 0x00047C10 File Offset: 0x00045E10
		' (set) Token: 0x0600929B RID: 37531 RVA: 0x00047C1A File Offset: 0x00045E1A
		Friend Overridable Property Panel5 As Panel

		' Token: 0x1700365C RID: 13916
		' (get) Token: 0x0600929C RID: 37532 RVA: 0x00047C23 File Offset: 0x00045E23
		' (set) Token: 0x0600929D RID: 37533 RVA: 0x00047C2D File Offset: 0x00045E2D
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x1700365D RID: 13917
		' (get) Token: 0x0600929E RID: 37534 RVA: 0x00047C36 File Offset: 0x00045E36
		' (set) Token: 0x0600929F RID: 37535 RVA: 0x00047C40 File Offset: 0x00045E40
		Friend Overridable Property Label2 As Label

		' Token: 0x1700365E RID: 13918
		' (get) Token: 0x060092A0 RID: 37536 RVA: 0x00047C49 File Offset: 0x00045E49
		' (set) Token: 0x060092A1 RID: 37537 RVA: 0x00047C53 File Offset: 0x00045E53
		Friend Overridable Property Label4 As Label

		' Token: 0x1700365F RID: 13919
		' (get) Token: 0x060092A2 RID: 37538 RVA: 0x00047C5C File Offset: 0x00045E5C
		' (set) Token: 0x060092A3 RID: 37539 RVA: 0x00047C66 File Offset: 0x00045E66
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17003660 RID: 13920
		' (get) Token: 0x060092A4 RID: 37540 RVA: 0x00047C6F File Offset: 0x00045E6F
		' (set) Token: 0x060092A5 RID: 37541 RVA: 0x00047C79 File Offset: 0x00045E79
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17003661 RID: 13921
		' (get) Token: 0x060092A6 RID: 37542 RVA: 0x00047C82 File Offset: 0x00045E82
		' (set) Token: 0x060092A7 RID: 37543 RVA: 0x00047C8C File Offset: 0x00045E8C
		Friend Overridable Property lblSet As Label

		' Token: 0x17003662 RID: 13922
		' (get) Token: 0x060092A8 RID: 37544 RVA: 0x00047C95 File Offset: 0x00045E95
		' (set) Token: 0x060092A9 RID: 37545 RVA: 0x00047C9F File Offset: 0x00045E9F
		Friend Overridable Property Label1 As Label

		' Token: 0x17003663 RID: 13923
		' (get) Token: 0x060092AA RID: 37546 RVA: 0x00047CA8 File Offset: 0x00045EA8
		' (set) Token: 0x060092AB RID: 37547 RVA: 0x00047CB2 File Offset: 0x00045EB2
		Friend Overridable Property lblUserType As Label

		' Token: 0x17003664 RID: 13924
		' (get) Token: 0x060092AC RID: 37548 RVA: 0x00047CBB File Offset: 0x00045EBB
		' (set) Token: 0x060092AD RID: 37549 RVA: 0x00047CC5 File Offset: 0x00045EC5
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17003665 RID: 13925
		' (get) Token: 0x060092AE RID: 37550 RVA: 0x00047CCE File Offset: 0x00045ECE
		' (set) Token: 0x060092AF RID: 37551 RVA: 0x00047CD8 File Offset: 0x00045ED8
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x17003666 RID: 13926
		' (get) Token: 0x060092B0 RID: 37552 RVA: 0x00047CE1 File Offset: 0x00045EE1
		' (set) Token: 0x060092B1 RID: 37553 RVA: 0x00047CEB File Offset: 0x00045EEB
		Friend Overridable Property Label13 As Label

		' Token: 0x17003667 RID: 13927
		' (get) Token: 0x060092B2 RID: 37554 RVA: 0x00047CF4 File Offset: 0x00045EF4
		' (set) Token: 0x060092B3 RID: 37555 RVA: 0x00047CFE File Offset: 0x00045EFE
		Friend Overridable Property Label12 As Label

		' Token: 0x17003668 RID: 13928
		' (get) Token: 0x060092B4 RID: 37556 RVA: 0x00047D07 File Offset: 0x00045F07
		' (set) Token: 0x060092B5 RID: 37557 RVA: 0x00047D11 File Offset: 0x00045F11
		Friend Overridable Property Label11 As Label

		' Token: 0x17003669 RID: 13929
		' (get) Token: 0x060092B6 RID: 37558 RVA: 0x00047D1A File Offset: 0x00045F1A
		' (set) Token: 0x060092B7 RID: 37559 RVA: 0x00047D24 File Offset: 0x00045F24
		Friend Overridable Property Label16 As Label

		' Token: 0x1700366A RID: 13930
		' (get) Token: 0x060092B8 RID: 37560 RVA: 0x00047D2D File Offset: 0x00045F2D
		' (set) Token: 0x060092B9 RID: 37561 RVA: 0x00047D37 File Offset: 0x00045F37
		Friend Overridable Property Label15 As Label

		' Token: 0x1700366B RID: 13931
		' (get) Token: 0x060092BA RID: 37562 RVA: 0x00047D40 File Offset: 0x00045F40
		' (set) Token: 0x060092BB RID: 37563 RVA: 0x00047D4A File Offset: 0x00045F4A
		Friend Overridable Property Label14 As Label

		' Token: 0x1700366C RID: 13932
		' (get) Token: 0x060092BC RID: 37564 RVA: 0x00047D53 File Offset: 0x00045F53
		' (set) Token: 0x060092BD RID: 37565 RVA: 0x00047D5D File Offset: 0x00045F5D
		Friend Overridable Property Label18 As Label

		' Token: 0x1700366D RID: 13933
		' (get) Token: 0x060092BE RID: 37566 RVA: 0x00047D66 File Offset: 0x00045F66
		' (set) Token: 0x060092BF RID: 37567 RVA: 0x00047D70 File Offset: 0x00045F70
		Friend Overridable Property Label17 As Label

		' Token: 0x1700366E RID: 13934
		' (get) Token: 0x060092C0 RID: 37568 RVA: 0x00047D79 File Offset: 0x00045F79
		' (set) Token: 0x060092C1 RID: 37569 RVA: 0x00047D83 File Offset: 0x00045F83
		Friend Overridable Property Label20 As Label

		' Token: 0x1700366F RID: 13935
		' (get) Token: 0x060092C2 RID: 37570 RVA: 0x00047D8C File Offset: 0x00045F8C
		' (set) Token: 0x060092C3 RID: 37571 RVA: 0x00047D96 File Offset: 0x00045F96
		Friend Overridable Property Label19 As Label

		' Token: 0x17003670 RID: 13936
		' (get) Token: 0x060092C4 RID: 37572 RVA: 0x00047D9F File Offset: 0x00045F9F
		' (set) Token: 0x060092C5 RID: 37573 RVA: 0x006A678C File Offset: 0x006A498C
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

		' Token: 0x17003671 RID: 13937
		' (get) Token: 0x060092C6 RID: 37574 RVA: 0x00047DA9 File Offset: 0x00045FA9
		' (set) Token: 0x060092C7 RID: 37575 RVA: 0x006A67D0 File Offset: 0x006A49D0
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

		' Token: 0x17003672 RID: 13938
		' (get) Token: 0x060092C8 RID: 37576 RVA: 0x00047DB3 File Offset: 0x00045FB3
		' (set) Token: 0x060092C9 RID: 37577 RVA: 0x006A6814 File Offset: 0x006A4A14
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

		' Token: 0x17003673 RID: 13939
		' (get) Token: 0x060092CA RID: 37578 RVA: 0x00047DBD File Offset: 0x00045FBD
		' (set) Token: 0x060092CB RID: 37579 RVA: 0x006A6858 File Offset: 0x006A4A58
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

		' Token: 0x17003674 RID: 13940
		' (get) Token: 0x060092CC RID: 37580 RVA: 0x00047DC7 File Offset: 0x00045FC7
		' (set) Token: 0x060092CD RID: 37581 RVA: 0x006A689C File Offset: 0x006A4A9C
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw_KeyDown
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellContentClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003675 RID: 13941
		' (get) Token: 0x060092CE RID: 37582 RVA: 0x00047DD1 File Offset: 0x00045FD1
		' (set) Token: 0x060092CF RID: 37583 RVA: 0x00047DDB File Offset: 0x00045FDB
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x17003676 RID: 13942
		' (get) Token: 0x060092D0 RID: 37584 RVA: 0x00047DE4 File Offset: 0x00045FE4
		' (set) Token: 0x060092D1 RID: 37585 RVA: 0x00047DEE File Offset: 0x00045FEE
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x17003677 RID: 13943
		' (get) Token: 0x060092D2 RID: 37586 RVA: 0x00047DF7 File Offset: 0x00045FF7
		' (set) Token: 0x060092D3 RID: 37587 RVA: 0x00047E01 File Offset: 0x00046001
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17003678 RID: 13944
		' (get) Token: 0x060092D4 RID: 37588 RVA: 0x00047E0A File Offset: 0x0004600A
		' (set) Token: 0x060092D5 RID: 37589 RVA: 0x00047E14 File Offset: 0x00046014
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17003679 RID: 13945
		' (get) Token: 0x060092D6 RID: 37590 RVA: 0x00047E1D File Offset: 0x0004601D
		' (set) Token: 0x060092D7 RID: 37591 RVA: 0x00047E27 File Offset: 0x00046027
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x1700367A RID: 13946
		' (get) Token: 0x060092D8 RID: 37592 RVA: 0x00047E30 File Offset: 0x00046030
		' (set) Token: 0x060092D9 RID: 37593 RVA: 0x00047E3A File Offset: 0x0004603A
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700367B RID: 13947
		' (get) Token: 0x060092DA RID: 37594 RVA: 0x00047E43 File Offset: 0x00046043
		' (set) Token: 0x060092DB RID: 37595 RVA: 0x00047E4D File Offset: 0x0004604D
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700367C RID: 13948
		' (get) Token: 0x060092DC RID: 37596 RVA: 0x00047E56 File Offset: 0x00046056
		' (set) Token: 0x060092DD RID: 37597 RVA: 0x00047E60 File Offset: 0x00046060
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x1700367D RID: 13949
		' (get) Token: 0x060092DE RID: 37598 RVA: 0x00047E69 File Offset: 0x00046069
		' (set) Token: 0x060092DF RID: 37599 RVA: 0x00047E73 File Offset: 0x00046073
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x1700367E RID: 13950
		' (get) Token: 0x060092E0 RID: 37600 RVA: 0x00047E7C File Offset: 0x0004607C
		' (set) Token: 0x060092E1 RID: 37601 RVA: 0x00047E86 File Offset: 0x00046086
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x1700367F RID: 13951
		' (get) Token: 0x060092E2 RID: 37602 RVA: 0x00047E8F File Offset: 0x0004608F
		' (set) Token: 0x060092E3 RID: 37603 RVA: 0x00047E99 File Offset: 0x00046099
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17003680 RID: 13952
		' (get) Token: 0x060092E4 RID: 37604 RVA: 0x00047EA2 File Offset: 0x000460A2
		' (set) Token: 0x060092E5 RID: 37605 RVA: 0x00047EAC File Offset: 0x000460AC
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17003681 RID: 13953
		' (get) Token: 0x060092E6 RID: 37606 RVA: 0x00047EB5 File Offset: 0x000460B5
		' (set) Token: 0x060092E7 RID: 37607 RVA: 0x00047EBF File Offset: 0x000460BF
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17003682 RID: 13954
		' (get) Token: 0x060092E8 RID: 37608 RVA: 0x00047EC8 File Offset: 0x000460C8
		' (set) Token: 0x060092E9 RID: 37609 RVA: 0x00047ED2 File Offset: 0x000460D2
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17003683 RID: 13955
		' (get) Token: 0x060092EA RID: 37610 RVA: 0x00047EDB File Offset: 0x000460DB
		' (set) Token: 0x060092EB RID: 37611 RVA: 0x00047EE5 File Offset: 0x000460E5
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17003684 RID: 13956
		' (get) Token: 0x060092EC RID: 37612 RVA: 0x00047EEE File Offset: 0x000460EE
		' (set) Token: 0x060092ED RID: 37613 RVA: 0x00047EF8 File Offset: 0x000460F8
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17003685 RID: 13957
		' (get) Token: 0x060092EE RID: 37614 RVA: 0x00047F01 File Offset: 0x00046101
		' (set) Token: 0x060092EF RID: 37615 RVA: 0x00047F0B File Offset: 0x0004610B
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17003686 RID: 13958
		' (get) Token: 0x060092F0 RID: 37616 RVA: 0x00047F14 File Offset: 0x00046114
		' (set) Token: 0x060092F1 RID: 37617 RVA: 0x00047F1E File Offset: 0x0004611E
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17003687 RID: 13959
		' (get) Token: 0x060092F2 RID: 37618 RVA: 0x00047F27 File Offset: 0x00046127
		' (set) Token: 0x060092F3 RID: 37619 RVA: 0x00047F31 File Offset: 0x00046131
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17003688 RID: 13960
		' (get) Token: 0x060092F4 RID: 37620 RVA: 0x00047F3A File Offset: 0x0004613A
		' (set) Token: 0x060092F5 RID: 37621 RVA: 0x00047F44 File Offset: 0x00046144
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17003689 RID: 13961
		' (get) Token: 0x060092F6 RID: 37622 RVA: 0x00047F4D File Offset: 0x0004614D
		' (set) Token: 0x060092F7 RID: 37623 RVA: 0x00047F57 File Offset: 0x00046157
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x1700368A RID: 13962
		' (get) Token: 0x060092F8 RID: 37624 RVA: 0x00047F60 File Offset: 0x00046160
		' (set) Token: 0x060092F9 RID: 37625 RVA: 0x00047F6A File Offset: 0x0004616A
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x1700368B RID: 13963
		' (get) Token: 0x060092FA RID: 37626 RVA: 0x00047F73 File Offset: 0x00046173
		' (set) Token: 0x060092FB RID: 37627 RVA: 0x00047F7D File Offset: 0x0004617D
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700368C RID: 13964
		' (get) Token: 0x060092FC RID: 37628 RVA: 0x00047F86 File Offset: 0x00046186
		' (set) Token: 0x060092FD RID: 37629 RVA: 0x00047F90 File Offset: 0x00046190
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x1700368D RID: 13965
		' (get) Token: 0x060092FE RID: 37630 RVA: 0x00047F99 File Offset: 0x00046199
		' (set) Token: 0x060092FF RID: 37631 RVA: 0x00047FA3 File Offset: 0x000461A3
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x1700368E RID: 13966
		' (get) Token: 0x06009300 RID: 37632 RVA: 0x00047FAC File Offset: 0x000461AC
		' (set) Token: 0x06009301 RID: 37633 RVA: 0x00047FB6 File Offset: 0x000461B6
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x1700368F RID: 13967
		' (get) Token: 0x06009302 RID: 37634 RVA: 0x00047FBF File Offset: 0x000461BF
		' (set) Token: 0x06009303 RID: 37635 RVA: 0x00047FC9 File Offset: 0x000461C9
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17003690 RID: 13968
		' (get) Token: 0x06009304 RID: 37636 RVA: 0x00047FD2 File Offset: 0x000461D2
		' (set) Token: 0x06009305 RID: 37637 RVA: 0x00047FDC File Offset: 0x000461DC
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17003691 RID: 13969
		' (get) Token: 0x06009306 RID: 37638 RVA: 0x00047FE5 File Offset: 0x000461E5
		' (set) Token: 0x06009307 RID: 37639 RVA: 0x00047FEF File Offset: 0x000461EF
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17003692 RID: 13970
		' (get) Token: 0x06009308 RID: 37640 RVA: 0x00047FF8 File Offset: 0x000461F8
		' (set) Token: 0x06009309 RID: 37641 RVA: 0x00048002 File Offset: 0x00046202
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17003693 RID: 13971
		' (get) Token: 0x0600930A RID: 37642 RVA: 0x0004800B File Offset: 0x0004620B
		' (set) Token: 0x0600930B RID: 37643 RVA: 0x00048015 File Offset: 0x00046215
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17003694 RID: 13972
		' (get) Token: 0x0600930C RID: 37644 RVA: 0x0004801E File Offset: 0x0004621E
		' (set) Token: 0x0600930D RID: 37645 RVA: 0x00048028 File Offset: 0x00046228
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17003695 RID: 13973
		' (get) Token: 0x0600930E RID: 37646 RVA: 0x00048031 File Offset: 0x00046231
		' (set) Token: 0x0600930F RID: 37647 RVA: 0x0004803B File Offset: 0x0004623B
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x17003696 RID: 13974
		' (get) Token: 0x06009310 RID: 37648 RVA: 0x00048044 File Offset: 0x00046244
		' (set) Token: 0x06009311 RID: 37649 RVA: 0x0004804E File Offset: 0x0004624E
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x17003697 RID: 13975
		' (get) Token: 0x06009312 RID: 37650 RVA: 0x00048057 File Offset: 0x00046257
		' (set) Token: 0x06009313 RID: 37651 RVA: 0x00048061 File Offset: 0x00046261
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x17003698 RID: 13976
		' (get) Token: 0x06009314 RID: 37652 RVA: 0x0004806A File Offset: 0x0004626A
		' (set) Token: 0x06009315 RID: 37653 RVA: 0x00048074 File Offset: 0x00046274
		Friend Overridable Property Column36 As DataGridViewTextBoxColumn

		' Token: 0x17003699 RID: 13977
		' (get) Token: 0x06009316 RID: 37654 RVA: 0x0004807D File Offset: 0x0004627D
		' (set) Token: 0x06009317 RID: 37655 RVA: 0x00048087 File Offset: 0x00046287
		Friend Overridable Property Column37 As DataGridViewTextBoxColumn

		' Token: 0x1700369A RID: 13978
		' (get) Token: 0x06009318 RID: 37656 RVA: 0x00048090 File Offset: 0x00046290
		' (set) Token: 0x06009319 RID: 37657 RVA: 0x0004809A File Offset: 0x0004629A
		Friend Overridable Property Column38 As DataGridViewTextBoxColumn

		' Token: 0x1700369B RID: 13979
		' (get) Token: 0x0600931A RID: 37658 RVA: 0x000480A3 File Offset: 0x000462A3
		' (set) Token: 0x0600931B RID: 37659 RVA: 0x000480AD File Offset: 0x000462AD
		Friend Overridable Property Column39 As DataGridViewTextBoxColumn

		' Token: 0x1700369C RID: 13980
		' (get) Token: 0x0600931C RID: 37660 RVA: 0x000480B6 File Offset: 0x000462B6
		' (set) Token: 0x0600931D RID: 37661 RVA: 0x000480C0 File Offset: 0x000462C0
		Friend Overridable Property Column40 As DataGridViewTextBoxColumn

		' Token: 0x1700369D RID: 13981
		' (get) Token: 0x0600931E RID: 37662 RVA: 0x000480C9 File Offset: 0x000462C9
		' (set) Token: 0x0600931F RID: 37663 RVA: 0x000480D3 File Offset: 0x000462D3
		Friend Overridable Property Column41 As DataGridViewTextBoxColumn

		' Token: 0x1700369E RID: 13982
		' (get) Token: 0x06009320 RID: 37664 RVA: 0x000480DC File Offset: 0x000462DC
		' (set) Token: 0x06009321 RID: 37665 RVA: 0x000480E6 File Offset: 0x000462E6
		Friend Overridable Property Column42 As DataGridViewTextBoxColumn

		' Token: 0x1700369F RID: 13983
		' (get) Token: 0x06009322 RID: 37666 RVA: 0x000480EF File Offset: 0x000462EF
		' (set) Token: 0x06009323 RID: 37667 RVA: 0x000480F9 File Offset: 0x000462F9
		Friend Overridable Property Column43 As DataGridViewTextBoxColumn

		' Token: 0x170036A0 RID: 13984
		' (get) Token: 0x06009324 RID: 37668 RVA: 0x00048102 File Offset: 0x00046302
		' (set) Token: 0x06009325 RID: 37669 RVA: 0x0004810C File Offset: 0x0004630C
		Friend Overridable Property Column44 As DataGridViewTextBoxColumn

		' Token: 0x170036A1 RID: 13985
		' (get) Token: 0x06009326 RID: 37670 RVA: 0x00048115 File Offset: 0x00046315
		' (set) Token: 0x06009327 RID: 37671 RVA: 0x0004811F File Offset: 0x0004631F
		Friend Overridable Property Column45 As DataGridViewTextBoxColumn

		' Token: 0x170036A2 RID: 13986
		' (get) Token: 0x06009328 RID: 37672 RVA: 0x00048128 File Offset: 0x00046328
		' (set) Token: 0x06009329 RID: 37673 RVA: 0x00048132 File Offset: 0x00046332
		Friend Overridable Property Column46 As DataGridViewTextBoxColumn

		' Token: 0x170036A3 RID: 13987
		' (get) Token: 0x0600932A RID: 37674 RVA: 0x0004813B File Offset: 0x0004633B
		' (set) Token: 0x0600932B RID: 37675 RVA: 0x00048145 File Offset: 0x00046345
		Friend Overridable Property Column49 As DataGridViewTextBoxColumn

		' Token: 0x170036A4 RID: 13988
		' (get) Token: 0x0600932C RID: 37676 RVA: 0x0004814E File Offset: 0x0004634E
		' (set) Token: 0x0600932D RID: 37677 RVA: 0x00048158 File Offset: 0x00046358
		Friend Overridable Property Column50 As DataGridViewTextBoxColumn

		' Token: 0x170036A5 RID: 13989
		' (get) Token: 0x0600932E RID: 37678 RVA: 0x00048161 File Offset: 0x00046361
		' (set) Token: 0x0600932F RID: 37679 RVA: 0x0004816B File Offset: 0x0004636B
		Friend Overridable Property Column51 As DataGridViewTextBoxColumn

		' Token: 0x170036A6 RID: 13990
		' (get) Token: 0x06009330 RID: 37680 RVA: 0x00048174 File Offset: 0x00046374
		' (set) Token: 0x06009331 RID: 37681 RVA: 0x0004817E File Offset: 0x0004637E
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170036A7 RID: 13991
		' (get) Token: 0x06009332 RID: 37682 RVA: 0x00048187 File Offset: 0x00046387
		' (set) Token: 0x06009333 RID: 37683 RVA: 0x00048191 File Offset: 0x00046391
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170036A8 RID: 13992
		' (get) Token: 0x06009334 RID: 37684 RVA: 0x0004819A File Offset: 0x0004639A
		' (set) Token: 0x06009335 RID: 37685 RVA: 0x000481A4 File Offset: 0x000463A4
		Friend Overridable Property btnTransfer_Online As DataGridViewButtonColumn

		' Token: 0x170036A9 RID: 13993
		' (get) Token: 0x06009336 RID: 37686 RVA: 0x000481AD File Offset: 0x000463AD
		' (set) Token: 0x06009337 RID: 37687 RVA: 0x000481B7 File Offset: 0x000463B7
		Friend Overridable Property lblFrom_Company_id As Label

		' Token: 0x170036AA RID: 13994
		' (get) Token: 0x06009338 RID: 37688 RVA: 0x000481C0 File Offset: 0x000463C0
		' (set) Token: 0x06009339 RID: 37689 RVA: 0x000481CA File Offset: 0x000463CA
		Friend Overridable Property lblUser As Label

		' Token: 0x0600933A RID: 37690 RVA: 0x006A68FC File Offset: 0x006A4AFC
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
					Me.dtpDateTo.Value = DateAndTime.Today
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

		' Token: 0x0600933B RID: 37691 RVA: 0x006A69E0 File Offset: 0x006A4BE0
		Public Sub Getdata(from_companyid As String)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, InvoiceInfo_StockTransfer.CGST, InvoiceInfo_StockTransfer.SGST, InvoiceInfo_StockTransfer.IGST, InvoiceInfo_StockTransfer.CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo_StockTransfer.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt," & vbCrLf & "'' as Barcode," & vbCrLf & "    '' as ProductName," & vbCrLf & "    0 as Qty," & vbCrLf & "    InvoiceInfo_StockTransfer.from_company_id," & vbCrLf & "    InvoiceInfo_StockTransfer.to_company_id," & vbCrLf & "    RTRIM(y.CompanyName) AS CompanyName, CASE " & vbCrLf & "        WHEN InvoiceInfo_StockTransfer.status = 0 THEN 'Pending'" & vbCrLf & "        ELSE 'Transfer'" & vbCrLf & "    END AS StatusText" & vbCrLf & "from InvoiceInfo_StockTransfer " & vbCrLf & "LEFT Join Customer ON InvoiceInfo_StockTransfer.Customer_ID = Customer.ID " & vbCrLf & "Left Join Salesman ON InvoiceInfo_StockTransfer.SalesmanID=Salesman.SM_ID " & vbCrLf & vbCrLf & "LEFT JOIN Branch_Relation y ON InvoiceInfo_StockTransfer.to_company_id = y.to_company_id " & vbCrLf & "where InvoiceInfo_StockTransfer.from_company_id=@d0 and InvoiceDate between @d1 and @d2 order by InvoiceDate"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime).Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime).Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d0", SqlDbType.NVarChar).Value = from_companyid
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr("Inv_ID"))
					Dim text2 As String = ModCommonClasses.rdr("ProductName").ToString() + " (" + ModCommonClasses.rdr("Barcode").ToString() + ")"
					Dim text3 As String = ModCommonClasses.rdr("CompanyName").ToString() + " (" + ModCommonClasses.rdr("to_company_id").ToString() + ")"
					Dim num As Decimal = Conversions.ToDecimal(ModCommonClasses.rdr("Qty"))
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), text2, num, text3, ModCommonClasses.rdr("to_company_id").ToString(), ModCommonClasses.rdr("StatusText").ToString() })
					Dim num2 As Integer = Me.dgw.Rows.Count - 1
					Dim flag As Boolean = Operators.CompareString(ModCommonClasses.rdr("StatusText").ToString().Trim().ToUpper(), "TRANSFER", False) = 0
					If flag Then
						Me.dgw.Rows(num2).DefaultCellStyle.BackColor = Color.Red
						Dim dataGridViewTextBoxCell As DataGridViewTextBoxCell = New DataGridViewTextBoxCell()
						dataGridViewTextBoxCell.Value = ""
						Me.dgw.Rows(num2).Cells("btnTransfer_Online") = dataGridViewTextBoxCell
					End If
				End While
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
			End Try
		End Sub

		' Token: 0x0600933C RID: 37692 RVA: 0x006A6FE0 File Offset: 0x006A51E0
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata(Me.lblFrom_Company_id.Text)
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600933D RID: 37693 RVA: 0x006A707C File Offset: 0x006A527C
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

		' Token: 0x0600933E RID: 37694 RVA: 0x006A71F4 File Offset: 0x006A53F4
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

		' Token: 0x0600933F RID: 37695 RVA: 0x006A72C0 File Offset: 0x006A54C0
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

		' Token: 0x06009340 RID: 37696 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06009341 RID: 37697 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06009342 RID: 37698 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06009343 RID: 37699 RVA: 0x006A738C File Offset: 0x006A558C
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x06009344 RID: 37700 RVA: 0x006A73B4 File Offset: 0x006A55B4
		Public Sub RetrieveData()
			Dim flag As Boolean = Operators.CompareString(Me.lblSet.Text, "transfer", False) = 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				MyProject.Forms.frmPOSNewTuch_StockTransfer.Show()
				MyBase.Hide()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtInvoiceNo.Text = dataGridViewRow.Cells(1).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.dtpInvoiceDate.Text = dataGridViewRow.Cells(2).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtGSTNonGST.Text = dataGridViewRow.Cells(3).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.TextBox7.Text = dataGridViewRow.Cells(3).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtCustomerID.Text = dataGridViewRow.Cells(5).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.Label202.Text = dataGridViewRow.Cells(5).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtCID.Text = dataGridViewRow.Cells(4).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.cmbCustomerName.Text = dataGridViewRow.Cells(6).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
				Dim flag2 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch_StockTransfer.cmbCustomerName.Text.Trim(), "Cash", False) = 0
				If flag2 Then
					MyProject.Forms.frmPOSNewTuch_StockTransfer.cmbCustomerState.Text = MyProject.Forms.frmPOSNewTuch_StockTransfer.txtCompanyState.Text
				Else
					MyProject.Forms.frmPOSNewTuch_StockTransfer.cmbCustomerState.Text = dataGridViewRow.Cells(8).Value.ToString()
				End If
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtSM_ID.Text = dataGridViewRow.Cells(10).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtSalesmanID.Text = dataGridViewRow.Cells(11).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtSalesman.Text = dataGridViewRow.Cells(12).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtSubTotal.Text = dataGridViewRow.Cells(13).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtCGST.Text = dataGridViewRow.Cells(14).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtSGST.Text = dataGridViewRow.Cells(15).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtIGST.Text = dataGridViewRow.Cells(16).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtCESS.Text = dataGridViewRow.Cells(17).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtFreightCharges.Text = dataGridViewRow.Cells(18).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtBillDiscount.Text = dataGridViewRow.Cells(19).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtTotal.Text = dataGridViewRow.Cells(20).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtRoundOff.Text = dataGridViewRow.Cells(21).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtGrandTotal.Text = dataGridViewRow.Cells(22).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtTotalPayment.Text = dataGridViewRow.Cells(23).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtPaymentDue.Text = dataGridViewRow.Cells(24).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtNar.Text = dataGridViewRow.Cells(26).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txteway.Text = dataGridViewRow.Cells(27).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.cmbBSundry.Text = dataGridViewRow.Cells(30).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtOffer.Text = dataGridViewRow.Cells(31).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtApplyPoint.Text = dataGridViewRow.Cells(32).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtLAmt.Text = dataGridViewRow.Cells(32).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtbilldisc.Text = dataGridViewRow.Cells(33).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtTCSdbl.Text = dataGridViewRow.Cells(18).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtTendAmt.Text = dataGridViewRow.Cells(35).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtRefAmt.Text = dataGridViewRow.Cells(36).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtBillAmt.Text = dataGridViewRow.Cells(37).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.CAddress = dataGridViewRow.Cells(40).Value.ToString()
				Dim flag3 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(32).Value, 0, False)
				If flag3 Then
					MyProject.Forms.frmPOSNewTuch_StockTransfer.cb1.Checked = True
				Else
					MyProject.Forms.frmPOSNewTuch_StockTransfer.cb1.Checked = False
				End If
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtCoupAmt.Text = dataGridViewRow.Cells(38).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtgiftamt.Text = dataGridViewRow.Cells(39).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtByReturn.Text = dataGridViewRow.Cells(42).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtTotalLoyality_points.Text = dataGridViewRow.Cells(43).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.lblTPoints1.Text = dataGridViewRow.Cells(44).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.lblTPointsAmt1.Text = dataGridViewRow.Cells(45).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.TextBox43.Text = dataGridViewRow.Cells(45).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.cmbToCompany.SelectedValue = dataGridViewRow.Cells(49).Value.ToString()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.btnSave.Enabled = False
				MyProject.Forms.frmPOSNewTuch_StockTransfer.btnPrint.Enabled = True
				MyProject.Forms.frmPOSNewTuch_StockTransfer.Button5.Enabled = True
				MyProject.Forms.frmPOSNewTuch_StockTransfer.Button6.Enabled = True
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtOffer.Text = "0.00"
				Dim flag4 As Boolean = (Operators.CompareString(Me.lblUserType.Text, "Admin", False) = 0) Or (Operators.CompareString(Me.lblUserType.Text, "Moderator", False) = 0)
				If flag4 Then
					MyProject.Forms.frmPOSNewTuch_StockTransfer.btnUpdate.Enabled = True
					MyProject.Forms.frmPOSNewTuch_StockTransfer.btnDelete.Enabled = True
				Else
					MyProject.Forms.frmPOSNewTuch_StockTransfer.btnUpdate.Enabled = False
					MyProject.Forms.frmPOSNewTuch_StockTransfer.btnDelete.Enabled = False
				End If
				MyProject.Forms.frmPOSNewTuch_StockTransfer.lblSet.Text = "Not Allowed"
				MyProject.Forms.frmPOSNewTuch_StockTransfer.btnAdd.Enabled = True
				MyProject.Forms.frmPOSNewTuch_StockTransfer.cmbCustomerName.Enabled = False
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtContactNo.[ReadOnly] = True
				MyProject.Forms.frmPOSNewTuch_StockTransfer.cmbCustomerState.Enabled = False
				MyProject.Forms.frmPOSNewTuch_StockTransfer.btnCustomerSelection.Enabled = False
				MyProject.Forms.frmPOSNewTuch_StockTransfer.cmbCustomerName.Enabled = False
				MyProject.Forms.frmPOSNewTuch_StockTransfer.TextBox15.[ReadOnly] = True
				MyProject.Forms.frmPOSNewTuch_StockTransfer.Label82.Enabled = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT " & vbCrLf & "    InvoiceInfo_Product_StockTransfer.ProductID," & vbCrLf & "    RTRIM(Product.HSNCode)," & vbCrLf & "    RTRIM(Product.ProductName)," & vbCrLf & "    RTRIM(InvoiceInfo_Product_StockTransfer.Barcode)," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.Qty," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.SalesRate," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.DiscountPer," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.Discount," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.CGSTPer," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.CGSTAmt," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.SGSTPer," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.SGSTAmt," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.IGSTPer," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.IGSTAmt," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.CESSPer," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.CESSAmt," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.TotalAmount," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.PurchaseRate," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.Margin," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.Descr," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.Qty," & vbCrLf & "    RTRIM(InvoiceInfo_Product_StockTransfer.IM1)," & vbCrLf & "    RTRIM(InvoiceInfo_Product_StockTransfer.IM2)," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.MRP," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.TaxableAmt," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.AltQty," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.AltUnit," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.STaxType," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.TotalMRP," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.PromoQty," & vbCrLf & "    RTRIM(InvoiceInfo_Product_StockTransfer.MainUnit)," & vbCrLf & "    RTRIM(InvoiceInfo_Product_StockTransfer.Batch)," & vbCrLf & "    RTRIM(InvoiceInfo_Product_StockTransfer.Mfg)," & vbCrLf & "    RTRIM(InvoiceInfo_Product_StockTransfer.Exp)," & vbCrLf & "    RTRIM(InvoiceInfo_Product_StockTransfer.Size)," & vbCrLf & "    RTRIM(InvoiceInfo_Product_StockTransfer.Colour)," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.SalesManID," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.SalesMan," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.SalesManPur," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.SalesManComm," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.StockID," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.LoyalityPoints" & vbCrLf & "FROM " & vbCrLf & "    InvoiceInfo_StockTransfer" & vbCrLf & "INNER JOIN " & vbCrLf & "    InvoiceInfo_Product_StockTransfer ON InvoiceInfo_StockTransfer.Inv_ID = InvoiceInfo_Product_StockTransfer.InvoiceID" & vbCrLf & "INNER JOIN " & vbCrLf & "    Product ON Product.PID = InvoiceInfo_Product_StockTransfer.ProductID" & vbCrLf & "WHERE " & vbCrLf & "    InvoiceInfo_StockTransfer.Inv_ID =@d1"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				MyProject.Forms.frmPOSNewTuch_StockTransfer.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					MyProject.Forms.frmPOSNewTuch_StockTransfer.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), "", ModCommonClasses.rdr(40), ModCommonClasses.rdr(41) })
				End While
				MyProject.Forms.frmPOSNewTuch_StockTransfer.DataGridView1.ClearSelection()
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text2 As String = "SELECT " & vbCrLf & "    InvoiceInfo_Product_StockTransfer.ProductID," & vbCrLf & "    RTRIM(Product.HSNCode)," & vbCrLf & "    RTRIM(Product.ProductName)," & vbCrLf & "    RTRIM(InvoiceInfo_Product_StockTransfer.Barcode)," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.Qty," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.SalesRate," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.DiscountPer," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.Discount," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.CGSTPer," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.CGSTAmt," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.SGSTPer," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.SGSTAmt," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.IGSTPer," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.IGSTAmt," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.CESSPer," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.CESSAmt," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.TotalAmount," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.PurchaseRate," & vbCrLf & "    InvoiceInfo_Product_StockTransfer.Margin" & vbCrLf & "FROM " & vbCrLf & "    InvoiceInfo_StockTransfer" & vbCrLf & "INNER JOIN " & vbCrLf & "    InvoiceInfo_Product_StockTransfer " & vbCrLf & "    ON InvoiceInfo_StockTransfer.Inv_ID = InvoiceInfo_Product_StockTransfer.InvoiceID" & vbCrLf & "INNER JOIN " & vbCrLf & "    Product " & vbCrLf & "    ON Product.PID = InvoiceInfo_Product_StockTransfer.ProductID" & vbCrLf & "WHERE " & vbCrLf & "    InvoiceInfo_StockTransfer.Inv_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				MyProject.Forms.frmPOSNewTuch_StockTransfer.DataGridView3.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					MyProject.Forms.frmPOSNewTuch_StockTransfer.DataGridView3.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18) })
				End While
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text3 As String = "SELECT RTRIM(Invoice_Payment.PaymentMode),Invoice_Payment.TotalPaid,PaymentDate,RTRIM(Invoice_Payment.BankAc) from InvoiceInfo,Invoice_Payment where InvoiceInfo.Inv_ID=Invoice_Payment.InvoiceID and InvoiceInfo.Inv_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text3, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				MyProject.Forms.frmPOSNewTuch_StockTransfer.DataGridView2.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					MyProject.Forms.frmPOSNewTuch_StockTransfer.DataGridView2.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
				End While
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text4 As String = "SELECT a.productid AS PID, RTRIM(b.ProductCode) AS Productcode, RTRIM(b.ProductName) AS ProductName, a.barcode AS Barcode, a.serialno" & vbCrLf & "                              FROM tbl_product_serial_sale a" & vbCrLf & "                              INNER JOIN product b ON a.productid = b.pid where a.invoice_no=@d1"
				ModCommonClasses.cmd = New SqlCommand(text4, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				MyProject.Forms.frmPOSNewTuch_StockTransfer.DataGridView5.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					MyProject.Forms.frmPOSNewTuch_StockTransfer.DataGridView5.Visible = True
					MyProject.Forms.frmPOSNewTuch_StockTransfer.DataGridView5.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4) })
				End While
				ModCommonClasses.con.Close()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.CustomerBalance_Loyality()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.Calc()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.Compute()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.alldiscountcalc()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.Bankcondn()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.totitemnqty()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.btnSelectSalesman.Enabled = False
				MyProject.Forms.frmPOSNewTuch_StockTransfer.btnListReset1.PerformClick()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.Calculate12345()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.Calculate143()
				Dim flag5 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch_StockTransfer.cmbBSundry.Text, "TCS", False) = 0
				If flag5 Then
					MyProject.Forms.frmPOSNewTuch_StockTransfer.txtTCSdbl.[ReadOnly] = True
				Else
					MyProject.Forms.frmPOSNewTuch_StockTransfer.txtTCSdbl.[ReadOnly] = True
					MyProject.Forms.frmPOSNewTuch_StockTransfer.txtTCSdbl.Text = "0"
				End If
				MyProject.Forms.frmPOSNewTuch_StockTransfer.CTypeStatus()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.BrokerRetrive()
				MyProject.Forms.frmPOSNewTuch_StockTransfer.CheckBox11.Checked = False
				MyProject.Forms.frmPOSNewTuch_StockTransfer.txtInvoiceNo.[ReadOnly] = True
			End If
		End Sub

		' Token: 0x06009345 RID: 37701 RVA: 0x006A87A0 File Offset: 0x006A69A0
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

		' Token: 0x06009346 RID: 37702 RVA: 0x000481D3 File Offset: 0x000463D3
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.dgw.Rows.Clear()
			Me.Getdata(Me.lblFrom_Company_id.Text)
		End Sub

		' Token: 0x06009347 RID: 37703 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSalesInvoiceRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06009348 RID: 37704 RVA: 0x006A8888 File Offset: 0x006A6A88
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))
						End If

				Next
				Me.lblTotalAmount.Text = Conversions.ToString(num2)
				Dim num3 As Integer = Me.dgw.Rows.Count - 1
				Dim num4 As Double
				For j As Integer = 0 To num3
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(j).Cells("Column32").Value))

						If flag2 Then
							num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(j).Cells("Column32").Value))
						End If

				Next
				Me.Label14.Text = Conversions.ToString(num4)
				Dim num5 As Integer = Me.dgw.Rows.Count - 1
				Dim num6 As Double
				For k As Integer = 0 To num5
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(k).Cells("Column33").Value))

						If flag3 Then
							num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(k).Cells("Column33").Value))
						End If

				Next
				Me.Label15.Text = Conversions.ToString(num6)
				Dim num7 As Integer = Me.dgw.Rows.Count - 1
				Dim num8 As Double
				For l As Integer = 0 To num7
					Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(l).Cells("Column34").Value))

						If flag4 Then
							num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(l).Cells("Column34").Value))
						End If

				Next
				Me.Label16.Text = Conversions.ToString(num8)
				Dim num9 As Integer = Me.dgw.Rows.Count - 1
				Dim num10 As Double
				For m As Integer = 0 To num9
					Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(m).Cells("Column39").Value))

						If flag5 Then
							num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(m).Cells("Column39").Value))
						End If

				Next
				Me.Label18.Text = Conversions.ToString(num10)
				Dim num11 As Integer = Me.dgw.Rows.Count - 1
				Dim num12 As Double
				For n As Integer = 0 To num11
					Dim flag6 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(n).Cells("Column40").Value))

						If flag6 Then
							num12 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(n).Cells("Column40").Value))
						End If

				Next
				Me.Label20.Text = Conversions.ToString(num12)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.lblTotalAmount.Text = "Total : " + Strings.Format(Math.Round(Conversion.Val(Me.lblTotalAmount.Text), 2), "0.00")
			Me.Label14.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label14.Text), 2), "0.00")
			Me.Label15.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label15.Text), 2), "0.00")
			Me.Label16.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label16.Text), 2), "0.00")
			Me.Label18.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label18.Text), 2), "0.00")
			Me.Label20.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label20.Text), 2), "0.00")
		End Sub

		' Token: 0x06009349 RID: 37705 RVA: 0x00048211 File Offset: 0x00046411
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x0600934A RID: 37706 RVA: 0x006A8DEC File Offset: 0x006A6FEC
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

		' Token: 0x0600934B RID: 37707 RVA: 0x006A9098 File Offset: 0x006A7298
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			MyBase.Dispose()
			MyProject.Forms.frmPOSNewTuch_StockTransfer.Dispose()
			MyProject.Forms.frmStock_Inward_Notification.lblSet.Text = "transfer"
			MyProject.Forms.frmStock_Inward_Notification.lblUser.Text = Me.lblUserType.Text
			MyProject.Forms.frmStock_Inward_Notification.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmStock_Inward_Notification.lblFrom_Company_id.Text = Me.lblFrom_Company_id.Text
			MyProject.Forms.frmStock_Inward_Notification.ShowDialog()
		End Sub

		' Token: 0x0600934C RID: 37708 RVA: 0x006A9148 File Offset: 0x006A7348
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, InvoiceInfo_StockTransfer.CGST, InvoiceInfo_StockTransfer.SGST, InvoiceInfo_StockTransfer.IGST, InvoiceInfo_StockTransfer.CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo_StockTransfer.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt," & vbCrLf & "'' as Barcode," & vbCrLf & "    '' as ProductName," & vbCrLf & "    0 as Qty," & vbCrLf & "    InvoiceInfo_StockTransfer.from_company_id," & vbCrLf & "    InvoiceInfo_StockTransfer.to_company_id," & vbCrLf & "    RTRIM(y.CompanyName) AS CompanyName, CASE " & vbCrLf & "        WHEN InvoiceInfo_StockTransfer.status = 0 THEN 'Pending'" & vbCrLf & "        ELSE 'Transfer'" & vbCrLf & "    END AS StatusText" & vbCrLf & "from InvoiceInfo_StockTransfer " & vbCrLf & "LEFT Join Customer ON InvoiceInfo_StockTransfer.Customer_ID = Customer.ID " & vbCrLf & "Left Join Salesman ON InvoiceInfo_StockTransfer.SalesmanID=Salesman.SM_ID " & vbCrLf & vbCrLf & "LEFT JOIN Branch_Relation y ON InvoiceInfo_StockTransfer.to_company_id = y.to_company_id " & vbCrLf & "where InvoiceInfo_StockTransfer.from_company_id=@d0 and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d0", SqlDbType.NVarChar).Value = Me.lblFrom_Company_id.Text
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr("Inv_ID"))
					Dim text As String = ModCommonClasses.rdr("ProductName").ToString() + " (" + ModCommonClasses.rdr("Barcode").ToString() + ")"
					Dim text2 As String = ModCommonClasses.rdr("CompanyName").ToString() + " (" + ModCommonClasses.rdr("to_company_id").ToString() + ")"
					Dim num As Decimal = Conversions.ToDecimal(ModCommonClasses.rdr("Qty"))
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), text, num, text2, ModCommonClasses.rdr("to_company_id").ToString(), ModCommonClasses.rdr("StatusText").ToString() })
					Dim num2 As Integer = Me.dgw.Rows.Count - 1
					Dim flag As Boolean = Operators.CompareString(ModCommonClasses.rdr("StatusText").ToString().Trim().ToUpper(), "TRANSFER", False) = 0
					If flag Then
						Me.dgw.Rows(num2).DefaultCellStyle.BackColor = Color.Red
						Dim dataGridViewTextBoxCell As DataGridViewTextBoxCell = New DataGridViewTextBoxCell()
						dataGridViewTextBoxCell.Value = ""
						Me.dgw.Rows(num2).Cells("btnTransfer_Online") = dataGridViewTextBoxCell
					End If
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600934D RID: 37709 RVA: 0x006A972C File Offset: 0x006A792C
		Private Sub dgw_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.dgw.Columns(e.ColumnIndex).Name, "btnTransfer_Online", False) = 0 AndAlso e.RowIndex >= 0
			If flag Then
				Try
					Dim value As Object = Me.dgw.Rows(e.RowIndex).Cells(0).Value
					Dim text As String = If((value IsNot Nothing), value.ToString().Trim(), Nothing)
					Dim value2 As Object = Me.dgw.Rows(e.RowIndex).Cells(48).Value
					Dim text2 As String = If((value2 IsNot Nothing), value2.ToString().Trim(), Nothing)
					Dim value3 As Object = Me.dgw.Rows(e.RowIndex).Cells(49).Value
					Dim text3 As String = If((value3 IsNot Nothing), value3.ToString().Trim(), Nothing)
					Dim dialogResult As DialogResult = MessageBox.Show("Are you sure you want to transfer '" + text2 + "'?", "To Branch", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
					Dim flag2 As Boolean = dialogResult = DialogResult.Yes
					If flag2 Then
						Me.Transfer_StockOnline(text)
						Me.Getdata(Me.lblFrom_Company_id.Text)
					End If
				Catch ex As Exception
					MessageBox.Show("❌ Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Else
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x0600934E RID: 37710 RVA: 0x006A98B8 File Offset: 0x006A7AB8
		Public Sub Transfer_StockOnline(selectedInv_Id As String)
			Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
			If flag Then
				MessageBox.Show("Please Check your internet connection!")
			Else
				Dim cs As String = ModCS.cs
				Dim text As String = ModCS.RaintechMaster_Online_connection()
				Try
					Dim dataTable As DataTable = New DataTable()
					Dim dataTable2 As DataTable = New DataTable()
					Using sqlConnection As SqlConnection = New SqlConnection(cs)
						sqlConnection.Open()
						Dim sqlCommand As SqlCommand = New SqlCommand("SELECT * FROM InvoiceInfo_StockTransfer WHERE Inv_ID = @InvID", sqlConnection)
						sqlCommand.Parameters.AddWithValue("@InvID", selectedInv_Id)
						Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
							sqlDataAdapter.Fill(dataTable)
						End Using
						Dim sqlCommand2 As SqlCommand = New SqlCommand("SELECT * FROM InvoiceInfo_Product_StockTransfer WHERE InvoiceID = @InvID", sqlConnection)
						sqlCommand2.Parameters.AddWithValue("@InvID", selectedInv_Id)
						Using sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter(sqlCommand2)
							sqlDataAdapter2.Fill(dataTable2)
						End Using
					End Using
					Using sqlConnection2 As SqlConnection = New SqlConnection(text)
						sqlConnection2.Open()
						Try
							For Each obj As Object In dataTable.Rows
								Dim dataRow As DataRow = CType(obj, DataRow)
								Dim cols As New List(Of String)()
								Dim vals As New List(Of String)()
								For Each col As DataColumn In dataRow.Table.Columns
									If Not New String() { "is_remote", "SyncGuid", "Version" }.Contains(col.ColumnName) Then
										cols.Add(col.ColumnName)
										vals.Add("@" & col.ColumnName)
									End If
								Next
								Dim text3 As String = String.Join(",", cols)
								Dim text5 As String = String.Join(",", vals)
								Dim text6 As String = String.Format("INSERT INTO InvoiceInfo_StockTransfer ({0}) VALUES ({1})", text3, text5)
								Dim sqlCommand3 As SqlCommand = New SqlCommand(text6, sqlConnection2)
								Try
									For Each obj2 As Object In dataRow.Table.Columns
										Dim dataColumn As DataColumn = CType(obj2, DataColumn)
										Dim flag2 As Boolean = Not New String() { "is_remote", "SyncGuid", "Version" }.Contains(dataColumn.ColumnName)
										If flag2 Then
											sqlCommand3.Parameters.AddWithValue("@" + dataColumn.ColumnName, RuntimeHelpers.GetObjectValue(dataRow(dataColumn.ColumnName)))
										End If
									Next
								Finally
									Dim enumerator2 As IEnumerator
									If TypeOf enumerator2 Is IDisposable Then
										TryCast(enumerator2, IDisposable).Dispose()
									End If
								End Try
								sqlCommand3.ExecuteNonQuery()
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						Dim sqlCommand4 As SqlCommand = New SqlCommand("SET IDENTITY_INSERT InvoiceInfo_Product_StockTransfer ON", sqlConnection2)
						sqlCommand4.ExecuteNonQuery()
						Try
							For Each obj3 As Object In dataTable2.Rows
								Dim dataRow2 As DataRow = CType(obj3, DataRow)
								Dim cols2 As New List(Of String)()
								Dim vals2 As New List(Of String)()
								For Each col As DataColumn In dataRow2.Table.Columns
									If Not New String() { "is_remote", "SyncGuid", "Version" }.Contains(col.ColumnName) Then
										cols2.Add(col.ColumnName)
										vals2.Add("@" & col.ColumnName)
									End If
								Next
								Dim text8 As String = String.Join(",", cols2)
								Dim text10 As String = String.Join(",", vals2)
								Dim text11 As String = String.Format("INSERT INTO InvoiceInfo_Product_StockTransfer ({0}) VALUES ({1})", text8, text10)
								Dim sqlCommand5 As SqlCommand = New SqlCommand(text11, sqlConnection2)
								Try
									For Each obj4 As Object In dataRow2.Table.Columns
										Dim dataColumn2 As DataColumn = CType(obj4, DataColumn)
										Dim flag3 As Boolean = Not New String() { "is_remote", "SyncGuid", "Version" }.Contains(dataColumn2.ColumnName)
										If flag3 Then
											sqlCommand5.Parameters.AddWithValue("@" + dataColumn2.ColumnName, RuntimeHelpers.GetObjectValue(dataRow2(dataColumn2.ColumnName)))
										End If
									Next
								Finally
									Dim enumerator4 As IEnumerator
									If TypeOf enumerator4 Is IDisposable Then
										TryCast(enumerator4, IDisposable).Dispose()
									End If
								End Try
								sqlCommand5.ExecuteNonQuery()
							Next
						Finally
							Dim enumerator3 As IEnumerator
							If TypeOf enumerator3 Is IDisposable Then
								TryCast(enumerator3, IDisposable).Dispose()
							End If
						End Try
						Dim sqlCommand6 As SqlCommand = New SqlCommand("SET IDENTITY_INSERT InvoiceInfo_Product_StockTransfer OFF", sqlConnection2)
						sqlCommand6.ExecuteNonQuery()
					End Using
					Using sqlConnection3 As SqlConnection = New SqlConnection(cs)
						sqlConnection3.Open()
						Dim sqlCommand7 As SqlCommand = New SqlCommand("UPDATE InvoiceInfo_StockTransfer SET status = 1 WHERE Inv_ID = @InvID", sqlConnection3)
						sqlCommand7.Parameters.AddWithValue("@InvID", selectedInv_Id)
						sqlCommand7.ExecuteNonQuery()
					End Using
					MessageBox.Show("✅ Stock transfer completed and marked as transferred.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Catch ex As Exception
					MessageBox.Show("❌ Transfer failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub
	End Class
End Namespace
