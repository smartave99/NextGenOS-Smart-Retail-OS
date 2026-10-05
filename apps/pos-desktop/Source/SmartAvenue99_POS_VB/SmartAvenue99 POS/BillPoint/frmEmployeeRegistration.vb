Imports System
Imports System.Collections
Imports System.Collections.Generic
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

Namespace BillPoint
	' Token: 0x02000341 RID: 833
	<DesignerGenerated()>
	Public Partial Class frmEmployeeRegistration
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C299 RID: 49817 RVA: 0x007BA08C File Offset: 0x007B828C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmEmployeeRegistration_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmEmployeeRegistration_KeyDown
			Me.Photoname = ""
			Me.IsImageChanged = False
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004D4E RID: 19790
		' (get) Token: 0x0600C29C RID: 49820 RVA: 0x00057025 File Offset: 0x00055225
		' (set) Token: 0x0600C29D RID: 49821 RVA: 0x0005702F File Offset: 0x0005522F
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004D4F RID: 19791
		' (get) Token: 0x0600C29E RID: 49822 RVA: 0x00057038 File Offset: 0x00055238
		' (set) Token: 0x0600C29F RID: 49823 RVA: 0x00057042 File Offset: 0x00055242
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004D50 RID: 19792
		' (get) Token: 0x0600C2A0 RID: 49824 RVA: 0x0005704B File Offset: 0x0005524B
		' (set) Token: 0x0600C2A1 RID: 49825 RVA: 0x00057055 File Offset: 0x00055255
		Friend Overridable Property Label1 As Label

		' Token: 0x17004D51 RID: 19793
		' (get) Token: 0x0600C2A2 RID: 49826 RVA: 0x0005705E File Offset: 0x0005525E
		' (set) Token: 0x0600C2A3 RID: 49827 RVA: 0x00057068 File Offset: 0x00055268
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x17004D52 RID: 19794
		' (get) Token: 0x0600C2A4 RID: 49828 RVA: 0x00057071 File Offset: 0x00055271
		' (set) Token: 0x0600C2A5 RID: 49829 RVA: 0x0005707B File Offset: 0x0005527B
		Friend Overridable Property Timer1 As Timer

		' Token: 0x17004D53 RID: 19795
		' (get) Token: 0x0600C2A6 RID: 49830 RVA: 0x00057084 File Offset: 0x00055284
		' (set) Token: 0x0600C2A7 RID: 49831 RVA: 0x007BC7AC File Offset: 0x007BA9AC
		Private _cmbGender As ComboBox
		Friend Overridable Property cmbGender As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbGender
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.All_KD
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbGender
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbGender = value
				comboBox = Me._cmbGender
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D54 RID: 19796
		' (get) Token: 0x0600C2A8 RID: 49832 RVA: 0x0005708E File Offset: 0x0005528E
		' (set) Token: 0x0600C2A9 RID: 49833 RVA: 0x007BC80C File Offset: 0x007BAA0C
		Private _txtCity As TextBox
		Friend Overridable Property txtCity As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCity
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.All_KD
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

		' Token: 0x17004D55 RID: 19797
		' (get) Token: 0x0600C2AA RID: 49834 RVA: 0x00057098 File Offset: 0x00055298
		' (set) Token: 0x0600C2AB RID: 49835 RVA: 0x000570A2 File Offset: 0x000552A2
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17004D56 RID: 19798
		' (get) Token: 0x0600C2AC RID: 49836 RVA: 0x000570AB File Offset: 0x000552AB
		' (set) Token: 0x0600C2AD RID: 49837 RVA: 0x007BC86C File Offset: 0x007BAA6C
		Private _txtAddress As TextBox
		Friend Overridable Property txtAddress As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAddress
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.All_KD
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

		' Token: 0x17004D57 RID: 19799
		' (get) Token: 0x0600C2AE RID: 49838 RVA: 0x000570B5 File Offset: 0x000552B5
		' (set) Token: 0x0600C2AF RID: 49839 RVA: 0x000570BF File Offset: 0x000552BF
		Friend Overridable Property txtEmployeeID As TextBox

		' Token: 0x17004D58 RID: 19800
		' (get) Token: 0x0600C2B0 RID: 49840 RVA: 0x000570C8 File Offset: 0x000552C8
		' (set) Token: 0x0600C2B1 RID: 49841 RVA: 0x007BC8CC File Offset: 0x007BAACC
		Private _txtBasicWorkingTime As MaskedTextBox
		Friend Overridable Property txtBasicWorkingTime As MaskedTextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBasicWorkingTime
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As MaskedTextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.All_KD
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim maskedTextBox As MaskedTextBox = Me._txtBasicWorkingTime
				If maskedTextBox IsNot Nothing Then
					RemoveHandler maskedTextBox.KeyDown, keyEventHandler
					RemoveHandler maskedTextBox.Validating, cancelEventHandler
				End If
				Me._txtBasicWorkingTime = value
				maskedTextBox = Me._txtBasicWorkingTime
				If maskedTextBox IsNot Nothing Then
					AddHandler maskedTextBox.KeyDown, keyEventHandler
					AddHandler maskedTextBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D59 RID: 19801
		' (get) Token: 0x0600C2B2 RID: 49842 RVA: 0x000570D2 File Offset: 0x000552D2
		' (set) Token: 0x0600C2B3 RID: 49843 RVA: 0x000570DC File Offset: 0x000552DC
		Friend Overridable Property Label12 As Label

		' Token: 0x17004D5A RID: 19802
		' (get) Token: 0x0600C2B4 RID: 49844 RVA: 0x000570E5 File Offset: 0x000552E5
		' (set) Token: 0x0600C2B5 RID: 49845 RVA: 0x007BC92C File Offset: 0x007BAB2C
		Private _txtEmployeeName As TextBox
		Friend Overridable Property txtEmployeeName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtEmployeeName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.All_KD
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtEmployeeName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtEmployeeName = value
				textBox = Me._txtEmployeeName
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D5B RID: 19803
		' (get) Token: 0x0600C2B6 RID: 49846 RVA: 0x000570EF File Offset: 0x000552EF
		' (set) Token: 0x0600C2B7 RID: 49847 RVA: 0x007BC98C File Offset: 0x007BAB8C
		Private _cmbDesignation As ComboBox
		Friend Overridable Property cmbDesignation As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbDesignation
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim listControlConvertEventHandler As ListControlConvertEventHandler = AddressOf Me.cmbDesignation_Format
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.All_KD
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbDesignation
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.Format, listControlConvertEventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbDesignation = value
				comboBox = Me._cmbDesignation
				If comboBox IsNot Nothing Then
					AddHandler comboBox.Format, listControlConvertEventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D5C RID: 19804
		' (get) Token: 0x0600C2B8 RID: 49848 RVA: 0x000570F9 File Offset: 0x000552F9
		' (set) Token: 0x0600C2B9 RID: 49849 RVA: 0x00057103 File Offset: 0x00055303
		Friend Overridable Property Label11 As Label

		' Token: 0x17004D5D RID: 19805
		' (get) Token: 0x0600C2BA RID: 49850 RVA: 0x0005710C File Offset: 0x0005530C
		' (set) Token: 0x0600C2BB RID: 49851 RVA: 0x007BCA08 File Offset: 0x007BAC08
		Private _dtpDateOfJoining As DateTimePicker
		Friend Overridable Property dtpDateOfJoining As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpDateOfJoining
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.All_KD
				Dim dateTimePicker As DateTimePicker = Me._dtpDateOfJoining
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpDateOfJoining = value
				dateTimePicker = Me._dtpDateOfJoining
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D5E RID: 19806
		' (get) Token: 0x0600C2BC RID: 49852 RVA: 0x00057116 File Offset: 0x00055316
		' (set) Token: 0x0600C2BD RID: 49853 RVA: 0x007BCA4C File Offset: 0x007BAC4C
		Private _cmbDepartment As ComboBox
		Friend Overridable Property cmbDepartment As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbDepartment
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim listControlConvertEventHandler As ListControlConvertEventHandler = AddressOf Me.cmbDepartment_Format
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.All_KD
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbDepartment
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.Format, listControlConvertEventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbDepartment = value
				comboBox = Me._cmbDepartment
				If comboBox IsNot Nothing Then
					AddHandler comboBox.Format, listControlConvertEventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D5F RID: 19807
		' (get) Token: 0x0600C2BE RID: 49854 RVA: 0x00057120 File Offset: 0x00055320
		' (set) Token: 0x0600C2BF RID: 49855 RVA: 0x007BCAC8 File Offset: 0x007BACC8
		Private _cmbBloodGroup As ComboBox
		Friend Overridable Property cmbBloodGroup As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbBloodGroup
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.All_KD
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbBloodGroup
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbBloodGroup = value
				comboBox = Me._cmbBloodGroup
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D60 RID: 19808
		' (get) Token: 0x0600C2C0 RID: 49856 RVA: 0x0005712A File Offset: 0x0005532A
		' (set) Token: 0x0600C2C1 RID: 49857 RVA: 0x007BCB28 File Offset: 0x007BAD28
		Private _txtContactNo As MaskedTextBox
		Friend Overridable Property txtContactNo As MaskedTextBox
			<CompilerGenerated()>
			Get
				Return Me._txtContactNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As MaskedTextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtContactNo_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.All_KD
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim maskedTextBox As MaskedTextBox = Me._txtContactNo
				If maskedTextBox IsNot Nothing Then
					RemoveHandler maskedTextBox.KeyPress, keyPressEventHandler
					RemoveHandler maskedTextBox.KeyDown, keyEventHandler
					RemoveHandler maskedTextBox.Validating, cancelEventHandler
				End If
				Me._txtContactNo = value
				maskedTextBox = Me._txtContactNo
				If maskedTextBox IsNot Nothing Then
					AddHandler maskedTextBox.KeyPress, keyPressEventHandler
					AddHandler maskedTextBox.KeyDown, keyEventHandler
					AddHandler maskedTextBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D61 RID: 19809
		' (get) Token: 0x0600C2C2 RID: 49858 RVA: 0x00057134 File Offset: 0x00055334
		' (set) Token: 0x0600C2C3 RID: 49859 RVA: 0x0005713E File Offset: 0x0005533E
		Friend Overridable Property Label10 As Label

		' Token: 0x17004D62 RID: 19810
		' (get) Token: 0x0600C2C4 RID: 49860 RVA: 0x00057147 File Offset: 0x00055347
		' (set) Token: 0x0600C2C5 RID: 49861 RVA: 0x00057151 File Offset: 0x00055351
		Friend Overridable Property Label9 As Label

		' Token: 0x17004D63 RID: 19811
		' (get) Token: 0x0600C2C6 RID: 49862 RVA: 0x0005715A File Offset: 0x0005535A
		' (set) Token: 0x0600C2C7 RID: 49863 RVA: 0x00057164 File Offset: 0x00055364
		Friend Overridable Property Label13 As Label

		' Token: 0x17004D64 RID: 19812
		' (get) Token: 0x0600C2C8 RID: 49864 RVA: 0x0005716D File Offset: 0x0005536D
		' (set) Token: 0x0600C2C9 RID: 49865 RVA: 0x00057177 File Offset: 0x00055377
		Friend Overridable Property Label14 As Label

		' Token: 0x17004D65 RID: 19813
		' (get) Token: 0x0600C2CA RID: 49866 RVA: 0x00057180 File Offset: 0x00055380
		' (set) Token: 0x0600C2CB RID: 49867 RVA: 0x0005718A File Offset: 0x0005538A
		Friend Overridable Property Label15 As Label

		' Token: 0x17004D66 RID: 19814
		' (get) Token: 0x0600C2CC RID: 49868 RVA: 0x00057193 File Offset: 0x00055393
		' (set) Token: 0x0600C2CD RID: 49869 RVA: 0x0005719D File Offset: 0x0005539D
		Friend Overridable Property Label16 As Label

		' Token: 0x17004D67 RID: 19815
		' (get) Token: 0x0600C2CE RID: 49870 RVA: 0x000571A6 File Offset: 0x000553A6
		' (set) Token: 0x0600C2CF RID: 49871 RVA: 0x000571B0 File Offset: 0x000553B0
		Friend Overridable Property Label17 As Label

		' Token: 0x17004D68 RID: 19816
		' (get) Token: 0x0600C2D0 RID: 49872 RVA: 0x000571B9 File Offset: 0x000553B9
		' (set) Token: 0x0600C2D1 RID: 49873 RVA: 0x000571C3 File Offset: 0x000553C3
		Friend Overridable Property Label18 As Label

		' Token: 0x17004D69 RID: 19817
		' (get) Token: 0x0600C2D2 RID: 49874 RVA: 0x000571CC File Offset: 0x000553CC
		' (set) Token: 0x0600C2D3 RID: 49875 RVA: 0x000571D6 File Offset: 0x000553D6
		Friend Overridable Property Label19 As Label

		' Token: 0x17004D6A RID: 19818
		' (get) Token: 0x0600C2D4 RID: 49876 RVA: 0x000571DF File Offset: 0x000553DF
		' (set) Token: 0x0600C2D5 RID: 49877 RVA: 0x007BCBA4 File Offset: 0x007BADA4
		Private _txtEmail As TextBox
		Friend Overridable Property txtEmail As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtEmail
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtEmail_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.All_KD
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtEmail
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtEmail = value
				textBox = Me._txtEmail
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D6B RID: 19819
		' (get) Token: 0x0600C2D6 RID: 49878 RVA: 0x000571E9 File Offset: 0x000553E9
		' (set) Token: 0x0600C2D7 RID: 49879 RVA: 0x007BCC20 File Offset: 0x007BAE20
		Private _txtSalary As MaskedTextBox
		Friend Overridable Property txtSalary As MaskedTextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSalary
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As MaskedTextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtSalary_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.All_KD
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim maskedTextBox As MaskedTextBox = Me._txtSalary
				If maskedTextBox IsNot Nothing Then
					RemoveHandler maskedTextBox.KeyPress, keyPressEventHandler
					RemoveHandler maskedTextBox.KeyDown, keyEventHandler
					RemoveHandler maskedTextBox.Validating, cancelEventHandler
				End If
				Me._txtSalary = value
				maskedTextBox = Me._txtSalary
				If maskedTextBox IsNot Nothing Then
					AddHandler maskedTextBox.KeyPress, keyPressEventHandler
					AddHandler maskedTextBox.KeyDown, keyEventHandler
					AddHandler maskedTextBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D6C RID: 19820
		' (get) Token: 0x0600C2D8 RID: 49880 RVA: 0x000571F3 File Offset: 0x000553F3
		' (set) Token: 0x0600C2D9 RID: 49881 RVA: 0x000571FD File Offset: 0x000553FD
		Public Overridable Property Picture As PictureBox

		' Token: 0x17004D6D RID: 19821
		' (get) Token: 0x0600C2DA RID: 49882 RVA: 0x00057206 File Offset: 0x00055406
		' (set) Token: 0x0600C2DB RID: 49883 RVA: 0x007BCC9C File Offset: 0x007BAE9C
		Private _BStartCapture As Button
		Friend Overridable Property BStartCapture As Button
			<CompilerGenerated()>
			Get
				Return Me._BStartCapture
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.BStartCapture_Click
				Dim button As Button = Me._BStartCapture
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._BStartCapture = value
				button = Me._BStartCapture
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D6E RID: 19822
		' (get) Token: 0x0600C2DC RID: 49884 RVA: 0x00057210 File Offset: 0x00055410
		' (set) Token: 0x0600C2DD RID: 49885 RVA: 0x007BCCE0 File Offset: 0x007BAEE0
		Private _Browse As Button
		Friend Overridable Property Browse As Button
			<CompilerGenerated()>
			Get
				Return Me._Browse
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Browse_Click
				Dim button As Button = Me._Browse
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Browse = value
				button = Me._Browse
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D6F RID: 19823
		' (get) Token: 0x0600C2DE RID: 49886 RVA: 0x0005721A File Offset: 0x0005541A
		' (set) Token: 0x0600C2DF RID: 49887 RVA: 0x007BCD24 File Offset: 0x007BAF24
		Private _BRemove As Button
		Friend Overridable Property BRemove As Button
			<CompilerGenerated()>
			Get
				Return Me._BRemove
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.BRemove_Click
				Dim button As Button = Me._BRemove
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._BRemove = value
				button = Me._BRemove
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D70 RID: 19824
		' (get) Token: 0x0600C2E0 RID: 49888 RVA: 0x00057224 File Offset: 0x00055424
		' (set) Token: 0x0600C2E1 RID: 49889 RVA: 0x0005722E File Offset: 0x0005542E
		Friend Overridable Property txtID As TextBox

		' Token: 0x17004D71 RID: 19825
		' (get) Token: 0x0600C2E2 RID: 49890 RVA: 0x00057237 File Offset: 0x00055437
		' (set) Token: 0x0600C2E3 RID: 49891 RVA: 0x00057241 File Offset: 0x00055441
		Friend Overridable Property lblUser As Label

		' Token: 0x17004D72 RID: 19826
		' (get) Token: 0x0600C2E4 RID: 49892 RVA: 0x0005724A File Offset: 0x0005544A
		' (set) Token: 0x0600C2E5 RID: 49893 RVA: 0x00057254 File Offset: 0x00055454
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17004D73 RID: 19827
		' (get) Token: 0x0600C2E6 RID: 49894 RVA: 0x0005725D File Offset: 0x0005545D
		' (set) Token: 0x0600C2E7 RID: 49895 RVA: 0x00057267 File Offset: 0x00055467
		Friend Overridable Property txtEmpName As TextBox

		' Token: 0x17004D74 RID: 19828
		' (get) Token: 0x0600C2E8 RID: 49896 RVA: 0x00057270 File Offset: 0x00055470
		' (set) Token: 0x0600C2E9 RID: 49897 RVA: 0x0005727A File Offset: 0x0005547A
		Friend Overridable Property Label8 As Label

		' Token: 0x17004D75 RID: 19829
		' (get) Token: 0x0600C2EA RID: 49898 RVA: 0x00057283 File Offset: 0x00055483
		' (set) Token: 0x0600C2EB RID: 49899 RVA: 0x0005728D File Offset: 0x0005548D
		Friend Overridable Property chkActive As CheckBox

		' Token: 0x17004D76 RID: 19830
		' (get) Token: 0x0600C2EC RID: 49900 RVA: 0x00057296 File Offset: 0x00055496
		' (set) Token: 0x0600C2ED RID: 49901 RVA: 0x000572A0 File Offset: 0x000554A0
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17004D77 RID: 19831
		' (get) Token: 0x0600C2EE RID: 49902 RVA: 0x000572A9 File Offset: 0x000554A9
		' (set) Token: 0x0600C2EF RID: 49903 RVA: 0x007BCD68 File Offset: 0x007BAF68
		Private _btnGetData As GelButton
		Friend Overridable Property btnGetData As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
				Dim gelButton As GelButton = Me._btnGetData
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnGetData = value
				gelButton = Me._btnGetData
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D78 RID: 19832
		' (get) Token: 0x0600C2F0 RID: 49904 RVA: 0x000572B3 File Offset: 0x000554B3
		' (set) Token: 0x0600C2F1 RID: 49905 RVA: 0x007BCDAC File Offset: 0x007BAFAC
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

		' Token: 0x17004D79 RID: 19833
		' (get) Token: 0x0600C2F2 RID: 49906 RVA: 0x000572BD File Offset: 0x000554BD
		' (set) Token: 0x0600C2F3 RID: 49907 RVA: 0x007BCDF0 File Offset: 0x007BAFF0
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

		' Token: 0x17004D7A RID: 19834
		' (get) Token: 0x0600C2F4 RID: 49908 RVA: 0x000572C7 File Offset: 0x000554C7
		' (set) Token: 0x0600C2F5 RID: 49909 RVA: 0x007BCE34 File Offset: 0x007BB034
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

		' Token: 0x17004D7B RID: 19835
		' (get) Token: 0x0600C2F6 RID: 49910 RVA: 0x000572D1 File Offset: 0x000554D1
		' (set) Token: 0x0600C2F7 RID: 49911 RVA: 0x007BCE78 File Offset: 0x007BB078
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

		' Token: 0x0600C2F8 RID: 49912 RVA: 0x007BCEBC File Offset: 0x007BB0BC
		Public Sub Reset()
			Me.txtEmployeeID.Text = ""
			Me.txtEmployeeName.Text = ""
			Me.txtCity.Text = ""
			Me.txtAddress.Text = ""
			Me.txtContactNo.Text = ""
			Me.txtEmail.Text = ""
			Me.cmbDesignation.Text = ""
			Me.cmbDepartment.Text = ""
			Me.dtpDateOfJoining.Text = Conversions.ToString(DateAndTime.Today)
			Me.txtSalary.Text = ""
			Me.cmbBloodGroup.SelectedIndex = -1
			Me.cmbGender.SelectedIndex = -1
			Me.txtBasicWorkingTime.Text = ""
			Me.btnUpdate.Enabled = False
			Me.btnDelete.Enabled = False
			Me.chkActive.Checked = True
			Me.btnSave.Enabled = True
			Me.Picture.Image = Resources.photo
			Me.auto()
			Me.txtEmployeeName.Focus()
		End Sub

		' Token: 0x0600C2F9 RID: 49913 RVA: 0x007BCFFC File Offset: 0x007BB1FC
		Private Sub auto()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT MAX(ID) FROM EmployeeRegistration"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			Dim flag As Boolean = Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.cmd.ExecuteScalar()))
			If flag Then
				Dim num As Integer = 1
				Me.txtID.Text = num.ToString()
				Me.txtEmployeeID.Text = "EMP-" + num.ToString()
			Else
				Dim num As Integer = Conversions.ToInteger(Operators.AddObject(ModCommonClasses.cmd.ExecuteScalar(), 1))
				Me.txtID.Text = num.ToString()
				Me.txtEmployeeID.Text = "EMP-" + num.ToString()
			End If
			ModCommonClasses.cmd.Dispose()
			ModCommonClasses.con.Close()
			ModCommonClasses.con.Dispose()
		End Sub

		' Token: 0x0600C2FA RID: 49914 RVA: 0x007BD104 File Offset: 0x007BB304
		Public Sub Filldepartment()
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct(department) FROM employeeregistration", sqlConnection)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbDepartment.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbDepartment.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C2FB RID: 49915 RVA: 0x007BD22C File Offset: 0x007BB42C
		Public Sub FillDesignation()
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct (designation) FROM employeeregistration", sqlConnection)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbDesignation.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbDesignation.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C2FC RID: 49916 RVA: 0x007BD354 File Offset: 0x007BB554
		Private Sub Browse_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
				openFileDialog.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;"
				openFileDialog.FilterIndex = 4
				Me.OpenFileDialog1.FileName = ""
				Dim flag As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
				If flag Then
					Me.Picture.Image = Image.FromFile(Me.OpenFileDialog1.FileName)
				End If
			Catch ex As Exception
				Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x0600C2FD RID: 49917 RVA: 0x000572DB File Offset: 0x000554DB
		Private Sub BRemove_Click(sender As Object, e As EventArgs)
			Me.Picture.Image = Resources.photo
		End Sub

		' Token: 0x0600C2FE RID: 49918 RVA: 0x007BD3F4 File Offset: 0x007BB5F4
		Private Sub BStartCapture_Click(sender As Object, e As EventArgs)
			Dim frmCamera As frmCamera = New frmCamera()
			frmCamera.ShowDialog()
			Dim flag As Boolean = ModCommonClasses.TempFileNames2.Length > 0
			If flag Then
				Me.Picture.Image = Image.FromFile(ModCommonClasses.TempFileNames2)
				Me.Photoname = ModCommonClasses.TempFileNames2
				Me.IsImageChanged = True
			End If
		End Sub

		' Token: 0x0600C2FF RID: 49919 RVA: 0x000572EF File Offset: 0x000554EF
		Private Sub frmEmployeeRegistration_Load(sender As Object, e As EventArgs)
			Me.auto()
			Me.Filldepartment()
			Me.FillDesignation()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600C300 RID: 49920 RVA: 0x007BD44C File Offset: 0x007BB64C
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

		' Token: 0x0600C301 RID: 49921 RVA: 0x007BD5C4 File Offset: 0x007BB7C4
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

		' Token: 0x0600C302 RID: 49922 RVA: 0x007BD680 File Offset: 0x007BB880
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

		' Token: 0x0600C303 RID: 49923 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600C304 RID: 49924 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600C305 RID: 49925 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600C306 RID: 49926 RVA: 0x007BD74C File Offset: 0x007BB94C
		Public Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select EmployeeRegistration.ID from EmployeeRegistration,AdvanceEntry where EmployeeRegistration.ID=AdvanceEntry.EmployeeID and EmployeeRegistration.ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("Unable to delete..Already in use in Payroll Advance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "select EmployeeRegistration.ID from EmployeeRegistration,EmployeeAttendance where EmployeeRegistration.ID=EmployeeAttendance.EmployeeID and EmployeeRegistration.ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
					If flag3 Then
						MessageBox.Show("Unable to delete..Already in use in Employee Attendance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag4 Then
							ModCommonClasses.rdr.Close()
						End If
					Else
						ModCommonClasses.con.Close()
						ModCommonClasses.con.Open()
						Dim text3 As String = "select EmployeeRegistration.ID from EmployeeRegistration,EmployeePayment where EmployeeRegistration.ID=EmployeePayment.EmployeeID and EmployeeRegistration.ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text3)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
						If flag5 Then
							MessageBox.Show("Unable to delete..Already in use in Employee Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag6 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text4 As String = If(("delete from EmployeeRegistration where ID=" + Me.txtID.Text), "")
							ModCommonClasses.cmd = New SqlCommand(text4)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
							Dim flag7 As Boolean = num > 0
							If flag7 Then
								Dim text5 As String = "deleted the record of employee '" + Me.txtEmployeeName.Text + "'"
								ModFunc.LogFunc(Me.lblUser.Text, text5)
								MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.Reset()
							Else
								MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.Reset()
							End If
							ModCommonClasses.con.Close()
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C307 RID: 49927 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbDepartment_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x0600C308 RID: 49928 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbDesignation_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x0600C309 RID: 49929 RVA: 0x007BDABC File Offset: 0x007BBCBC
		Private Sub txtSalary_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtSalary.Text
					Dim selectionStart As Integer = Me.txtSalary.SelectionStart
					Dim selectionLength As Integer = Me.txtSalary.SelectionLength
					text = text.Substring(0, selectionStart) + Conversions.ToString(keyChar) + text.Substring(selectionStart + selectionLength)
					Dim text2 As String = text
					Dim num As Integer = 0
					Dim flag3 As Boolean = Integer.TryParse(text2, num) AndAlso text.Length > 16
					If flag3 Then
						e.Handled = True
					Else
						Dim text3 As String = text
						Dim num2 As Double = 0.0
						Dim flag4 As Boolean = Double.TryParse(text3, num2) AndAlso text.IndexOf("."c) < text.Length - 3
						If flag4 Then
							e.Handled = False
						End If
					End If
				Else
					e.Handled = True
				End If
			End If
		End Sub

		' Token: 0x0600C30A RID: 49930 RVA: 0x0077BBFC File Offset: 0x00779DFC
		Private Sub txtContactNo_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "+", False) <> 0 AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "-", False) <> 0 AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0600C30B RID: 49931 RVA: 0x007BDBB4 File Offset: 0x007BBDB4
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

		' Token: 0x0600C30C RID: 49932 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub txtEmail_Validating(sender As Object, e As CancelEventArgs)
		End Sub

		' Token: 0x0600C30D RID: 49933 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub All_KD(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600C30E RID: 49934 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmEmployeeRegistration_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600C30F RID: 49935 RVA: 0x007BDCBC File Offset: 0x007BBEBC
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtSalary.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtSalary, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtSalary, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtEmployeeName.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtEmployeeName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtEmployeeName, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.txtEmail.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.txtEmail, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtEmail, String.Empty)
			End If
			Dim flag4 As Boolean = String.IsNullOrEmpty(Me.txtContactNo.Text.Trim())
			If flag4 Then
				Me.ErrorProvider1.SetError(Me.txtContactNo, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtContactNo, String.Empty)
			End If
			Dim flag5 As Boolean = String.IsNullOrEmpty(Me.txtCity.Text.Trim())
			If flag5 Then
				Me.ErrorProvider1.SetError(Me.txtCity, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtCity, String.Empty)
			End If
			Dim flag6 As Boolean = String.IsNullOrEmpty(Me.txtBasicWorkingTime.Text.Trim())
			If flag6 Then
				Me.ErrorProvider1.SetError(Me.txtBasicWorkingTime, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtBasicWorkingTime, String.Empty)
			End If
			Dim flag7 As Boolean = String.IsNullOrEmpty(Me.txtAddress.Text.Trim())
			If flag7 Then
				Me.ErrorProvider1.SetError(Me.txtAddress, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtAddress, String.Empty)
			End If
			Dim flag8 As Boolean = String.IsNullOrEmpty(Me.cmbGender.Text.Trim())
			If flag8 Then
				Me.ErrorProvider1.SetError(Me.cmbGender, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbGender, String.Empty)
			End If
			Dim flag9 As Boolean = String.IsNullOrEmpty(Me.cmbDesignation.Text.Trim())
			If flag9 Then
				Me.ErrorProvider1.SetError(Me.cmbDesignation, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbDesignation, String.Empty)
			End If
			Dim flag10 As Boolean = String.IsNullOrEmpty(Me.cmbDepartment.Text.Trim())
			If flag10 Then
				Me.ErrorProvider1.SetError(Me.cmbDepartment, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbDepartment, String.Empty)
			End If
			Dim flag11 As Boolean = String.IsNullOrEmpty(Me.cmbBloodGroup.Text.Trim())
			If flag11 Then
				Me.ErrorProvider1.SetError(Me.cmbBloodGroup, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbBloodGroup, String.Empty)
			End If
		End Sub

		' Token: 0x0600C310 RID: 49936 RVA: 0x0005730E File Offset: 0x0005550E
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600C311 RID: 49937 RVA: 0x007BE01C File Offset: 0x007BC21C
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Me.auto()
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
				Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtEmployeeName.Text)) = 0
				If flag3 Then
					MessageBox.Show("Please enter employee name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtEmployeeName.Focus()
				Else
					Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.cmbGender.Text)) = 0
					If flag4 Then
						MessageBox.Show("Please select gender", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbGender.Focus()
					Else
						Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.txtAddress.Text)) = 0
						If flag5 Then
							MessageBox.Show("Please enter address", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtAddress.Focus()
						Else
							Dim flag6 As Boolean = Strings.Len(Strings.Trim(Me.txtCity.Text)) = 0
							If flag6 Then
								MessageBox.Show("Please enter city", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtCity.Focus()
							Else
								Dim flag7 As Boolean = Strings.Len(Strings.Trim(Me.txtContactNo.Text)) = 0
								If flag7 Then
									MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtContactNo.Focus()
								Else
									Dim flag8 As Boolean = Strings.Len(Strings.Trim(Me.cmbDepartment.Text)) = 0
									If flag8 Then
										MessageBox.Show("Please enter/select department", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.cmbDepartment.Focus()
									Else
										Dim flag9 As Boolean = Strings.Len(Strings.Trim(Me.cmbDesignation.Text)) = 0
										If flag9 Then
											MessageBox.Show("Please enter/select designation", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.cmbDesignation.Focus()
										Else
											Dim flag10 As Boolean = Strings.Len(Strings.Trim(Me.txtSalary.Text)) = 0
											If flag10 Then
												MessageBox.Show("Please enter basic Salary", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Me.txtSalary.Focus()
											Else
												Dim flag11 As Boolean = Operators.CompareString(Me.txtBasicWorkingTime.Text, "", False) = 0
												If flag11 Then
													MessageBox.Show("Please enter basic working time", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Me.txtBasicWorkingTime.Focus()
												Else
													Try
														Dim checked As Boolean = Me.chkActive.Checked
														If checked Then
															Me.st1 = "Yes"
														Else
															Me.st1 = "No"
														End If
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text2 As String = "insert into employeeregistration(id,employeeid,employeename,Gender,address,City,contactno,email,bloodgroup,department,designation,dateofjoining,salary,basicworkingtime,photo,Active) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"
														ModCommonClasses.cmd = New SqlCommand(text2)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Me.txtID.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtEmployeeID.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtEmployeeName.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbGender.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtAddress.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtCity.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtContactNo.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtEmail.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.cmbBloodGroup.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.cmbDepartment.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.cmbDesignation.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.dtpDateOfJoining.Value.[Date])
														ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(Me.txtSalary.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.txtBasicWorkingTime.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Me.st1)
														Dim memoryStream As MemoryStream = New MemoryStream()
														Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
														bitmap.Save(memoryStream, ImageFormat.Jpeg)
														Dim buffer As Byte() = memoryStream.GetBuffer()
														Dim sqlParameter As SqlParameter = New SqlParameter("@d14", SqlDbType.Image)
														sqlParameter.Value = buffer
														ModCommonClasses.cmd.Parameters.Add(sqlParameter)
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModCommonClasses.con.Close()
														Dim text3 As String = "added the new employee '" + Me.txtEmployeeName.Text + "'"
														ModFunc.LogFunc(Me.lblUser.Text, text3)
														MessageBox.Show("Successfully saved", "Employee Profile", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
														Me.btnSave.Enabled = False
														Me.Filldepartment()
														Me.FillDesignation()
														ModCommonClasses.con.Close()
													Catch ex As Exception
														MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													End Try
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
		End Sub

		' Token: 0x0600C312 RID: 49938 RVA: 0x007BE69C File Offset: 0x007BC89C
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtEmployeeName.Text)) = 0
			If flag Then
				MessageBox.Show("Please enter employee name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtEmployeeName.Focus()
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.cmbGender.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please select gender", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbGender.Focus()
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtAddress.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please enter address", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtAddress.Focus()
					Else
						Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.txtCity.Text)) = 0
						If flag4 Then
							MessageBox.Show("Please enter city", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtCity.Focus()
						Else
							Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.txtContactNo.Text)) = 0
							If flag5 Then
								MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtContactNo.Focus()
							Else
								Dim flag6 As Boolean = Strings.Len(Strings.Trim(Me.cmbDepartment.Text)) = 0
								If flag6 Then
									MessageBox.Show("Please enter/select department", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.cmbDepartment.Focus()
								Else
									Dim flag7 As Boolean = Strings.Len(Strings.Trim(Me.cmbDesignation.Text)) = 0
									If flag7 Then
										MessageBox.Show("Please enter/select designation", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.cmbDesignation.Focus()
									Else
										Dim flag8 As Boolean = Strings.Len(Strings.Trim(Me.txtSalary.Text)) = 0
										If flag8 Then
											MessageBox.Show("Please enter basic Salary", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.txtSalary.Focus()
										Else
											Dim flag9 As Boolean = Operators.CompareString(Me.txtBasicWorkingTime.Text, "", False) = 0
											If flag9 Then
												MessageBox.Show("Please enter basic working time", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Me.txtBasicWorkingTime.Focus()
											Else
												Try
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text As String = "update LedgerBook set [Name]=@d3 where PartyID=@d1 and Name=@d2"
													ModCommonClasses.cmd = New SqlCommand(text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtEmployeeID.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtEmpName.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtEmployeeName.Text)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.cmd.ExecuteNonQuery()
													ModCommonClasses.con.Close()
													Dim checked As Boolean = Me.chkActive.Checked
													If checked Then
														Me.st1 = "Yes"
													Else
														Me.st1 = "No"
													End If
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text2 As String = If(("update employeeregistration set employeeid=@d1,employeename=@d2,Gender=@d3,address=@d4,City=@d5,contactno=@d6,email=@d7,bloodgroup=@d8,department=@d9,designation=@d10,dateofjoining=@d11,salary=@d12,basicworkingtime=@d13,photo=@d14,Active='" + Me.st1 + "' where id=" + Me.txtID.Text), "")
													ModCommonClasses.cmd = New SqlCommand(text2)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtEmployeeID.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtEmployeeName.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbGender.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtAddress.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtCity.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtContactNo.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtEmail.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.cmbBloodGroup.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.cmbDepartment.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.cmbDesignation.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.dtpDateOfJoining.Value.[Date])
													ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(Me.txtSalary.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.txtBasicWorkingTime.Text)
													Dim memoryStream As MemoryStream = New MemoryStream()
													Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
													bitmap.Save(memoryStream, ImageFormat.Jpeg)
													Dim buffer As Byte() = memoryStream.GetBuffer()
													Dim sqlParameter As SqlParameter = New SqlParameter("@d14", SqlDbType.Image)
													sqlParameter.Value = buffer
													ModCommonClasses.cmd.Parameters.Add(sqlParameter)
													ModCommonClasses.cmd.ExecuteNonQuery()
													ModCommonClasses.con.Close()
													Dim text3 As String = "updated the record of employee '" + Me.txtEmployeeName.Text + "'"
													ModFunc.LogFunc(Me.lblUser.Text, text3)
													MessageBox.Show("Successfully updated", "Employee Profile", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
													Me.btnUpdate.Enabled = False
													Me.Filldepartment()
													Me.FillDesignation()
													ModCommonClasses.con.Close()
												Catch ex As Exception
													MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
												End Try
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600C313 RID: 49939 RVA: 0x007BED14 File Offset: 0x007BCF14
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

		' Token: 0x0600C314 RID: 49940 RVA: 0x00057318 File Offset: 0x00055518
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmEmployeesRecord.lblSet.Text = "Employee"
			MyProject.Forms.frmEmployeesRecord.Reset()
			MyProject.Forms.frmEmployeesRecord.ShowDialog()
		End Sub

		' Token: 0x04004E31 RID: 20017
		Private Photoname As String

		' Token: 0x04004E32 RID: 20018
		Private IsImageChanged As Boolean

		' Token: 0x04004E33 RID: 20019
		Private st1 As String
	End Class
End Namespace
