Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Linq
Imports System.Management
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports DevNet.GS
Imports Microsoft.SqlServer.Management.Common
Imports Microsoft.SqlServer.Management.Sdk.Sfc
Imports Microsoft.SqlServer.Management.Smo
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005D6 RID: 1494
	<DesignerGenerated()>
	Public Partial Class frmCompany
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060124A0 RID: 74912 RVA: 0x00A83988 File Offset: 0x00A81B88
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmRegistration_Load
			AddHandler MyBase.Closing, AddressOf Me.frmCompany_Closing
			AddHandler MyBase.KeyDown, AddressOf Me.frmCompany_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17007188 RID: 29064
		' (get) Token: 0x060124A3 RID: 74915 RVA: 0x0007D6E8 File Offset: 0x0007B8E8
		' (set) Token: 0x060124A4 RID: 74916 RVA: 0x0007D6F2 File Offset: 0x0007B8F2
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17007189 RID: 29065
		' (get) Token: 0x060124A5 RID: 74917 RVA: 0x0007D6FB File Offset: 0x0007B8FB
		' (set) Token: 0x060124A6 RID: 74918 RVA: 0x0007D705 File Offset: 0x0007B905
		Friend Overridable Property Panel4 As Panel

		' Token: 0x1700718A RID: 29066
		' (get) Token: 0x060124A7 RID: 74919 RVA: 0x0007D70E File Offset: 0x0007B90E
		' (set) Token: 0x060124A8 RID: 74920 RVA: 0x0007D718 File Offset: 0x0007B918
		Friend Overridable Property Label3 As Label

		' Token: 0x1700718B RID: 29067
		' (get) Token: 0x060124A9 RID: 74921 RVA: 0x0007D721 File Offset: 0x0007B921
		' (set) Token: 0x060124AA RID: 74922 RVA: 0x00A85BD4 File Offset: 0x00A83DD4
		Private _txtCompanyName As TextBox
		Friend Overridable Property txtCompanyName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCompanyName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCompanyName_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtCompanyName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtCompanyName = value
				textBox = Me._txtCompanyName
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700718C RID: 29068
		' (get) Token: 0x060124AB RID: 74923 RVA: 0x0007D72B File Offset: 0x0007B92B
		' (set) Token: 0x060124AC RID: 74924 RVA: 0x0007D735 File Offset: 0x0007B935
		Friend Overridable Property Panel2 As Panel

		' Token: 0x1700718D RID: 29069
		' (get) Token: 0x060124AD RID: 74925 RVA: 0x0007D73E File Offset: 0x0007B93E
		' (set) Token: 0x060124AE RID: 74926 RVA: 0x0007D748 File Offset: 0x0007B948
		Friend Overridable Property Label1 As Label

		' Token: 0x1700718E RID: 29070
		' (get) Token: 0x060124AF RID: 74927 RVA: 0x0007D751 File Offset: 0x0007B951
		' (set) Token: 0x060124B0 RID: 74928 RVA: 0x0007D75B File Offset: 0x0007B95B
		Friend Overridable Property Label7 As Label

		' Token: 0x1700718F RID: 29071
		' (get) Token: 0x060124B1 RID: 74929 RVA: 0x0007D764 File Offset: 0x0007B964
		' (set) Token: 0x060124B2 RID: 74930 RVA: 0x0007D76E File Offset: 0x0007B96E
		Friend Overridable Property Label6 As Label

		' Token: 0x17007190 RID: 29072
		' (get) Token: 0x060124B3 RID: 74931 RVA: 0x0007D777 File Offset: 0x0007B977
		' (set) Token: 0x060124B4 RID: 74932 RVA: 0x0007D781 File Offset: 0x0007B981
		Friend Overridable Property Label5 As Label

		' Token: 0x17007191 RID: 29073
		' (get) Token: 0x060124B5 RID: 74933 RVA: 0x0007D78A File Offset: 0x0007B98A
		' (set) Token: 0x060124B6 RID: 74934 RVA: 0x00A85C34 File Offset: 0x00A83E34
		Private _txtGSTIN As TextBox
		Friend Overridable Property txtGSTIN As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtGSTIN
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtGSTIN_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.txtGSTIN_TextChanged
				Dim textBox As TextBox = Me._txtGSTIN
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtGSTIN = value
				textBox = Me._txtGSTIN
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007192 RID: 29074
		' (get) Token: 0x060124B7 RID: 74935 RVA: 0x0007D794 File Offset: 0x0007B994
		' (set) Token: 0x060124B8 RID: 74936 RVA: 0x00A85C94 File Offset: 0x00A83E94
		Private _txtEmailID As TextBox
		Friend Overridable Property txtEmailID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtEmailID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtEmailID_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtEmailID_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtEmailID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtEmailID = value
				textBox = Me._txtEmailID
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007193 RID: 29075
		' (get) Token: 0x060124B9 RID: 74937 RVA: 0x0007D79E File Offset: 0x0007B99E
		' (set) Token: 0x060124BA RID: 74938 RVA: 0x00A85D10 File Offset: 0x00A83F10
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

		' Token: 0x17007194 RID: 29076
		' (get) Token: 0x060124BB RID: 74939 RVA: 0x0007D7A8 File Offset: 0x0007B9A8
		' (set) Token: 0x060124BC RID: 74940 RVA: 0x0007D7B2 File Offset: 0x0007B9B2
		Friend Overridable Property Label4 As Label

		' Token: 0x17007195 RID: 29077
		' (get) Token: 0x060124BD RID: 74941 RVA: 0x0007D7BB File Offset: 0x0007B9BB
		' (set) Token: 0x060124BE RID: 74942 RVA: 0x0007D7C5 File Offset: 0x0007B9C5
		Friend Overridable Property Label2 As Label

		' Token: 0x17007196 RID: 29078
		' (get) Token: 0x060124BF RID: 74943 RVA: 0x0007D7CE File Offset: 0x0007B9CE
		' (set) Token: 0x060124C0 RID: 74944 RVA: 0x0007D7D8 File Offset: 0x0007B9D8
		Friend Overridable Property txtID As TextBox

		' Token: 0x17007197 RID: 29079
		' (get) Token: 0x060124C1 RID: 74945 RVA: 0x0007D7E1 File Offset: 0x0007B9E1
		' (set) Token: 0x060124C2 RID: 74946 RVA: 0x0007D7EB File Offset: 0x0007B9EB
		Friend Overridable Property lblUser As Label

		' Token: 0x17007198 RID: 29080
		' (get) Token: 0x060124C3 RID: 74947 RVA: 0x0007D7F4 File Offset: 0x0007B9F4
		' (set) Token: 0x060124C4 RID: 74948 RVA: 0x00A85D8C File Offset: 0x00A83F8C
		Private _btnBrowse As Button
		Public Overridable Property btnBrowse As Button
			<CompilerGenerated()>
			Get
				Return Me._btnBrowse
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnBrowse_Click
				Dim button As Button = Me._btnBrowse
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnBrowse = value
				button = Me._btnBrowse
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007199 RID: 29081
		' (get) Token: 0x060124C5 RID: 74949 RVA: 0x0007D7FE File Offset: 0x0007B9FE
		' (set) Token: 0x060124C6 RID: 74950 RVA: 0x0007D808 File Offset: 0x0007BA08
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x1700719A RID: 29082
		' (get) Token: 0x060124C7 RID: 74951 RVA: 0x0007D811 File Offset: 0x0007BA11
		' (set) Token: 0x060124C8 RID: 74952 RVA: 0x00A85DD0 File Offset: 0x00A83FD0
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

		' Token: 0x1700719B RID: 29083
		' (get) Token: 0x060124C9 RID: 74953 RVA: 0x0007D81B File Offset: 0x0007BA1B
		' (set) Token: 0x060124CA RID: 74954 RVA: 0x00A85E30 File Offset: 0x00A84030
		Private _txtCIN As TextBox
		Friend Overridable Property txtCIN As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCIN
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCIN_KeyDown
				Dim textBox As TextBox = Me._txtCIN
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCIN = value
				textBox = Me._txtCIN
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700719C RID: 29084
		' (get) Token: 0x060124CB RID: 74955 RVA: 0x0007D825 File Offset: 0x0007BA25
		' (set) Token: 0x060124CC RID: 74956 RVA: 0x0007D82F File Offset: 0x0007BA2F
		Friend Overridable Property Label8 As Label

		' Token: 0x1700719D RID: 29085
		' (get) Token: 0x060124CD RID: 74957 RVA: 0x0007D838 File Offset: 0x0007BA38
		' (set) Token: 0x060124CE RID: 74958 RVA: 0x0007D842 File Offset: 0x0007BA42
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x1700719E RID: 29086
		' (get) Token: 0x060124CF RID: 74959 RVA: 0x0007D84B File Offset: 0x0007BA4B
		' (set) Token: 0x060124D0 RID: 74960 RVA: 0x00A85E74 File Offset: 0x00A84074
		Private _cmbState As ComboBox
		Friend Overridable Property cmbState As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbState
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbState_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbState
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbState = value
				comboBox = Me._cmbState
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700719F RID: 29087
		' (get) Token: 0x060124D1 RID: 74961 RVA: 0x0007D855 File Offset: 0x0007BA55
		' (set) Token: 0x060124D2 RID: 74962 RVA: 0x00A85ED4 File Offset: 0x00A840D4
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

		' Token: 0x170071A0 RID: 29088
		' (get) Token: 0x060124D3 RID: 74963 RVA: 0x0007D85F File Offset: 0x0007BA5F
		' (set) Token: 0x060124D4 RID: 74964 RVA: 0x00A85F18 File Offset: 0x00A84118
		Private _Button5 As Button
		Friend Overridable Property Button5 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button5_Click
				Dim button As Button = Me._Button5
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button5 = value
				button = Me._Button5
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170071A1 RID: 29089
		' (get) Token: 0x060124D5 RID: 74965 RVA: 0x0007D869 File Offset: 0x0007BA69
		' (set) Token: 0x060124D6 RID: 74966 RVA: 0x0007D873 File Offset: 0x0007BA73
		Friend Overridable Property txtEmail As TextBox

		' Token: 0x170071A2 RID: 29090
		' (get) Token: 0x060124D7 RID: 74967 RVA: 0x0007D87C File Offset: 0x0007BA7C
		' (set) Token: 0x060124D8 RID: 74968 RVA: 0x0007D886 File Offset: 0x0007BA86
		Friend Overridable Property txtCompanyID As TextBox

		' Token: 0x170071A3 RID: 29091
		' (get) Token: 0x060124D9 RID: 74969 RVA: 0x0007D88F File Offset: 0x0007BA8F
		' (set) Token: 0x060124DA RID: 74970 RVA: 0x0007D899 File Offset: 0x0007BA99
		Friend Overridable Property lblSet As Label

		' Token: 0x170071A4 RID: 29092
		' (get) Token: 0x060124DB RID: 74971 RVA: 0x0007D8A2 File Offset: 0x0007BAA2
		' (set) Token: 0x060124DC RID: 74972 RVA: 0x00A85F5C File Offset: 0x00A8415C
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

		' Token: 0x170071A5 RID: 29093
		' (get) Token: 0x060124DD RID: 74973 RVA: 0x0007D8AC File Offset: 0x0007BAAC
		' (set) Token: 0x060124DE RID: 74974 RVA: 0x0007D8B6 File Offset: 0x0007BAB6
		Friend Overridable Property TabControl1 As TabControl

		' Token: 0x170071A6 RID: 29094
		' (get) Token: 0x060124DF RID: 74975 RVA: 0x0007D8BF File Offset: 0x0007BABF
		' (set) Token: 0x060124E0 RID: 74976 RVA: 0x0007D8C9 File Offset: 0x0007BAC9
		Friend Overridable Property TabPage1 As TabPage

		' Token: 0x170071A7 RID: 29095
		' (get) Token: 0x060124E1 RID: 74977 RVA: 0x0007D8D2 File Offset: 0x0007BAD2
		' (set) Token: 0x060124E2 RID: 74978 RVA: 0x0007D8DC File Offset: 0x0007BADC
		Friend Overridable Property Label13 As Label

		' Token: 0x170071A8 RID: 29096
		' (get) Token: 0x060124E3 RID: 74979 RVA: 0x0007D8E5 File Offset: 0x0007BAE5
		' (set) Token: 0x060124E4 RID: 74980 RVA: 0x0007D8EF File Offset: 0x0007BAEF
		Friend Overridable Property Label15 As Label

		' Token: 0x170071A9 RID: 29097
		' (get) Token: 0x060124E5 RID: 74981 RVA: 0x0007D8F8 File Offset: 0x0007BAF8
		' (set) Token: 0x060124E6 RID: 74982 RVA: 0x0007D902 File Offset: 0x0007BB02
		Friend Overridable Property Label14 As Label

		' Token: 0x170071AA RID: 29098
		' (get) Token: 0x060124E7 RID: 74983 RVA: 0x0007D90B File Offset: 0x0007BB0B
		' (set) Token: 0x060124E8 RID: 74984 RVA: 0x00A85FA0 File Offset: 0x00A841A0
		Private _DateTimePicker2 As DateTimePicker
		Friend Overridable Property DateTimePicker2 As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._DateTimePicker2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DateTimePicker2_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._DateTimePicker2
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._DateTimePicker2 = value
				dateTimePicker = Me._DateTimePicker2
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170071AB RID: 29099
		' (get) Token: 0x060124E9 RID: 74985 RVA: 0x0007D915 File Offset: 0x0007BB15
		' (set) Token: 0x060124EA RID: 74986 RVA: 0x00A85FE4 File Offset: 0x00A841E4
		Private _DateTimePicker1 As DateTimePicker
		Friend Overridable Property DateTimePicker1 As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._DateTimePicker1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DateTimePicker1_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._DateTimePicker1
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._DateTimePicker1 = value
				dateTimePicker = Me._DateTimePicker1
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170071AC RID: 29100
		' (get) Token: 0x060124EB RID: 74987 RVA: 0x0007D91F File Offset: 0x0007BB1F
		' (set) Token: 0x060124EC RID: 74988 RVA: 0x0007D929 File Offset: 0x0007BB29
		Friend Overridable Property DateTimePicker3 As DateTimePicker

		' Token: 0x170071AD RID: 29101
		' (get) Token: 0x060124ED RID: 74989 RVA: 0x0007D932 File Offset: 0x0007BB32
		' (set) Token: 0x060124EE RID: 74990 RVA: 0x00A86028 File Offset: 0x00A84228
		Private _txtCity As TextBox
		Friend Overridable Property txtCity As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCity
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox1_KeyDown
				Dim textBox As TextBox = Me._txtCity
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCity = value
				textBox = Me._txtCity
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170071AE RID: 29102
		' (get) Token: 0x060124EF RID: 74991 RVA: 0x0007D93C File Offset: 0x0007BB3C
		' (set) Token: 0x060124F0 RID: 74992 RVA: 0x0007D946 File Offset: 0x0007BB46
		Friend Overridable Property Label17 As Label

		' Token: 0x170071AF RID: 29103
		' (get) Token: 0x060124F1 RID: 74993 RVA: 0x0007D94F File Offset: 0x0007BB4F
		' (set) Token: 0x060124F2 RID: 74994 RVA: 0x00A8606C File Offset: 0x00A8426C
		Private _txtWeb As TextBox
		Friend Overridable Property txtWeb As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtWeb
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtWeb_KeyDown
				Dim textBox As TextBox = Me._txtWeb
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtWeb = value
				textBox = Me._txtWeb
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170071B0 RID: 29104
		' (get) Token: 0x060124F3 RID: 74995 RVA: 0x0007D959 File Offset: 0x0007BB59
		' (set) Token: 0x060124F4 RID: 74996 RVA: 0x0007D963 File Offset: 0x0007BB63
		Friend Overridable Property Label18 As Label

		' Token: 0x170071B1 RID: 29105
		' (get) Token: 0x060124F5 RID: 74997 RVA: 0x0007D96C File Offset: 0x0007BB6C
		' (set) Token: 0x060124F6 RID: 74998 RVA: 0x0007D976 File Offset: 0x0007BB76
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x170071B2 RID: 29106
		' (get) Token: 0x060124F7 RID: 74999 RVA: 0x0007D97F File Offset: 0x0007BB7F
		' (set) Token: 0x060124F8 RID: 75000 RVA: 0x0007D989 File Offset: 0x0007BB89
		Friend Overridable Property Label9 As Label

		' Token: 0x170071B3 RID: 29107
		' (get) Token: 0x060124F9 RID: 75001 RVA: 0x0007D992 File Offset: 0x0007BB92
		' (set) Token: 0x060124FA RID: 75002 RVA: 0x00A860B0 File Offset: 0x00A842B0
		Private _txtCurrencySymb As TextBox
		Friend Overridable Property txtCurrencySymb As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCurrencySymb
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCurrencySymb_KeyDown
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtCurrencySymb_KeyPress
				Dim textBox As TextBox = Me._txtCurrencySymb
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._txtCurrencySymb = value
				textBox = Me._txtCurrencySymb
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x170071B4 RID: 29108
		' (get) Token: 0x060124FB RID: 75003 RVA: 0x0007D99C File Offset: 0x0007BB9C
		' (set) Token: 0x060124FC RID: 75004 RVA: 0x0007D9A6 File Offset: 0x0007BBA6
		Friend Overridable Property lbl_Result As Label

		' Token: 0x170071B5 RID: 29109
		' (get) Token: 0x060124FD RID: 75005 RVA: 0x0007D9AF File Offset: 0x0007BBAF
		' (set) Token: 0x060124FE RID: 75006 RVA: 0x0007D9B9 File Offset: 0x0007BBB9
		Friend Overridable Property Label10 As Label

		' Token: 0x170071B6 RID: 29110
		' (get) Token: 0x060124FF RID: 75007 RVA: 0x0007D9C2 File Offset: 0x0007BBC2
		' (set) Token: 0x06012500 RID: 75008 RVA: 0x0007D9CC File Offset: 0x0007BBCC
		Friend Overridable Property txtLoyality As TextBox

		' Token: 0x170071B7 RID: 29111
		' (get) Token: 0x06012501 RID: 75009 RVA: 0x0007D9D5 File Offset: 0x0007BBD5
		' (set) Token: 0x06012502 RID: 75010 RVA: 0x0007D9DF File Offset: 0x0007BBDF
		Friend Overridable Property lblProgress As Label

		' Token: 0x170071B8 RID: 29112
		' (get) Token: 0x06012503 RID: 75011 RVA: 0x0007D9E8 File Offset: 0x0007BBE8
		' (set) Token: 0x06012504 RID: 75012 RVA: 0x0007D9F2 File Offset: 0x0007BBF2
		Friend Overridable Property ProgressBar1 As ProgressBar

		' Token: 0x06012505 RID: 75013 RVA: 0x00A86110 File Offset: 0x00A84310
		Private Sub FYDate()
			Dim year As Integer = Me.DateTimePicker3.Value.Year
			Me.DateTimePicker1.Value = DateTimePicker.MinimumDateTime
			Me.DateTimePicker1.Value = New DateTime(year, 4, 1)
			Me.DateTimePicker2.Value = DateTimePicker.MinimumDateTime
			Me.DateTimePicker2.Value = New DateTime(year + 1, 3, 31)
		End Sub

		' Token: 0x06012506 RID: 75014 RVA: 0x00A86180 File Offset: 0x00A84380
		Private Sub auto()
			Try
				ModCommonClasses.con = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT MAX(ID) FROM RaintechMaster"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim flag As Boolean = Microsoft.VisualBasic.Information.IsDBNull(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(ModCommonClasses.cmd.ExecuteScalar())))
				Dim flag2 As Boolean = flag
				If flag2 Then
					Dim num As Integer = 1
					Me.txtCompanyID.Text = num.ToString()
				Else
					Dim num2 As Integer = Conversions.ToInteger(RuntimeHelpers.GetObjectValue(Operators.AddObject(RuntimeHelpers.GetObjectValue(ModCommonClasses.cmd.ExecuteScalar()), 1)))
					Me.txtCompanyID.Text = num2.ToString()
				End If
				ModCommonClasses.cmd.Dispose()
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012507 RID: 75015 RVA: 0x00A86298 File Offset: 0x00A84498
		Public Sub Reset()
			Me.FYDate()
			Me.cmbState.SelectedIndex = -1
			Me.txtGSTIN.Text = ""
			Me.txtEmailID.Text = ""
			Me.txtContactNo.Text = ""
			Me.txtCompanyName.Text = ""
			Me.txtCIN.Text = ""
			Me.txtAddress.Text = ""
			Me.PictureBox1.Image = Resources.Nologo
			Me.txtCompanyName.Focus()
			Me.Button3.Enabled = True
			Me.txtCurrencySymb.Text = "₹"
			Me.txtLoyality.Text = "0.10"
		End Sub

		' Token: 0x06012508 RID: 75016 RVA: 0x00A8636C File Offset: 0x00A8456C
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			Me.ProgressBar1.Visible = True
			Me.lblProgress.Visible = True
			Try
				Dim flag As Boolean = Operators.CompareString(Me.txtCompanyName.Text, "", False) = 0
				Dim flag2 As Boolean = Operators.CompareString(Me.txtCurrencySymb.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please enter currency symbol", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtCurrencySymb.Focus()
				Else
					Dim flag3 As Boolean = flag
					If flag3 Then
						MessageBox.Show("Please enter company name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtCompanyName.Focus()
					Else
						flag = Operators.CompareString(Me.txtAddress.Text, "", False) = 0
						Dim flag4 As Boolean = flag
						If flag4 Then
							MessageBox.Show("Please enter address", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtAddress.Focus()
						Else
							flag = Operators.CompareString(Me.cmbState.Text, "", False) = 0
							Dim flag5 As Boolean = flag
							If flag5 Then
								MessageBox.Show("Please select state", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.cmbState.Focus()
							Else
								flag = Operators.CompareString(Me.txtContactNo.Text, "", False) = 0
								Dim flag6 As Boolean = flag
								If flag6 Then
									MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtContactNo.Focus()
								Else
									flag = Operators.CompareString(Me.txtEmailID.Text, "", False) = 0
									Dim flag7 As Boolean = flag
									If flag7 Then
										MessageBox.Show("Please enter email id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtEmailID.Focus()
									Else
										Try
											ModCommonClasses.con = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
											ModCommonClasses.con.Open()
											Dim text As String = "select * from RaintechMaster where CompanyName=@d1"
											ModCommonClasses.cmd = New SqlCommand(text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCompanyName.Text)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											flag = ModCommonClasses.rdr.Read()
											Dim flag8 As Boolean = flag
											If flag8 Then
												MessageBox.Show("Company name already exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
												flag = ModCommonClasses.rdr IsNot Nothing
												Dim flag9 As Boolean = flag
												If flag9 Then
													ModCommonClasses.rdr.Close()
												End If
											Else
												ModCommonClasses.con.Close()
												Me.Cursor = Cursors.WaitCursor
												Me.Timer1.Enabled = True
												Me.auto()
												File.WriteAllText(Application.StartupPath + "\TempDBSettings.dat", "")
												Dim streamWriter As StreamWriter = New StreamWriter(Application.StartupPath + "\TempDBSettings.dat")
												Try
													streamWriter.WriteLine("Raintech_DB" + Conversions.ToString(Conversion.Val(Me.txtCompanyID.Text)))
													streamWriter.Close()
												Finally
													flag = streamWriter IsNot Nothing
													Dim flag10 As Boolean = flag
													If flag10 Then
														CType(streamWriter, IDisposable).Dispose()
													End If
												End Try
												Dim array As String() = File.ReadAllLines(Application.StartupPath + "\SQLSettings.dat")
												Me.ServerName = array(0)
												Dim text2 As String = "Data source= " + Me.ServerName + ";Initial Catalog=master;Integrated Security=True;"
												ModCommonClasses.con = New SqlConnection(text2)
												ModCommonClasses.con.Open()
												Dim text3 As String = "Create Database Raintech_DB" + Conversions.ToString(Conversion.Val(Me.txtCompanyID.Text))
												ModCommonClasses.cmd = New SqlCommand(text3)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.ExecuteNonQuery()
												ModCommonClasses.con.Close()
												Dim streamReader As StreamReader = New StreamReader(Application.StartupPath + "\DBScript.sql")
												Try
													Me.st = "USE Raintech_DB" + Conversions.ToString(Conversion.Val(Me.txtCompanyID.Text)) + vbCrLf + streamReader.ReadToEnd()
													Dim server As Server = New Server(New ServerConnection(ModCommonClasses.con))
													server.ConnectionContext.ExecuteNonQuery(Me.st)
												Finally
													flag = streamReader IsNot Nothing
													Dim flag11 As Boolean = flag
													If flag11 Then
														CType(streamReader, IDisposable).Dispose()
													End If
												End Try
												ModCommonClasses.con = New SqlConnection(text2)
												ModCommonClasses.con.Open()
												Dim text4 As String = "ALTER DATABASE Raintech_DB" + Conversions.ToString(Conversion.Val(Me.txtCompanyID.Text)) + "  SET READ_WRITE"
												ModCommonClasses.cmd = New SqlCommand(text4)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.ExecuteNonQuery()
												ModCommonClasses.con.Close()
												ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
												ModCommonClasses.con.Open()
												Dim text5 As String = "insert into company(companyName, Address, ContactNo, EmailID, GSTIN, State, CIN, Logo,FYFrom,FYTo,City,Web,Bankholder,Bankacno,Bankname,Bankifsc,AndroidID,CurSym,Loyality_perpoint) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19)"
												ModCommonClasses.cmd = New SqlCommand(text5)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCompanyName.Text).ToString()
												ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtAddress.Text).ToString()
												ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtContactNo.Text).ToString()
												ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtEmailID.Text).ToString()
												ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtGSTIN.Text).ToString()
												ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.cmbState.Text).ToString()
												ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtCIN.Text).ToString()
												ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.DateTimePicker1.Value.[Date])
												ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.DateTimePicker2.Value.[Date])
												ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.txtCity.Text).ToString()
												ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.txtWeb.Text).ToString()
												ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "").ToString()
												ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "").ToString()
												ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "").ToString()
												ModCommonClasses.cmd.Parameters.AddWithValue("@d16", "").ToString()
												ModCommonClasses.cmd.Parameters.AddWithValue("@d17", "Disabled").ToString()
												ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Me.txtCurrencySymb.Text).ToString()
												Dim flag12 As Boolean = Me.txtLoyality.Text = Nothing
												If flag12 Then
													ModCommonClasses.cmd.Parameters.AddWithValue("@d19", 0)
												Else
													ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Me.txtLoyality.Text)
												End If
												Dim memoryStream As MemoryStream = New MemoryStream()
												Dim bitmap As Bitmap = New Bitmap(Me.PictureBox1.Image)
												bitmap.Save(memoryStream, ImageFormat.Jpeg)
												Dim buffer As Byte() = memoryStream.GetBuffer()
												Dim sqlParameter As SqlParameter = New SqlParameter("@d8", SqlDbType.Image)
												sqlParameter.Value = buffer
												ModCommonClasses.cmd.Parameters.Add(sqlParameter)
												ModCommonClasses.cmd.ExecuteNonQuery()
												ModCommonClasses.con.Close()
												Dim text7 As String
												Try
													Dim managementObjectSearcher As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")
													Try
														For Each managementBaseObject As ManagementBaseObject In managementObjectSearcher.[Get]()
															Dim managementObject As ManagementObject = CType(managementBaseObject, ManagementObject)
															Dim text6 As String = Conversions.ToString(managementObject("SerialNumber"))
															text7 = ModFunc.MD5Encrypt("Raintech_DB" + Conversions.ToString(Conversion.Val(Me.txtCompanyID.Text)) + Strings.StrReverse(text6))
														Next
													Finally
														Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator
														If enumerator IsNot Nothing Then
															CType(enumerator, IDisposable).Dispose()
														End If
													End Try
												Catch ex As Exception
													MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
												End Try
												ModCommonClasses.con = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
												ModCommonClasses.con.Open()
												Dim text8 As String = "insert into RaintechMaster(ID,CompanyName,DBName, Online_DBName,company_id) VALUES (@d1,@d2,@d3, @d4,@d5)"
												ModCommonClasses.cmd = New SqlCommand(text8)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtCompanyID.Text))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtCompanyName.Text).ToString()
												ModCommonClasses.cmd.Parameters.AddWithValue("@d3", "Raintech_DB" + Conversions.ToString(Conversion.Val(Me.txtCompanyID.Text)))
												Dim text9 As String = DateTime.Now.ToString("yyyyMMddHHmmss")
												Dim text10 As String = "Raintech_DB" + Conversions.ToString(Conversion.Val(Me.txtCompanyID.Text))
												Dim text11 As String = text10 + "_" + text9
												ModCommonClasses.cmd.Parameters.AddWithValue("@d4", text11)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d5", text7.ToString())
												ModCommonClasses.cmd.ExecuteNonQuery()
												ModCommonClasses.con.Close()
												ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
												ModCommonClasses.con.Open()
												Dim text12 As String = "update Customer set State=@d1 where ID='1' and Name='Cash'"
												ModCommonClasses.cmd = New SqlCommand(text12)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbState.Text)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.ExecuteNonQuery()
												ModCommonClasses.con.Close()
												MessageBox.Show("Successfully Created..." & vbCrLf & "Application will be closed,Please start it again", "Company", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
												ProjectData.EndApp()
											End If
										Catch ex2 As Exception
											MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										End Try
									End If
								End If
							End If
						End If
					End If
				End If
			Catch ex3 As Exception
				MessageBox.Show(ex3.ToString() + "CREATE BTTON")
			End Try
		End Sub

		' Token: 0x06012509 RID: 75017 RVA: 0x00204688 File Offset: 0x00202888
		Public Function CreateDatabaseIfNotExists(serverConnStrWithoutDB As String, databaseName As String) As Boolean
			Dim flag2 As Boolean
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(serverConnStrWithoutDB)
					sqlConnection.Open()
					Dim sqlCommand As SqlCommand = New SqlCommand(String.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName), sqlConnection)
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar())
					Dim flag As Boolean = objectValue Is Nothing
					If flag Then
						Dim sqlCommand2 As SqlCommand = New SqlCommand(String.Format("CREATE DATABASE [{0}]", databaseName), sqlConnection)
						sqlCommand2.ExecuteNonQuery()
						flag2 = True
					Else
						MessageBox.Show("✅ Already Exist!," + databaseName)
						flag2 = False
					End If
				End Using
			Catch ex As Exception
				MessageBox.Show("DB Check/Create Error: " + ex.Message)
				flag2 = False
			End Try
			Return flag2
		End Function

		' Token: 0x0601250A RID: 75018 RVA: 0x00911E08 File Offset: 0x00910008
		Public Sub AddAndPopulateSyncGuidAndIsRemoteColumn(connectionString As String)
			Using sqlConnection As SqlConnection = New SqlConnection(connectionString)
				sqlConnection.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", sqlConnection)
				Dim sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
				Dim list As List(Of String) = New List(Of String)()
				While sqlDataReader.Read()
					list.Add(sqlDataReader("TABLE_NAME").ToString())
				End While
				sqlDataReader.Close()
				Try
					For Each text As String In list
						Dim sqlCommand2 As SqlCommand = New SqlCommand(String.Format("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' AND COLUMN_NAME = 'is_remote'", text), sqlConnection)
						Dim flag As Boolean = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand2.ExecuteScalar())) > 0
						Dim flag2 As Boolean = Not flag
						If flag2 Then
							Dim sqlCommand3 As SqlCommand = New SqlCommand(String.Format("ALTER TABLE [{0}] ADD is_remote BIT DEFAULT 0", text), sqlConnection)
							sqlCommand3.ExecuteNonQuery()
							Console.WriteLine(String.Format("✅ Added is_remote to table: {0}", text))
						Else
							Console.WriteLine(String.Format("ℹ️ is_remote already exists in table: {0}", text))
						End If
						Dim sqlCommand4 As SqlCommand = New SqlCommand(String.Format("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' AND COLUMN_NAME = 'SyncGuid'", text), sqlConnection)
						Dim flag3 As Boolean = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand4.ExecuteScalar())) > 0
						Dim flag4 As Boolean = Not flag3
						If flag4 Then
							Dim sqlCommand5 As SqlCommand = New SqlCommand(String.Format("ALTER TABLE [{0}] ADD SyncGuid UNIQUEIDENTIFIER DEFAULT NEWID()", text), sqlConnection)
							sqlCommand5.ExecuteNonQuery()
							Console.WriteLine(String.Format("✅ Added SyncGuid to table: {0}", text))
						Else
							Console.WriteLine(String.Format("ℹ️ SyncGuid already exists in table: {0}", text))
						End If
						Dim sqlCommand6 As SqlCommand = New SqlCommand(String.Format("UPDATE [{0}] SET SyncGuid = NEWID() WHERE SyncGuid IS NULL", text), sqlConnection)
						Dim num As Integer = sqlCommand6.ExecuteNonQuery()
						Dim flag5 As Boolean = num > 0
						If flag5 Then
							Console.WriteLine(String.Format("🔄 Updated {0} NULL SyncGuid values in: {1}", num, text))
						End If
						Dim sqlCommand7 As SqlCommand = New SqlCommand(String.Format("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' AND COLUMN_NAME = 'Version'", text), sqlConnection)
						Dim flag6 As Boolean = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand7.ExecuteScalar())) > 0
						Dim flag7 As Boolean = Not flag6
						If flag7 Then
							Dim sqlCommand8 As SqlCommand = New SqlCommand(String.Format("ALTER TABLE [{0}] ADD Version ROWVERSION", text), sqlConnection)
							sqlCommand8.ExecuteNonQuery()
							Console.WriteLine(String.Format("✅ Added Version (ROWVERSION) to table: {0}", text))
						Else
							Console.WriteLine(String.Format("ℹ️ Version column already exists in table: {0}", text))
						End If
					Next
				Finally
					Dim enumerator As List(Of String).Enumerator
					CType(enumerator, IDisposable).Dispose()
				End Try
				sqlConnection.Close()
			End Using
		End Sub

		' Token: 0x0601250B RID: 75019 RVA: 0x009120A0 File Offset: 0x009102A0
		Public Sub DatabaseScheme_Create(localConnStr As String, remoteConnStr As String, datbaseName As String)
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(localConnStr)
				Dim server As Server = New Server(New ServerConnection(sqlConnection))
				Dim database As Database = server.Databases(datbaseName)
				Dim sqlConnection2 As SqlConnection = New SqlConnection(remoteConnStr)
				Dim server2 As Server = New Server(New ServerConnection(sqlConnection2))
				Dim scripter As Scripter = New Scripter(server)
				scripter.Options.ScriptData = False
				scripter.Options.ScriptSchema = True
				scripter.Options.WithDependencies = False
				scripter.Options.DriAll = True
				scripter.Options.Indexes = True
				scripter.Options.SchemaQualify = True
				scripter.Options.IncludeHeaders = True
				Dim list As List(Of Urn) = New List(Of Urn)()
				Try
					For Each obj As Object In database.Tables
						Dim table As Table = CType(obj, Table)
						Dim flag As Boolean = Not table.IsSystemObject
						If flag Then
							list.Add(table.Urn)
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim stringCollection As StringCollection = scripter.Script(list.ToArray())
				Dim list2 As List(Of String) = stringCollection.Cast(Of String)().ToList()
				Try
					For Each text As String In list2
						Dim flag2 As Boolean = Not String.IsNullOrWhiteSpace(text)
						If flag2 Then
							Dim text2 As String = Regex.Replace(text, "(?i)(\[Version\]\s+)([^\s,]+)", "$1NVARCHAR(200)")
							server2.ConnectionContext.ExecuteNonQuery(text2)
						End If
					Next
				Finally
					Dim enumerator2 As List(Of String).Enumerator
					CType(enumerator2, IDisposable).Dispose()
				End Try
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x0601250C RID: 75020 RVA: 0x00A86F0C File Offset: 0x00A8510C
		Public Shared Function GetTableMigrationOrder(con As SqlConnection) As List(Of String)
			Dim dependencies As New Dictionary(Of String, List(Of String))()
			Dim allTables As New HashSet(Of String)()
			Dim sqlCommand As New SqlCommand("SELECT fk.name AS FK_Name, tp.name AS ParentTable, tr.name AS ChildTable FROM sys.foreign_keys fk INNER JOIN sys.tables tp ON fk.referenced_object_id = tp.object_id INNER JOIN sys.tables tr ON fk.parent_object_id = tr.object_id", con)
			Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
				While sqlDataReader.Read()
					Dim parentTable As String = sqlDataReader("ParentTable").ToString()
					Dim childTable As String = sqlDataReader("ChildTable").ToString()
					If Not dependencies.ContainsKey(childTable) Then
						dependencies(childTable) = New List(Of String)()
					End If
					dependencies(childTable).Add(parentTable)
					allTables.Add(parentTable)
					allTables.Add(childTable)
				End While
			End Using
			Dim sqlCommand2 As New SqlCommand("SELECT name FROM sys.tables", con)
			Using sqlDataReader2 As SqlDataReader = sqlCommand2.ExecuteReader()
				While sqlDataReader2.Read()
					allTables.Add(sqlDataReader2("name").ToString())
				End While
			End Using
			Dim visited As New HashSet(Of String)()
			Dim result As New List(Of String)()
			Dim visitAction As Action(Of String) = Nothing
			visitAction = Sub(t As String)
				If Not visited.Contains(t) Then
					visited.Add(t)
					If dependencies.ContainsKey(t) Then
						For Each dep As String In dependencies(t)
							visitAction(dep)
						Next
					End If
					result.Add(t)
				End If
			End Sub
			For Each table As String In allTables
				visitAction(table)
			Next
			Return result.Distinct().ToList()
		End Function

		' Token: 0x0601250D RID: 75021 RVA: 0x00A870DC File Offset: 0x00A852DC
		Public Shared Sub MigrateAllInOrder(localConStr As String, remoteConStr As String)
			Dim dictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)()
			Using sqlConnection As SqlConnection = New SqlConnection(localConStr)
				Using sqlConnection2 As SqlConnection = New SqlConnection(remoteConStr)
					sqlConnection.Open()
					sqlConnection2.Open()
					Dim tableMigrationOrder As List(Of String) = frmCompany.GetTableMigrationOrder(sqlConnection)
					Try
						For Each text As String In tableMigrationOrder
							Console.WriteLine("Migrating: " + text)
						Next
					Finally
						Dim enumerator As List(Of String).Enumerator
						CType(enumerator, IDisposable).Dispose()
					End Try
				End Using
			End Using
		End Sub

		' Token: 0x0601250E RID: 75022 RVA: 0x00A8719C File Offset: 0x00A8539C
		Private Sub MigrateInitialRows(tableName As String, tableKeys As Dictionary(Of String, String), localCon As SqlConnection, remoteCon As SqlConnection)
			' The following expression was wrapped in a checked-statement
			Try
				Dim dictionary As Dictionary(Of String, Type) = New Dictionary(Of String, Type)()
				Dim hashSet As HashSet(Of String) = New HashSet(Of String)()
				Using sqlCommand As SqlCommand = New SqlCommand(String.Format("SELECT TOP 0 * FROM [{0}]", tableName), remoteCon)
					Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SchemaOnly)
						Dim schemaTable As DataTable = sqlDataReader.GetSchemaTable()
						Try
							For Each obj As Object In schemaTable.Rows
								Dim dataRow As DataRow = CType(obj, DataRow)
								Dim text As String = dataRow("ColumnName").ToString()
								dictionary(text) = CType(dataRow("DataType"), Type)
								Dim flag As Boolean = schemaTable.Columns.Contains("IsIdentity") AndAlso Conversions.ToBoolean(dataRow("IsIdentity"))
								If flag Then
									hashSet.Add(text)
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
					End Using
				End Using
				Dim sqlCommand2 As SqlCommand = New SqlCommand(String.Format("SELECT * FROM [{0}] WHERE ISNULL(is_remote, 0) = 0", tableName), localCon)
				Dim sqlDataReader2 As SqlDataReader = sqlCommand2.ExecuteReader()
				While sqlDataReader2.Read()
					Dim flag2 As Boolean = (Operators.CompareString(tableName, "EmailCache", False) <> 0) And (Operators.CompareString(tableName, "Language_set", False) <> 0)
					If flag2 Then
						Dim cols As New List(Of String)()
						Dim list As List(Of String) = New List(Of String)()
						Dim list2 As List(Of SqlParameter) = New List(Of SqlParameter)()
						Dim text2 As String = sqlDataReader2("SyncGuid").ToString()
						Dim num As Integer = sqlDataReader2.FieldCount - 1
						For i As Integer = 0 To num
							Dim name As String = sqlDataReader2.GetName(i)
							Dim flag3 As Boolean = Operators.CompareString(name.ToLower(), "is_remote", False) <> 0
							If flag3 Then
								cols.Add("[" + name + "]")
								list.Add("@" + name)
								Dim objectValue As Object = RuntimeHelpers.GetObjectValue(sqlDataReader2(name))
								Dim sqlParameter As SqlParameter = New SqlParameter("@" + name, RuntimeHelpers.GetObjectValue(If((objectValue IsNot Nothing AndAlso objectValue IsNot DBNull.Value), objectValue, DBNull.Value)))
								Dim flag4 As Boolean = objectValue IsNot Nothing AndAlso objectValue IsNot DBNull.Value
								If flag4 Then
									Dim flag5 As Boolean = dictionary.ContainsKey(name)
									If flag5 Then
										Dim type As Type = dictionary(name)
										Dim flag6 As Boolean = Operators.CompareString(name, "Version", False) = 0 AndAlso type Is GetType(String) AndAlso TypeOf objectValue Is Byte()
										If flag6 Then
											Dim array As Byte() = CType(objectValue, Byte())
											sqlParameter.Value = BitConverter.ToString(array).Replace("-", "")
											sqlParameter.SqlDbType = SqlDbType.NVarChar
										End If
									End If
								End If
								list2.Add(sqlParameter)
							End If
						Next
						Try
							Dim flag7 As Boolean = False
							Dim flag8 As Boolean = hashSet.Any(Function(ic As String) cols.Any(Function(col As String) col.Trim("["c, "]"c).Equals(ic, StringComparison.OrdinalIgnoreCase)))
							If flag8 Then
								Dim sqlCommand3 As SqlCommand = New SqlCommand(String.Format("SET IDENTITY_INSERT [{0}] ON", tableName), remoteCon)
								sqlCommand3.ExecuteNonQuery()
								flag7 = True
							End If
							Dim text3 As String = String.Format("INSERT INTO [{0}] ({1}) VALUES ({2})", tableName, String.Join(",", cols), String.Join(",", list))
							Dim sqlCommand4 As SqlCommand = New SqlCommand(text3, remoteCon)
							sqlCommand4.Parameters.AddRange(list2.ToArray())
							sqlCommand4.ExecuteNonQuery()
							Dim flag9 As Boolean = flag7
							If flag9 Then
								Dim sqlCommand5 As SqlCommand = New SqlCommand(String.Format("SET IDENTITY_INSERT [{0}] OFF", tableName), remoteCon)
								sqlCommand5.ExecuteNonQuery()
							End If
							Using sqlCommand6 As SqlCommand = New SqlCommand(String.Format("UPDATE [{0}] SET is_remote = 1 WHERE SyncGuid = @sync", tableName), localCon)
								sqlCommand6.Parameters.AddWithValue("@sync", text2)
								sqlCommand6.ExecuteNonQuery()
							End Using
						Catch ex As Exception
							Debug.WriteLine(String.Format("❌ Error inserting into {0}: {1}", tableName, ex.Message))
						End Try
					End If
				End While
				sqlDataReader2.Close()
			Catch ex2 As Exception
				MessageBox.Show("❌ Error in initial migration for table " + tableName + ": " + ex2.Message)
			End Try
		End Sub

		' Token: 0x0601250F RID: 75023 RVA: 0x00A8768C File Offset: 0x00A8588C
		Public Sub Migrate_Data(localConnStr As String, onlineConnStr As String)
			Dim dictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(localConnStr)
					Using sqlConnection2 As SqlConnection = New SqlConnection(onlineConnStr)
						sqlConnection.Open()
						sqlConnection2.Open()
						Dim tableMigrationOrder As List(Of String) = frmCompany.GetTableMigrationOrder(sqlConnection)
						Try
							For Each text As String In tableMigrationOrder
								Me.MigrateInitialRows(text, dictionary, sqlConnection, sqlConnection2)
								Console.WriteLine("Migrating: " + text)
							Next
						Finally
							Dim enumerator As List(Of String).Enumerator
							CType(enumerator, IDisposable).Dispose()
						End Try
						MessageBox.Show("✅ Sync completed successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("❌ Error during sync: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012510 RID: 75024 RVA: 0x000D8784 File Offset: 0x000D6984
		Private Function GetSqlDbTypeFromType(type As Type) As SqlDbType
			Dim flag As Boolean = type Is GetType(Integer)
			Dim sqlDbType As SqlDbType
			If flag Then
				sqlDbType = SqlDbType.Int
			Else
				Dim flag2 As Boolean = type Is GetType(String)
				If flag2 Then
					sqlDbType = SqlDbType.NVarChar
				Else
					Dim flag3 As Boolean = type Is GetType(DateTime)
					If flag3 Then
						sqlDbType = SqlDbType.DateTime
					Else
						Dim flag4 As Boolean = type Is GetType(Boolean)
						If flag4 Then
							sqlDbType = SqlDbType.Bit
						Else
							Dim flag5 As Boolean = type Is GetType(Decimal)
							If flag5 Then
								sqlDbType = SqlDbType.[Decimal]
							Else
								Dim flag6 As Boolean = type Is GetType(Double)
								If flag6 Then
									sqlDbType = SqlDbType.Float
								Else
									Dim flag7 As Boolean = type Is GetType(Byte())
									If flag7 Then
										sqlDbType = SqlDbType.Image
									Else
										Dim flag8 As Boolean = type Is GetType(Guid)
										If flag8 Then
											sqlDbType = SqlDbType.UniqueIdentifier
										Else
											Dim flag9 As Boolean = type Is GetType(Long)
											If flag9 Then
												sqlDbType = SqlDbType.BigInt
											Else
												Dim flag10 As Boolean = type Is GetType(Short)
												If flag10 Then
													sqlDbType = SqlDbType.SmallInt
												Else
													sqlDbType = SqlDbType.[Variant]
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			End If
			Return sqlDbType
		End Function

		' Token: 0x06012511 RID: 75025 RVA: 0x0007D9FB File Offset: 0x0007BBFB
		Private Sub Button5_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06012512 RID: 75026 RVA: 0x0007DA05 File Offset: 0x0007BC05
		Private Sub frmRegistration_Load(sender As Object, e As EventArgs)
			Me.FYDate()
			Me.txtCompanyName.Focus()
		End Sub

		' Token: 0x06012513 RID: 75027 RVA: 0x00A877AC File Offset: 0x00A859AC
		Private Sub btnBrowse_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
				openFileDialog.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;*.ico;"
				openFileDialog.FilterIndex = 4
				Me.OpenFileDialog1.FileName = ""
				Dim flag As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
				If flag Then
					Me.PictureBox1.Image = Image.FromFile(Me.OpenFileDialog1.FileName)
				End If
			Catch ex As Exception
				Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x06012514 RID: 75028 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Button1_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06012515 RID: 75029 RVA: 0x00A8784C File Offset: 0x00A85A4C
		Private Sub txtContactNo_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "+", False) <> 0 AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "-", False) <> 0 AndAlso e.KeyChar <> vbBack
			If flag Then
			End If
		End Sub

		' Token: 0x06012516 RID: 75030 RVA: 0x00A878B4 File Offset: 0x00A85AB4
		Private Sub txtEmailID_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim text As String = "@"
			Dim flag As Boolean = e.KeyChar <> vbBack
			If flag Then
				Dim flag2 As Boolean = (Strings.Asc(e.KeyChar) < 97) Or (Strings.Asc(e.KeyChar) > 122)
				If flag2 Then
					Dim flag3 As Boolean = (Strings.Asc(e.KeyChar) <> 46) And (Strings.Asc(e.KeyChar) <> 95)
					If flag3 Then
						Dim flag4 As Boolean = (Strings.Asc(e.KeyChar) < 48) Or (Strings.Asc(e.KeyChar) > 57)
						If flag4 Then
							Dim flag5 As Boolean = text.IndexOf(e.KeyChar) = -1
							If flag5 Then
								e.Handled = True
							Else
								Dim flag6 As Boolean = Me.txtEmailID.Text.Contains("@") And (Operators.CompareString(Conversions.ToString(e.KeyChar), "@", False) = 0)
								If flag6 Then
									e.Handled = True
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06012517 RID: 75031 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub txtEmailID_Validating(sender As Object, e As CancelEventArgs)
		End Sub

		' Token: 0x06012518 RID: 75032 RVA: 0x0007DA1B File Offset: 0x0007BC1B
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06012519 RID: 75033 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCompanyName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601251A RID: 75034 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub txtAddress_KeyDown(sender As Object, e As KeyEventArgs)
		End Sub

		' Token: 0x0601251B RID: 75035 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbState_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601251C RID: 75036 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtContactNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601251D RID: 75037 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtEmailID_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601251E RID: 75038 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtGSTIN_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601251F RID: 75039 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCIN_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012520 RID: 75040 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub DateTimePicker1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012521 RID: 75041 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub DateTimePicker2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012522 RID: 75042 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012523 RID: 75043 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtWeb_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012524 RID: 75044 RVA: 0x00A879BC File Offset: 0x00A85BBC
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Private Sub frmCompany_Closing(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblSet.Text, "Main Form", False) = 0
			Dim flag2 As Boolean = flag
			If flag2 Then
				ProjectData.EndApp()
			Else
				ProjectData.EndApp()
			End If
		End Sub

		' Token: 0x06012525 RID: 75045 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCompany_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06012526 RID: 75046 RVA: 0x00A879FC File Offset: 0x00A85BFC
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtEmailID.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtEmailID, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtEmailID, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtContactNo.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtContactNo, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtContactNo, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.txtCompanyName.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.txtCompanyName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtCompanyName, String.Empty)
			End If
			Dim flag4 As Boolean = String.IsNullOrEmpty(Me.txtAddress.Text.Trim())
			If flag4 Then
				Me.ErrorProvider1.SetError(Me.txtAddress, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtAddress, String.Empty)
			End If
			Dim flag5 As Boolean = String.IsNullOrEmpty(Me.cmbState.Text.Trim())
			If flag5 Then
				Me.ErrorProvider1.SetError(Me.cmbState, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbState, String.Empty)
			End If
		End Sub

		' Token: 0x06012527 RID: 75047 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCurrencySymb_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012528 RID: 75048 RVA: 0x00A87B88 File Offset: 0x00A85D88
		Private Sub txtCurrencySymb_KeyPress(sender As Object, e As KeyPressEventArgs)
			Me.txtCurrencySymb.MaxLength = 3
			Dim flag As Boolean = Versioned.IsNumeric(e.KeyChar) AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x06012529 RID: 75049 RVA: 0x00A87BD4 File Offset: 0x00A85DD4
		Private Async Sub txtGSTIN_TextChanged(sender As Object, e As EventArgs)
			Dim validator As GSTINValidator = New GSTINValidator()
			Try
				Dim result As Dictionary(Of String, String) = Await validator.ValidateGSTINAsync(Me.txtGSTIN.Text)
				If result.ContainsKey("Error") Then
					Me.lbl_Result.ForeColor = Color.Red
					Me.lbl_Result.Text = "Invalid GSTIN!"
				Else
					Dim dictionary As Dictionary(Of String, String) = result
					Dim text As String = "State"
					Dim text2 As String = ""
					Dim strState As String = If(dictionary.TryGetValue(text, text2), result("State"), "NA")
					If Operators.CompareString(strState, "Not Available", False) = 0 Then
						Me.lbl_Result.ForeColor = Color.Red
						Me.lbl_Result.Text = "Invalid GSTIN!"
					Else
						Me.lbl_Result.ForeColor = Color.Green
						Me.lbl_Result.Text = "Valid GSTIN."
					End If
				End If
			Catch ex As Exception
				Me.lbl_Result.ForeColor = Color.Red
				Me.lbl_Result.Text = ex.Message
			End Try
		End Sub

		' Token: 0x04006E1B RID: 28187
		Private st As String

		' Token: 0x04006E1C RID: 28188
		Private ServerName As String
	End Class
End Namespace
