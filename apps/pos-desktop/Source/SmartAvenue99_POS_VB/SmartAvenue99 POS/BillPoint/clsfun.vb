Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200001B RID: 27
	Public Class clsfun
		' Token: 0x0600079B RID: 1947 RVA: 0x0009E87C File Offset: 0x0009CA7C
		Public Shared Function ReadCS() As String
			Dim text As String
			Using streamReader As StreamReader = New StreamReader(Application.StartupPath + "\SQLSettings.dat")
				text = streamReader.ReadLine()
			End Using
			text = text
			Return text
		End Function

		' Token: 0x0600079C RID: 1948 RVA: 0x0009E8CC File Offset: 0x0009CACC
		Public Shared Function GetConnection() As SqlConnection
			clsfun.ReadCS()
			Dim text As String = clsfun.ReadCS()
			ModCommonClasses.con = New SqlConnection(text)
			ModCommonClasses.con.Open()
			Return ModCommonClasses.con
		End Function

		' Token: 0x0600079D RID: 1949 RVA: 0x0000A244 File Offset: 0x00008444
		Public Shared Sub CloseConnection()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x0600079E RID: 1950 RVA: 0x0009E908 File Offset: 0x0009CB08
		Public Shared Function ExecDataTable(cmdText As String) As DataTable
			Dim dataTable As DataTable = New DataTable()
			Dim dataTable2 As DataTable
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					Using sqlCommand As SqlCommand = New SqlCommand(cmdText, sqlConnection)
						Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
							sqlConnection.Open()
							sqlDataAdapter.Fill(dataTable)
						End Using
					End Using
				End Using
				dataTable2 = dataTable
			Catch ex As Exception
			End Try
			Return dataTable2
		End Function

		' Token: 0x0600079F RID: 1951 RVA: 0x0009E9C4 File Offset: 0x0009CBC4
		Public Shared Function ExecDataSet(cmdText As String, Optional tmptblName As String = "a") As DataSet
			Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(cmdText, ModCommonClasses.con)
			Dim dataSet As DataSet = New DataSet()
			sqlDataAdapter.Fill(dataSet, tmptblName)
			sqlDataAdapter.Dispose()
			Return dataSet
		End Function

		' Token: 0x060007A0 RID: 1952 RVA: 0x0009E9FC File Offset: 0x0009CBFC
		Public Shared Function ExecNonQuery(cmdText As String, Optional withTran As Boolean = False) As Integer
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			sqlConnection.Open()
			Dim flag As Boolean = Not withTran
			Dim sqlCommand As SqlCommand
			Dim num As Integer
			If flag Then
				sqlCommand = New SqlCommand(cmdText, sqlConnection)
				num = sqlCommand.ExecuteNonQuery()
			Else
				Dim sqlTransaction As SqlTransaction = sqlConnection.BeginTransaction()
				sqlCommand = New SqlCommand(cmdText, sqlConnection, sqlTransaction)
				sqlCommand.CommandTimeout = 7000
				num = sqlCommand.ExecuteNonQuery()
				sqlTransaction.Commit()
				sqlTransaction.Dispose()
			End If
			sqlCommand.Dispose()
			sqlConnection.Dispose()
			Return num
		End Function

		' Token: 0x060007A1 RID: 1953 RVA: 0x0009EA8C File Offset: 0x0009CC8C
		Public Shared Function ExecScalarStr(cmdText As String) As String
			Dim empty As String = String.Empty
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			sqlConnection.Open()
			Dim sqlCommand As SqlCommand = New SqlCommand(cmdText, sqlConnection)
			Dim objectValue As Object = RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar())
			sqlCommand.Dispose()
			sqlConnection.Dispose()
			Return clsfun.ToStr(RuntimeHelpers.GetObjectValue(objectValue))
		End Function

		' Token: 0x060007A2 RID: 1954 RVA: 0x0009EAE8 File Offset: 0x0009CCE8
		Public Shared Function ExecScalarInt(cmdText As String) As Integer
			Return clsfun.ToInt(clsfun.ExecScalarStr(cmdText))
		End Function

		' Token: 0x060007A3 RID: 1955 RVA: 0x0009EB08 File Offset: 0x0009CD08
		Public Shared Function ExecScalarDec(cmdText As String) As Decimal
			Return Convert.ToDecimal(clsfun.ExecScalarStr(cmdText))
		End Function

		' Token: 0x060007A4 RID: 1956 RVA: 0x0009EB28 File Offset: 0x0009CD28
		Public Shared Function ToInt(Val As Object) As Integer
			Dim num As Integer = 0
			Try
				num = Convert.ToInt32(Convert.ToDecimal(RuntimeHelpers.GetObjectValue(Val)))
			Catch ex As Exception
				num = 0
			End Try
			Return num
		End Function

		' Token: 0x060007A5 RID: 1957 RVA: 0x0009EB74 File Offset: 0x0009CD74
		Public Shared Sub FillDropDownList(ByRef ddl As ComboBox, cmdText As String, sTextField As String, sValueField As String, sDefaultValue As String)
			Dim dataTable As DataTable = New DataTable()
			dataTable = clsfun.ExecDataTable(cmdText)
			Dim flag As Boolean = Operators.CompareString(sDefaultValue.Trim(), "", False) <> 0
			If flag Then
				Dim dataRow As DataRow = dataTable.NewRow()
				dataRow(0) = 0
				dataRow(1) = sDefaultValue
				dataTable.Rows.InsertAt(dataRow, 0)
			End If
			ddl.DataSource = dataTable
			ddl.DisplayMember = sTextField
			ddl.ValueMember = sValueField
			Dim flag2 As Boolean = ddl.Items.Count > 0
			If flag2 Then
				ddl.SelectedIndex = 0
			End If
		End Sub

		' Token: 0x060007A6 RID: 1958 RVA: 0x0009EC10 File Offset: 0x0009CE10
		Public Shared Function ToStr(Val As Object) As String
			Dim text As String = String.Empty
			Try
				text = Val.ToString()
			Catch ex As Exception
				text = String.Empty
			End Try
			Return text
		End Function
	End Class
End Namespace
