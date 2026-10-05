Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Configuration
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint.My
	' Token: 0x02000010 RID: 16
	<CompilerGenerated()>
	<GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.6.0.0")>
	<EditorBrowsable(EditorBrowsableState.Advanced)>
	Friend NotInheritable Partial Class MySettings
		Inherits ApplicationSettingsBase

		' Token: 0x06000486 RID: 1158 RVA: 0x00084F44 File Offset: 0x00083144
		<DebuggerNonUserCode()>
		<EditorBrowsable(EditorBrowsableState.Advanced)>
		Private Shared Sub AutoSaveSettings(sender As Object, e As EventArgs)
			Dim saveMySettingsOnExit As Boolean = MyProject.Application.SaveMySettingsOnExit
			If saveMySettingsOnExit Then
				MySettingsProperty.Settings.Save()
			End If
		End Sub

		' Token: 0x170002C2 RID: 706
		' (get) Token: 0x06000487 RID: 1159 RVA: 0x00084F70 File Offset: 0x00083170
		Public Shared ReadOnly Property [Default] As MySettings
			Get
				Dim flag As Boolean = Not MySettings.addedHandler
				If flag Then
					Dim obj As Object = MySettings.addedHandlerLockObject
					ObjectFlowControl.CheckForSyncLockOnValueType(obj)
					SyncLock obj
						Dim flag3 As Boolean = Not MySettings.addedHandler
						If flag3 Then
							AddHandler MyProject.Application.Shutdown, AddressOf MySettings.AutoSaveSettings
							MySettings.addedHandler = True
						End If
					End SyncLock
				End If
				Return MySettings.defaultInstance
			End Get
		End Property

		' Token: 0x170002C3 RID: 707
		' (get) Token: 0x06000488 RID: 1160 RVA: 0x00084FFC File Offset: 0x000831FC
		<ApplicationScopedSetting()>
		<DebuggerNonUserCode()>
		<SpecialSetting(SpecialSetting.ConnectionString)>
		<DefaultSettingValue("Data Source=.\Sqlexpress;Initial Catalog=Inventory_DB;Integrated Security=True;MultipleActiveResultSets=True;")>
		Public ReadOnly Property Inventory_DBConnectionString1 As String
			Get
				Return Conversions.ToString(Me("Inventory_DBConnectionString1"))
			End Get
		End Property

		' Token: 0x170002C4 RID: 708
		' (get) Token: 0x06000489 RID: 1161 RVA: 0x00085020 File Offset: 0x00083220
		' (set) Token: 0x0600048A RID: 1162 RVA: 0x00009180 File Offset: 0x00007380
		<UserScopedSetting()>
		<DebuggerNonUserCode()>
		<DefaultSettingValue("False")>
		Public Property checked As Boolean
			Get
				Return Conversions.ToBoolean(Me("checked"))
			End Get
			Set(value As Boolean)
				Me("checked") = value
			End Set
		End Property

		' Token: 0x170002C5 RID: 709
		' (get) Token: 0x0600048B RID: 1163 RVA: 0x00085044 File Offset: 0x00083244
		' (set) Token: 0x0600048C RID: 1164 RVA: 0x00009195 File Offset: 0x00007395
		<UserScopedSetting()>
		<DebuggerNonUserCode()>
		<DefaultSettingValue("")>
		Public Property day As String
			Get
				Return Conversions.ToString(Me("day"))
			End Get
			Set(value As String)
				Me("day") = value
			End Set
		End Property

		' Token: 0x170002C6 RID: 710
		' (get) Token: 0x0600048D RID: 1165 RVA: 0x00085068 File Offset: 0x00083268
		' (set) Token: 0x0600048E RID: 1166 RVA: 0x000091A5 File Offset: 0x000073A5
		<UserScopedSetting()>
		<DebuggerNonUserCode()>
		<DefaultSettingValue("")>
		Public Property month As String
			Get
				Return Conversions.ToString(Me("month"))
			End Get
			Set(value As String)
				Me("month") = value
			End Set
		End Property

		' Token: 0x170002C7 RID: 711
		' (get) Token: 0x0600048F RID: 1167 RVA: 0x0008508C File Offset: 0x0008328C
		' (set) Token: 0x06000490 RID: 1168 RVA: 0x000091B5 File Offset: 0x000073B5
		<UserScopedSetting()>
		<DebuggerNonUserCode()>
		<DefaultSettingValue("")>
		Public Property year As String
			Get
				Return Conversions.ToString(Me("year"))
			End Get
			Set(value As String)
				Me("year") = value
			End Set
		End Property

		' Token: 0x170002C8 RID: 712
		' (get) Token: 0x06000491 RID: 1169 RVA: 0x000850B0 File Offset: 0x000832B0
		' (set) Token: 0x06000492 RID: 1170 RVA: 0x000091C5 File Offset: 0x000073C5
		<UserScopedSetting()>
		<DebuggerNonUserCode()>
		<DefaultSettingValue("")>
		Public Property setting As String
			Get
				Return Conversions.ToString(Me("setting"))
			End Get
			Set(value As String)
				Me("setting") = value
			End Set
		End Property

		' Token: 0x040001A4 RID: 420
		Private Shared defaultInstance As MySettings = CType(SettingsBase.Synchronized(New MySettings()), MySettings)

		' Token: 0x040001A5 RID: 421
		Private Shared addedHandler As Boolean

		' Token: 0x040001A6 RID: 422
		Private Shared addedHandlerLockObject As Object = RuntimeHelpers.GetObjectValue(New Object())
	End Class
End Namespace
