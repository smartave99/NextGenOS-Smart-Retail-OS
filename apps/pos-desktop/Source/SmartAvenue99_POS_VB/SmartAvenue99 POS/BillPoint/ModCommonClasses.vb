Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.CompilerServices
Imports MySql.Data.MySqlClient

Namespace BillPoint
	' Token: 0x020005E8 RID: 1512
	Friend Module ModCommonClasses
		' Token: 0x04007030 RID: 28720
		Public mycon As MySqlConnection = Nothing

		' Token: 0x04007031 RID: 28721
		Public mycmd As MySqlCommand = Nothing

		' Token: 0x04007032 RID: 28722
		Public myrdr As MySqlDataReader = Nothing

		' Token: 0x04007033 RID: 28723
		Public con As SqlConnection = Nothing

		' Token: 0x04007034 RID: 28724
		Public conn As SqlConnection = Nothing

		' Token: 0x04007035 RID: 28725
		Public con1 As SqlConnection = Nothing

		' Token: 0x04007036 RID: 28726
		Public con101 As SqlConnection = Nothing

		' Token: 0x04007037 RID: 28727
		Public con102 As SqlConnection = Nothing

		' Token: 0x04007038 RID: 28728
		Public con103 As SqlConnection = Nothing

		' Token: 0x04007039 RID: 28729
		Public con555 As SqlConnection = Nothing

		' Token: 0x0400703A RID: 28730
		Public con29 As SqlConnection = Nothing

		' Token: 0x0400703B RID: 28731
		Public cmd As SqlCommand

		' Token: 0x0400703C RID: 28732
		Public cmd1 As SqlCommand

		' Token: 0x0400703D RID: 28733
		Public cmd2 As SqlCommand

		' Token: 0x0400703E RID: 28734
		Public cmd101 As SqlCommand

		' Token: 0x0400703F RID: 28735
		Public cmd102 As SqlCommand

		' Token: 0x04007040 RID: 28736
		Public cmd103 As SqlCommand

		' Token: 0x04007041 RID: 28737
		Public cmd555 As SqlCommand

		' Token: 0x04007042 RID: 28738
		Public rdr As SqlDataReader = Nothing

		' Token: 0x04007043 RID: 28739
		Public rdr1 As SqlDataReader = Nothing

		' Token: 0x04007044 RID: 28740
		Public rdr29 As SqlDataReader = Nothing

		' Token: 0x04007045 RID: 28741
		Public rdr101 As SqlDataReader = Nothing

		' Token: 0x04007046 RID: 28742
		Public rdr102 As SqlDataReader = Nothing

		' Token: 0x04007047 RID: 28743
		Public rdr103 As SqlDataReader = Nothing

		' Token: 0x04007048 RID: 28744
		Public rdr555 As SqlDataReader = Nothing

		' Token: 0x04007049 RID: 28745
		Public rdr5551 As SqlDataReader = Nothing

		' Token: 0x0400704A RID: 28746
		Public ds As DataSet

		' Token: 0x0400704B RID: 28747
		Public adp As SqlDataAdapter

		' Token: 0x0400704C RID: 28748
		Public adp1 As SqlDataAdapter

		' Token: 0x0400704D RID: 28749
		Public adp2 As SqlDataAdapter

		' Token: 0x0400704E RID: 28750
		Public dtable As DataTable

		' Token: 0x0400704F RID: 28751
		Public dtable1 As DataTable

		' Token: 0x04007050 RID: 28752
		Public dtable2 As DataTable

		' Token: 0x04007051 RID: 28753
		Public TempFileNames2 As String
	End Module
End Namespace
