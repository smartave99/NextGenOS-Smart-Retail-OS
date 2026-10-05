Imports System
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Imports MyDBLibrary

Namespace BillPoint
	' Token: 0x020005E9 RID: 1513
	Friend Module ModCS
		' Token: 0x060129B9 RID: 76217 RVA: 0x00AB5E9C File Offset: 0x00AB409C
		Public Function ReadCS() As String
			Dim array As String() = File.ReadAllLines(Application.StartupPath + "\SQLSettings.dat")
			Dim array2 As String() = File.ReadAllLines(Application.StartupPath + "\TempDBSettings.dat")
			ModCS.st = array(0)
			ModCS.st1 = array(1)
			ModCS.st2 = array(2)
			ModCS.st4 = array2(0)
			ModCS.st3 = String.Concat(New String() { "Data Source=", ModCS.st, ";Initial Catalog=", ModCS.st4, ";Integrated Security=False;User ID=", ModCS.st1, ";Password=", ModCS.st2, ";MultipleActiveResultSets=True", ";Max Pool Size=500" })
			Return ModCS.st3
		End Function

		' Token: 0x060129BA RID: 76218 RVA: 0x00AB5F60 File Offset: 0x00AB4160
		Public Function ReadCS1() As String
			Dim array As String() = File.ReadAllLines(Application.StartupPath + "\TempDB.dat")
			ModCS.st5 = array(0)
			Return ModCS.st5
		End Function

		' Token: 0x060129BB RID: 76219 RVA: 0x00AB5F94 File Offset: 0x00AB4194
		Public Sub UpdateConnectionStringFromGrid(newDBName As String)
			Dim text As String = ModCS.helper.UpdateConnectionStringFromGrid(newDBName)
			ModCS.cs = text
		End Sub

		' Token: 0x060129BC RID: 76220 RVA: 0x0007F846 File Offset: 0x0007DA46
		Public Sub ResetToLocalDB()
			ModCS.cs = ModCS.ReadCS()
		End Sub

		' Token: 0x060129BD RID: 76221 RVA: 0x00AB5FB4 File Offset: 0x00AB41B4
		Public Function RaintechMaster_Online_connection() As String
			Return ModCS.helper.RaintechMaster_Online_connection()
		End Function

		' Token: 0x04007052 RID: 28754
		Private helper As DBHelper = New DBHelper()

		' Token: 0x04007053 RID: 28755
		Private st As String

		' Token: 0x04007054 RID: 28756
		Private st1 As String

		' Token: 0x04007055 RID: 28757
		Private st2 As String

		' Token: 0x04007056 RID: 28758
		Private st3 As String

		' Token: 0x04007057 RID: 28759
		Private st4 As String

		' Token: 0x04007058 RID: 28760
		Private st5 As String

		' Token: 0x04007059 RID: 28761
		Public cs As String = ModCS.ReadCS()

		' Token: 0x0400705A RID: 28762
		Public compupdateconn As String = ModCS.ReadCS()
	End Module
End Namespace
