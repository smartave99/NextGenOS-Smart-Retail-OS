Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic.CompilerServices
Imports MyDBLibrary

Namespace BillPoint
	' Token: 0x0200021C RID: 540
	Friend Module GlobalVariables
		' Token: 0x04004462 RID: 17506
		Public LoggedInLang_code As String

		' Token: 0x04004463 RID: 17507
		Public translations As Dictionary(Of String, String) = New Dictionary(Of String, String)()

		' Token: 0x04004464 RID: 17508
		Private helper As DBHelper = New DBHelper()

		' Token: 0x04004465 RID: 17509
		Private connStr As String = DBHelper.GetMasterConnectionString()

		' Token: 0x04004466 RID: 17510
		Public serverConnStrWithoutDB As String = GlobalVariables.connStr
	End Module
End Namespace
