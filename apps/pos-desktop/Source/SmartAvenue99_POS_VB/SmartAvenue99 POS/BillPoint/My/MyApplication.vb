Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ApplicationServices

Namespace BillPoint.My
	' Token: 0x02000009 RID: 9
	<GeneratedCode("MyTemplate", "11.0.0.0")>
	<EditorBrowsable(EditorBrowsableState.Never)>
	Friend Class MyApplication
		Inherits WindowsFormsApplicationBase

		' Token: 0x06000034 RID: 52 RVA: 0x000811C0 File Offset: 0x0007F3C0
		<STAThread()>
		<DebuggerHidden()>
		<EditorBrowsable(EditorBrowsableState.Advanced)>
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Friend Shared Sub Main(Args As String())
			Try
				Global.System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering)
			Finally
			End Try
			Try
				System.IO.File.WriteAllText(System.Windows.Forms.Application.StartupPath + "\main_called.txt", "Main called with: " + Environment.CommandLine + vbCrLf)
			Catch
			End Try
			Try
				RetailLayouts.Install()
				MyProject.Application.Run(Args)
			Catch ex As Exception
				Try
					System.IO.File.WriteAllText(System.Windows.Forms.Application.StartupPath + "\global_crash.txt", ex.ToString())
				Catch
				End Try
			End Try
		End Sub

		' Token: 0x06000035 RID: 53 RVA: 0x0000235C File Offset: 0x0000055C
		<DebuggerStepThrough()>
		Public Sub New()
			MyBase.New(AuthenticationMode.ApplicationDefined)
			MyBase.IsSingleInstance = False
			MyBase.EnableVisualStyles = True
			MyBase.SaveMySettingsOnExit = True
			MyBase.ShutdownStyle = ShutdownMode.AfterAllFormsClose
		End Sub

		' Token: 0x06000036 RID: 54 RVA: 0x00002387 File Offset: 0x00000587
		<DebuggerStepThrough()>
		Protected Overrides Sub OnCreateMainForm()
			MyBase.MainForm = MyProject.Forms.frmSplash
		End Sub
	End Class
End Namespace
