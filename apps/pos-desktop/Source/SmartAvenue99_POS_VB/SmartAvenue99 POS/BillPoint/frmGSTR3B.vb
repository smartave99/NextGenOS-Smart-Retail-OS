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
Imports ClosedXML.Excel
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004CA RID: 1226
	<DesignerGenerated()>
	Public Partial Class frmGSTR3B
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F78A RID: 63370 RVA: 0x009418EC File Offset: 0x0093FAEC
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmGSTR3B_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmGSTR3B_KeyDown
			Me.suppliertype = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005EBC RID: 24252
		' (get) Token: 0x0600F78D RID: 63373 RVA: 0x0006C84A File Offset: 0x0006AA4A
		' (set) Token: 0x0600F78E RID: 63374 RVA: 0x0006C854 File Offset: 0x0006AA54
		Friend Overridable Property Label1 As Label

		' Token: 0x17005EBD RID: 24253
		' (get) Token: 0x0600F78F RID: 63375 RVA: 0x0006C85D File Offset: 0x0006AA5D
		' (set) Token: 0x0600F790 RID: 63376 RVA: 0x0006C867 File Offset: 0x0006AA67
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17005EBE RID: 24254
		' (get) Token: 0x0600F791 RID: 63377 RVA: 0x0006C870 File Offset: 0x0006AA70
		' (set) Token: 0x0600F792 RID: 63378 RVA: 0x0094A824 File Offset: 0x00948A24
		Private _btnReset As Button
		Friend Overridable Property btnReset As Button
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim button As Button = Me._btnReset
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnReset = value
				button = Me._btnReset
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005EBF RID: 24255
		' (get) Token: 0x0600F793 RID: 63379 RVA: 0x0006C87A File Offset: 0x0006AA7A
		' (set) Token: 0x0600F794 RID: 63380 RVA: 0x0006C884 File Offset: 0x0006AA84
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17005EC0 RID: 24256
		' (get) Token: 0x0600F795 RID: 63381 RVA: 0x0006C88D File Offset: 0x0006AA8D
		' (set) Token: 0x0600F796 RID: 63382 RVA: 0x0006C897 File Offset: 0x0006AA97
		Friend Overridable Property Label2 As Label

		' Token: 0x17005EC1 RID: 24257
		' (get) Token: 0x0600F797 RID: 63383 RVA: 0x0006C8A0 File Offset: 0x0006AAA0
		' (set) Token: 0x0600F798 RID: 63384 RVA: 0x0094A868 File Offset: 0x00948A68
		Private _btnGetData As Button
		Friend Overridable Property btnGetData As Button
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
				Dim button As Button = Me._btnGetData
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnGetData = value
				button = Me._btnGetData
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005EC2 RID: 24258
		' (get) Token: 0x0600F799 RID: 63385 RVA: 0x0006C8AA File Offset: 0x0006AAAA
		' (set) Token: 0x0600F79A RID: 63386 RVA: 0x0006C8B4 File Offset: 0x0006AAB4
		Friend Overridable Property Label4 As Label

		' Token: 0x17005EC3 RID: 24259
		' (get) Token: 0x0600F79B RID: 63387 RVA: 0x0006C8BD File Offset: 0x0006AABD
		' (set) Token: 0x0600F79C RID: 63388 RVA: 0x0006C8C7 File Offset: 0x0006AAC7
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17005EC4 RID: 24260
		' (get) Token: 0x0600F79D RID: 63389 RVA: 0x0006C8D0 File Offset: 0x0006AAD0
		' (set) Token: 0x0600F79E RID: 63390 RVA: 0x0006C8DA File Offset: 0x0006AADA
		Friend Overridable Property TabControl1 As TabControl

		' Token: 0x17005EC5 RID: 24261
		' (get) Token: 0x0600F79F RID: 63391 RVA: 0x0006C8E3 File Offset: 0x0006AAE3
		' (set) Token: 0x0600F7A0 RID: 63392 RVA: 0x0006C8ED File Offset: 0x0006AAED
		Friend Overridable Property TabPage3 As TabPage

		' Token: 0x17005EC6 RID: 24262
		' (get) Token: 0x0600F7A1 RID: 63393 RVA: 0x0006C8F6 File Offset: 0x0006AAF6
		' (set) Token: 0x0600F7A2 RID: 63394 RVA: 0x0094A8AC File Offset: 0x00948AAC
		Private _LinkLabel3 As LinkLabel
		Friend Overridable Property LinkLabel3 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel3_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel3
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel3 = value
				linkLabel = Me._LinkLabel3
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005EC7 RID: 24263
		' (get) Token: 0x0600F7A3 RID: 63395 RVA: 0x0006C900 File Offset: 0x0006AB00
		' (set) Token: 0x0600F7A4 RID: 63396 RVA: 0x0006C90A File Offset: 0x0006AB0A
		Friend Overridable Property TabPage4 As TabPage

		' Token: 0x17005EC8 RID: 24264
		' (get) Token: 0x0600F7A5 RID: 63397 RVA: 0x0006C913 File Offset: 0x0006AB13
		' (set) Token: 0x0600F7A6 RID: 63398 RVA: 0x0094A8F0 File Offset: 0x00948AF0
		Private _LinkLabel4 As LinkLabel
		Friend Overridable Property LinkLabel4 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel4_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel4
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel4 = value
				linkLabel = Me._LinkLabel4
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005EC9 RID: 24265
		' (get) Token: 0x0600F7A7 RID: 63399 RVA: 0x0006C91D File Offset: 0x0006AB1D
		' (set) Token: 0x0600F7A8 RID: 63400 RVA: 0x0006C927 File Offset: 0x0006AB27
		Friend Overridable Property TabPage5 As TabPage

		' Token: 0x17005ECA RID: 24266
		' (get) Token: 0x0600F7A9 RID: 63401 RVA: 0x0006C930 File Offset: 0x0006AB30
		' (set) Token: 0x0600F7AA RID: 63402 RVA: 0x0094A934 File Offset: 0x00948B34
		Private _LinkLabel5 As LinkLabel
		Friend Overridable Property LinkLabel5 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel5_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel5
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel5 = value
				linkLabel = Me._LinkLabel5
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005ECB RID: 24267
		' (get) Token: 0x0600F7AB RID: 63403 RVA: 0x0006C93A File Offset: 0x0006AB3A
		' (set) Token: 0x0600F7AC RID: 63404 RVA: 0x0006C944 File Offset: 0x0006AB44
		Friend Overridable Property dgw As DataGridView

		' Token: 0x17005ECC RID: 24268
		' (get) Token: 0x0600F7AD RID: 63405 RVA: 0x0006C94D File Offset: 0x0006AB4D
		' (set) Token: 0x0600F7AE RID: 63406 RVA: 0x0006C957 File Offset: 0x0006AB57
		Friend Overridable Property Label3 As Label

		' Token: 0x17005ECD RID: 24269
		' (get) Token: 0x0600F7AF RID: 63407 RVA: 0x0006C960 File Offset: 0x0006AB60
		' (set) Token: 0x0600F7B0 RID: 63408 RVA: 0x0006C96A File Offset: 0x0006AB6A
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17005ECE RID: 24270
		' (get) Token: 0x0600F7B1 RID: 63409 RVA: 0x0006C973 File Offset: 0x0006AB73
		' (set) Token: 0x0600F7B2 RID: 63410 RVA: 0x0006C97D File Offset: 0x0006AB7D
		Friend Overridable Property Label5 As Label

		' Token: 0x17005ECF RID: 24271
		' (get) Token: 0x0600F7B3 RID: 63411 RVA: 0x0006C986 File Offset: 0x0006AB86
		' (set) Token: 0x0600F7B4 RID: 63412 RVA: 0x0006C990 File Offset: 0x0006AB90
		Friend Overridable Property Label6 As Label

		' Token: 0x17005ED0 RID: 24272
		' (get) Token: 0x0600F7B5 RID: 63413 RVA: 0x0006C999 File Offset: 0x0006AB99
		' (set) Token: 0x0600F7B6 RID: 63414 RVA: 0x0006C9A3 File Offset: 0x0006ABA3
		Friend Overridable Property dgw5 As DataGridView

		' Token: 0x17005ED1 RID: 24273
		' (get) Token: 0x0600F7B7 RID: 63415 RVA: 0x0006C9AC File Offset: 0x0006ABAC
		' (set) Token: 0x0600F7B8 RID: 63416 RVA: 0x0006C9B6 File Offset: 0x0006ABB6
		Friend Overridable Property Label7 As Label

		' Token: 0x17005ED2 RID: 24274
		' (get) Token: 0x0600F7B9 RID: 63417 RVA: 0x0006C9BF File Offset: 0x0006ABBF
		' (set) Token: 0x0600F7BA RID: 63418 RVA: 0x0006C9C9 File Offset: 0x0006ABC9
		Friend Overridable Property dgw7 As DataGridView

		' Token: 0x17005ED3 RID: 24275
		' (get) Token: 0x0600F7BB RID: 63419 RVA: 0x0006C9D2 File Offset: 0x0006ABD2
		' (set) Token: 0x0600F7BC RID: 63420 RVA: 0x0006C9DC File Offset: 0x0006ABDC
		Friend Overridable Property Label8 As Label

		' Token: 0x17005ED4 RID: 24276
		' (get) Token: 0x0600F7BD RID: 63421 RVA: 0x0006C9E5 File Offset: 0x0006ABE5
		' (set) Token: 0x0600F7BE RID: 63422 RVA: 0x0006C9EF File Offset: 0x0006ABEF
		Friend Overridable Property dgw8 As DataGridView

		' Token: 0x17005ED5 RID: 24277
		' (get) Token: 0x0600F7BF RID: 63423 RVA: 0x0006C9F8 File Offset: 0x0006ABF8
		' (set) Token: 0x0600F7C0 RID: 63424 RVA: 0x0006CA02 File Offset: 0x0006AC02
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17005ED6 RID: 24278
		' (get) Token: 0x0600F7C1 RID: 63425 RVA: 0x0006CA0B File Offset: 0x0006AC0B
		' (set) Token: 0x0600F7C2 RID: 63426 RVA: 0x0006CA15 File Offset: 0x0006AC15
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x17005ED7 RID: 24279
		' (get) Token: 0x0600F7C3 RID: 63427 RVA: 0x0006CA1E File Offset: 0x0006AC1E
		' (set) Token: 0x0600F7C4 RID: 63428 RVA: 0x0006CA28 File Offset: 0x0006AC28
		Friend Overridable Property TextBox4 As TextBox

		' Token: 0x17005ED8 RID: 24280
		' (get) Token: 0x0600F7C5 RID: 63429 RVA: 0x0006CA31 File Offset: 0x0006AC31
		' (set) Token: 0x0600F7C6 RID: 63430 RVA: 0x0006CA3B File Offset: 0x0006AC3B
		Friend Overridable Property TextBox5 As TextBox

		' Token: 0x17005ED9 RID: 24281
		' (get) Token: 0x0600F7C7 RID: 63431 RVA: 0x0006CA44 File Offset: 0x0006AC44
		' (set) Token: 0x0600F7C8 RID: 63432 RVA: 0x0006CA4E File Offset: 0x0006AC4E
		Friend Overridable Property TextBox6 As TextBox

		' Token: 0x17005EDA RID: 24282
		' (get) Token: 0x0600F7C9 RID: 63433 RVA: 0x0006CA57 File Offset: 0x0006AC57
		' (set) Token: 0x0600F7CA RID: 63434 RVA: 0x0006CA61 File Offset: 0x0006AC61
		Friend Overridable Property TextBox7 As TextBox

		' Token: 0x17005EDB RID: 24283
		' (get) Token: 0x0600F7CB RID: 63435 RVA: 0x0006CA6A File Offset: 0x0006AC6A
		' (set) Token: 0x0600F7CC RID: 63436 RVA: 0x0006CA74 File Offset: 0x0006AC74
		Friend Overridable Property Label9 As Label

		' Token: 0x17005EDC RID: 24284
		' (get) Token: 0x0600F7CD RID: 63437 RVA: 0x0006CA7D File Offset: 0x0006AC7D
		' (set) Token: 0x0600F7CE RID: 63438 RVA: 0x0094A978 File Offset: 0x00948B78
		Private _LinkLabel10 As LinkLabel
		Friend Overridable Property LinkLabel10 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel10
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel10_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel10
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel10 = value
				linkLabel = Me._LinkLabel10
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005EDD RID: 24285
		' (get) Token: 0x0600F7CF RID: 63439 RVA: 0x0006CA87 File Offset: 0x0006AC87
		' (set) Token: 0x0600F7D0 RID: 63440 RVA: 0x0094A9BC File Offset: 0x00948BBC
		Private _LinkLabel9 As LinkLabel
		Friend Overridable Property LinkLabel9 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel9
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel9_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel9
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel9 = value
				linkLabel = Me._LinkLabel9
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005EDE RID: 24286
		' (get) Token: 0x0600F7D1 RID: 63441 RVA: 0x0006CA91 File Offset: 0x0006AC91
		' (set) Token: 0x0600F7D2 RID: 63442 RVA: 0x0094AA00 File Offset: 0x00948C00
		Private _LinkLabel7 As LinkLabel
		Friend Overridable Property LinkLabel7 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel7_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel7
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel7 = value
				linkLabel = Me._LinkLabel7
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005EDF RID: 24287
		' (get) Token: 0x0600F7D3 RID: 63443 RVA: 0x0006CA9B File Offset: 0x0006AC9B
		' (set) Token: 0x0600F7D4 RID: 63444 RVA: 0x0094AA44 File Offset: 0x00948C44
		Private _LinkLabel2 As LinkLabel
		Friend Overridable Property LinkLabel2 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel2_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel2
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel2 = value
				linkLabel = Me._LinkLabel2
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005EE0 RID: 24288
		' (get) Token: 0x0600F7D5 RID: 63445 RVA: 0x0006CAA5 File Offset: 0x0006ACA5
		' (set) Token: 0x0600F7D6 RID: 63446 RVA: 0x0006CAAF File Offset: 0x0006ACAF
		Friend Overridable Property Label10 As Label

		' Token: 0x17005EE1 RID: 24289
		' (get) Token: 0x0600F7D7 RID: 63447 RVA: 0x0006CAB8 File Offset: 0x0006ACB8
		' (set) Token: 0x0600F7D8 RID: 63448 RVA: 0x0094AA88 File Offset: 0x00948C88
		Private _LinkLabel12 As LinkLabel
		Friend Overridable Property LinkLabel12 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel12
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel12_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel12
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel12 = value
				linkLabel = Me._LinkLabel12
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005EE2 RID: 24290
		' (get) Token: 0x0600F7D9 RID: 63449 RVA: 0x0006CAC2 File Offset: 0x0006ACC2
		' (set) Token: 0x0600F7DA RID: 63450 RVA: 0x0006CACC File Offset: 0x0006ACCC
		Friend Overridable Property dgwp As DataGridView

		' Token: 0x17005EE3 RID: 24291
		' (get) Token: 0x0600F7DB RID: 63451 RVA: 0x0006CAD5 File Offset: 0x0006ACD5
		' (set) Token: 0x0600F7DC RID: 63452 RVA: 0x0006CADF File Offset: 0x0006ACDF
		Friend Overridable Property dgwp2 As DataGridView

		' Token: 0x17005EE4 RID: 24292
		' (get) Token: 0x0600F7DD RID: 63453 RVA: 0x0006CAE8 File Offset: 0x0006ACE8
		' (set) Token: 0x0600F7DE RID: 63454 RVA: 0x0006CAF2 File Offset: 0x0006ACF2
		Friend Overridable Property Label11 As Label

		' Token: 0x17005EE5 RID: 24293
		' (get) Token: 0x0600F7DF RID: 63455 RVA: 0x0006CAFB File Offset: 0x0006ACFB
		' (set) Token: 0x0600F7E0 RID: 63456 RVA: 0x0006CB05 File Offset: 0x0006AD05
		Friend Overridable Property dgwp4 As DataGridView

		' Token: 0x17005EE6 RID: 24294
		' (get) Token: 0x0600F7E1 RID: 63457 RVA: 0x0006CB0E File Offset: 0x0006AD0E
		' (set) Token: 0x0600F7E2 RID: 63458 RVA: 0x0006CB18 File Offset: 0x0006AD18
		Friend Overridable Property Label12 As Label

		' Token: 0x17005EE7 RID: 24295
		' (get) Token: 0x0600F7E3 RID: 63459 RVA: 0x0006CB21 File Offset: 0x0006AD21
		' (set) Token: 0x0600F7E4 RID: 63460 RVA: 0x0006CB2B File Offset: 0x0006AD2B
		Friend Overridable Property dgwp6 As DataGridView

		' Token: 0x17005EE8 RID: 24296
		' (get) Token: 0x0600F7E5 RID: 63461 RVA: 0x0006CB34 File Offset: 0x0006AD34
		' (set) Token: 0x0600F7E6 RID: 63462 RVA: 0x0006CB3E File Offset: 0x0006AD3E
		Friend Overridable Property Label13 As Label

		' Token: 0x17005EE9 RID: 24297
		' (get) Token: 0x0600F7E7 RID: 63463 RVA: 0x0006CB47 File Offset: 0x0006AD47
		' (set) Token: 0x0600F7E8 RID: 63464 RVA: 0x0006CB51 File Offset: 0x0006AD51
		Friend Overridable Property dgwp7 As DataGridView

		' Token: 0x17005EEA RID: 24298
		' (get) Token: 0x0600F7E9 RID: 63465 RVA: 0x0006CB5A File Offset: 0x0006AD5A
		' (set) Token: 0x0600F7EA RID: 63466 RVA: 0x0006CB64 File Offset: 0x0006AD64
		Friend Overridable Property Label14 As Label

		' Token: 0x17005EEB RID: 24299
		' (get) Token: 0x0600F7EB RID: 63467 RVA: 0x0006CB6D File Offset: 0x0006AD6D
		' (set) Token: 0x0600F7EC RID: 63468 RVA: 0x0006CB77 File Offset: 0x0006AD77
		Friend Overridable Property dgwp8 As DataGridView

		' Token: 0x17005EEC RID: 24300
		' (get) Token: 0x0600F7ED RID: 63469 RVA: 0x0006CB80 File Offset: 0x0006AD80
		' (set) Token: 0x0600F7EE RID: 63470 RVA: 0x0006CB8A File Offset: 0x0006AD8A
		Friend Overridable Property Label15 As Label

		' Token: 0x17005EED RID: 24301
		' (get) Token: 0x0600F7EF RID: 63471 RVA: 0x0006CB93 File Offset: 0x0006AD93
		' (set) Token: 0x0600F7F0 RID: 63472 RVA: 0x0006CB9D File Offset: 0x0006AD9D
		Friend Overridable Property dgwp9 As DataGridView

		' Token: 0x17005EEE RID: 24302
		' (get) Token: 0x0600F7F1 RID: 63473 RVA: 0x0006CBA6 File Offset: 0x0006ADA6
		' (set) Token: 0x0600F7F2 RID: 63474 RVA: 0x0006CBB0 File Offset: 0x0006ADB0
		Friend Overridable Property Label16 As Label

		' Token: 0x17005EEF RID: 24303
		' (get) Token: 0x0600F7F3 RID: 63475 RVA: 0x0006CBB9 File Offset: 0x0006ADB9
		' (set) Token: 0x0600F7F4 RID: 63476 RVA: 0x0006CBC3 File Offset: 0x0006ADC3
		Friend Overridable Property TextBox8 As TextBox

		' Token: 0x17005EF0 RID: 24304
		' (get) Token: 0x0600F7F5 RID: 63477 RVA: 0x0006CBCC File Offset: 0x0006ADCC
		' (set) Token: 0x0600F7F6 RID: 63478 RVA: 0x0006CBD6 File Offset: 0x0006ADD6
		Friend Overridable Property TextBox9 As TextBox

		' Token: 0x17005EF1 RID: 24305
		' (get) Token: 0x0600F7F7 RID: 63479 RVA: 0x0006CBDF File Offset: 0x0006ADDF
		' (set) Token: 0x0600F7F8 RID: 63480 RVA: 0x0006CBE9 File Offset: 0x0006ADE9
		Friend Overridable Property TextBox10 As TextBox

		' Token: 0x17005EF2 RID: 24306
		' (get) Token: 0x0600F7F9 RID: 63481 RVA: 0x0006CBF2 File Offset: 0x0006ADF2
		' (set) Token: 0x0600F7FA RID: 63482 RVA: 0x0006CBFC File Offset: 0x0006ADFC
		Friend Overridable Property TextBox11 As TextBox

		' Token: 0x17005EF3 RID: 24307
		' (get) Token: 0x0600F7FB RID: 63483 RVA: 0x0006CC05 File Offset: 0x0006AE05
		' (set) Token: 0x0600F7FC RID: 63484 RVA: 0x0006CC0F File Offset: 0x0006AE0F
		Friend Overridable Property TextBox13 As TextBox

		' Token: 0x17005EF4 RID: 24308
		' (get) Token: 0x0600F7FD RID: 63485 RVA: 0x0006CC18 File Offset: 0x0006AE18
		' (set) Token: 0x0600F7FE RID: 63486 RVA: 0x0006CC22 File Offset: 0x0006AE22
		Friend Overridable Property TextBox12 As TextBox

		' Token: 0x17005EF5 RID: 24309
		' (get) Token: 0x0600F7FF RID: 63487 RVA: 0x0006CC2B File Offset: 0x0006AE2B
		' (set) Token: 0x0600F800 RID: 63488 RVA: 0x0094AACC File Offset: 0x00948CCC
		Private _LinkLabel19 As LinkLabel
		Friend Overridable Property LinkLabel19 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel19
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel19_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel19
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel19 = value
				linkLabel = Me._LinkLabel19
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005EF6 RID: 24310
		' (get) Token: 0x0600F801 RID: 63489 RVA: 0x0006CC35 File Offset: 0x0006AE35
		' (set) Token: 0x0600F802 RID: 63490 RVA: 0x0094AB10 File Offset: 0x00948D10
		Private _LinkLabel18 As LinkLabel
		Friend Overridable Property LinkLabel18 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel18
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel18_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel18
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel18 = value
				linkLabel = Me._LinkLabel18
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005EF7 RID: 24311
		' (get) Token: 0x0600F803 RID: 63491 RVA: 0x0006CC3F File Offset: 0x0006AE3F
		' (set) Token: 0x0600F804 RID: 63492 RVA: 0x0094AB54 File Offset: 0x00948D54
		Private _LinkLabel17 As LinkLabel
		Friend Overridable Property LinkLabel17 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel17
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel17_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel17
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel17 = value
				linkLabel = Me._LinkLabel17
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005EF8 RID: 24312
		' (get) Token: 0x0600F805 RID: 63493 RVA: 0x0006CC49 File Offset: 0x0006AE49
		' (set) Token: 0x0600F806 RID: 63494 RVA: 0x0094AB98 File Offset: 0x00948D98
		Private _LinkLabel16 As LinkLabel
		Friend Overridable Property LinkLabel16 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel16
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel16_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel16
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel16 = value
				linkLabel = Me._LinkLabel16
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005EF9 RID: 24313
		' (get) Token: 0x0600F807 RID: 63495 RVA: 0x0006CC53 File Offset: 0x0006AE53
		' (set) Token: 0x0600F808 RID: 63496 RVA: 0x0094ABDC File Offset: 0x00948DDC
		Private _LinkLabel15 As LinkLabel
		Friend Overridable Property LinkLabel15 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel15
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel15_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel15
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel15 = value
				linkLabel = Me._LinkLabel15
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005EFA RID: 24314
		' (get) Token: 0x0600F809 RID: 63497 RVA: 0x0006CC5D File Offset: 0x0006AE5D
		' (set) Token: 0x0600F80A RID: 63498 RVA: 0x0006CC67 File Offset: 0x0006AE67
		Friend Overridable Property DataGridView1 As DataGridView

		' Token: 0x17005EFB RID: 24315
		' (get) Token: 0x0600F80B RID: 63499 RVA: 0x0006CC70 File Offset: 0x0006AE70
		' (set) Token: 0x0600F80C RID: 63500 RVA: 0x0006CC7A File Offset: 0x0006AE7A
		Friend Overridable Property Label18 As Label

		' Token: 0x17005EFC RID: 24316
		' (get) Token: 0x0600F80D RID: 63501 RVA: 0x0006CC83 File Offset: 0x0006AE83
		' (set) Token: 0x0600F80E RID: 63502 RVA: 0x0006CC8D File Offset: 0x0006AE8D
		Friend Overridable Property TextBox15 As TextBox

		' Token: 0x17005EFD RID: 24317
		' (get) Token: 0x0600F80F RID: 63503 RVA: 0x0006CC96 File Offset: 0x0006AE96
		' (set) Token: 0x0600F810 RID: 63504 RVA: 0x0006CCA0 File Offset: 0x0006AEA0
		Friend Overridable Property TextBox14 As TextBox

		' Token: 0x17005EFE RID: 24318
		' (get) Token: 0x0600F811 RID: 63505 RVA: 0x0006CCA9 File Offset: 0x0006AEA9
		' (set) Token: 0x0600F812 RID: 63506 RVA: 0x0006CCB3 File Offset: 0x0006AEB3
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17005EFF RID: 24319
		' (get) Token: 0x0600F813 RID: 63507 RVA: 0x0006CCBC File Offset: 0x0006AEBC
		' (set) Token: 0x0600F814 RID: 63508 RVA: 0x0006CCC6 File Offset: 0x0006AEC6
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005F00 RID: 24320
		' (get) Token: 0x0600F815 RID: 63509 RVA: 0x0006CCCF File Offset: 0x0006AECF
		' (set) Token: 0x0600F816 RID: 63510 RVA: 0x0006CCD9 File Offset: 0x0006AED9
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005F01 RID: 24321
		' (get) Token: 0x0600F817 RID: 63511 RVA: 0x0006CCE2 File Offset: 0x0006AEE2
		' (set) Token: 0x0600F818 RID: 63512 RVA: 0x0006CCEC File Offset: 0x0006AEEC
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17005F02 RID: 24322
		' (get) Token: 0x0600F819 RID: 63513 RVA: 0x0006CCF5 File Offset: 0x0006AEF5
		' (set) Token: 0x0600F81A RID: 63514 RVA: 0x0006CCFF File Offset: 0x0006AEFF
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17005F03 RID: 24323
		' (get) Token: 0x0600F81B RID: 63515 RVA: 0x0006CD08 File Offset: 0x0006AF08
		' (set) Token: 0x0600F81C RID: 63516 RVA: 0x0006CD12 File Offset: 0x0006AF12
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17005F04 RID: 24324
		' (get) Token: 0x0600F81D RID: 63517 RVA: 0x0006CD1B File Offset: 0x0006AF1B
		' (set) Token: 0x0600F81E RID: 63518 RVA: 0x0006CD25 File Offset: 0x0006AF25
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17005F05 RID: 24325
		' (get) Token: 0x0600F81F RID: 63519 RVA: 0x0006CD2E File Offset: 0x0006AF2E
		' (set) Token: 0x0600F820 RID: 63520 RVA: 0x0006CD38 File Offset: 0x0006AF38
		Friend Overridable Property dgw3 As DataGridView

		' Token: 0x17005F06 RID: 24326
		' (get) Token: 0x0600F821 RID: 63521 RVA: 0x0006CD41 File Offset: 0x0006AF41
		' (set) Token: 0x0600F822 RID: 63522 RVA: 0x0006CD4B File Offset: 0x0006AF4B
		Friend Overridable Property DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn

		' Token: 0x17005F07 RID: 24327
		' (get) Token: 0x0600F823 RID: 63523 RVA: 0x0006CD54 File Offset: 0x0006AF54
		' (set) Token: 0x0600F824 RID: 63524 RVA: 0x0006CD5E File Offset: 0x0006AF5E
		Friend Overridable Property DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn

		' Token: 0x17005F08 RID: 24328
		' (get) Token: 0x0600F825 RID: 63525 RVA: 0x0006CD67 File Offset: 0x0006AF67
		' (set) Token: 0x0600F826 RID: 63526 RVA: 0x0006CD71 File Offset: 0x0006AF71
		Friend Overridable Property DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn

		' Token: 0x17005F09 RID: 24329
		' (get) Token: 0x0600F827 RID: 63527 RVA: 0x0006CD7A File Offset: 0x0006AF7A
		' (set) Token: 0x0600F828 RID: 63528 RVA: 0x0006CD84 File Offset: 0x0006AF84
		Friend Overridable Property DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn

		' Token: 0x17005F0A RID: 24330
		' (get) Token: 0x0600F829 RID: 63529 RVA: 0x0006CD8D File Offset: 0x0006AF8D
		' (set) Token: 0x0600F82A RID: 63530 RVA: 0x0006CD97 File Offset: 0x0006AF97
		Friend Overridable Property DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn

		' Token: 0x17005F0B RID: 24331
		' (get) Token: 0x0600F82B RID: 63531 RVA: 0x0006CDA0 File Offset: 0x0006AFA0
		' (set) Token: 0x0600F82C RID: 63532 RVA: 0x0006CDAA File Offset: 0x0006AFAA
		Friend Overridable Property DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn

		' Token: 0x17005F0C RID: 24332
		' (get) Token: 0x0600F82D RID: 63533 RVA: 0x0006CDB3 File Offset: 0x0006AFB3
		' (set) Token: 0x0600F82E RID: 63534 RVA: 0x0006CDBD File Offset: 0x0006AFBD
		Friend Overridable Property DataGridViewTextBoxColumn49 As DataGridViewTextBoxColumn

		' Token: 0x17005F0D RID: 24333
		' (get) Token: 0x0600F82F RID: 63535 RVA: 0x0006CDC6 File Offset: 0x0006AFC6
		' (set) Token: 0x0600F830 RID: 63536 RVA: 0x0006CDD0 File Offset: 0x0006AFD0
		Friend Overridable Property DataGridViewTextBoxColumn50 As DataGridViewTextBoxColumn

		' Token: 0x17005F0E RID: 24334
		' (get) Token: 0x0600F831 RID: 63537 RVA: 0x0006CDD9 File Offset: 0x0006AFD9
		' (set) Token: 0x0600F832 RID: 63538 RVA: 0x0006CDE3 File Offset: 0x0006AFE3
		Friend Overridable Property DataGridViewTextBoxColumn51 As DataGridViewTextBoxColumn

		' Token: 0x17005F0F RID: 24335
		' (get) Token: 0x0600F833 RID: 63539 RVA: 0x0006CDEC File Offset: 0x0006AFEC
		' (set) Token: 0x0600F834 RID: 63540 RVA: 0x0006CDF6 File Offset: 0x0006AFF6
		Friend Overridable Property DataGridViewTextBoxColumn52 As DataGridViewTextBoxColumn

		' Token: 0x17005F10 RID: 24336
		' (get) Token: 0x0600F835 RID: 63541 RVA: 0x0006CDFF File Offset: 0x0006AFFF
		' (set) Token: 0x0600F836 RID: 63542 RVA: 0x0006CE09 File Offset: 0x0006B009
		Friend Overridable Property DataGridViewTextBoxColumn53 As DataGridViewTextBoxColumn

		' Token: 0x17005F11 RID: 24337
		' (get) Token: 0x0600F837 RID: 63543 RVA: 0x0006CE12 File Offset: 0x0006B012
		' (set) Token: 0x0600F838 RID: 63544 RVA: 0x0006CE1C File Offset: 0x0006B01C
		Friend Overridable Property DataGridViewTextBoxColumn54 As DataGridViewTextBoxColumn

		' Token: 0x17005F12 RID: 24338
		' (get) Token: 0x0600F839 RID: 63545 RVA: 0x0006CE25 File Offset: 0x0006B025
		' (set) Token: 0x0600F83A RID: 63546 RVA: 0x0006CE2F File Offset: 0x0006B02F
		Friend Overridable Property DataGridViewTextBoxColumn73 As DataGridViewTextBoxColumn

		' Token: 0x17005F13 RID: 24339
		' (get) Token: 0x0600F83B RID: 63547 RVA: 0x0006CE38 File Offset: 0x0006B038
		' (set) Token: 0x0600F83C RID: 63548 RVA: 0x0006CE42 File Offset: 0x0006B042
		Friend Overridable Property DataGridViewTextBoxColumn74 As DataGridViewTextBoxColumn

		' Token: 0x17005F14 RID: 24340
		' (get) Token: 0x0600F83D RID: 63549 RVA: 0x0006CE4B File Offset: 0x0006B04B
		' (set) Token: 0x0600F83E RID: 63550 RVA: 0x0006CE55 File Offset: 0x0006B055
		Friend Overridable Property DataGridViewTextBoxColumn75 As DataGridViewTextBoxColumn

		' Token: 0x17005F15 RID: 24341
		' (get) Token: 0x0600F83F RID: 63551 RVA: 0x0006CE5E File Offset: 0x0006B05E
		' (set) Token: 0x0600F840 RID: 63552 RVA: 0x0006CE68 File Offset: 0x0006B068
		Friend Overridable Property DataGridViewTextBoxColumn76 As DataGridViewTextBoxColumn

		' Token: 0x17005F16 RID: 24342
		' (get) Token: 0x0600F841 RID: 63553 RVA: 0x0006CE71 File Offset: 0x0006B071
		' (set) Token: 0x0600F842 RID: 63554 RVA: 0x0006CE7B File Offset: 0x0006B07B
		Friend Overridable Property DataGridViewTextBoxColumn77 As DataGridViewTextBoxColumn

		' Token: 0x17005F17 RID: 24343
		' (get) Token: 0x0600F843 RID: 63555 RVA: 0x0006CE84 File Offset: 0x0006B084
		' (set) Token: 0x0600F844 RID: 63556 RVA: 0x0006CE8E File Offset: 0x0006B08E
		Friend Overridable Property DataGridViewTextBoxColumn78 As DataGridViewTextBoxColumn

		' Token: 0x17005F18 RID: 24344
		' (get) Token: 0x0600F845 RID: 63557 RVA: 0x0006CE97 File Offset: 0x0006B097
		' (set) Token: 0x0600F846 RID: 63558 RVA: 0x0006CEA1 File Offset: 0x0006B0A1
		Friend Overridable Property DataGridViewTextBoxColumn61 As DataGridViewTextBoxColumn

		' Token: 0x17005F19 RID: 24345
		' (get) Token: 0x0600F847 RID: 63559 RVA: 0x0006CEAA File Offset: 0x0006B0AA
		' (set) Token: 0x0600F848 RID: 63560 RVA: 0x0006CEB4 File Offset: 0x0006B0B4
		Friend Overridable Property DataGridViewTextBoxColumn62 As DataGridViewTextBoxColumn

		' Token: 0x17005F1A RID: 24346
		' (get) Token: 0x0600F849 RID: 63561 RVA: 0x0006CEBD File Offset: 0x0006B0BD
		' (set) Token: 0x0600F84A RID: 63562 RVA: 0x0006CEC7 File Offset: 0x0006B0C7
		Friend Overridable Property DataGridViewTextBoxColumn63 As DataGridViewTextBoxColumn

		' Token: 0x17005F1B RID: 24347
		' (get) Token: 0x0600F84B RID: 63563 RVA: 0x0006CED0 File Offset: 0x0006B0D0
		' (set) Token: 0x0600F84C RID: 63564 RVA: 0x0006CEDA File Offset: 0x0006B0DA
		Friend Overridable Property DataGridViewTextBoxColumn64 As DataGridViewTextBoxColumn

		' Token: 0x17005F1C RID: 24348
		' (get) Token: 0x0600F84D RID: 63565 RVA: 0x0006CEE3 File Offset: 0x0006B0E3
		' (set) Token: 0x0600F84E RID: 63566 RVA: 0x0006CEED File Offset: 0x0006B0ED
		Friend Overridable Property DataGridViewTextBoxColumn65 As DataGridViewTextBoxColumn

		' Token: 0x17005F1D RID: 24349
		' (get) Token: 0x0600F84F RID: 63567 RVA: 0x0006CEF6 File Offset: 0x0006B0F6
		' (set) Token: 0x0600F850 RID: 63568 RVA: 0x0006CF00 File Offset: 0x0006B100
		Friend Overridable Property DataGridViewTextBoxColumn66 As DataGridViewTextBoxColumn

		' Token: 0x17005F1E RID: 24350
		' (get) Token: 0x0600F851 RID: 63569 RVA: 0x0006CF09 File Offset: 0x0006B109
		' (set) Token: 0x0600F852 RID: 63570 RVA: 0x0006CF13 File Offset: 0x0006B113
		Friend Overridable Property TableLayoutPanel1 As TableLayoutPanel

		' Token: 0x17005F1F RID: 24351
		' (get) Token: 0x0600F853 RID: 63571 RVA: 0x0006CF1C File Offset: 0x0006B11C
		' (set) Token: 0x0600F854 RID: 63572 RVA: 0x0006CF26 File Offset: 0x0006B126
		Friend Overridable Property Label25 As Label

		' Token: 0x17005F20 RID: 24352
		' (get) Token: 0x0600F855 RID: 63573 RVA: 0x0006CF2F File Offset: 0x0006B12F
		' (set) Token: 0x0600F856 RID: 63574 RVA: 0x0006CF39 File Offset: 0x0006B139
		Friend Overridable Property Label24 As Label

		' Token: 0x17005F21 RID: 24353
		' (get) Token: 0x0600F857 RID: 63575 RVA: 0x0006CF42 File Offset: 0x0006B142
		' (set) Token: 0x0600F858 RID: 63576 RVA: 0x0006CF4C File Offset: 0x0006B14C
		Friend Overridable Property Label23 As Label

		' Token: 0x17005F22 RID: 24354
		' (get) Token: 0x0600F859 RID: 63577 RVA: 0x0006CF55 File Offset: 0x0006B155
		' (set) Token: 0x0600F85A RID: 63578 RVA: 0x0006CF5F File Offset: 0x0006B15F
		Friend Overridable Property Label22 As Label

		' Token: 0x17005F23 RID: 24355
		' (get) Token: 0x0600F85B RID: 63579 RVA: 0x0006CF68 File Offset: 0x0006B168
		' (set) Token: 0x0600F85C RID: 63580 RVA: 0x0006CF72 File Offset: 0x0006B172
		Friend Overridable Property Label21 As Label

		' Token: 0x17005F24 RID: 24356
		' (get) Token: 0x0600F85D RID: 63581 RVA: 0x0006CF7B File Offset: 0x0006B17B
		' (set) Token: 0x0600F85E RID: 63582 RVA: 0x0006CF85 File Offset: 0x0006B185
		Friend Overridable Property Label20 As Label

		' Token: 0x17005F25 RID: 24357
		' (get) Token: 0x0600F85F RID: 63583 RVA: 0x0006CF8E File Offset: 0x0006B18E
		' (set) Token: 0x0600F860 RID: 63584 RVA: 0x0006CF98 File Offset: 0x0006B198
		Friend Overridable Property Label19 As Label

		' Token: 0x17005F26 RID: 24358
		' (get) Token: 0x0600F861 RID: 63585 RVA: 0x0006CFA1 File Offset: 0x0006B1A1
		' (set) Token: 0x0600F862 RID: 63586 RVA: 0x0006CFAB File Offset: 0x0006B1AB
		Friend Overridable Property TableLayoutPanel2 As TableLayoutPanel

		' Token: 0x17005F27 RID: 24359
		' (get) Token: 0x0600F863 RID: 63587 RVA: 0x0006CFB4 File Offset: 0x0006B1B4
		' (set) Token: 0x0600F864 RID: 63588 RVA: 0x0006CFBE File Offset: 0x0006B1BE
		Friend Overridable Property DataGridViewTextBoxColumn85 As DataGridViewTextBoxColumn

		' Token: 0x17005F28 RID: 24360
		' (get) Token: 0x0600F865 RID: 63589 RVA: 0x0006CFC7 File Offset: 0x0006B1C7
		' (set) Token: 0x0600F866 RID: 63590 RVA: 0x0006CFD1 File Offset: 0x0006B1D1
		Friend Overridable Property DataGridViewTextBoxColumn86 As DataGridViewTextBoxColumn

		' Token: 0x17005F29 RID: 24361
		' (get) Token: 0x0600F867 RID: 63591 RVA: 0x0006CFDA File Offset: 0x0006B1DA
		' (set) Token: 0x0600F868 RID: 63592 RVA: 0x0006CFE4 File Offset: 0x0006B1E4
		Friend Overridable Property DataGridViewTextBoxColumn87 As DataGridViewTextBoxColumn

		' Token: 0x17005F2A RID: 24362
		' (get) Token: 0x0600F869 RID: 63593 RVA: 0x0006CFED File Offset: 0x0006B1ED
		' (set) Token: 0x0600F86A RID: 63594 RVA: 0x0006CFF7 File Offset: 0x0006B1F7
		Friend Overridable Property DataGridViewTextBoxColumn88 As DataGridViewTextBoxColumn

		' Token: 0x17005F2B RID: 24363
		' (get) Token: 0x0600F86B RID: 63595 RVA: 0x0006D000 File Offset: 0x0006B200
		' (set) Token: 0x0600F86C RID: 63596 RVA: 0x0006D00A File Offset: 0x0006B20A
		Friend Overridable Property DataGridViewTextBoxColumn89 As DataGridViewTextBoxColumn

		' Token: 0x17005F2C RID: 24364
		' (get) Token: 0x0600F86D RID: 63597 RVA: 0x0006D013 File Offset: 0x0006B213
		' (set) Token: 0x0600F86E RID: 63598 RVA: 0x0006D01D File Offset: 0x0006B21D
		Friend Overridable Property DataGridViewTextBoxColumn90 As DataGridViewTextBoxColumn

		' Token: 0x17005F2D RID: 24365
		' (get) Token: 0x0600F86F RID: 63599 RVA: 0x0006D026 File Offset: 0x0006B226
		' (set) Token: 0x0600F870 RID: 63600 RVA: 0x0006D030 File Offset: 0x0006B230
		Friend Overridable Property DataGridViewTextBoxColumn121 As DataGridViewTextBoxColumn

		' Token: 0x17005F2E RID: 24366
		' (get) Token: 0x0600F871 RID: 63601 RVA: 0x0006D039 File Offset: 0x0006B239
		' (set) Token: 0x0600F872 RID: 63602 RVA: 0x0006D043 File Offset: 0x0006B243
		Friend Overridable Property DataGridViewTextBoxColumn122 As DataGridViewTextBoxColumn

		' Token: 0x17005F2F RID: 24367
		' (get) Token: 0x0600F873 RID: 63603 RVA: 0x0006D04C File Offset: 0x0006B24C
		' (set) Token: 0x0600F874 RID: 63604 RVA: 0x0006D056 File Offset: 0x0006B256
		Friend Overridable Property DataGridViewTextBoxColumn123 As DataGridViewTextBoxColumn

		' Token: 0x17005F30 RID: 24368
		' (get) Token: 0x0600F875 RID: 63605 RVA: 0x0006D05F File Offset: 0x0006B25F
		' (set) Token: 0x0600F876 RID: 63606 RVA: 0x0006D069 File Offset: 0x0006B269
		Friend Overridable Property DataGridViewTextBoxColumn124 As DataGridViewTextBoxColumn

		' Token: 0x17005F31 RID: 24369
		' (get) Token: 0x0600F877 RID: 63607 RVA: 0x0006D072 File Offset: 0x0006B272
		' (set) Token: 0x0600F878 RID: 63608 RVA: 0x0006D07C File Offset: 0x0006B27C
		Friend Overridable Property DataGridViewTextBoxColumn125 As DataGridViewTextBoxColumn

		' Token: 0x17005F32 RID: 24370
		' (get) Token: 0x0600F879 RID: 63609 RVA: 0x0006D085 File Offset: 0x0006B285
		' (set) Token: 0x0600F87A RID: 63610 RVA: 0x0006D08F File Offset: 0x0006B28F
		Friend Overridable Property DataGridViewTextBoxColumn126 As DataGridViewTextBoxColumn

		' Token: 0x17005F33 RID: 24371
		' (get) Token: 0x0600F87B RID: 63611 RVA: 0x0006D098 File Offset: 0x0006B298
		' (set) Token: 0x0600F87C RID: 63612 RVA: 0x0006D0A2 File Offset: 0x0006B2A2
		Friend Overridable Property DataGridViewTextBoxColumn145 As DataGridViewTextBoxColumn

		' Token: 0x17005F34 RID: 24372
		' (get) Token: 0x0600F87D RID: 63613 RVA: 0x0006D0AB File Offset: 0x0006B2AB
		' (set) Token: 0x0600F87E RID: 63614 RVA: 0x0006D0B5 File Offset: 0x0006B2B5
		Friend Overridable Property DataGridViewTextBoxColumn146 As DataGridViewTextBoxColumn

		' Token: 0x17005F35 RID: 24373
		' (get) Token: 0x0600F87F RID: 63615 RVA: 0x0006D0BE File Offset: 0x0006B2BE
		' (set) Token: 0x0600F880 RID: 63616 RVA: 0x0006D0C8 File Offset: 0x0006B2C8
		Friend Overridable Property DataGridViewTextBoxColumn147 As DataGridViewTextBoxColumn

		' Token: 0x17005F36 RID: 24374
		' (get) Token: 0x0600F881 RID: 63617 RVA: 0x0006D0D1 File Offset: 0x0006B2D1
		' (set) Token: 0x0600F882 RID: 63618 RVA: 0x0006D0DB File Offset: 0x0006B2DB
		Friend Overridable Property DataGridViewTextBoxColumn148 As DataGridViewTextBoxColumn

		' Token: 0x17005F37 RID: 24375
		' (get) Token: 0x0600F883 RID: 63619 RVA: 0x0006D0E4 File Offset: 0x0006B2E4
		' (set) Token: 0x0600F884 RID: 63620 RVA: 0x0006D0EE File Offset: 0x0006B2EE
		Friend Overridable Property DataGridViewTextBoxColumn149 As DataGridViewTextBoxColumn

		' Token: 0x17005F38 RID: 24376
		' (get) Token: 0x0600F885 RID: 63621 RVA: 0x0006D0F7 File Offset: 0x0006B2F7
		' (set) Token: 0x0600F886 RID: 63622 RVA: 0x0006D101 File Offset: 0x0006B301
		Friend Overridable Property DataGridViewTextBoxColumn150 As DataGridViewTextBoxColumn

		' Token: 0x17005F39 RID: 24377
		' (get) Token: 0x0600F887 RID: 63623 RVA: 0x0006D10A File Offset: 0x0006B30A
		' (set) Token: 0x0600F888 RID: 63624 RVA: 0x0006D114 File Offset: 0x0006B314
		Friend Overridable Property DataGridViewTextBoxColumn169 As DataGridViewTextBoxColumn

		' Token: 0x17005F3A RID: 24378
		' (get) Token: 0x0600F889 RID: 63625 RVA: 0x0006D11D File Offset: 0x0006B31D
		' (set) Token: 0x0600F88A RID: 63626 RVA: 0x0006D127 File Offset: 0x0006B327
		Friend Overridable Property DataGridViewTextBoxColumn170 As DataGridViewTextBoxColumn

		' Token: 0x17005F3B RID: 24379
		' (get) Token: 0x0600F88B RID: 63627 RVA: 0x0006D130 File Offset: 0x0006B330
		' (set) Token: 0x0600F88C RID: 63628 RVA: 0x0006D13A File Offset: 0x0006B33A
		Friend Overridable Property DataGridViewTextBoxColumn171 As DataGridViewTextBoxColumn

		' Token: 0x17005F3C RID: 24380
		' (get) Token: 0x0600F88D RID: 63629 RVA: 0x0006D143 File Offset: 0x0006B343
		' (set) Token: 0x0600F88E RID: 63630 RVA: 0x0006D14D File Offset: 0x0006B34D
		Friend Overridable Property DataGridViewTextBoxColumn172 As DataGridViewTextBoxColumn

		' Token: 0x17005F3D RID: 24381
		' (get) Token: 0x0600F88F RID: 63631 RVA: 0x0006D156 File Offset: 0x0006B356
		' (set) Token: 0x0600F890 RID: 63632 RVA: 0x0006D160 File Offset: 0x0006B360
		Friend Overridable Property DataGridViewTextBoxColumn173 As DataGridViewTextBoxColumn

		' Token: 0x17005F3E RID: 24382
		' (get) Token: 0x0600F891 RID: 63633 RVA: 0x0006D169 File Offset: 0x0006B369
		' (set) Token: 0x0600F892 RID: 63634 RVA: 0x0006D173 File Offset: 0x0006B373
		Friend Overridable Property DataGridViewTextBoxColumn174 As DataGridViewTextBoxColumn

		' Token: 0x17005F3F RID: 24383
		' (get) Token: 0x0600F893 RID: 63635 RVA: 0x0006D17C File Offset: 0x0006B37C
		' (set) Token: 0x0600F894 RID: 63636 RVA: 0x0006D186 File Offset: 0x0006B386
		Friend Overridable Property DataGridViewTextBoxColumn157 As DataGridViewTextBoxColumn

		' Token: 0x17005F40 RID: 24384
		' (get) Token: 0x0600F895 RID: 63637 RVA: 0x0006D18F File Offset: 0x0006B38F
		' (set) Token: 0x0600F896 RID: 63638 RVA: 0x0006D199 File Offset: 0x0006B399
		Friend Overridable Property DataGridViewTextBoxColumn158 As DataGridViewTextBoxColumn

		' Token: 0x17005F41 RID: 24385
		' (get) Token: 0x0600F897 RID: 63639 RVA: 0x0006D1A2 File Offset: 0x0006B3A2
		' (set) Token: 0x0600F898 RID: 63640 RVA: 0x0006D1AC File Offset: 0x0006B3AC
		Friend Overridable Property DataGridViewTextBoxColumn159 As DataGridViewTextBoxColumn

		' Token: 0x17005F42 RID: 24386
		' (get) Token: 0x0600F899 RID: 63641 RVA: 0x0006D1B5 File Offset: 0x0006B3B5
		' (set) Token: 0x0600F89A RID: 63642 RVA: 0x0006D1BF File Offset: 0x0006B3BF
		Friend Overridable Property DataGridViewTextBoxColumn160 As DataGridViewTextBoxColumn

		' Token: 0x17005F43 RID: 24387
		' (get) Token: 0x0600F89B RID: 63643 RVA: 0x0006D1C8 File Offset: 0x0006B3C8
		' (set) Token: 0x0600F89C RID: 63644 RVA: 0x0006D1D2 File Offset: 0x0006B3D2
		Friend Overridable Property DataGridViewTextBoxColumn161 As DataGridViewTextBoxColumn

		' Token: 0x17005F44 RID: 24388
		' (get) Token: 0x0600F89D RID: 63645 RVA: 0x0006D1DB File Offset: 0x0006B3DB
		' (set) Token: 0x0600F89E RID: 63646 RVA: 0x0006D1E5 File Offset: 0x0006B3E5
		Friend Overridable Property DataGridViewTextBoxColumn162 As DataGridViewTextBoxColumn

		' Token: 0x17005F45 RID: 24389
		' (get) Token: 0x0600F89F RID: 63647 RVA: 0x0006D1EE File Offset: 0x0006B3EE
		' (set) Token: 0x0600F8A0 RID: 63648 RVA: 0x0006D1F8 File Offset: 0x0006B3F8
		Friend Overridable Property DataGridViewTextBoxColumn181 As DataGridViewTextBoxColumn

		' Token: 0x17005F46 RID: 24390
		' (get) Token: 0x0600F8A1 RID: 63649 RVA: 0x0006D201 File Offset: 0x0006B401
		' (set) Token: 0x0600F8A2 RID: 63650 RVA: 0x0006D20B File Offset: 0x0006B40B
		Friend Overridable Property DataGridViewTextBoxColumn182 As DataGridViewTextBoxColumn

		' Token: 0x17005F47 RID: 24391
		' (get) Token: 0x0600F8A3 RID: 63651 RVA: 0x0006D214 File Offset: 0x0006B414
		' (set) Token: 0x0600F8A4 RID: 63652 RVA: 0x0006D21E File Offset: 0x0006B41E
		Friend Overridable Property DataGridViewTextBoxColumn183 As DataGridViewTextBoxColumn

		' Token: 0x17005F48 RID: 24392
		' (get) Token: 0x0600F8A5 RID: 63653 RVA: 0x0006D227 File Offset: 0x0006B427
		' (set) Token: 0x0600F8A6 RID: 63654 RVA: 0x0006D231 File Offset: 0x0006B431
		Friend Overridable Property DataGridViewTextBoxColumn184 As DataGridViewTextBoxColumn

		' Token: 0x17005F49 RID: 24393
		' (get) Token: 0x0600F8A7 RID: 63655 RVA: 0x0006D23A File Offset: 0x0006B43A
		' (set) Token: 0x0600F8A8 RID: 63656 RVA: 0x0006D244 File Offset: 0x0006B444
		Friend Overridable Property DataGridViewTextBoxColumn185 As DataGridViewTextBoxColumn

		' Token: 0x17005F4A RID: 24394
		' (get) Token: 0x0600F8A9 RID: 63657 RVA: 0x0006D24D File Offset: 0x0006B44D
		' (set) Token: 0x0600F8AA RID: 63658 RVA: 0x0006D257 File Offset: 0x0006B457
		Friend Overridable Property DataGridViewTextBoxColumn186 As DataGridViewTextBoxColumn

		' Token: 0x17005F4B RID: 24395
		' (get) Token: 0x0600F8AB RID: 63659 RVA: 0x0006D260 File Offset: 0x0006B460
		' (set) Token: 0x0600F8AC RID: 63660 RVA: 0x0006D26A File Offset: 0x0006B46A
		Friend Overridable Property DataGridViewTextBoxColumn193 As DataGridViewTextBoxColumn

		' Token: 0x17005F4C RID: 24396
		' (get) Token: 0x0600F8AD RID: 63661 RVA: 0x0006D273 File Offset: 0x0006B473
		' (set) Token: 0x0600F8AE RID: 63662 RVA: 0x0006D27D File Offset: 0x0006B47D
		Friend Overridable Property DataGridViewTextBoxColumn194 As DataGridViewTextBoxColumn

		' Token: 0x17005F4D RID: 24397
		' (get) Token: 0x0600F8AF RID: 63663 RVA: 0x0006D286 File Offset: 0x0006B486
		' (set) Token: 0x0600F8B0 RID: 63664 RVA: 0x0006D290 File Offset: 0x0006B490
		Friend Overridable Property DataGridViewTextBoxColumn195 As DataGridViewTextBoxColumn

		' Token: 0x17005F4E RID: 24398
		' (get) Token: 0x0600F8B1 RID: 63665 RVA: 0x0006D299 File Offset: 0x0006B499
		' (set) Token: 0x0600F8B2 RID: 63666 RVA: 0x0006D2A3 File Offset: 0x0006B4A3
		Friend Overridable Property DataGridViewTextBoxColumn196 As DataGridViewTextBoxColumn

		' Token: 0x17005F4F RID: 24399
		' (get) Token: 0x0600F8B3 RID: 63667 RVA: 0x0006D2AC File Offset: 0x0006B4AC
		' (set) Token: 0x0600F8B4 RID: 63668 RVA: 0x0006D2B6 File Offset: 0x0006B4B6
		Friend Overridable Property DataGridViewTextBoxColumn197 As DataGridViewTextBoxColumn

		' Token: 0x17005F50 RID: 24400
		' (get) Token: 0x0600F8B5 RID: 63669 RVA: 0x0006D2BF File Offset: 0x0006B4BF
		' (set) Token: 0x0600F8B6 RID: 63670 RVA: 0x0006D2C9 File Offset: 0x0006B4C9
		Friend Overridable Property DataGridViewTextBoxColumn198 As DataGridViewTextBoxColumn

		' Token: 0x17005F51 RID: 24401
		' (get) Token: 0x0600F8B7 RID: 63671 RVA: 0x0006D2D2 File Offset: 0x0006B4D2
		' (set) Token: 0x0600F8B8 RID: 63672 RVA: 0x0006D2DC File Offset: 0x0006B4DC
		Friend Overridable Property TableLayoutPanel3 As TableLayoutPanel

		' Token: 0x17005F52 RID: 24402
		' (get) Token: 0x0600F8B9 RID: 63673 RVA: 0x0006D2E5 File Offset: 0x0006B4E5
		' (set) Token: 0x0600F8BA RID: 63674 RVA: 0x0006D2EF File Offset: 0x0006B4EF
		Friend Overridable Property Label26 As Label

		' Token: 0x17005F53 RID: 24403
		' (get) Token: 0x0600F8BB RID: 63675 RVA: 0x0006D2F8 File Offset: 0x0006B4F8
		' (set) Token: 0x0600F8BC RID: 63676 RVA: 0x0006D302 File Offset: 0x0006B502
		Friend Overridable Property Label27 As Label

		' Token: 0x17005F54 RID: 24404
		' (get) Token: 0x0600F8BD RID: 63677 RVA: 0x0006D30B File Offset: 0x0006B50B
		' (set) Token: 0x0600F8BE RID: 63678 RVA: 0x0006D315 File Offset: 0x0006B515
		Friend Overridable Property Label28 As Label

		' Token: 0x17005F55 RID: 24405
		' (get) Token: 0x0600F8BF RID: 63679 RVA: 0x0006D31E File Offset: 0x0006B51E
		' (set) Token: 0x0600F8C0 RID: 63680 RVA: 0x0006D328 File Offset: 0x0006B528
		Friend Overridable Property Label29 As Label

		' Token: 0x17005F56 RID: 24406
		' (get) Token: 0x0600F8C1 RID: 63681 RVA: 0x0006D331 File Offset: 0x0006B531
		' (set) Token: 0x0600F8C2 RID: 63682 RVA: 0x0006D33B File Offset: 0x0006B53B
		Friend Overridable Property Label30 As Label

		' Token: 0x17005F57 RID: 24407
		' (get) Token: 0x0600F8C3 RID: 63683 RVA: 0x0006D344 File Offset: 0x0006B544
		' (set) Token: 0x0600F8C4 RID: 63684 RVA: 0x0006D34E File Offset: 0x0006B54E
		Friend Overridable Property Label31 As Label

		' Token: 0x17005F58 RID: 24408
		' (get) Token: 0x0600F8C5 RID: 63685 RVA: 0x0006D357 File Offset: 0x0006B557
		' (set) Token: 0x0600F8C6 RID: 63686 RVA: 0x0006D361 File Offset: 0x0006B561
		Friend Overridable Property Label32 As Label

		' Token: 0x17005F59 RID: 24409
		' (get) Token: 0x0600F8C7 RID: 63687 RVA: 0x0006D36A File Offset: 0x0006B56A
		' (set) Token: 0x0600F8C8 RID: 63688 RVA: 0x0006D374 File Offset: 0x0006B574
		Friend Overridable Property TableLayoutPanel4 As TableLayoutPanel

		' Token: 0x17005F5A RID: 24410
		' (get) Token: 0x0600F8C9 RID: 63689 RVA: 0x0006D37D File Offset: 0x0006B57D
		' (set) Token: 0x0600F8CA RID: 63690 RVA: 0x0006D387 File Offset: 0x0006B587
		Friend Overridable Property Label33 As Label

		' Token: 0x17005F5B RID: 24411
		' (get) Token: 0x0600F8CB RID: 63691 RVA: 0x0006D390 File Offset: 0x0006B590
		' (set) Token: 0x0600F8CC RID: 63692 RVA: 0x0006D39A File Offset: 0x0006B59A
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17005F5C RID: 24412
		' (get) Token: 0x0600F8CD RID: 63693 RVA: 0x0006D3A3 File Offset: 0x0006B5A3
		' (set) Token: 0x0600F8CE RID: 63694 RVA: 0x0006D3AD File Offset: 0x0006B5AD
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17005F5D RID: 24413
		' (get) Token: 0x0600F8CF RID: 63695 RVA: 0x0006D3B6 File Offset: 0x0006B5B6
		' (set) Token: 0x0600F8D0 RID: 63696 RVA: 0x0006D3C0 File Offset: 0x0006B5C0
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17005F5E RID: 24414
		' (get) Token: 0x0600F8D1 RID: 63697 RVA: 0x0006D3C9 File Offset: 0x0006B5C9
		' (set) Token: 0x0600F8D2 RID: 63698 RVA: 0x0006D3D3 File Offset: 0x0006B5D3
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17005F5F RID: 24415
		' (get) Token: 0x0600F8D3 RID: 63699 RVA: 0x0006D3DC File Offset: 0x0006B5DC
		' (set) Token: 0x0600F8D4 RID: 63700 RVA: 0x0006D3E6 File Offset: 0x0006B5E6
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x0600F8D5 RID: 63701 RVA: 0x0094AC20 File Offset: 0x00948E20
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

		' Token: 0x0600F8D6 RID: 63702 RVA: 0x0094ACFC File Offset: 0x00948EFC
		Private Sub GetCompanyState()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(State) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TextBox1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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

		' Token: 0x0600F8D7 RID: 63703 RVA: 0x0094ADEC File Offset: 0x00948FEC
		Private Sub Sale()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Sum(TaxableAmt), Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS),(Sum(TaxableAmt)+Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)) from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID where TaxType='GST' and (CGST + SGST + IGST + CESS) > 0 and RTRIM(Customer.State)=@d3 and InvoiceDate between @d1 and @d2", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox1.Text.Trim())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F8D8 RID: 63704 RVA: 0x0094AFC8 File Offset: 0x009491C8
		Private Sub Sale2()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Sum(TaxableAmt), Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS),(Sum(TaxableAmt)+Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)) from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID where TaxType='GST' and (CGST + SGST + IGST + CESS) > 0 and NOT RTRIM(Customer.State)=@d3 and RTRIM(Customer.GSTIN)='' and InvoiceDate between @d1 and @d2", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox1.Text.Trim())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw3.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw3.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw3.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F8D9 RID: 63705 RVA: 0x0094B1A4 File Offset: 0x009493A4
		Private Sub Sale4()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Sum(TaxableAmt), Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS),(Sum(TaxableAmt)+Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)) from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID where TaxType='GST' and (CGST + SGST + IGST + CESS) > 0 and NOT RTRIM(Customer.State)=@d3 and RTRIM(Customer.GSTIN)>'' and InvoiceDate between @d1 and @d2", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox1.Text.Trim())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw5.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw5.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw5.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F8DA RID: 63706 RVA: 0x0094B380 File Offset: 0x00949580
		Private Sub Sale6()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Sum(TaxableAmt), Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS),(Sum(TaxableAmt)+Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)) from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID where TaxType='GST' and (CGST + SGST + IGST + CESS) = 0 and InvoiceDate between @d1 and @d2", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox1.Text.Trim())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw7.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw7.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw7.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F8DB RID: 63707 RVA: 0x0094B55C File Offset: 0x0094975C
		Private Sub Sale7()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Sum(TaxableAmt), Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS),(Sum(TaxableAmt)+Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)) from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID where TaxType='NON GST' and InvoiceDate between @d1 and @d2", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox1.Text.Trim())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw8.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw8.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw8.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F8DC RID: 63708 RVA: 0x0094B738 File Offset: 0x00949938
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Me.Sale()
			Me.Sale2()
			Me.Sale4()
			Me.Sale6()
			Me.Sale7()
			Me.Calculate()
			Me.Calculate1()
			Me.Calculate2()
			Me.Calculate3()
			Me.Calculate4()
			Me.Calculate5()
			Me.Pur()
			Me.Pur2()
			Me.Pur4()
			Me.Pur6()
			Me.Pur7()
			Me.Pur8()
			Me.Pur9()
			Me.Calculate6()
			Me.Calculate7()
			Me.Calculate8()
			Me.Calculate9()
			Me.Calculate10()
			Me.Calculate11()
			Me.SaleStatewise()
			Me.Calculate111()
		End Sub

		' Token: 0x0600F8DD RID: 63709 RVA: 0x0006D3EF File Offset: 0x0006B5EF
		Private Sub frmGSTR3B_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.GetCompanyState()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F8DE RID: 63710 RVA: 0x0094B7FC File Offset: 0x009499FC
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

		' Token: 0x0600F8DF RID: 63711 RVA: 0x0094B974 File Offset: 0x00949B74
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

		' Token: 0x0600F8E0 RID: 63712 RVA: 0x0094BA30 File Offset: 0x00949C30
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

		' Token: 0x0600F8E1 RID: 63713 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600F8E2 RID: 63714 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600F8E3 RID: 63715 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600F8E4 RID: 63716 RVA: 0x0094BAFC File Offset: 0x00949CFC
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Sale()
			Me.Sale2()
			Me.Sale4()
			Me.Sale6()
			Me.Sale7()
			Me.Calculate()
			Me.Calculate1()
			Me.Calculate2()
			Me.Calculate3()
			Me.Calculate4()
			Me.Calculate5()
			Me.Pur()
			Me.Pur2()
			Me.Pur4()
			Me.Pur6()
			Me.Pur7()
			Me.Pur8()
			Me.Pur9()
			Me.Calculate6()
			Me.Calculate7()
			Me.Calculate8()
			Me.Calculate9()
			Me.Calculate10()
			Me.Calculate11()
			Me.SaleStatewise()
			Me.Calculate111()
		End Sub

		' Token: 0x0600F8E5 RID: 63717 RVA: 0x0094BBD8 File Offset: 0x00949DD8
		Private Sub Calculate()
			Try
				Dim num2 As Double
				Dim num4 As Double
				Dim num6 As Double
				Dim num8 As Double
				Dim num10 As Double
				Dim num As Integer = Me.dgw.Rows.Count - 1
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column1").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column1").Value))
						End If

				Next
				Dim num3 As Integer = Me.dgw3.Rows.Count - 1
				For j As Integer = 0 To num3
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw3.Rows(j).Cells("DataGridViewTextBoxColumn13").Value))

						If flag2 Then
							num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw3.Rows(j).Cells("DataGridViewTextBoxColumn13").Value))
						End If

				Next
				Dim num5 As Integer = Me.dgw5.Rows.Count - 1
				For k As Integer = 0 To num5
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw5.Rows(k).Cells("DataGridViewTextBoxColumn49").Value))

						If flag3 Then
							num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw5.Rows(k).Cells("DataGridViewTextBoxColumn49").Value))
						End If

				Next
				Dim num7 As Integer = Me.dgw7.Rows.Count - 1
				For l As Integer = 0 To num7
					Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw7.Rows(l).Cells("DataGridViewTextBoxColumn73").Value))

						If flag4 Then
							num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw7.Rows(l).Cells("DataGridViewTextBoxColumn73").Value))
						End If

				Next
				Dim num9 As Integer = Me.dgw8.Rows.Count - 1
				For m As Integer = 0 To num9
					Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw8.Rows(m).Cells("DataGridViewTextBoxColumn61").Value))

						If flag5 Then
							num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw8.Rows(m).Cells("DataGridViewTextBoxColumn61").Value))
						End If

				Next
				Me.TextBox2.Text = Conversions.ToString(num2 + num4 + num6 + num8 + num10)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox2.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox2.Text), 2), "0.00")
		End Sub

		' Token: 0x0600F8E6 RID: 63718 RVA: 0x0094BF54 File Offset: 0x0094A154
		Private Sub Calculate1()
			Try
				Dim num2 As Double
				Dim num4 As Double
				Dim num6 As Double
				Dim num8 As Double
				Dim num10 As Double
				Dim num As Integer = Me.dgw.Rows.Count - 1
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column2").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column2").Value))
						End If

				Next
				Dim num3 As Integer = Me.dgw3.Rows.Count - 1
				For j As Integer = 0 To num3
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw3.Rows(j).Cells("DataGridViewTextBoxColumn14").Value))

						If flag2 Then
							num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw3.Rows(j).Cells("DataGridViewTextBoxColumn14").Value))
						End If

				Next
				Dim num5 As Integer = Me.dgw5.Rows.Count - 1
				For k As Integer = 0 To num5
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw5.Rows(k).Cells("DataGridViewTextBoxColumn50").Value))

						If flag3 Then
							num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw5.Rows(k).Cells("DataGridViewTextBoxColumn50").Value))
						End If

				Next
				Dim num7 As Integer = Me.dgw7.Rows.Count - 1
				For l As Integer = 0 To num7
					Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw7.Rows(l).Cells("DataGridViewTextBoxColumn74").Value))

						If flag4 Then
							num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw7.Rows(l).Cells("DataGridViewTextBoxColumn74").Value))
						End If

				Next
				Dim num9 As Integer = Me.dgw8.Rows.Count - 1
				For m As Integer = 0 To num9
					Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw8.Rows(m).Cells("DataGridViewTextBoxColumn62").Value))

						If flag5 Then
							num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw8.Rows(m).Cells("DataGridViewTextBoxColumn62").Value))
						End If

				Next
				Me.TextBox3.Text = Conversions.ToString(num2 + num4 + num6 + num8 + num10)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox3.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox3.Text), 2), "0.00")
		End Sub

		' Token: 0x0600F8E7 RID: 63719 RVA: 0x0094C2D0 File Offset: 0x0094A4D0
		Private Sub Calculate2()
			Try
				Dim num2 As Double
				Dim num4 As Double
				Dim num6 As Double
				Dim num8 As Double
				Dim num10 As Double
				Dim num As Integer = Me.dgw.Rows.Count - 1
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column3").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column3").Value))
						End If

				Next
				Dim num3 As Integer = Me.dgw3.Rows.Count - 1
				For j As Integer = 0 To num3
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw3.Rows(j).Cells("DataGridViewTextBoxColumn15").Value))

						If flag2 Then
							num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw3.Rows(j).Cells("DataGridViewTextBoxColumn15").Value))
						End If

				Next
				Dim num5 As Integer = Me.dgw5.Rows.Count - 1
				For k As Integer = 0 To num5
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw5.Rows(k).Cells("DataGridViewTextBoxColumn51").Value))

						If flag3 Then
							num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw5.Rows(k).Cells("DataGridViewTextBoxColumn51").Value))
						End If

				Next
				Dim num7 As Integer = Me.dgw7.Rows.Count - 1
				For l As Integer = 0 To num7
					Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw7.Rows(l).Cells("DataGridViewTextBoxColumn75").Value))

						If flag4 Then
							num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw7.Rows(l).Cells("DataGridViewTextBoxColumn75").Value))
						End If

				Next
				Dim num9 As Integer = Me.dgw8.Rows.Count - 1
				For m As Integer = 0 To num9
					Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw8.Rows(m).Cells("DataGridViewTextBoxColumn63").Value))

						If flag5 Then
							num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw8.Rows(m).Cells("DataGridViewTextBoxColumn63").Value))
						End If

				Next
				Me.TextBox4.Text = Conversions.ToString(num2 + num4 + num6 + num8 + num10)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox4.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox4.Text), 2), "0.00")
		End Sub

		' Token: 0x0600F8E8 RID: 63720 RVA: 0x0094C64C File Offset: 0x0094A84C
		Private Sub Calculate3()
			Try
				Dim num2 As Double
				Dim num4 As Double
				Dim num6 As Double
				Dim num8 As Double
				Dim num10 As Double
				Dim num As Integer = Me.dgw.Rows.Count - 1
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column4").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column4").Value))
						End If

				Next
				Dim num3 As Integer = Me.dgw3.Rows.Count - 1
				For j As Integer = 0 To num3
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw3.Rows(j).Cells("DataGridViewTextBoxColumn16").Value))

						If flag2 Then
							num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw3.Rows(j).Cells("DataGridViewTextBoxColumn16").Value))
						End If

				Next
				Dim num5 As Integer = Me.dgw5.Rows.Count - 1
				For k As Integer = 0 To num5
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw5.Rows(k).Cells("DataGridViewTextBoxColumn52").Value))

						If flag3 Then
							num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw5.Rows(k).Cells("DataGridViewTextBoxColumn52").Value))
						End If

				Next
				Dim num7 As Integer = Me.dgw7.Rows.Count - 1
				For l As Integer = 0 To num7
					Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw7.Rows(l).Cells("DataGridViewTextBoxColumn76").Value))

						If flag4 Then
							num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw7.Rows(l).Cells("DataGridViewTextBoxColumn76").Value))
						End If

				Next
				Dim num9 As Integer = Me.dgw8.Rows.Count - 1
				For m As Integer = 0 To num9
					Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw8.Rows(m).Cells("DataGridViewTextBoxColumn64").Value))

						If flag5 Then
							num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw8.Rows(m).Cells("DataGridViewTextBoxColumn64").Value))
						End If

				Next
				Me.TextBox5.Text = Conversions.ToString(num2 + num4 + num6 + num8 + num10)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox5.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox5.Text), 2), "0.00")
		End Sub

		' Token: 0x0600F8E9 RID: 63721 RVA: 0x0094C9C8 File Offset: 0x0094ABC8
		Private Sub Calculate4()
			Try
				Dim num2 As Double
				Dim num4 As Double
				Dim num6 As Double
				Dim num8 As Double
				Dim num10 As Double
				Dim num As Integer = Me.dgw.Rows.Count - 1
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column5").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column5").Value))
						End If

				Next
				Dim num3 As Integer = Me.dgw3.Rows.Count - 1
				For j As Integer = 0 To num3
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw3.Rows(j).Cells("DataGridViewTextBoxColumn17").Value))

						If flag2 Then
							num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw3.Rows(j).Cells("DataGridViewTextBoxColumn17").Value))
						End If

				Next
				Dim num5 As Integer = Me.dgw5.Rows.Count - 1
				For k As Integer = 0 To num5
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw5.Rows(k).Cells("DataGridViewTextBoxColumn53").Value))

						If flag3 Then
							num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw5.Rows(k).Cells("DataGridViewTextBoxColumn53").Value))
						End If

				Next
				Dim num7 As Integer = Me.dgw7.Rows.Count - 1
				For l As Integer = 0 To num7
					Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw7.Rows(l).Cells("DataGridViewTextBoxColumn77").Value))

						If flag4 Then
							num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw7.Rows(l).Cells("DataGridViewTextBoxColumn77").Value))
						End If

				Next
				Dim num9 As Integer = Me.dgw8.Rows.Count - 1
				For m As Integer = 0 To num9
					Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw8.Rows(m).Cells("DataGridViewTextBoxColumn65").Value))

						If flag5 Then
							num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw8.Rows(m).Cells("DataGridViewTextBoxColumn65").Value))
						End If

				Next
				Me.TextBox6.Text = Conversions.ToString(num2 + num4 + num6 + num8 + num10)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox6.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox6.Text), 2), "0.00")
		End Sub

		' Token: 0x0600F8EA RID: 63722 RVA: 0x0094CD44 File Offset: 0x0094AF44
		Private Sub Calculate5()
			Try
				Dim num2 As Double
				Dim num4 As Double
				Dim num6 As Double
				Dim num8 As Double
				Dim num10 As Double
				Dim num As Integer = Me.dgw.Rows.Count - 1
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column6").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column6").Value))
						End If

				Next
				Dim num3 As Integer = Me.dgw3.Rows.Count - 1
				For j As Integer = 0 To num3
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw3.Rows(j).Cells("DataGridViewTextBoxColumn18").Value))

						If flag2 Then
							num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw3.Rows(j).Cells("DataGridViewTextBoxColumn18").Value))
						End If

				Next
				Dim num5 As Integer = Me.dgw5.Rows.Count - 1
				For k As Integer = 0 To num5
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw5.Rows(k).Cells("DataGridViewTextBoxColumn54").Value))

						If flag3 Then
							num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw5.Rows(k).Cells("DataGridViewTextBoxColumn54").Value))
						End If

				Next
				Dim num7 As Integer = Me.dgw7.Rows.Count - 1
				For l As Integer = 0 To num7
					Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw7.Rows(l).Cells("DataGridViewTextBoxColumn78").Value))

						If flag4 Then
							num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw7.Rows(l).Cells("DataGridViewTextBoxColumn78").Value))
						End If

				Next
				Dim num9 As Integer = Me.dgw8.Rows.Count - 1
				For m As Integer = 0 To num9
					Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw8.Rows(m).Cells("DataGridViewTextBoxColumn66").Value))

						If flag5 Then
							num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw8.Rows(m).Cells("DataGridViewTextBoxColumn66").Value))
						End If

				Next
				Me.TextBox7.Text = Conversions.ToString(num2 + num4 + num6 + num8 + num10)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox7.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox7.Text), 2), "0.00")
		End Sub

		' Token: 0x0600F8EB RID: 63723 RVA: 0x0094D0C0 File Offset: 0x0094B2C0
		Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
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

		' Token: 0x0600F8EC RID: 63724 RVA: 0x0094D36C File Offset: 0x0094B56C
		Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim flag As Boolean = (Me.dgw3.Columns.Count = 0) Or (Me.dgw3.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw3.Columns
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
						For Each obj2 As Object In CType(Me.dgw3.Rows, IEnumerable)
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

		' Token: 0x0600F8ED RID: 63725 RVA: 0x0094D618 File Offset: 0x0094B818
		Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim flag As Boolean = (Me.dgw5.Columns.Count = 0) Or (Me.dgw5.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw5.Columns
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
						For Each obj2 As Object In CType(Me.dgw5.Rows, IEnumerable)
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

		' Token: 0x0600F8EE RID: 63726 RVA: 0x0094D8C4 File Offset: 0x0094BAC4
		Private Sub LinkLabel9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim flag As Boolean = (Me.dgw7.Columns.Count = 0) Or (Me.dgw7.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw7.Columns
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
						For Each obj2 As Object In CType(Me.dgw7.Rows, IEnumerable)
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

		' Token: 0x0600F8EF RID: 63727 RVA: 0x0094DB70 File Offset: 0x0094BD70
		Private Sub LinkLabel10_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim flag As Boolean = (Me.dgw8.Columns.Count = 0) Or (Me.dgw8.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw8.Columns
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
						For Each obj2 As Object In CType(Me.dgw8.Rows, IEnumerable)
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

		' Token: 0x0600F8F0 RID: 63728 RVA: 0x0094DE1C File Offset: 0x0094C01C
		Private Sub Pur()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Sum(TaxableAmt), Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS),(Sum(TaxableAmt)+Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)) from Stock LEFT Join Supplier ON Stock.SupplierID = Supplier.ID where TaxType='GST' and (CGST + SGST + IGST + CESS) > 0 and RTRIM(Supplier.GSTIN)>'' and Date between @d1 and @d2", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox1.Text.Trim())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgwp.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgwp.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgwp.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F8F1 RID: 63729 RVA: 0x0094DFF8 File Offset: 0x0094C1F8
		Private Sub Pur2()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Sum(TaxableAmt), Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS),(Sum(TaxableAmt)+Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)) from Stock LEFT Join Supplier ON Stock.SupplierID = Supplier.ID where TaxType='GST' and (CGST + SGST + IGST + CESS) > 0 and RTRIM(Supplier.GSTIN)='' and ReferenceNo2='Yes' and Date between @d1 and @d2", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox1.Text.Trim())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgwp2.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgwp2.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgwp2.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F8F2 RID: 63730 RVA: 0x0094E1D4 File Offset: 0x0094C3D4
		Private Sub Pur4()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Sum(TaxableAmt), Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS),(Sum(TaxableAmt)+Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)) from Stock LEFT Join Supplier ON Stock.SupplierID = Supplier.ID where TaxType='GST' and (CGST + SGST + IGST + CESS) > 0 and RTRIM(Supplier.GSTIN)='' and ReferenceNo2='No' and Date between @d1 and @d2", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox1.Text.Trim())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgwp4.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgwp4.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgwp4.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F8F3 RID: 63731 RVA: 0x0094E3B0 File Offset: 0x0094C5B0
		Private Sub Pur6()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Sum(TaxableAmt), Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS),(Sum(TaxableAmt)+Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)) from Stock LEFT Join Supplier ON Stock.SupplierID = Supplier.ID where TaxType='GST' and (CGST + SGST + IGST + CESS) = 0 and RTRIM(Supplier.GSTIN)>'' and RTRIM(Supplier.State)=@d3 and Date between @d1 and @d2", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox1.Text.Trim())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgwp6.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgwp6.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgwp6.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F8F4 RID: 63732 RVA: 0x0094E58C File Offset: 0x0094C78C
		Private Sub Pur7()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Sum(TaxableAmt), Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS),(Sum(TaxableAmt)+Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)) from Stock LEFT Join Supplier ON Stock.SupplierID = Supplier.ID where TaxType='GST' and (CGST + SGST + IGST + CESS) = 0 and RTRIM(Supplier.GSTIN)>'' and NOT RTRIM(Supplier.State)=@d3 and Date between @d1 and @d2", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox1.Text.Trim())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgwp7.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgwp7.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgwp7.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F8F5 RID: 63733 RVA: 0x0094E768 File Offset: 0x0094C968
		Private Sub Pur8()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Sum(TaxableAmt), Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS),(Sum(TaxableAmt)+Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)) from Stock LEFT Join Supplier ON Stock.SupplierID = Supplier.ID where TaxType='NON GST' and (CGST + SGST + IGST + CESS) = 0 and RTRIM(Supplier.State)=@d3 and Date between @d1 and @d2", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox1.Text.Trim())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgwp8.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgwp8.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgwp8.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F8F6 RID: 63734 RVA: 0x0094E944 File Offset: 0x0094CB44
		Private Sub Pur9()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Sum(TaxableAmt), Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS),(Sum(TaxableAmt)+Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)) from Stock LEFT Join Supplier ON Stock.SupplierID = Supplier.ID where TaxType='NON GST' and (CGST + SGST + IGST + CESS) = 0 and NOT RTRIM(Supplier.State)=@d3 and Date between @d1 and @d2", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox1.Text.Trim())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgwp9.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgwp9.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgwp9.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F8F7 RID: 63735 RVA: 0x0094EB20 File Offset: 0x0094CD20
		Private Sub Calculate6()
			Try
				Dim num2 As Double
				Dim num4 As Double
				Dim num6 As Double
				Dim num8 As Double
				Dim num10 As Double
				Dim num12 As Double
				Dim num15 As Double
				Dim num As Integer = Me.dgwp.Rows.Count - 1
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp.Rows(i).Cells("DataGridViewTextBoxColumn85").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp.Rows(i).Cells("DataGridViewTextBoxColumn85").Value))
						End If

				Next
				Dim num3 As Integer = Me.dgwp2.Rows.Count - 1
				For j As Integer = 0 To num3
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp2.Rows(j).Cells("DataGridViewTextBoxColumn121").Value))

						If flag2 Then
							num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp2.Rows(j).Cells("DataGridViewTextBoxColumn121").Value))
						End If

				Next
				Dim num5 As Integer = Me.dgwp4.Rows.Count - 1
				For k As Integer = 0 To num5
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp4.Rows(k).Cells("DataGridViewTextBoxColumn145").Value))

						If flag3 Then
							num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp4.Rows(k).Cells("DataGridViewTextBoxColumn145").Value))
						End If

				Next
				Dim num7 As Integer = Me.dgwp6.Rows.Count - 1
				For l As Integer = 0 To num7
					Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp6.Rows(l).Cells("DataGridViewTextBoxColumn169").Value))

						If flag4 Then
							num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp6.Rows(l).Cells("DataGridViewTextBoxColumn169").Value))
						End If

				Next
				Dim num9 As Integer = Me.dgwp7.Rows.Count - 1
				For m As Integer = 0 To num9
					Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp7.Rows(m).Cells("DataGridViewTextBoxColumn157").Value))

						If flag5 Then
							num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp7.Rows(m).Cells("DataGridViewTextBoxColumn157").Value))
						End If

				Next
				Dim num11 As Integer = Me.dgwp8.Rows.Count - 1
				For n As Integer = 0 To num11
					Dim flag6 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp8.Rows(n).Cells("DataGridViewTextBoxColumn181").Value))

						If flag6 Then
							num12 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp8.Rows(n).Cells("DataGridViewTextBoxColumn181").Value))
						End If

				Next
				Dim num13 As Integer = Me.dgwp9.Rows.Count - 1
				For num14 As Integer = 0 To num13
					Dim flag7 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp9.Rows(num14).Cells("DataGridViewTextBoxColumn193").Value))

						If flag7 Then
							num15 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp9.Rows(num14).Cells("DataGridViewTextBoxColumn193").Value))
						End If

				Next
				Me.TextBox8.Text = Conversions.ToString(num2 + num4 + num6 + num8 + num10 + num12 + num15)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox8.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox8.Text), 2), "0.00")
		End Sub

		' Token: 0x0600F8F8 RID: 63736 RVA: 0x0094EFCC File Offset: 0x0094D1CC
		Private Sub Calculate7()
			Try
				Dim num2 As Double
				Dim num4 As Double
				Dim num6 As Double
				Dim num8 As Double
				Dim num10 As Double
				Dim num12 As Double
				Dim num15 As Double
				Dim num As Integer = Me.dgwp.Rows.Count - 1
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp.Rows(i).Cells("DataGridViewTextBoxColumn86").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp.Rows(i).Cells("DataGridViewTextBoxColumn86").Value))
						End If

				Next
				Dim num3 As Integer = Me.dgwp2.Rows.Count - 1
				For j As Integer = 0 To num3
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp2.Rows(j).Cells("DataGridViewTextBoxColumn122").Value))

						If flag2 Then
							num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp2.Rows(j).Cells("DataGridViewTextBoxColumn122").Value))
						End If

				Next
				Dim num5 As Integer = Me.dgwp4.Rows.Count - 1
				For k As Integer = 0 To num5
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp4.Rows(k).Cells("DataGridViewTextBoxColumn146").Value))

						If flag3 Then
							num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp4.Rows(k).Cells("DataGridViewTextBoxColumn146").Value))
						End If

				Next
				Dim num7 As Integer = Me.dgwp6.Rows.Count - 1
				For l As Integer = 0 To num7
					Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp6.Rows(l).Cells("DataGridViewTextBoxColumn170").Value))

						If flag4 Then
							num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp6.Rows(l).Cells("DataGridViewTextBoxColumn170").Value))
						End If

				Next
				Dim num9 As Integer = Me.dgwp7.Rows.Count - 1
				For m As Integer = 0 To num9
					Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp7.Rows(m).Cells("DataGridViewTextBoxColumn158").Value))

						If flag5 Then
							num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp7.Rows(m).Cells("DataGridViewTextBoxColumn158").Value))
						End If

				Next
				Dim num11 As Integer = Me.dgwp8.Rows.Count - 1
				For n As Integer = 0 To num11
					Dim flag6 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp8.Rows(n).Cells("DataGridViewTextBoxColumn182").Value))

						If flag6 Then
							num12 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp8.Rows(n).Cells("DataGridViewTextBoxColumn182").Value))
						End If

				Next
				Dim num13 As Integer = Me.dgwp9.Rows.Count - 1
				For num14 As Integer = 0 To num13
					Dim flag7 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp9.Rows(num14).Cells("DataGridViewTextBoxColumn194").Value))

						If flag7 Then
							num15 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp9.Rows(num14).Cells("DataGridViewTextBoxColumn194").Value))
						End If

				Next
				Me.TextBox9.Text = Conversions.ToString(num2 + num4 + num6 + num8 + num10 + num12 + num15)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox9.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox9.Text), 2), "0.00")
		End Sub

		' Token: 0x0600F8F9 RID: 63737 RVA: 0x0094F478 File Offset: 0x0094D678
		Private Sub Calculate8()
			Try
				Dim num2 As Double
				Dim num4 As Double
				Dim num6 As Double
				Dim num8 As Double
				Dim num10 As Double
				Dim num12 As Double
				Dim num15 As Double
				Dim num As Integer = Me.dgwp.Rows.Count - 1
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp.Rows(i).Cells("DataGridViewTextBoxColumn87").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp.Rows(i).Cells("DataGridViewTextBoxColumn87").Value))
						End If

				Next
				Dim num3 As Integer = Me.dgwp2.Rows.Count - 1
				For j As Integer = 0 To num3
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp2.Rows(j).Cells("DataGridViewTextBoxColumn123").Value))

						If flag2 Then
							num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp2.Rows(j).Cells("DataGridViewTextBoxColumn123").Value))
						End If

				Next
				Dim num5 As Integer = Me.dgwp4.Rows.Count - 1
				For k As Integer = 0 To num5
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp4.Rows(k).Cells("DataGridViewTextBoxColumn147").Value))

						If flag3 Then
							num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp4.Rows(k).Cells("DataGridViewTextBoxColumn147").Value))
						End If

				Next
				Dim num7 As Integer = Me.dgwp6.Rows.Count - 1
				For l As Integer = 0 To num7
					Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp6.Rows(l).Cells("DataGridViewTextBoxColumn171").Value))

						If flag4 Then
							num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp6.Rows(l).Cells("DataGridViewTextBoxColumn171").Value))
						End If

				Next
				Dim num9 As Integer = Me.dgwp7.Rows.Count - 1
				For m As Integer = 0 To num9
					Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp7.Rows(m).Cells("DataGridViewTextBoxColumn159").Value))

						If flag5 Then
							num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp7.Rows(m).Cells("DataGridViewTextBoxColumn159").Value))
						End If

				Next
				Dim num11 As Integer = Me.dgwp8.Rows.Count - 1
				For n As Integer = 0 To num11
					Dim flag6 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp8.Rows(n).Cells("DataGridViewTextBoxColumn183").Value))

						If flag6 Then
							num12 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp8.Rows(n).Cells("DataGridViewTextBoxColumn183").Value))
						End If

				Next
				Dim num13 As Integer = Me.dgwp9.Rows.Count - 1
				For num14 As Integer = 0 To num13
					Dim flag7 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp9.Rows(num14).Cells("DataGridViewTextBoxColumn195").Value))

						If flag7 Then
							num15 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp9.Rows(num14).Cells("DataGridViewTextBoxColumn195").Value))
						End If

				Next
				Me.TextBox10.Text = Conversions.ToString(num2 + num4 + num6 + num8 + num10 + num12 + num15)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox10.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox10.Text), 2), "0.00")
		End Sub

		' Token: 0x0600F8FA RID: 63738 RVA: 0x0094F924 File Offset: 0x0094DB24
		Private Sub Calculate9()
			Try
				Dim num2 As Double
				Dim num4 As Double
				Dim num6 As Double
				Dim num8 As Double
				Dim num10 As Double
				Dim num12 As Double
				Dim num15 As Double
				Dim num As Integer = Me.dgwp.Rows.Count - 1
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp.Rows(i).Cells("DataGridViewTextBoxColumn88").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp.Rows(i).Cells("DataGridViewTextBoxColumn88").Value))
						End If

				Next
				Dim num3 As Integer = Me.dgwp2.Rows.Count - 1
				For j As Integer = 0 To num3
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp2.Rows(j).Cells("DataGridViewTextBoxColumn124").Value))

						If flag2 Then
							num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp2.Rows(j).Cells("DataGridViewTextBoxColumn124").Value))
						End If

				Next
				Dim num5 As Integer = Me.dgwp4.Rows.Count - 1
				For k As Integer = 0 To num5
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp4.Rows(k).Cells("DataGridViewTextBoxColumn148").Value))

						If flag3 Then
							num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp4.Rows(k).Cells("DataGridViewTextBoxColumn148").Value))
						End If

				Next
				Dim num7 As Integer = Me.dgwp6.Rows.Count - 1
				For l As Integer = 0 To num7
					Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp6.Rows(l).Cells("DataGridViewTextBoxColumn172").Value))

						If flag4 Then
							num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp6.Rows(l).Cells("DataGridViewTextBoxColumn172").Value))
						End If

				Next
				Dim num9 As Integer = Me.dgwp7.Rows.Count - 1
				For m As Integer = 0 To num9
					Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp7.Rows(m).Cells("DataGridViewTextBoxColumn160").Value))

						If flag5 Then
							num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp7.Rows(m).Cells("DataGridViewTextBoxColumn160").Value))
						End If

				Next
				Dim num11 As Integer = Me.dgwp8.Rows.Count - 1
				For n As Integer = 0 To num11
					Dim flag6 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp8.Rows(n).Cells("DataGridViewTextBoxColumn184").Value))

						If flag6 Then
							num12 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp8.Rows(n).Cells("DataGridViewTextBoxColumn184").Value))
						End If

				Next
				Dim num13 As Integer = Me.dgwp9.Rows.Count - 1
				For num14 As Integer = 0 To num13
					Dim flag7 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp9.Rows(num14).Cells("DataGridViewTextBoxColumn196").Value))

						If flag7 Then
							num15 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp9.Rows(num14).Cells("DataGridViewTextBoxColumn196").Value))
						End If

				Next
				Me.TextBox11.Text = Conversions.ToString(num2 + num4 + num6 + num8 + num10 + num12 + num15)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox11.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox11.Text), 2), "0.00")
		End Sub

		' Token: 0x0600F8FB RID: 63739 RVA: 0x0094FDD0 File Offset: 0x0094DFD0
		Private Sub Calculate10()
			Try
				Dim num2 As Double
				Dim num4 As Double
				Dim num6 As Double
				Dim num8 As Double
				Dim num10 As Double
				Dim num12 As Double
				Dim num15 As Double
				Dim num As Integer = Me.dgwp.Rows.Count - 1
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp.Rows(i).Cells("DataGridViewTextBoxColumn89").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp.Rows(i).Cells("DataGridViewTextBoxColumn89").Value))
						End If

				Next
				Dim num3 As Integer = Me.dgwp2.Rows.Count - 1
				For j As Integer = 0 To num3
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp2.Rows(j).Cells("DataGridViewTextBoxColumn125").Value))

						If flag2 Then
							num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp2.Rows(j).Cells("DataGridViewTextBoxColumn125").Value))
						End If

				Next
				Dim num5 As Integer = Me.dgwp4.Rows.Count - 1
				For k As Integer = 0 To num5
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp4.Rows(k).Cells("DataGridViewTextBoxColumn149").Value))

						If flag3 Then
							num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp4.Rows(k).Cells("DataGridViewTextBoxColumn149").Value))
						End If

				Next
				Dim num7 As Integer = Me.dgwp6.Rows.Count - 1
				For l As Integer = 0 To num7
					Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp6.Rows(l).Cells("DataGridViewTextBoxColumn173").Value))

						If flag4 Then
							num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp6.Rows(l).Cells("DataGridViewTextBoxColumn173").Value))
						End If

				Next
				Dim num9 As Integer = Me.dgwp7.Rows.Count - 1
				For m As Integer = 0 To num9
					Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp7.Rows(m).Cells("DataGridViewTextBoxColumn161").Value))

						If flag5 Then
							num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp7.Rows(m).Cells("DataGridViewTextBoxColumn161").Value))
						End If

				Next
				Dim num11 As Integer = Me.dgwp8.Rows.Count - 1
				For n As Integer = 0 To num11
					Dim flag6 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp8.Rows(n).Cells("DataGridViewTextBoxColumn185").Value))

						If flag6 Then
							num12 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp8.Rows(n).Cells("DataGridViewTextBoxColumn185").Value))
						End If

				Next
				Dim num13 As Integer = Me.dgwp9.Rows.Count - 1
				For num14 As Integer = 0 To num13
					Dim flag7 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp9.Rows(num14).Cells("DataGridViewTextBoxColumn197").Value))

						If flag7 Then
							num15 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp9.Rows(num14).Cells("DataGridViewTextBoxColumn197").Value))
						End If

				Next
				Me.TextBox12.Text = Conversions.ToString(num2 + num4 + num6 + num8 + num10 + num12 + num15)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox12.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox12.Text), 2), "0.00")
		End Sub

		' Token: 0x0600F8FC RID: 63740 RVA: 0x0095027C File Offset: 0x0094E47C
		Private Sub Calculate11()
			Try
				Dim num2 As Double
				Dim num4 As Double
				Dim num6 As Double
				Dim num8 As Double
				Dim num10 As Double
				Dim num12 As Double
				Dim num15 As Double
				Dim num As Integer = Me.dgwp.Rows.Count - 1
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp.Rows(i).Cells("DataGridViewTextBoxColumn90").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp.Rows(i).Cells("DataGridViewTextBoxColumn90").Value))
						End If

				Next
				Dim num3 As Integer = Me.dgwp2.Rows.Count - 1
				For j As Integer = 0 To num3
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp2.Rows(j).Cells("DataGridViewTextBoxColumn126").Value))

						If flag2 Then
							num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp2.Rows(j).Cells("DataGridViewTextBoxColumn126").Value))
						End If

				Next
				Dim num5 As Integer = Me.dgwp4.Rows.Count - 1
				For k As Integer = 0 To num5
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp4.Rows(k).Cells("DataGridViewTextBoxColumn150").Value))

						If flag3 Then
							num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp4.Rows(k).Cells("DataGridViewTextBoxColumn150").Value))
						End If

				Next
				Dim num7 As Integer = Me.dgwp6.Rows.Count - 1
				For l As Integer = 0 To num7
					Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp6.Rows(l).Cells("DataGridViewTextBoxColumn174").Value))

						If flag4 Then
							num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp6.Rows(l).Cells("DataGridViewTextBoxColumn174").Value))
						End If

				Next
				Dim num9 As Integer = Me.dgwp7.Rows.Count - 1
				For m As Integer = 0 To num9
					Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp7.Rows(m).Cells("DataGridViewTextBoxColumn162").Value))

						If flag5 Then
							num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp7.Rows(m).Cells("DataGridViewTextBoxColumn162").Value))
						End If

				Next
				Dim num11 As Integer = Me.dgwp8.Rows.Count - 1
				For n As Integer = 0 To num11
					Dim flag6 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp8.Rows(n).Cells("DataGridViewTextBoxColumn186").Value))

						If flag6 Then
							num12 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp8.Rows(n).Cells("DataGridViewTextBoxColumn186").Value))
						End If

				Next
				Dim num13 As Integer = Me.dgwp9.Rows.Count - 1
				For num14 As Integer = 0 To num13
					Dim flag7 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgwp9.Rows(num14).Cells("DataGridViewTextBoxColumn198").Value))

						If flag7 Then
							num15 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgwp9.Rows(num14).Cells("DataGridViewTextBoxColumn198").Value))
						End If

				Next
				Me.TextBox13.Text = Conversions.ToString(num2 + num4 + num6 + num8 + num10 + num12 + num15)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox13.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox13.Text), 2), "0.00")
		End Sub

		' Token: 0x0600F8FD RID: 63741 RVA: 0x00950728 File Offset: 0x0094E928
		Private Sub LinkLabel12_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim flag As Boolean = (Me.dgwp.Columns.Count = 0) Or (Me.dgwp.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgwp.Columns
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
						For Each obj2 As Object In CType(Me.dgwp.Rows, IEnumerable)
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

		' Token: 0x0600F8FE RID: 63742 RVA: 0x009509D4 File Offset: 0x0094EBD4
		Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim flag As Boolean = (Me.dgwp2.Columns.Count = 0) Or (Me.dgwp2.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgwp2.Columns
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
						For Each obj2 As Object In CType(Me.dgwp2.Rows, IEnumerable)
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

		' Token: 0x0600F8FF RID: 63743 RVA: 0x00950C80 File Offset: 0x0094EE80
		Private Sub LinkLabel15_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim flag As Boolean = (Me.dgwp4.Columns.Count = 0) Or (Me.dgwp4.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgwp4.Columns
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
						For Each obj2 As Object In CType(Me.dgwp4.Rows, IEnumerable)
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

		' Token: 0x0600F900 RID: 63744 RVA: 0x00950F2C File Offset: 0x0094F12C
		Private Sub LinkLabel16_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim flag As Boolean = (Me.dgwp6.Columns.Count = 0) Or (Me.dgwp6.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgwp6.Columns
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
						For Each obj2 As Object In CType(Me.dgwp6.Rows, IEnumerable)
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

		' Token: 0x0600F901 RID: 63745 RVA: 0x009511D8 File Offset: 0x0094F3D8
		Private Sub LinkLabel17_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim flag As Boolean = (Me.dgwp7.Columns.Count = 0) Or (Me.dgwp7.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgwp7.Columns
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
						For Each obj2 As Object In CType(Me.dgwp7.Rows, IEnumerable)
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

		' Token: 0x0600F902 RID: 63746 RVA: 0x00951484 File Offset: 0x0094F684
		Private Sub LinkLabel18_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim flag As Boolean = (Me.dgwp8.Columns.Count = 0) Or (Me.dgwp8.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgwp8.Columns
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
						For Each obj2 As Object In CType(Me.dgwp8.Rows, IEnumerable)
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

		' Token: 0x0600F903 RID: 63747 RVA: 0x00951730 File Offset: 0x0094F930
		Private Sub LinkLabel19_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim flag As Boolean = (Me.dgwp9.Columns.Count = 0) Or (Me.dgwp9.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgwp9.Columns
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
						For Each obj2 As Object In CType(Me.dgwp9.Rows, IEnumerable)
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

		' Token: 0x0600F904 RID: 63748 RVA: 0x009519DC File Offset: 0x0094FBDC
		Private Sub SaleStatewise()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(TaxType), RTRIM(Customer.State),RTRIM(Customer.GSTIN),TaxableAmt, IGST  from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where (CGST + SGST)=0 and IGST > 0 and NOT RTRIM(Customer.State)=@d3 and RTRIM(TaxType)='GST' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox1.Text.Trim())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim text As String = ModCommonClasses.rdr(2).ToString()
					Dim flag As Boolean = Operators.CompareString(text, "", False) = 0
					If flag Then
						Me.suppliertype = "Unregistered"
					Else
						Dim flag2 As Boolean = Operators.CompareString(text, "", False) > 0
						If flag2 Then
							Me.suppliertype = "Registered"
						End If
					End If
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), Me.suppliertype, ModCommonClasses.rdr(3), ModCommonClasses.rdr(4) })
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView1.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F905 RID: 63749 RVA: 0x00951C00 File Offset: 0x0094FE00
		Private Sub Calculate111()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.DataGridView1.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("Column18").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("Column18").Value))
						End If

				Next
				Dim num3 As Integer = Me.DataGridView1.Rows.Count - 1
				Dim num4 As Double
				For j As Integer = 0 To num3
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(j).Cells("Column21").Value))

						If flag2 Then
							num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(j).Cells("Column21").Value))
						End If

				Next
				Me.TextBox15.Text = Conversions.ToString(num2)
				Me.TextBox14.Text = Conversions.ToString(num4)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox15.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox15.Text), 2), "0.00")
			Me.TextBox14.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox14.Text), 2), "0.00")
		End Sub

		' Token: 0x0600F906 RID: 63750 RVA: 0x00951DF4 File Offset: 0x0094FFF4
		Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim flag As Boolean = (Me.DataGridView1.Columns.Count = 0) Or (Me.DataGridView1.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.DataGridView1.Columns
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
						For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
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

		' Token: 0x0600F907 RID: 63751 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmGSTR3B_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x04005F4B RID: 24395
		Private suppliertype As String
	End Class
End Namespace
