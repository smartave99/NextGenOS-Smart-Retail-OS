Imports System
Imports System.CodeDom.Compiler
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Diagnostics
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint.My
	' Token: 0x0200000B RID: 11
	<HideModuleName()>
	<GeneratedCode("MyTemplate", "11.0.0.0")>
	Friend Module MyProject
		' Token: 0x17000011 RID: 17
		' (get) Token: 0x06000039 RID: 57 RVA: 0x000811FC File Offset: 0x0007F3FC
		<HelpKeyword("My.Computer")>
		Friend ReadOnly Property Computer As MyComputer
			<DebuggerHidden()>
			Get
				Return MyProject.m_ComputerObjectProvider.GetInstance
			End Get
		End Property

		' Token: 0x17000012 RID: 18
		' (get) Token: 0x0600003A RID: 58 RVA: 0x00081218 File Offset: 0x0007F418
		<HelpKeyword("My.Application")>
		Friend ReadOnly Property Application As MyApplication
			<DebuggerHidden()>
			Get
				Return MyProject.m_AppObjectProvider.GetInstance
			End Get
		End Property

		' Token: 0x17000013 RID: 19
		' (get) Token: 0x0600003B RID: 59 RVA: 0x00081234 File Offset: 0x0007F434
		<HelpKeyword("My.User")>
		Friend ReadOnly Property User As User
			<DebuggerHidden()>
			Get
				Return MyProject.m_UserObjectProvider.GetInstance
			End Get
		End Property

		' Token: 0x17000014 RID: 20
		' (get) Token: 0x0600003C RID: 60 RVA: 0x00081250 File Offset: 0x0007F450
		<HelpKeyword("My.Forms")>
		Friend ReadOnly Property Forms As MyProject.MyForms
			<DebuggerHidden()>
			Get
				Return MyProject.m_MyFormsObjectProvider.GetInstance
			End Get
		End Property

		' Token: 0x17000015 RID: 21
		' (get) Token: 0x0600003D RID: 61 RVA: 0x0008126C File Offset: 0x0007F46C
		<HelpKeyword("My.WebServices")>
		Friend ReadOnly Property WebServices As MyProject.MyWebServices
			<DebuggerHidden()>
			Get
				Return MyProject.m_MyWebServicesObjectProvider.GetInstance
			End Get
		End Property

		' Token: 0x04000011 RID: 17
		Private m_ComputerObjectProvider As MyProject.ThreadSafeObjectProvider(Of MyComputer) = New MyProject.ThreadSafeObjectProvider(Of MyComputer)()

		' Token: 0x04000012 RID: 18
		Private m_AppObjectProvider As MyProject.ThreadSafeObjectProvider(Of MyApplication) = New MyProject.ThreadSafeObjectProvider(Of MyApplication)()

		' Token: 0x04000013 RID: 19
		Private m_UserObjectProvider As MyProject.ThreadSafeObjectProvider(Of User) = New MyProject.ThreadSafeObjectProvider(Of User)()

		' Token: 0x04000014 RID: 20
		Private m_MyFormsObjectProvider As MyProject.ThreadSafeObjectProvider(Of MyProject.MyForms) = New MyProject.ThreadSafeObjectProvider(Of MyProject.MyForms)()

		' Token: 0x04000015 RID: 21
		Private m_MyWebServicesObjectProvider As MyProject.ThreadSafeObjectProvider(Of MyProject.MyWebServices) = New MyProject.ThreadSafeObjectProvider(Of MyProject.MyWebServices)()

		' Token: 0x0200000C RID: 12
		<EditorBrowsable(EditorBrowsableState.Never)>
		Friend NotInheritable Class MyForms
			' Token: 0x0600003E RID: 62 RVA: 0x00081288 File Offset: 0x0007F488
			<DebuggerHidden()>
			Private Shared Function Create__Instance__(Of T As{Global.System.Windows.Forms.Form, New})(Instance As T) As T
				Dim flag As Boolean = Instance Is Nothing OrElse Instance.IsDisposed
				If flag Then
					Dim flag2 As Boolean = MyProject.MyForms.m_FormBeingCreated IsNot Nothing
					If flag2 Then
						Dim flag3 As Boolean = MyProject.MyForms.m_FormBeingCreated.ContainsKey(GetType(T))
						If flag3 Then
							Throw New InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", New String(-1) {}))
						End If
					Else
						MyProject.MyForms.m_FormBeingCreated = New Hashtable()
					End If
					MyProject.MyForms.m_FormBeingCreated.Add(GetType(T), Nothing)
					Try
						Return New T()
					Catch ex As TargetInvocationException When ex.InnerException IsNot Nothing
						Dim resourceString As String = Utils.GetResourceString("WinForms_SeeInnerException", New String() { ex.InnerException.Message })
						Throw New InvalidOperationException(resourceString, ex.InnerException)
					Finally
						MyProject.MyForms.m_FormBeingCreated.Remove(GetType(T))
					End Try
				End If
				Return Instance
			End Function

			' Token: 0x0600003F RID: 63 RVA: 0x000023D9 File Offset: 0x000005D9
			<DebuggerHidden()>
			Private Sub Dispose__Instance__(Of T As Global.System.Windows.Forms.Form)(ByRef instance As T)
				instance.Dispose()
				instance = Nothing
			End Sub

			' Token: 0x06000040 RID: 64 RVA: 0x000023F0 File Offset: 0x000005F0
			<DebuggerHidden()>
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Sub New()
			End Sub

			' Token: 0x06000041 RID: 65 RVA: 0x000813B0 File Offset: 0x0007F5B0
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Overrides Function Equals(o As Object) As Boolean
				Return MyBase.Equals(RuntimeHelpers.GetObjectValue(o))
			End Function

			' Token: 0x06000042 RID: 66 RVA: 0x000813D0 File Offset: 0x0007F5D0
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Overrides Function GetHashCode() As Integer
				Return MyBase.GetHashCode()
			End Function

			' Token: 0x06000043 RID: 67 RVA: 0x000813E8 File Offset: 0x0007F5E8
			<EditorBrowsable(EditorBrowsableState.Never)>
			Friend Function [GetType]() As Type
				Return GetType(MyProject.MyForms)
			End Function

			' Token: 0x06000044 RID: 68 RVA: 0x00081404 File Offset: 0x0007F604
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Overrides Function ToString() As String
				Return MyBase.ToString()
			End Function

			' Token: 0x17000016 RID: 22
			' (get) Token: 0x06000045 RID: 69 RVA: 0x000023FA File Offset: 0x000005FA
			' (set) Token: 0x060001CF RID: 463 RVA: 0x00004D88 File Offset: 0x00002F88
			Public Property BalanceSheetForm As BalanceSheetForm
				<DebuggerHidden()>
				Get
					Me.m_BalanceSheetForm = MyProject.MyForms.Create__Instance__(Of BalanceSheetForm)(Me.m_BalanceSheetForm)
					Return Me.m_BalanceSheetForm
				End Get
				<DebuggerHidden()>
				Set(value As BalanceSheetForm)
					If value IsNot Me.m_BalanceSheetForm Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of BalanceSheetForm)(Me.m_BalanceSheetForm)
					End If
				End Set
			End Property

			' Token: 0x17000017 RID: 23
			' (get) Token: 0x06000046 RID: 70 RVA: 0x00002415 File Offset: 0x00000615
			' (set) Token: 0x060001D0 RID: 464 RVA: 0x00004DB4 File Offset: 0x00002FB4
			Public Property btnGetData As btnGetData
				<DebuggerHidden()>
				Get
					Me.m_btnGetData = MyProject.MyForms.Create__Instance__(Of btnGetData)(Me.m_btnGetData)
					Return Me.m_btnGetData
				End Get
				<DebuggerHidden()>
				Set(value As btnGetData)
					If value IsNot Me.m_btnGetData Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of btnGetData)(Me.m_btnGetData)
					End If
				End Set
			End Property

			' Token: 0x17000018 RID: 24
			' (get) Token: 0x06000047 RID: 71 RVA: 0x00002430 File Offset: 0x00000630
			' (set) Token: 0x060001D1 RID: 465 RVA: 0x00004DE0 File Offset: 0x00002FE0
			Public Property Calculator As Calculator
				<DebuggerHidden()>
				Get
					Me.m_Calculator = MyProject.MyForms.Create__Instance__(Of Calculator)(Me.m_Calculator)
					Return Me.m_Calculator
				End Get
				<DebuggerHidden()>
				Set(value As Calculator)
					If value IsNot Me.m_Calculator Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Calculator)(Me.m_Calculator)
					End If
				End Set
			End Property

			' Token: 0x17000019 RID: 25
			' (get) Token: 0x06000048 RID: 72 RVA: 0x0000244B File Offset: 0x0000064B
			' (set) Token: 0x060001D2 RID: 466 RVA: 0x00004E0C File Offset: 0x0000300C
			Public Property Calender As Calender
				<DebuggerHidden()>
				Get
					Me.m_Calender = MyProject.MyForms.Create__Instance__(Of Calender)(Me.m_Calender)
					Return Me.m_Calender
				End Get
				<DebuggerHidden()>
				Set(value As Calender)
					If value IsNot Me.m_Calender Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Calender)(Me.m_Calender)
					End If
				End Set
			End Property

			' Token: 0x1700001A RID: 26
			' (get) Token: 0x06000049 RID: 73 RVA: 0x00002466 File Offset: 0x00000666
			' (set) Token: 0x060001D3 RID: 467 RVA: 0x00004E38 File Offset: 0x00003038
			Public Property Cashrefund As Cashrefund
				<DebuggerHidden()>
				Get
					Me.m_Cashrefund = MyProject.MyForms.Create__Instance__(Of Cashrefund)(Me.m_Cashrefund)
					Return Me.m_Cashrefund
				End Get
				<DebuggerHidden()>
				Set(value As Cashrefund)
					If value IsNot Me.m_Cashrefund Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Cashrefund)(Me.m_Cashrefund)
					End If
				End Set
			End Property

			' Token: 0x1700001B RID: 27
			' (get) Token: 0x0600004A RID: 74 RVA: 0x00002481 File Offset: 0x00000681
			' (set) Token: 0x060001D4 RID: 468 RVA: 0x00004E64 File Offset: 0x00003064
			Public Property Denomination As Denomination
				<DebuggerHidden()>
				Get
					Me.m_Denomination = MyProject.MyForms.Create__Instance__(Of Denomination)(Me.m_Denomination)
					Return Me.m_Denomination
				End Get
				<DebuggerHidden()>
				Set(value As Denomination)
					If value IsNot Me.m_Denomination Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Denomination)(Me.m_Denomination)
					End If
				End Set
			End Property

			' Token: 0x1700001C RID: 28
			' (get) Token: 0x0600004B RID: 75 RVA: 0x0000249C File Offset: 0x0000069C
			' (set) Token: 0x060001D5 RID: 469 RVA: 0x00004E90 File Offset: 0x00003090
			Public Property Error5 As Error5
				<DebuggerHidden()>
				Get
					Me.m_Error5 = MyProject.MyForms.Create__Instance__(Of Error5)(Me.m_Error5)
					Return Me.m_Error5
				End Get
				<DebuggerHidden()>
				Set(value As Error5)
					If value IsNot Me.m_Error5 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Error5)(Me.m_Error5)
					End If
				End Set
			End Property

			' Token: 0x1700001D RID: 29
			' (get) Token: 0x0600004C RID: 76 RVA: 0x000024B7 File Offset: 0x000006B7
			' (set) Token: 0x060001D6 RID: 470 RVA: 0x00004EBC File Offset: 0x000030BC
			Public Property Error6 As Error6
				<DebuggerHidden()>
				Get
					Me.m_Error6 = MyProject.MyForms.Create__Instance__(Of Error6)(Me.m_Error6)
					Return Me.m_Error6
				End Get
				<DebuggerHidden()>
				Set(value As Error6)
					If value IsNot Me.m_Error6 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Error6)(Me.m_Error6)
					End If
				End Set
			End Property

			' Token: 0x1700001E RID: 30
			' (get) Token: 0x0600004D RID: 77 RVA: 0x000024D2 File Offset: 0x000006D2
			' (set) Token: 0x060001D7 RID: 471 RVA: 0x00004EE8 File Offset: 0x000030E8
			Public Property Error8 As Error8
				<DebuggerHidden()>
				Get
					Me.m_Error8 = MyProject.MyForms.Create__Instance__(Of Error8)(Me.m_Error8)
					Return Me.m_Error8
				End Get
				<DebuggerHidden()>
				Set(value As Error8)
					If value IsNot Me.m_Error8 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Error8)(Me.m_Error8)
					End If
				End Set
			End Property

			' Token: 0x1700001F RID: 31
			' (get) Token: 0x0600004E RID: 78 RVA: 0x000024ED File Offset: 0x000006ED
			' (set) Token: 0x060001D8 RID: 472 RVA: 0x00004F14 File Offset: 0x00003114
			Public Property Form As Form
				<DebuggerHidden()>
				Get
					Me.m_Form = MyProject.MyForms.Create__Instance__(Of Form)(Me.m_Form)
					Return Me.m_Form
				End Get
				<DebuggerHidden()>
				Set(value As Form)
					If value IsNot Me.m_Form Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Form)(Me.m_Form)
					End If
				End Set
			End Property

			' Token: 0x17000020 RID: 32
			' (get) Token: 0x0600004F RID: 79 RVA: 0x00002508 File Offset: 0x00000708
			' (set) Token: 0x060001D9 RID: 473 RVA: 0x00004F40 File Offset: 0x00003140
			Public Property Form1 As Form1
				<DebuggerHidden()>
				Get
					Me.m_Form1 = MyProject.MyForms.Create__Instance__(Of Form1)(Me.m_Form1)
					Return Me.m_Form1
				End Get
				<DebuggerHidden()>
				Set(value As Form1)
					If value IsNot Me.m_Form1 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Form1)(Me.m_Form1)
					End If
				End Set
			End Property

			' Token: 0x17000021 RID: 33
			' (get) Token: 0x06000050 RID: 80 RVA: 0x00002523 File Offset: 0x00000723
			' (set) Token: 0x060001DA RID: 474 RVA: 0x00004F6C File Offset: 0x0000316C
			Public Property Form2 As Form2
				<DebuggerHidden()>
				Get
					Me.m_Form2 = MyProject.MyForms.Create__Instance__(Of Form2)(Me.m_Form2)
					Return Me.m_Form2
				End Get
				<DebuggerHidden()>
				Set(value As Form2)
					If value IsNot Me.m_Form2 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Form2)(Me.m_Form2)
					End If
				End Set
			End Property

			' Token: 0x17000022 RID: 34
			' (get) Token: 0x06000051 RID: 81 RVA: 0x0000253E File Offset: 0x0000073E
			' (set) Token: 0x060001DB RID: 475 RVA: 0x00004F98 File Offset: 0x00003198
			Public Property Form3 As Form3
				<DebuggerHidden()>
				Get
					Me.m_Form3 = MyProject.MyForms.Create__Instance__(Of Form3)(Me.m_Form3)
					Return Me.m_Form3
				End Get
				<DebuggerHidden()>
				Set(value As Form3)
					If value IsNot Me.m_Form3 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Form3)(Me.m_Form3)
					End If
				End Set
			End Property

			' Token: 0x17000023 RID: 35
			' (get) Token: 0x06000052 RID: 82 RVA: 0x00002559 File Offset: 0x00000759
			' (set) Token: 0x060001DC RID: 476 RVA: 0x00004FC4 File Offset: 0x000031C4
			Public Property Form4 As Form4
				<DebuggerHidden()>
				Get
					Me.m_Form4 = MyProject.MyForms.Create__Instance__(Of Form4)(Me.m_Form4)
					Return Me.m_Form4
				End Get
				<DebuggerHidden()>
				Set(value As Form4)
					If value IsNot Me.m_Form4 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Form4)(Me.m_Form4)
					End If
				End Set
			End Property

			' Token: 0x17000024 RID: 36
			' (get) Token: 0x06000053 RID: 83 RVA: 0x00002574 File Offset: 0x00000774
			' (set) Token: 0x060001DD RID: 477 RVA: 0x00004FF0 File Offset: 0x000031F0
			Public Property FormCamera As FormCamera
				<DebuggerHidden()>
				Get
					Me.m_FormCamera = MyProject.MyForms.Create__Instance__(Of FormCamera)(Me.m_FormCamera)
					Return Me.m_FormCamera
				End Get
				<DebuggerHidden()>
				Set(value As FormCamera)
					If value IsNot Me.m_FormCamera Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of FormCamera)(Me.m_FormCamera)
					End If
				End Set
			End Property

			' Token: 0x17000025 RID: 37
			' (get) Token: 0x06000054 RID: 84 RVA: 0x0000258F File Offset: 0x0000078F
			' (set) Token: 0x060001DE RID: 478 RVA: 0x0000501C File Offset: 0x0000321C
			Public Property frmAbout As frmAbout
				<DebuggerHidden()>
				Get
					Me.m_frmAbout = MyProject.MyForms.Create__Instance__(Of frmAbout)(Me.m_frmAbout)
					Return Me.m_frmAbout
				End Get
				<DebuggerHidden()>
				Set(value As frmAbout)
					If value IsNot Me.m_frmAbout Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmAbout)(Me.m_frmAbout)
					End If
				End Set
			End Property

			' Token: 0x17000026 RID: 38
			' (get) Token: 0x06000055 RID: 85 RVA: 0x000025AA File Offset: 0x000007AA
			' (set) Token: 0x060001DF RID: 479 RVA: 0x00005048 File Offset: 0x00003248
			Public Property frmAccountHead As frmAccountHead
				<DebuggerHidden()>
				Get
					Me.m_frmAccountHead = MyProject.MyForms.Create__Instance__(Of frmAccountHead)(Me.m_frmAccountHead)
					Return Me.m_frmAccountHead
				End Get
				<DebuggerHidden()>
				Set(value As frmAccountHead)
					If value IsNot Me.m_frmAccountHead Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmAccountHead)(Me.m_frmAccountHead)
					End If
				End Set
			End Property

			' Token: 0x17000027 RID: 39
			' (get) Token: 0x06000056 RID: 86 RVA: 0x000025C5 File Offset: 0x000007C5
			' (set) Token: 0x060001E0 RID: 480 RVA: 0x00005074 File Offset: 0x00003274
			Public Property frmAdvanceEntry As frmAdvanceEntry
				<DebuggerHidden()>
				Get
					Me.m_frmAdvanceEntry = MyProject.MyForms.Create__Instance__(Of frmAdvanceEntry)(Me.m_frmAdvanceEntry)
					Return Me.m_frmAdvanceEntry
				End Get
				<DebuggerHidden()>
				Set(value As frmAdvanceEntry)
					If value IsNot Me.m_frmAdvanceEntry Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmAdvanceEntry)(Me.m_frmAdvanceEntry)
					End If
				End Set
			End Property

			' Token: 0x17000028 RID: 40
			' (get) Token: 0x06000057 RID: 87 RVA: 0x000025E0 File Offset: 0x000007E0
			' (set) Token: 0x060001E1 RID: 481 RVA: 0x000050A0 File Offset: 0x000032A0
			Public Property frmAdvanceEntryRecord As frmAdvanceEntryRecord
				<DebuggerHidden()>
				Get
					Me.m_frmAdvanceEntryRecord = MyProject.MyForms.Create__Instance__(Of frmAdvanceEntryRecord)(Me.m_frmAdvanceEntryRecord)
					Return Me.m_frmAdvanceEntryRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmAdvanceEntryRecord)
					If value IsNot Me.m_frmAdvanceEntryRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmAdvanceEntryRecord)(Me.m_frmAdvanceEntryRecord)
					End If
				End Set
			End Property

			' Token: 0x17000029 RID: 41
			' (get) Token: 0x06000058 RID: 88 RVA: 0x000025FB File Offset: 0x000007FB
			' (set) Token: 0x060001E2 RID: 482 RVA: 0x000050CC File Offset: 0x000032CC
			Public Property frmAdvanceEntryReport As frmAdvanceEntryReport
				<DebuggerHidden()>
				Get
					Me.m_frmAdvanceEntryReport = MyProject.MyForms.Create__Instance__(Of frmAdvanceEntryReport)(Me.m_frmAdvanceEntryReport)
					Return Me.m_frmAdvanceEntryReport
				End Get
				<DebuggerHidden()>
				Set(value As frmAdvanceEntryReport)
					If value IsNot Me.m_frmAdvanceEntryReport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmAdvanceEntryReport)(Me.m_frmAdvanceEntryReport)
					End If
				End Set
			End Property

			' Token: 0x1700002A RID: 42
			' (get) Token: 0x06000059 RID: 89 RVA: 0x00002616 File Offset: 0x00000816
			' (set) Token: 0x060001E3 RID: 483 RVA: 0x000050F8 File Offset: 0x000032F8
			Public Property FrmApp As FrmApp
				<DebuggerHidden()>
				Get
					Me.m_FrmApp = MyProject.MyForms.Create__Instance__(Of FrmApp)(Me.m_FrmApp)
					Return Me.m_FrmApp
				End Get
				<DebuggerHidden()>
				Set(value As FrmApp)
					If value IsNot Me.m_FrmApp Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of FrmApp)(Me.m_FrmApp)
					End If
				End Set
			End Property

			' Token: 0x1700002B RID: 43
			' (get) Token: 0x0600005A RID: 90 RVA: 0x00002631 File Offset: 0x00000831
			' (set) Token: 0x060001E4 RID: 484 RVA: 0x00005124 File Offset: 0x00003324
			Public Property frmAttendance As frmAttendance
				<DebuggerHidden()>
				Get
					Me.m_frmAttendance = MyProject.MyForms.Create__Instance__(Of frmAttendance)(Me.m_frmAttendance)
					Return Me.m_frmAttendance
				End Get
				<DebuggerHidden()>
				Set(value As frmAttendance)
					If value IsNot Me.m_frmAttendance Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmAttendance)(Me.m_frmAttendance)
					End If
				End Set
			End Property

			' Token: 0x1700002C RID: 44
			' (get) Token: 0x0600005B RID: 91 RVA: 0x0000264C File Offset: 0x0000084C
			' (set) Token: 0x060001E5 RID: 485 RVA: 0x00005150 File Offset: 0x00003350
			Public Property frmAttendanceEntryRecord As frmAttendanceEntryRecord
				<DebuggerHidden()>
				Get
					Me.m_frmAttendanceEntryRecord = MyProject.MyForms.Create__Instance__(Of frmAttendanceEntryRecord)(Me.m_frmAttendanceEntryRecord)
					Return Me.m_frmAttendanceEntryRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmAttendanceEntryRecord)
					If value IsNot Me.m_frmAttendanceEntryRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmAttendanceEntryRecord)(Me.m_frmAttendanceEntryRecord)
					End If
				End Set
			End Property

			' Token: 0x1700002D RID: 45
			' (get) Token: 0x0600005C RID: 92 RVA: 0x00002667 File Offset: 0x00000867
			' (set) Token: 0x060001E6 RID: 486 RVA: 0x0000517C File Offset: 0x0000337C
			Public Property frmAuto_Migrate As frmAuto_Migrate
				<DebuggerHidden()>
				Get
					Me.m_frmAuto_Migrate = MyProject.MyForms.Create__Instance__(Of frmAuto_Migrate)(Me.m_frmAuto_Migrate)
					Return Me.m_frmAuto_Migrate
				End Get
				<DebuggerHidden()>
				Set(value As frmAuto_Migrate)
					If value IsNot Me.m_frmAuto_Migrate Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmAuto_Migrate)(Me.m_frmAuto_Migrate)
					End If
				End Set
			End Property

			' Token: 0x1700002E RID: 46
			' (get) Token: 0x0600005D RID: 93 RVA: 0x00002682 File Offset: 0x00000882
			' (set) Token: 0x060001E7 RID: 487 RVA: 0x000051A8 File Offset: 0x000033A8
			Public Property frmAutobackup As frmAutobackup
				<DebuggerHidden()>
				Get
					Me.m_frmAutobackup = MyProject.MyForms.Create__Instance__(Of frmAutobackup)(Me.m_frmAutobackup)
					Return Me.m_frmAutobackup
				End Get
				<DebuggerHidden()>
				Set(value As frmAutobackup)
					If value IsNot Me.m_frmAutobackup Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmAutobackup)(Me.m_frmAutobackup)
					End If
				End Set
			End Property

			' Token: 0x1700002F RID: 47
			' (get) Token: 0x0600005E RID: 94 RVA: 0x0000269D File Offset: 0x0000089D
			' (set) Token: 0x060001E8 RID: 488 RVA: 0x000051D4 File Offset: 0x000033D4
			Public Property frmAutoRoundoff As frmAutoRoundoff
				<DebuggerHidden()>
				Get
					Me.m_frmAutoRoundoff = MyProject.MyForms.Create__Instance__(Of frmAutoRoundoff)(Me.m_frmAutoRoundoff)
					Return Me.m_frmAutoRoundoff
				End Get
				<DebuggerHidden()>
				Set(value As frmAutoRoundoff)
					If value IsNot Me.m_frmAutoRoundoff Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmAutoRoundoff)(Me.m_frmAutoRoundoff)
					End If
				End Set
			End Property

			' Token: 0x17000030 RID: 48
			' (get) Token: 0x0600005F RID: 95 RVA: 0x000026B8 File Offset: 0x000008B8
			' (set) Token: 0x060001E9 RID: 489 RVA: 0x00005200 File Offset: 0x00003400
			Public Property frmAutoUPI As frmAutoUPI
				<DebuggerHidden()>
				Get
					Me.m_frmAutoUPI = MyProject.MyForms.Create__Instance__(Of frmAutoUPI)(Me.m_frmAutoUPI)
					Return Me.m_frmAutoUPI
				End Get
				<DebuggerHidden()>
				Set(value As frmAutoUPI)
					If value IsNot Me.m_frmAutoUPI Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmAutoUPI)(Me.m_frmAutoUPI)
					End If
				End Set
			End Property

			' Token: 0x17000031 RID: 49
			' (get) Token: 0x06000060 RID: 96 RVA: 0x000026D3 File Offset: 0x000008D3
			' (set) Token: 0x060001EA RID: 490 RVA: 0x0000522C File Offset: 0x0000342C
			Public Property frmBagBox As frmBagBox
				<DebuggerHidden()>
				Get
					Me.m_frmBagBox = MyProject.MyForms.Create__Instance__(Of frmBagBox)(Me.m_frmBagBox)
					Return Me.m_frmBagBox
				End Get
				<DebuggerHidden()>
				Set(value As frmBagBox)
					If value IsNot Me.m_frmBagBox Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBagBox)(Me.m_frmBagBox)
					End If
				End Set
			End Property

			' Token: 0x17000032 RID: 50
			' (get) Token: 0x06000061 RID: 97 RVA: 0x000026EE File Offset: 0x000008EE
			' (set) Token: 0x060001EB RID: 491 RVA: 0x00005258 File Offset: 0x00003458
			Public Property frmBalancesheet As frmBalancesheet
				<DebuggerHidden()>
				Get
					Me.m_frmBalancesheet = MyProject.MyForms.Create__Instance__(Of frmBalancesheet)(Me.m_frmBalancesheet)
					Return Me.m_frmBalancesheet
				End Get
				<DebuggerHidden()>
				Set(value As frmBalancesheet)
					If value IsNot Me.m_frmBalancesheet Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBalancesheet)(Me.m_frmBalancesheet)
					End If
				End Set
			End Property

			' Token: 0x17000033 RID: 51
			' (get) Token: 0x06000062 RID: 98 RVA: 0x00002709 File Offset: 0x00000909
			' (set) Token: 0x060001EC RID: 492 RVA: 0x00005284 File Offset: 0x00003484
			Public Property frmBanarCreate As frmBanarCreate
				<DebuggerHidden()>
				Get
					Me.m_frmBanarCreate = MyProject.MyForms.Create__Instance__(Of frmBanarCreate)(Me.m_frmBanarCreate)
					Return Me.m_frmBanarCreate
				End Get
				<DebuggerHidden()>
				Set(value As frmBanarCreate)
					If value IsNot Me.m_frmBanarCreate Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBanarCreate)(Me.m_frmBanarCreate)
					End If
				End Set
			End Property

			' Token: 0x17000034 RID: 52
			' (get) Token: 0x06000063 RID: 99 RVA: 0x00002724 File Offset: 0x00000924
			' (set) Token: 0x060001ED RID: 493 RVA: 0x000052B0 File Offset: 0x000034B0
			Public Property frmBank As frmBank
				<DebuggerHidden()>
				Get
					Me.m_frmBank = MyProject.MyForms.Create__Instance__(Of frmBank)(Me.m_frmBank)
					Return Me.m_frmBank
				End Get
				<DebuggerHidden()>
				Set(value As frmBank)
					If value IsNot Me.m_frmBank Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBank)(Me.m_frmBank)
					End If
				End Set
			End Property

			' Token: 0x17000035 RID: 53
			' (get) Token: 0x06000064 RID: 100 RVA: 0x0000273F File Offset: 0x0000093F
			' (set) Token: 0x060001EE RID: 494 RVA: 0x000052DC File Offset: 0x000034DC
			Public Property frmBankAccountRegistration As frmBankAccountRegistration
				<DebuggerHidden()>
				Get
					Me.m_frmBankAccountRegistration = MyProject.MyForms.Create__Instance__(Of frmBankAccountRegistration)(Me.m_frmBankAccountRegistration)
					Return Me.m_frmBankAccountRegistration
				End Get
				<DebuggerHidden()>
				Set(value As frmBankAccountRegistration)
					If value IsNot Me.m_frmBankAccountRegistration Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBankAccountRegistration)(Me.m_frmBankAccountRegistration)
					End If
				End Set
			End Property

			' Token: 0x17000036 RID: 54
			' (get) Token: 0x06000065 RID: 101 RVA: 0x0000275A File Offset: 0x0000095A
			' (set) Token: 0x060001EF RID: 495 RVA: 0x00005308 File Offset: 0x00003508
			Public Property frmBankAccountStatements As frmBankAccountStatements
				<DebuggerHidden()>
				Get
					Me.m_frmBankAccountStatements = MyProject.MyForms.Create__Instance__(Of frmBankAccountStatements)(Me.m_frmBankAccountStatements)
					Return Me.m_frmBankAccountStatements
				End Get
				<DebuggerHidden()>
				Set(value As frmBankAccountStatements)
					If value IsNot Me.m_frmBankAccountStatements Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBankAccountStatements)(Me.m_frmBankAccountStatements)
					End If
				End Set
			End Property

			' Token: 0x17000037 RID: 55
			' (get) Token: 0x06000066 RID: 102 RVA: 0x00002775 File Offset: 0x00000975
			' (set) Token: 0x060001F0 RID: 496 RVA: 0x00005334 File Offset: 0x00003534
			Public Property frmBankLedger As frmBankLedger
				<DebuggerHidden()>
				Get
					Me.m_frmBankLedger = MyProject.MyForms.Create__Instance__(Of frmBankLedger)(Me.m_frmBankLedger)
					Return Me.m_frmBankLedger
				End Get
				<DebuggerHidden()>
				Set(value As frmBankLedger)
					If value IsNot Me.m_frmBankLedger Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBankLedger)(Me.m_frmBankLedger)
					End If
				End Set
			End Property

			' Token: 0x17000038 RID: 56
			' (get) Token: 0x06000067 RID: 103 RVA: 0x00002790 File Offset: 0x00000990
			' (set) Token: 0x060001F1 RID: 497 RVA: 0x00005360 File Offset: 0x00003560
			Public Property frmBankList As frmBankList
				<DebuggerHidden()>
				Get
					Me.m_frmBankList = MyProject.MyForms.Create__Instance__(Of frmBankList)(Me.m_frmBankList)
					Return Me.m_frmBankList
				End Get
				<DebuggerHidden()>
				Set(value As frmBankList)
					If value IsNot Me.m_frmBankList Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBankList)(Me.m_frmBankList)
					End If
				End Set
			End Property

			' Token: 0x17000039 RID: 57
			' (get) Token: 0x06000068 RID: 104 RVA: 0x000027AB File Offset: 0x000009AB
			' (set) Token: 0x060001F2 RID: 498 RVA: 0x0000538C File Offset: 0x0000358C
			Public Property frmBarcodeLabelPrinting As frmBarcodeLabelPrinting
				<DebuggerHidden()>
				Get
					Me.m_frmBarcodeLabelPrinting = MyProject.MyForms.Create__Instance__(Of frmBarcodeLabelPrinting)(Me.m_frmBarcodeLabelPrinting)
					Return Me.m_frmBarcodeLabelPrinting
				End Get
				<DebuggerHidden()>
				Set(value As frmBarcodeLabelPrinting)
					If value IsNot Me.m_frmBarcodeLabelPrinting Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBarcodeLabelPrinting)(Me.m_frmBarcodeLabelPrinting)
					End If
				End Set
			End Property

			' Token: 0x1700003A RID: 58
			' (get) Token: 0x06000069 RID: 105 RVA: 0x000027C6 File Offset: 0x000009C6
			' (set) Token: 0x060001F3 RID: 499 RVA: 0x000053B8 File Offset: 0x000035B8
			Public Property frmBarcodeLabelPrintingnew As frmBarcodeLabelPrintingnew
				<DebuggerHidden()>
				Get
					Me.m_frmBarcodeLabelPrintingnew = MyProject.MyForms.Create__Instance__(Of frmBarcodeLabelPrintingnew)(Me.m_frmBarcodeLabelPrintingnew)
					Return Me.m_frmBarcodeLabelPrintingnew
				End Get
				<DebuggerHidden()>
				Set(value As frmBarcodeLabelPrintingnew)
					If value IsNot Me.m_frmBarcodeLabelPrintingnew Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBarcodeLabelPrintingnew)(Me.m_frmBarcodeLabelPrintingnew)
					End If
				End Set
			End Property

			' Token: 0x1700003B RID: 59
			' (get) Token: 0x0600006A RID: 106 RVA: 0x000027E1 File Offset: 0x000009E1
			' (set) Token: 0x060001F4 RID: 500 RVA: 0x000053E4 File Offset: 0x000035E4
			Public Property frmBarcodeMain As frmBarcodeMain
				<DebuggerHidden()>
				Get
					Me.m_frmBarcodeMain = MyProject.MyForms.Create__Instance__(Of frmBarcodeMain)(Me.m_frmBarcodeMain)
					Return Me.m_frmBarcodeMain
				End Get
				<DebuggerHidden()>
				Set(value As frmBarcodeMain)
					If value IsNot Me.m_frmBarcodeMain Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBarcodeMain)(Me.m_frmBarcodeMain)
					End If
				End Set
			End Property

			' Token: 0x1700003C RID: 60
			' (get) Token: 0x0600006B RID: 107 RVA: 0x000027FC File Offset: 0x000009FC
			' (set) Token: 0x060001F5 RID: 501 RVA: 0x00005410 File Offset: 0x00003610
			Public Property frmBestAndLowSellingItemsReport As frmBestAndLowSellingItemsReport
				<DebuggerHidden()>
				Get
					Me.m_frmBestAndLowSellingItemsReport = MyProject.MyForms.Create__Instance__(Of frmBestAndLowSellingItemsReport)(Me.m_frmBestAndLowSellingItemsReport)
					Return Me.m_frmBestAndLowSellingItemsReport
				End Get
				<DebuggerHidden()>
				Set(value As frmBestAndLowSellingItemsReport)
					If value IsNot Me.m_frmBestAndLowSellingItemsReport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBestAndLowSellingItemsReport)(Me.m_frmBestAndLowSellingItemsReport)
					End If
				End Set
			End Property

			' Token: 0x1700003D RID: 61
			' (get) Token: 0x0600006C RID: 108 RVA: 0x00002817 File Offset: 0x00000A17
			' (set) Token: 0x060001F6 RID: 502 RVA: 0x0000543C File Offset: 0x0000363C
			Public Property frmBillStyle As frmBillStyle
				<DebuggerHidden()>
				Get
					Me.m_frmBillStyle = MyProject.MyForms.Create__Instance__(Of frmBillStyle)(Me.m_frmBillStyle)
					Return Me.m_frmBillStyle
				End Get
				<DebuggerHidden()>
				Set(value As frmBillStyle)
					If value IsNot Me.m_frmBillStyle Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBillStyle)(Me.m_frmBillStyle)
					End If
				End Set
			End Property

			' Token: 0x1700003E RID: 62
			' (get) Token: 0x0600006D RID: 109 RVA: 0x00002832 File Offset: 0x00000A32
			' (set) Token: 0x060001F7 RID: 503 RVA: 0x00005468 File Offset: 0x00003668
			Public Property frmBillSundry As frmBillSundry
				<DebuggerHidden()>
				Get
					Me.m_frmBillSundry = MyProject.MyForms.Create__Instance__(Of frmBillSundry)(Me.m_frmBillSundry)
					Return Me.m_frmBillSundry
				End Get
				<DebuggerHidden()>
				Set(value As frmBillSundry)
					If value IsNot Me.m_frmBillSundry Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBillSundry)(Me.m_frmBillSundry)
					End If
				End Set
			End Property

			' Token: 0x1700003F RID: 63
			' (get) Token: 0x0600006E RID: 110 RVA: 0x0000284D File Offset: 0x00000A4D
			' (set) Token: 0x060001F8 RID: 504 RVA: 0x00005494 File Offset: 0x00003694
			Public Property frmBIllwise_ProfitReport As frmBIllwise_ProfitReport
				<DebuggerHidden()>
				Get
					Me.m_frmBIllwise_ProfitReport = MyProject.MyForms.Create__Instance__(Of frmBIllwise_ProfitReport)(Me.m_frmBIllwise_ProfitReport)
					Return Me.m_frmBIllwise_ProfitReport
				End Get
				<DebuggerHidden()>
				Set(value As frmBIllwise_ProfitReport)
					If value IsNot Me.m_frmBIllwise_ProfitReport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBIllwise_ProfitReport)(Me.m_frmBIllwise_ProfitReport)
					End If
				End Set
			End Property

			' Token: 0x17000040 RID: 64
			' (get) Token: 0x0600006F RID: 111 RVA: 0x00002868 File Offset: 0x00000A68
			' (set) Token: 0x060001F9 RID: 505 RVA: 0x000054C0 File Offset: 0x000036C0
			Public Property frmBranch_AddMaster As frmBranch_AddMaster
				<DebuggerHidden()>
				Get
					Me.m_frmBranch_AddMaster = MyProject.MyForms.Create__Instance__(Of frmBranch_AddMaster)(Me.m_frmBranch_AddMaster)
					Return Me.m_frmBranch_AddMaster
				End Get
				<DebuggerHidden()>
				Set(value As frmBranch_AddMaster)
					If value IsNot Me.m_frmBranch_AddMaster Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBranch_AddMaster)(Me.m_frmBranch_AddMaster)
					End If
				End Set
			End Property

			' Token: 0x17000041 RID: 65
			' (get) Token: 0x06000070 RID: 112 RVA: 0x00002883 File Offset: 0x00000A83
			' (set) Token: 0x060001FA RID: 506 RVA: 0x000054EC File Offset: 0x000036EC
			Public Property frmBranchAdmin As frmBranchAdmin
				<DebuggerHidden()>
				Get
					Me.m_frmBranchAdmin = MyProject.MyForms.Create__Instance__(Of frmBranchAdmin)(Me.m_frmBranchAdmin)
					Return Me.m_frmBranchAdmin
				End Get
				<DebuggerHidden()>
				Set(value As frmBranchAdmin)
					If value IsNot Me.m_frmBranchAdmin Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBranchAdmin)(Me.m_frmBranchAdmin)
					End If
				End Set
			End Property

			' Token: 0x17000042 RID: 66
			' (get) Token: 0x06000071 RID: 113 RVA: 0x0000289E File Offset: 0x00000A9E
			' (set) Token: 0x060001FB RID: 507 RVA: 0x00005518 File Offset: 0x00003718
			Public Property frmBranchMaster_Bank As frmBranchMaster_Bank
				<DebuggerHidden()>
				Get
					Me.m_frmBranchMaster_Bank = MyProject.MyForms.Create__Instance__(Of frmBranchMaster_Bank)(Me.m_frmBranchMaster_Bank)
					Return Me.m_frmBranchMaster_Bank
				End Get
				<DebuggerHidden()>
				Set(value As frmBranchMaster_Bank)
					If value IsNot Me.m_frmBranchMaster_Bank Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBranchMaster_Bank)(Me.m_frmBranchMaster_Bank)
					End If
				End Set
			End Property

			' Token: 0x17000043 RID: 67
			' (get) Token: 0x06000072 RID: 114 RVA: 0x000028B9 File Offset: 0x00000AB9
			' (set) Token: 0x060001FC RID: 508 RVA: 0x00005544 File Offset: 0x00003744
			Public Property frmBranchReport_Dashboard As frmBranchReport_Dashboard
				<DebuggerHidden()>
				Get
					Me.m_frmBranchReport_Dashboard = MyProject.MyForms.Create__Instance__(Of frmBranchReport_Dashboard)(Me.m_frmBranchReport_Dashboard)
					Return Me.m_frmBranchReport_Dashboard
				End Get
				<DebuggerHidden()>
				Set(value As frmBranchReport_Dashboard)
					If value IsNot Me.m_frmBranchReport_Dashboard Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBranchReport_Dashboard)(Me.m_frmBranchReport_Dashboard)
					End If
				End Set
			End Property

			' Token: 0x17000044 RID: 68
			' (get) Token: 0x06000073 RID: 115 RVA: 0x000028D4 File Offset: 0x00000AD4
			' (set) Token: 0x060001FD RID: 509 RVA: 0x00005570 File Offset: 0x00003770
			Public Property frmBroker As frmBroker
				<DebuggerHidden()>
				Get
					Me.m_frmBroker = MyProject.MyForms.Create__Instance__(Of frmBroker)(Me.m_frmBroker)
					Return Me.m_frmBroker
				End Get
				<DebuggerHidden()>
				Set(value As frmBroker)
					If value IsNot Me.m_frmBroker Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBroker)(Me.m_frmBroker)
					End If
				End Set
			End Property

			' Token: 0x17000045 RID: 69
			' (get) Token: 0x06000074 RID: 116 RVA: 0x000028EF File Offset: 0x00000AEF
			' (set) Token: 0x060001FE RID: 510 RVA: 0x0000559C File Offset: 0x0000379C
			Public Property frmBrokerCalc As frmBrokerCalc
				<DebuggerHidden()>
				Get
					Me.m_frmBrokerCalc = MyProject.MyForms.Create__Instance__(Of frmBrokerCalc)(Me.m_frmBrokerCalc)
					Return Me.m_frmBrokerCalc
				End Get
				<DebuggerHidden()>
				Set(value As frmBrokerCalc)
					If value IsNot Me.m_frmBrokerCalc Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBrokerCalc)(Me.m_frmBrokerCalc)
					End If
				End Set
			End Property

			' Token: 0x17000046 RID: 70
			' (get) Token: 0x06000075 RID: 117 RVA: 0x0000290A File Offset: 0x00000B0A
			' (set) Token: 0x060001FF RID: 511 RVA: 0x000055C8 File Offset: 0x000037C8
			Public Property frmBrokerLedger As frmBrokerLedger
				<DebuggerHidden()>
				Get
					Me.m_frmBrokerLedger = MyProject.MyForms.Create__Instance__(Of frmBrokerLedger)(Me.m_frmBrokerLedger)
					Return Me.m_frmBrokerLedger
				End Get
				<DebuggerHidden()>
				Set(value As frmBrokerLedger)
					If value IsNot Me.m_frmBrokerLedger Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBrokerLedger)(Me.m_frmBrokerLedger)
					End If
				End Set
			End Property

			' Token: 0x17000047 RID: 71
			' (get) Token: 0x06000076 RID: 118 RVA: 0x00002925 File Offset: 0x00000B25
			' (set) Token: 0x06000200 RID: 512 RVA: 0x000055F4 File Offset: 0x000037F4
			Public Property frmBulkPriceChange As frmBulkPriceChange
				<DebuggerHidden()>
				Get
					Me.m_frmBulkPriceChange = MyProject.MyForms.Create__Instance__(Of frmBulkPriceChange)(Me.m_frmBulkPriceChange)
					Return Me.m_frmBulkPriceChange
				End Get
				<DebuggerHidden()>
				Set(value As frmBulkPriceChange)
					If value IsNot Me.m_frmBulkPriceChange Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBulkPriceChange)(Me.m_frmBulkPriceChange)
					End If
				End Set
			End Property

			' Token: 0x17000048 RID: 72
			' (get) Token: 0x06000077 RID: 119 RVA: 0x00002940 File Offset: 0x00000B40
			' (set) Token: 0x06000201 RID: 513 RVA: 0x00005620 File Offset: 0x00003820
			Public Property frmBulkProductSeting As frmBulkProductSeting
				<DebuggerHidden()>
				Get
					Me.m_frmBulkProductSeting = MyProject.MyForms.Create__Instance__(Of frmBulkProductSeting)(Me.m_frmBulkProductSeting)
					Return Me.m_frmBulkProductSeting
				End Get
				<DebuggerHidden()>
				Set(value As frmBulkProductSeting)
					If value IsNot Me.m_frmBulkProductSeting Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBulkProductSeting)(Me.m_frmBulkProductSeting)
					End If
				End Set
			End Property

			' Token: 0x17000049 RID: 73
			' (get) Token: 0x06000078 RID: 120 RVA: 0x0000295B File Offset: 0x00000B5B
			' (set) Token: 0x06000202 RID: 514 RVA: 0x0000564C File Offset: 0x0000384C
			Public Property frmBulkWapp2CrCustomer As frmBulkWapp2CrCustomer
				<DebuggerHidden()>
				Get
					Me.m_frmBulkWapp2CrCustomer = MyProject.MyForms.Create__Instance__(Of frmBulkWapp2CrCustomer)(Me.m_frmBulkWapp2CrCustomer)
					Return Me.m_frmBulkWapp2CrCustomer
				End Get
				<DebuggerHidden()>
				Set(value As frmBulkWapp2CrCustomer)
					If value IsNot Me.m_frmBulkWapp2CrCustomer Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBulkWapp2CrCustomer)(Me.m_frmBulkWapp2CrCustomer)
					End If
				End Set
			End Property

			' Token: 0x1700004A RID: 74
			' (get) Token: 0x06000079 RID: 121 RVA: 0x00002976 File Offset: 0x00000B76
			' (set) Token: 0x06000203 RID: 515 RVA: 0x00005678 File Offset: 0x00003878
			Public Property frmBulkWhatsappDoc As frmBulkWhatsappDoc
				<DebuggerHidden()>
				Get
					Me.m_frmBulkWhatsappDoc = MyProject.MyForms.Create__Instance__(Of frmBulkWhatsappDoc)(Me.m_frmBulkWhatsappDoc)
					Return Me.m_frmBulkWhatsappDoc
				End Get
				<DebuggerHidden()>
				Set(value As frmBulkWhatsappDoc)
					If value IsNot Me.m_frmBulkWhatsappDoc Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmBulkWhatsappDoc)(Me.m_frmBulkWhatsappDoc)
					End If
				End Set
			End Property

			' Token: 0x1700004B RID: 75
			' (get) Token: 0x0600007A RID: 122 RVA: 0x00002991 File Offset: 0x00000B91
			' (set) Token: 0x06000204 RID: 516 RVA: 0x000056A4 File Offset: 0x000038A4
			Public Property frmCamera As frmCamera
				<DebuggerHidden()>
				Get
					Me.m_frmCamera = MyProject.MyForms.Create__Instance__(Of frmCamera)(Me.m_frmCamera)
					Return Me.m_frmCamera
				End Get
				<DebuggerHidden()>
				Set(value As frmCamera)
					If value IsNot Me.m_frmCamera Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCamera)(Me.m_frmCamera)
					End If
				End Set
			End Property

			' Token: 0x1700004C RID: 76
			' (get) Token: 0x0600007B RID: 123 RVA: 0x000029AC File Offset: 0x00000BAC
			' (set) Token: 0x06000205 RID: 517 RVA: 0x000056D0 File Offset: 0x000038D0
			Public Property frmCashLedger As frmCashLedger
				<DebuggerHidden()>
				Get
					Me.m_frmCashLedger = MyProject.MyForms.Create__Instance__(Of frmCashLedger)(Me.m_frmCashLedger)
					Return Me.m_frmCashLedger
				End Get
				<DebuggerHidden()>
				Set(value As frmCashLedger)
					If value IsNot Me.m_frmCashLedger Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCashLedger)(Me.m_frmCashLedger)
					End If
				End Set
			End Property

			' Token: 0x1700004D RID: 77
			' (get) Token: 0x0600007C RID: 124 RVA: 0x000029C7 File Offset: 0x00000BC7
			' (set) Token: 0x06000206 RID: 518 RVA: 0x000056FC File Offset: 0x000038FC
			Public Property frmCategory As frmCategory
				<DebuggerHidden()>
				Get
					Me.m_frmCategory = MyProject.MyForms.Create__Instance__(Of frmCategory)(Me.m_frmCategory)
					Return Me.m_frmCategory
				End Get
				<DebuggerHidden()>
				Set(value As frmCategory)
					If value IsNot Me.m_frmCategory Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCategory)(Me.m_frmCategory)
					End If
				End Set
			End Property

			' Token: 0x1700004E RID: 78
			' (get) Token: 0x0600007D RID: 125 RVA: 0x000029E2 File Offset: 0x00000BE2
			' (set) Token: 0x06000207 RID: 519 RVA: 0x00005728 File Offset: 0x00003928
			Public Property frmCategoryNew As frmCategoryNew
				<DebuggerHidden()>
				Get
					Me.m_frmCategoryNew = MyProject.MyForms.Create__Instance__(Of frmCategoryNew)(Me.m_frmCategoryNew)
					Return Me.m_frmCategoryNew
				End Get
				<DebuggerHidden()>
				Set(value As frmCategoryNew)
					If value IsNot Me.m_frmCategoryNew Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCategoryNew)(Me.m_frmCategoryNew)
					End If
				End Set
			End Property

			' Token: 0x1700004F RID: 79
			' (get) Token: 0x0600007E RID: 126 RVA: 0x000029FD File Offset: 0x00000BFD
			' (set) Token: 0x06000208 RID: 520 RVA: 0x00005754 File Offset: 0x00003954
			Public Property frmCategoryPopup As frmCategoryPopup
				<DebuggerHidden()>
				Get
					Me.m_frmCategoryPopup = MyProject.MyForms.Create__Instance__(Of frmCategoryPopup)(Me.m_frmCategoryPopup)
					Return Me.m_frmCategoryPopup
				End Get
				<DebuggerHidden()>
				Set(value As frmCategoryPopup)
					If value IsNot Me.m_frmCategoryPopup Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCategoryPopup)(Me.m_frmCategoryPopup)
					End If
				End Set
			End Property

			' Token: 0x17000050 RID: 80
			' (get) Token: 0x0600007F RID: 127 RVA: 0x00002A18 File Offset: 0x00000C18
			' (set) Token: 0x06000209 RID: 521 RVA: 0x00005780 File Offset: 0x00003980
			Public Property frmCatlogStyle As frmCatlogStyle
				<DebuggerHidden()>
				Get
					Me.m_frmCatlogStyle = MyProject.MyForms.Create__Instance__(Of frmCatlogStyle)(Me.m_frmCatlogStyle)
					Return Me.m_frmCatlogStyle
				End Get
				<DebuggerHidden()>
				Set(value As frmCatlogStyle)
					If value IsNot Me.m_frmCatlogStyle Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCatlogStyle)(Me.m_frmCatlogStyle)
					End If
				End Set
			End Property

			' Token: 0x17000051 RID: 81
			' (get) Token: 0x06000080 RID: 128 RVA: 0x00002A33 File Offset: 0x00000C33
			' (set) Token: 0x0600020A RID: 522 RVA: 0x000057AC File Offset: 0x000039AC
			Public Property frmChangePassword As frmChangePassword
				<DebuggerHidden()>
				Get
					Me.m_frmChangePassword = MyProject.MyForms.Create__Instance__(Of frmChangePassword)(Me.m_frmChangePassword)
					Return Me.m_frmChangePassword
				End Get
				<DebuggerHidden()>
				Set(value As frmChangePassword)
					If value IsNot Me.m_frmChangePassword Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmChangePassword)(Me.m_frmChangePassword)
					End If
				End Set
			End Property

			' Token: 0x17000052 RID: 82
			' (get) Token: 0x06000081 RID: 129 RVA: 0x00002A4E File Offset: 0x00000C4E
			' (set) Token: 0x0600020B RID: 523 RVA: 0x000057D8 File Offset: 0x000039D8
			Public Property frmChat As frmChat
				<DebuggerHidden()>
				Get
					Me.m_frmChat = MyProject.MyForms.Create__Instance__(Of frmChat)(Me.m_frmChat)
					Return Me.m_frmChat
				End Get
				<DebuggerHidden()>
				Set(value As frmChat)
					If value IsNot Me.m_frmChat Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmChat)(Me.m_frmChat)
					End If
				End Set
			End Property

			' Token: 0x17000053 RID: 83
			' (get) Token: 0x06000082 RID: 130 RVA: 0x00002A69 File Offset: 0x00000C69
			' (set) Token: 0x0600020C RID: 524 RVA: 0x00005804 File Offset: 0x00003A04
			Public Property frmChat1 As frmChat1
				<DebuggerHidden()>
				Get
					Me.m_frmChat1 = MyProject.MyForms.Create__Instance__(Of frmChat1)(Me.m_frmChat1)
					Return Me.m_frmChat1
				End Get
				<DebuggerHidden()>
				Set(value As frmChat1)
					If value IsNot Me.m_frmChat1 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmChat1)(Me.m_frmChat1)
					End If
				End Set
			End Property

			' Token: 0x17000054 RID: 84
			' (get) Token: 0x06000083 RID: 131 RVA: 0x00002A84 File Offset: 0x00000C84
			' (set) Token: 0x0600020D RID: 525 RVA: 0x00005830 File Offset: 0x00003A30
			Public Property frmChat2 As frmChat2
				<DebuggerHidden()>
				Get
					Me.m_frmChat2 = MyProject.MyForms.Create__Instance__(Of frmChat2)(Me.m_frmChat2)
					Return Me.m_frmChat2
				End Get
				<DebuggerHidden()>
				Set(value As frmChat2)
					If value IsNot Me.m_frmChat2 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmChat2)(Me.m_frmChat2)
					End If
				End Set
			End Property

			' Token: 0x17000055 RID: 85
			' (get) Token: 0x06000084 RID: 132 RVA: 0x00002A9F File Offset: 0x00000C9F
			' (set) Token: 0x0600020E RID: 526 RVA: 0x0000585C File Offset: 0x00003A5C
			Public Property frmChat3 As frmChat3
				<DebuggerHidden()>
				Get
					Me.m_frmChat3 = MyProject.MyForms.Create__Instance__(Of frmChat3)(Me.m_frmChat3)
					Return Me.m_frmChat3
				End Get
				<DebuggerHidden()>
				Set(value As frmChat3)
					If value IsNot Me.m_frmChat3 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmChat3)(Me.m_frmChat3)
					End If
				End Set
			End Property

			' Token: 0x17000056 RID: 86
			' (get) Token: 0x06000085 RID: 133 RVA: 0x00002ABA File Offset: 0x00000CBA
			' (set) Token: 0x0600020F RID: 527 RVA: 0x00005888 File Offset: 0x00003A88
			Public Property frmChat4 As frmChat4
				<DebuggerHidden()>
				Get
					Me.m_frmChat4 = MyProject.MyForms.Create__Instance__(Of frmChat4)(Me.m_frmChat4)
					Return Me.m_frmChat4
				End Get
				<DebuggerHidden()>
				Set(value As frmChat4)
					If value IsNot Me.m_frmChat4 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmChat4)(Me.m_frmChat4)
					End If
				End Set
			End Property

			' Token: 0x17000057 RID: 87
			' (get) Token: 0x06000086 RID: 134 RVA: 0x00002AD5 File Offset: 0x00000CD5
			' (set) Token: 0x06000210 RID: 528 RVA: 0x000058B4 File Offset: 0x00003AB4
			Public Property frmCipherSetting As frmCipherSetting
				<DebuggerHidden()>
				Get
					Me.m_frmCipherSetting = MyProject.MyForms.Create__Instance__(Of frmCipherSetting)(Me.m_frmCipherSetting)
					Return Me.m_frmCipherSetting
				End Get
				<DebuggerHidden()>
				Set(value As frmCipherSetting)
					If value IsNot Me.m_frmCipherSetting Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCipherSetting)(Me.m_frmCipherSetting)
					End If
				End Set
			End Property

			' Token: 0x17000058 RID: 88
			' (get) Token: 0x06000087 RID: 135 RVA: 0x00002AF0 File Offset: 0x00000CF0
			' (set) Token: 0x06000211 RID: 529 RVA: 0x000058E0 File Offset: 0x00003AE0
			Public Property frmComboPack As frmComboPack
				<DebuggerHidden()>
				Get
					Me.m_frmComboPack = MyProject.MyForms.Create__Instance__(Of frmComboPack)(Me.m_frmComboPack)
					Return Me.m_frmComboPack
				End Get
				<DebuggerHidden()>
				Set(value As frmComboPack)
					If value IsNot Me.m_frmComboPack Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmComboPack)(Me.m_frmComboPack)
					End If
				End Set
			End Property

			' Token: 0x17000059 RID: 89
			' (get) Token: 0x06000088 RID: 136 RVA: 0x00002B0B File Offset: 0x00000D0B
			' (set) Token: 0x06000212 RID: 530 RVA: 0x0000590C File Offset: 0x00003B0C
			Public Property frmComboPackBarcode As frmComboPackBarcode
				<DebuggerHidden()>
				Get
					Me.m_frmComboPackBarcode = MyProject.MyForms.Create__Instance__(Of frmComboPackBarcode)(Me.m_frmComboPackBarcode)
					Return Me.m_frmComboPackBarcode
				End Get
				<DebuggerHidden()>
				Set(value As frmComboPackBarcode)
					If value IsNot Me.m_frmComboPackBarcode Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmComboPackBarcode)(Me.m_frmComboPackBarcode)
					End If
				End Set
			End Property

			' Token: 0x1700005A RID: 90
			' (get) Token: 0x06000089 RID: 137 RVA: 0x00002B26 File Offset: 0x00000D26
			' (set) Token: 0x06000213 RID: 531 RVA: 0x00005938 File Offset: 0x00003B38
			Public Property frmComboPackMaster As frmComboPackMaster
				<DebuggerHidden()>
				Get
					Me.m_frmComboPackMaster = MyProject.MyForms.Create__Instance__(Of frmComboPackMaster)(Me.m_frmComboPackMaster)
					Return Me.m_frmComboPackMaster
				End Get
				<DebuggerHidden()>
				Set(value As frmComboPackMaster)
					If value IsNot Me.m_frmComboPackMaster Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmComboPackMaster)(Me.m_frmComboPackMaster)
					End If
				End Set
			End Property

			' Token: 0x1700005B RID: 91
			' (get) Token: 0x0600008A RID: 138 RVA: 0x00002B41 File Offset: 0x00000D41
			' (set) Token: 0x06000214 RID: 532 RVA: 0x00005964 File Offset: 0x00003B64
			Public Property frmCompany As frmCompany
				<DebuggerHidden()>
				Get
					Me.m_frmCompany = MyProject.MyForms.Create__Instance__(Of frmCompany)(Me.m_frmCompany)
					Return Me.m_frmCompany
				End Get
				<DebuggerHidden()>
				Set(value As frmCompany)
					If value IsNot Me.m_frmCompany Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCompany)(Me.m_frmCompany)
					End If
				End Set
			End Property

			' Token: 0x1700005C RID: 92
			' (get) Token: 0x0600008B RID: 139 RVA: 0x00002B5C File Offset: 0x00000D5C
			' (set) Token: 0x06000215 RID: 533 RVA: 0x00005990 File Offset: 0x00003B90
			Public Property frmCompanyDelete As frmCompanyDelete
				<DebuggerHidden()>
				Get
					Me.m_frmCompanyDelete = MyProject.MyForms.Create__Instance__(Of frmCompanyDelete)(Me.m_frmCompanyDelete)
					Return Me.m_frmCompanyDelete
				End Get
				<DebuggerHidden()>
				Set(value As frmCompanyDelete)
					If value IsNot Me.m_frmCompanyDelete Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCompanyDelete)(Me.m_frmCompanyDelete)
					End If
				End Set
			End Property

			' Token: 0x1700005D RID: 93
			' (get) Token: 0x0600008C RID: 140 RVA: 0x00002B77 File Offset: 0x00000D77
			' (set) Token: 0x06000216 RID: 534 RVA: 0x000059BC File Offset: 0x00003BBC
			Public Property frmCompanyupdate As frmCompanyupdate
				<DebuggerHidden()>
				Get
					Me.m_frmCompanyupdate = MyProject.MyForms.Create__Instance__(Of frmCompanyupdate)(Me.m_frmCompanyupdate)
					Return Me.m_frmCompanyupdate
				End Get
				<DebuggerHidden()>
				Set(value As frmCompanyupdate)
					If value IsNot Me.m_frmCompanyupdate Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCompanyupdate)(Me.m_frmCompanyupdate)
					End If
				End Set
			End Property

			' Token: 0x1700005E RID: 94
			' (get) Token: 0x0600008D RID: 141 RVA: 0x00002B92 File Offset: 0x00000D92
			' (set) Token: 0x06000217 RID: 535 RVA: 0x000059E8 File Offset: 0x00003BE8
			Public Property frmContactPhoto As frmContactPhoto
				<DebuggerHidden()>
				Get
					Me.m_frmContactPhoto = MyProject.MyForms.Create__Instance__(Of frmContactPhoto)(Me.m_frmContactPhoto)
					Return Me.m_frmContactPhoto
				End Get
				<DebuggerHidden()>
				Set(value As frmContactPhoto)
					If value IsNot Me.m_frmContactPhoto Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmContactPhoto)(Me.m_frmContactPhoto)
					End If
				End Set
			End Property

			' Token: 0x1700005F RID: 95
			' (get) Token: 0x0600008E RID: 142 RVA: 0x00002BAD File Offset: 0x00000DAD
			' (set) Token: 0x06000218 RID: 536 RVA: 0x00005A14 File Offset: 0x00003C14
			Public Property frmContacts As frmContacts
				<DebuggerHidden()>
				Get
					Me.m_frmContacts = MyProject.MyForms.Create__Instance__(Of frmContacts)(Me.m_frmContacts)
					Return Me.m_frmContacts
				End Get
				<DebuggerHidden()>
				Set(value As frmContacts)
					If value IsNot Me.m_frmContacts Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmContacts)(Me.m_frmContacts)
					End If
				End Set
			End Property

			' Token: 0x17000060 RID: 96
			' (get) Token: 0x0600008F RID: 143 RVA: 0x00002BC8 File Offset: 0x00000DC8
			' (set) Token: 0x06000219 RID: 537 RVA: 0x00005A40 File Offset: 0x00003C40
			Public Property frmContra As frmContra
				<DebuggerHidden()>
				Get
					Me.m_frmContra = MyProject.MyForms.Create__Instance__(Of frmContra)(Me.m_frmContra)
					Return Me.m_frmContra
				End Get
				<DebuggerHidden()>
				Set(value As frmContra)
					If value IsNot Me.m_frmContra Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmContra)(Me.m_frmContra)
					End If
				End Set
			End Property

			' Token: 0x17000061 RID: 97
			' (get) Token: 0x06000090 RID: 144 RVA: 0x00002BE3 File Offset: 0x00000DE3
			' (set) Token: 0x0600021A RID: 538 RVA: 0x00005A6C File Offset: 0x00003C6C
			Public Property frmConvert_Language As frmConvert_Language
				<DebuggerHidden()>
				Get
					Me.m_frmConvert_Language = MyProject.MyForms.Create__Instance__(Of frmConvert_Language)(Me.m_frmConvert_Language)
					Return Me.m_frmConvert_Language
				End Get
				<DebuggerHidden()>
				Set(value As frmConvert_Language)
					If value IsNot Me.m_frmConvert_Language Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmConvert_Language)(Me.m_frmConvert_Language)
					End If
				End Set
			End Property

			' Token: 0x17000062 RID: 98
			' (get) Token: 0x06000091 RID: 145 RVA: 0x00002BFE File Offset: 0x00000DFE
			' (set) Token: 0x0600021B RID: 539 RVA: 0x00005A98 File Offset: 0x00003C98
			Public Property frmCouponApply As frmCouponApply
				<DebuggerHidden()>
				Get
					Me.m_frmCouponApply = MyProject.MyForms.Create__Instance__(Of frmCouponApply)(Me.m_frmCouponApply)
					Return Me.m_frmCouponApply
				End Get
				<DebuggerHidden()>
				Set(value As frmCouponApply)
					If value IsNot Me.m_frmCouponApply Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCouponApply)(Me.m_frmCouponApply)
					End If
				End Set
			End Property

			' Token: 0x17000063 RID: 99
			' (get) Token: 0x06000092 RID: 146 RVA: 0x00002C19 File Offset: 0x00000E19
			' (set) Token: 0x0600021C RID: 540 RVA: 0x00005AC4 File Offset: 0x00003CC4
			Public Property frmCouponGenerate As frmCouponGenerate
				<DebuggerHidden()>
				Get
					Me.m_frmCouponGenerate = MyProject.MyForms.Create__Instance__(Of frmCouponGenerate)(Me.m_frmCouponGenerate)
					Return Me.m_frmCouponGenerate
				End Get
				<DebuggerHidden()>
				Set(value As frmCouponGenerate)
					If value IsNot Me.m_frmCouponGenerate Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCouponGenerate)(Me.m_frmCouponGenerate)
					End If
				End Set
			End Property

			' Token: 0x17000064 RID: 100
			' (get) Token: 0x06000093 RID: 147 RVA: 0x00002C34 File Offset: 0x00000E34
			' (set) Token: 0x0600021D RID: 541 RVA: 0x00005AF0 File Offset: 0x00003CF0
			Public Property frmCreditCustomerReceipt As frmCreditCustomerReceipt
				<DebuggerHidden()>
				Get
					Me.m_frmCreditCustomerReceipt = MyProject.MyForms.Create__Instance__(Of frmCreditCustomerReceipt)(Me.m_frmCreditCustomerReceipt)
					Return Me.m_frmCreditCustomerReceipt
				End Get
				<DebuggerHidden()>
				Set(value As frmCreditCustomerReceipt)
					If value IsNot Me.m_frmCreditCustomerReceipt Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCreditCustomerReceipt)(Me.m_frmCreditCustomerReceipt)
					End If
				End Set
			End Property

			' Token: 0x17000065 RID: 101
			' (get) Token: 0x06000094 RID: 148 RVA: 0x00002C4F File Offset: 0x00000E4F
			' (set) Token: 0x0600021E RID: 542 RVA: 0x00005B1C File Offset: 0x00003D1C
			Public Property frmCreditCustomerReceiptRecord As frmCreditCustomerReceiptRecord
				<DebuggerHidden()>
				Get
					Me.m_frmCreditCustomerReceiptRecord = MyProject.MyForms.Create__Instance__(Of frmCreditCustomerReceiptRecord)(Me.m_frmCreditCustomerReceiptRecord)
					Return Me.m_frmCreditCustomerReceiptRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmCreditCustomerReceiptRecord)
					If value IsNot Me.m_frmCreditCustomerReceiptRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCreditCustomerReceiptRecord)(Me.m_frmCreditCustomerReceiptRecord)
					End If
				End Set
			End Property

			' Token: 0x17000066 RID: 102
			' (get) Token: 0x06000095 RID: 149 RVA: 0x00002C6A File Offset: 0x00000E6A
			' (set) Token: 0x0600021F RID: 543 RVA: 0x00005B48 File Offset: 0x00003D48
			Public Property frmCreditCustomerSMS As frmCreditCustomerSMS
				<DebuggerHidden()>
				Get
					Me.m_frmCreditCustomerSMS = MyProject.MyForms.Create__Instance__(Of frmCreditCustomerSMS)(Me.m_frmCreditCustomerSMS)
					Return Me.m_frmCreditCustomerSMS
				End Get
				<DebuggerHidden()>
				Set(value As frmCreditCustomerSMS)
					If value IsNot Me.m_frmCreditCustomerSMS Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCreditCustomerSMS)(Me.m_frmCreditCustomerSMS)
					End If
				End Set
			End Property

			' Token: 0x17000067 RID: 103
			' (get) Token: 0x06000096 RID: 150 RVA: 0x00002C85 File Offset: 0x00000E85
			' (set) Token: 0x06000220 RID: 544 RVA: 0x00005B74 File Offset: 0x00003D74
			Public Property frmCreditDebit As frmCreditDebit
				<DebuggerHidden()>
				Get
					Me.m_frmCreditDebit = MyProject.MyForms.Create__Instance__(Of frmCreditDebit)(Me.m_frmCreditDebit)
					Return Me.m_frmCreditDebit
				End Get
				<DebuggerHidden()>
				Set(value As frmCreditDebit)
					If value IsNot Me.m_frmCreditDebit Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCreditDebit)(Me.m_frmCreditDebit)
					End If
				End Set
			End Property

			' Token: 0x17000068 RID: 104
			' (get) Token: 0x06000097 RID: 151 RVA: 0x00002CA0 File Offset: 0x00000EA0
			' (set) Token: 0x06000221 RID: 545 RVA: 0x00005BA0 File Offset: 0x00003DA0
			Public Property frmCreditTermsStatements As frmCreditTermsStatements
				<DebuggerHidden()>
				Get
					Me.m_frmCreditTermsStatements = MyProject.MyForms.Create__Instance__(Of frmCreditTermsStatements)(Me.m_frmCreditTermsStatements)
					Return Me.m_frmCreditTermsStatements
				End Get
				<DebuggerHidden()>
				Set(value As frmCreditTermsStatements)
					If value IsNot Me.m_frmCreditTermsStatements Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCreditTermsStatements)(Me.m_frmCreditTermsStatements)
					End If
				End Set
			End Property

			' Token: 0x17000069 RID: 105
			' (get) Token: 0x06000098 RID: 152 RVA: 0x00002CBB File Offset: 0x00000EBB
			' (set) Token: 0x06000222 RID: 546 RVA: 0x00005BCC File Offset: 0x00003DCC
			Public Property frmCurrentStock As frmCurrentStock
				<DebuggerHidden()>
				Get
					Me.m_frmCurrentStock = MyProject.MyForms.Create__Instance__(Of frmCurrentStock)(Me.m_frmCurrentStock)
					Return Me.m_frmCurrentStock
				End Get
				<DebuggerHidden()>
				Set(value As frmCurrentStock)
					If value IsNot Me.m_frmCurrentStock Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCurrentStock)(Me.m_frmCurrentStock)
					End If
				End Set
			End Property

			' Token: 0x1700006A RID: 106
			' (get) Token: 0x06000099 RID: 153 RVA: 0x00002CD6 File Offset: 0x00000ED6
			' (set) Token: 0x06000223 RID: 547 RVA: 0x00005BF8 File Offset: 0x00003DF8
			Public Property frmCustBalanceLedger As frmCustBalanceLedger
				<DebuggerHidden()>
				Get
					Me.m_frmCustBalanceLedger = MyProject.MyForms.Create__Instance__(Of frmCustBalanceLedger)(Me.m_frmCustBalanceLedger)
					Return Me.m_frmCustBalanceLedger
				End Get
				<DebuggerHidden()>
				Set(value As frmCustBalanceLedger)
					If value IsNot Me.m_frmCustBalanceLedger Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustBalanceLedger)(Me.m_frmCustBalanceLedger)
					End If
				End Set
			End Property

			' Token: 0x1700006B RID: 107
			' (get) Token: 0x0600009A RID: 154 RVA: 0x00002CF1 File Offset: 0x00000EF1
			' (set) Token: 0x06000224 RID: 548 RVA: 0x00005C24 File Offset: 0x00003E24
			Public Property frmCustomDialog As frmCustomDialog
				<DebuggerHidden()>
				Get
					Me.m_frmCustomDialog = MyProject.MyForms.Create__Instance__(Of frmCustomDialog)(Me.m_frmCustomDialog)
					Return Me.m_frmCustomDialog
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomDialog)
					If value IsNot Me.m_frmCustomDialog Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomDialog)(Me.m_frmCustomDialog)
					End If
				End Set
			End Property

			' Token: 0x1700006C RID: 108
			' (get) Token: 0x0600009B RID: 155 RVA: 0x00002D0C File Offset: 0x00000F0C
			' (set) Token: 0x06000225 RID: 549 RVA: 0x00005C50 File Offset: 0x00003E50
			Public Property frmCustomDialog1 As frmCustomDialog1
				<DebuggerHidden()>
				Get
					Me.m_frmCustomDialog1 = MyProject.MyForms.Create__Instance__(Of frmCustomDialog1)(Me.m_frmCustomDialog1)
					Return Me.m_frmCustomDialog1
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomDialog1)
					If value IsNot Me.m_frmCustomDialog1 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomDialog1)(Me.m_frmCustomDialog1)
					End If
				End Set
			End Property

			' Token: 0x1700006D RID: 109
			' (get) Token: 0x0600009C RID: 156 RVA: 0x00002D27 File Offset: 0x00000F27
			' (set) Token: 0x06000226 RID: 550 RVA: 0x00005C7C File Offset: 0x00003E7C
			Public Property frmCustomDialog2 As frmCustomDialog2
				<DebuggerHidden()>
				Get
					Me.m_frmCustomDialog2 = MyProject.MyForms.Create__Instance__(Of frmCustomDialog2)(Me.m_frmCustomDialog2)
					Return Me.m_frmCustomDialog2
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomDialog2)
					If value IsNot Me.m_frmCustomDialog2 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomDialog2)(Me.m_frmCustomDialog2)
					End If
				End Set
			End Property

			' Token: 0x1700006E RID: 110
			' (get) Token: 0x0600009D RID: 157 RVA: 0x00002D42 File Offset: 0x00000F42
			' (set) Token: 0x06000227 RID: 551 RVA: 0x00005CA8 File Offset: 0x00003EA8
			Public Property frmCustomDialog3 As frmCustomDialog3
				<DebuggerHidden()>
				Get
					Me.m_frmCustomDialog3 = MyProject.MyForms.Create__Instance__(Of frmCustomDialog3)(Me.m_frmCustomDialog3)
					Return Me.m_frmCustomDialog3
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomDialog3)
					If value IsNot Me.m_frmCustomDialog3 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomDialog3)(Me.m_frmCustomDialog3)
					End If
				End Set
			End Property

			' Token: 0x1700006F RID: 111
			' (get) Token: 0x0600009E RID: 158 RVA: 0x00002D5D File Offset: 0x00000F5D
			' (set) Token: 0x06000228 RID: 552 RVA: 0x00005CD4 File Offset: 0x00003ED4
			Public Property frmCustomer As frmCustomer
				<DebuggerHidden()>
				Get
					Me.m_frmCustomer = MyProject.MyForms.Create__Instance__(Of frmCustomer)(Me.m_frmCustomer)
					Return Me.m_frmCustomer
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomer)
					If value IsNot Me.m_frmCustomer Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomer)(Me.m_frmCustomer)
					End If
				End Set
			End Property

			' Token: 0x17000070 RID: 112
			' (get) Token: 0x0600009F RID: 159 RVA: 0x00002D78 File Offset: 0x00000F78
			' (set) Token: 0x06000229 RID: 553 RVA: 0x00005D00 File Offset: 0x00003F00
			Public Property frmCustomerBulkUpdate As frmCustomerBulkUpdate
				<DebuggerHidden()>
				Get
					Me.m_frmCustomerBulkUpdate = MyProject.MyForms.Create__Instance__(Of frmCustomerBulkUpdate)(Me.m_frmCustomerBulkUpdate)
					Return Me.m_frmCustomerBulkUpdate
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomerBulkUpdate)
					If value IsNot Me.m_frmCustomerBulkUpdate Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomerBulkUpdate)(Me.m_frmCustomerBulkUpdate)
					End If
				End Set
			End Property

			' Token: 0x17000071 RID: 113
			' (get) Token: 0x060000A0 RID: 160 RVA: 0x00002D93 File Offset: 0x00000F93
			' (set) Token: 0x0600022A RID: 554 RVA: 0x00005D2C File Offset: 0x00003F2C
			Public Property frmCustomerContactList As frmCustomerContactList
				<DebuggerHidden()>
				Get
					Me.m_frmCustomerContactList = MyProject.MyForms.Create__Instance__(Of frmCustomerContactList)(Me.m_frmCustomerContactList)
					Return Me.m_frmCustomerContactList
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomerContactList)
					If value IsNot Me.m_frmCustomerContactList Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomerContactList)(Me.m_frmCustomerContactList)
					End If
				End Set
			End Property

			' Token: 0x17000072 RID: 114
			' (get) Token: 0x060000A1 RID: 161 RVA: 0x00002DAE File Offset: 0x00000FAE
			' (set) Token: 0x0600022B RID: 555 RVA: 0x00005D58 File Offset: 0x00003F58
			Public Property frmCustomerDiscRecord As frmCustomerDiscRecord
				<DebuggerHidden()>
				Get
					Me.m_frmCustomerDiscRecord = MyProject.MyForms.Create__Instance__(Of frmCustomerDiscRecord)(Me.m_frmCustomerDiscRecord)
					Return Me.m_frmCustomerDiscRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomerDiscRecord)
					If value IsNot Me.m_frmCustomerDiscRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomerDiscRecord)(Me.m_frmCustomerDiscRecord)
					End If
				End Set
			End Property

			' Token: 0x17000073 RID: 115
			' (get) Token: 0x060000A2 RID: 162 RVA: 0x00002DC9 File Offset: 0x00000FC9
			' (set) Token: 0x0600022C RID: 556 RVA: 0x00005D84 File Offset: 0x00003F84
			Public Property frmCustomerLedger As frmCustomerLedger
				<DebuggerHidden()>
				Get
					Me.m_frmCustomerLedger = MyProject.MyForms.Create__Instance__(Of frmCustomerLedger)(Me.m_frmCustomerLedger)
					Return Me.m_frmCustomerLedger
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomerLedger)
					If value IsNot Me.m_frmCustomerLedger Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomerLedger)(Me.m_frmCustomerLedger)
					End If
				End Set
			End Property

			' Token: 0x17000074 RID: 116
			' (get) Token: 0x060000A3 RID: 163 RVA: 0x00002DE4 File Offset: 0x00000FE4
			' (set) Token: 0x0600022D RID: 557 RVA: 0x00005DB0 File Offset: 0x00003FB0
			Public Property frmCustomerLedger_Loyalty As frmCustomerLedger_Loyalty
				<DebuggerHidden()>
				Get
					Me.m_frmCustomerLedger_Loyalty = MyProject.MyForms.Create__Instance__(Of frmCustomerLedger_Loyalty)(Me.m_frmCustomerLedger_Loyalty)
					Return Me.m_frmCustomerLedger_Loyalty
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomerLedger_Loyalty)
					If value IsNot Me.m_frmCustomerLedger_Loyalty Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomerLedger_Loyalty)(Me.m_frmCustomerLedger_Loyalty)
					End If
				End Set
			End Property

			' Token: 0x17000075 RID: 117
			' (get) Token: 0x060000A4 RID: 164 RVA: 0x00002DFF File Offset: 0x00000FFF
			' (set) Token: 0x0600022E RID: 558 RVA: 0x00005DDC File Offset: 0x00003FDC
			Public Property frmCustomerMobileAppSender As frmCustomerMobileAppSender
				<DebuggerHidden()>
				Get
					Me.m_frmCustomerMobileAppSender = MyProject.MyForms.Create__Instance__(Of frmCustomerMobileAppSender)(Me.m_frmCustomerMobileAppSender)
					Return Me.m_frmCustomerMobileAppSender
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomerMobileAppSender)
					If value IsNot Me.m_frmCustomerMobileAppSender Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomerMobileAppSender)(Me.m_frmCustomerMobileAppSender)
					End If
				End Set
			End Property

			' Token: 0x17000076 RID: 118
			' (get) Token: 0x060000A5 RID: 165 RVA: 0x00002E1A File Offset: 0x0000101A
			' (set) Token: 0x0600022F RID: 559 RVA: 0x00005E08 File Offset: 0x00004008
			Public Property frmCustomerMobileRpt As frmCustomerMobileRpt
				<DebuggerHidden()>
				Get
					Me.m_frmCustomerMobileRpt = MyProject.MyForms.Create__Instance__(Of frmCustomerMobileRpt)(Me.m_frmCustomerMobileRpt)
					Return Me.m_frmCustomerMobileRpt
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomerMobileRpt)
					If value IsNot Me.m_frmCustomerMobileRpt Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomerMobileRpt)(Me.m_frmCustomerMobileRpt)
					End If
				End Set
			End Property

			' Token: 0x17000077 RID: 119
			' (get) Token: 0x060000A6 RID: 166 RVA: 0x00002E35 File Offset: 0x00001035
			' (set) Token: 0x06000230 RID: 560 RVA: 0x00005E34 File Offset: 0x00004034
			Public Property frmCustomerOffer As frmCustomerOffer
				<DebuggerHidden()>
				Get
					Me.m_frmCustomerOffer = MyProject.MyForms.Create__Instance__(Of frmCustomerOffer)(Me.m_frmCustomerOffer)
					Return Me.m_frmCustomerOffer
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomerOffer)
					If value IsNot Me.m_frmCustomerOffer Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomerOffer)(Me.m_frmCustomerOffer)
					End If
				End Set
			End Property

			' Token: 0x17000078 RID: 120
			' (get) Token: 0x060000A7 RID: 167 RVA: 0x00002E50 File Offset: 0x00001050
			' (set) Token: 0x06000231 RID: 561 RVA: 0x00005E60 File Offset: 0x00004060
			Public Property frmCustomerOutstanding As frmCustomerOutstanding
				<DebuggerHidden()>
				Get
					Me.m_frmCustomerOutstanding = MyProject.MyForms.Create__Instance__(Of frmCustomerOutstanding)(Me.m_frmCustomerOutstanding)
					Return Me.m_frmCustomerOutstanding
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomerOutstanding)
					If value IsNot Me.m_frmCustomerOutstanding Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomerOutstanding)(Me.m_frmCustomerOutstanding)
					End If
				End Set
			End Property

			' Token: 0x17000079 RID: 121
			' (get) Token: 0x060000A8 RID: 168 RVA: 0x00002E6B File Offset: 0x0000106B
			' (set) Token: 0x06000232 RID: 562 RVA: 0x00005E8C File Offset: 0x0000408C
			Public Property frmCustomerRecord As frmCustomerRecord
				<DebuggerHidden()>
				Get
					Me.m_frmCustomerRecord = MyProject.MyForms.Create__Instance__(Of frmCustomerRecord)(Me.m_frmCustomerRecord)
					Return Me.m_frmCustomerRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomerRecord)
					If value IsNot Me.m_frmCustomerRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomerRecord)(Me.m_frmCustomerRecord)
					End If
				End Set
			End Property

			' Token: 0x1700007A RID: 122
			' (get) Token: 0x060000A9 RID: 169 RVA: 0x00002E86 File Offset: 0x00001086
			' (set) Token: 0x06000233 RID: 563 RVA: 0x00005EB8 File Offset: 0x000040B8
			Public Property frmCustomerRoundover As frmCustomerRoundover
				<DebuggerHidden()>
				Get
					Me.m_frmCustomerRoundover = MyProject.MyForms.Create__Instance__(Of frmCustomerRoundover)(Me.m_frmCustomerRoundover)
					Return Me.m_frmCustomerRoundover
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomerRoundover)
					If value IsNot Me.m_frmCustomerRoundover Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomerRoundover)(Me.m_frmCustomerRoundover)
					End If
				End Set
			End Property

			' Token: 0x1700007B RID: 123
			' (get) Token: 0x060000AA RID: 170 RVA: 0x00002EA1 File Offset: 0x000010A1
			' (set) Token: 0x06000234 RID: 564 RVA: 0x00005EE4 File Offset: 0x000040E4
			Public Property frmCustomersNew As frmCustomersNew
				<DebuggerHidden()>
				Get
					Me.m_frmCustomersNew = MyProject.MyForms.Create__Instance__(Of frmCustomersNew)(Me.m_frmCustomersNew)
					Return Me.m_frmCustomersNew
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomersNew)
					If value IsNot Me.m_frmCustomersNew Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomersNew)(Me.m_frmCustomersNew)
					End If
				End Set
			End Property

			' Token: 0x1700007C RID: 124
			' (get) Token: 0x060000AB RID: 171 RVA: 0x00002EBC File Offset: 0x000010BC
			' (set) Token: 0x06000235 RID: 565 RVA: 0x00005F10 File Offset: 0x00004110
			Public Property frmCustomerSupport As frmCustomerSupport
				<DebuggerHidden()>
				Get
					Me.m_frmCustomerSupport = MyProject.MyForms.Create__Instance__(Of frmCustomerSupport)(Me.m_frmCustomerSupport)
					Return Me.m_frmCustomerSupport
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomerSupport)
					If value IsNot Me.m_frmCustomerSupport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomerSupport)(Me.m_frmCustomerSupport)
					End If
				End Set
			End Property

			' Token: 0x1700007D RID: 125
			' (get) Token: 0x060000AC RID: 172 RVA: 0x00002ED7 File Offset: 0x000010D7
			' (set) Token: 0x06000236 RID: 566 RVA: 0x00005F3C File Offset: 0x0000413C
			Public Property frmCustomerSupport1 As frmCustomerSupport1
				<DebuggerHidden()>
				Get
					Me.m_frmCustomerSupport1 = MyProject.MyForms.Create__Instance__(Of frmCustomerSupport1)(Me.m_frmCustomerSupport1)
					Return Me.m_frmCustomerSupport1
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomerSupport1)
					If value IsNot Me.m_frmCustomerSupport1 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomerSupport1)(Me.m_frmCustomerSupport1)
					End If
				End Set
			End Property

			' Token: 0x1700007E RID: 126
			' (get) Token: 0x060000AD RID: 173 RVA: 0x00002EF2 File Offset: 0x000010F2
			' (set) Token: 0x06000237 RID: 567 RVA: 0x00005F68 File Offset: 0x00004168
			Public Property frmCustomerSupportForm_Dashboard As frmCustomerSupportForm_Dashboard
				<DebuggerHidden()>
				Get
					Me.m_frmCustomerSupportForm_Dashboard = MyProject.MyForms.Create__Instance__(Of frmCustomerSupportForm_Dashboard)(Me.m_frmCustomerSupportForm_Dashboard)
					Return Me.m_frmCustomerSupportForm_Dashboard
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomerSupportForm_Dashboard)
					If value IsNot Me.m_frmCustomerSupportForm_Dashboard Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomerSupportForm_Dashboard)(Me.m_frmCustomerSupportForm_Dashboard)
					End If
				End Set
			End Property

			' Token: 0x1700007F RID: 127
			' (get) Token: 0x060000AE RID: 174 RVA: 0x00002F0D File Offset: 0x0000110D
			' (set) Token: 0x06000238 RID: 568 RVA: 0x00005F94 File Offset: 0x00004194
			Public Property frmCustomerSupportLog As frmCustomerSupportLog
				<DebuggerHidden()>
				Get
					Me.m_frmCustomerSupportLog = MyProject.MyForms.Create__Instance__(Of frmCustomerSupportLog)(Me.m_frmCustomerSupportLog)
					Return Me.m_frmCustomerSupportLog
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomerSupportLog)
					If value IsNot Me.m_frmCustomerSupportLog Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomerSupportLog)(Me.m_frmCustomerSupportLog)
					End If
				End Set
			End Property

			' Token: 0x17000080 RID: 128
			' (get) Token: 0x060000AF RID: 175 RVA: 0x00002F28 File Offset: 0x00001128
			' (set) Token: 0x06000239 RID: 569 RVA: 0x00005FC0 File Offset: 0x000041C0
			Public Property frmCustomerSupportLog_Dashboard As frmCustomerSupportLog_Dashboard
				<DebuggerHidden()>
				Get
					Me.m_frmCustomerSupportLog_Dashboard = MyProject.MyForms.Create__Instance__(Of frmCustomerSupportLog_Dashboard)(Me.m_frmCustomerSupportLog_Dashboard)
					Return Me.m_frmCustomerSupportLog_Dashboard
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomerSupportLog_Dashboard)
					If value IsNot Me.m_frmCustomerSupportLog_Dashboard Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomerSupportLog_Dashboard)(Me.m_frmCustomerSupportLog_Dashboard)
					End If
				End Set
			End Property

			' Token: 0x17000081 RID: 129
			' (get) Token: 0x060000B0 RID: 176 RVA: 0x00002F43 File Offset: 0x00001143
			' (set) Token: 0x0600023A RID: 570 RVA: 0x00005FEC File Offset: 0x000041EC
			Public Property frmCustomerSupportLog_Report As frmCustomerSupportLog_Report
				<DebuggerHidden()>
				Get
					Me.m_frmCustomerSupportLog_Report = MyProject.MyForms.Create__Instance__(Of frmCustomerSupportLog_Report)(Me.m_frmCustomerSupportLog_Report)
					Return Me.m_frmCustomerSupportLog_Report
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomerSupportLog_Report)
					If value IsNot Me.m_frmCustomerSupportLog_Report Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomerSupportLog_Report)(Me.m_frmCustomerSupportLog_Report)
					End If
				End Set
			End Property

			' Token: 0x17000082 RID: 130
			' (get) Token: 0x060000B1 RID: 177 RVA: 0x00002F5E File Offset: 0x0000115E
			' (set) Token: 0x0600023B RID: 571 RVA: 0x00006018 File Offset: 0x00004218
			Public Property frmCustomerValid As frmCustomerValid
				<DebuggerHidden()>
				Get
					Me.m_frmCustomerValid = MyProject.MyForms.Create__Instance__(Of frmCustomerValid)(Me.m_frmCustomerValid)
					Return Me.m_frmCustomerValid
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomerValid)
					If value IsNot Me.m_frmCustomerValid Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomerValid)(Me.m_frmCustomerValid)
					End If
				End Set
			End Property

			' Token: 0x17000083 RID: 131
			' (get) Token: 0x060000B2 RID: 178 RVA: 0x00002F79 File Offset: 0x00001179
			' (set) Token: 0x0600023C RID: 572 RVA: 0x00006044 File Offset: 0x00004244
			Public Property frmCustomiseBarcode As frmCustomiseBarcode
				<DebuggerHidden()>
				Get
					Me.m_frmCustomiseBarcode = MyProject.MyForms.Create__Instance__(Of frmCustomiseBarcode)(Me.m_frmCustomiseBarcode)
					Return Me.m_frmCustomiseBarcode
				End Get
				<DebuggerHidden()>
				Set(value As frmCustomiseBarcode)
					If value IsNot Me.m_frmCustomiseBarcode Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCustomiseBarcode)(Me.m_frmCustomiseBarcode)
					End If
				End Set
			End Property

			' Token: 0x17000084 RID: 132
			' (get) Token: 0x060000B3 RID: 179 RVA: 0x00002F94 File Offset: 0x00001194
			' (set) Token: 0x0600023D RID: 573 RVA: 0x00006070 File Offset: 0x00004270
			Public Property frmDamageProduct As frmDamageProduct
				<DebuggerHidden()>
				Get
					Me.m_frmDamageProduct = MyProject.MyForms.Create__Instance__(Of frmDamageProduct)(Me.m_frmDamageProduct)
					Return Me.m_frmDamageProduct
				End Get
				<DebuggerHidden()>
				Set(value As frmDamageProduct)
					If value IsNot Me.m_frmDamageProduct Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmDamageProduct)(Me.m_frmDamageProduct)
					End If
				End Set
			End Property

			' Token: 0x17000085 RID: 133
			' (get) Token: 0x060000B4 RID: 180 RVA: 0x00002FAF File Offset: 0x000011AF
			' (set) Token: 0x0600023E RID: 574 RVA: 0x0000609C File Offset: 0x0000429C
			Public Property frmDebtorsReport As frmDebtorsReport
				<DebuggerHidden()>
				Get
					Me.m_frmDebtorsReport = MyProject.MyForms.Create__Instance__(Of frmDebtorsReport)(Me.m_frmDebtorsReport)
					Return Me.m_frmDebtorsReport
				End Get
				<DebuggerHidden()>
				Set(value As frmDebtorsReport)
					If value IsNot Me.m_frmDebtorsReport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmDebtorsReport)(Me.m_frmDebtorsReport)
					End If
				End Set
			End Property

			' Token: 0x17000086 RID: 134
			' (get) Token: 0x060000B5 RID: 181 RVA: 0x00002FCA File Offset: 0x000011CA
			' (set) Token: 0x0600023F RID: 575 RVA: 0x000060C8 File Offset: 0x000042C8
			Public Property frmDeductionReport As frmDeductionReport
				<DebuggerHidden()>
				Get
					Me.m_frmDeductionReport = MyProject.MyForms.Create__Instance__(Of frmDeductionReport)(Me.m_frmDeductionReport)
					Return Me.m_frmDeductionReport
				End Get
				<DebuggerHidden()>
				Set(value As frmDeductionReport)
					If value IsNot Me.m_frmDeductionReport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmDeductionReport)(Me.m_frmDeductionReport)
					End If
				End Set
			End Property

			' Token: 0x17000087 RID: 135
			' (get) Token: 0x060000B6 RID: 182 RVA: 0x00002FE5 File Offset: 0x000011E5
			' (set) Token: 0x06000240 RID: 576 RVA: 0x000060F4 File Offset: 0x000042F4
			Public Property frmECategory As frmECategory
				<DebuggerHidden()>
				Get
					Me.m_frmECategory = MyProject.MyForms.Create__Instance__(Of frmECategory)(Me.m_frmECategory)
					Return Me.m_frmECategory
				End Get
				<DebuggerHidden()>
				Set(value As frmECategory)
					If value IsNot Me.m_frmECategory Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmECategory)(Me.m_frmECategory)
					End If
				End Set
			End Property

			' Token: 0x17000088 RID: 136
			' (get) Token: 0x060000B7 RID: 183 RVA: 0x00003000 File Offset: 0x00001200
			' (set) Token: 0x06000241 RID: 577 RVA: 0x00006120 File Offset: 0x00004320
			Public Property frmEComSeting As frmEComSeting
				<DebuggerHidden()>
				Get
					Me.m_frmEComSeting = MyProject.MyForms.Create__Instance__(Of frmEComSeting)(Me.m_frmEComSeting)
					Return Me.m_frmEComSeting
				End Get
				<DebuggerHidden()>
				Set(value As frmEComSeting)
					If value IsNot Me.m_frmEComSeting Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEComSeting)(Me.m_frmEComSeting)
					End If
				End Set
			End Property

			' Token: 0x17000089 RID: 137
			' (get) Token: 0x060000B8 RID: 184 RVA: 0x0000301B File Offset: 0x0000121B
			' (set) Token: 0x06000242 RID: 578 RVA: 0x0000614C File Offset: 0x0000434C
			Public Property frmEmailDashboard As frmEmailDashboard
				<DebuggerHidden()>
				Get
					Me.m_frmEmailDashboard = MyProject.MyForms.Create__Instance__(Of frmEmailDashboard)(Me.m_frmEmailDashboard)
					Return Me.m_frmEmailDashboard
				End Get
				<DebuggerHidden()>
				Set(value As frmEmailDashboard)
					If value IsNot Me.m_frmEmailDashboard Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEmailDashboard)(Me.m_frmEmailDashboard)
					End If
				End Set
			End Property

			' Token: 0x1700008A RID: 138
			' (get) Token: 0x060000B9 RID: 185 RVA: 0x00003036 File Offset: 0x00001236
			' (set) Token: 0x06000243 RID: 579 RVA: 0x00006178 File Offset: 0x00004378
			Public Property frmEmailDashboard2 As frmEmailDashboard2
				<DebuggerHidden()>
				Get
					Me.m_frmEmailDashboard2 = MyProject.MyForms.Create__Instance__(Of frmEmailDashboard2)(Me.m_frmEmailDashboard2)
					Return Me.m_frmEmailDashboard2
				End Get
				<DebuggerHidden()>
				Set(value As frmEmailDashboard2)
					If value IsNot Me.m_frmEmailDashboard2 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEmailDashboard2)(Me.m_frmEmailDashboard2)
					End If
				End Set
			End Property

			' Token: 0x1700008B RID: 139
			' (get) Token: 0x060000BA RID: 186 RVA: 0x00003051 File Offset: 0x00001251
			' (set) Token: 0x06000244 RID: 580 RVA: 0x000061A4 File Offset: 0x000043A4
			Public Property frmEmailDashboard3 As frmEmailDashboard3
				<DebuggerHidden()>
				Get
					Me.m_frmEmailDashboard3 = MyProject.MyForms.Create__Instance__(Of frmEmailDashboard3)(Me.m_frmEmailDashboard3)
					Return Me.m_frmEmailDashboard3
				End Get
				<DebuggerHidden()>
				Set(value As frmEmailDashboard3)
					If value IsNot Me.m_frmEmailDashboard3 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEmailDashboard3)(Me.m_frmEmailDashboard3)
					End If
				End Set
			End Property

			' Token: 0x1700008C RID: 140
			' (get) Token: 0x060000BB RID: 187 RVA: 0x0000306C File Offset: 0x0000126C
			' (set) Token: 0x06000245 RID: 581 RVA: 0x000061D0 File Offset: 0x000043D0
			Public Property frmEmailsender As frmEmailsender
				<DebuggerHidden()>
				Get
					Me.m_frmEmailsender = MyProject.MyForms.Create__Instance__(Of frmEmailsender)(Me.m_frmEmailsender)
					Return Me.m_frmEmailsender
				End Get
				<DebuggerHidden()>
				Set(value As frmEmailsender)
					If value IsNot Me.m_frmEmailsender Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEmailsender)(Me.m_frmEmailsender)
					End If
				End Set
			End Property

			' Token: 0x1700008D RID: 141
			' (get) Token: 0x060000BC RID: 188 RVA: 0x00003087 File Offset: 0x00001287
			' (set) Token: 0x06000246 RID: 582 RVA: 0x000061FC File Offset: 0x000043FC
			Public Property frmEmailSetting As frmEmailSetting
				<DebuggerHidden()>
				Get
					Me.m_frmEmailSetting = MyProject.MyForms.Create__Instance__(Of frmEmailSetting)(Me.m_frmEmailSetting)
					Return Me.m_frmEmailSetting
				End Get
				<DebuggerHidden()>
				Set(value As frmEmailSetting)
					If value IsNot Me.m_frmEmailSetting Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEmailSetting)(Me.m_frmEmailSetting)
					End If
				End Set
			End Property

			' Token: 0x1700008E RID: 142
			' (get) Token: 0x060000BD RID: 189 RVA: 0x000030A2 File Offset: 0x000012A2
			' (set) Token: 0x06000247 RID: 583 RVA: 0x00006228 File Offset: 0x00004428
			Public Property frmEmailSetting_login As frmEmailSetting_login
				<DebuggerHidden()>
				Get
					Me.m_frmEmailSetting_login = MyProject.MyForms.Create__Instance__(Of frmEmailSetting_login)(Me.m_frmEmailSetting_login)
					Return Me.m_frmEmailSetting_login
				End Get
				<DebuggerHidden()>
				Set(value As frmEmailSetting_login)
					If value IsNot Me.m_frmEmailSetting_login Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEmailSetting_login)(Me.m_frmEmailSetting_login)
					End If
				End Set
			End Property

			' Token: 0x1700008F RID: 143
			' (get) Token: 0x060000BE RID: 190 RVA: 0x000030BD File Offset: 0x000012BD
			' (set) Token: 0x06000248 RID: 584 RVA: 0x00006254 File Offset: 0x00004454
			Public Property frmEMain As frmEMain
				<DebuggerHidden()>
				Get
					Me.m_frmEMain = MyProject.MyForms.Create__Instance__(Of frmEMain)(Me.m_frmEMain)
					Return Me.m_frmEMain
				End Get
				<DebuggerHidden()>
				Set(value As frmEMain)
					If value IsNot Me.m_frmEMain Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEMain)(Me.m_frmEMain)
					End If
				End Set
			End Property

			' Token: 0x17000090 RID: 144
			' (get) Token: 0x060000BF RID: 191 RVA: 0x000030D8 File Offset: 0x000012D8
			' (set) Token: 0x06000249 RID: 585 RVA: 0x00006280 File Offset: 0x00004480
			Public Property frmEmployeePayment As frmEmployeePayment
				<DebuggerHidden()>
				Get
					Me.m_frmEmployeePayment = MyProject.MyForms.Create__Instance__(Of frmEmployeePayment)(Me.m_frmEmployeePayment)
					Return Me.m_frmEmployeePayment
				End Get
				<DebuggerHidden()>
				Set(value As frmEmployeePayment)
					If value IsNot Me.m_frmEmployeePayment Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEmployeePayment)(Me.m_frmEmployeePayment)
					End If
				End Set
			End Property

			' Token: 0x17000091 RID: 145
			' (get) Token: 0x060000C0 RID: 192 RVA: 0x000030F3 File Offset: 0x000012F3
			' (set) Token: 0x0600024A RID: 586 RVA: 0x000062AC File Offset: 0x000044AC
			Public Property frmEmployeePaymentRecord As frmEmployeePaymentRecord
				<DebuggerHidden()>
				Get
					Me.m_frmEmployeePaymentRecord = MyProject.MyForms.Create__Instance__(Of frmEmployeePaymentRecord)(Me.m_frmEmployeePaymentRecord)
					Return Me.m_frmEmployeePaymentRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmEmployeePaymentRecord)
					If value IsNot Me.m_frmEmployeePaymentRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEmployeePaymentRecord)(Me.m_frmEmployeePaymentRecord)
					End If
				End Set
			End Property

			' Token: 0x17000092 RID: 146
			' (get) Token: 0x060000C1 RID: 193 RVA: 0x0000310E File Offset: 0x0000130E
			' (set) Token: 0x0600024B RID: 587 RVA: 0x000062D8 File Offset: 0x000044D8
			Public Property frmEmployeePaymentReport As frmEmployeePaymentReport
				<DebuggerHidden()>
				Get
					Me.m_frmEmployeePaymentReport = MyProject.MyForms.Create__Instance__(Of frmEmployeePaymentReport)(Me.m_frmEmployeePaymentReport)
					Return Me.m_frmEmployeePaymentReport
				End Get
				<DebuggerHidden()>
				Set(value As frmEmployeePaymentReport)
					If value IsNot Me.m_frmEmployeePaymentReport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEmployeePaymentReport)(Me.m_frmEmployeePaymentReport)
					End If
				End Set
			End Property

			' Token: 0x17000093 RID: 147
			' (get) Token: 0x060000C2 RID: 194 RVA: 0x00003129 File Offset: 0x00001329
			' (set) Token: 0x0600024C RID: 588 RVA: 0x00006304 File Offset: 0x00004504
			Public Property frmEmployeeRegistration As frmEmployeeRegistration
				<DebuggerHidden()>
				Get
					Me.m_frmEmployeeRegistration = MyProject.MyForms.Create__Instance__(Of frmEmployeeRegistration)(Me.m_frmEmployeeRegistration)
					Return Me.m_frmEmployeeRegistration
				End Get
				<DebuggerHidden()>
				Set(value As frmEmployeeRegistration)
					If value IsNot Me.m_frmEmployeeRegistration Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEmployeeRegistration)(Me.m_frmEmployeeRegistration)
					End If
				End Set
			End Property

			' Token: 0x17000094 RID: 148
			' (get) Token: 0x060000C3 RID: 195 RVA: 0x00003144 File Offset: 0x00001344
			' (set) Token: 0x0600024D RID: 589 RVA: 0x00006330 File Offset: 0x00004530
			Public Property frmEmployeesRecord As frmEmployeesRecord
				<DebuggerHidden()>
				Get
					Me.m_frmEmployeesRecord = MyProject.MyForms.Create__Instance__(Of frmEmployeesRecord)(Me.m_frmEmployeesRecord)
					Return Me.m_frmEmployeesRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmEmployeesRecord)
					If value IsNot Me.m_frmEmployeesRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEmployeesRecord)(Me.m_frmEmployeesRecord)
					End If
				End Set
			End Property

			' Token: 0x17000095 RID: 149
			' (get) Token: 0x060000C4 RID: 196 RVA: 0x0000315F File Offset: 0x0000135F
			' (set) Token: 0x0600024E RID: 590 RVA: 0x0000635C File Offset: 0x0000455C
			Public Property frmEProduct As frmEProduct
				<DebuggerHidden()>
				Get
					Me.m_frmEProduct = MyProject.MyForms.Create__Instance__(Of frmEProduct)(Me.m_frmEProduct)
					Return Me.m_frmEProduct
				End Get
				<DebuggerHidden()>
				Set(value As frmEProduct)
					If value IsNot Me.m_frmEProduct Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEProduct)(Me.m_frmEProduct)
					End If
				End Set
			End Property

			' Token: 0x17000096 RID: 150
			' (get) Token: 0x060000C5 RID: 197 RVA: 0x0000317A File Offset: 0x0000137A
			' (set) Token: 0x0600024F RID: 591 RVA: 0x00006388 File Offset: 0x00004588
			Public Property frmEstimate As frmEstimate
				<DebuggerHidden()>
				Get
					Me.m_frmEstimate = MyProject.MyForms.Create__Instance__(Of frmEstimate)(Me.m_frmEstimate)
					Return Me.m_frmEstimate
				End Get
				<DebuggerHidden()>
				Set(value As frmEstimate)
					If value IsNot Me.m_frmEstimate Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEstimate)(Me.m_frmEstimate)
					End If
				End Set
			End Property

			' Token: 0x17000097 RID: 151
			' (get) Token: 0x060000C6 RID: 198 RVA: 0x00003195 File Offset: 0x00001395
			' (set) Token: 0x06000250 RID: 592 RVA: 0x000063B4 File Offset: 0x000045B4
			Public Property frmEstimateRecord As frmEstimateRecord
				<DebuggerHidden()>
				Get
					Me.m_frmEstimateRecord = MyProject.MyForms.Create__Instance__(Of frmEstimateRecord)(Me.m_frmEstimateRecord)
					Return Me.m_frmEstimateRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmEstimateRecord)
					If value IsNot Me.m_frmEstimateRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEstimateRecord)(Me.m_frmEstimateRecord)
					End If
				End Set
			End Property

			' Token: 0x17000098 RID: 152
			' (get) Token: 0x060000C7 RID: 199 RVA: 0x000031B0 File Offset: 0x000013B0
			' (set) Token: 0x06000251 RID: 593 RVA: 0x000063E0 File Offset: 0x000045E0
			Public Property frmEstimateRetrieve As frmEstimateRetrieve
				<DebuggerHidden()>
				Get
					Me.m_frmEstimateRetrieve = MyProject.MyForms.Create__Instance__(Of frmEstimateRetrieve)(Me.m_frmEstimateRetrieve)
					Return Me.m_frmEstimateRetrieve
				End Get
				<DebuggerHidden()>
				Set(value As frmEstimateRetrieve)
					If value IsNot Me.m_frmEstimateRetrieve Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEstimateRetrieve)(Me.m_frmEstimateRetrieve)
					End If
				End Set
			End Property

			' Token: 0x17000099 RID: 153
			' (get) Token: 0x060000C8 RID: 200 RVA: 0x000031CB File Offset: 0x000013CB
			' (set) Token: 0x06000252 RID: 594 RVA: 0x0000640C File Offset: 0x0000460C
			Public Property frmESubCategory As frmESubCategory
				<DebuggerHidden()>
				Get
					Me.m_frmESubCategory = MyProject.MyForms.Create__Instance__(Of frmESubCategory)(Me.m_frmESubCategory)
					Return Me.m_frmESubCategory
				End Get
				<DebuggerHidden()>
				Set(value As frmESubCategory)
					If value IsNot Me.m_frmESubCategory Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmESubCategory)(Me.m_frmESubCategory)
					End If
				End Set
			End Property

			' Token: 0x1700009A RID: 154
			' (get) Token: 0x060000C9 RID: 201 RVA: 0x000031E6 File Offset: 0x000013E6
			' (set) Token: 0x06000253 RID: 595 RVA: 0x00006438 File Offset: 0x00004638
			Public Property frmEWayBill As frmEWayBill
				<DebuggerHidden()>
				Get
					Me.m_frmEWayBill = MyProject.MyForms.Create__Instance__(Of frmEWayBill)(Me.m_frmEWayBill)
					Return Me.m_frmEWayBill
				End Get
				<DebuggerHidden()>
				Set(value As frmEWayBill)
					If value IsNot Me.m_frmEWayBill Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEWayBill)(Me.m_frmEWayBill)
					End If
				End Set
			End Property

			' Token: 0x1700009B RID: 155
			' (get) Token: 0x060000CA RID: 202 RVA: 0x00003201 File Offset: 0x00001401
			' (set) Token: 0x06000254 RID: 596 RVA: 0x00006464 File Offset: 0x00004664
			Public Property frmEwayBillSetting As frmEwayBillSetting
				<DebuggerHidden()>
				Get
					Me.m_frmEwayBillSetting = MyProject.MyForms.Create__Instance__(Of frmEwayBillSetting)(Me.m_frmEwayBillSetting)
					Return Me.m_frmEwayBillSetting
				End Get
				<DebuggerHidden()>
				Set(value As frmEwayBillSetting)
					If value IsNot Me.m_frmEwayBillSetting Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEwayBillSetting)(Me.m_frmEwayBillSetting)
					End If
				End Set
			End Property

			' Token: 0x1700009C RID: 156
			' (get) Token: 0x060000CB RID: 203 RVA: 0x0000321C File Offset: 0x0000141C
			' (set) Token: 0x06000255 RID: 597 RVA: 0x00006490 File Offset: 0x00004690
			Public Property frmEwaysetting As frmEwaysetting
				<DebuggerHidden()>
				Get
					Me.m_frmEwaysetting = MyProject.MyForms.Create__Instance__(Of frmEwaysetting)(Me.m_frmEwaysetting)
					Return Me.m_frmEwaysetting
				End Get
				<DebuggerHidden()>
				Set(value As frmEwaysetting)
					If value IsNot Me.m_frmEwaysetting Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEwaysetting)(Me.m_frmEwaysetting)
					End If
				End Set
			End Property

			' Token: 0x1700009D RID: 157
			' (get) Token: 0x060000CC RID: 204 RVA: 0x00003237 File Offset: 0x00001437
			' (set) Token: 0x06000256 RID: 598 RVA: 0x000064BC File Offset: 0x000046BC
			Public Property frmExpDashboard As frmExpDashboard
				<DebuggerHidden()>
				Get
					Me.m_frmExpDashboard = MyProject.MyForms.Create__Instance__(Of frmExpDashboard)(Me.m_frmExpDashboard)
					Return Me.m_frmExpDashboard
				End Get
				<DebuggerHidden()>
				Set(value As frmExpDashboard)
					If value IsNot Me.m_frmExpDashboard Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmExpDashboard)(Me.m_frmExpDashboard)
					End If
				End Set
			End Property

			' Token: 0x1700009E RID: 158
			' (get) Token: 0x060000CD RID: 205 RVA: 0x00003252 File Offset: 0x00001452
			' (set) Token: 0x06000257 RID: 599 RVA: 0x000064E8 File Offset: 0x000046E8
			Public Property frmExportImportExcel_Customers As frmExportImportExcel_Customers
				<DebuggerHidden()>
				Get
					Me.m_frmExportImportExcel_Customers = MyProject.MyForms.Create__Instance__(Of frmExportImportExcel_Customers)(Me.m_frmExportImportExcel_Customers)
					Return Me.m_frmExportImportExcel_Customers
				End Get
				<DebuggerHidden()>
				Set(value As frmExportImportExcel_Customers)
					If value IsNot Me.m_frmExportImportExcel_Customers Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmExportImportExcel_Customers)(Me.m_frmExportImportExcel_Customers)
					End If
				End Set
			End Property

			' Token: 0x1700009F RID: 159
			' (get) Token: 0x060000CE RID: 206 RVA: 0x0000326D File Offset: 0x0000146D
			' (set) Token: 0x06000258 RID: 600 RVA: 0x00006514 File Offset: 0x00004714
			Public Property frmExportImportExcel_OpeningStock As frmExportImportExcel_OpeningStock
				<DebuggerHidden()>
				Get
					Me.m_frmExportImportExcel_OpeningStock = MyProject.MyForms.Create__Instance__(Of frmExportImportExcel_OpeningStock)(Me.m_frmExportImportExcel_OpeningStock)
					Return Me.m_frmExportImportExcel_OpeningStock
				End Get
				<DebuggerHidden()>
				Set(value As frmExportImportExcel_OpeningStock)
					If value IsNot Me.m_frmExportImportExcel_OpeningStock Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmExportImportExcel_OpeningStock)(Me.m_frmExportImportExcel_OpeningStock)
					End If
				End Set
			End Property

			' Token: 0x170000A0 RID: 160
			' (get) Token: 0x060000CF RID: 207 RVA: 0x00003288 File Offset: 0x00001488
			' (set) Token: 0x06000259 RID: 601 RVA: 0x00006540 File Offset: 0x00004740
			Public Property frmExportImportExcel_ProductsRecord As frmExportImportExcel_ProductsRecord
				<DebuggerHidden()>
				Get
					Me.m_frmExportImportExcel_ProductsRecord = MyProject.MyForms.Create__Instance__(Of frmExportImportExcel_ProductsRecord)(Me.m_frmExportImportExcel_ProductsRecord)
					Return Me.m_frmExportImportExcel_ProductsRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmExportImportExcel_ProductsRecord)
					If value IsNot Me.m_frmExportImportExcel_ProductsRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmExportImportExcel_ProductsRecord)(Me.m_frmExportImportExcel_ProductsRecord)
					End If
				End Set
			End Property

			' Token: 0x170000A1 RID: 161
			' (get) Token: 0x060000D0 RID: 208 RVA: 0x000032A3 File Offset: 0x000014A3
			' (set) Token: 0x0600025A RID: 602 RVA: 0x0000656C File Offset: 0x0000476C
			Public Property frmExportImportExcel_ProductsRecord1 As frmExportImportExcel_ProductsRecord1
				<DebuggerHidden()>
				Get
					Me.m_frmExportImportExcel_ProductsRecord1 = MyProject.MyForms.Create__Instance__(Of frmExportImportExcel_ProductsRecord1)(Me.m_frmExportImportExcel_ProductsRecord1)
					Return Me.m_frmExportImportExcel_ProductsRecord1
				End Get
				<DebuggerHidden()>
				Set(value As frmExportImportExcel_ProductsRecord1)
					If value IsNot Me.m_frmExportImportExcel_ProductsRecord1 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmExportImportExcel_ProductsRecord1)(Me.m_frmExportImportExcel_ProductsRecord1)
					End If
				End Set
			End Property

			' Token: 0x170000A2 RID: 162
			' (get) Token: 0x060000D1 RID: 209 RVA: 0x000032BE File Offset: 0x000014BE
			' (set) Token: 0x0600025B RID: 603 RVA: 0x00006598 File Offset: 0x00004798
			Public Property frmExportImportExcel_Salesman As frmExportImportExcel_Salesman
				<DebuggerHidden()>
				Get
					Me.m_frmExportImportExcel_Salesman = MyProject.MyForms.Create__Instance__(Of frmExportImportExcel_Salesman)(Me.m_frmExportImportExcel_Salesman)
					Return Me.m_frmExportImportExcel_Salesman
				End Get
				<DebuggerHidden()>
				Set(value As frmExportImportExcel_Salesman)
					If value IsNot Me.m_frmExportImportExcel_Salesman Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmExportImportExcel_Salesman)(Me.m_frmExportImportExcel_Salesman)
					End If
				End Set
			End Property

			' Token: 0x170000A3 RID: 163
			' (get) Token: 0x060000D2 RID: 210 RVA: 0x000032D9 File Offset: 0x000014D9
			' (set) Token: 0x0600025C RID: 604 RVA: 0x000065C4 File Offset: 0x000047C4
			Public Property frmExportImportExcel_Suppliers As frmExportImportExcel_Suppliers
				<DebuggerHidden()>
				Get
					Me.m_frmExportImportExcel_Suppliers = MyProject.MyForms.Create__Instance__(Of frmExportImportExcel_Suppliers)(Me.m_frmExportImportExcel_Suppliers)
					Return Me.m_frmExportImportExcel_Suppliers
				End Get
				<DebuggerHidden()>
				Set(value As frmExportImportExcel_Suppliers)
					If value IsNot Me.m_frmExportImportExcel_Suppliers Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmExportImportExcel_Suppliers)(Me.m_frmExportImportExcel_Suppliers)
					End If
				End Set
			End Property

			' Token: 0x170000A4 RID: 164
			' (get) Token: 0x060000D3 RID: 211 RVA: 0x000032F4 File Offset: 0x000014F4
			' (set) Token: 0x0600025D RID: 605 RVA: 0x000065F0 File Offset: 0x000047F0
			Public Property frmFileupload As frmFileupload
				<DebuggerHidden()>
				Get
					Me.m_frmFileupload = MyProject.MyForms.Create__Instance__(Of frmFileupload)(Me.m_frmFileupload)
					Return Me.m_frmFileupload
				End Get
				<DebuggerHidden()>
				Set(value As frmFileupload)
					If value IsNot Me.m_frmFileupload Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmFileupload)(Me.m_frmFileupload)
					End If
				End Set
			End Property

			' Token: 0x170000A5 RID: 165
			' (get) Token: 0x060000D4 RID: 212 RVA: 0x0000330F File Offset: 0x0000150F
			' (set) Token: 0x0600025E RID: 606 RVA: 0x0000661C File Offset: 0x0000481C
			Public Property frmFollowUp_Lead As frmFollowUp_Lead
				<DebuggerHidden()>
				Get
					Me.m_frmFollowUp_Lead = MyProject.MyForms.Create__Instance__(Of frmFollowUp_Lead)(Me.m_frmFollowUp_Lead)
					Return Me.m_frmFollowUp_Lead
				End Get
				<DebuggerHidden()>
				Set(value As frmFollowUp_Lead)
					If value IsNot Me.m_frmFollowUp_Lead Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmFollowUp_Lead)(Me.m_frmFollowUp_Lead)
					End If
				End Set
			End Property

			' Token: 0x170000A6 RID: 166
			' (get) Token: 0x060000D5 RID: 213 RVA: 0x0000332A File Offset: 0x0000152A
			' (set) Token: 0x0600025F RID: 607 RVA: 0x00006648 File Offset: 0x00004848
			Public Property frmFollowUp_LeadRecords As frmFollowUp_LeadRecords
				<DebuggerHidden()>
				Get
					Me.m_frmFollowUp_LeadRecords = MyProject.MyForms.Create__Instance__(Of frmFollowUp_LeadRecords)(Me.m_frmFollowUp_LeadRecords)
					Return Me.m_frmFollowUp_LeadRecords
				End Get
				<DebuggerHidden()>
				Set(value As frmFollowUp_LeadRecords)
					If value IsNot Me.m_frmFollowUp_LeadRecords Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmFollowUp_LeadRecords)(Me.m_frmFollowUp_LeadRecords)
					End If
				End Set
			End Property

			' Token: 0x170000A7 RID: 167
			' (get) Token: 0x060000D6 RID: 214 RVA: 0x00003345 File Offset: 0x00001545
			' (set) Token: 0x06000260 RID: 608 RVA: 0x00006674 File Offset: 0x00004874
			Public Property frmFormwise_Shortcutkey As frmFormwise_Shortcutkey
				<DebuggerHidden()>
				Get
					Me.m_frmFormwise_Shortcutkey = MyProject.MyForms.Create__Instance__(Of frmFormwise_Shortcutkey)(Me.m_frmFormwise_Shortcutkey)
					Return Me.m_frmFormwise_Shortcutkey
				End Get
				<DebuggerHidden()>
				Set(value As frmFormwise_Shortcutkey)
					If value IsNot Me.m_frmFormwise_Shortcutkey Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmFormwise_Shortcutkey)(Me.m_frmFormwise_Shortcutkey)
					End If
				End Set
			End Property

			' Token: 0x170000A8 RID: 168
			' (get) Token: 0x060000D7 RID: 215 RVA: 0x00003360 File Offset: 0x00001560
			' (set) Token: 0x06000261 RID: 609 RVA: 0x000066A0 File Offset: 0x000048A0
			Public Property frmFundDeposit As frmFundDeposit
				<DebuggerHidden()>
				Get
					Me.m_frmFundDeposit = MyProject.MyForms.Create__Instance__(Of frmFundDeposit)(Me.m_frmFundDeposit)
					Return Me.m_frmFundDeposit
				End Get
				<DebuggerHidden()>
				Set(value As frmFundDeposit)
					If value IsNot Me.m_frmFundDeposit Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmFundDeposit)(Me.m_frmFundDeposit)
					End If
				End Set
			End Property

			' Token: 0x170000A9 RID: 169
			' (get) Token: 0x060000D8 RID: 216 RVA: 0x0000337B File Offset: 0x0000157B
			' (set) Token: 0x06000262 RID: 610 RVA: 0x000066CC File Offset: 0x000048CC
			Public Property frmFundTransfer As frmFundTransfer
				<DebuggerHidden()>
				Get
					Me.m_frmFundTransfer = MyProject.MyForms.Create__Instance__(Of frmFundTransfer)(Me.m_frmFundTransfer)
					Return Me.m_frmFundTransfer
				End Get
				<DebuggerHidden()>
				Set(value As frmFundTransfer)
					If value IsNot Me.m_frmFundTransfer Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmFundTransfer)(Me.m_frmFundTransfer)
					End If
				End Set
			End Property

			' Token: 0x170000AA RID: 170
			' (get) Token: 0x060000D9 RID: 217 RVA: 0x00003396 File Offset: 0x00001596
			' (set) Token: 0x06000263 RID: 611 RVA: 0x000066F8 File Offset: 0x000048F8
			Public Property frmFYChange As frmFYChange
				<DebuggerHidden()>
				Get
					Me.m_frmFYChange = MyProject.MyForms.Create__Instance__(Of frmFYChange)(Me.m_frmFYChange)
					Return Me.m_frmFYChange
				End Get
				<DebuggerHidden()>
				Set(value As frmFYChange)
					If value IsNot Me.m_frmFYChange Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmFYChange)(Me.m_frmFYChange)
					End If
				End Set
			End Property

			' Token: 0x170000AB RID: 171
			' (get) Token: 0x060000DA RID: 218 RVA: 0x000033B1 File Offset: 0x000015B1
			' (set) Token: 0x06000264 RID: 612 RVA: 0x00006724 File Offset: 0x00004924
			Public Property frmGallery As frmGallery
				<DebuggerHidden()>
				Get
					Me.m_frmGallery = MyProject.MyForms.Create__Instance__(Of frmGallery)(Me.m_frmGallery)
					Return Me.m_frmGallery
				End Get
				<DebuggerHidden()>
				Set(value As frmGallery)
					If value IsNot Me.m_frmGallery Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmGallery)(Me.m_frmGallery)
					End If
				End Set
			End Property

			' Token: 0x170000AC RID: 172
			' (get) Token: 0x060000DB RID: 219 RVA: 0x000033CC File Offset: 0x000015CC
			' (set) Token: 0x06000265 RID: 613 RVA: 0x00006750 File Offset: 0x00004950
			Public Property FrmGDClientSample As FrmGDClientSample
				<DebuggerHidden()>
				Get
					Me.m_FrmGDClientSample = MyProject.MyForms.Create__Instance__(Of FrmGDClientSample)(Me.m_FrmGDClientSample)
					Return Me.m_FrmGDClientSample
				End Get
				<DebuggerHidden()>
				Set(value As FrmGDClientSample)
					If value IsNot Me.m_FrmGDClientSample Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of FrmGDClientSample)(Me.m_FrmGDClientSample)
					End If
				End Set
			End Property

			' Token: 0x170000AD RID: 173
			' (get) Token: 0x060000DC RID: 220 RVA: 0x000033E7 File Offset: 0x000015E7
			' (set) Token: 0x06000266 RID: 614 RVA: 0x0000677C File Offset: 0x0000497C
			Public Property frmGeneralDayBook As frmGeneralDayBook
				<DebuggerHidden()>
				Get
					Me.m_frmGeneralDayBook = MyProject.MyForms.Create__Instance__(Of frmGeneralDayBook)(Me.m_frmGeneralDayBook)
					Return Me.m_frmGeneralDayBook
				End Get
				<DebuggerHidden()>
				Set(value As frmGeneralDayBook)
					If value IsNot Me.m_frmGeneralDayBook Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmGeneralDayBook)(Me.m_frmGeneralDayBook)
					End If
				End Set
			End Property

			' Token: 0x170000AE RID: 174
			' (get) Token: 0x060000DD RID: 221 RVA: 0x00003402 File Offset: 0x00001602
			' (set) Token: 0x06000267 RID: 615 RVA: 0x000067A8 File Offset: 0x000049A8
			Public Property frmGeneralLedger As frmGeneralLedger
				<DebuggerHidden()>
				Get
					Me.m_frmGeneralLedger = MyProject.MyForms.Create__Instance__(Of frmGeneralLedger)(Me.m_frmGeneralLedger)
					Return Me.m_frmGeneralLedger
				End Get
				<DebuggerHidden()>
				Set(value As frmGeneralLedger)
					If value IsNot Me.m_frmGeneralLedger Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmGeneralLedger)(Me.m_frmGeneralLedger)
					End If
				End Set
			End Property

			' Token: 0x170000AF RID: 175
			' (get) Token: 0x060000DE RID: 222 RVA: 0x0000341D File Offset: 0x0000161D
			' (set) Token: 0x06000268 RID: 616 RVA: 0x000067D4 File Offset: 0x000049D4
			Public Property frmGift As frmGift
				<DebuggerHidden()>
				Get
					Me.m_frmGift = MyProject.MyForms.Create__Instance__(Of frmGift)(Me.m_frmGift)
					Return Me.m_frmGift
				End Get
				<DebuggerHidden()>
				Set(value As frmGift)
					If value IsNot Me.m_frmGift Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmGift)(Me.m_frmGift)
					End If
				End Set
			End Property

			' Token: 0x170000B0 RID: 176
			' (get) Token: 0x060000DF RID: 223 RVA: 0x00003438 File Offset: 0x00001638
			' (set) Token: 0x06000269 RID: 617 RVA: 0x00006800 File Offset: 0x00004A00
			Public Property frmGiftApply As frmGiftApply
				<DebuggerHidden()>
				Get
					Me.m_frmGiftApply = MyProject.MyForms.Create__Instance__(Of frmGiftApply)(Me.m_frmGiftApply)
					Return Me.m_frmGiftApply
				End Get
				<DebuggerHidden()>
				Set(value As frmGiftApply)
					If value IsNot Me.m_frmGiftApply Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmGiftApply)(Me.m_frmGiftApply)
					End If
				End Set
			End Property

			' Token: 0x170000B1 RID: 177
			' (get) Token: 0x060000E0 RID: 224 RVA: 0x00003453 File Offset: 0x00001653
			' (set) Token: 0x0600026A RID: 618 RVA: 0x0000682C File Offset: 0x00004A2C
			Public Property frmGiftCodeSender As frmGiftCodeSender
				<DebuggerHidden()>
				Get
					Me.m_frmGiftCodeSender = MyProject.MyForms.Create__Instance__(Of frmGiftCodeSender)(Me.m_frmGiftCodeSender)
					Return Me.m_frmGiftCodeSender
				End Get
				<DebuggerHidden()>
				Set(value As frmGiftCodeSender)
					If value IsNot Me.m_frmGiftCodeSender Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmGiftCodeSender)(Me.m_frmGiftCodeSender)
					End If
				End Set
			End Property

			' Token: 0x170000B2 RID: 178
			' (get) Token: 0x060000E1 RID: 225 RVA: 0x0000346E File Offset: 0x0000166E
			' (set) Token: 0x0600026B RID: 619 RVA: 0x00006858 File Offset: 0x00004A58
			Public Property frmGodownConfig As frmGodownConfig
				<DebuggerHidden()>
				Get
					Me.m_frmGodownConfig = MyProject.MyForms.Create__Instance__(Of frmGodownConfig)(Me.m_frmGodownConfig)
					Return Me.m_frmGodownConfig
				End Get
				<DebuggerHidden()>
				Set(value As frmGodownConfig)
					If value IsNot Me.m_frmGodownConfig Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmGodownConfig)(Me.m_frmGodownConfig)
					End If
				End Set
			End Property

			' Token: 0x170000B3 RID: 179
			' (get) Token: 0x060000E2 RID: 226 RVA: 0x00003489 File Offset: 0x00001689
			' (set) Token: 0x0600026C RID: 620 RVA: 0x00006884 File Offset: 0x00004A84
			Public Property frmGodownInward As frmGodownInward
				<DebuggerHidden()>
				Get
					Me.m_frmGodownInward = MyProject.MyForms.Create__Instance__(Of frmGodownInward)(Me.m_frmGodownInward)
					Return Me.m_frmGodownInward
				End Get
				<DebuggerHidden()>
				Set(value As frmGodownInward)
					If value IsNot Me.m_frmGodownInward Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmGodownInward)(Me.m_frmGodownInward)
					End If
				End Set
			End Property

			' Token: 0x170000B4 RID: 180
			' (get) Token: 0x060000E3 RID: 227 RVA: 0x000034A4 File Offset: 0x000016A4
			' (set) Token: 0x0600026D RID: 621 RVA: 0x000068B0 File Offset: 0x00004AB0
			Public Property frmGodownOutward As frmGodownOutward
				<DebuggerHidden()>
				Get
					Me.m_frmGodownOutward = MyProject.MyForms.Create__Instance__(Of frmGodownOutward)(Me.m_frmGodownOutward)
					Return Me.m_frmGodownOutward
				End Get
				<DebuggerHidden()>
				Set(value As frmGodownOutward)
					If value IsNot Me.m_frmGodownOutward Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmGodownOutward)(Me.m_frmGodownOutward)
					End If
				End Set
			End Property

			' Token: 0x170000B5 RID: 181
			' (get) Token: 0x060000E4 RID: 228 RVA: 0x000034BF File Offset: 0x000016BF
			' (set) Token: 0x0600026E RID: 622 RVA: 0x000068DC File Offset: 0x00004ADC
			Public Property frmGoProduct As frmGoProduct
				<DebuggerHidden()>
				Get
					Me.m_frmGoProduct = MyProject.MyForms.Create__Instance__(Of frmGoProduct)(Me.m_frmGoProduct)
					Return Me.m_frmGoProduct
				End Get
				<DebuggerHidden()>
				Set(value As frmGoProduct)
					If value IsNot Me.m_frmGoProduct Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmGoProduct)(Me.m_frmGoProduct)
					End If
				End Set
			End Property

			' Token: 0x170000B6 RID: 182
			' (get) Token: 0x060000E5 RID: 229 RVA: 0x000034DA File Offset: 0x000016DA
			' (set) Token: 0x0600026F RID: 623 RVA: 0x00006908 File Offset: 0x00004B08
			Public Property frmGSheet_Report As frmGSheet_Report
				<DebuggerHidden()>
				Get
					Me.m_frmGSheet_Report = MyProject.MyForms.Create__Instance__(Of frmGSheet_Report)(Me.m_frmGSheet_Report)
					Return Me.m_frmGSheet_Report
				End Get
				<DebuggerHidden()>
				Set(value As frmGSheet_Report)
					If value IsNot Me.m_frmGSheet_Report Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmGSheet_Report)(Me.m_frmGSheet_Report)
					End If
				End Set
			End Property

			' Token: 0x170000B7 RID: 183
			' (get) Token: 0x060000E6 RID: 230 RVA: 0x000034F5 File Offset: 0x000016F5
			' (set) Token: 0x06000270 RID: 624 RVA: 0x00006934 File Offset: 0x00004B34
			Public Property frmGSheet_Setting As frmGSheet_Setting
				<DebuggerHidden()>
				Get
					Me.m_frmGSheet_Setting = MyProject.MyForms.Create__Instance__(Of frmGSheet_Setting)(Me.m_frmGSheet_Setting)
					Return Me.m_frmGSheet_Setting
				End Get
				<DebuggerHidden()>
				Set(value As frmGSheet_Setting)
					If value IsNot Me.m_frmGSheet_Setting Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmGSheet_Setting)(Me.m_frmGSheet_Setting)
					End If
				End Set
			End Property

			' Token: 0x170000B8 RID: 184
			' (get) Token: 0x060000E7 RID: 231 RVA: 0x00003510 File Offset: 0x00001710
			' (set) Token: 0x06000271 RID: 625 RVA: 0x00006960 File Offset: 0x00004B60
			Public Property frmGSTCalc As frmGSTCalc
				<DebuggerHidden()>
				Get
					Me.m_frmGSTCalc = MyProject.MyForms.Create__Instance__(Of frmGSTCalc)(Me.m_frmGSTCalc)
					Return Me.m_frmGSTCalc
				End Get
				<DebuggerHidden()>
				Set(value As frmGSTCalc)
					If value IsNot Me.m_frmGSTCalc Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmGSTCalc)(Me.m_frmGSTCalc)
					End If
				End Set
			End Property

			' Token: 0x170000B9 RID: 185
			' (get) Token: 0x060000E8 RID: 232 RVA: 0x0000352B File Offset: 0x0000172B
			' (set) Token: 0x06000272 RID: 626 RVA: 0x0000698C File Offset: 0x00004B8C
			Public Property frmGSTCalc1 As frmGSTCalc1
				<DebuggerHidden()>
				Get
					Me.m_frmGSTCalc1 = MyProject.MyForms.Create__Instance__(Of frmGSTCalc1)(Me.m_frmGSTCalc1)
					Return Me.m_frmGSTCalc1
				End Get
				<DebuggerHidden()>
				Set(value As frmGSTCalc1)
					If value IsNot Me.m_frmGSTCalc1 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmGSTCalc1)(Me.m_frmGSTCalc1)
					End If
				End Set
			End Property

			' Token: 0x170000BA RID: 186
			' (get) Token: 0x060000E9 RID: 233 RVA: 0x00003546 File Offset: 0x00001746
			' (set) Token: 0x06000273 RID: 627 RVA: 0x000069B8 File Offset: 0x00004BB8
			Public Property frmGSTDetails As frmGSTDetails
				<DebuggerHidden()>
				Get
					Me.m_frmGSTDetails = MyProject.MyForms.Create__Instance__(Of frmGSTDetails)(Me.m_frmGSTDetails)
					Return Me.m_frmGSTDetails
				End Get
				<DebuggerHidden()>
				Set(value As frmGSTDetails)
					If value IsNot Me.m_frmGSTDetails Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmGSTDetails)(Me.m_frmGSTDetails)
					End If
				End Set
			End Property

			' Token: 0x170000BB RID: 187
			' (get) Token: 0x060000EA RID: 234 RVA: 0x00003561 File Offset: 0x00001761
			' (set) Token: 0x06000274 RID: 628 RVA: 0x000069E4 File Offset: 0x00004BE4
			Public Property frmGSTDetailsPur As frmGSTDetailsPur
				<DebuggerHidden()>
				Get
					Me.m_frmGSTDetailsPur = MyProject.MyForms.Create__Instance__(Of frmGSTDetailsPur)(Me.m_frmGSTDetailsPur)
					Return Me.m_frmGSTDetailsPur
				End Get
				<DebuggerHidden()>
				Set(value As frmGSTDetailsPur)
					If value IsNot Me.m_frmGSTDetailsPur Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmGSTDetailsPur)(Me.m_frmGSTDetailsPur)
					End If
				End Set
			End Property

			' Token: 0x170000BC RID: 188
			' (get) Token: 0x060000EB RID: 235 RVA: 0x0000357C File Offset: 0x0000177C
			' (set) Token: 0x06000275 RID: 629 RVA: 0x00006A10 File Offset: 0x00004C10
			Public Property frmGstNonGst As frmGstNonGst
				<DebuggerHidden()>
				Get
					Me.m_frmGstNonGst = MyProject.MyForms.Create__Instance__(Of frmGstNonGst)(Me.m_frmGstNonGst)
					Return Me.m_frmGstNonGst
				End Get
				<DebuggerHidden()>
				Set(value As frmGstNonGst)
					If value IsNot Me.m_frmGstNonGst Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmGstNonGst)(Me.m_frmGstNonGst)
					End If
				End Set
			End Property

			' Token: 0x170000BD RID: 189
			' (get) Token: 0x060000EC RID: 236 RVA: 0x00003597 File Offset: 0x00001797
			' (set) Token: 0x06000276 RID: 630 RVA: 0x00006A3C File Offset: 0x00004C3C
			Public Property frmGSTR1 As frmGSTR1
				<DebuggerHidden()>
				Get
					Me.m_frmGSTR1 = MyProject.MyForms.Create__Instance__(Of frmGSTR1)(Me.m_frmGSTR1)
					Return Me.m_frmGSTR1
				End Get
				<DebuggerHidden()>
				Set(value As frmGSTR1)
					If value IsNot Me.m_frmGSTR1 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmGSTR1)(Me.m_frmGSTR1)
					End If
				End Set
			End Property

			' Token: 0x170000BE RID: 190
			' (get) Token: 0x060000ED RID: 237 RVA: 0x000035B2 File Offset: 0x000017B2
			' (set) Token: 0x06000277 RID: 631 RVA: 0x00006A68 File Offset: 0x00004C68
			Public Property frmGSTR1_HSNC As frmGSTR1_HSNC
				<DebuggerHidden()>
				Get
					Me.m_frmGSTR1_HSNC = MyProject.MyForms.Create__Instance__(Of frmGSTR1_HSNC)(Me.m_frmGSTR1_HSNC)
					Return Me.m_frmGSTR1_HSNC
				End Get
				<DebuggerHidden()>
				Set(value As frmGSTR1_HSNC)
					If value IsNot Me.m_frmGSTR1_HSNC Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmGSTR1_HSNC)(Me.m_frmGSTR1_HSNC)
					End If
				End Set
			End Property

			' Token: 0x170000BF RID: 191
			' (get) Token: 0x060000EE RID: 238 RVA: 0x000035CD File Offset: 0x000017CD
			' (set) Token: 0x06000278 RID: 632 RVA: 0x00006A94 File Offset: 0x00004C94
			Public Property frmGSTR3B As frmGSTR3B
				<DebuggerHidden()>
				Get
					Me.m_frmGSTR3B = MyProject.MyForms.Create__Instance__(Of frmGSTR3B)(Me.m_frmGSTR3B)
					Return Me.m_frmGSTR3B
				End Get
				<DebuggerHidden()>
				Set(value As frmGSTR3B)
					If value IsNot Me.m_frmGSTR3B Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmGSTR3B)(Me.m_frmGSTR3B)
					End If
				End Set
			End Property

			' Token: 0x170000C0 RID: 192
			' (get) Token: 0x060000EF RID: 239 RVA: 0x000035E8 File Offset: 0x000017E8
			' (set) Token: 0x06000279 RID: 633 RVA: 0x00006AC0 File Offset: 0x00004CC0
			Public Property frmHoldrecord As frmHoldrecord
				<DebuggerHidden()>
				Get
					Me.m_frmHoldrecord = MyProject.MyForms.Create__Instance__(Of frmHoldrecord)(Me.m_frmHoldrecord)
					Return Me.m_frmHoldrecord
				End Get
				<DebuggerHidden()>
				Set(value As frmHoldrecord)
					If value IsNot Me.m_frmHoldrecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmHoldrecord)(Me.m_frmHoldrecord)
					End If
				End Set
			End Property

			' Token: 0x170000C1 RID: 193
			' (get) Token: 0x060000F0 RID: 240 RVA: 0x00003603 File Offset: 0x00001803
			' (set) Token: 0x0600027A RID: 634 RVA: 0x00006AEC File Offset: 0x00004CEC
			Public Property frmHoldrecord_Purchase As frmHoldrecord_Purchase
				<DebuggerHidden()>
				Get
					Me.m_frmHoldrecord_Purchase = MyProject.MyForms.Create__Instance__(Of frmHoldrecord_Purchase)(Me.m_frmHoldrecord_Purchase)
					Return Me.m_frmHoldrecord_Purchase
				End Get
				<DebuggerHidden()>
				Set(value As frmHoldrecord_Purchase)
					If value IsNot Me.m_frmHoldrecord_Purchase Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmHoldrecord_Purchase)(Me.m_frmHoldrecord_Purchase)
					End If
				End Set
			End Property

			' Token: 0x170000C2 RID: 194
			' (get) Token: 0x060000F1 RID: 241 RVA: 0x0000361E File Offset: 0x0000181E
			' (set) Token: 0x0600027B RID: 635 RVA: 0x00006B18 File Offset: 0x00004D18
			Public Property frmImageReader As frmImageReader
				<DebuggerHidden()>
				Get
					Me.m_frmImageReader = MyProject.MyForms.Create__Instance__(Of frmImageReader)(Me.m_frmImageReader)
					Return Me.m_frmImageReader
				End Get
				<DebuggerHidden()>
				Set(value As frmImageReader)
					If value IsNot Me.m_frmImageReader Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmImageReader)(Me.m_frmImageReader)
					End If
				End Set
			End Property

			' Token: 0x170000C3 RID: 195
			' (get) Token: 0x060000F2 RID: 242 RVA: 0x00003639 File Offset: 0x00001839
			' (set) Token: 0x0600027C RID: 636 RVA: 0x00006B44 File Offset: 0x00004D44
			Public Property frmImportPro As frmImportPro
				<DebuggerHidden()>
				Get
					Me.m_frmImportPro = MyProject.MyForms.Create__Instance__(Of frmImportPro)(Me.m_frmImportPro)
					Return Me.m_frmImportPro
				End Get
				<DebuggerHidden()>
				Set(value As frmImportPro)
					If value IsNot Me.m_frmImportPro Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmImportPro)(Me.m_frmImportPro)
					End If
				End Set
			End Property

			' Token: 0x170000C4 RID: 196
			' (get) Token: 0x060000F3 RID: 243 RVA: 0x00003654 File Offset: 0x00001854
			' (set) Token: 0x0600027D RID: 637 RVA: 0x00006B70 File Offset: 0x00004D70
			Public Property frmIncome As frmIncome
				<DebuggerHidden()>
				Get
					Me.m_frmIncome = MyProject.MyForms.Create__Instance__(Of frmIncome)(Me.m_frmIncome)
					Return Me.m_frmIncome
				End Get
				<DebuggerHidden()>
				Set(value As frmIncome)
					If value IsNot Me.m_frmIncome Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmIncome)(Me.m_frmIncome)
					End If
				End Set
			End Property

			' Token: 0x170000C5 RID: 197
			' (get) Token: 0x060000F4 RID: 244 RVA: 0x0000366F File Offset: 0x0000186F
			' (set) Token: 0x0600027E RID: 638 RVA: 0x00006B9C File Offset: 0x00004D9C
			Public Property frmIncomeDashboard As frmIncomeDashboard
				<DebuggerHidden()>
				Get
					Me.m_frmIncomeDashboard = MyProject.MyForms.Create__Instance__(Of frmIncomeDashboard)(Me.m_frmIncomeDashboard)
					Return Me.m_frmIncomeDashboard
				End Get
				<DebuggerHidden()>
				Set(value As frmIncomeDashboard)
					If value IsNot Me.m_frmIncomeDashboard Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmIncomeDashboard)(Me.m_frmIncomeDashboard)
					End If
				End Set
			End Property

			' Token: 0x170000C6 RID: 198
			' (get) Token: 0x060000F5 RID: 245 RVA: 0x0000368A File Offset: 0x0000188A
			' (set) Token: 0x0600027F RID: 639 RVA: 0x00006BC8 File Offset: 0x00004DC8
			Public Property frmIncomeRecord As frmIncomeRecord
				<DebuggerHidden()>
				Get
					Me.m_frmIncomeRecord = MyProject.MyForms.Create__Instance__(Of frmIncomeRecord)(Me.m_frmIncomeRecord)
					Return Me.m_frmIncomeRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmIncomeRecord)
					If value IsNot Me.m_frmIncomeRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmIncomeRecord)(Me.m_frmIncomeRecord)
					End If
				End Set
			End Property

			' Token: 0x170000C7 RID: 199
			' (get) Token: 0x060000F6 RID: 246 RVA: 0x000036A5 File Offset: 0x000018A5
			' (set) Token: 0x06000280 RID: 640 RVA: 0x00006BF4 File Offset: 0x00004DF4
			Public Property frmInEx As frmInEx
				<DebuggerHidden()>
				Get
					Me.m_frmInEx = MyProject.MyForms.Create__Instance__(Of frmInEx)(Me.m_frmInEx)
					Return Me.m_frmInEx
				End Get
				<DebuggerHidden()>
				Set(value As frmInEx)
					If value IsNot Me.m_frmInEx Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmInEx)(Me.m_frmInEx)
					End If
				End Set
			End Property

			' Token: 0x170000C8 RID: 200
			' (get) Token: 0x060000F7 RID: 247 RVA: 0x000036C0 File Offset: 0x000018C0
			' (set) Token: 0x06000281 RID: 641 RVA: 0x00006C20 File Offset: 0x00004E20
			Public Property frmInfoBrodcast As frmInfoBrodcast
				<DebuggerHidden()>
				Get
					Me.m_frmInfoBrodcast = MyProject.MyForms.Create__Instance__(Of frmInfoBrodcast)(Me.m_frmInfoBrodcast)
					Return Me.m_frmInfoBrodcast
				End Get
				<DebuggerHidden()>
				Set(value As frmInfoBrodcast)
					If value IsNot Me.m_frmInfoBrodcast Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmInfoBrodcast)(Me.m_frmInfoBrodcast)
					End If
				End Set
			End Property

			' Token: 0x170000C9 RID: 201
			' (get) Token: 0x060000F8 RID: 248 RVA: 0x000036DB File Offset: 0x000018DB
			' (set) Token: 0x06000282 RID: 642 RVA: 0x00006C4C File Offset: 0x00004E4C
			Public Property frmInvCode As frmInvCode
				<DebuggerHidden()>
				Get
					Me.m_frmInvCode = MyProject.MyForms.Create__Instance__(Of frmInvCode)(Me.m_frmInvCode)
					Return Me.m_frmInvCode
				End Get
				<DebuggerHidden()>
				Set(value As frmInvCode)
					If value IsNot Me.m_frmInvCode Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmInvCode)(Me.m_frmInvCode)
					End If
				End Set
			End Property

			' Token: 0x170000CA RID: 202
			' (get) Token: 0x060000F9 RID: 249 RVA: 0x000036F6 File Offset: 0x000018F6
			' (set) Token: 0x06000283 RID: 643 RVA: 0x00006C78 File Offset: 0x00004E78
			Public Property frmInvoiceHeader As frmInvoiceHeader
				<DebuggerHidden()>
				Get
					Me.m_frmInvoiceHeader = MyProject.MyForms.Create__Instance__(Of frmInvoiceHeader)(Me.m_frmInvoiceHeader)
					Return Me.m_frmInvoiceHeader
				End Get
				<DebuggerHidden()>
				Set(value As frmInvoiceHeader)
					If value IsNot Me.m_frmInvoiceHeader Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmInvoiceHeader)(Me.m_frmInvoiceHeader)
					End If
				End Set
			End Property

			' Token: 0x170000CB RID: 203
			' (get) Token: 0x060000FA RID: 250 RVA: 0x00003711 File Offset: 0x00001911
			' (set) Token: 0x06000284 RID: 644 RVA: 0x00006CA4 File Offset: 0x00004EA4
			Public Property frmInvoicePhoto As frmInvoicePhoto
				<DebuggerHidden()>
				Get
					Me.m_frmInvoicePhoto = MyProject.MyForms.Create__Instance__(Of frmInvoicePhoto)(Me.m_frmInvoicePhoto)
					Return Me.m_frmInvoicePhoto
				End Get
				<DebuggerHidden()>
				Set(value As frmInvoicePhoto)
					If value IsNot Me.m_frmInvoicePhoto Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmInvoicePhoto)(Me.m_frmInvoicePhoto)
					End If
				End Set
			End Property

			' Token: 0x170000CC RID: 204
			' (get) Token: 0x060000FB RID: 251 RVA: 0x0000372C File Offset: 0x0000192C
			' (set) Token: 0x06000285 RID: 645 RVA: 0x00006CD0 File Offset: 0x00004ED0
			Public Property frmKeyBord As frmKeyBord
				<DebuggerHidden()>
				Get
					Me.m_frmKeyBord = MyProject.MyForms.Create__Instance__(Of frmKeyBord)(Me.m_frmKeyBord)
					Return Me.m_frmKeyBord
				End Get
				<DebuggerHidden()>
				Set(value As frmKeyBord)
					If value IsNot Me.m_frmKeyBord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmKeyBord)(Me.m_frmKeyBord)
					End If
				End Set
			End Property

			' Token: 0x170000CD RID: 205
			' (get) Token: 0x060000FC RID: 252 RVA: 0x00003747 File Offset: 0x00001947
			' (set) Token: 0x06000286 RID: 646 RVA: 0x00006CFC File Offset: 0x00004EFC
			Public Property frmKitchen_Section As frmKitchen_Section
				<DebuggerHidden()>
				Get
					Me.m_frmKitchen_Section = MyProject.MyForms.Create__Instance__(Of frmKitchen_Section)(Me.m_frmKitchen_Section)
					Return Me.m_frmKitchen_Section
				End Get
				<DebuggerHidden()>
				Set(value As frmKitchen_Section)
					If value IsNot Me.m_frmKitchen_Section Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmKitchen_Section)(Me.m_frmKitchen_Section)
					End If
				End Set
			End Property

			' Token: 0x170000CE RID: 206
			' (get) Token: 0x060000FD RID: 253 RVA: 0x00003762 File Offset: 0x00001962
			' (set) Token: 0x06000287 RID: 647 RVA: 0x00006D28 File Offset: 0x00004F28
			Public Property frmLanChat As frmLanChat
				<DebuggerHidden()>
				Get
					Me.m_frmLanChat = MyProject.MyForms.Create__Instance__(Of frmLanChat)(Me.m_frmLanChat)
					Return Me.m_frmLanChat
				End Get
				<DebuggerHidden()>
				Set(value As frmLanChat)
					If value IsNot Me.m_frmLanChat Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmLanChat)(Me.m_frmLanChat)
					End If
				End Set
			End Property

			' Token: 0x170000CF RID: 207
			' (get) Token: 0x060000FE RID: 254 RVA: 0x0000377D File Offset: 0x0000197D
			' (set) Token: 0x06000288 RID: 648 RVA: 0x00006D54 File Offset: 0x00004F54
			Public Property frmLCardIssue As frmLCardIssue
				<DebuggerHidden()>
				Get
					Me.m_frmLCardIssue = MyProject.MyForms.Create__Instance__(Of frmLCardIssue)(Me.m_frmLCardIssue)
					Return Me.m_frmLCardIssue
				End Get
				<DebuggerHidden()>
				Set(value As frmLCardIssue)
					If value IsNot Me.m_frmLCardIssue Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmLCardIssue)(Me.m_frmLCardIssue)
					End If
				End Set
			End Property

			' Token: 0x170000D0 RID: 208
			' (get) Token: 0x060000FF RID: 255 RVA: 0x00003798 File Offset: 0x00001998
			' (set) Token: 0x06000289 RID: 649 RVA: 0x00006D80 File Offset: 0x00004F80
			Public Property frmLead2 As frmLead2
				<DebuggerHidden()>
				Get
					Me.m_frmLead2 = MyProject.MyForms.Create__Instance__(Of frmLead2)(Me.m_frmLead2)
					Return Me.m_frmLead2
				End Get
				<DebuggerHidden()>
				Set(value As frmLead2)
					If value IsNot Me.m_frmLead2 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmLead2)(Me.m_frmLead2)
					End If
				End Set
			End Property

			' Token: 0x170000D1 RID: 209
			' (get) Token: 0x06000100 RID: 256 RVA: 0x000037B3 File Offset: 0x000019B3
			' (set) Token: 0x0600028A RID: 650 RVA: 0x00006DAC File Offset: 0x00004FAC
			Public Property frmLead_Product As frmLead_Product
				<DebuggerHidden()>
				Get
					Me.m_frmLead_Product = MyProject.MyForms.Create__Instance__(Of frmLead_Product)(Me.m_frmLead_Product)
					Return Me.m_frmLead_Product
				End Get
				<DebuggerHidden()>
				Set(value As frmLead_Product)
					If value IsNot Me.m_frmLead_Product Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmLead_Product)(Me.m_frmLead_Product)
					End If
				End Set
			End Property

			' Token: 0x170000D2 RID: 210
			' (get) Token: 0x06000101 RID: 257 RVA: 0x000037CE File Offset: 0x000019CE
			' (set) Token: 0x0600028B RID: 651 RVA: 0x00006DD8 File Offset: 0x00004FD8
			Public Property frmLead_Update As frmLead_Update
				<DebuggerHidden()>
				Get
					Me.m_frmLead_Update = MyProject.MyForms.Create__Instance__(Of frmLead_Update)(Me.m_frmLead_Update)
					Return Me.m_frmLead_Update
				End Get
				<DebuggerHidden()>
				Set(value As frmLead_Update)
					If value IsNot Me.m_frmLead_Update Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmLead_Update)(Me.m_frmLead_Update)
					End If
				End Set
			End Property

			' Token: 0x170000D3 RID: 211
			' (get) Token: 0x06000102 RID: 258 RVA: 0x000037E9 File Offset: 0x000019E9
			' (set) Token: 0x0600028C RID: 652 RVA: 0x00006E04 File Offset: 0x00005004
			Public Property frmLeadGenerate As frmLeadGenerate
				<DebuggerHidden()>
				Get
					Me.m_frmLeadGenerate = MyProject.MyForms.Create__Instance__(Of frmLeadGenerate)(Me.m_frmLeadGenerate)
					Return Me.m_frmLeadGenerate
				End Get
				<DebuggerHidden()>
				Set(value As frmLeadGenerate)
					If value IsNot Me.m_frmLeadGenerate Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmLeadGenerate)(Me.m_frmLeadGenerate)
					End If
				End Set
			End Property

			' Token: 0x170000D4 RID: 212
			' (get) Token: 0x06000103 RID: 259 RVA: 0x00003804 File Offset: 0x00001A04
			' (set) Token: 0x0600028D RID: 653 RVA: 0x00006E30 File Offset: 0x00005030
			Public Property frmLeadGenerateRecord As frmLeadGenerateRecord
				<DebuggerHidden()>
				Get
					Me.m_frmLeadGenerateRecord = MyProject.MyForms.Create__Instance__(Of frmLeadGenerateRecord)(Me.m_frmLeadGenerateRecord)
					Return Me.m_frmLeadGenerateRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmLeadGenerateRecord)
					If value IsNot Me.m_frmLeadGenerateRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmLeadGenerateRecord)(Me.m_frmLeadGenerateRecord)
					End If
				End Set
			End Property

			' Token: 0x170000D5 RID: 213
			' (get) Token: 0x06000104 RID: 260 RVA: 0x0000381F File Offset: 0x00001A1F
			' (set) Token: 0x0600028E RID: 654 RVA: 0x00006E5C File Offset: 0x0000505C
			Public Property frmLoading As frmLoading
				<DebuggerHidden()>
				Get
					Me.m_frmLoading = MyProject.MyForms.Create__Instance__(Of frmLoading)(Me.m_frmLoading)
					Return Me.m_frmLoading
				End Get
				<DebuggerHidden()>
				Set(value As frmLoading)
					If value IsNot Me.m_frmLoading Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmLoading)(Me.m_frmLoading)
					End If
				End Set
			End Property

			' Token: 0x170000D6 RID: 214
			' (get) Token: 0x06000105 RID: 261 RVA: 0x0000383A File Offset: 0x00001A3A
			' (set) Token: 0x0600028F RID: 655 RVA: 0x00006E88 File Offset: 0x00005088
			Public Property frmLogin As frmLogin
				<DebuggerHidden()>
				Get
					Me.m_frmLogin = MyProject.MyForms.Create__Instance__(Of frmLogin)(Me.m_frmLogin)
					Return Me.m_frmLogin
				End Get
				<DebuggerHidden()>
				Set(value As frmLogin)
					If value IsNot Me.m_frmLogin Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmLogin)(Me.m_frmLogin)
					End If
				End Set
			End Property

			' Token: 0x170000D7 RID: 215
			' (get) Token: 0x06000106 RID: 262 RVA: 0x00003855 File Offset: 0x00001A55
			' (set) Token: 0x06000290 RID: 656 RVA: 0x00006EB4 File Offset: 0x000050B4
			Public Property frmLogs As frmLogs
				<DebuggerHidden()>
				Get
					Me.m_frmLogs = MyProject.MyForms.Create__Instance__(Of frmLogs)(Me.m_frmLogs)
					Return Me.m_frmLogs
				End Get
				<DebuggerHidden()>
				Set(value As frmLogs)
					If value IsNot Me.m_frmLogs Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmLogs)(Me.m_frmLogs)
					End If
				End Set
			End Property

			' Token: 0x170000D8 RID: 216
			' (get) Token: 0x06000107 RID: 263 RVA: 0x00003870 File Offset: 0x00001A70
			' (set) Token: 0x06000291 RID: 657 RVA: 0x00006EE0 File Offset: 0x000050E0
			Public Property frmLoyaltySMS As frmLoyaltySMS
				<DebuggerHidden()>
				Get
					Me.m_frmLoyaltySMS = MyProject.MyForms.Create__Instance__(Of frmLoyaltySMS)(Me.m_frmLoyaltySMS)
					Return Me.m_frmLoyaltySMS
				End Get
				<DebuggerHidden()>
				Set(value As frmLoyaltySMS)
					If value IsNot Me.m_frmLoyaltySMS Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmLoyaltySMS)(Me.m_frmLoyaltySMS)
					End If
				End Set
			End Property

			' Token: 0x170000D9 RID: 217
			' (get) Token: 0x06000108 RID: 264 RVA: 0x0000388B File Offset: 0x00001A8B
			' (set) Token: 0x06000292 RID: 658 RVA: 0x00006F0C File Offset: 0x0000510C
			Public Property frmLoyaltyvalid As frmLoyaltyvalid
				<DebuggerHidden()>
				Get
					Me.m_frmLoyaltyvalid = MyProject.MyForms.Create__Instance__(Of frmLoyaltyvalid)(Me.m_frmLoyaltyvalid)
					Return Me.m_frmLoyaltyvalid
				End Get
				<DebuggerHidden()>
				Set(value As frmLoyaltyvalid)
					If value IsNot Me.m_frmLoyaltyvalid Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmLoyaltyvalid)(Me.m_frmLoyaltyvalid)
					End If
				End Set
			End Property

			' Token: 0x170000DA RID: 218
			' (get) Token: 0x06000109 RID: 265 RVA: 0x000038A6 File Offset: 0x00001AA6
			' (set) Token: 0x06000293 RID: 659 RVA: 0x00006F38 File Offset: 0x00005138
			Public Property frmLSetDefault As frmLSetDefault
				<DebuggerHidden()>
				Get
					Me.m_frmLSetDefault = MyProject.MyForms.Create__Instance__(Of frmLSetDefault)(Me.m_frmLSetDefault)
					Return Me.m_frmLSetDefault
				End Get
				<DebuggerHidden()>
				Set(value As frmLSetDefault)
					If value IsNot Me.m_frmLSetDefault Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmLSetDefault)(Me.m_frmLSetDefault)
					End If
				End Set
			End Property

			' Token: 0x170000DB RID: 219
			' (get) Token: 0x0600010A RID: 266 RVA: 0x000038C1 File Offset: 0x00001AC1
			' (set) Token: 0x06000294 RID: 660 RVA: 0x00006F64 File Offset: 0x00005164
			Public Property frmMainMenu As frmMainMenu
				<DebuggerHidden()>
				Get
					Me.m_frmMainMenu = MyProject.MyForms.Create__Instance__(Of frmMainMenu)(Me.m_frmMainMenu)
					Return Me.m_frmMainMenu
				End Get
				<DebuggerHidden()>
				Set(value As frmMainMenu)
					If value IsNot Me.m_frmMainMenu Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmMainMenu)(Me.m_frmMainMenu)
					End If
				End Set
			End Property

			' Token: 0x170000DC RID: 220
			' (get) Token: 0x0600010B RID: 267 RVA: 0x000038DC File Offset: 0x00001ADC
			' (set) Token: 0x06000295 RID: 661 RVA: 0x00006F90 File Offset: 0x00005190
			Public Property frmMenu_update As frmMenu_update
				<DebuggerHidden()>
				Get
					Me.m_frmMenu_update = MyProject.MyForms.Create__Instance__(Of frmMenu_update)(Me.m_frmMenu_update)
					Return Me.m_frmMenu_update
				End Get
				<DebuggerHidden()>
				Set(value As frmMenu_update)
					If value IsNot Me.m_frmMenu_update Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmMenu_update)(Me.m_frmMenu_update)
					End If
				End Set
			End Property

			' Token: 0x170000DD RID: 221
			' (get) Token: 0x0600010C RID: 268 RVA: 0x000038F7 File Offset: 0x00001AF7
			' (set) Token: 0x06000296 RID: 662 RVA: 0x00006FBC File Offset: 0x000051BC
			Public Property frmMenuHeader_update As frmMenuHeader_update
				<DebuggerHidden()>
				Get
					Me.m_frmMenuHeader_update = MyProject.MyForms.Create__Instance__(Of frmMenuHeader_update)(Me.m_frmMenuHeader_update)
					Return Me.m_frmMenuHeader_update
				End Get
				<DebuggerHidden()>
				Set(value As frmMenuHeader_update)
					If value IsNot Me.m_frmMenuHeader_update Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmMenuHeader_update)(Me.m_frmMenuHeader_update)
					End If
				End Set
			End Property

			' Token: 0x170000DE RID: 222
			' (get) Token: 0x0600010D RID: 269 RVA: 0x00003912 File Offset: 0x00001B12
			' (set) Token: 0x06000297 RID: 663 RVA: 0x00006FE8 File Offset: 0x000051E8
			Public Property frmMigrate_test As frmMigrate_test
				<DebuggerHidden()>
				Get
					Me.m_frmMigrate_test = MyProject.MyForms.Create__Instance__(Of frmMigrate_test)(Me.m_frmMigrate_test)
					Return Me.m_frmMigrate_test
				End Get
				<DebuggerHidden()>
				Set(value As frmMigrate_test)
					If value IsNot Me.m_frmMigrate_test Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmMigrate_test)(Me.m_frmMigrate_test)
					End If
				End Set
			End Property

			' Token: 0x170000DF RID: 223
			' (get) Token: 0x0600010E RID: 270 RVA: 0x0000392D File Offset: 0x00001B2D
			' (set) Token: 0x06000298 RID: 664 RVA: 0x00007014 File Offset: 0x00005214
			Public Property frmMigratedb_auto As frmMigratedb_auto
				<DebuggerHidden()>
				Get
					Me.m_frmMigratedb_auto = MyProject.MyForms.Create__Instance__(Of frmMigratedb_auto)(Me.m_frmMigratedb_auto)
					Return Me.m_frmMigratedb_auto
				End Get
				<DebuggerHidden()>
				Set(value As frmMigratedb_auto)
					If value IsNot Me.m_frmMigratedb_auto Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmMigratedb_auto)(Me.m_frmMigratedb_auto)
					End If
				End Set
			End Property

			' Token: 0x170000E0 RID: 224
			' (get) Token: 0x0600010F RID: 271 RVA: 0x00003948 File Offset: 0x00001B48
			' (set) Token: 0x06000299 RID: 665 RVA: 0x00007040 File Offset: 0x00005240
			Public Property frmMine As frmMine
				<DebuggerHidden()>
				Get
					Me.m_frmMine = MyProject.MyForms.Create__Instance__(Of frmMine)(Me.m_frmMine)
					Return Me.m_frmMine
				End Get
				<DebuggerHidden()>
				Set(value As frmMine)
					If value IsNot Me.m_frmMine Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmMine)(Me.m_frmMine)
					End If
				End Set
			End Property

			' Token: 0x170000E1 RID: 225
			' (get) Token: 0x06000110 RID: 272 RVA: 0x00003963 File Offset: 0x00001B63
			' (set) Token: 0x0600029A RID: 666 RVA: 0x0000706C File Offset: 0x0000526C
			Public Property frmMobileIDDialog As frmMobileIDDialog
				<DebuggerHidden()>
				Get
					Me.m_frmMobileIDDialog = MyProject.MyForms.Create__Instance__(Of frmMobileIDDialog)(Me.m_frmMobileIDDialog)
					Return Me.m_frmMobileIDDialog
				End Get
				<DebuggerHidden()>
				Set(value As frmMobileIDDialog)
					If value IsNot Me.m_frmMobileIDDialog Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmMobileIDDialog)(Me.m_frmMobileIDDialog)
					End If
				End Set
			End Property

			' Token: 0x170000E2 RID: 226
			' (get) Token: 0x06000111 RID: 273 RVA: 0x0000397E File Offset: 0x00001B7E
			' (set) Token: 0x0600029B RID: 667 RVA: 0x00007098 File Offset: 0x00005298
			Public Property frmMRP_Purchase_Update As frmMRP_Purchase_Update
				<DebuggerHidden()>
				Get
					Me.m_frmMRP_Purchase_Update = MyProject.MyForms.Create__Instance__(Of frmMRP_Purchase_Update)(Me.m_frmMRP_Purchase_Update)
					Return Me.m_frmMRP_Purchase_Update
				End Get
				<DebuggerHidden()>
				Set(value As frmMRP_Purchase_Update)
					If value IsNot Me.m_frmMRP_Purchase_Update Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmMRP_Purchase_Update)(Me.m_frmMRP_Purchase_Update)
					End If
				End Set
			End Property

			' Token: 0x170000E3 RID: 227
			' (get) Token: 0x06000112 RID: 274 RVA: 0x00003999 File Offset: 0x00001B99
			' (set) Token: 0x0600029C RID: 668 RVA: 0x000070C4 File Offset: 0x000052C4
			Public Property frmMRPShow As frmMRPShow
				<DebuggerHidden()>
				Get
					Me.m_frmMRPShow = MyProject.MyForms.Create__Instance__(Of frmMRPShow)(Me.m_frmMRPShow)
					Return Me.m_frmMRPShow
				End Get
				<DebuggerHidden()>
				Set(value As frmMRPShow)
					If value IsNot Me.m_frmMRPShow Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmMRPShow)(Me.m_frmMRPShow)
					End If
				End Set
			End Property

			' Token: 0x170000E4 RID: 228
			' (get) Token: 0x06000113 RID: 275 RVA: 0x000039B4 File Offset: 0x00001BB4
			' (set) Token: 0x0600029D RID: 669 RVA: 0x000070F0 File Offset: 0x000052F0
			Public Property frmMRPShow_Serial As frmMRPShow_Serial
				<DebuggerHidden()>
				Get
					Me.m_frmMRPShow_Serial = MyProject.MyForms.Create__Instance__(Of frmMRPShow_Serial)(Me.m_frmMRPShow_Serial)
					Return Me.m_frmMRPShow_Serial
				End Get
				<DebuggerHidden()>
				Set(value As frmMRPShow_Serial)
					If value IsNot Me.m_frmMRPShow_Serial Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmMRPShow_Serial)(Me.m_frmMRPShow_Serial)
					End If
				End Set
			End Property

			' Token: 0x170000E5 RID: 229
			' (get) Token: 0x06000114 RID: 276 RVA: 0x000039CF File Offset: 0x00001BCF
			' (set) Token: 0x0600029E RID: 670 RVA: 0x0000711C File Offset: 0x0000531C
			Public Property frmMultiBillPayment As frmMultiBillPayment
				<DebuggerHidden()>
				Get
					Me.m_frmMultiBillPayment = MyProject.MyForms.Create__Instance__(Of frmMultiBillPayment)(Me.m_frmMultiBillPayment)
					Return Me.m_frmMultiBillPayment
				End Get
				<DebuggerHidden()>
				Set(value As frmMultiBillPayment)
					If value IsNot Me.m_frmMultiBillPayment Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmMultiBillPayment)(Me.m_frmMultiBillPayment)
					End If
				End Set
			End Property

			' Token: 0x170000E6 RID: 230
			' (get) Token: 0x06000115 RID: 277 RVA: 0x000039EA File Offset: 0x00001BEA
			' (set) Token: 0x0600029F RID: 671 RVA: 0x00007148 File Offset: 0x00005348
			Public Property frmMultiBranchReport As frmMultiBranchReport
				<DebuggerHidden()>
				Get
					Me.m_frmMultiBranchReport = MyProject.MyForms.Create__Instance__(Of frmMultiBranchReport)(Me.m_frmMultiBranchReport)
					Return Me.m_frmMultiBranchReport
				End Get
				<DebuggerHidden()>
				Set(value As frmMultiBranchReport)
					If value IsNot Me.m_frmMultiBranchReport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmMultiBranchReport)(Me.m_frmMultiBranchReport)
					End If
				End Set
			End Property

			' Token: 0x170000E7 RID: 231
			' (get) Token: 0x06000116 RID: 278 RVA: 0x00003A05 File Offset: 0x00001C05
			' (set) Token: 0x060002A0 RID: 672 RVA: 0x00007174 File Offset: 0x00005374
			Public Property frmMultiPaymentModeSettings As frmMultiPaymentModeSettings
				<DebuggerHidden()>
				Get
					Me.m_frmMultiPaymentModeSettings = MyProject.MyForms.Create__Instance__(Of frmMultiPaymentModeSettings)(Me.m_frmMultiPaymentModeSettings)
					Return Me.m_frmMultiPaymentModeSettings
				End Get
				<DebuggerHidden()>
				Set(value As frmMultiPaymentModeSettings)
					If value IsNot Me.m_frmMultiPaymentModeSettings Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmMultiPaymentModeSettings)(Me.m_frmMultiPaymentModeSettings)
					End If
				End Set
			End Property

			' Token: 0x170000E8 RID: 232
			' (get) Token: 0x06000117 RID: 279 RVA: 0x00003A20 File Offset: 0x00001C20
			' (set) Token: 0x060002A1 RID: 673 RVA: 0x000071A0 File Offset: 0x000053A0
			Public Property frmOfferMessage As frmOfferMessage
				<DebuggerHidden()>
				Get
					Me.m_frmOfferMessage = MyProject.MyForms.Create__Instance__(Of frmOfferMessage)(Me.m_frmOfferMessage)
					Return Me.m_frmOfferMessage
				End Get
				<DebuggerHidden()>
				Set(value As frmOfferMessage)
					If value IsNot Me.m_frmOfferMessage Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmOfferMessage)(Me.m_frmOfferMessage)
					End If
				End Set
			End Property

			' Token: 0x170000E9 RID: 233
			' (get) Token: 0x06000118 RID: 280 RVA: 0x00003A3B File Offset: 0x00001C3B
			' (set) Token: 0x060002A2 RID: 674 RVA: 0x000071CC File Offset: 0x000053CC
			Public Property frmOnlineImage As frmOnlineImage
				<DebuggerHidden()>
				Get
					Me.m_frmOnlineImage = MyProject.MyForms.Create__Instance__(Of frmOnlineImage)(Me.m_frmOnlineImage)
					Return Me.m_frmOnlineImage
				End Get
				<DebuggerHidden()>
				Set(value As frmOnlineImage)
					If value IsNot Me.m_frmOnlineImage Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmOnlineImage)(Me.m_frmOnlineImage)
					End If
				End Set
			End Property

			' Token: 0x170000EA RID: 234
			' (get) Token: 0x06000119 RID: 281 RVA: 0x00003A56 File Offset: 0x00001C56
			' (set) Token: 0x060002A3 RID: 675 RVA: 0x000071F8 File Offset: 0x000053F8
			Public Property frmOrder As frmOrder
				<DebuggerHidden()>
				Get
					Me.m_frmOrder = MyProject.MyForms.Create__Instance__(Of frmOrder)(Me.m_frmOrder)
					Return Me.m_frmOrder
				End Get
				<DebuggerHidden()>
				Set(value As frmOrder)
					If value IsNot Me.m_frmOrder Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmOrder)(Me.m_frmOrder)
					End If
				End Set
			End Property

			' Token: 0x170000EB RID: 235
			' (get) Token: 0x0600011A RID: 282 RVA: 0x00003A71 File Offset: 0x00001C71
			' (set) Token: 0x060002A4 RID: 676 RVA: 0x00007224 File Offset: 0x00005424
			Public Property frmOtherSettings As frmOtherSettings
				<DebuggerHidden()>
				Get
					Me.m_frmOtherSettings = MyProject.MyForms.Create__Instance__(Of frmOtherSettings)(Me.m_frmOtherSettings)
					Return Me.m_frmOtherSettings
				End Get
				<DebuggerHidden()>
				Set(value As frmOtherSettings)
					If value IsNot Me.m_frmOtherSettings Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmOtherSettings)(Me.m_frmOtherSettings)
					End If
				End Set
			End Property

			' Token: 0x170000EC RID: 236
			' (get) Token: 0x0600011B RID: 283 RVA: 0x00003A8C File Offset: 0x00001C8C
			' (set) Token: 0x060002A5 RID: 677 RVA: 0x00007250 File Offset: 0x00005450
			Public Property frmPayment As frmPayment
				<DebuggerHidden()>
				Get
					Me.m_frmPayment = MyProject.MyForms.Create__Instance__(Of frmPayment)(Me.m_frmPayment)
					Return Me.m_frmPayment
				End Get
				<DebuggerHidden()>
				Set(value As frmPayment)
					If value IsNot Me.m_frmPayment Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPayment)(Me.m_frmPayment)
					End If
				End Set
			End Property

			' Token: 0x170000ED RID: 237
			' (get) Token: 0x0600011C RID: 284 RVA: 0x00003AA7 File Offset: 0x00001CA7
			' (set) Token: 0x060002A6 RID: 678 RVA: 0x0000727C File Offset: 0x0000547C
			Public Property frmPayment_Withdrawal As frmPayment_Withdrawal
				<DebuggerHidden()>
				Get
					Me.m_frmPayment_Withdrawal = MyProject.MyForms.Create__Instance__(Of frmPayment_Withdrawal)(Me.m_frmPayment_Withdrawal)
					Return Me.m_frmPayment_Withdrawal
				End Get
				<DebuggerHidden()>
				Set(value As frmPayment_Withdrawal)
					If value IsNot Me.m_frmPayment_Withdrawal Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPayment_Withdrawal)(Me.m_frmPayment_Withdrawal)
					End If
				End Set
			End Property

			' Token: 0x170000EE RID: 238
			' (get) Token: 0x0600011D RID: 285 RVA: 0x00003AC2 File Offset: 0x00001CC2
			' (set) Token: 0x060002A7 RID: 679 RVA: 0x000072A8 File Offset: 0x000054A8
			Public Property frmPaymentRecord As frmPaymentRecord
				<DebuggerHidden()>
				Get
					Me.m_frmPaymentRecord = MyProject.MyForms.Create__Instance__(Of frmPaymentRecord)(Me.m_frmPaymentRecord)
					Return Me.m_frmPaymentRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmPaymentRecord)
					If value IsNot Me.m_frmPaymentRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPaymentRecord)(Me.m_frmPaymentRecord)
					End If
				End Set
			End Property

			' Token: 0x170000EF RID: 239
			' (get) Token: 0x0600011E RID: 286 RVA: 0x00003ADD File Offset: 0x00001CDD
			' (set) Token: 0x060002A8 RID: 680 RVA: 0x000072D4 File Offset: 0x000054D4
			Public Property frmPdfReader As frmPdfReader
				<DebuggerHidden()>
				Get
					Me.m_frmPdfReader = MyProject.MyForms.Create__Instance__(Of frmPdfReader)(Me.m_frmPdfReader)
					Return Me.m_frmPdfReader
				End Get
				<DebuggerHidden()>
				Set(value As frmPdfReader)
					If value IsNot Me.m_frmPdfReader Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPdfReader)(Me.m_frmPdfReader)
					End If
				End Set
			End Property

			' Token: 0x170000F0 RID: 240
			' (get) Token: 0x0600011F RID: 287 RVA: 0x00003AF8 File Offset: 0x00001CF8
			' (set) Token: 0x060002A9 RID: 681 RVA: 0x00007300 File Offset: 0x00005500
			Public Property frmPhonePeUPI As frmPhonePeUPI
				<DebuggerHidden()>
				Get
					Me.m_frmPhonePeUPI = MyProject.MyForms.Create__Instance__(Of frmPhonePeUPI)(Me.m_frmPhonePeUPI)
					Return Me.m_frmPhonePeUPI
				End Get
				<DebuggerHidden()>
				Set(value As frmPhonePeUPI)
					If value IsNot Me.m_frmPhonePeUPI Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPhonePeUPI)(Me.m_frmPhonePeUPI)
					End If
				End Set
			End Property

			' Token: 0x170000F1 RID: 241
			' (get) Token: 0x06000120 RID: 288 RVA: 0x00003B13 File Offset: 0x00001D13
			' (set) Token: 0x060002AA RID: 682 RVA: 0x0000732C File Offset: 0x0000552C
			Public Property frmPOS As frmPOS
				<DebuggerHidden()>
				Get
					Me.m_frmPOS = MyProject.MyForms.Create__Instance__(Of frmPOS)(Me.m_frmPOS)
					Return Me.m_frmPOS
				End Get
				<DebuggerHidden()>
				Set(value As frmPOS)
					If value IsNot Me.m_frmPOS Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPOS)(Me.m_frmPOS)
					End If
				End Set
			End Property

			' Token: 0x170000F2 RID: 242
			' (get) Token: 0x06000121 RID: 289 RVA: 0x00003B2E File Offset: 0x00001D2E
			' (set) Token: 0x060002AB RID: 683 RVA: 0x00007358 File Offset: 0x00005558
			Public Property frmPos_Cursor_Setting As frmPos_Cursor_Setting
				<DebuggerHidden()>
				Get
					Me.m_frmPos_Cursor_Setting = MyProject.MyForms.Create__Instance__(Of frmPos_Cursor_Setting)(Me.m_frmPos_Cursor_Setting)
					Return Me.m_frmPos_Cursor_Setting
				End Get
				<DebuggerHidden()>
				Set(value As frmPos_Cursor_Setting)
					If value IsNot Me.m_frmPos_Cursor_Setting Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPos_Cursor_Setting)(Me.m_frmPos_Cursor_Setting)
					End If
				End Set
			End Property

			' Token: 0x170000F3 RID: 243
			' (get) Token: 0x06000122 RID: 290 RVA: 0x00003B49 File Offset: 0x00001D49
			' (set) Token: 0x060002AC RID: 684 RVA: 0x00007384 File Offset: 0x00005584
			Public Property frmPOS_Update As frmPOS_Update
				<DebuggerHidden()>
				Get
					Me.m_frmPOS_Update = MyProject.MyForms.Create__Instance__(Of frmPOS_Update)(Me.m_frmPOS_Update)
					Return Me.m_frmPOS_Update
				End Get
				<DebuggerHidden()>
				Set(value As frmPOS_Update)
					If value IsNot Me.m_frmPOS_Update Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPOS_Update)(Me.m_frmPOS_Update)
					End If
				End Set
			End Property

			' Token: 0x170000F4 RID: 244
			' (get) Token: 0x06000123 RID: 291 RVA: 0x00003B64 File Offset: 0x00001D64
			' (set) Token: 0x060002AD RID: 685 RVA: 0x000073B0 File Offset: 0x000055B0
			Public Property frmPOSNew As frmPOSNew
				<DebuggerHidden()>
				Get
					Me.m_frmPOSNew = MyProject.MyForms.Create__Instance__(Of frmPOSNew)(Me.m_frmPOSNew)
					Return Me.m_frmPOSNew
				End Get
				<DebuggerHidden()>
				Set(value As frmPOSNew)
					If value IsNot Me.m_frmPOSNew Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPOSNew)(Me.m_frmPOSNew)
					End If
				End Set
			End Property

			' Token: 0x170000F5 RID: 245
			' (get) Token: 0x06000124 RID: 292 RVA: 0x00003B7F File Offset: 0x00001D7F
			' (set) Token: 0x060002AE RID: 686 RVA: 0x000073DC File Offset: 0x000055DC
			Public Property frmPOSNewTuch As frmPOSNewTuch
				<DebuggerHidden()>
				Get
					Me.m_frmPOSNewTuch = MyProject.MyForms.Create__Instance__(Of frmPOSNewTuch)(Me.m_frmPOSNewTuch)
					Return Me.m_frmPOSNewTuch
				End Get
				<DebuggerHidden()>
				Set(value As frmPOSNewTuch)
					If value IsNot Me.m_frmPOSNewTuch Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPOSNewTuch)(Me.m_frmPOSNewTuch)
					End If
				End Set
			End Property

			' Token: 0x170000F6 RID: 246
			' (get) Token: 0x06000125 RID: 293 RVA: 0x00003B9A File Offset: 0x00001D9A
			' (set) Token: 0x060002AF RID: 687 RVA: 0x00007408 File Offset: 0x00005608
			Public Property frmPOSNewTuch_Quotation As frmPOSNewTuch_Quotation
				<DebuggerHidden()>
				Get
					Me.m_frmPOSNewTuch_Quotation = MyProject.MyForms.Create__Instance__(Of frmPOSNewTuch_Quotation)(Me.m_frmPOSNewTuch_Quotation)
					Return Me.m_frmPOSNewTuch_Quotation
				End Get
				<DebuggerHidden()>
				Set(value As frmPOSNewTuch_Quotation)
					If value IsNot Me.m_frmPOSNewTuch_Quotation Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPOSNewTuch_Quotation)(Me.m_frmPOSNewTuch_Quotation)
					End If
				End Set
			End Property

			' Token: 0x170000F7 RID: 247
			' (get) Token: 0x06000126 RID: 294 RVA: 0x00003BB5 File Offset: 0x00001DB5
			' (set) Token: 0x060002B0 RID: 688 RVA: 0x00007434 File Offset: 0x00005634
			Public Property frmPOSNewTuch_QuotationRecord As frmPOSNewTuch_QuotationRecord
				<DebuggerHidden()>
				Get
					Me.m_frmPOSNewTuch_QuotationRecord = MyProject.MyForms.Create__Instance__(Of frmPOSNewTuch_QuotationRecord)(Me.m_frmPOSNewTuch_QuotationRecord)
					Return Me.m_frmPOSNewTuch_QuotationRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmPOSNewTuch_QuotationRecord)
					If value IsNot Me.m_frmPOSNewTuch_QuotationRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPOSNewTuch_QuotationRecord)(Me.m_frmPOSNewTuch_QuotationRecord)
					End If
				End Set
			End Property

			' Token: 0x170000F8 RID: 248
			' (get) Token: 0x06000127 RID: 295 RVA: 0x00003BD0 File Offset: 0x00001DD0
			' (set) Token: 0x060002B1 RID: 689 RVA: 0x00007460 File Offset: 0x00005660
			Public Property frmPOSNewTuch_Service As frmPOSNewTuch_Service
				<DebuggerHidden()>
				Get
					Me.m_frmPOSNewTuch_Service = MyProject.MyForms.Create__Instance__(Of frmPOSNewTuch_Service)(Me.m_frmPOSNewTuch_Service)
					Return Me.m_frmPOSNewTuch_Service
				End Get
				<DebuggerHidden()>
				Set(value As frmPOSNewTuch_Service)
					If value IsNot Me.m_frmPOSNewTuch_Service Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPOSNewTuch_Service)(Me.m_frmPOSNewTuch_Service)
					End If
				End Set
			End Property

			' Token: 0x170000F9 RID: 249
			' (get) Token: 0x06000128 RID: 296 RVA: 0x00003BEB File Offset: 0x00001DEB
			' (set) Token: 0x060002B2 RID: 690 RVA: 0x0000748C File Offset: 0x0000568C
			Public Property frmPOSNewTuch_StockInward As frmPOSNewTuch_StockInward
				<DebuggerHidden()>
				Get
					Me.m_frmPOSNewTuch_StockInward = MyProject.MyForms.Create__Instance__(Of frmPOSNewTuch_StockInward)(Me.m_frmPOSNewTuch_StockInward)
					Return Me.m_frmPOSNewTuch_StockInward
				End Get
				<DebuggerHidden()>
				Set(value As frmPOSNewTuch_StockInward)
					If value IsNot Me.m_frmPOSNewTuch_StockInward Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPOSNewTuch_StockInward)(Me.m_frmPOSNewTuch_StockInward)
					End If
				End Set
			End Property

			' Token: 0x170000FA RID: 250
			' (get) Token: 0x06000129 RID: 297 RVA: 0x00003C06 File Offset: 0x00001E06
			' (set) Token: 0x060002B3 RID: 691 RVA: 0x000074B8 File Offset: 0x000056B8
			Public Property frmPOSNewTuch_StockTransfer As frmPOSNewTuch_StockTransfer
				<DebuggerHidden()>
				Get
					Me.m_frmPOSNewTuch_StockTransfer = MyProject.MyForms.Create__Instance__(Of frmPOSNewTuch_StockTransfer)(Me.m_frmPOSNewTuch_StockTransfer)
					Return Me.m_frmPOSNewTuch_StockTransfer
				End Get
				<DebuggerHidden()>
				Set(value As frmPOSNewTuch_StockTransfer)
					If value IsNot Me.m_frmPOSNewTuch_StockTransfer Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPOSNewTuch_StockTransfer)(Me.m_frmPOSNewTuch_StockTransfer)
					End If
				End Set
			End Property

			' Token: 0x170000FB RID: 251
			' (get) Token: 0x0600012A RID: 298 RVA: 0x00003C21 File Offset: 0x00001E21
			' (set) Token: 0x060002B4 RID: 692 RVA: 0x000074E4 File Offset: 0x000056E4
			Public Property frmPostImport As frmPostImport
				<DebuggerHidden()>
				Get
					Me.m_frmPostImport = MyProject.MyForms.Create__Instance__(Of frmPostImport)(Me.m_frmPostImport)
					Return Me.m_frmPostImport
				End Get
				<DebuggerHidden()>
				Set(value As frmPostImport)
					If value IsNot Me.m_frmPostImport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPostImport)(Me.m_frmPostImport)
					End If
				End Set
			End Property

			' Token: 0x170000FC RID: 252
			' (get) Token: 0x0600012B RID: 299 RVA: 0x00003C3C File Offset: 0x00001E3C
			' (set) Token: 0x060002B5 RID: 693 RVA: 0x00007510 File Offset: 0x00005710
			Public Property frmPOSTouch As frmPOSTouch
				<DebuggerHidden()>
				Get
					Me.m_frmPOSTouch = MyProject.MyForms.Create__Instance__(Of frmPOSTouch)(Me.m_frmPOSTouch)
					Return Me.m_frmPOSTouch
				End Get
				<DebuggerHidden()>
				Set(value As frmPOSTouch)
					If value IsNot Me.m_frmPOSTouch Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPOSTouch)(Me.m_frmPOSTouch)
					End If
				End Set
			End Property

			' Token: 0x170000FD RID: 253
			' (get) Token: 0x0600012C RID: 300 RVA: 0x00003C57 File Offset: 0x00001E57
			' (set) Token: 0x060002B6 RID: 694 RVA: 0x0000753C File Offset: 0x0000573C
			Public Property frmPrevSales As frmPrevSales
				<DebuggerHidden()>
				Get
					Me.m_frmPrevSales = MyProject.MyForms.Create__Instance__(Of frmPrevSales)(Me.m_frmPrevSales)
					Return Me.m_frmPrevSales
				End Get
				<DebuggerHidden()>
				Set(value As frmPrevSales)
					If value IsNot Me.m_frmPrevSales Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPrevSales)(Me.m_frmPrevSales)
					End If
				End Set
			End Property

			' Token: 0x170000FE RID: 254
			' (get) Token: 0x0600012D RID: 301 RVA: 0x00003C72 File Offset: 0x00001E72
			' (set) Token: 0x060002B7 RID: 695 RVA: 0x00007568 File Offset: 0x00005768
			Public Property frmPrinterSettings As frmPrinterSettings
				<DebuggerHidden()>
				Get
					Me.m_frmPrinterSettings = MyProject.MyForms.Create__Instance__(Of frmPrinterSettings)(Me.m_frmPrinterSettings)
					Return Me.m_frmPrinterSettings
				End Get
				<DebuggerHidden()>
				Set(value As frmPrinterSettings)
					If value IsNot Me.m_frmPrinterSettings Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPrinterSettings)(Me.m_frmPrinterSettings)
					End If
				End Set
			End Property

			' Token: 0x170000FF RID: 255
			' (get) Token: 0x0600012E RID: 302 RVA: 0x00003C8D File Offset: 0x00001E8D
			' (set) Token: 0x060002B8 RID: 696 RVA: 0x00007594 File Offset: 0x00005794
			Public Property frmPrintLoyaltyCard As frmPrintLoyaltyCard
				<DebuggerHidden()>
				Get
					Me.m_frmPrintLoyaltyCard = MyProject.MyForms.Create__Instance__(Of frmPrintLoyaltyCard)(Me.m_frmPrintLoyaltyCard)
					Return Me.m_frmPrintLoyaltyCard
				End Get
				<DebuggerHidden()>
				Set(value As frmPrintLoyaltyCard)
					If value IsNot Me.m_frmPrintLoyaltyCard Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPrintLoyaltyCard)(Me.m_frmPrintLoyaltyCard)
					End If
				End Set
			End Property

			' Token: 0x17000100 RID: 256
			' (get) Token: 0x0600012F RID: 303 RVA: 0x00003CA8 File Offset: 0x00001EA8
			' (set) Token: 0x060002B9 RID: 697 RVA: 0x000075C0 File Offset: 0x000057C0
			Public Property frmProduct As frmProduct
				<DebuggerHidden()>
				Get
					Me.m_frmProduct = MyProject.MyForms.Create__Instance__(Of frmProduct)(Me.m_frmProduct)
					Return Me.m_frmProduct
				End Get
				<DebuggerHidden()>
				Set(value As frmProduct)
					If value IsNot Me.m_frmProduct Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProduct)(Me.m_frmProduct)
					End If
				End Set
			End Property

			' Token: 0x17000101 RID: 257
			' (get) Token: 0x06000130 RID: 304 RVA: 0x00003CC3 File Offset: 0x00001EC3
			' (set) Token: 0x060002BA RID: 698 RVA: 0x000075EC File Offset: 0x000057EC
			Public Property frmProductBulkUpdate As frmProductBulkUpdate
				<DebuggerHidden()>
				Get
					Me.m_frmProductBulkUpdate = MyProject.MyForms.Create__Instance__(Of frmProductBulkUpdate)(Me.m_frmProductBulkUpdate)
					Return Me.m_frmProductBulkUpdate
				End Get
				<DebuggerHidden()>
				Set(value As frmProductBulkUpdate)
					If value IsNot Me.m_frmProductBulkUpdate Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProductBulkUpdate)(Me.m_frmProductBulkUpdate)
					End If
				End Set
			End Property

			' Token: 0x17000102 RID: 258
			' (get) Token: 0x06000131 RID: 305 RVA: 0x00003CDE File Offset: 0x00001EDE
			' (set) Token: 0x060002BB RID: 699 RVA: 0x00007618 File Offset: 0x00005818
			Public Property frmProductBulkUpdate_GST As frmProductBulkUpdate_GST
				<DebuggerHidden()>
				Get
					Me.m_frmProductBulkUpdate_GST = MyProject.MyForms.Create__Instance__(Of frmProductBulkUpdate_GST)(Me.m_frmProductBulkUpdate_GST)
					Return Me.m_frmProductBulkUpdate_GST
				End Get
				<DebuggerHidden()>
				Set(value As frmProductBulkUpdate_GST)
					If value IsNot Me.m_frmProductBulkUpdate_GST Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProductBulkUpdate_GST)(Me.m_frmProductBulkUpdate_GST)
					End If
				End Set
			End Property

			' Token: 0x17000103 RID: 259
			' (get) Token: 0x06000132 RID: 306 RVA: 0x00003CF9 File Offset: 0x00001EF9
			' (set) Token: 0x060002BC RID: 700 RVA: 0x00007644 File Offset: 0x00005844
			Public Property frmProductDefault As frmProductDefault
				<DebuggerHidden()>
				Get
					Me.m_frmProductDefault = MyProject.MyForms.Create__Instance__(Of frmProductDefault)(Me.m_frmProductDefault)
					Return Me.m_frmProductDefault
				End Get
				<DebuggerHidden()>
				Set(value As frmProductDefault)
					If value IsNot Me.m_frmProductDefault Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProductDefault)(Me.m_frmProductDefault)
					End If
				End Set
			End Property

			' Token: 0x17000104 RID: 260
			' (get) Token: 0x06000133 RID: 307 RVA: 0x00003D14 File Offset: 0x00001F14
			' (set) Token: 0x060002BD RID: 701 RVA: 0x00007670 File Offset: 0x00005870
			Public Property frmProductDiscount As frmProductDiscount
				<DebuggerHidden()>
				Get
					Me.m_frmProductDiscount = MyProject.MyForms.Create__Instance__(Of frmProductDiscount)(Me.m_frmProductDiscount)
					Return Me.m_frmProductDiscount
				End Get
				<DebuggerHidden()>
				Set(value As frmProductDiscount)
					If value IsNot Me.m_frmProductDiscount Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProductDiscount)(Me.m_frmProductDiscount)
					End If
				End Set
			End Property

			' Token: 0x17000105 RID: 261
			' (get) Token: 0x06000134 RID: 308 RVA: 0x00003D2F File Offset: 0x00001F2F
			' (set) Token: 0x060002BE RID: 702 RVA: 0x0000769C File Offset: 0x0000589C
			Public Property frmProductEntry As frmProductEntry
				<DebuggerHidden()>
				Get
					Me.m_frmProductEntry = MyProject.MyForms.Create__Instance__(Of frmProductEntry)(Me.m_frmProductEntry)
					Return Me.m_frmProductEntry
				End Get
				<DebuggerHidden()>
				Set(value As frmProductEntry)
					If value IsNot Me.m_frmProductEntry Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProductEntry)(Me.m_frmProductEntry)
					End If
				End Set
			End Property

			' Token: 0x17000106 RID: 262
			' (get) Token: 0x06000135 RID: 309 RVA: 0x00003D4A File Offset: 0x00001F4A
			' (set) Token: 0x060002BF RID: 703 RVA: 0x000076C8 File Offset: 0x000058C8
			Public Property frmProductImageMaker As frmProductImageMaker
				<DebuggerHidden()>
				Get
					Me.m_frmProductImageMaker = MyProject.MyForms.Create__Instance__(Of frmProductImageMaker)(Me.m_frmProductImageMaker)
					Return Me.m_frmProductImageMaker
				End Get
				<DebuggerHidden()>
				Set(value As frmProductImageMaker)
					If value IsNot Me.m_frmProductImageMaker Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProductImageMaker)(Me.m_frmProductImageMaker)
					End If
				End Set
			End Property

			' Token: 0x17000107 RID: 263
			' (get) Token: 0x06000136 RID: 310 RVA: 0x00003D65 File Offset: 0x00001F65
			' (set) Token: 0x060002C0 RID: 704 RVA: 0x000076F4 File Offset: 0x000058F4
			Public Property frmProductImageUpdator As frmProductImageUpdator
				<DebuggerHidden()>
				Get
					Me.m_frmProductImageUpdator = MyProject.MyForms.Create__Instance__(Of frmProductImageUpdator)(Me.m_frmProductImageUpdator)
					Return Me.m_frmProductImageUpdator
				End Get
				<DebuggerHidden()>
				Set(value As frmProductImageUpdator)
					If value IsNot Me.m_frmProductImageUpdator Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProductImageUpdator)(Me.m_frmProductImageUpdator)
					End If
				End Set
			End Property

			' Token: 0x17000108 RID: 264
			' (get) Token: 0x06000137 RID: 311 RVA: 0x00003D80 File Offset: 0x00001F80
			' (set) Token: 0x060002C1 RID: 705 RVA: 0x00007720 File Offset: 0x00005920
			Public Property frmProductLedgerPOS As frmProductLedgerPOS
				<DebuggerHidden()>
				Get
					Me.m_frmProductLedgerPOS = MyProject.MyForms.Create__Instance__(Of frmProductLedgerPOS)(Me.m_frmProductLedgerPOS)
					Return Me.m_frmProductLedgerPOS
				End Get
				<DebuggerHidden()>
				Set(value As frmProductLedgerPOS)
					If value IsNot Me.m_frmProductLedgerPOS Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProductLedgerPOS)(Me.m_frmProductLedgerPOS)
					End If
				End Set
			End Property

			' Token: 0x17000109 RID: 265
			' (get) Token: 0x06000138 RID: 312 RVA: 0x00003D9B File Offset: 0x00001F9B
			' (set) Token: 0x060002C2 RID: 706 RVA: 0x0000774C File Offset: 0x0000594C
			Public Property frmProductListWeigh As frmProductListWeigh
				<DebuggerHidden()>
				Get
					Me.m_frmProductListWeigh = MyProject.MyForms.Create__Instance__(Of frmProductListWeigh)(Me.m_frmProductListWeigh)
					Return Me.m_frmProductListWeigh
				End Get
				<DebuggerHidden()>
				Set(value As frmProductListWeigh)
					If value IsNot Me.m_frmProductListWeigh Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProductListWeigh)(Me.m_frmProductListWeigh)
					End If
				End Set
			End Property

			' Token: 0x1700010A RID: 266
			' (get) Token: 0x06000139 RID: 313 RVA: 0x00003DB6 File Offset: 0x00001FB6
			' (set) Token: 0x060002C3 RID: 707 RVA: 0x00007778 File Offset: 0x00005978
			Public Property frmProductNew As frmProductNew
				<DebuggerHidden()>
				Get
					Me.m_frmProductNew = MyProject.MyForms.Create__Instance__(Of frmProductNew)(Me.m_frmProductNew)
					Return Me.m_frmProductNew
				End Get
				<DebuggerHidden()>
				Set(value As frmProductNew)
					If value IsNot Me.m_frmProductNew Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProductNew)(Me.m_frmProductNew)
					End If
				End Set
			End Property

			' Token: 0x1700010B RID: 267
			' (get) Token: 0x0600013A RID: 314 RVA: 0x00003DD1 File Offset: 0x00001FD1
			' (set) Token: 0x060002C4 RID: 708 RVA: 0x000077A4 File Offset: 0x000059A4
			Public Property frmProductPlus As frmProductPlus
				<DebuggerHidden()>
				Get
					Me.m_frmProductPlus = MyProject.MyForms.Create__Instance__(Of frmProductPlus)(Me.m_frmProductPlus)
					Return Me.m_frmProductPlus
				End Get
				<DebuggerHidden()>
				Set(value As frmProductPlus)
					If value IsNot Me.m_frmProductPlus Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProductPlus)(Me.m_frmProductPlus)
					End If
				End Set
			End Property

			' Token: 0x1700010C RID: 268
			' (get) Token: 0x0600013B RID: 315 RVA: 0x00003DEC File Offset: 0x00001FEC
			' (set) Token: 0x060002C5 RID: 709 RVA: 0x000077D0 File Offset: 0x000059D0
			Public Property frmProductRec As frmProductRec
				<DebuggerHidden()>
				Get
					Me.m_frmProductRec = MyProject.MyForms.Create__Instance__(Of frmProductRec)(Me.m_frmProductRec)
					Return Me.m_frmProductRec
				End Get
				<DebuggerHidden()>
				Set(value As frmProductRec)
					If value IsNot Me.m_frmProductRec Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProductRec)(Me.m_frmProductRec)
					End If
				End Set
			End Property

			' Token: 0x1700010D RID: 269
			' (get) Token: 0x0600013C RID: 316 RVA: 0x00003E07 File Offset: 0x00002007
			' (set) Token: 0x060002C6 RID: 710 RVA: 0x000077FC File Offset: 0x000059FC
			Public Property frmProductRec1 As frmProductRec1
				<DebuggerHidden()>
				Get
					Me.m_frmProductRec1 = MyProject.MyForms.Create__Instance__(Of frmProductRec1)(Me.m_frmProductRec1)
					Return Me.m_frmProductRec1
				End Get
				<DebuggerHidden()>
				Set(value As frmProductRec1)
					If value IsNot Me.m_frmProductRec1 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProductRec1)(Me.m_frmProductRec1)
					End If
				End Set
			End Property

			' Token: 0x1700010E RID: 270
			' (get) Token: 0x0600013D RID: 317 RVA: 0x00003E22 File Offset: 0x00002022
			' (set) Token: 0x060002C7 RID: 711 RVA: 0x00007828 File Offset: 0x00005A28
			Public Property frmProductRec_serial As frmProductRec_serial
				<DebuggerHidden()>
				Get
					Me.m_frmProductRec_serial = MyProject.MyForms.Create__Instance__(Of frmProductRec_serial)(Me.m_frmProductRec_serial)
					Return Me.m_frmProductRec_serial
				End Get
				<DebuggerHidden()>
				Set(value As frmProductRec_serial)
					If value IsNot Me.m_frmProductRec_serial Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProductRec_serial)(Me.m_frmProductRec_serial)
					End If
				End Set
			End Property

			' Token: 0x1700010F RID: 271
			' (get) Token: 0x0600013E RID: 318 RVA: 0x00003E3D File Offset: 0x0000203D
			' (set) Token: 0x060002C8 RID: 712 RVA: 0x00007854 File Offset: 0x00005A54
			Public Property frmProductRec_serial_sale As frmProductRec_serial_sale
				<DebuggerHidden()>
				Get
					Me.m_frmProductRec_serial_sale = MyProject.MyForms.Create__Instance__(Of frmProductRec_serial_sale)(Me.m_frmProductRec_serial_sale)
					Return Me.m_frmProductRec_serial_sale
				End Get
				<DebuggerHidden()>
				Set(value As frmProductRec_serial_sale)
					If value IsNot Me.m_frmProductRec_serial_sale Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProductRec_serial_sale)(Me.m_frmProductRec_serial_sale)
					End If
				End Set
			End Property

			' Token: 0x17000110 RID: 272
			' (get) Token: 0x0600013F RID: 319 RVA: 0x00003E58 File Offset: 0x00002058
			' (set) Token: 0x060002C9 RID: 713 RVA: 0x00007880 File Offset: 0x00005A80
			Public Property frmProductRec_variant As frmProductRec_variant
				<DebuggerHidden()>
				Get
					Me.m_frmProductRec_variant = MyProject.MyForms.Create__Instance__(Of frmProductRec_variant)(Me.m_frmProductRec_variant)
					Return Me.m_frmProductRec_variant
				End Get
				<DebuggerHidden()>
				Set(value As frmProductRec_variant)
					If value IsNot Me.m_frmProductRec_variant Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProductRec_variant)(Me.m_frmProductRec_variant)
					End If
				End Set
			End Property

			' Token: 0x17000111 RID: 273
			' (get) Token: 0x06000140 RID: 320 RVA: 0x00003E73 File Offset: 0x00002073
			' (set) Token: 0x060002CA RID: 714 RVA: 0x000078AC File Offset: 0x00005AAC
			Public Property frmProductRecord As frmProductRecord
				<DebuggerHidden()>
				Get
					Me.m_frmProductRecord = MyProject.MyForms.Create__Instance__(Of frmProductRecord)(Me.m_frmProductRecord)
					Return Me.m_frmProductRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmProductRecord)
					If value IsNot Me.m_frmProductRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProductRecord)(Me.m_frmProductRecord)
					End If
				End Set
			End Property

			' Token: 0x17000112 RID: 274
			' (get) Token: 0x06000141 RID: 321 RVA: 0x00003E8E File Offset: 0x0000208E
			' (set) Token: 0x060002CB RID: 715 RVA: 0x000078D8 File Offset: 0x00005AD8
			Public Property frmProductSeting As frmProductSeting
				<DebuggerHidden()>
				Get
					Me.m_frmProductSeting = MyProject.MyForms.Create__Instance__(Of frmProductSeting)(Me.m_frmProductSeting)
					Return Me.m_frmProductSeting
				End Get
				<DebuggerHidden()>
				Set(value As frmProductSeting)
					If value IsNot Me.m_frmProductSeting Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProductSeting)(Me.m_frmProductSeting)
					End If
				End Set
			End Property

			' Token: 0x17000113 RID: 275
			' (get) Token: 0x06000142 RID: 322 RVA: 0x00003EA9 File Offset: 0x000020A9
			' (set) Token: 0x060002CC RID: 716 RVA: 0x00007904 File Offset: 0x00005B04
			Public Property frmProductSmart As frmProductSmart
				<DebuggerHidden()>
				Get
					Me.m_frmProductSmart = MyProject.MyForms.Create__Instance__(Of frmProductSmart)(Me.m_frmProductSmart)
					Return Me.m_frmProductSmart
				End Get
				<DebuggerHidden()>
				Set(value As frmProductSmart)
					If value IsNot Me.m_frmProductSmart Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProductSmart)(Me.m_frmProductSmart)
					End If
				End Set
			End Property

			' Token: 0x17000114 RID: 276
			' (get) Token: 0x06000143 RID: 323 RVA: 0x00003EC4 File Offset: 0x000020C4
			' (set) Token: 0x060002CD RID: 717 RVA: 0x00007930 File Offset: 0x00005B30
			Public Property frmProfitloss As frmProfitloss
				<DebuggerHidden()>
				Get
					Me.m_frmProfitloss = MyProject.MyForms.Create__Instance__(Of frmProfitloss)(Me.m_frmProfitloss)
					Return Me.m_frmProfitloss
				End Get
				<DebuggerHidden()>
				Set(value As frmProfitloss)
					If value IsNot Me.m_frmProfitloss Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmProfitloss)(Me.m_frmProfitloss)
					End If
				End Set
			End Property

			' Token: 0x17000115 RID: 277
			' (get) Token: 0x06000144 RID: 324 RVA: 0x00003EDF File Offset: 0x000020DF
			' (set) Token: 0x060002CE RID: 718 RVA: 0x0000795C File Offset: 0x00005B5C
			Public Property frmPromotionalOffers As frmPromotionalOffers
				<DebuggerHidden()>
				Get
					Me.m_frmPromotionalOffers = MyProject.MyForms.Create__Instance__(Of frmPromotionalOffers)(Me.m_frmPromotionalOffers)
					Return Me.m_frmPromotionalOffers
				End Get
				<DebuggerHidden()>
				Set(value As frmPromotionalOffers)
					If value IsNot Me.m_frmPromotionalOffers Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPromotionalOffers)(Me.m_frmPromotionalOffers)
					End If
				End Set
			End Property

			' Token: 0x17000116 RID: 278
			' (get) Token: 0x06000145 RID: 325 RVA: 0x00003EFA File Offset: 0x000020FA
			' (set) Token: 0x060002CF RID: 719 RVA: 0x00007988 File Offset: 0x00005B88
			Public Property frmPurchaseEntry As frmPurchaseEntry
				<DebuggerHidden()>
				Get
					Me.m_frmPurchaseEntry = MyProject.MyForms.Create__Instance__(Of frmPurchaseEntry)(Me.m_frmPurchaseEntry)
					Return Me.m_frmPurchaseEntry
				End Get
				<DebuggerHidden()>
				Set(value As frmPurchaseEntry)
					If value IsNot Me.m_frmPurchaseEntry Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPurchaseEntry)(Me.m_frmPurchaseEntry)
					End If
				End Set
			End Property

			' Token: 0x17000117 RID: 279
			' (get) Token: 0x06000146 RID: 326 RVA: 0x00003F15 File Offset: 0x00002115
			' (set) Token: 0x060002D0 RID: 720 RVA: 0x000079B4 File Offset: 0x00005BB4
			Public Property frmPurchaseOrder As frmPurchaseOrder
				<DebuggerHidden()>
				Get
					Me.m_frmPurchaseOrder = MyProject.MyForms.Create__Instance__(Of frmPurchaseOrder)(Me.m_frmPurchaseOrder)
					Return Me.m_frmPurchaseOrder
				End Get
				<DebuggerHidden()>
				Set(value As frmPurchaseOrder)
					If value IsNot Me.m_frmPurchaseOrder Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPurchaseOrder)(Me.m_frmPurchaseOrder)
					End If
				End Set
			End Property

			' Token: 0x17000118 RID: 280
			' (get) Token: 0x06000147 RID: 327 RVA: 0x00003F30 File Offset: 0x00002130
			' (set) Token: 0x060002D1 RID: 721 RVA: 0x000079E0 File Offset: 0x00005BE0
			Public Property frmPurchaseOrderRecord As frmPurchaseOrderRecord
				<DebuggerHidden()>
				Get
					Me.m_frmPurchaseOrderRecord = MyProject.MyForms.Create__Instance__(Of frmPurchaseOrderRecord)(Me.m_frmPurchaseOrderRecord)
					Return Me.m_frmPurchaseOrderRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmPurchaseOrderRecord)
					If value IsNot Me.m_frmPurchaseOrderRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPurchaseOrderRecord)(Me.m_frmPurchaseOrderRecord)
					End If
				End Set
			End Property

			' Token: 0x17000119 RID: 281
			' (get) Token: 0x06000148 RID: 328 RVA: 0x00003F4B File Offset: 0x0000214B
			' (set) Token: 0x060002D2 RID: 722 RVA: 0x00007A0C File Offset: 0x00005C0C
			Public Property frmPurchaseRecord As frmPurchaseRecord
				<DebuggerHidden()>
				Get
					Me.m_frmPurchaseRecord = MyProject.MyForms.Create__Instance__(Of frmPurchaseRecord)(Me.m_frmPurchaseRecord)
					Return Me.m_frmPurchaseRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmPurchaseRecord)
					If value IsNot Me.m_frmPurchaseRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPurchaseRecord)(Me.m_frmPurchaseRecord)
					End If
				End Set
			End Property

			' Token: 0x1700011A RID: 282
			' (get) Token: 0x06000149 RID: 329 RVA: 0x00003F66 File Offset: 0x00002166
			' (set) Token: 0x060002D3 RID: 723 RVA: 0x00007A38 File Offset: 0x00005C38
			Public Property frmPurchaseRecord_GSTR As frmPurchaseRecord_GSTR
				<DebuggerHidden()>
				Get
					Me.m_frmPurchaseRecord_GSTR = MyProject.MyForms.Create__Instance__(Of frmPurchaseRecord_GSTR)(Me.m_frmPurchaseRecord_GSTR)
					Return Me.m_frmPurchaseRecord_GSTR
				End Get
				<DebuggerHidden()>
				Set(value As frmPurchaseRecord_GSTR)
					If value IsNot Me.m_frmPurchaseRecord_GSTR Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPurchaseRecord_GSTR)(Me.m_frmPurchaseRecord_GSTR)
					End If
				End Set
			End Property

			' Token: 0x1700011B RID: 283
			' (get) Token: 0x0600014A RID: 330 RVA: 0x00003F81 File Offset: 0x00002181
			' (set) Token: 0x060002D4 RID: 724 RVA: 0x00007A64 File Offset: 0x00005C64
			Public Property frmPurchaseReport As frmPurchaseReport
				<DebuggerHidden()>
				Get
					Me.m_frmPurchaseReport = MyProject.MyForms.Create__Instance__(Of frmPurchaseReport)(Me.m_frmPurchaseReport)
					Return Me.m_frmPurchaseReport
				End Get
				<DebuggerHidden()>
				Set(value As frmPurchaseReport)
					If value IsNot Me.m_frmPurchaseReport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPurchaseReport)(Me.m_frmPurchaseReport)
					End If
				End Set
			End Property

			' Token: 0x1700011C RID: 284
			' (get) Token: 0x0600014B RID: 331 RVA: 0x00003F9C File Offset: 0x0000219C
			' (set) Token: 0x060002D5 RID: 725 RVA: 0x00007A90 File Offset: 0x00005C90
			Public Property frmPurchaseReturn As frmPurchaseReturn
				<DebuggerHidden()>
				Get
					Me.m_frmPurchaseReturn = MyProject.MyForms.Create__Instance__(Of frmPurchaseReturn)(Me.m_frmPurchaseReturn)
					Return Me.m_frmPurchaseReturn
				End Get
				<DebuggerHidden()>
				Set(value As frmPurchaseReturn)
					If value IsNot Me.m_frmPurchaseReturn Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPurchaseReturn)(Me.m_frmPurchaseReturn)
					End If
				End Set
			End Property

			' Token: 0x1700011D RID: 285
			' (get) Token: 0x0600014C RID: 332 RVA: 0x00003FB7 File Offset: 0x000021B7
			' (set) Token: 0x060002D6 RID: 726 RVA: 0x00007ABC File Offset: 0x00005CBC
			Public Property frmPurchaseReturnRecord As frmPurchaseReturnRecord
				<DebuggerHidden()>
				Get
					Me.m_frmPurchaseReturnRecord = MyProject.MyForms.Create__Instance__(Of frmPurchaseReturnRecord)(Me.m_frmPurchaseReturnRecord)
					Return Me.m_frmPurchaseReturnRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmPurchaseReturnRecord)
					If value IsNot Me.m_frmPurchaseReturnRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPurchaseReturnRecord)(Me.m_frmPurchaseReturnRecord)
					End If
				End Set
			End Property

			' Token: 0x1700011E RID: 286
			' (get) Token: 0x0600014D RID: 333 RVA: 0x00003FD2 File Offset: 0x000021D2
			' (set) Token: 0x060002D7 RID: 727 RVA: 0x00007AE8 File Offset: 0x00005CE8
			Public Property frmPurchaseReturnRecord_GSTR As frmPurchaseReturnRecord_GSTR
				<DebuggerHidden()>
				Get
					Me.m_frmPurchaseReturnRecord_GSTR = MyProject.MyForms.Create__Instance__(Of frmPurchaseReturnRecord_GSTR)(Me.m_frmPurchaseReturnRecord_GSTR)
					Return Me.m_frmPurchaseReturnRecord_GSTR
				End Get
				<DebuggerHidden()>
				Set(value As frmPurchaseReturnRecord_GSTR)
					If value IsNot Me.m_frmPurchaseReturnRecord_GSTR Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPurchaseReturnRecord_GSTR)(Me.m_frmPurchaseReturnRecord_GSTR)
					End If
				End Set
			End Property

			' Token: 0x1700011F RID: 287
			' (get) Token: 0x0600014E RID: 334 RVA: 0x00003FED File Offset: 0x000021ED
			' (set) Token: 0x060002D8 RID: 728 RVA: 0x00007B14 File Offset: 0x00005D14
			Public Property frmPurchaseStock As frmPurchaseStock
				<DebuggerHidden()>
				Get
					Me.m_frmPurchaseStock = MyProject.MyForms.Create__Instance__(Of frmPurchaseStock)(Me.m_frmPurchaseStock)
					Return Me.m_frmPurchaseStock
				End Get
				<DebuggerHidden()>
				Set(value As frmPurchaseStock)
					If value IsNot Me.m_frmPurchaseStock Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPurchaseStock)(Me.m_frmPurchaseStock)
					End If
				End Set
			End Property

			' Token: 0x17000120 RID: 288
			' (get) Token: 0x0600014F RID: 335 RVA: 0x00004008 File Offset: 0x00002208
			' (set) Token: 0x060002D9 RID: 729 RVA: 0x00007B40 File Offset: 0x00005D40
			Public Property frmPurchaseWiseMerge As frmPurchaseWiseMerge
				<DebuggerHidden()>
				Get
					Me.m_frmPurchaseWiseMerge = MyProject.MyForms.Create__Instance__(Of frmPurchaseWiseMerge)(Me.m_frmPurchaseWiseMerge)
					Return Me.m_frmPurchaseWiseMerge
				End Get
				<DebuggerHidden()>
				Set(value As frmPurchaseWiseMerge)
					If value IsNot Me.m_frmPurchaseWiseMerge Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPurchaseWiseMerge)(Me.m_frmPurchaseWiseMerge)
					End If
				End Set
			End Property

			' Token: 0x17000121 RID: 289
			' (get) Token: 0x06000150 RID: 336 RVA: 0x00004023 File Offset: 0x00002223
			' (set) Token: 0x060002DA RID: 730 RVA: 0x00007B6C File Offset: 0x00005D6C
			Public Property frmPurcOrderRetrieve As frmPurcOrderRetrieve
				<DebuggerHidden()>
				Get
					Me.m_frmPurcOrderRetrieve = MyProject.MyForms.Create__Instance__(Of frmPurcOrderRetrieve)(Me.m_frmPurcOrderRetrieve)
					Return Me.m_frmPurcOrderRetrieve
				End Get
				<DebuggerHidden()>
				Set(value As frmPurcOrderRetrieve)
					If value IsNot Me.m_frmPurcOrderRetrieve Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPurcOrderRetrieve)(Me.m_frmPurcOrderRetrieve)
					End If
				End Set
			End Property

			' Token: 0x17000122 RID: 290
			' (get) Token: 0x06000151 RID: 337 RVA: 0x0000403E File Offset: 0x0000223E
			' (set) Token: 0x060002DB RID: 731 RVA: 0x00007B98 File Offset: 0x00005D98
			Public Property frmPurcOrderRetrieve1 As frmPurcOrderRetrieve1
				<DebuggerHidden()>
				Get
					Me.m_frmPurcOrderRetrieve1 = MyProject.MyForms.Create__Instance__(Of frmPurcOrderRetrieve1)(Me.m_frmPurcOrderRetrieve1)
					Return Me.m_frmPurcOrderRetrieve1
				End Get
				<DebuggerHidden()>
				Set(value As frmPurcOrderRetrieve1)
					If value IsNot Me.m_frmPurcOrderRetrieve1 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmPurcOrderRetrieve1)(Me.m_frmPurcOrderRetrieve1)
					End If
				End Set
			End Property

			' Token: 0x17000123 RID: 291
			' (get) Token: 0x06000152 RID: 338 RVA: 0x00004059 File Offset: 0x00002259
			' (set) Token: 0x060002DC RID: 732 RVA: 0x00007BC4 File Offset: 0x00005DC4
			Public Property frmQuotation As frmQuotation
				<DebuggerHidden()>
				Get
					Me.m_frmQuotation = MyProject.MyForms.Create__Instance__(Of frmQuotation)(Me.m_frmQuotation)
					Return Me.m_frmQuotation
				End Get
				<DebuggerHidden()>
				Set(value As frmQuotation)
					If value IsNot Me.m_frmQuotation Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmQuotation)(Me.m_frmQuotation)
					End If
				End Set
			End Property

			' Token: 0x17000124 RID: 292
			' (get) Token: 0x06000153 RID: 339 RVA: 0x00004074 File Offset: 0x00002274
			' (set) Token: 0x060002DD RID: 733 RVA: 0x00007BF0 File Offset: 0x00005DF0
			Public Property frmQuotationRecord As frmQuotationRecord
				<DebuggerHidden()>
				Get
					Me.m_frmQuotationRecord = MyProject.MyForms.Create__Instance__(Of frmQuotationRecord)(Me.m_frmQuotationRecord)
					Return Me.m_frmQuotationRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmQuotationRecord)
					If value IsNot Me.m_frmQuotationRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmQuotationRecord)(Me.m_frmQuotationRecord)
					End If
				End Set
			End Property

			' Token: 0x17000125 RID: 293
			' (get) Token: 0x06000154 RID: 340 RVA: 0x0000408F File Offset: 0x0000228F
			' (set) Token: 0x060002DE RID: 734 RVA: 0x00007C1C File Offset: 0x00005E1C
			Public Property frmQuotationRetrieve As frmQuotationRetrieve
				<DebuggerHidden()>
				Get
					Me.m_frmQuotationRetrieve = MyProject.MyForms.Create__Instance__(Of frmQuotationRetrieve)(Me.m_frmQuotationRetrieve)
					Return Me.m_frmQuotationRetrieve
				End Get
				<DebuggerHidden()>
				Set(value As frmQuotationRetrieve)
					If value IsNot Me.m_frmQuotationRetrieve Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmQuotationRetrieve)(Me.m_frmQuotationRetrieve)
					End If
				End Set
			End Property

			' Token: 0x17000126 RID: 294
			' (get) Token: 0x06000155 RID: 341 RVA: 0x000040AA File Offset: 0x000022AA
			' (set) Token: 0x060002DF RID: 735 RVA: 0x00007C48 File Offset: 0x00005E48
			Public Property frmRecoveryPassword As frmRecoveryPassword
				<DebuggerHidden()>
				Get
					Me.m_frmRecoveryPassword = MyProject.MyForms.Create__Instance__(Of frmRecoveryPassword)(Me.m_frmRecoveryPassword)
					Return Me.m_frmRecoveryPassword
				End Get
				<DebuggerHidden()>
				Set(value As frmRecoveryPassword)
					If value IsNot Me.m_frmRecoveryPassword Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmRecoveryPassword)(Me.m_frmRecoveryPassword)
					End If
				End Set
			End Property

			' Token: 0x17000127 RID: 295
			' (get) Token: 0x06000156 RID: 342 RVA: 0x000040C5 File Offset: 0x000022C5
			' (set) Token: 0x060002E0 RID: 736 RVA: 0x00007C74 File Offset: 0x00005E74
			Public Property frmRefundAmt As frmRefundAmt
				<DebuggerHidden()>
				Get
					Me.m_frmRefundAmt = MyProject.MyForms.Create__Instance__(Of frmRefundAmt)(Me.m_frmRefundAmt)
					Return Me.m_frmRefundAmt
				End Get
				<DebuggerHidden()>
				Set(value As frmRefundAmt)
					If value IsNot Me.m_frmRefundAmt Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmRefundAmt)(Me.m_frmRefundAmt)
					End If
				End Set
			End Property

			' Token: 0x17000128 RID: 296
			' (get) Token: 0x06000157 RID: 343 RVA: 0x000040E0 File Offset: 0x000022E0
			' (set) Token: 0x060002E1 RID: 737 RVA: 0x00007CA0 File Offset: 0x00005EA0
			Public Property frmRegistration As frmRegistration
				<DebuggerHidden()>
				Get
					Me.m_frmRegistration = MyProject.MyForms.Create__Instance__(Of frmRegistration)(Me.m_frmRegistration)
					Return Me.m_frmRegistration
				End Get
				<DebuggerHidden()>
				Set(value As frmRegistration)
					If value IsNot Me.m_frmRegistration Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmRegistration)(Me.m_frmRegistration)
					End If
				End Set
			End Property

			' Token: 0x17000129 RID: 297
			' (get) Token: 0x06000158 RID: 344 RVA: 0x000040FB File Offset: 0x000022FB
			' (set) Token: 0x060002E2 RID: 738 RVA: 0x00007CCC File Offset: 0x00005ECC
			Public Property frmReminder As frmReminder
				<DebuggerHidden()>
				Get
					Me.m_frmReminder = MyProject.MyForms.Create__Instance__(Of frmReminder)(Me.m_frmReminder)
					Return Me.m_frmReminder
				End Get
				<DebuggerHidden()>
				Set(value As frmReminder)
					If value IsNot Me.m_frmReminder Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmReminder)(Me.m_frmReminder)
					End If
				End Set
			End Property

			' Token: 0x1700012A RID: 298
			' (get) Token: 0x06000159 RID: 345 RVA: 0x00004116 File Offset: 0x00002316
			' (set) Token: 0x060002E3 RID: 739 RVA: 0x00007CF8 File Offset: 0x00005EF8
			Public Property frmReminderRecord As frmReminderRecord
				<DebuggerHidden()>
				Get
					Me.m_frmReminderRecord = MyProject.MyForms.Create__Instance__(Of frmReminderRecord)(Me.m_frmReminderRecord)
					Return Me.m_frmReminderRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmReminderRecord)
					If value IsNot Me.m_frmReminderRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmReminderRecord)(Me.m_frmReminderRecord)
					End If
				End Set
			End Property

			' Token: 0x1700012B RID: 299
			' (get) Token: 0x0600015A RID: 346 RVA: 0x00004131 File Offset: 0x00002331
			' (set) Token: 0x060002E4 RID: 740 RVA: 0x00007D24 File Offset: 0x00005F24
			Public Property frmReminderShow As frmReminderShow
				<DebuggerHidden()>
				Get
					Me.m_frmReminderShow = MyProject.MyForms.Create__Instance__(Of frmReminderShow)(Me.m_frmReminderShow)
					Return Me.m_frmReminderShow
				End Get
				<DebuggerHidden()>
				Set(value As frmReminderShow)
					If value IsNot Me.m_frmReminderShow Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmReminderShow)(Me.m_frmReminderShow)
					End If
				End Set
			End Property

			' Token: 0x1700012C RID: 300
			' (get) Token: 0x0600015B RID: 347 RVA: 0x0000414C File Offset: 0x0000234C
			' (set) Token: 0x060002E5 RID: 741 RVA: 0x00007D50 File Offset: 0x00005F50
			Public Property frmReport As frmReport
				<DebuggerHidden()>
				Get
					Me.m_frmReport = MyProject.MyForms.Create__Instance__(Of frmReport)(Me.m_frmReport)
					Return Me.m_frmReport
				End Get
				<DebuggerHidden()>
				Set(value As frmReport)
					If value IsNot Me.m_frmReport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmReport)(Me.m_frmReport)
					End If
				End Set
			End Property

			' Token: 0x1700012D RID: 301
			' (get) Token: 0x0600015C RID: 348 RVA: 0x00004167 File Offset: 0x00002367
			' (set) Token: 0x060002E6 RID: 742 RVA: 0x00007D7C File Offset: 0x00005F7C
			Public Property frmRoute As frmRoute
				<DebuggerHidden()>
				Get
					Me.m_frmRoute = MyProject.MyForms.Create__Instance__(Of frmRoute)(Me.m_frmRoute)
					Return Me.m_frmRoute
				End Get
				<DebuggerHidden()>
				Set(value As frmRoute)
					If value IsNot Me.m_frmRoute Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmRoute)(Me.m_frmRoute)
					End If
				End Set
			End Property

			' Token: 0x1700012E RID: 302
			' (get) Token: 0x0600015D RID: 349 RVA: 0x00004182 File Offset: 0x00002382
			' (set) Token: 0x060002E7 RID: 743 RVA: 0x00007DA8 File Offset: 0x00005FA8
			Public Property frmSalaryslip As frmSalaryslip
				<DebuggerHidden()>
				Get
					Me.m_frmSalaryslip = MyProject.MyForms.Create__Instance__(Of frmSalaryslip)(Me.m_frmSalaryslip)
					Return Me.m_frmSalaryslip
				End Get
				<DebuggerHidden()>
				Set(value As frmSalaryslip)
					If value IsNot Me.m_frmSalaryslip Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSalaryslip)(Me.m_frmSalaryslip)
					End If
				End Set
			End Property

			' Token: 0x1700012F RID: 303
			' (get) Token: 0x0600015E RID: 350 RVA: 0x0000419D File Offset: 0x0000239D
			' (set) Token: 0x060002E8 RID: 744 RVA: 0x00007DD4 File Offset: 0x00005FD4
			Public Property frmSalarySlipsReport As frmSalarySlipsReport
				<DebuggerHidden()>
				Get
					Me.m_frmSalarySlipsReport = MyProject.MyForms.Create__Instance__(Of frmSalarySlipsReport)(Me.m_frmSalarySlipsReport)
					Return Me.m_frmSalarySlipsReport
				End Get
				<DebuggerHidden()>
				Set(value As frmSalarySlipsReport)
					If value IsNot Me.m_frmSalarySlipsReport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSalarySlipsReport)(Me.m_frmSalarySlipsReport)
					End If
				End Set
			End Property

			' Token: 0x17000130 RID: 304
			' (get) Token: 0x0600015F RID: 351 RVA: 0x000041B8 File Offset: 0x000023B8
			' (set) Token: 0x060002E9 RID: 745 RVA: 0x00007E00 File Offset: 0x00006000
			Public Property frmSaleAmtCal As frmSaleAmtCal
				<DebuggerHidden()>
				Get
					Me.m_frmSaleAmtCal = MyProject.MyForms.Create__Instance__(Of frmSaleAmtCal)(Me.m_frmSaleAmtCal)
					Return Me.m_frmSaleAmtCal
				End Get
				<DebuggerHidden()>
				Set(value As frmSaleAmtCal)
					If value IsNot Me.m_frmSaleAmtCal Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSaleAmtCal)(Me.m_frmSaleAmtCal)
					End If
				End Set
			End Property

			' Token: 0x17000131 RID: 305
			' (get) Token: 0x06000160 RID: 352 RVA: 0x000041D3 File Offset: 0x000023D3
			' (set) Token: 0x060002EA RID: 746 RVA: 0x00007E2C File Offset: 0x0000602C
			Public Property frmSaleReport_Multi_Payment As frmSaleReport_Multi_Payment
				<DebuggerHidden()>
				Get
					Me.m_frmSaleReport_Multi_Payment = MyProject.MyForms.Create__Instance__(Of frmSaleReport_Multi_Payment)(Me.m_frmSaleReport_Multi_Payment)
					Return Me.m_frmSaleReport_Multi_Payment
				End Get
				<DebuggerHidden()>
				Set(value As frmSaleReport_Multi_Payment)
					If value IsNot Me.m_frmSaleReport_Multi_Payment Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSaleReport_Multi_Payment)(Me.m_frmSaleReport_Multi_Payment)
					End If
				End Set
			End Property

			' Token: 0x17000132 RID: 306
			' (get) Token: 0x06000161 RID: 353 RVA: 0x000041EE File Offset: 0x000023EE
			' (set) Token: 0x060002EB RID: 747 RVA: 0x00007E58 File Offset: 0x00006058
			Public Property frmSales_ProductHistory As frmSales_ProductHistory
				<DebuggerHidden()>
				Get
					Me.m_frmSales_ProductHistory = MyProject.MyForms.Create__Instance__(Of frmSales_ProductHistory)(Me.m_frmSales_ProductHistory)
					Return Me.m_frmSales_ProductHistory
				End Get
				<DebuggerHidden()>
				Set(value As frmSales_ProductHistory)
					If value IsNot Me.m_frmSales_ProductHistory Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSales_ProductHistory)(Me.m_frmSales_ProductHistory)
					End If
				End Set
			End Property

			' Token: 0x17000133 RID: 307
			' (get) Token: 0x06000162 RID: 354 RVA: 0x00004209 File Offset: 0x00002409
			' (set) Token: 0x060002EC RID: 748 RVA: 0x00007E84 File Offset: 0x00006084
			Public Property frmSalesInvoiceRecord As frmSalesInvoiceRecord
				<DebuggerHidden()>
				Get
					Me.m_frmSalesInvoiceRecord = MyProject.MyForms.Create__Instance__(Of frmSalesInvoiceRecord)(Me.m_frmSalesInvoiceRecord)
					Return Me.m_frmSalesInvoiceRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmSalesInvoiceRecord)
					If value IsNot Me.m_frmSalesInvoiceRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSalesInvoiceRecord)(Me.m_frmSalesInvoiceRecord)
					End If
				End Set
			End Property

			' Token: 0x17000134 RID: 308
			' (get) Token: 0x06000163 RID: 355 RVA: 0x00004224 File Offset: 0x00002424
			' (set) Token: 0x060002ED RID: 749 RVA: 0x00007EB0 File Offset: 0x000060B0
			Public Property frmSalesInvoiceRecord_GSTR As frmSalesInvoiceRecord_GSTR
				<DebuggerHidden()>
				Get
					Me.m_frmSalesInvoiceRecord_GSTR = MyProject.MyForms.Create__Instance__(Of frmSalesInvoiceRecord_GSTR)(Me.m_frmSalesInvoiceRecord_GSTR)
					Return Me.m_frmSalesInvoiceRecord_GSTR
				End Get
				<DebuggerHidden()>
				Set(value As frmSalesInvoiceRecord_GSTR)
					If value IsNot Me.m_frmSalesInvoiceRecord_GSTR Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSalesInvoiceRecord_GSTR)(Me.m_frmSalesInvoiceRecord_GSTR)
					End If
				End Set
			End Property

			' Token: 0x17000135 RID: 309
			' (get) Token: 0x06000164 RID: 356 RVA: 0x0000423F File Offset: 0x0000243F
			' (set) Token: 0x060002EE RID: 750 RVA: 0x00007EDC File Offset: 0x000060DC
			Public Property frmSalesInvoiceRecordD As frmSalesInvoiceRecordD
				<DebuggerHidden()>
				Get
					Me.m_frmSalesInvoiceRecordD = MyProject.MyForms.Create__Instance__(Of frmSalesInvoiceRecordD)(Me.m_frmSalesInvoiceRecordD)
					Return Me.m_frmSalesInvoiceRecordD
				End Get
				<DebuggerHidden()>
				Set(value As frmSalesInvoiceRecordD)
					If value IsNot Me.m_frmSalesInvoiceRecordD Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSalesInvoiceRecordD)(Me.m_frmSalesInvoiceRecordD)
					End If
				End Set
			End Property

			' Token: 0x17000136 RID: 310
			' (get) Token: 0x06000165 RID: 357 RVA: 0x0000425A File Offset: 0x0000245A
			' (set) Token: 0x060002EF RID: 751 RVA: 0x00007F08 File Offset: 0x00006108
			Public Property frmSalesman As frmSalesman
				<DebuggerHidden()>
				Get
					Me.m_frmSalesman = MyProject.MyForms.Create__Instance__(Of frmSalesman)(Me.m_frmSalesman)
					Return Me.m_frmSalesman
				End Get
				<DebuggerHidden()>
				Set(value As frmSalesman)
					If value IsNot Me.m_frmSalesman Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSalesman)(Me.m_frmSalesman)
					End If
				End Set
			End Property

			' Token: 0x17000137 RID: 311
			' (get) Token: 0x06000166 RID: 358 RVA: 0x00004275 File Offset: 0x00002475
			' (set) Token: 0x060002F0 RID: 752 RVA: 0x00007F34 File Offset: 0x00006134
			Public Property frmSalesmanBulkUpdate As frmSalesmanBulkUpdate
				<DebuggerHidden()>
				Get
					Me.m_frmSalesmanBulkUpdate = MyProject.MyForms.Create__Instance__(Of frmSalesmanBulkUpdate)(Me.m_frmSalesmanBulkUpdate)
					Return Me.m_frmSalesmanBulkUpdate
				End Get
				<DebuggerHidden()>
				Set(value As frmSalesmanBulkUpdate)
					If value IsNot Me.m_frmSalesmanBulkUpdate Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSalesmanBulkUpdate)(Me.m_frmSalesmanBulkUpdate)
					End If
				End Set
			End Property

			' Token: 0x17000138 RID: 312
			' (get) Token: 0x06000167 RID: 359 RVA: 0x00004290 File Offset: 0x00002490
			' (set) Token: 0x060002F1 RID: 753 RVA: 0x00007F60 File Offset: 0x00006160
			Public Property frmSalesmanCommmissionReport As frmSalesmanCommmissionReport
				<DebuggerHidden()>
				Get
					Me.m_frmSalesmanCommmissionReport = MyProject.MyForms.Create__Instance__(Of frmSalesmanCommmissionReport)(Me.m_frmSalesmanCommmissionReport)
					Return Me.m_frmSalesmanCommmissionReport
				End Get
				<DebuggerHidden()>
				Set(value As frmSalesmanCommmissionReport)
					If value IsNot Me.m_frmSalesmanCommmissionReport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSalesmanCommmissionReport)(Me.m_frmSalesmanCommmissionReport)
					End If
				End Set
			End Property

			' Token: 0x17000139 RID: 313
			' (get) Token: 0x06000168 RID: 360 RVA: 0x000042AB File Offset: 0x000024AB
			' (set) Token: 0x060002F2 RID: 754 RVA: 0x00007F8C File Offset: 0x0000618C
			Public Property frmSalesmanLedger As frmSalesmanLedger
				<DebuggerHidden()>
				Get
					Me.m_frmSalesmanLedger = MyProject.MyForms.Create__Instance__(Of frmSalesmanLedger)(Me.m_frmSalesmanLedger)
					Return Me.m_frmSalesmanLedger
				End Get
				<DebuggerHidden()>
				Set(value As frmSalesmanLedger)
					If value IsNot Me.m_frmSalesmanLedger Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSalesmanLedger)(Me.m_frmSalesmanLedger)
					End If
				End Set
			End Property

			' Token: 0x1700013A RID: 314
			' (get) Token: 0x06000169 RID: 361 RVA: 0x000042C6 File Offset: 0x000024C6
			' (set) Token: 0x060002F3 RID: 755 RVA: 0x00007FB8 File Offset: 0x000061B8
			Public Property frmSalesmanLedgerNew As frmSalesmanLedgerNew
				<DebuggerHidden()>
				Get
					Me.m_frmSalesmanLedgerNew = MyProject.MyForms.Create__Instance__(Of frmSalesmanLedgerNew)(Me.m_frmSalesmanLedgerNew)
					Return Me.m_frmSalesmanLedgerNew
				End Get
				<DebuggerHidden()>
				Set(value As frmSalesmanLedgerNew)
					If value IsNot Me.m_frmSalesmanLedgerNew Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSalesmanLedgerNew)(Me.m_frmSalesmanLedgerNew)
					End If
				End Set
			End Property

			' Token: 0x1700013B RID: 315
			' (get) Token: 0x0600016A RID: 362 RVA: 0x000042E1 File Offset: 0x000024E1
			' (set) Token: 0x060002F4 RID: 756 RVA: 0x00007FE4 File Offset: 0x000061E4
			Public Property frmSalesManPayment As frmSalesManPayment
				<DebuggerHidden()>
				Get
					Me.m_frmSalesManPayment = MyProject.MyForms.Create__Instance__(Of frmSalesManPayment)(Me.m_frmSalesManPayment)
					Return Me.m_frmSalesManPayment
				End Get
				<DebuggerHidden()>
				Set(value As frmSalesManPayment)
					If value IsNot Me.m_frmSalesManPayment Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSalesManPayment)(Me.m_frmSalesManPayment)
					End If
				End Set
			End Property

			' Token: 0x1700013C RID: 316
			' (get) Token: 0x0600016B RID: 363 RVA: 0x000042FC File Offset: 0x000024FC
			' (set) Token: 0x060002F5 RID: 757 RVA: 0x00008010 File Offset: 0x00006210
			Public Property frmSalesManPaymentRecordNew As frmSalesManPaymentRecordNew
				<DebuggerHidden()>
				Get
					Me.m_frmSalesManPaymentRecordNew = MyProject.MyForms.Create__Instance__(Of frmSalesManPaymentRecordNew)(Me.m_frmSalesManPaymentRecordNew)
					Return Me.m_frmSalesManPaymentRecordNew
				End Get
				<DebuggerHidden()>
				Set(value As frmSalesManPaymentRecordNew)
					If value IsNot Me.m_frmSalesManPaymentRecordNew Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSalesManPaymentRecordNew)(Me.m_frmSalesManPaymentRecordNew)
					End If
				End Set
			End Property

			' Token: 0x1700013D RID: 317
			' (get) Token: 0x0600016C RID: 364 RVA: 0x00004317 File Offset: 0x00002517
			' (set) Token: 0x060002F6 RID: 758 RVA: 0x0000803C File Offset: 0x0000623C
			Public Property frmSalesmanRecord As frmSalesmanRecord
				<DebuggerHidden()>
				Get
					Me.m_frmSalesmanRecord = MyProject.MyForms.Create__Instance__(Of frmSalesmanRecord)(Me.m_frmSalesmanRecord)
					Return Me.m_frmSalesmanRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmSalesmanRecord)
					If value IsNot Me.m_frmSalesmanRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSalesmanRecord)(Me.m_frmSalesmanRecord)
					End If
				End Set
			End Property

			' Token: 0x1700013E RID: 318
			' (get) Token: 0x0600016D RID: 365 RVA: 0x00004332 File Offset: 0x00002532
			' (set) Token: 0x060002F7 RID: 759 RVA: 0x00008068 File Offset: 0x00006268
			Public Property frmSalesPmtInfo As frmSalesPmtInfo
				<DebuggerHidden()>
				Get
					Me.m_frmSalesPmtInfo = MyProject.MyForms.Create__Instance__(Of frmSalesPmtInfo)(Me.m_frmSalesPmtInfo)
					Return Me.m_frmSalesPmtInfo
				End Get
				<DebuggerHidden()>
				Set(value As frmSalesPmtInfo)
					If value IsNot Me.m_frmSalesPmtInfo Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSalesPmtInfo)(Me.m_frmSalesPmtInfo)
					End If
				End Set
			End Property

			' Token: 0x1700013F RID: 319
			' (get) Token: 0x0600016E RID: 366 RVA: 0x0000434D File Offset: 0x0000254D
			' (set) Token: 0x060002F8 RID: 760 RVA: 0x00008094 File Offset: 0x00006294
			Public Property frmSalesReport As frmSalesReport
				<DebuggerHidden()>
				Get
					Me.m_frmSalesReport = MyProject.MyForms.Create__Instance__(Of frmSalesReport)(Me.m_frmSalesReport)
					Return Me.m_frmSalesReport
				End Get
				<DebuggerHidden()>
				Set(value As frmSalesReport)
					If value IsNot Me.m_frmSalesReport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSalesReport)(Me.m_frmSalesReport)
					End If
				End Set
			End Property

			' Token: 0x17000140 RID: 320
			' (get) Token: 0x0600016F RID: 367 RVA: 0x00004368 File Offset: 0x00002568
			' (set) Token: 0x060002F9 RID: 761 RVA: 0x000080C0 File Offset: 0x000062C0
			Public Property frmSalesReturn As frmSalesReturn
				<DebuggerHidden()>
				Get
					Me.m_frmSalesReturn = MyProject.MyForms.Create__Instance__(Of frmSalesReturn)(Me.m_frmSalesReturn)
					Return Me.m_frmSalesReturn
				End Get
				<DebuggerHidden()>
				Set(value As frmSalesReturn)
					If value IsNot Me.m_frmSalesReturn Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSalesReturn)(Me.m_frmSalesReturn)
					End If
				End Set
			End Property

			' Token: 0x17000141 RID: 321
			' (get) Token: 0x06000170 RID: 368 RVA: 0x00004383 File Offset: 0x00002583
			' (set) Token: 0x060002FA RID: 762 RVA: 0x000080EC File Offset: 0x000062EC
			Public Property frmSalesReturnRecord As frmSalesReturnRecord
				<DebuggerHidden()>
				Get
					Me.m_frmSalesReturnRecord = MyProject.MyForms.Create__Instance__(Of frmSalesReturnRecord)(Me.m_frmSalesReturnRecord)
					Return Me.m_frmSalesReturnRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmSalesReturnRecord)
					If value IsNot Me.m_frmSalesReturnRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSalesReturnRecord)(Me.m_frmSalesReturnRecord)
					End If
				End Set
			End Property

			' Token: 0x17000142 RID: 322
			' (get) Token: 0x06000171 RID: 369 RVA: 0x0000439E File Offset: 0x0000259E
			' (set) Token: 0x060002FB RID: 763 RVA: 0x00008118 File Offset: 0x00006318
			Public Property frmSalesReturnRecord_GSTR As frmSalesReturnRecord_GSTR
				<DebuggerHidden()>
				Get
					Me.m_frmSalesReturnRecord_GSTR = MyProject.MyForms.Create__Instance__(Of frmSalesReturnRecord_GSTR)(Me.m_frmSalesReturnRecord_GSTR)
					Return Me.m_frmSalesReturnRecord_GSTR
				End Get
				<DebuggerHidden()>
				Set(value As frmSalesReturnRecord_GSTR)
					If value IsNot Me.m_frmSalesReturnRecord_GSTR Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSalesReturnRecord_GSTR)(Me.m_frmSalesReturnRecord_GSTR)
					End If
				End Set
			End Property

			' Token: 0x17000143 RID: 323
			' (get) Token: 0x06000172 RID: 370 RVA: 0x000043B9 File Offset: 0x000025B9
			' (set) Token: 0x060002FC RID: 764 RVA: 0x00008144 File Offset: 0x00006344
			Public Property frmScrDsply As frmScrDsply
				<DebuggerHidden()>
				Get
					Me.m_frmScrDsply = MyProject.MyForms.Create__Instance__(Of frmScrDsply)(Me.m_frmScrDsply)
					Return Me.m_frmScrDsply
				End Get
				<DebuggerHidden()>
				Set(value As frmScrDsply)
					If value IsNot Me.m_frmScrDsply Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmScrDsply)(Me.m_frmScrDsply)
					End If
				End Set
			End Property

			' Token: 0x17000144 RID: 324
			' (get) Token: 0x06000173 RID: 371 RVA: 0x000043D4 File Offset: 0x000025D4
			' (set) Token: 0x060002FD RID: 765 RVA: 0x00008170 File Offset: 0x00006370
			Public Property frmScreenlock As frmScreenlock
				<DebuggerHidden()>
				Get
					Me.m_frmScreenlock = MyProject.MyForms.Create__Instance__(Of frmScreenlock)(Me.m_frmScreenlock)
					Return Me.m_frmScreenlock
				End Get
				<DebuggerHidden()>
				Set(value As frmScreenlock)
					If value IsNot Me.m_frmScreenlock Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmScreenlock)(Me.m_frmScreenlock)
					End If
				End Set
			End Property

			' Token: 0x17000145 RID: 325
			' (get) Token: 0x06000174 RID: 372 RVA: 0x000043EF File Offset: 0x000025EF
			' (set) Token: 0x060002FE RID: 766 RVA: 0x0000819C File Offset: 0x0000639C
			Public Property frmSendEmail As frmSendEmail
				<DebuggerHidden()>
				Get
					Me.m_frmSendEmail = MyProject.MyForms.Create__Instance__(Of frmSendEmail)(Me.m_frmSendEmail)
					Return Me.m_frmSendEmail
				End Get
				<DebuggerHidden()>
				Set(value As frmSendEmail)
					If value IsNot Me.m_frmSendEmail Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSendEmail)(Me.m_frmSendEmail)
					End If
				End Set
			End Property

			' Token: 0x17000146 RID: 326
			' (get) Token: 0x06000175 RID: 373 RVA: 0x0000440A File Offset: 0x0000260A
			' (set) Token: 0x060002FF RID: 767 RVA: 0x000081C8 File Offset: 0x000063C8
			Public Property frmSendSMS_Sales As frmSendSMS_Sales
				<DebuggerHidden()>
				Get
					Me.m_frmSendSMS_Sales = MyProject.MyForms.Create__Instance__(Of frmSendSMS_Sales)(Me.m_frmSendSMS_Sales)
					Return Me.m_frmSendSMS_Sales
				End Get
				<DebuggerHidden()>
				Set(value As frmSendSMS_Sales)
					If value IsNot Me.m_frmSendSMS_Sales Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSendSMS_Sales)(Me.m_frmSendSMS_Sales)
					End If
				End Set
			End Property

			' Token: 0x17000147 RID: 327
			' (get) Token: 0x06000176 RID: 374 RVA: 0x00004425 File Offset: 0x00002625
			' (set) Token: 0x06000300 RID: 768 RVA: 0x000081F4 File Offset: 0x000063F4
			Public Property frmSendSMS_Services As frmSendSMS_Services
				<DebuggerHidden()>
				Get
					Me.m_frmSendSMS_Services = MyProject.MyForms.Create__Instance__(Of frmSendSMS_Services)(Me.m_frmSendSMS_Services)
					Return Me.m_frmSendSMS_Services
				End Get
				<DebuggerHidden()>
				Set(value As frmSendSMS_Services)
					If value IsNot Me.m_frmSendSMS_Services Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSendSMS_Services)(Me.m_frmSendSMS_Services)
					End If
				End Set
			End Property

			' Token: 0x17000148 RID: 328
			' (get) Token: 0x06000177 RID: 375 RVA: 0x00004440 File Offset: 0x00002640
			' (set) Token: 0x06000301 RID: 769 RVA: 0x00008220 File Offset: 0x00006420
			Public Property frmSerialno_popup As frmSerialno_popup
				<DebuggerHidden()>
				Get
					Me.m_frmSerialno_popup = MyProject.MyForms.Create__Instance__(Of frmSerialno_popup)(Me.m_frmSerialno_popup)
					Return Me.m_frmSerialno_popup
				End Get
				<DebuggerHidden()>
				Set(value As frmSerialno_popup)
					If value IsNot Me.m_frmSerialno_popup Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSerialno_popup)(Me.m_frmSerialno_popup)
					End If
				End Set
			End Property

			' Token: 0x17000149 RID: 329
			' (get) Token: 0x06000178 RID: 376 RVA: 0x0000445B File Offset: 0x0000265B
			' (set) Token: 0x06000302 RID: 770 RVA: 0x0000824C File Offset: 0x0000644C
			Public Property frmSerialwiseReport As frmSerialwiseReport
				<DebuggerHidden()>
				Get
					Me.m_frmSerialwiseReport = MyProject.MyForms.Create__Instance__(Of frmSerialwiseReport)(Me.m_frmSerialwiseReport)
					Return Me.m_frmSerialwiseReport
				End Get
				<DebuggerHidden()>
				Set(value As frmSerialwiseReport)
					If value IsNot Me.m_frmSerialwiseReport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSerialwiseReport)(Me.m_frmSerialwiseReport)
					End If
				End Set
			End Property

			' Token: 0x1700014A RID: 330
			' (get) Token: 0x06000179 RID: 377 RVA: 0x00004476 File Offset: 0x00002676
			' (set) Token: 0x06000303 RID: 771 RVA: 0x00008278 File Offset: 0x00006478
			Public Property frmServiceBilling As frmServiceBilling
				<DebuggerHidden()>
				Get
					Me.m_frmServiceBilling = MyProject.MyForms.Create__Instance__(Of frmServiceBilling)(Me.m_frmServiceBilling)
					Return Me.m_frmServiceBilling
				End Get
				<DebuggerHidden()>
				Set(value As frmServiceBilling)
					If value IsNot Me.m_frmServiceBilling Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmServiceBilling)(Me.m_frmServiceBilling)
					End If
				End Set
			End Property

			' Token: 0x1700014B RID: 331
			' (get) Token: 0x0600017A RID: 378 RVA: 0x00004491 File Offset: 0x00002691
			' (set) Token: 0x06000304 RID: 772 RVA: 0x000082A4 File Offset: 0x000064A4
			Public Property frmServiceBillingRecord As frmServiceBillingRecord
				<DebuggerHidden()>
				Get
					Me.m_frmServiceBillingRecord = MyProject.MyForms.Create__Instance__(Of frmServiceBillingRecord)(Me.m_frmServiceBillingRecord)
					Return Me.m_frmServiceBillingRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmServiceBillingRecord)
					If value IsNot Me.m_frmServiceBillingRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmServiceBillingRecord)(Me.m_frmServiceBillingRecord)
					End If
				End Set
			End Property

			' Token: 0x1700014C RID: 332
			' (get) Token: 0x0600017B RID: 379 RVA: 0x000044AC File Offset: 0x000026AC
			' (set) Token: 0x06000305 RID: 773 RVA: 0x000082D0 File Offset: 0x000064D0
			Public Property frmServiceDoneReport As frmServiceDoneReport
				<DebuggerHidden()>
				Get
					Me.m_frmServiceDoneReport = MyProject.MyForms.Create__Instance__(Of frmServiceDoneReport)(Me.m_frmServiceDoneReport)
					Return Me.m_frmServiceDoneReport
				End Get
				<DebuggerHidden()>
				Set(value As frmServiceDoneReport)
					If value IsNot Me.m_frmServiceDoneReport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmServiceDoneReport)(Me.m_frmServiceDoneReport)
					End If
				End Set
			End Property

			' Token: 0x1700014D RID: 333
			' (get) Token: 0x0600017C RID: 380 RVA: 0x000044C7 File Offset: 0x000026C7
			' (set) Token: 0x06000306 RID: 774 RVA: 0x000082FC File Offset: 0x000064FC
			Public Property frmServices As frmServices
				<DebuggerHidden()>
				Get
					Me.m_frmServices = MyProject.MyForms.Create__Instance__(Of frmServices)(Me.m_frmServices)
					Return Me.m_frmServices
				End Get
				<DebuggerHidden()>
				Set(value As frmServices)
					If value IsNot Me.m_frmServices Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmServices)(Me.m_frmServices)
					End If
				End Set
			End Property

			' Token: 0x1700014E RID: 334
			' (get) Token: 0x0600017D RID: 381 RVA: 0x000044E2 File Offset: 0x000026E2
			' (set) Token: 0x06000307 RID: 775 RVA: 0x00008328 File Offset: 0x00006528
			Public Property frmServicesRecord As frmServicesRecord
				<DebuggerHidden()>
				Get
					Me.m_frmServicesRecord = MyProject.MyForms.Create__Instance__(Of frmServicesRecord)(Me.m_frmServicesRecord)
					Return Me.m_frmServicesRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmServicesRecord)
					If value IsNot Me.m_frmServicesRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmServicesRecord)(Me.m_frmServicesRecord)
					End If
				End Set
			End Property

			' Token: 0x1700014F RID: 335
			' (get) Token: 0x0600017E RID: 382 RVA: 0x000044FD File Offset: 0x000026FD
			' (set) Token: 0x06000308 RID: 776 RVA: 0x00008354 File Offset: 0x00006554
			Public Property frmServicesRecord1 As frmServicesRecord1
				<DebuggerHidden()>
				Get
					Me.m_frmServicesRecord1 = MyProject.MyForms.Create__Instance__(Of frmServicesRecord1)(Me.m_frmServicesRecord1)
					Return Me.m_frmServicesRecord1
				End Get
				<DebuggerHidden()>
				Set(value As frmServicesRecord1)
					If value IsNot Me.m_frmServicesRecord1 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmServicesRecord1)(Me.m_frmServicesRecord1)
					End If
				End Set
			End Property

			' Token: 0x17000150 RID: 336
			' (get) Token: 0x0600017F RID: 383 RVA: 0x00004518 File Offset: 0x00002718
			' (set) Token: 0x06000309 RID: 777 RVA: 0x00008380 File Offset: 0x00006580
			Public Property frmSetBillDiscount As frmSetBillDiscount
				<DebuggerHidden()>
				Get
					Me.m_frmSetBillDiscount = MyProject.MyForms.Create__Instance__(Of frmSetBillDiscount)(Me.m_frmSetBillDiscount)
					Return Me.m_frmSetBillDiscount
				End Get
				<DebuggerHidden()>
				Set(value As frmSetBillDiscount)
					If value IsNot Me.m_frmSetBillDiscount Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSetBillDiscount)(Me.m_frmSetBillDiscount)
					End If
				End Set
			End Property

			' Token: 0x17000151 RID: 337
			' (get) Token: 0x06000180 RID: 384 RVA: 0x00004533 File Offset: 0x00002733
			' (set) Token: 0x0600030A RID: 778 RVA: 0x000083AC File Offset: 0x000065AC
			Public Property frmSMS As frmSMS
				<DebuggerHidden()>
				Get
					Me.m_frmSMS = MyProject.MyForms.Create__Instance__(Of frmSMS)(Me.m_frmSMS)
					Return Me.m_frmSMS
				End Get
				<DebuggerHidden()>
				Set(value As frmSMS)
					If value IsNot Me.m_frmSMS Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSMS)(Me.m_frmSMS)
					End If
				End Set
			End Property

			' Token: 0x17000152 RID: 338
			' (get) Token: 0x06000181 RID: 385 RVA: 0x0000454E File Offset: 0x0000274E
			' (set) Token: 0x0600030B RID: 779 RVA: 0x000083D8 File Offset: 0x000065D8
			Public Property frmSMS_AutoDetect As frmSMS_AutoDetect
				<DebuggerHidden()>
				Get
					Me.m_frmSMS_AutoDetect = MyProject.MyForms.Create__Instance__(Of frmSMS_AutoDetect)(Me.m_frmSMS_AutoDetect)
					Return Me.m_frmSMS_AutoDetect
				End Get
				<DebuggerHidden()>
				Set(value As frmSMS_AutoDetect)
					If value IsNot Me.m_frmSMS_AutoDetect Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSMS_AutoDetect)(Me.m_frmSMS_AutoDetect)
					End If
				End Set
			End Property

			' Token: 0x17000153 RID: 339
			' (get) Token: 0x06000182 RID: 386 RVA: 0x00004569 File Offset: 0x00002769
			' (set) Token: 0x0600030C RID: 780 RVA: 0x00008404 File Offset: 0x00006604
			Public Property frmSMSSetting As frmSMSSetting
				<DebuggerHidden()>
				Get
					Me.m_frmSMSSetting = MyProject.MyForms.Create__Instance__(Of frmSMSSetting)(Me.m_frmSMSSetting)
					Return Me.m_frmSMSSetting
				End Get
				<DebuggerHidden()>
				Set(value As frmSMSSetting)
					If value IsNot Me.m_frmSMSSetting Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSMSSetting)(Me.m_frmSMSSetting)
					End If
				End Set
			End Property

			' Token: 0x17000154 RID: 340
			' (get) Token: 0x06000183 RID: 387 RVA: 0x00004584 File Offset: 0x00002784
			' (set) Token: 0x0600030D RID: 781 RVA: 0x00008430 File Offset: 0x00006630
			Public Property frmSplash As frmSplash
				<DebuggerHidden()>
				Get
					Me.m_frmSplash = MyProject.MyForms.Create__Instance__(Of frmSplash)(Me.m_frmSplash)
					Return Me.m_frmSplash
				End Get
				<DebuggerHidden()>
				Set(value As frmSplash)
					If value IsNot Me.m_frmSplash Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSplash)(Me.m_frmSplash)
					End If
				End Set
			End Property

			' Token: 0x17000155 RID: 341
			' (get) Token: 0x06000184 RID: 388 RVA: 0x0000459F File Offset: 0x0000279F
			' (set) Token: 0x0600030E RID: 782 RVA: 0x0000845C File Offset: 0x0000665C
			Public Property frmSqlServerSetting As frmSqlServerSetting
				<DebuggerHidden()>
				Get
					Me.m_frmSqlServerSetting = MyProject.MyForms.Create__Instance__(Of frmSqlServerSetting)(Me.m_frmSqlServerSetting)
					Return Me.m_frmSqlServerSetting
				End Get
				<DebuggerHidden()>
				Set(value As frmSqlServerSetting)
					If value IsNot Me.m_frmSqlServerSetting Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSqlServerSetting)(Me.m_frmSqlServerSetting)
					End If
				End Set
			End Property

			' Token: 0x17000156 RID: 342
			' (get) Token: 0x06000185 RID: 389 RVA: 0x000045BA File Offset: 0x000027BA
			' (set) Token: 0x0600030F RID: 783 RVA: 0x00008488 File Offset: 0x00006688
			Public Property frmState As frmState
				<DebuggerHidden()>
				Get
					Me.m_frmState = MyProject.MyForms.Create__Instance__(Of frmState)(Me.m_frmState)
					Return Me.m_frmState
				End Get
				<DebuggerHidden()>
				Set(value As frmState)
					If value IsNot Me.m_frmState Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmState)(Me.m_frmState)
					End If
				End Set
			End Property

			' Token: 0x17000157 RID: 343
			' (get) Token: 0x06000186 RID: 390 RVA: 0x000045D5 File Offset: 0x000027D5
			' (set) Token: 0x06000310 RID: 784 RVA: 0x000084B4 File Offset: 0x000066B4
			Public Property frmStock_Inward_Notification As frmStock_Inward_Notification
				<DebuggerHidden()>
				Get
					Me.m_frmStock_Inward_Notification = MyProject.MyForms.Create__Instance__(Of frmStock_Inward_Notification)(Me.m_frmStock_Inward_Notification)
					Return Me.m_frmStock_Inward_Notification
				End Get
				<DebuggerHidden()>
				Set(value As frmStock_Inward_Notification)
					If value IsNot Me.m_frmStock_Inward_Notification Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmStock_Inward_Notification)(Me.m_frmStock_Inward_Notification)
					End If
				End Set
			End Property

			' Token: 0x17000158 RID: 344
			' (get) Token: 0x06000187 RID: 391 RVA: 0x000045F0 File Offset: 0x000027F0
			' (set) Token: 0x06000311 RID: 785 RVA: 0x000084E0 File Offset: 0x000066E0
			Public Property frmStock_Inward_Record As frmStock_Inward_Record
				<DebuggerHidden()>
				Get
					Me.m_frmStock_Inward_Record = MyProject.MyForms.Create__Instance__(Of frmStock_Inward_Record)(Me.m_frmStock_Inward_Record)
					Return Me.m_frmStock_Inward_Record
				End Get
				<DebuggerHidden()>
				Set(value As frmStock_Inward_Record)
					If value IsNot Me.m_frmStock_Inward_Record Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmStock_Inward_Record)(Me.m_frmStock_Inward_Record)
					End If
				End Set
			End Property

			' Token: 0x17000159 RID: 345
			' (get) Token: 0x06000188 RID: 392 RVA: 0x0000460B File Offset: 0x0000280B
			' (set) Token: 0x06000312 RID: 786 RVA: 0x0000850C File Offset: 0x0000670C
			Public Property frmStock_Settlement As frmStock_Settlement
				<DebuggerHidden()>
				Get
					Me.m_frmStock_Settlement = MyProject.MyForms.Create__Instance__(Of frmStock_Settlement)(Me.m_frmStock_Settlement)
					Return Me.m_frmStock_Settlement
				End Get
				<DebuggerHidden()>
				Set(value As frmStock_Settlement)
					If value IsNot Me.m_frmStock_Settlement Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmStock_Settlement)(Me.m_frmStock_Settlement)
					End If
				End Set
			End Property

			' Token: 0x1700015A RID: 346
			' (get) Token: 0x06000189 RID: 393 RVA: 0x00004626 File Offset: 0x00002826
			' (set) Token: 0x06000313 RID: 787 RVA: 0x00008538 File Offset: 0x00006738
			Public Property frmStock_TransferRecord As frmStock_TransferRecord
				<DebuggerHidden()>
				Get
					Me.m_frmStock_TransferRecord = MyProject.MyForms.Create__Instance__(Of frmStock_TransferRecord)(Me.m_frmStock_TransferRecord)
					Return Me.m_frmStock_TransferRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmStock_TransferRecord)
					If value IsNot Me.m_frmStock_TransferRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmStock_TransferRecord)(Me.m_frmStock_TransferRecord)
					End If
				End Set
			End Property

			' Token: 0x1700015B RID: 347
			' (get) Token: 0x0600018A RID: 394 RVA: 0x00004641 File Offset: 0x00002841
			' (set) Token: 0x06000314 RID: 788 RVA: 0x00008564 File Offset: 0x00006764
			Public Property frmStockAdjustment_Store As frmStockAdjustment_Store
				<DebuggerHidden()>
				Get
					Me.m_frmStockAdjustment_Store = MyProject.MyForms.Create__Instance__(Of frmStockAdjustment_Store)(Me.m_frmStockAdjustment_Store)
					Return Me.m_frmStockAdjustment_Store
				End Get
				<DebuggerHidden()>
				Set(value As frmStockAdjustment_Store)
					If value IsNot Me.m_frmStockAdjustment_Store Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmStockAdjustment_Store)(Me.m_frmStockAdjustment_Store)
					End If
				End Set
			End Property

			' Token: 0x1700015C RID: 348
			' (get) Token: 0x0600018B RID: 395 RVA: 0x0000465C File Offset: 0x0000285C
			' (set) Token: 0x06000315 RID: 789 RVA: 0x00008590 File Offset: 0x00006790
			Public Property frmStockAdjustment_Store_Record As frmStockAdjustment_Store_Record
				<DebuggerHidden()>
				Get
					Me.m_frmStockAdjustment_Store_Record = MyProject.MyForms.Create__Instance__(Of frmStockAdjustment_Store_Record)(Me.m_frmStockAdjustment_Store_Record)
					Return Me.m_frmStockAdjustment_Store_Record
				End Get
				<DebuggerHidden()>
				Set(value As frmStockAdjustment_Store_Record)
					If value IsNot Me.m_frmStockAdjustment_Store_Record Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmStockAdjustment_Store_Record)(Me.m_frmStockAdjustment_Store_Record)
					End If
				End Set
			End Property

			' Token: 0x1700015D RID: 349
			' (get) Token: 0x0600018C RID: 396 RVA: 0x00004677 File Offset: 0x00002877
			' (set) Token: 0x06000316 RID: 790 RVA: 0x000085BC File Offset: 0x000067BC
			Public Property frmStockEntry As frmStockEntry
				<DebuggerHidden()>
				Get
					Me.m_frmStockEntry = MyProject.MyForms.Create__Instance__(Of frmStockEntry)(Me.m_frmStockEntry)
					Return Me.m_frmStockEntry
				End Get
				<DebuggerHidden()>
				Set(value As frmStockEntry)
					If value IsNot Me.m_frmStockEntry Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmStockEntry)(Me.m_frmStockEntry)
					End If
				End Set
			End Property

			' Token: 0x1700015E RID: 350
			' (get) Token: 0x0600018D RID: 397 RVA: 0x00004692 File Offset: 0x00002892
			' (set) Token: 0x06000317 RID: 791 RVA: 0x000085E8 File Offset: 0x000067E8
			Public Property frmStockEntryRecord As frmStockEntryRecord
				<DebuggerHidden()>
				Get
					Me.m_frmStockEntryRecord = MyProject.MyForms.Create__Instance__(Of frmStockEntryRecord)(Me.m_frmStockEntryRecord)
					Return Me.m_frmStockEntryRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmStockEntryRecord)
					If value IsNot Me.m_frmStockEntryRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmStockEntryRecord)(Me.m_frmStockEntryRecord)
					End If
				End Set
			End Property

			' Token: 0x1700015F RID: 351
			' (get) Token: 0x0600018E RID: 398 RVA: 0x000046AD File Offset: 0x000028AD
			' (set) Token: 0x06000318 RID: 792 RVA: 0x00008614 File Offset: 0x00006814
			Public Property frmStockEntryRecord1 As frmStockEntryRecord1
				<DebuggerHidden()>
				Get
					Me.m_frmStockEntryRecord1 = MyProject.MyForms.Create__Instance__(Of frmStockEntryRecord1)(Me.m_frmStockEntryRecord1)
					Return Me.m_frmStockEntryRecord1
				End Get
				<DebuggerHidden()>
				Set(value As frmStockEntryRecord1)
					If value IsNot Me.m_frmStockEntryRecord1 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmStockEntryRecord1)(Me.m_frmStockEntryRecord1)
					End If
				End Set
			End Property

			' Token: 0x17000160 RID: 352
			' (get) Token: 0x0600018F RID: 399 RVA: 0x000046C8 File Offset: 0x000028C8
			' (set) Token: 0x06000319 RID: 793 RVA: 0x00008640 File Offset: 0x00006840
			Public Property frmStockEntryReport As frmStockEntryReport
				<DebuggerHidden()>
				Get
					Me.m_frmStockEntryReport = MyProject.MyForms.Create__Instance__(Of frmStockEntryReport)(Me.m_frmStockEntryReport)
					Return Me.m_frmStockEntryReport
				End Get
				<DebuggerHidden()>
				Set(value As frmStockEntryReport)
					If value IsNot Me.m_frmStockEntryReport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmStockEntryReport)(Me.m_frmStockEntryReport)
					End If
				End Set
			End Property

			' Token: 0x17000161 RID: 353
			' (get) Token: 0x06000190 RID: 400 RVA: 0x000046E3 File Offset: 0x000028E3
			' (set) Token: 0x0600031A RID: 794 RVA: 0x0000866C File Offset: 0x0000686C
			Public Property frmStockInAndOutReport As frmStockInAndOutReport
				<DebuggerHidden()>
				Get
					Me.m_frmStockInAndOutReport = MyProject.MyForms.Create__Instance__(Of frmStockInAndOutReport)(Me.m_frmStockInAndOutReport)
					Return Me.m_frmStockInAndOutReport
				End Get
				<DebuggerHidden()>
				Set(value As frmStockInAndOutReport)
					If value IsNot Me.m_frmStockInAndOutReport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmStockInAndOutReport)(Me.m_frmStockInAndOutReport)
					End If
				End Set
			End Property

			' Token: 0x17000162 RID: 354
			' (get) Token: 0x06000191 RID: 401 RVA: 0x000046FE File Offset: 0x000028FE
			' (set) Token: 0x0600031B RID: 795 RVA: 0x00008698 File Offset: 0x00006898
			Public Property frmStockMovementReport As frmStockMovementReport
				<DebuggerHidden()>
				Get
					Me.m_frmStockMovementReport = MyProject.MyForms.Create__Instance__(Of frmStockMovementReport)(Me.m_frmStockMovementReport)
					Return Me.m_frmStockMovementReport
				End Get
				<DebuggerHidden()>
				Set(value As frmStockMovementReport)
					If value IsNot Me.m_frmStockMovementReport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmStockMovementReport)(Me.m_frmStockMovementReport)
					End If
				End Set
			End Property

			' Token: 0x17000163 RID: 355
			' (get) Token: 0x06000192 RID: 402 RVA: 0x00004719 File Offset: 0x00002919
			' (set) Token: 0x0600031C RID: 796 RVA: 0x000086C4 File Offset: 0x000068C4
			Public Property FrmStockOutPrint As FrmStockOutPrint
				<DebuggerHidden()>
				Get
					Me.m_FrmStockOutPrint = MyProject.MyForms.Create__Instance__(Of FrmStockOutPrint)(Me.m_FrmStockOutPrint)
					Return Me.m_FrmStockOutPrint
				End Get
				<DebuggerHidden()>
				Set(value As FrmStockOutPrint)
					If value IsNot Me.m_FrmStockOutPrint Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of FrmStockOutPrint)(Me.m_FrmStockOutPrint)
					End If
				End Set
			End Property

			' Token: 0x17000164 RID: 356
			' (get) Token: 0x06000193 RID: 403 RVA: 0x00004734 File Offset: 0x00002934
			' (set) Token: 0x0600031D RID: 797 RVA: 0x000086F0 File Offset: 0x000068F0
			Public Property frmStockTransfer As frmStockTransfer
				<DebuggerHidden()>
				Get
					Me.m_frmStockTransfer = MyProject.MyForms.Create__Instance__(Of frmStockTransfer)(Me.m_frmStockTransfer)
					Return Me.m_frmStockTransfer
				End Get
				<DebuggerHidden()>
				Set(value As frmStockTransfer)
					If value IsNot Me.m_frmStockTransfer Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmStockTransfer)(Me.m_frmStockTransfer)
					End If
				End Set
			End Property

			' Token: 0x17000165 RID: 357
			' (get) Token: 0x06000194 RID: 404 RVA: 0x0000474F File Offset: 0x0000294F
			' (set) Token: 0x0600031E RID: 798 RVA: 0x0000871C File Offset: 0x0000691C
			Public Property frmSubCategory As frmSubCategory
				<DebuggerHidden()>
				Get
					Me.m_frmSubCategory = MyProject.MyForms.Create__Instance__(Of frmSubCategory)(Me.m_frmSubCategory)
					Return Me.m_frmSubCategory
				End Get
				<DebuggerHidden()>
				Set(value As frmSubCategory)
					If value IsNot Me.m_frmSubCategory Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSubCategory)(Me.m_frmSubCategory)
					End If
				End Set
			End Property

			' Token: 0x17000166 RID: 358
			' (get) Token: 0x06000195 RID: 405 RVA: 0x0000476A File Offset: 0x0000296A
			' (set) Token: 0x0600031F RID: 799 RVA: 0x00008748 File Offset: 0x00006948
			Public Property frmSubcategory_DirectEntry As frmSubcategory_DirectEntry
				<DebuggerHidden()>
				Get
					Me.m_frmSubcategory_DirectEntry = MyProject.MyForms.Create__Instance__(Of frmSubcategory_DirectEntry)(Me.m_frmSubcategory_DirectEntry)
					Return Me.m_frmSubcategory_DirectEntry
				End Get
				<DebuggerHidden()>
				Set(value As frmSubcategory_DirectEntry)
					If value IsNot Me.m_frmSubcategory_DirectEntry Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSubcategory_DirectEntry)(Me.m_frmSubcategory_DirectEntry)
					End If
				End Set
			End Property

			' Token: 0x17000167 RID: 359
			' (get) Token: 0x06000196 RID: 406 RVA: 0x00004785 File Offset: 0x00002985
			' (set) Token: 0x06000320 RID: 800 RVA: 0x00008774 File Offset: 0x00006974
			Public Property frmSubCategoryNew As frmSubCategoryNew
				<DebuggerHidden()>
				Get
					Me.m_frmSubCategoryNew = MyProject.MyForms.Create__Instance__(Of frmSubCategoryNew)(Me.m_frmSubCategoryNew)
					Return Me.m_frmSubCategoryNew
				End Get
				<DebuggerHidden()>
				Set(value As frmSubCategoryNew)
					If value IsNot Me.m_frmSubCategoryNew Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSubCategoryNew)(Me.m_frmSubCategoryNew)
					End If
				End Set
			End Property

			' Token: 0x17000168 RID: 360
			' (get) Token: 0x06000197 RID: 407 RVA: 0x000047A0 File Offset: 0x000029A0
			' (set) Token: 0x06000321 RID: 801 RVA: 0x000087A0 File Offset: 0x000069A0
			Public Property frmSuplBalanceLedger As frmSuplBalanceLedger
				<DebuggerHidden()>
				Get
					Me.m_frmSuplBalanceLedger = MyProject.MyForms.Create__Instance__(Of frmSuplBalanceLedger)(Me.m_frmSuplBalanceLedger)
					Return Me.m_frmSuplBalanceLedger
				End Get
				<DebuggerHidden()>
				Set(value As frmSuplBalanceLedger)
					If value IsNot Me.m_frmSuplBalanceLedger Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSuplBalanceLedger)(Me.m_frmSuplBalanceLedger)
					End If
				End Set
			End Property

			' Token: 0x17000169 RID: 361
			' (get) Token: 0x06000198 RID: 408 RVA: 0x000047BB File Offset: 0x000029BB
			' (set) Token: 0x06000322 RID: 802 RVA: 0x000087CC File Offset: 0x000069CC
			Public Property frmSupplier As frmSupplier
				<DebuggerHidden()>
				Get
					Me.m_frmSupplier = MyProject.MyForms.Create__Instance__(Of frmSupplier)(Me.m_frmSupplier)
					Return Me.m_frmSupplier
				End Get
				<DebuggerHidden()>
				Set(value As frmSupplier)
					If value IsNot Me.m_frmSupplier Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSupplier)(Me.m_frmSupplier)
					End If
				End Set
			End Property

			' Token: 0x1700016A RID: 362
			' (get) Token: 0x06000199 RID: 409 RVA: 0x000047D6 File Offset: 0x000029D6
			' (set) Token: 0x06000323 RID: 803 RVA: 0x000087F8 File Offset: 0x000069F8
			Public Property frmSupplierBulkUpdate As frmSupplierBulkUpdate
				<DebuggerHidden()>
				Get
					Me.m_frmSupplierBulkUpdate = MyProject.MyForms.Create__Instance__(Of frmSupplierBulkUpdate)(Me.m_frmSupplierBulkUpdate)
					Return Me.m_frmSupplierBulkUpdate
				End Get
				<DebuggerHidden()>
				Set(value As frmSupplierBulkUpdate)
					If value IsNot Me.m_frmSupplierBulkUpdate Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSupplierBulkUpdate)(Me.m_frmSupplierBulkUpdate)
					End If
				End Set
			End Property

			' Token: 0x1700016B RID: 363
			' (get) Token: 0x0600019A RID: 410 RVA: 0x000047F1 File Offset: 0x000029F1
			' (set) Token: 0x06000324 RID: 804 RVA: 0x00008824 File Offset: 0x00006A24
			Public Property frmSupplierContactList As frmSupplierContactList
				<DebuggerHidden()>
				Get
					Me.m_frmSupplierContactList = MyProject.MyForms.Create__Instance__(Of frmSupplierContactList)(Me.m_frmSupplierContactList)
					Return Me.m_frmSupplierContactList
				End Get
				<DebuggerHidden()>
				Set(value As frmSupplierContactList)
					If value IsNot Me.m_frmSupplierContactList Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSupplierContactList)(Me.m_frmSupplierContactList)
					End If
				End Set
			End Property

			' Token: 0x1700016C RID: 364
			' (get) Token: 0x0600019B RID: 411 RVA: 0x0000480C File Offset: 0x00002A0C
			' (set) Token: 0x06000325 RID: 805 RVA: 0x00008850 File Offset: 0x00006A50
			Public Property frmSupplierLedger As frmSupplierLedger
				<DebuggerHidden()>
				Get
					Me.m_frmSupplierLedger = MyProject.MyForms.Create__Instance__(Of frmSupplierLedger)(Me.m_frmSupplierLedger)
					Return Me.m_frmSupplierLedger
				End Get
				<DebuggerHidden()>
				Set(value As frmSupplierLedger)
					If value IsNot Me.m_frmSupplierLedger Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSupplierLedger)(Me.m_frmSupplierLedger)
					End If
				End Set
			End Property

			' Token: 0x1700016D RID: 365
			' (get) Token: 0x0600019C RID: 412 RVA: 0x00004827 File Offset: 0x00002A27
			' (set) Token: 0x06000326 RID: 806 RVA: 0x0000887C File Offset: 0x00006A7C
			Public Property frmSupplierOutstanding As frmSupplierOutstanding
				<DebuggerHidden()>
				Get
					Me.m_frmSupplierOutstanding = MyProject.MyForms.Create__Instance__(Of frmSupplierOutstanding)(Me.m_frmSupplierOutstanding)
					Return Me.m_frmSupplierOutstanding
				End Get
				<DebuggerHidden()>
				Set(value As frmSupplierOutstanding)
					If value IsNot Me.m_frmSupplierOutstanding Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSupplierOutstanding)(Me.m_frmSupplierOutstanding)
					End If
				End Set
			End Property

			' Token: 0x1700016E RID: 366
			' (get) Token: 0x0600019D RID: 413 RVA: 0x00004842 File Offset: 0x00002A42
			' (set) Token: 0x06000327 RID: 807 RVA: 0x000088A8 File Offset: 0x00006AA8
			Public Property frmSupplierRecord As frmSupplierRecord
				<DebuggerHidden()>
				Get
					Me.m_frmSupplierRecord = MyProject.MyForms.Create__Instance__(Of frmSupplierRecord)(Me.m_frmSupplierRecord)
					Return Me.m_frmSupplierRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmSupplierRecord)
					If value IsNot Me.m_frmSupplierRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSupplierRecord)(Me.m_frmSupplierRecord)
					End If
				End Set
			End Property

			' Token: 0x1700016F RID: 367
			' (get) Token: 0x0600019E RID: 414 RVA: 0x0000485D File Offset: 0x00002A5D
			' (set) Token: 0x06000328 RID: 808 RVA: 0x000088D4 File Offset: 0x00006AD4
			Public Property frmSuppliers As frmSuppliers
				<DebuggerHidden()>
				Get
					Me.m_frmSuppliers = MyProject.MyForms.Create__Instance__(Of frmSuppliers)(Me.m_frmSuppliers)
					Return Me.m_frmSuppliers
				End Get
				<DebuggerHidden()>
				Set(value As frmSuppliers)
					If value IsNot Me.m_frmSuppliers Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSuppliers)(Me.m_frmSuppliers)
					End If
				End Set
			End Property

			' Token: 0x17000170 RID: 368
			' (get) Token: 0x0600019F RID: 415 RVA: 0x00004878 File Offset: 0x00002A78
			' (set) Token: 0x06000329 RID: 809 RVA: 0x00008900 File Offset: 0x00006B00
			Public Property frmSupplierwise_report As frmSupplierwise_report
				<DebuggerHidden()>
				Get
					Me.m_frmSupplierwise_report = MyProject.MyForms.Create__Instance__(Of frmSupplierwise_report)(Me.m_frmSupplierwise_report)
					Return Me.m_frmSupplierwise_report
				End Get
				<DebuggerHidden()>
				Set(value As frmSupplierwise_report)
					If value IsNot Me.m_frmSupplierwise_report Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSupplierwise_report)(Me.m_frmSupplierwise_report)
					End If
				End Set
			End Property

			' Token: 0x17000171 RID: 369
			' (get) Token: 0x060001A0 RID: 416 RVA: 0x00004893 File Offset: 0x00002A93
			' (set) Token: 0x0600032A RID: 810 RVA: 0x0000892C File Offset: 0x00006B2C
			Public Property frmSystemInfo As frmSystemInfo
				<DebuggerHidden()>
				Get
					Me.m_frmSystemInfo = MyProject.MyForms.Create__Instance__(Of frmSystemInfo)(Me.m_frmSystemInfo)
					Return Me.m_frmSystemInfo
				End Get
				<DebuggerHidden()>
				Set(value As frmSystemInfo)
					If value IsNot Me.m_frmSystemInfo Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSystemInfo)(Me.m_frmSystemInfo)
					End If
				End Set
			End Property

			' Token: 0x17000172 RID: 370
			' (get) Token: 0x060001A1 RID: 417 RVA: 0x000048AE File Offset: 0x00002AAE
			' (set) Token: 0x0600032B RID: 811 RVA: 0x00008958 File Offset: 0x00006B58
			Public Property frmTaxCategory As frmTaxCategory
				<DebuggerHidden()>
				Get
					Me.m_frmTaxCategory = MyProject.MyForms.Create__Instance__(Of frmTaxCategory)(Me.m_frmTaxCategory)
					Return Me.m_frmTaxCategory
				End Get
				<DebuggerHidden()>
				Set(value As frmTaxCategory)
					If value IsNot Me.m_frmTaxCategory Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTaxCategory)(Me.m_frmTaxCategory)
					End If
				End Set
			End Property

			' Token: 0x17000173 RID: 371
			' (get) Token: 0x060001A2 RID: 418 RVA: 0x000048C9 File Offset: 0x00002AC9
			' (set) Token: 0x0600032C RID: 812 RVA: 0x00008984 File Offset: 0x00006B84
			Public Property frmTaxCategoryNew As frmTaxCategoryNew
				<DebuggerHidden()>
				Get
					Me.m_frmTaxCategoryNew = MyProject.MyForms.Create__Instance__(Of frmTaxCategoryNew)(Me.m_frmTaxCategoryNew)
					Return Me.m_frmTaxCategoryNew
				End Get
				<DebuggerHidden()>
				Set(value As frmTaxCategoryNew)
					If value IsNot Me.m_frmTaxCategoryNew Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTaxCategoryNew)(Me.m_frmTaxCategoryNew)
					End If
				End Set
			End Property

			' Token: 0x17000174 RID: 372
			' (get) Token: 0x060001A3 RID: 419 RVA: 0x000048E4 File Offset: 0x00002AE4
			' (set) Token: 0x0600032D RID: 813 RVA: 0x000089B0 File Offset: 0x00006BB0
			Public Property frmTaxReport As frmTaxReport
				<DebuggerHidden()>
				Get
					Me.m_frmTaxReport = MyProject.MyForms.Create__Instance__(Of frmTaxReport)(Me.m_frmTaxReport)
					Return Me.m_frmTaxReport
				End Get
				<DebuggerHidden()>
				Set(value As frmTaxReport)
					If value IsNot Me.m_frmTaxReport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTaxReport)(Me.m_frmTaxReport)
					End If
				End Set
			End Property

			' Token: 0x17000175 RID: 373
			' (get) Token: 0x060001A4 RID: 420 RVA: 0x000048FF File Offset: 0x00002AFF
			' (set) Token: 0x0600032E RID: 814 RVA: 0x000089DC File Offset: 0x00006BDC
			Public Property frmTaxSetting As frmTaxSetting
				<DebuggerHidden()>
				Get
					Me.m_frmTaxSetting = MyProject.MyForms.Create__Instance__(Of frmTaxSetting)(Me.m_frmTaxSetting)
					Return Me.m_frmTaxSetting
				End Get
				<DebuggerHidden()>
				Set(value As frmTaxSetting)
					If value IsNot Me.m_frmTaxSetting Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTaxSetting)(Me.m_frmTaxSetting)
					End If
				End Set
			End Property

			' Token: 0x17000176 RID: 374
			' (get) Token: 0x060001A5 RID: 421 RVA: 0x0000491A File Offset: 0x00002B1A
			' (set) Token: 0x0600032F RID: 815 RVA: 0x00008A08 File Offset: 0x00006C08
			Public Property frmTaxSettingsNew As frmTaxSettingsNew
				<DebuggerHidden()>
				Get
					Me.m_frmTaxSettingsNew = MyProject.MyForms.Create__Instance__(Of frmTaxSettingsNew)(Me.m_frmTaxSettingsNew)
					Return Me.m_frmTaxSettingsNew
				End Get
				<DebuggerHidden()>
				Set(value As frmTaxSettingsNew)
					If value IsNot Me.m_frmTaxSettingsNew Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTaxSettingsNew)(Me.m_frmTaxSettingsNew)
					End If
				End Set
			End Property

			' Token: 0x17000177 RID: 375
			' (get) Token: 0x060001A6 RID: 422 RVA: 0x00004935 File Offset: 0x00002B35
			' (set) Token: 0x06000330 RID: 816 RVA: 0x00008A34 File Offset: 0x00006C34
			Public Property frmTCSPurchase As frmTCSPurchase
				<DebuggerHidden()>
				Get
					Me.m_frmTCSPurchase = MyProject.MyForms.Create__Instance__(Of frmTCSPurchase)(Me.m_frmTCSPurchase)
					Return Me.m_frmTCSPurchase
				End Get
				<DebuggerHidden()>
				Set(value As frmTCSPurchase)
					If value IsNot Me.m_frmTCSPurchase Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTCSPurchase)(Me.m_frmTCSPurchase)
					End If
				End Set
			End Property

			' Token: 0x17000178 RID: 376
			' (get) Token: 0x060001A7 RID: 423 RVA: 0x00004950 File Offset: 0x00002B50
			' (set) Token: 0x06000331 RID: 817 RVA: 0x00008A60 File Offset: 0x00006C60
			Public Property frmTCSPurchaseReturn As frmTCSPurchaseReturn
				<DebuggerHidden()>
				Get
					Me.m_frmTCSPurchaseReturn = MyProject.MyForms.Create__Instance__(Of frmTCSPurchaseReturn)(Me.m_frmTCSPurchaseReturn)
					Return Me.m_frmTCSPurchaseReturn
				End Get
				<DebuggerHidden()>
				Set(value As frmTCSPurchaseReturn)
					If value IsNot Me.m_frmTCSPurchaseReturn Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTCSPurchaseReturn)(Me.m_frmTCSPurchaseReturn)
					End If
				End Set
			End Property

			' Token: 0x17000179 RID: 377
			' (get) Token: 0x060001A8 RID: 424 RVA: 0x0000496B File Offset: 0x00002B6B
			' (set) Token: 0x06000332 RID: 818 RVA: 0x00008A8C File Offset: 0x00006C8C
			Public Property frmTCSRcvd As frmTCSRcvd
				<DebuggerHidden()>
				Get
					Me.m_frmTCSRcvd = MyProject.MyForms.Create__Instance__(Of frmTCSRcvd)(Me.m_frmTCSRcvd)
					Return Me.m_frmTCSRcvd
				End Get
				<DebuggerHidden()>
				Set(value As frmTCSRcvd)
					If value IsNot Me.m_frmTCSRcvd Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTCSRcvd)(Me.m_frmTCSRcvd)
					End If
				End Set
			End Property

			' Token: 0x1700017A RID: 378
			' (get) Token: 0x060001A9 RID: 425 RVA: 0x00004986 File Offset: 0x00002B86
			' (set) Token: 0x06000333 RID: 819 RVA: 0x00008AB8 File Offset: 0x00006CB8
			Public Property frmTCSSaleReturn As frmTCSSaleReturn
				<DebuggerHidden()>
				Get
					Me.m_frmTCSSaleReturn = MyProject.MyForms.Create__Instance__(Of frmTCSSaleReturn)(Me.m_frmTCSSaleReturn)
					Return Me.m_frmTCSSaleReturn
				End Get
				<DebuggerHidden()>
				Set(value As frmTCSSaleReturn)
					If value IsNot Me.m_frmTCSSaleReturn Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTCSSaleReturn)(Me.m_frmTCSSaleReturn)
					End If
				End Set
			End Property

			' Token: 0x1700017B RID: 379
			' (get) Token: 0x060001AA RID: 426 RVA: 0x000049A1 File Offset: 0x00002BA1
			' (set) Token: 0x06000334 RID: 820 RVA: 0x00008AE4 File Offset: 0x00006CE4
			Public Property frmTCSValidation As frmTCSValidation
				<DebuggerHidden()>
				Get
					Me.m_frmTCSValidation = MyProject.MyForms.Create__Instance__(Of frmTCSValidation)(Me.m_frmTCSValidation)
					Return Me.m_frmTCSValidation
				End Get
				<DebuggerHidden()>
				Set(value As frmTCSValidation)
					If value IsNot Me.m_frmTCSValidation Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTCSValidation)(Me.m_frmTCSValidation)
					End If
				End Set
			End Property

			' Token: 0x1700017C RID: 380
			' (get) Token: 0x060001AB RID: 427 RVA: 0x000049BC File Offset: 0x00002BBC
			' (set) Token: 0x06000335 RID: 821 RVA: 0x00008B10 File Offset: 0x00006D10
			Public Property frmTempleteEdit As frmTempleteEdit
				<DebuggerHidden()>
				Get
					Me.m_frmTempleteEdit = MyProject.MyForms.Create__Instance__(Of frmTempleteEdit)(Me.m_frmTempleteEdit)
					Return Me.m_frmTempleteEdit
				End Get
				<DebuggerHidden()>
				Set(value As frmTempleteEdit)
					If value IsNot Me.m_frmTempleteEdit Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTempleteEdit)(Me.m_frmTempleteEdit)
					End If
				End Set
			End Property

			' Token: 0x1700017D RID: 381
			' (get) Token: 0x060001AC RID: 428 RVA: 0x000049D7 File Offset: 0x00002BD7
			' (set) Token: 0x06000336 RID: 822 RVA: 0x00008B3C File Offset: 0x00006D3C
			Public Property frmTerminalSetting As frmTerminalSetting
				<DebuggerHidden()>
				Get
					Me.m_frmTerminalSetting = MyProject.MyForms.Create__Instance__(Of frmTerminalSetting)(Me.m_frmTerminalSetting)
					Return Me.m_frmTerminalSetting
				End Get
				<DebuggerHidden()>
				Set(value As frmTerminalSetting)
					If value IsNot Me.m_frmTerminalSetting Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTerminalSetting)(Me.m_frmTerminalSetting)
					End If
				End Set
			End Property

			' Token: 0x1700017E RID: 382
			' (get) Token: 0x060001AD RID: 429 RVA: 0x000049F2 File Offset: 0x00002BF2
			' (set) Token: 0x06000337 RID: 823 RVA: 0x00008B68 File Offset: 0x00006D68
			Public Property frmTermsandCondn As frmTermsandCondn
				<DebuggerHidden()>
				Get
					Me.m_frmTermsandCondn = MyProject.MyForms.Create__Instance__(Of frmTermsandCondn)(Me.m_frmTermsandCondn)
					Return Me.m_frmTermsandCondn
				End Get
				<DebuggerHidden()>
				Set(value As frmTermsandCondn)
					If value IsNot Me.m_frmTermsandCondn Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTermsandCondn)(Me.m_frmTermsandCondn)
					End If
				End Set
			End Property

			' Token: 0x1700017F RID: 383
			' (get) Token: 0x060001AE RID: 430 RVA: 0x00004A0D File Offset: 0x00002C0D
			' (set) Token: 0x06000338 RID: 824 RVA: 0x00008B94 File Offset: 0x00006D94
			Public Property frmTest1 As frmTest1
				<DebuggerHidden()>
				Get
					Me.m_frmTest1 = MyProject.MyForms.Create__Instance__(Of frmTest1)(Me.m_frmTest1)
					Return Me.m_frmTest1
				End Get
				<DebuggerHidden()>
				Set(value As frmTest1)
					If value IsNot Me.m_frmTest1 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTest1)(Me.m_frmTest1)
					End If
				End Set
			End Property

			' Token: 0x17000180 RID: 384
			' (get) Token: 0x060001AF RID: 431 RVA: 0x00004A28 File Offset: 0x00002C28
			' (set) Token: 0x06000339 RID: 825 RVA: 0x00008BC0 File Offset: 0x00006DC0
			Public Property frmTestnew As frmTestnew
				<DebuggerHidden()>
				Get
					Me.m_frmTestnew = MyProject.MyForms.Create__Instance__(Of frmTestnew)(Me.m_frmTestnew)
					Return Me.m_frmTestnew
				End Get
				<DebuggerHidden()>
				Set(value As frmTestnew)
					If value IsNot Me.m_frmTestnew Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTestnew)(Me.m_frmTestnew)
					End If
				End Set
			End Property

			' Token: 0x17000181 RID: 385
			' (get) Token: 0x060001B0 RID: 432 RVA: 0x00004A43 File Offset: 0x00002C43
			' (set) Token: 0x0600033A RID: 826 RVA: 0x00008BEC File Offset: 0x00006DEC
			Public Property frmTokenIn As frmTokenIn
				<DebuggerHidden()>
				Get
					Me.m_frmTokenIn = MyProject.MyForms.Create__Instance__(Of frmTokenIn)(Me.m_frmTokenIn)
					Return Me.m_frmTokenIn
				End Get
				<DebuggerHidden()>
				Set(value As frmTokenIn)
					If value IsNot Me.m_frmTokenIn Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTokenIn)(Me.m_frmTokenIn)
					End If
				End Set
			End Property

			' Token: 0x17000182 RID: 386
			' (get) Token: 0x060001B1 RID: 433 RVA: 0x00004A5E File Offset: 0x00002C5E
			' (set) Token: 0x0600033B RID: 827 RVA: 0x00008C18 File Offset: 0x00006E18
			Public Property frmTokenOut As frmTokenOut
				<DebuggerHidden()>
				Get
					Me.m_frmTokenOut = MyProject.MyForms.Create__Instance__(Of frmTokenOut)(Me.m_frmTokenOut)
					Return Me.m_frmTokenOut
				End Get
				<DebuggerHidden()>
				Set(value As frmTokenOut)
					If value IsNot Me.m_frmTokenOut Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTokenOut)(Me.m_frmTokenOut)
					End If
				End Set
			End Property

			' Token: 0x17000183 RID: 387
			' (get) Token: 0x060001B2 RID: 434 RVA: 0x00004A79 File Offset: 0x00002C79
			' (set) Token: 0x0600033C RID: 828 RVA: 0x00008C44 File Offset: 0x00006E44
			Public Property frmTokenSettlement As frmTokenSettlement
				<DebuggerHidden()>
				Get
					Me.m_frmTokenSettlement = MyProject.MyForms.Create__Instance__(Of frmTokenSettlement)(Me.m_frmTokenSettlement)
					Return Me.m_frmTokenSettlement
				End Get
				<DebuggerHidden()>
				Set(value As frmTokenSettlement)
					If value IsNot Me.m_frmTokenSettlement Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTokenSettlement)(Me.m_frmTokenSettlement)
					End If
				End Set
			End Property

			' Token: 0x17000184 RID: 388
			' (get) Token: 0x060001B3 RID: 435 RVA: 0x00004A94 File Offset: 0x00002C94
			' (set) Token: 0x0600033D RID: 829 RVA: 0x00008C70 File Offset: 0x00006E70
			Public Property frmTouchProduct As frmTouchProduct
				<DebuggerHidden()>
				Get
					Me.m_frmTouchProduct = MyProject.MyForms.Create__Instance__(Of frmTouchProduct)(Me.m_frmTouchProduct)
					Return Me.m_frmTouchProduct
				End Get
				<DebuggerHidden()>
				Set(value As frmTouchProduct)
					If value IsNot Me.m_frmTouchProduct Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTouchProduct)(Me.m_frmTouchProduct)
					End If
				End Set
			End Property

			' Token: 0x17000185 RID: 389
			' (get) Token: 0x060001B4 RID: 436 RVA: 0x00004AAF File Offset: 0x00002CAF
			' (set) Token: 0x0600033E RID: 830 RVA: 0x00008C9C File Offset: 0x00006E9C
			Public Property frmTransport As frmTransport
				<DebuggerHidden()>
				Get
					Me.m_frmTransport = MyProject.MyForms.Create__Instance__(Of frmTransport)(Me.m_frmTransport)
					Return Me.m_frmTransport
				End Get
				<DebuggerHidden()>
				Set(value As frmTransport)
					If value IsNot Me.m_frmTransport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTransport)(Me.m_frmTransport)
					End If
				End Set
			End Property

			' Token: 0x17000186 RID: 390
			' (get) Token: 0x060001B5 RID: 437 RVA: 0x00004ACA File Offset: 0x00002CCA
			' (set) Token: 0x0600033F RID: 831 RVA: 0x00008CC8 File Offset: 0x00006EC8
			Public Property frmTrialBalance As frmTrialBalance
				<DebuggerHidden()>
				Get
					Me.m_frmTrialBalance = MyProject.MyForms.Create__Instance__(Of frmTrialBalance)(Me.m_frmTrialBalance)
					Return Me.m_frmTrialBalance
				End Get
				<DebuggerHidden()>
				Set(value As frmTrialBalance)
					If value IsNot Me.m_frmTrialBalance Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTrialBalance)(Me.m_frmTrialBalance)
					End If
				End Set
			End Property

			' Token: 0x17000187 RID: 391
			' (get) Token: 0x060001B6 RID: 438 RVA: 0x00004AE5 File Offset: 0x00002CE5
			' (set) Token: 0x06000340 RID: 832 RVA: 0x00008CF4 File Offset: 0x00006EF4
			Public Property frmUnit As frmUnit
				<DebuggerHidden()>
				Get
					Me.m_frmUnit = MyProject.MyForms.Create__Instance__(Of frmUnit)(Me.m_frmUnit)
					Return Me.m_frmUnit
				End Get
				<DebuggerHidden()>
				Set(value As frmUnit)
					If value IsNot Me.m_frmUnit Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmUnit)(Me.m_frmUnit)
					End If
				End Set
			End Property

			' Token: 0x17000188 RID: 392
			' (get) Token: 0x060001B7 RID: 439 RVA: 0x00004B00 File Offset: 0x00002D00
			' (set) Token: 0x06000341 RID: 833 RVA: 0x00008D20 File Offset: 0x00006F20
			Public Property frmUnitButton As frmUnitButton
				<DebuggerHidden()>
				Get
					Me.m_frmUnitButton = MyProject.MyForms.Create__Instance__(Of frmUnitButton)(Me.m_frmUnitButton)
					Return Me.m_frmUnitButton
				End Get
				<DebuggerHidden()>
				Set(value As frmUnitButton)
					If value IsNot Me.m_frmUnitButton Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmUnitButton)(Me.m_frmUnitButton)
					End If
				End Set
			End Property

			' Token: 0x17000189 RID: 393
			' (get) Token: 0x060001B8 RID: 440 RVA: 0x00004B1B File Offset: 0x00002D1B
			' (set) Token: 0x06000342 RID: 834 RVA: 0x00008D4C File Offset: 0x00006F4C
			Public Property frmUnitMasterNew As frmUnitMasterNew
				<DebuggerHidden()>
				Get
					Me.m_frmUnitMasterNew = MyProject.MyForms.Create__Instance__(Of frmUnitMasterNew)(Me.m_frmUnitMasterNew)
					Return Me.m_frmUnitMasterNew
				End Get
				<DebuggerHidden()>
				Set(value As frmUnitMasterNew)
					If value IsNot Me.m_frmUnitMasterNew Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmUnitMasterNew)(Me.m_frmUnitMasterNew)
					End If
				End Set
			End Property

			' Token: 0x1700018A RID: 394
			' (get) Token: 0x060001B9 RID: 441 RVA: 0x00004B36 File Offset: 0x00002D36
			' (set) Token: 0x06000343 RID: 835 RVA: 0x00008D78 File Offset: 0x00006F78
			Public Property frmUPIQRCodeImg As frmUPIQRCodeImg
				<DebuggerHidden()>
				Get
					Me.m_frmUPIQRCodeImg = MyProject.MyForms.Create__Instance__(Of frmUPIQRCodeImg)(Me.m_frmUPIQRCodeImg)
					Return Me.m_frmUPIQRCodeImg
				End Get
				<DebuggerHidden()>
				Set(value As frmUPIQRCodeImg)
					If value IsNot Me.m_frmUPIQRCodeImg Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmUPIQRCodeImg)(Me.m_frmUPIQRCodeImg)
					End If
				End Set
			End Property

			' Token: 0x1700018B RID: 395
			' (get) Token: 0x060001BA RID: 442 RVA: 0x00004B51 File Offset: 0x00002D51
			' (set) Token: 0x06000344 RID: 836 RVA: 0x00008DA4 File Offset: 0x00006FA4
			Public Property frmUserControl As frmUserControl
				<DebuggerHidden()>
				Get
					Me.m_frmUserControl = MyProject.MyForms.Create__Instance__(Of frmUserControl)(Me.m_frmUserControl)
					Return Me.m_frmUserControl
				End Get
				<DebuggerHidden()>
				Set(value As frmUserControl)
					If value IsNot Me.m_frmUserControl Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmUserControl)(Me.m_frmUserControl)
					End If
				End Set
			End Property

			' Token: 0x1700018C RID: 396
			' (get) Token: 0x060001BB RID: 443 RVA: 0x00004B6C File Offset: 0x00002D6C
			' (set) Token: 0x06000345 RID: 837 RVA: 0x00008DD0 File Offset: 0x00006FD0
			Public Property frmUserMenu_Control As frmUserMenu_Control
				<DebuggerHidden()>
				Get
					Me.m_frmUserMenu_Control = MyProject.MyForms.Create__Instance__(Of frmUserMenu_Control)(Me.m_frmUserMenu_Control)
					Return Me.m_frmUserMenu_Control
				End Get
				<DebuggerHidden()>
				Set(value As frmUserMenu_Control)
					If value IsNot Me.m_frmUserMenu_Control Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmUserMenu_Control)(Me.m_frmUserMenu_Control)
					End If
				End Set
			End Property

			' Token: 0x1700018D RID: 397
			' (get) Token: 0x060001BC RID: 444 RVA: 0x00004B87 File Offset: 0x00002D87
			' (set) Token: 0x06000346 RID: 838 RVA: 0x00008DFC File Offset: 0x00006FFC
			Public Property FrmValidate As FrmValidate
				<DebuggerHidden()>
				Get
					Me.m_FrmValidate = MyProject.MyForms.Create__Instance__(Of FrmValidate)(Me.m_FrmValidate)
					Return Me.m_FrmValidate
				End Get
				<DebuggerHidden()>
				Set(value As FrmValidate)
					If value IsNot Me.m_FrmValidate Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of FrmValidate)(Me.m_FrmValidate)
					End If
				End Set
			End Property

			' Token: 0x1700018E RID: 398
			' (get) Token: 0x060001BD RID: 445 RVA: 0x00004BA2 File Offset: 0x00002DA2
			' (set) Token: 0x06000347 RID: 839 RVA: 0x00008E28 File Offset: 0x00007028
			Public Property FrmValidate1 As FrmValidate1
				<DebuggerHidden()>
				Get
					Me.m_FrmValidate1 = MyProject.MyForms.Create__Instance__(Of FrmValidate1)(Me.m_FrmValidate1)
					Return Me.m_FrmValidate1
				End Get
				<DebuggerHidden()>
				Set(value As FrmValidate1)
					If value IsNot Me.m_FrmValidate1 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of FrmValidate1)(Me.m_FrmValidate1)
					End If
				End Set
			End Property

			' Token: 0x1700018F RID: 399
			' (get) Token: 0x060001BE RID: 446 RVA: 0x00004BBD File Offset: 0x00002DBD
			' (set) Token: 0x06000348 RID: 840 RVA: 0x00008E54 File Offset: 0x00007054
			Public Property frmVirtualCompany As frmVirtualCompany
				<DebuggerHidden()>
				Get
					Me.m_frmVirtualCompany = MyProject.MyForms.Create__Instance__(Of frmVirtualCompany)(Me.m_frmVirtualCompany)
					Return Me.m_frmVirtualCompany
				End Get
				<DebuggerHidden()>
				Set(value As frmVirtualCompany)
					If value IsNot Me.m_frmVirtualCompany Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmVirtualCompany)(Me.m_frmVirtualCompany)
					End If
				End Set
			End Property

			' Token: 0x17000190 RID: 400
			' (get) Token: 0x060001BF RID: 447 RVA: 0x00004BD8 File Offset: 0x00002DD8
			' (set) Token: 0x06000349 RID: 841 RVA: 0x00008E80 File Offset: 0x00007080
			Public Property frmVoucher As frmVoucher
				<DebuggerHidden()>
				Get
					Me.m_frmVoucher = MyProject.MyForms.Create__Instance__(Of frmVoucher)(Me.m_frmVoucher)
					Return Me.m_frmVoucher
				End Get
				<DebuggerHidden()>
				Set(value As frmVoucher)
					If value IsNot Me.m_frmVoucher Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmVoucher)(Me.m_frmVoucher)
					End If
				End Set
			End Property

			' Token: 0x17000191 RID: 401
			' (get) Token: 0x060001C0 RID: 448 RVA: 0x00004BF3 File Offset: 0x00002DF3
			' (set) Token: 0x0600034A RID: 842 RVA: 0x00008EAC File Offset: 0x000070AC
			Public Property frmVoucherRecord As frmVoucherRecord
				<DebuggerHidden()>
				Get
					Me.m_frmVoucherRecord = MyProject.MyForms.Create__Instance__(Of frmVoucherRecord)(Me.m_frmVoucherRecord)
					Return Me.m_frmVoucherRecord
				End Get
				<DebuggerHidden()>
				Set(value As frmVoucherRecord)
					If value IsNot Me.m_frmVoucherRecord Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmVoucherRecord)(Me.m_frmVoucherRecord)
					End If
				End Set
			End Property

			' Token: 0x17000192 RID: 402
			' (get) Token: 0x060001C1 RID: 449 RVA: 0x00004C0E File Offset: 0x00002E0E
			' (set) Token: 0x0600034B RID: 843 RVA: 0x00008ED8 File Offset: 0x000070D8
			Public Property frmVoucherReport As frmVoucherReport
				<DebuggerHidden()>
				Get
					Me.m_frmVoucherReport = MyProject.MyForms.Create__Instance__(Of frmVoucherReport)(Me.m_frmVoucherReport)
					Return Me.m_frmVoucherReport
				End Get
				<DebuggerHidden()>
				Set(value As frmVoucherReport)
					If value IsNot Me.m_frmVoucherReport Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmVoucherReport)(Me.m_frmVoucherReport)
					End If
				End Set
			End Property

			' Token: 0x17000193 RID: 403
			' (get) Token: 0x060001C2 RID: 450 RVA: 0x00004C29 File Offset: 0x00002E29
			' (set) Token: 0x0600034C RID: 844 RVA: 0x00008F04 File Offset: 0x00007104
			Public Property frmWalletList As frmWalletList
				<DebuggerHidden()>
				Get
					Me.m_frmWalletList = MyProject.MyForms.Create__Instance__(Of frmWalletList)(Me.m_frmWalletList)
					Return Me.m_frmWalletList
				End Get
				<DebuggerHidden()>
				Set(value As frmWalletList)
					If value IsNot Me.m_frmWalletList Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmWalletList)(Me.m_frmWalletList)
					End If
				End Set
			End Property

			' Token: 0x17000194 RID: 404
			' (get) Token: 0x060001C3 RID: 451 RVA: 0x00004C44 File Offset: 0x00002E44
			' (set) Token: 0x0600034D RID: 845 RVA: 0x00008F30 File Offset: 0x00007130
			Public Property frmWAppAPIServer As frmWAppAPIServer
				<DebuggerHidden()>
				Get
					Me.m_frmWAppAPIServer = MyProject.MyForms.Create__Instance__(Of frmWAppAPIServer)(Me.m_frmWAppAPIServer)
					Return Me.m_frmWAppAPIServer
				End Get
				<DebuggerHidden()>
				Set(value As frmWAppAPIServer)
					If value IsNot Me.m_frmWAppAPIServer Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmWAppAPIServer)(Me.m_frmWAppAPIServer)
					End If
				End Set
			End Property

			' Token: 0x17000195 RID: 405
			' (get) Token: 0x060001C4 RID: 452 RVA: 0x00004C5F File Offset: 0x00002E5F
			' (set) Token: 0x0600034E RID: 846 RVA: 0x00008F5C File Offset: 0x0000715C
			Public Property frmWAppAPIServer2 As frmWAppAPIServer2
				<DebuggerHidden()>
				Get
					Me.m_frmWAppAPIServer2 = MyProject.MyForms.Create__Instance__(Of frmWAppAPIServer2)(Me.m_frmWAppAPIServer2)
					Return Me.m_frmWAppAPIServer2
				End Get
				<DebuggerHidden()>
				Set(value As frmWAppAPIServer2)
					If value IsNot Me.m_frmWAppAPIServer2 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmWAppAPIServer2)(Me.m_frmWAppAPIServer2)
					End If
				End Set
			End Property

			' Token: 0x17000196 RID: 406
			' (get) Token: 0x060001C5 RID: 453 RVA: 0x00004C7A File Offset: 0x00002E7A
			' (set) Token: 0x0600034F RID: 847 RVA: 0x00008F88 File Offset: 0x00007188
			Public Property frmWhatsappMessage As frmWhatsappMessage
				<DebuggerHidden()>
				Get
					Me.m_frmWhatsappMessage = MyProject.MyForms.Create__Instance__(Of frmWhatsappMessage)(Me.m_frmWhatsappMessage)
					Return Me.m_frmWhatsappMessage
				End Get
				<DebuggerHidden()>
				Set(value As frmWhatsappMessage)
					If value IsNot Me.m_frmWhatsappMessage Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmWhatsappMessage)(Me.m_frmWhatsappMessage)
					End If
				End Set
			End Property

			' Token: 0x17000197 RID: 407
			' (get) Token: 0x060001C6 RID: 454 RVA: 0x00004C95 File Offset: 0x00002E95
			' (set) Token: 0x06000350 RID: 848 RVA: 0x00008FB4 File Offset: 0x000071B4
			Public Property frmYesNo As frmYesNo
				<DebuggerHidden()>
				Get
					Me.m_frmYesNo = MyProject.MyForms.Create__Instance__(Of frmYesNo)(Me.m_frmYesNo)
					Return Me.m_frmYesNo
				End Get
				<DebuggerHidden()>
				Set(value As frmYesNo)
					If value IsNot Me.m_frmYesNo Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmYesNo)(Me.m_frmYesNo)
					End If
				End Set
			End Property

			' Token: 0x17000198 RID: 408
			' (get) Token: 0x060001C7 RID: 455 RVA: 0x00004CB0 File Offset: 0x00002EB0
			' (set) Token: 0x06000351 RID: 849 RVA: 0x00008FE0 File Offset: 0x000071E0
			Public Property fromItemoffervalid As fromItemoffervalid
				<DebuggerHidden()>
				Get
					Me.m_fromItemoffervalid = MyProject.MyForms.Create__Instance__(Of fromItemoffervalid)(Me.m_fromItemoffervalid)
					Return Me.m_fromItemoffervalid
				End Get
				<DebuggerHidden()>
				Set(value As fromItemoffervalid)
					If value IsNot Me.m_fromItemoffervalid Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of fromItemoffervalid)(Me.m_fromItemoffervalid)
					End If
				End Set
			End Property

			' Token: 0x17000199 RID: 409
			' (get) Token: 0x060001C8 RID: 456 RVA: 0x00004CCB File Offset: 0x00002ECB
			' (set) Token: 0x06000352 RID: 850 RVA: 0x0000900C File Offset: 0x0000720C
			Public Property GSTCalculator As GSTCalculator
				<DebuggerHidden()>
				Get
					Me.m_GSTCalculator = MyProject.MyForms.Create__Instance__(Of GSTCalculator)(Me.m_GSTCalculator)
					Return Me.m_GSTCalculator
				End Get
				<DebuggerHidden()>
				Set(value As GSTCalculator)
					If value IsNot Me.m_GSTCalculator Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of GSTCalculator)(Me.m_GSTCalculator)
					End If
				End Set
			End Property

			' Token: 0x1700019A RID: 410
			' (get) Token: 0x060001C9 RID: 457 RVA: 0x00004CE6 File Offset: 0x00002EE6
			' (set) Token: 0x06000353 RID: 851 RVA: 0x00009038 File Offset: 0x00007238
			Public Property GSTPurchaseRegister As GSTPurchaseRegister
				<DebuggerHidden()>
				Get
					Me.m_GSTPurchaseRegister = MyProject.MyForms.Create__Instance__(Of GSTPurchaseRegister)(Me.m_GSTPurchaseRegister)
					Return Me.m_GSTPurchaseRegister
				End Get
				<DebuggerHidden()>
				Set(value As GSTPurchaseRegister)
					If value IsNot Me.m_GSTPurchaseRegister Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of GSTPurchaseRegister)(Me.m_GSTPurchaseRegister)
					End If
				End Set
			End Property

			' Token: 0x1700019B RID: 411
			' (get) Token: 0x060001CA RID: 458 RVA: 0x00004D01 File Offset: 0x00002F01
			' (set) Token: 0x06000354 RID: 852 RVA: 0x00009064 File Offset: 0x00007264
			Public Property GSTPurchaseReturn As GSTPurchaseReturn
				<DebuggerHidden()>
				Get
					Me.m_GSTPurchaseReturn = MyProject.MyForms.Create__Instance__(Of GSTPurchaseReturn)(Me.m_GSTPurchaseReturn)
					Return Me.m_GSTPurchaseReturn
				End Get
				<DebuggerHidden()>
				Set(value As GSTPurchaseReturn)
					If value IsNot Me.m_GSTPurchaseReturn Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of GSTPurchaseReturn)(Me.m_GSTPurchaseReturn)
					End If
				End Set
			End Property

			' Token: 0x1700019C RID: 412
			' (get) Token: 0x060001CB RID: 459 RVA: 0x00004D1C File Offset: 0x00002F1C
			' (set) Token: 0x06000355 RID: 853 RVA: 0x00009090 File Offset: 0x00007290
			Public Property GSTSaleRegister As GSTSaleRegister
				<DebuggerHidden()>
				Get
					Me.m_GSTSaleRegister = MyProject.MyForms.Create__Instance__(Of GSTSaleRegister)(Me.m_GSTSaleRegister)
					Return Me.m_GSTSaleRegister
				End Get
				<DebuggerHidden()>
				Set(value As GSTSaleRegister)
					If value IsNot Me.m_GSTSaleRegister Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of GSTSaleRegister)(Me.m_GSTSaleRegister)
					End If
				End Set
			End Property

			' Token: 0x1700019D RID: 413
			' (get) Token: 0x060001CC RID: 460 RVA: 0x00004D37 File Offset: 0x00002F37
			' (set) Token: 0x06000356 RID: 854 RVA: 0x000090BC File Offset: 0x000072BC
			Public Property GSTSaleReturn As GSTSaleReturn
				<DebuggerHidden()>
				Get
					Me.m_GSTSaleReturn = MyProject.MyForms.Create__Instance__(Of GSTSaleReturn)(Me.m_GSTSaleReturn)
					Return Me.m_GSTSaleReturn
				End Get
				<DebuggerHidden()>
				Set(value As GSTSaleReturn)
					If value IsNot Me.m_GSTSaleReturn Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of GSTSaleReturn)(Me.m_GSTSaleReturn)
					End If
				End Set
			End Property

			' Token: 0x1700019E RID: 414
			' (get) Token: 0x060001CD RID: 461 RVA: 0x00004D52 File Offset: 0x00002F52
			' (set) Token: 0x06000357 RID: 855 RVA: 0x000090E8 File Offset: 0x000072E8
			Public Property QRGenerator As QRGenerator
				<DebuggerHidden()>
				Get
					Me.m_QRGenerator = MyProject.MyForms.Create__Instance__(Of QRGenerator)(Me.m_QRGenerator)
					Return Me.m_QRGenerator
				End Get
				<DebuggerHidden()>
				Set(value As QRGenerator)
					If value IsNot Me.m_QRGenerator Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of QRGenerator)(Me.m_QRGenerator)
					End If
				End Set
			End Property

			' Token: 0x1700019F RID: 415
			' (get) Token: 0x060001CE RID: 462 RVA: 0x00004D6D File Offset: 0x00002F6D
			' (set) Token: 0x06000358 RID: 856 RVA: 0x00009114 File Offset: 0x00007314
			Public Property Receiver As Receiver
				<DebuggerHidden()>
				Get
					Me.m_Receiver = MyProject.MyForms.Create__Instance__(Of Receiver)(Me.m_Receiver)
					Return Me.m_Receiver
				End Get
				<DebuggerHidden()>
				Set(value As Receiver)
					If value IsNot Me.m_Receiver Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Receiver)(Me.m_Receiver)
					End If
				End Set
			End Property

			' Token: 0x04000016 RID: 22
			<ThreadStatic()>
			Private Shared m_FormBeingCreated As Hashtable

			' Token: 0x04000017 RID: 23
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_BalanceSheetForm As BalanceSheetForm

			' Token: 0x04000018 RID: 24
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_btnGetData As btnGetData

			' Token: 0x04000019 RID: 25
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Calculator As Calculator

			' Token: 0x0400001A RID: 26
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Calender As Calender

			' Token: 0x0400001B RID: 27
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Cashrefund As Cashrefund

			' Token: 0x0400001C RID: 28
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Denomination As Denomination

			' Token: 0x0400001D RID: 29
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Error5 As Error5

			' Token: 0x0400001E RID: 30
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Error6 As Error6

			' Token: 0x0400001F RID: 31
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Error8 As Error8

			' Token: 0x04000020 RID: 32
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Form As Form

			' Token: 0x04000021 RID: 33
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Form1 As Form1

			' Token: 0x04000022 RID: 34
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Form2 As Form2

			' Token: 0x04000023 RID: 35
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Form3 As Form3

			' Token: 0x04000024 RID: 36
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Form4 As Form4

			' Token: 0x04000025 RID: 37
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_FormCamera As FormCamera

			' Token: 0x04000026 RID: 38
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmAbout As frmAbout

			' Token: 0x04000027 RID: 39
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmAccountHead As frmAccountHead

			' Token: 0x04000028 RID: 40
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmAdvanceEntry As frmAdvanceEntry

			' Token: 0x04000029 RID: 41
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmAdvanceEntryRecord As frmAdvanceEntryRecord

			' Token: 0x0400002A RID: 42
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmAdvanceEntryReport As frmAdvanceEntryReport

			' Token: 0x0400002B RID: 43
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_FrmApp As FrmApp

			' Token: 0x0400002C RID: 44
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmAttendance As frmAttendance

			' Token: 0x0400002D RID: 45
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmAttendanceEntryRecord As frmAttendanceEntryRecord

			' Token: 0x0400002E RID: 46
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmAuto_Migrate As frmAuto_Migrate

			' Token: 0x0400002F RID: 47
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmAutobackup As frmAutobackup

			' Token: 0x04000030 RID: 48
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmAutoRoundoff As frmAutoRoundoff

			' Token: 0x04000031 RID: 49
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmAutoUPI As frmAutoUPI

			' Token: 0x04000032 RID: 50
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBagBox As frmBagBox

			' Token: 0x04000033 RID: 51
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBalancesheet As frmBalancesheet

			' Token: 0x04000034 RID: 52
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBanarCreate As frmBanarCreate

			' Token: 0x04000035 RID: 53
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBank As frmBank

			' Token: 0x04000036 RID: 54
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBankAccountRegistration As frmBankAccountRegistration

			' Token: 0x04000037 RID: 55
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBankAccountStatements As frmBankAccountStatements

			' Token: 0x04000038 RID: 56
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBankLedger As frmBankLedger

			' Token: 0x04000039 RID: 57
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBankList As frmBankList

			' Token: 0x0400003A RID: 58
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBarcodeLabelPrinting As frmBarcodeLabelPrinting

			' Token: 0x0400003B RID: 59
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBarcodeLabelPrintingnew As frmBarcodeLabelPrintingnew

			' Token: 0x0400003C RID: 60
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBarcodeMain As frmBarcodeMain

			' Token: 0x0400003D RID: 61
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBestAndLowSellingItemsReport As frmBestAndLowSellingItemsReport

			' Token: 0x0400003E RID: 62
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBillStyle As frmBillStyle

			' Token: 0x0400003F RID: 63
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBillSundry As frmBillSundry

			' Token: 0x04000040 RID: 64
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBIllwise_ProfitReport As frmBIllwise_ProfitReport

			' Token: 0x04000041 RID: 65
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBranch_AddMaster As frmBranch_AddMaster

			' Token: 0x04000042 RID: 66
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBranchAdmin As frmBranchAdmin

			' Token: 0x04000043 RID: 67
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBranchMaster_Bank As frmBranchMaster_Bank

			' Token: 0x04000044 RID: 68
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBranchReport_Dashboard As frmBranchReport_Dashboard

			' Token: 0x04000045 RID: 69
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBroker As frmBroker

			' Token: 0x04000046 RID: 70
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBrokerCalc As frmBrokerCalc

			' Token: 0x04000047 RID: 71
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBrokerLedger As frmBrokerLedger

			' Token: 0x04000048 RID: 72
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBulkPriceChange As frmBulkPriceChange

			' Token: 0x04000049 RID: 73
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBulkProductSeting As frmBulkProductSeting

			' Token: 0x0400004A RID: 74
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBulkWapp2CrCustomer As frmBulkWapp2CrCustomer

			' Token: 0x0400004B RID: 75
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmBulkWhatsappDoc As frmBulkWhatsappDoc

			' Token: 0x0400004C RID: 76
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCamera As frmCamera

			' Token: 0x0400004D RID: 77
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCashLedger As frmCashLedger

			' Token: 0x0400004E RID: 78
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCategory As frmCategory

			' Token: 0x0400004F RID: 79
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCategoryNew As frmCategoryNew

			' Token: 0x04000050 RID: 80
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCategoryPopup As frmCategoryPopup

			' Token: 0x04000051 RID: 81
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCatlogStyle As frmCatlogStyle

			' Token: 0x04000052 RID: 82
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmChangePassword As frmChangePassword

			' Token: 0x04000053 RID: 83
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmChat As frmChat

			' Token: 0x04000054 RID: 84
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmChat1 As frmChat1

			' Token: 0x04000055 RID: 85
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmChat2 As frmChat2

			' Token: 0x04000056 RID: 86
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmChat3 As frmChat3

			' Token: 0x04000057 RID: 87
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmChat4 As frmChat4

			' Token: 0x04000058 RID: 88
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCipherSetting As frmCipherSetting

			' Token: 0x04000059 RID: 89
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmComboPack As frmComboPack

			' Token: 0x0400005A RID: 90
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmComboPackBarcode As frmComboPackBarcode

			' Token: 0x0400005B RID: 91
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmComboPackMaster As frmComboPackMaster

			' Token: 0x0400005C RID: 92
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCompany As frmCompany

			' Token: 0x0400005D RID: 93
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCompanyDelete As frmCompanyDelete

			' Token: 0x0400005E RID: 94
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCompanyupdate As frmCompanyupdate

			' Token: 0x0400005F RID: 95
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmContactPhoto As frmContactPhoto

			' Token: 0x04000060 RID: 96
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmContacts As frmContacts

			' Token: 0x04000061 RID: 97
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmContra As frmContra

			' Token: 0x04000062 RID: 98
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmConvert_Language As frmConvert_Language

			' Token: 0x04000063 RID: 99
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCouponApply As frmCouponApply

			' Token: 0x04000064 RID: 100
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCouponGenerate As frmCouponGenerate

			' Token: 0x04000065 RID: 101
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCreditCustomerReceipt As frmCreditCustomerReceipt

			' Token: 0x04000066 RID: 102
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCreditCustomerReceiptRecord As frmCreditCustomerReceiptRecord

			' Token: 0x04000067 RID: 103
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCreditCustomerSMS As frmCreditCustomerSMS

			' Token: 0x04000068 RID: 104
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCreditDebit As frmCreditDebit

			' Token: 0x04000069 RID: 105
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCreditTermsStatements As frmCreditTermsStatements

			' Token: 0x0400006A RID: 106
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCurrentStock As frmCurrentStock

			' Token: 0x0400006B RID: 107
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustBalanceLedger As frmCustBalanceLedger

			' Token: 0x0400006C RID: 108
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomDialog As frmCustomDialog

			' Token: 0x0400006D RID: 109
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomDialog1 As frmCustomDialog1

			' Token: 0x0400006E RID: 110
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomDialog2 As frmCustomDialog2

			' Token: 0x0400006F RID: 111
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomDialog3 As frmCustomDialog3

			' Token: 0x04000070 RID: 112
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomer As frmCustomer

			' Token: 0x04000071 RID: 113
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomerBulkUpdate As frmCustomerBulkUpdate

			' Token: 0x04000072 RID: 114
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomerContactList As frmCustomerContactList

			' Token: 0x04000073 RID: 115
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomerDiscRecord As frmCustomerDiscRecord

			' Token: 0x04000074 RID: 116
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomerLedger As frmCustomerLedger

			' Token: 0x04000075 RID: 117
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomerLedger_Loyalty As frmCustomerLedger_Loyalty

			' Token: 0x04000076 RID: 118
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomerMobileAppSender As frmCustomerMobileAppSender

			' Token: 0x04000077 RID: 119
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomerMobileRpt As frmCustomerMobileRpt

			' Token: 0x04000078 RID: 120
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomerOffer As frmCustomerOffer

			' Token: 0x04000079 RID: 121
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomerOutstanding As frmCustomerOutstanding

			' Token: 0x0400007A RID: 122
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomerRecord As frmCustomerRecord

			' Token: 0x0400007B RID: 123
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomerRoundover As frmCustomerRoundover

			' Token: 0x0400007C RID: 124
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomersNew As frmCustomersNew

			' Token: 0x0400007D RID: 125
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomerSupport As frmCustomerSupport

			' Token: 0x0400007E RID: 126
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomerSupport1 As frmCustomerSupport1

			' Token: 0x0400007F RID: 127
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomerSupportForm_Dashboard As frmCustomerSupportForm_Dashboard

			' Token: 0x04000080 RID: 128
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomerSupportLog As frmCustomerSupportLog

			' Token: 0x04000081 RID: 129
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomerSupportLog_Dashboard As frmCustomerSupportLog_Dashboard

			' Token: 0x04000082 RID: 130
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomerSupportLog_Report As frmCustomerSupportLog_Report

			' Token: 0x04000083 RID: 131
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomerValid As frmCustomerValid

			' Token: 0x04000084 RID: 132
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCustomiseBarcode As frmCustomiseBarcode

			' Token: 0x04000085 RID: 133
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmDamageProduct As frmDamageProduct

			' Token: 0x04000086 RID: 134
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmDebtorsReport As frmDebtorsReport

			' Token: 0x04000087 RID: 135
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmDeductionReport As frmDeductionReport

			' Token: 0x04000088 RID: 136
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmECategory As frmECategory

			' Token: 0x04000089 RID: 137
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEComSeting As frmEComSeting

			' Token: 0x0400008A RID: 138
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEmailDashboard As frmEmailDashboard

			' Token: 0x0400008B RID: 139
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEmailDashboard2 As frmEmailDashboard2

			' Token: 0x0400008C RID: 140
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEmailDashboard3 As frmEmailDashboard3

			' Token: 0x0400008D RID: 141
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEmailsender As frmEmailsender

			' Token: 0x0400008E RID: 142
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEmailSetting As frmEmailSetting

			' Token: 0x0400008F RID: 143
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEmailSetting_login As frmEmailSetting_login

			' Token: 0x04000090 RID: 144
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEMain As frmEMain

			' Token: 0x04000091 RID: 145
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEmployeePayment As frmEmployeePayment

			' Token: 0x04000092 RID: 146
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEmployeePaymentRecord As frmEmployeePaymentRecord

			' Token: 0x04000093 RID: 147
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEmployeePaymentReport As frmEmployeePaymentReport

			' Token: 0x04000094 RID: 148
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEmployeeRegistration As frmEmployeeRegistration

			' Token: 0x04000095 RID: 149
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEmployeesRecord As frmEmployeesRecord

			' Token: 0x04000096 RID: 150
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEProduct As frmEProduct

			' Token: 0x04000097 RID: 151
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEstimate As frmEstimate

			' Token: 0x04000098 RID: 152
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEstimateRecord As frmEstimateRecord

			' Token: 0x04000099 RID: 153
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEstimateRetrieve As frmEstimateRetrieve

			' Token: 0x0400009A RID: 154
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmESubCategory As frmESubCategory

			' Token: 0x0400009B RID: 155
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEWayBill As frmEWayBill

			' Token: 0x0400009C RID: 156
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEwayBillSetting As frmEwayBillSetting

			' Token: 0x0400009D RID: 157
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEwaysetting As frmEwaysetting

			' Token: 0x0400009E RID: 158
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmExpDashboard As frmExpDashboard

			' Token: 0x0400009F RID: 159
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmExportImportExcel_Customers As frmExportImportExcel_Customers

			' Token: 0x040000A0 RID: 160
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmExportImportExcel_OpeningStock As frmExportImportExcel_OpeningStock

			' Token: 0x040000A1 RID: 161
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmExportImportExcel_ProductsRecord As frmExportImportExcel_ProductsRecord

			' Token: 0x040000A2 RID: 162
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmExportImportExcel_ProductsRecord1 As frmExportImportExcel_ProductsRecord1

			' Token: 0x040000A3 RID: 163
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmExportImportExcel_Salesman As frmExportImportExcel_Salesman

			' Token: 0x040000A4 RID: 164
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmExportImportExcel_Suppliers As frmExportImportExcel_Suppliers

			' Token: 0x040000A5 RID: 165
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmFileupload As frmFileupload

			' Token: 0x040000A6 RID: 166
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmFollowUp_Lead As frmFollowUp_Lead

			' Token: 0x040000A7 RID: 167
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmFollowUp_LeadRecords As frmFollowUp_LeadRecords

			' Token: 0x040000A8 RID: 168
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmFormwise_Shortcutkey As frmFormwise_Shortcutkey

			' Token: 0x040000A9 RID: 169
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmFundDeposit As frmFundDeposit

			' Token: 0x040000AA RID: 170
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmFundTransfer As frmFundTransfer

			' Token: 0x040000AB RID: 171
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmFYChange As frmFYChange

			' Token: 0x040000AC RID: 172
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmGallery As frmGallery

			' Token: 0x040000AD RID: 173
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_FrmGDClientSample As FrmGDClientSample

			' Token: 0x040000AE RID: 174
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmGeneralDayBook As frmGeneralDayBook

			' Token: 0x040000AF RID: 175
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmGeneralLedger As frmGeneralLedger

			' Token: 0x040000B0 RID: 176
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmGift As frmGift

			' Token: 0x040000B1 RID: 177
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmGiftApply As frmGiftApply

			' Token: 0x040000B2 RID: 178
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmGiftCodeSender As frmGiftCodeSender

			' Token: 0x040000B3 RID: 179
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmGodownConfig As frmGodownConfig

			' Token: 0x040000B4 RID: 180
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmGodownInward As frmGodownInward

			' Token: 0x040000B5 RID: 181
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmGodownOutward As frmGodownOutward

			' Token: 0x040000B6 RID: 182
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmGoProduct As frmGoProduct

			' Token: 0x040000B7 RID: 183
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmGSheet_Report As frmGSheet_Report

			' Token: 0x040000B8 RID: 184
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmGSheet_Setting As frmGSheet_Setting

			' Token: 0x040000B9 RID: 185
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmGSTCalc As frmGSTCalc

			' Token: 0x040000BA RID: 186
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmGSTCalc1 As frmGSTCalc1

			' Token: 0x040000BB RID: 187
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmGSTDetails As frmGSTDetails

			' Token: 0x040000BC RID: 188
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmGSTDetailsPur As frmGSTDetailsPur

			' Token: 0x040000BD RID: 189
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmGstNonGst As frmGstNonGst

			' Token: 0x040000BE RID: 190
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmGSTR1 As frmGSTR1

			' Token: 0x040000BF RID: 191
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmGSTR1_HSNC As frmGSTR1_HSNC

			' Token: 0x040000C0 RID: 192
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmGSTR3B As frmGSTR3B

			' Token: 0x040000C1 RID: 193
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmHoldrecord As frmHoldrecord

			' Token: 0x040000C2 RID: 194
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmHoldrecord_Purchase As frmHoldrecord_Purchase

			' Token: 0x040000C3 RID: 195
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmImageReader As frmImageReader

			' Token: 0x040000C4 RID: 196
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmImportPro As frmImportPro

			' Token: 0x040000C5 RID: 197
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmIncome As frmIncome

			' Token: 0x040000C6 RID: 198
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmIncomeDashboard As frmIncomeDashboard

			' Token: 0x040000C7 RID: 199
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmIncomeRecord As frmIncomeRecord

			' Token: 0x040000C8 RID: 200
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmInEx As frmInEx

			' Token: 0x040000C9 RID: 201
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmInfoBrodcast As frmInfoBrodcast

			' Token: 0x040000CA RID: 202
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmInvCode As frmInvCode

			' Token: 0x040000CB RID: 203
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmInvoiceHeader As frmInvoiceHeader

			' Token: 0x040000CC RID: 204
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmInvoicePhoto As frmInvoicePhoto

			' Token: 0x040000CD RID: 205
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmKeyBord As frmKeyBord

			' Token: 0x040000CE RID: 206
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmKitchen_Section As frmKitchen_Section

			' Token: 0x040000CF RID: 207
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmLanChat As frmLanChat

			' Token: 0x040000D0 RID: 208
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmLCardIssue As frmLCardIssue

			' Token: 0x040000D1 RID: 209
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmLead2 As frmLead2

			' Token: 0x040000D2 RID: 210
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmLead_Product As frmLead_Product

			' Token: 0x040000D3 RID: 211
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmLead_Update As frmLead_Update

			' Token: 0x040000D4 RID: 212
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmLeadGenerate As frmLeadGenerate

			' Token: 0x040000D5 RID: 213
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmLeadGenerateRecord As frmLeadGenerateRecord

			' Token: 0x040000D6 RID: 214
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmLoading As frmLoading

			' Token: 0x040000D7 RID: 215
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmLogin As frmLogin

			' Token: 0x040000D8 RID: 216
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmLogs As frmLogs

			' Token: 0x040000D9 RID: 217
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmLoyaltySMS As frmLoyaltySMS

			' Token: 0x040000DA RID: 218
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmLoyaltyvalid As frmLoyaltyvalid

			' Token: 0x040000DB RID: 219
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmLSetDefault As frmLSetDefault

			' Token: 0x040000DC RID: 220
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmMainMenu As frmMainMenu

			' Token: 0x040000DD RID: 221
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmMenu_update As frmMenu_update

			' Token: 0x040000DE RID: 222
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmMenuHeader_update As frmMenuHeader_update

			' Token: 0x040000DF RID: 223
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmMigrate_test As frmMigrate_test

			' Token: 0x040000E0 RID: 224
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmMigratedb_auto As frmMigratedb_auto

			' Token: 0x040000E1 RID: 225
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmMine As frmMine

			' Token: 0x040000E2 RID: 226
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmMobileIDDialog As frmMobileIDDialog

			' Token: 0x040000E3 RID: 227
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmMRP_Purchase_Update As frmMRP_Purchase_Update

			' Token: 0x040000E4 RID: 228
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmMRPShow As frmMRPShow

			' Token: 0x040000E5 RID: 229
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmMRPShow_Serial As frmMRPShow_Serial

			' Token: 0x040000E6 RID: 230
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmMultiBillPayment As frmMultiBillPayment

			' Token: 0x040000E7 RID: 231
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmMultiBranchReport As frmMultiBranchReport

			' Token: 0x040000E8 RID: 232
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmMultiPaymentModeSettings As frmMultiPaymentModeSettings

			' Token: 0x040000E9 RID: 233
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmOfferMessage As frmOfferMessage

			' Token: 0x040000EA RID: 234
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmOnlineImage As frmOnlineImage

			' Token: 0x040000EB RID: 235
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmOrder As frmOrder

			' Token: 0x040000EC RID: 236
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmOtherSettings As frmOtherSettings

			' Token: 0x040000ED RID: 237
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPayment As frmPayment

			' Token: 0x040000EE RID: 238
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPayment_Withdrawal As frmPayment_Withdrawal

			' Token: 0x040000EF RID: 239
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPaymentRecord As frmPaymentRecord

			' Token: 0x040000F0 RID: 240
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPdfReader As frmPdfReader

			' Token: 0x040000F1 RID: 241
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPhonePeUPI As frmPhonePeUPI

			' Token: 0x040000F2 RID: 242
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPOS As frmPOS

			' Token: 0x040000F3 RID: 243
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPos_Cursor_Setting As frmPos_Cursor_Setting

			' Token: 0x040000F4 RID: 244
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPOS_Update As frmPOS_Update

			' Token: 0x040000F5 RID: 245
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPOSNew As frmPOSNew

			' Token: 0x040000F6 RID: 246
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPOSNewTuch As frmPOSNewTuch

			' Token: 0x040000F7 RID: 247
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPOSNewTuch_Quotation As frmPOSNewTuch_Quotation

			' Token: 0x040000F8 RID: 248
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPOSNewTuch_QuotationRecord As frmPOSNewTuch_QuotationRecord

			' Token: 0x040000F9 RID: 249
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPOSNewTuch_Service As frmPOSNewTuch_Service

			' Token: 0x040000FA RID: 250
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPOSNewTuch_StockInward As frmPOSNewTuch_StockInward

			' Token: 0x040000FB RID: 251
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPOSNewTuch_StockTransfer As frmPOSNewTuch_StockTransfer

			' Token: 0x040000FC RID: 252
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPostImport As frmPostImport

			' Token: 0x040000FD RID: 253
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPOSTouch As frmPOSTouch

			' Token: 0x040000FE RID: 254
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPrevSales As frmPrevSales

			' Token: 0x040000FF RID: 255
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPrinterSettings As frmPrinterSettings

			' Token: 0x04000100 RID: 256
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPrintLoyaltyCard As frmPrintLoyaltyCard

			' Token: 0x04000101 RID: 257
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProduct As frmProduct

			' Token: 0x04000102 RID: 258
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProductBulkUpdate As frmProductBulkUpdate

			' Token: 0x04000103 RID: 259
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProductBulkUpdate_GST As frmProductBulkUpdate_GST

			' Token: 0x04000104 RID: 260
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProductDefault As frmProductDefault

			' Token: 0x04000105 RID: 261
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProductDiscount As frmProductDiscount

			' Token: 0x04000106 RID: 262
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProductEntry As frmProductEntry

			' Token: 0x04000107 RID: 263
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProductImageMaker As frmProductImageMaker

			' Token: 0x04000108 RID: 264
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProductImageUpdator As frmProductImageUpdator

			' Token: 0x04000109 RID: 265
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProductLedgerPOS As frmProductLedgerPOS

			' Token: 0x0400010A RID: 266
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProductListWeigh As frmProductListWeigh

			' Token: 0x0400010B RID: 267
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProductNew As frmProductNew

			' Token: 0x0400010C RID: 268
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProductPlus As frmProductPlus

			' Token: 0x0400010D RID: 269
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProductRec As frmProductRec

			' Token: 0x0400010E RID: 270
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProductRec1 As frmProductRec1

			' Token: 0x0400010F RID: 271
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProductRec_serial As frmProductRec_serial

			' Token: 0x04000110 RID: 272
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProductRec_serial_sale As frmProductRec_serial_sale

			' Token: 0x04000111 RID: 273
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProductRec_variant As frmProductRec_variant

			' Token: 0x04000112 RID: 274
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProductRecord As frmProductRecord

			' Token: 0x04000113 RID: 275
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProductSeting As frmProductSeting

			' Token: 0x04000114 RID: 276
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProductSmart As frmProductSmart

			' Token: 0x04000115 RID: 277
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmProfitloss As frmProfitloss

			' Token: 0x04000116 RID: 278
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPromotionalOffers As frmPromotionalOffers

			' Token: 0x04000117 RID: 279
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPurchaseEntry As frmPurchaseEntry

			' Token: 0x04000118 RID: 280
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPurchaseOrder As frmPurchaseOrder

			' Token: 0x04000119 RID: 281
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPurchaseOrderRecord As frmPurchaseOrderRecord

			' Token: 0x0400011A RID: 282
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPurchaseRecord As frmPurchaseRecord

			' Token: 0x0400011B RID: 283
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPurchaseRecord_GSTR As frmPurchaseRecord_GSTR

			' Token: 0x0400011C RID: 284
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPurchaseReport As frmPurchaseReport

			' Token: 0x0400011D RID: 285
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPurchaseReturn As frmPurchaseReturn

			' Token: 0x0400011E RID: 286
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPurchaseReturnRecord As frmPurchaseReturnRecord

			' Token: 0x0400011F RID: 287
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPurchaseReturnRecord_GSTR As frmPurchaseReturnRecord_GSTR

			' Token: 0x04000120 RID: 288
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPurchaseStock As frmPurchaseStock

			' Token: 0x04000121 RID: 289
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPurchaseWiseMerge As frmPurchaseWiseMerge

			' Token: 0x04000122 RID: 290
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPurcOrderRetrieve As frmPurcOrderRetrieve

			' Token: 0x04000123 RID: 291
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmPurcOrderRetrieve1 As frmPurcOrderRetrieve1

			' Token: 0x04000124 RID: 292
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmQuotation As frmQuotation

			' Token: 0x04000125 RID: 293
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmQuotationRecord As frmQuotationRecord

			' Token: 0x04000126 RID: 294
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmQuotationRetrieve As frmQuotationRetrieve

			' Token: 0x04000127 RID: 295
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmRecoveryPassword As frmRecoveryPassword

			' Token: 0x04000128 RID: 296
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmRefundAmt As frmRefundAmt

			' Token: 0x04000129 RID: 297
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmRegistration As frmRegistration

			' Token: 0x0400012A RID: 298
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmReminder As frmReminder

			' Token: 0x0400012B RID: 299
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmReminderRecord As frmReminderRecord

			' Token: 0x0400012C RID: 300
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmReminderShow As frmReminderShow

			' Token: 0x0400012D RID: 301
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmReport As frmReport

			' Token: 0x0400012E RID: 302
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmRoute As frmRoute

			' Token: 0x0400012F RID: 303
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSalaryslip As frmSalaryslip

			' Token: 0x04000130 RID: 304
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSalarySlipsReport As frmSalarySlipsReport

			' Token: 0x04000131 RID: 305
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSaleAmtCal As frmSaleAmtCal

			' Token: 0x04000132 RID: 306
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSaleReport_Multi_Payment As frmSaleReport_Multi_Payment

			' Token: 0x04000133 RID: 307
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSales_ProductHistory As frmSales_ProductHistory

			' Token: 0x04000134 RID: 308
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSalesInvoiceRecord As frmSalesInvoiceRecord

			' Token: 0x04000135 RID: 309
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSalesInvoiceRecord_GSTR As frmSalesInvoiceRecord_GSTR

			' Token: 0x04000136 RID: 310
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSalesInvoiceRecordD As frmSalesInvoiceRecordD

			' Token: 0x04000137 RID: 311
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSalesman As frmSalesman

			' Token: 0x04000138 RID: 312
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSalesmanBulkUpdate As frmSalesmanBulkUpdate

			' Token: 0x04000139 RID: 313
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSalesmanCommmissionReport As frmSalesmanCommmissionReport

			' Token: 0x0400013A RID: 314
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSalesmanLedger As frmSalesmanLedger

			' Token: 0x0400013B RID: 315
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSalesmanLedgerNew As frmSalesmanLedgerNew

			' Token: 0x0400013C RID: 316
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSalesManPayment As frmSalesManPayment

			' Token: 0x0400013D RID: 317
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSalesManPaymentRecordNew As frmSalesManPaymentRecordNew

			' Token: 0x0400013E RID: 318
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSalesmanRecord As frmSalesmanRecord

			' Token: 0x0400013F RID: 319
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSalesPmtInfo As frmSalesPmtInfo

			' Token: 0x04000140 RID: 320
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSalesReport As frmSalesReport

			' Token: 0x04000141 RID: 321
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSalesReturn As frmSalesReturn

			' Token: 0x04000142 RID: 322
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSalesReturnRecord As frmSalesReturnRecord

			' Token: 0x04000143 RID: 323
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSalesReturnRecord_GSTR As frmSalesReturnRecord_GSTR

			' Token: 0x04000144 RID: 324
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmScrDsply As frmScrDsply

			' Token: 0x04000145 RID: 325
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmScreenlock As frmScreenlock

			' Token: 0x04000146 RID: 326
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSendEmail As frmSendEmail

			' Token: 0x04000147 RID: 327
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSendSMS_Sales As frmSendSMS_Sales

			' Token: 0x04000148 RID: 328
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSendSMS_Services As frmSendSMS_Services

			' Token: 0x04000149 RID: 329
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSerialno_popup As frmSerialno_popup

			' Token: 0x0400014A RID: 330
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSerialwiseReport As frmSerialwiseReport

			' Token: 0x0400014B RID: 331
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmServiceBilling As frmServiceBilling

			' Token: 0x0400014C RID: 332
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmServiceBillingRecord As frmServiceBillingRecord

			' Token: 0x0400014D RID: 333
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmServiceDoneReport As frmServiceDoneReport

			' Token: 0x0400014E RID: 334
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmServices As frmServices

			' Token: 0x0400014F RID: 335
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmServicesRecord As frmServicesRecord

			' Token: 0x04000150 RID: 336
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmServicesRecord1 As frmServicesRecord1

			' Token: 0x04000151 RID: 337
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSetBillDiscount As frmSetBillDiscount

			' Token: 0x04000152 RID: 338
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSMS As frmSMS

			' Token: 0x04000153 RID: 339
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSMS_AutoDetect As frmSMS_AutoDetect

			' Token: 0x04000154 RID: 340
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSMSSetting As frmSMSSetting

			' Token: 0x04000155 RID: 341
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSplash As frmSplash

			' Token: 0x04000156 RID: 342
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSqlServerSetting As frmSqlServerSetting

			' Token: 0x04000157 RID: 343
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmState As frmState

			' Token: 0x04000158 RID: 344
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmStock_Inward_Notification As frmStock_Inward_Notification

			' Token: 0x04000159 RID: 345
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmStock_Inward_Record As frmStock_Inward_Record

			' Token: 0x0400015A RID: 346
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmStock_Settlement As frmStock_Settlement

			' Token: 0x0400015B RID: 347
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmStock_TransferRecord As frmStock_TransferRecord

			' Token: 0x0400015C RID: 348
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmStockAdjustment_Store As frmStockAdjustment_Store

			' Token: 0x0400015D RID: 349
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmStockAdjustment_Store_Record As frmStockAdjustment_Store_Record

			' Token: 0x0400015E RID: 350
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmStockEntry As frmStockEntry

			' Token: 0x0400015F RID: 351
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmStockEntryRecord As frmStockEntryRecord

			' Token: 0x04000160 RID: 352
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmStockEntryRecord1 As frmStockEntryRecord1

			' Token: 0x04000161 RID: 353
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmStockEntryReport As frmStockEntryReport

			' Token: 0x04000162 RID: 354
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmStockInAndOutReport As frmStockInAndOutReport

			' Token: 0x04000163 RID: 355
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmStockMovementReport As frmStockMovementReport

			' Token: 0x04000164 RID: 356
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_FrmStockOutPrint As FrmStockOutPrint

			' Token: 0x04000165 RID: 357
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmStockTransfer As frmStockTransfer

			' Token: 0x04000166 RID: 358
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSubCategory As frmSubCategory

			' Token: 0x04000167 RID: 359
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSubcategory_DirectEntry As frmSubcategory_DirectEntry

			' Token: 0x04000168 RID: 360
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSubCategoryNew As frmSubCategoryNew

			' Token: 0x04000169 RID: 361
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSuplBalanceLedger As frmSuplBalanceLedger

			' Token: 0x0400016A RID: 362
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSupplier As frmSupplier

			' Token: 0x0400016B RID: 363
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSupplierBulkUpdate As frmSupplierBulkUpdate

			' Token: 0x0400016C RID: 364
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSupplierContactList As frmSupplierContactList

			' Token: 0x0400016D RID: 365
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSupplierLedger As frmSupplierLedger

			' Token: 0x0400016E RID: 366
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSupplierOutstanding As frmSupplierOutstanding

			' Token: 0x0400016F RID: 367
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSupplierRecord As frmSupplierRecord

			' Token: 0x04000170 RID: 368
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSuppliers As frmSuppliers

			' Token: 0x04000171 RID: 369
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSupplierwise_report As frmSupplierwise_report

			' Token: 0x04000172 RID: 370
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSystemInfo As frmSystemInfo

			' Token: 0x04000173 RID: 371
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTaxCategory As frmTaxCategory

			' Token: 0x04000174 RID: 372
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTaxCategoryNew As frmTaxCategoryNew

			' Token: 0x04000175 RID: 373
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTaxReport As frmTaxReport

			' Token: 0x04000176 RID: 374
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTaxSetting As frmTaxSetting

			' Token: 0x04000177 RID: 375
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTaxSettingsNew As frmTaxSettingsNew

			' Token: 0x04000178 RID: 376
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTCSPurchase As frmTCSPurchase

			' Token: 0x04000179 RID: 377
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTCSPurchaseReturn As frmTCSPurchaseReturn

			' Token: 0x0400017A RID: 378
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTCSRcvd As frmTCSRcvd

			' Token: 0x0400017B RID: 379
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTCSSaleReturn As frmTCSSaleReturn

			' Token: 0x0400017C RID: 380
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTCSValidation As frmTCSValidation

			' Token: 0x0400017D RID: 381
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTempleteEdit As frmTempleteEdit

			' Token: 0x0400017E RID: 382
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTerminalSetting As frmTerminalSetting

			' Token: 0x0400017F RID: 383
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTermsandCondn As frmTermsandCondn

			' Token: 0x04000180 RID: 384
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTest1 As frmTest1

			' Token: 0x04000181 RID: 385
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTestnew As frmTestnew

			' Token: 0x04000182 RID: 386
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTokenIn As frmTokenIn

			' Token: 0x04000183 RID: 387
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTokenOut As frmTokenOut

			' Token: 0x04000184 RID: 388
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTokenSettlement As frmTokenSettlement

			' Token: 0x04000185 RID: 389
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTouchProduct As frmTouchProduct

			' Token: 0x04000186 RID: 390
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTransport As frmTransport

			' Token: 0x04000187 RID: 391
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTrialBalance As frmTrialBalance

			' Token: 0x04000188 RID: 392
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmUnit As frmUnit

			' Token: 0x04000189 RID: 393
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmUnitButton As frmUnitButton

			' Token: 0x0400018A RID: 394
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmUnitMasterNew As frmUnitMasterNew

			' Token: 0x0400018B RID: 395
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmUPIQRCodeImg As frmUPIQRCodeImg

			' Token: 0x0400018C RID: 396
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmUserControl As frmUserControl

			' Token: 0x0400018D RID: 397
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmUserMenu_Control As frmUserMenu_Control

			' Token: 0x0400018E RID: 398
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_FrmValidate As FrmValidate

			' Token: 0x0400018F RID: 399
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_FrmValidate1 As FrmValidate1

			' Token: 0x04000190 RID: 400
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmVirtualCompany As frmVirtualCompany

			' Token: 0x04000191 RID: 401
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmVoucher As frmVoucher

			' Token: 0x04000192 RID: 402
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmVoucherRecord As frmVoucherRecord

			' Token: 0x04000193 RID: 403
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmVoucherReport As frmVoucherReport

			' Token: 0x04000194 RID: 404
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmWalletList As frmWalletList

			' Token: 0x04000195 RID: 405
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmWAppAPIServer As frmWAppAPIServer

			' Token: 0x04000196 RID: 406
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmWAppAPIServer2 As frmWAppAPIServer2

			' Token: 0x04000197 RID: 407
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmWhatsappMessage As frmWhatsappMessage

			' Token: 0x04000198 RID: 408
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmYesNo As frmYesNo

			' Token: 0x04000199 RID: 409
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_fromItemoffervalid As fromItemoffervalid

			' Token: 0x0400019A RID: 410
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_GSTCalculator As GSTCalculator

			' Token: 0x0400019B RID: 411
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_GSTPurchaseRegister As GSTPurchaseRegister

			' Token: 0x0400019C RID: 412
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_GSTPurchaseReturn As GSTPurchaseReturn

			' Token: 0x0400019D RID: 413
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_GSTSaleRegister As GSTSaleRegister

			' Token: 0x0400019E RID: 414
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_GSTSaleReturn As GSTSaleReturn

			' Token: 0x0400019F RID: 415
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_QRGenerator As QRGenerator

			' Token: 0x040001A0 RID: 416
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Receiver As Receiver
		End Class

		' Token: 0x0200000D RID: 13
		<EditorBrowsable(EditorBrowsableState.Never)>
		<MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")>
		Friend NotInheritable Class MyWebServices
			' Token: 0x06000359 RID: 857 RVA: 0x000813B0 File Offset: 0x0007F5B0
			<EditorBrowsable(EditorBrowsableState.Never)>
			<DebuggerHidden()>
			Public Overrides Function Equals(o As Object) As Boolean
				Return MyBase.Equals(RuntimeHelpers.GetObjectValue(o))
			End Function

			' Token: 0x0600035A RID: 858 RVA: 0x000813D0 File Offset: 0x0007F5D0
			<EditorBrowsable(EditorBrowsableState.Never)>
			<DebuggerHidden()>
			Public Overrides Function GetHashCode() As Integer
				Return MyBase.GetHashCode()
			End Function

			' Token: 0x0600035B RID: 859 RVA: 0x0008141C File Offset: 0x0007F61C
			<EditorBrowsable(EditorBrowsableState.Never)>
			<DebuggerHidden()>
			Friend Function [GetType]() As Type
				Return GetType(MyProject.MyWebServices)
			End Function

			' Token: 0x0600035C RID: 860 RVA: 0x00081404 File Offset: 0x0007F604
			<EditorBrowsable(EditorBrowsableState.Never)>
			<DebuggerHidden()>
			Public Overrides Function ToString() As String
				Return MyBase.ToString()
			End Function

			' Token: 0x0600035D RID: 861 RVA: 0x00081438 File Offset: 0x0007F638
			<DebuggerHidden()>
			Private Shared Function Create__Instance__(Of T As New)(instance As T) As T
				Dim flag As Boolean = instance Is Nothing
				Dim instResult As T
				If flag Then
					instResult = New T()
				Else
					instResult = instance
				End If
				Return instResult
			End Function

			' Token: 0x0600035E RID: 862 RVA: 0x00009140 File Offset: 0x00007340
			<DebuggerHidden()>
			Private Sub Dispose__Instance__(Of T)(ByRef instance As T)
				instance = Nothing
			End Sub

			' Token: 0x0600035F RID: 863 RVA: 0x000023F0 File Offset: 0x000005F0
			<DebuggerHidden()>
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Sub New()
			End Sub
		End Class

		' Token: 0x0200000E RID: 14
		<EditorBrowsable(EditorBrowsableState.Never)>
		<ComVisible(False)>
		Friend NotInheritable Class ThreadSafeObjectProvider(Of T As New)
			' Token: 0x170001A0 RID: 416
			' (get) Token: 0x06000360 RID: 864 RVA: 0x00081464 File Offset: 0x0007F664
			Friend ReadOnly Property GetInstance As T
				<DebuggerHidden()>
				Get
					Dim flag As Boolean = MyProject.ThreadSafeObjectProvider(Of T).m_ThreadStaticValue Is Nothing
					If flag Then
						MyProject.ThreadSafeObjectProvider(Of T).m_ThreadStaticValue = New T()
					End If
					Return MyProject.ThreadSafeObjectProvider(Of T).m_ThreadStaticValue
				End Get
			End Property

			' Token: 0x06000361 RID: 865 RVA: 0x000023F0 File Offset: 0x000005F0
			<DebuggerHidden()>
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Sub New()
			End Sub

			' Token: 0x040001A1 RID: 417
			<CompilerGenerated()>
			<ThreadStatic()>
			Private Shared m_ThreadStaticValue As T
		End Class
	End Module
End Namespace
