Imports System
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004F4 RID: 1268
	Friend Module ModCompanyMasterCS
		' Token: 0x06010461 RID: 66657 RVA: 0x009AF300 File Offset: 0x009AD500
		Public Function ReadCompanyCS() As String
			Dim array As String() = File.ReadAllLines(Application.StartupPath + "\SQLSettings.dat")
			ModCompanyMasterCS.st = array(0)
			ModCompanyMasterCS.st1 = array(1)
			ModCompanyMasterCS.st2 = array(2)
			ModCompanyMasterCS.CompanyCS = String.Concat(New String() { "Data Source=", ModCompanyMasterCS.st, ";Initial Catalog=RaintechMaster_DB;Integrated Security=False;User ID=", ModCompanyMasterCS.st1, ";Password=", ModCompanyMasterCS.st2, ";MultipleActiveResultSets=True", ";Max Pool Size=500" })
			Return ModCompanyMasterCS.CompanyCS
		End Function

		' Token: 0x040063F0 RID: 25584
		Private st As String

		' Token: 0x040063F1 RID: 25585
		Private st1 As String

		' Token: 0x040063F2 RID: 25586
		Private st2 As String

		' Token: 0x040063F3 RID: 25587
		Private CompanyCS As String

		' Token: 0x040063F4 RID: 25588
		Public CompnayMasterCS As String = ModCompanyMasterCS.ReadCompanyCS()
	End Module
End Namespace
