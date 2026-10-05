Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000015 RID: 21
	Public Class DimensionSP
		' Token: 0x060004ED RID: 1261 RVA: 0x0000946B File Offset: 0x0000766B
		Public Sub New()
			Me.sqlcon = ModCS.ReadCS()
		End Sub

		' Token: 0x060004EE RID: 1262 RVA: 0x00087B30 File Offset: 0x00085D30
		Public Sub DimensionAdd(dimensioninfo As DimensionInfo)
			Try
				Dim sqlCommand As SqlCommand = New SqlCommand("DimensionAdd", CType(Me.sqlcon, SqlConnection))
				sqlCommand.CommandType = CommandType.StoredProcedure
				Dim sqlParameter As SqlParameter = sqlCommand.Parameters.Add("@layoutId", SqlDbType.[Decimal])
				sqlParameter.Value = dimensioninfo.LayoutId
				sqlParameter = sqlCommand.Parameters.Add("@fieldId", SqlDbType.[Decimal])
				sqlParameter.Value = dimensioninfo.FieldId
				sqlParameter = sqlCommand.Parameters.Add("@xAxis", SqlDbType.Float)
				sqlParameter.Value = dimensioninfo.XAxis
				sqlParameter = sqlCommand.Parameters.Add("@yAxis", SqlDbType.Float)
				sqlParameter.Value = dimensioninfo.YAxis
				sqlParameter = sqlCommand.Parameters.Add("@width", SqlDbType.Float)
				sqlParameter.Value = dimensioninfo.Width
				sqlParameter = sqlCommand.Parameters.Add("@height", SqlDbType.Float)
				sqlParameter.Value = dimensioninfo.Height
				sqlCommand.ExecuteNonQuery()
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			Finally
				NewLateBinding.LateCall(Me.sqlcon, Nothing, "Close", New Object(-1) {}, Nothing, Nothing, Nothing, True)
			End Try
		End Sub

		' Token: 0x060004EF RID: 1263 RVA: 0x00087CB0 File Offset: 0x00085EB0
		Public Sub DimensionEdit(dimensioninfo As DimensionInfo)
			Try
				Dim flag As Boolean = Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(Me.sqlcon, Nothing, "State", New Object(-1) {}, Nothing, Nothing, Nothing), ConnectionState.Closed, False)
				If flag Then
					NewLateBinding.LateCall(Me.sqlcon, Nothing, "Open", New Object(-1) {}, Nothing, Nothing, Nothing, True)
				End If
				Dim sqlCommand As SqlCommand = New SqlCommand("DimensionEdit", CType(Me.sqlcon, SqlConnection))
				sqlCommand.CommandType = CommandType.StoredProcedure
				Dim sqlParameter As SqlParameter = sqlCommand.Parameters.Add("@dimensionId", SqlDbType.[Decimal])
				sqlParameter.Value = dimensioninfo.DimensionId
				sqlParameter = sqlCommand.Parameters.Add("@layoutId", SqlDbType.[Decimal])
				sqlParameter.Value = dimensioninfo.LayoutId
				sqlParameter = sqlCommand.Parameters.Add("@fieldId", SqlDbType.[Decimal])
				sqlParameter.Value = dimensioninfo.FieldId
				sqlParameter = sqlCommand.Parameters.Add("@xAxis", SqlDbType.Float)
				sqlParameter.Value = dimensioninfo.XAxis
				sqlParameter = sqlCommand.Parameters.Add("@yAxis", SqlDbType.Float)
				sqlParameter.Value = dimensioninfo.YAxis
				sqlParameter = sqlCommand.Parameters.Add("@width", SqlDbType.Float)
				sqlParameter.Value = dimensioninfo.Width
				sqlParameter = sqlCommand.Parameters.Add("@height", SqlDbType.Float)
				sqlParameter.Value = dimensioninfo.Height
				sqlCommand.ExecuteNonQuery()
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			Finally
				NewLateBinding.LateCall(Me.sqlcon, Nothing, "Close", New Object(-1) {}, Nothing, Nothing, Nothing, True)
			End Try
		End Sub

		' Token: 0x060004F0 RID: 1264 RVA: 0x00087E9C File Offset: 0x0008609C
		Public Function DimensionView(dimensionId As Decimal) As DimensionInfo
			Dim dimensionInfo As DimensionInfo = New DimensionInfo()
			Dim sqlDataReader As SqlDataReader = Nothing
			Try
				Dim flag As Boolean = Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(Me.sqlcon, Nothing, "State", New Object(-1) {}, Nothing, Nothing, Nothing), ConnectionState.Closed, False)
				If flag Then
					NewLateBinding.LateCall(Me.sqlcon, Nothing, "Open", New Object(-1) {}, Nothing, Nothing, Nothing, True)
				End If
				Dim sqlCommand As SqlCommand = New SqlCommand("DimensionView", CType(Me.sqlcon, SqlConnection))
				sqlCommand.CommandType = CommandType.StoredProcedure
				Dim sqlParameter As SqlParameter = sqlCommand.Parameters.Add("@dimensionId", SqlDbType.[Decimal])
				sqlParameter.Value = dimensionId
				sqlDataReader = sqlCommand.ExecuteReader()
				While sqlDataReader.Read()
					dimensionInfo.DimensionId = Decimal.Parse(sqlDataReader(0).ToString())
					dimensionInfo.LayoutId = Decimal.Parse(sqlDataReader(1).ToString())
					dimensionInfo.FieldId = Decimal.Parse(sqlDataReader(2).ToString())
					dimensionInfo.XAxis = Single.Parse(sqlDataReader(3).ToString())
					dimensionInfo.YAxis = Single.Parse(sqlDataReader(4).ToString())
					dimensionInfo.Width = Single.Parse(sqlDataReader(5).ToString())
					dimensionInfo.Height = Single.Parse(sqlDataReader(6).ToString())
				End While
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			Finally
				Dim flag2 As Boolean = sqlDataReader IsNot Nothing
				If flag2 Then
					sqlDataReader.Close()
				End If
				NewLateBinding.LateCall(Me.sqlcon, Nothing, "Close", New Object(-1) {}, Nothing, Nothing, Nothing, True)
			End Try
			Return dimensionInfo
		End Function

		' Token: 0x060004F1 RID: 1265 RVA: 0x0008808C File Offset: 0x0008628C
		Public Sub DimensionDelete(dimensionId As Decimal)
			Try
				Dim flag As Boolean = Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(Me.sqlcon, Nothing, "State", New Object(-1) {}, Nothing, Nothing, Nothing), ConnectionState.Closed, False)
				If flag Then
					NewLateBinding.LateCall(Me.sqlcon, Nothing, "Open", New Object(-1) {}, Nothing, Nothing, Nothing, True)
				End If
				Dim sqlCommand As SqlCommand = New SqlCommand("DimensionDelete", CType(Me.sqlcon, SqlConnection))
				sqlCommand.CommandType = CommandType.StoredProcedure
				Dim sqlParameter As SqlParameter = sqlCommand.Parameters.Add("@dimensionId", SqlDbType.[Decimal])
				sqlParameter.Value = dimensionId
				sqlCommand.ExecuteNonQuery()
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			Finally
				NewLateBinding.LateCall(Me.sqlcon, Nothing, "Close", New Object(-1) {}, Nothing, Nothing, Nothing, True)
			End Try
		End Sub

		' Token: 0x060004F2 RID: 1266 RVA: 0x00088184 File Offset: 0x00086384
		Public Function DimensionGetMax() As Integer
			Dim num As Integer = 0
			Try
				Dim flag As Boolean = Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(Me.sqlcon, Nothing, "State", New Object(-1) {}, Nothing, Nothing, Nothing), ConnectionState.Closed, False)
				If flag Then
					NewLateBinding.LateCall(Me.sqlcon, Nothing, "Open", New Object(-1) {}, Nothing, Nothing, Nothing, True)
				End If
				num = Integer.Parse(New SqlCommand("DimensionMax", CType(Me.sqlcon, SqlConnection)) With { .CommandType = CommandType.StoredProcedure }.ExecuteScalar().ToString())
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			Finally
				NewLateBinding.LateCall(Me.sqlcon, Nothing, "Close", New Object(-1) {}, Nothing, Nothing, Nothing, True)
			End Try
			Return num
		End Function

		' Token: 0x060004F3 RID: 1267 RVA: 0x00088270 File Offset: 0x00086470
		Public Function GetDimensionIdForALayoutIdAndFeildId1(layoutId As Decimal) As Decimal
			Dim num As Decimal = 0D
			Dim sqlDataReader As SqlDataReader = Nothing
			Try
				Dim flag As Boolean = Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(Me.sqlcon, Nothing, "State", New Object(-1) {}, Nothing, Nothing, Nothing), ConnectionState.Closed, False)
				If flag Then
					NewLateBinding.LateCall(Me.sqlcon, Nothing, "Open", New Object(-1) {}, Nothing, Nothing, Nothing, True)
				End If
				Dim sqlCommand As SqlCommand = New SqlCommand("GetDimensionIdForALayoutIdAndFeildId1", CType(Me.sqlcon, SqlConnection))
				sqlCommand.CommandType = CommandType.StoredProcedure
				Dim sqlParameter As SqlParameter = sqlCommand.Parameters.Add("@layoutId", SqlDbType.[Decimal])
				sqlParameter.Value = layoutId
				sqlDataReader = sqlCommand.ExecuteReader()
				While sqlDataReader.Read()
					num = Decimal.Parse(sqlDataReader(0).ToString())
				End While
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			Finally
				Dim flag2 As Boolean = sqlDataReader IsNot Nothing
				If flag2 Then
					sqlDataReader.Close()
				End If
				NewLateBinding.LateCall(Me.sqlcon, Nothing, "Close", New Object(-1) {}, Nothing, Nothing, Nothing, True)
			End Try
			Return num
		End Function

		' Token: 0x040001DC RID: 476
		Private sqlcon As Object
	End Class
End Namespace
