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
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004E7 RID: 1255
	<DesignerGenerated()>
	Public Partial Class frmTransport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06010064 RID: 65636 RVA: 0x00070719 File Offset: 0x0006E919
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmTransport_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmTransport_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170061F5 RID: 25077
		' (get) Token: 0x06010067 RID: 65639 RVA: 0x0007074B File Offset: 0x0006E94B
		' (set) Token: 0x06010068 RID: 65640 RVA: 0x00070755 File Offset: 0x0006E955
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170061F6 RID: 25078
		' (get) Token: 0x06010069 RID: 65641 RVA: 0x0007075E File Offset: 0x0006E95E
		' (set) Token: 0x0601006A RID: 65642 RVA: 0x00070768 File Offset: 0x0006E968
		Friend Overridable Property Label1 As Label

		' Token: 0x170061F7 RID: 25079
		' (get) Token: 0x0601006B RID: 65643 RVA: 0x00070771 File Offset: 0x0006E971
		' (set) Token: 0x0601006C RID: 65644 RVA: 0x0007077B File Offset: 0x0006E97B
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170061F8 RID: 25080
		' (get) Token: 0x0601006D RID: 65645 RVA: 0x00070784 File Offset: 0x0006E984
		' (set) Token: 0x0601006E RID: 65646 RVA: 0x0007078E File Offset: 0x0006E98E
		Friend Overridable Property Label5 As Label

		' Token: 0x170061F9 RID: 25081
		' (get) Token: 0x0601006F RID: 65647 RVA: 0x00070797 File Offset: 0x0006E997
		' (set) Token: 0x06010070 RID: 65648 RVA: 0x000707A1 File Offset: 0x0006E9A1
		Friend Overridable Property Label4 As Label

		' Token: 0x170061FA RID: 25082
		' (get) Token: 0x06010071 RID: 65649 RVA: 0x000707AA File Offset: 0x0006E9AA
		' (set) Token: 0x06010072 RID: 65650 RVA: 0x000707B4 File Offset: 0x0006E9B4
		Friend Overridable Property Label3 As Label

		' Token: 0x170061FB RID: 25083
		' (get) Token: 0x06010073 RID: 65651 RVA: 0x000707BD File Offset: 0x0006E9BD
		' (set) Token: 0x06010074 RID: 65652 RVA: 0x000707C7 File Offset: 0x0006E9C7
		Friend Overridable Property Label2 As Label

		' Token: 0x170061FC RID: 25084
		' (get) Token: 0x06010075 RID: 65653 RVA: 0x000707D0 File Offset: 0x0006E9D0
		' (set) Token: 0x06010076 RID: 65654 RVA: 0x000707DA File Offset: 0x0006E9DA
		Friend Overridable Property Label13 As Label

		' Token: 0x170061FD RID: 25085
		' (get) Token: 0x06010077 RID: 65655 RVA: 0x000707E3 File Offset: 0x0006E9E3
		' (set) Token: 0x06010078 RID: 65656 RVA: 0x000707ED File Offset: 0x0006E9ED
		Friend Overridable Property Label12 As Label

		' Token: 0x170061FE RID: 25086
		' (get) Token: 0x06010079 RID: 65657 RVA: 0x000707F6 File Offset: 0x0006E9F6
		' (set) Token: 0x0601007A RID: 65658 RVA: 0x00070800 File Offset: 0x0006EA00
		Friend Overridable Property Label11 As Label

		' Token: 0x170061FF RID: 25087
		' (get) Token: 0x0601007B RID: 65659 RVA: 0x00070809 File Offset: 0x0006EA09
		' (set) Token: 0x0601007C RID: 65660 RVA: 0x00070813 File Offset: 0x0006EA13
		Friend Overridable Property Label10 As Label

		' Token: 0x17006200 RID: 25088
		' (get) Token: 0x0601007D RID: 65661 RVA: 0x0007081C File Offset: 0x0006EA1C
		' (set) Token: 0x0601007E RID: 65662 RVA: 0x00070826 File Offset: 0x0006EA26
		Friend Overridable Property Label9 As Label

		' Token: 0x17006201 RID: 25089
		' (get) Token: 0x0601007F RID: 65663 RVA: 0x0007082F File Offset: 0x0006EA2F
		' (set) Token: 0x06010080 RID: 65664 RVA: 0x00070839 File Offset: 0x0006EA39
		Friend Overridable Property Label8 As Label

		' Token: 0x17006202 RID: 25090
		' (get) Token: 0x06010081 RID: 65665 RVA: 0x00070842 File Offset: 0x0006EA42
		' (set) Token: 0x06010082 RID: 65666 RVA: 0x0007084C File Offset: 0x0006EA4C
		Friend Overridable Property Label7 As Label

		' Token: 0x17006203 RID: 25091
		' (get) Token: 0x06010083 RID: 65667 RVA: 0x00070855 File Offset: 0x0006EA55
		' (set) Token: 0x06010084 RID: 65668 RVA: 0x0007085F File Offset: 0x0006EA5F
		Friend Overridable Property Label6 As Label

		' Token: 0x17006204 RID: 25092
		' (get) Token: 0x06010085 RID: 65669 RVA: 0x00070868 File Offset: 0x0006EA68
		' (set) Token: 0x06010086 RID: 65670 RVA: 0x00992534 File Offset: 0x00990734
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

		' Token: 0x17006205 RID: 25093
		' (get) Token: 0x06010087 RID: 65671 RVA: 0x00070872 File Offset: 0x0006EA72
		' (set) Token: 0x06010088 RID: 65672 RVA: 0x00992594 File Offset: 0x00990794
		Private _cmbService As ComboBox
		Friend Overridable Property cmbService As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbService
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbService_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbService
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbService = value
				comboBox = Me._cmbService
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006206 RID: 25094
		' (get) Token: 0x06010089 RID: 65673 RVA: 0x0007087C File Offset: 0x0006EA7C
		' (set) Token: 0x0601008A RID: 65674 RVA: 0x009925F4 File Offset: 0x009907F4
		Private _txtVehNo As TextBox
		Friend Overridable Property txtVehNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtVehNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtVehNo_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtVehNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtVehNo = value
				textBox = Me._txtVehNo
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006207 RID: 25095
		' (get) Token: 0x0601008B RID: 65675 RVA: 0x00070886 File Offset: 0x0006EA86
		' (set) Token: 0x0601008C RID: 65676 RVA: 0x00992654 File Offset: 0x00990854
		Private _txtVehicle As TextBox
		Friend Overridable Property txtVehicle As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtVehicle
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtVehicle_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtVehicle
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtVehicle = value
				textBox = Me._txtVehicle
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006208 RID: 25096
		' (get) Token: 0x0601008D RID: 65677 RVA: 0x00070890 File Offset: 0x0006EA90
		' (set) Token: 0x0601008E RID: 65678 RVA: 0x009926B4 File Offset: 0x009908B4
		Private _txtPAN As TextBox
		Friend Overridable Property txtPAN As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPAN
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtPAN_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtPAN
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtPAN = value
				textBox = Me._txtPAN
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006209 RID: 25097
		' (get) Token: 0x0601008F RID: 65679 RVA: 0x0007089A File Offset: 0x0006EA9A
		' (set) Token: 0x06010090 RID: 65680 RVA: 0x00992714 File Offset: 0x00990914
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
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtGSTIN
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtGSTIN = value
				textBox = Me._txtGSTIN
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700620A RID: 25098
		' (get) Token: 0x06010091 RID: 65681 RVA: 0x000708A4 File Offset: 0x0006EAA4
		' (set) Token: 0x06010092 RID: 65682 RVA: 0x00992774 File Offset: 0x00990974
		Private _txtEmail As TextBox
		Friend Overridable Property txtEmail As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtEmail
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtEmail_KeyDown
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtEmail_KeyPress
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtEmail
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtEmail = value
				textBox = Me._txtEmail
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700620B RID: 25099
		' (get) Token: 0x06010093 RID: 65683 RVA: 0x000708AE File Offset: 0x0006EAAE
		' (set) Token: 0x06010094 RID: 65684 RVA: 0x009927F0 File Offset: 0x009909F0
		Private _txtContact As TextBox
		Friend Overridable Property txtContact As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtContact
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtContact_KeyDown
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtContact_KeyPress
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtContact
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtContact = value
				textBox = Me._txtContact
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700620C RID: 25100
		' (get) Token: 0x06010095 RID: 65685 RVA: 0x000708B8 File Offset: 0x0006EAB8
		' (set) Token: 0x06010096 RID: 65686 RVA: 0x0099286C File Offset: 0x00990A6C
		Private _txtPin As TextBox
		Friend Overridable Property txtPin As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPin
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtPin_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtPin
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtPin = value
				textBox = Me._txtPin
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700620D RID: 25101
		' (get) Token: 0x06010097 RID: 65687 RVA: 0x000708C2 File Offset: 0x0006EAC2
		' (set) Token: 0x06010098 RID: 65688 RVA: 0x009928CC File Offset: 0x00990ACC
		Private _txtCity As TextBox
		Friend Overridable Property txtCity As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCity
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCity_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtCity
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtCity = value
				textBox = Me._txtCity
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700620E RID: 25102
		' (get) Token: 0x06010099 RID: 65689 RVA: 0x000708CC File Offset: 0x0006EACC
		' (set) Token: 0x0601009A RID: 65690 RVA: 0x0099292C File Offset: 0x00990B2C
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

		' Token: 0x1700620F RID: 25103
		' (get) Token: 0x0601009B RID: 65691 RVA: 0x000708D6 File Offset: 0x0006EAD6
		' (set) Token: 0x0601009C RID: 65692 RVA: 0x0099298C File Offset: 0x00990B8C
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

		' Token: 0x17006210 RID: 25104
		' (get) Token: 0x0601009D RID: 65693 RVA: 0x000708E0 File Offset: 0x0006EAE0
		' (set) Token: 0x0601009E RID: 65694 RVA: 0x009929EC File Offset: 0x00990BEC
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006211 RID: 25105
		' (get) Token: 0x0601009F RID: 65695 RVA: 0x000708EA File Offset: 0x0006EAEA
		' (set) Token: 0x060100A0 RID: 65696 RVA: 0x000708F4 File Offset: 0x0006EAF4
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006212 RID: 25106
		' (get) Token: 0x060100A1 RID: 65697 RVA: 0x000708FD File Offset: 0x0006EAFD
		' (set) Token: 0x060100A2 RID: 65698 RVA: 0x00070907 File Offset: 0x0006EB07
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006213 RID: 25107
		' (get) Token: 0x060100A3 RID: 65699 RVA: 0x00070910 File Offset: 0x0006EB10
		' (set) Token: 0x060100A4 RID: 65700 RVA: 0x0007091A File Offset: 0x0006EB1A
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006214 RID: 25108
		' (get) Token: 0x060100A5 RID: 65701 RVA: 0x00070923 File Offset: 0x0006EB23
		' (set) Token: 0x060100A6 RID: 65702 RVA: 0x0007092D File Offset: 0x0006EB2D
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006215 RID: 25109
		' (get) Token: 0x060100A7 RID: 65703 RVA: 0x00070936 File Offset: 0x0006EB36
		' (set) Token: 0x060100A8 RID: 65704 RVA: 0x00070940 File Offset: 0x0006EB40
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17006216 RID: 25110
		' (get) Token: 0x060100A9 RID: 65705 RVA: 0x00070949 File Offset: 0x0006EB49
		' (set) Token: 0x060100AA RID: 65706 RVA: 0x00070953 File Offset: 0x0006EB53
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17006217 RID: 25111
		' (get) Token: 0x060100AB RID: 65707 RVA: 0x0007095C File Offset: 0x0006EB5C
		' (set) Token: 0x060100AC RID: 65708 RVA: 0x00070966 File Offset: 0x0006EB66
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17006218 RID: 25112
		' (get) Token: 0x060100AD RID: 65709 RVA: 0x0007096F File Offset: 0x0006EB6F
		' (set) Token: 0x060100AE RID: 65710 RVA: 0x00070979 File Offset: 0x0006EB79
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17006219 RID: 25113
		' (get) Token: 0x060100AF RID: 65711 RVA: 0x00070982 File Offset: 0x0006EB82
		' (set) Token: 0x060100B0 RID: 65712 RVA: 0x0007098C File Offset: 0x0006EB8C
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x1700621A RID: 25114
		' (get) Token: 0x060100B1 RID: 65713 RVA: 0x00070995 File Offset: 0x0006EB95
		' (set) Token: 0x060100B2 RID: 65714 RVA: 0x0007099F File Offset: 0x0006EB9F
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x1700621B RID: 25115
		' (get) Token: 0x060100B3 RID: 65715 RVA: 0x000709A8 File Offset: 0x0006EBA8
		' (set) Token: 0x060100B4 RID: 65716 RVA: 0x000709B2 File Offset: 0x0006EBB2
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x1700621C RID: 25116
		' (get) Token: 0x060100B5 RID: 65717 RVA: 0x000709BB File Offset: 0x0006EBBB
		' (set) Token: 0x060100B6 RID: 65718 RVA: 0x000709C5 File Offset: 0x0006EBC5
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x1700621D RID: 25117
		' (get) Token: 0x060100B7 RID: 65719 RVA: 0x000709CE File Offset: 0x0006EBCE
		' (set) Token: 0x060100B8 RID: 65720 RVA: 0x000709D8 File Offset: 0x0006EBD8
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x1700621E RID: 25118
		' (get) Token: 0x060100B9 RID: 65721 RVA: 0x000709E1 File Offset: 0x0006EBE1
		' (set) Token: 0x060100BA RID: 65722 RVA: 0x000709EB File Offset: 0x0006EBEB
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x1700621F RID: 25119
		' (get) Token: 0x060100BB RID: 65723 RVA: 0x000709F4 File Offset: 0x0006EBF4
		' (set) Token: 0x060100BC RID: 65724 RVA: 0x000709FE File Offset: 0x0006EBFE
		Friend Overridable Property lblUser As Label

		' Token: 0x17006220 RID: 25120
		' (get) Token: 0x060100BD RID: 65725 RVA: 0x00070A07 File Offset: 0x0006EC07
		' (set) Token: 0x060100BE RID: 65726 RVA: 0x00070A11 File Offset: 0x0006EC11
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17006221 RID: 25121
		' (get) Token: 0x060100BF RID: 65727 RVA: 0x00070A1A File Offset: 0x0006EC1A
		' (set) Token: 0x060100C0 RID: 65728 RVA: 0x00992A4C File Offset: 0x00990C4C
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

		' Token: 0x17006222 RID: 25122
		' (get) Token: 0x060100C1 RID: 65729 RVA: 0x00070A24 File Offset: 0x0006EC24
		' (set) Token: 0x060100C2 RID: 65730 RVA: 0x00992A90 File Offset: 0x00990C90
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

		' Token: 0x17006223 RID: 25123
		' (get) Token: 0x060100C3 RID: 65731 RVA: 0x00070A2E File Offset: 0x0006EC2E
		' (set) Token: 0x060100C4 RID: 65732 RVA: 0x00992AD4 File Offset: 0x00990CD4
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

		' Token: 0x17006224 RID: 25124
		' (get) Token: 0x060100C5 RID: 65733 RVA: 0x00070A38 File Offset: 0x0006EC38
		' (set) Token: 0x060100C6 RID: 65734 RVA: 0x00070A42 File Offset: 0x0006EC42
		Friend Overridable Property Label16 As Label

		' Token: 0x17006225 RID: 25125
		' (get) Token: 0x060100C7 RID: 65735 RVA: 0x00070A4B File Offset: 0x0006EC4B
		' (set) Token: 0x060100C8 RID: 65736 RVA: 0x00070A55 File Offset: 0x0006EC55
		Friend Overridable Property Label15 As Label

		' Token: 0x17006226 RID: 25126
		' (get) Token: 0x060100C9 RID: 65737 RVA: 0x00070A5E File Offset: 0x0006EC5E
		' (set) Token: 0x060100CA RID: 65738 RVA: 0x00070A68 File Offset: 0x0006EC68
		Friend Overridable Property Label14 As Label

		' Token: 0x17006227 RID: 25127
		' (get) Token: 0x060100CB RID: 65739 RVA: 0x00070A71 File Offset: 0x0006EC71
		' (set) Token: 0x060100CC RID: 65740 RVA: 0x00070A7B File Offset: 0x0006EC7B
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17006228 RID: 25128
		' (get) Token: 0x060100CD RID: 65741 RVA: 0x00070A84 File Offset: 0x0006EC84
		' (set) Token: 0x060100CE RID: 65742 RVA: 0x00070A8E File Offset: 0x0006EC8E
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17006229 RID: 25129
		' (get) Token: 0x060100CF RID: 65743 RVA: 0x00070A97 File Offset: 0x0006EC97
		' (set) Token: 0x060100D0 RID: 65744 RVA: 0x00070AA1 File Offset: 0x0006ECA1
		Friend Overridable Property Panel4 As Panel

		' Token: 0x1700622A RID: 25130
		' (get) Token: 0x060100D1 RID: 65745 RVA: 0x00070AAA File Offset: 0x0006ECAA
		' (set) Token: 0x060100D2 RID: 65746 RVA: 0x00992B18 File Offset: 0x00990D18
		Private _GelButton5 As GelButton
		Friend Overridable Property GelButton5 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton5_Click
				Dim gelButton As GelButton = Me._GelButton5
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton5 = value
				gelButton = Me._GelButton5
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700622B RID: 25131
		' (get) Token: 0x060100D3 RID: 65747 RVA: 0x00070AB4 File Offset: 0x0006ECB4
		' (set) Token: 0x060100D4 RID: 65748 RVA: 0x00992B5C File Offset: 0x00990D5C
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

		' Token: 0x1700622C RID: 25132
		' (get) Token: 0x060100D5 RID: 65749 RVA: 0x00070ABE File Offset: 0x0006ECBE
		' (set) Token: 0x060100D6 RID: 65750 RVA: 0x00992BA0 File Offset: 0x00990DA0
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

		' Token: 0x1700622D RID: 25133
		' (get) Token: 0x060100D7 RID: 65751 RVA: 0x00070AC8 File Offset: 0x0006ECC8
		' (set) Token: 0x060100D8 RID: 65752 RVA: 0x00992BE4 File Offset: 0x00990DE4
		Private _btnNew As GelButton
		Friend Overridable Property btnNew As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
				Dim gelButton As GelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnNew = value
				gelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700622E RID: 25134
		' (get) Token: 0x060100D9 RID: 65753 RVA: 0x00070AD2 File Offset: 0x0006ECD2
		' (set) Token: 0x060100DA RID: 65754 RVA: 0x00992C28 File Offset: 0x00990E28
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

		' Token: 0x060100DB RID: 65755 RVA: 0x00992C6C File Offset: 0x00990E6C
		Public Sub clear()
			Me.txtCompanyName.Text = ""
			Me.txtAddress.Text = ""
			Me.txtCity.Text = ""
			Me.txtPin.Text = ""
			Me.cmbState.SelectedIndex = -1
			Me.txtContact.Text = ""
			Me.txtEmail.Text = ""
			Me.txtGSTIN.Text = ""
			Me.txtPAN.Text = ""
			Me.txtVehicle.Text = ""
			Me.txtVehNo.Text = ""
			Me.cmbService.SelectedIndex = -1
			Me.Getdata()
			Me.btnSave.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.btnDelete.Enabled = False
			Me.txtCompanyName.Focus()
			Me.TextBox1.Text = ""
			Me.TextBox2.Text = ""
			Me.TextBox3.Text = ""
			Me.TextBox4.Text = ""
		End Sub

		' Token: 0x060100DC RID: 65756 RVA: 0x00992DBC File Offset: 0x00990FBC
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,RTRIM(c1),RTRIM(c2),RTRIM(c3),RTRIM(c4),RTRIM(c5),RTRIM(c6),RTRIM(c7),RTRIM(c8),RTRIM(c9),RTRIM(c10),RTRIM(c11),RTRIM(c12) from Transport order by c1", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060100DD RID: 65757 RVA: 0x00992F64 File Offset: 0x00991164
		Private Sub frmTransport_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x060100DE RID: 65758 RVA: 0x00992FEC File Offset: 0x009911EC
		Public Sub Convert_Language()
			Dim text As String = "SELECT RTRIM(default_lang_eng) AS default_lang_eng, other_lang, lang_hin FROM Language_set WHERE lang_hin= '" + GlobalVariables.LoggedInLang_code + "'"
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
						Try
							For Each obj2 As Object In MyBase.Controls
								Dim control As Control = CType(obj2, Control)
								Dim flag2 As Boolean = TypeOf control Is DataGridView
								If flag2 Then
									Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
								End If
								Try
									For Each obj3 As Object In control.Controls
										Dim control2 As Control = CType(obj3, Control)
										Dim flag3 As Boolean = TypeOf control2 Is DataGridView
										If flag3 Then
											Me.UpdateDataGridViewHeaders(CType(control2, DataGridView))
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
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x060100DF RID: 65759 RVA: 0x0099328C File Offset: 0x0099148C
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is RadioButton
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

		' Token: 0x060100E0 RID: 65760 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060100E1 RID: 65761 RVA: 0x00993340 File Offset: 0x00991540
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.TextBox1.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtCompanyName.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtAddress.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtCity.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.txtPin.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.cmbState.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.txtContact.Text = dataGridViewRow.Cells(6).Value.ToString()
					Me.txtEmail.Text = dataGridViewRow.Cells(7).Value.ToString()
					Me.txtGSTIN.Text = dataGridViewRow.Cells(8).Value.ToString()
					Me.txtPAN.Text = dataGridViewRow.Cells(9).Value.ToString()
					Me.txtVehicle.Text = dataGridViewRow.Cells(10).Value.ToString()
					Me.txtVehNo.Text = dataGridViewRow.Cells(11).Value.ToString()
					Me.cmbService.Text = dataGridViewRow.Cells(12).Value.ToString()
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060100E2 RID: 65762 RVA: 0x00070ADC File Offset: 0x0006ECDC
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x060100E3 RID: 65763 RVA: 0x00993590 File Offset: 0x00991790
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

		' Token: 0x060100E4 RID: 65764 RVA: 0x00993678 File Offset: 0x00991878
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = If(("delete from Transport where ID =" + Me.TextBox1.Text), "")
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					ModFunc.LogFunc(Me.lblUser.Text, "Deleted the Transporter having Name '" + Me.txtCompanyName.Text + "'")
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.clear()
				Else
					MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.clear()
					Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag2 Then
						ModCommonClasses.con.Close()
					End If
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060100E5 RID: 65765 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCompanyName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060100E6 RID: 65766 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAddress_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060100E7 RID: 65767 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCity_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060100E8 RID: 65768 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtPin_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060100E9 RID: 65769 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbState_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060100EA RID: 65770 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtContact_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060100EB RID: 65771 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtEmail_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060100EC RID: 65772 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtGSTIN_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060100ED RID: 65773 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtPAN_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060100EE RID: 65774 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtVehicle_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060100EF RID: 65775 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtVehNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060100F0 RID: 65776 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbService_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060100F1 RID: 65777 RVA: 0x0077BBFC File Offset: 0x00779DFC
		Private Sub txtContact_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "+", False) <> 0 AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "-", False) <> 0 AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x060100F2 RID: 65778 RVA: 0x009937CC File Offset: 0x009919CC
		Private Sub txtEmail_KeyPress(sender As Object, e As KeyPressEventArgs)
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
								Dim flag6 As Boolean = Me.txtEmail.Text.Contains("@") And (Operators.CompareString(Conversions.ToString(e.KeyChar), "@", False) = 0)
								If flag6 Then
									e.Handled = True
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x060100F3 RID: 65779 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub txtEmail_Validating(sender As Object, e As CancelEventArgs)
		End Sub

		' Token: 0x060100F4 RID: 65780 RVA: 0x009938D4 File Offset: 0x00991AD4
		Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,RTRIM(c1),RTRIM(c2),RTRIM(c3),RTRIM(c4),RTRIM(c5),RTRIM(c6),RTRIM(c7),RTRIM(c8),RTRIM(c9),RTRIM(c10),RTRIM(c11),RTRIM(c12) from Transport where c1 like N'%" + Me.TextBox2.Text + "%' ORDER BY c1", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060100F5 RID: 65781 RVA: 0x00993A90 File Offset: 0x00991C90
		Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,RTRIM(c1),RTRIM(c2),RTRIM(c3),RTRIM(c4),RTRIM(c5),RTRIM(c6),RTRIM(c7),RTRIM(c8),RTRIM(c9),RTRIM(c10),RTRIM(c11),RTRIM(c12) from Transport where c6 like N'%" + Me.TextBox3.Text + "%' ORDER BY c1", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060100F6 RID: 65782 RVA: 0x00993C4C File Offset: 0x00991E4C
		Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,RTRIM(c1),RTRIM(c2),RTRIM(c3),RTRIM(c4),RTRIM(c5),RTRIM(c6),RTRIM(c7),RTRIM(c8),RTRIM(c9),RTRIM(c10),RTRIM(c11),RTRIM(c12) from Transport where c11 like N'%" + Me.TextBox4.Text + "%' ORDER BY c1", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060100F7 RID: 65783 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmTransport_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060100F8 RID: 65784 RVA: 0x00993E08 File Offset: 0x00992008
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtVehNo.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtVehNo, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtVehNo, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtVehicle.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtVehicle, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtVehicle, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.txtPin.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.txtPin, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtPin, String.Empty)
			End If
			Dim flag4 As Boolean = String.IsNullOrEmpty(Me.txtPAN.Text.Trim())
			If flag4 Then
				Me.ErrorProvider1.SetError(Me.txtPAN, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtPAN, String.Empty)
			End If
			Dim flag5 As Boolean = String.IsNullOrEmpty(Me.txtGSTIN.Text.Trim())
			If flag5 Then
				Me.ErrorProvider1.SetError(Me.txtGSTIN, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtGSTIN, String.Empty)
			End If
			Dim flag6 As Boolean = String.IsNullOrEmpty(Me.txtEmail.Text.Trim())
			If flag6 Then
				Me.ErrorProvider1.SetError(Me.txtEmail, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtEmail, String.Empty)
			End If
			Dim flag7 As Boolean = String.IsNullOrEmpty(Me.txtContact.Text.Trim())
			If flag7 Then
				Me.ErrorProvider1.SetError(Me.txtContact, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtContact, String.Empty)
			End If
			Dim flag8 As Boolean = String.IsNullOrEmpty(Me.txtCompanyName.Text.Trim())
			If flag8 Then
				Me.ErrorProvider1.SetError(Me.txtCompanyName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtCompanyName, String.Empty)
			End If
			Dim flag9 As Boolean = String.IsNullOrEmpty(Me.txtCity.Text.Trim())
			If flag9 Then
				Me.ErrorProvider1.SetError(Me.txtCity, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtCity, String.Empty)
			End If
			Dim flag10 As Boolean = String.IsNullOrEmpty(Me.txtAddress.Text.Trim())
			If flag10 Then
				Me.ErrorProvider1.SetError(Me.txtAddress, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtAddress, String.Empty)
			End If
			Dim flag11 As Boolean = String.IsNullOrEmpty(Me.cmbState.Text.Trim())
			If flag11 Then
				Me.ErrorProvider1.SetError(Me.cmbState, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbState, String.Empty)
			End If
			Dim flag12 As Boolean = String.IsNullOrEmpty(Me.cmbService.Text.Trim())
			If flag12 Then
				Me.ErrorProvider1.SetError(Me.cmbService, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbService, String.Empty)
			End If
		End Sub

		' Token: 0x060100F9 RID: 65785 RVA: 0x00070AE6 File Offset: 0x0006ECE6
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.clear()
		End Sub

		' Token: 0x060100FA RID: 65786 RVA: 0x009941B8 File Offset: 0x009923B8
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
				Dim flag3 As Boolean = Operators.CompareString(Me.txtCompanyName.Text, "", False) = 0
				If flag3 Then
					MessageBox.Show("Please enter Name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtCompanyName.Focus()
				Else
					Dim flag4 As Boolean = Operators.CompareString(Me.txtAddress.Text, "", False) = 0
					If flag4 Then
						MessageBox.Show("Please enter Address", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtAddress.Focus()
					Else
						Dim flag5 As Boolean = Me.cmbState.SelectedIndex = -1
						If flag5 Then
							MessageBox.Show("Please enter State", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.cmbState.Focus()
						Else
							Dim flag6 As Boolean = Operators.CompareString(Me.txtContact.Text, "", False) = 0
							If flag6 Then
								MessageBox.Show("Please enter Contact No.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtContact.Focus()
							Else
								Dim flag7 As Boolean = Me.cmbService.SelectedIndex = -1
								If flag7 Then
									MessageBox.Show("Please enter Service", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.cmbService.Focus()
								Else
									Try
										ModCommonClasses.con.Close()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text2 As String = "insert into Transport(c1,c2,c3,c4,c5,c6,c7,c8,c9,c10,c11,c12) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)"
										ModCommonClasses.cmd = New SqlCommand(text2)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCompanyName.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtAddress.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtCity.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtPin.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.cmbState.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtContact.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtEmail.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.txtGSTIN.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.txtPAN.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.txtVehicle.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.txtVehNo.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.cmbService.Text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModFunc.LogFunc(Me.lblUser.Text, "added the new Transporter having Name '" + Me.txtCompanyName.Text + "'")
										MessageBox.Show("Successfully Saved", "Salesman Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										ModCommonClasses.con.Close()
										Me.clear()
										Me.btnSave.Enabled = False
										Me.btnUpdate.Enabled = True
										Me.btnDelete.Enabled = True
									Catch ex As Exception
										MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									End Try
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x060100FB RID: 65787 RVA: 0x0099462C File Offset: 0x0099282C
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
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
				Dim flag3 As Boolean = Operators.CompareString(Me.txtCompanyName.Text, "", False) = 0
				If flag3 Then
					MessageBox.Show("Please enter Name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtCompanyName.Focus()
				Else
					Dim flag4 As Boolean = Operators.CompareString(Me.txtAddress.Text, "", False) = 0
					If flag4 Then
						MessageBox.Show("Please enter Address", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtAddress.Focus()
					Else
						Dim flag5 As Boolean = Me.cmbState.SelectedIndex = -1
						If flag5 Then
							MessageBox.Show("Please enter State", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.cmbState.Focus()
						Else
							Dim flag6 As Boolean = Operators.CompareString(Me.txtContact.Text, "", False) = 0
							If flag6 Then
								MessageBox.Show("Please enter Contact No.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtContact.Focus()
							Else
								Dim flag7 As Boolean = Me.cmbService.SelectedIndex = -1
								If flag7 Then
									MessageBox.Show("Please enter Service", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.cmbService.Focus()
								Else
									Try
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text2 As String = "update Transport set c1=@d1,c2=@d2,c3=@d3,c4=@d4,c5=@d5,c6=@d6,c7=@d7,c8=@d8,c9=@d9,c10=@d10,c11=@d11,c12=@d12 where ID=@d0"
										ModCommonClasses.cmd = New SqlCommand(text2)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCompanyName.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtAddress.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtCity.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtPin.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.cmbState.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtContact.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtEmail.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.txtGSTIN.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.txtPAN.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.txtVehicle.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.txtVehNo.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.cmbService.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Me.TextBox1.Text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										ModFunc.LogFunc(Me.lblUser.Text, "Updated the Transporter having Name '" + Me.txtCompanyName.Text + "'")
										MessageBox.Show("Successfully Updated", "Salesman Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										Me.btnUpdate.Enabled = False
										Me.btnSave.Enabled = True
										Me.btnDelete.Enabled = False
										Me.clear()
									Catch ex As Exception
										MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									End Try
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x060100FC RID: 65788 RVA: 0x00994AB4 File Offset: 0x00992CB4
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

		' Token: 0x060100FD RID: 65789 RVA: 0x00994B1C File Offset: 0x00992D1C
		Private Sub GelButton5_Click(sender As Object, e As EventArgs)
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
	End Class
End Namespace
