Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020001ED RID: 493
	<DesignerGenerated()>
	Public Partial Class frmProductwiseProfit
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x17003068 RID: 12392
		' (get) Token: 0x06008419 RID: 33817 RVA: 0x000409D6 File Offset: 0x0003EBD6
		' (set) Token: 0x0600841A RID: 33818 RVA: 0x000409E0 File Offset: 0x0003EBE0
		Friend Overridable Property DataGridView1 As DataGridView

		' Token: 0x17003069 RID: 12393
		' (get) Token: 0x0600841B RID: 33819 RVA: 0x000409E9 File Offset: 0x0003EBE9
		' (set) Token: 0x0600841C RID: 33820 RVA: 0x000409F3 File Offset: 0x0003EBF3
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700306A RID: 12394
		' (get) Token: 0x0600841D RID: 33821 RVA: 0x000409FC File Offset: 0x0003EBFC
		' (set) Token: 0x0600841E RID: 33822 RVA: 0x00040A06 File Offset: 0x0003EC06
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700306B RID: 12395
		' (get) Token: 0x0600841F RID: 33823 RVA: 0x00040A0F File Offset: 0x0003EC0F
		' (set) Token: 0x06008420 RID: 33824 RVA: 0x00040A19 File Offset: 0x0003EC19
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x1700306C RID: 12396
		' (get) Token: 0x06008421 RID: 33825 RVA: 0x00040A22 File Offset: 0x0003EC22
		' (set) Token: 0x06008422 RID: 33826 RVA: 0x00040A2C File Offset: 0x0003EC2C
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700306D RID: 12397
		' (get) Token: 0x06008423 RID: 33827 RVA: 0x00040A35 File Offset: 0x0003EC35
		' (set) Token: 0x06008424 RID: 33828 RVA: 0x00040A3F File Offset: 0x0003EC3F
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700306E RID: 12398
		' (get) Token: 0x06008425 RID: 33829 RVA: 0x00040A48 File Offset: 0x0003EC48
		' (set) Token: 0x06008426 RID: 33830 RVA: 0x00040A52 File Offset: 0x0003EC52
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700306F RID: 12399
		' (get) Token: 0x06008427 RID: 33831 RVA: 0x00040A5B File Offset: 0x0003EC5B
		' (set) Token: 0x06008428 RID: 33832 RVA: 0x00040A65 File Offset: 0x0003EC65
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x17003070 RID: 12400
		' (get) Token: 0x06008429 RID: 33833 RVA: 0x00040A6E File Offset: 0x0003EC6E
		' (set) Token: 0x0600842A RID: 33834 RVA: 0x00040A78 File Offset: 0x0003EC78
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17003071 RID: 12401
		' (get) Token: 0x0600842B RID: 33835 RVA: 0x00040A81 File Offset: 0x0003EC81
		' (set) Token: 0x0600842C RID: 33836 RVA: 0x00040A8B File Offset: 0x0003EC8B
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x17003072 RID: 12402
		' (get) Token: 0x0600842D RID: 33837 RVA: 0x00040A94 File Offset: 0x0003EC94
		' (set) Token: 0x0600842E RID: 33838 RVA: 0x00040A9E File Offset: 0x0003EC9E
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17003073 RID: 12403
		' (get) Token: 0x0600842F RID: 33839 RVA: 0x00040AA7 File Offset: 0x0003ECA7
		' (set) Token: 0x06008430 RID: 33840 RVA: 0x00040AB1 File Offset: 0x0003ECB1
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17003074 RID: 12404
		' (get) Token: 0x06008431 RID: 33841 RVA: 0x00040ABA File Offset: 0x0003ECBA
		' (set) Token: 0x06008432 RID: 33842 RVA: 0x00040AC4 File Offset: 0x0003ECC4
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17003075 RID: 12405
		' (get) Token: 0x06008433 RID: 33843 RVA: 0x00040ACD File Offset: 0x0003ECCD
		' (set) Token: 0x06008434 RID: 33844 RVA: 0x00040AD7 File Offset: 0x0003ECD7
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17003076 RID: 12406
		' (get) Token: 0x06008435 RID: 33845 RVA: 0x00040AE0 File Offset: 0x0003ECE0
		' (set) Token: 0x06008436 RID: 33846 RVA: 0x00040AEA File Offset: 0x0003ECEA
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17003077 RID: 12407
		' (get) Token: 0x06008437 RID: 33847 RVA: 0x00040AF3 File Offset: 0x0003ECF3
		' (set) Token: 0x06008438 RID: 33848 RVA: 0x00040AFD File Offset: 0x0003ECFD
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17003078 RID: 12408
		' (get) Token: 0x06008439 RID: 33849 RVA: 0x00040B06 File Offset: 0x0003ED06
		' (set) Token: 0x0600843A RID: 33850 RVA: 0x00040B10 File Offset: 0x0003ED10
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17003079 RID: 12409
		' (get) Token: 0x0600843B RID: 33851 RVA: 0x00040B19 File Offset: 0x0003ED19
		' (set) Token: 0x0600843C RID: 33852 RVA: 0x00040B23 File Offset: 0x0003ED23
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700307A RID: 12410
		' (get) Token: 0x0600843D RID: 33853 RVA: 0x00040B2C File Offset: 0x0003ED2C
		' (set) Token: 0x0600843E RID: 33854 RVA: 0x00040B36 File Offset: 0x0003ED36
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x1700307B RID: 12411
		' (get) Token: 0x0600843F RID: 33855 RVA: 0x00040B3F File Offset: 0x0003ED3F
		' (set) Token: 0x06008440 RID: 33856 RVA: 0x00040B49 File Offset: 0x0003ED49
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x1700307C RID: 12412
		' (get) Token: 0x06008441 RID: 33857 RVA: 0x00040B52 File Offset: 0x0003ED52
		' (set) Token: 0x06008442 RID: 33858 RVA: 0x00040B5C File Offset: 0x0003ED5C
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x1700307D RID: 12413
		' (get) Token: 0x06008443 RID: 33859 RVA: 0x00040B65 File Offset: 0x0003ED65
		' (set) Token: 0x06008444 RID: 33860 RVA: 0x00040B6F File Offset: 0x0003ED6F
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x1700307E RID: 12414
		' (get) Token: 0x06008445 RID: 33861 RVA: 0x00040B78 File Offset: 0x0003ED78
		' (set) Token: 0x06008446 RID: 33862 RVA: 0x00040B82 File Offset: 0x0003ED82
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x1700307F RID: 12415
		' (get) Token: 0x06008447 RID: 33863 RVA: 0x00040B8B File Offset: 0x0003ED8B
		' (set) Token: 0x06008448 RID: 33864 RVA: 0x00040B95 File Offset: 0x0003ED95
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17003080 RID: 12416
		' (get) Token: 0x06008449 RID: 33865 RVA: 0x00040B9E File Offset: 0x0003ED9E
		' (set) Token: 0x0600844A RID: 33866 RVA: 0x00040BA8 File Offset: 0x0003EDA8
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17003081 RID: 12417
		' (get) Token: 0x0600844B RID: 33867 RVA: 0x00040BB1 File Offset: 0x0003EDB1
		' (set) Token: 0x0600844C RID: 33868 RVA: 0x00040BBB File Offset: 0x0003EDBB
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17003082 RID: 12418
		' (get) Token: 0x0600844D RID: 33869 RVA: 0x00040BC4 File Offset: 0x0003EDC4
		' (set) Token: 0x0600844E RID: 33870 RVA: 0x00040BCE File Offset: 0x0003EDCE
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17003083 RID: 12419
		' (get) Token: 0x0600844F RID: 33871 RVA: 0x00040BD7 File Offset: 0x0003EDD7
		' (set) Token: 0x06008450 RID: 33872 RVA: 0x00040BE1 File Offset: 0x0003EDE1
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17003084 RID: 12420
		' (get) Token: 0x06008451 RID: 33873 RVA: 0x00040BEA File Offset: 0x0003EDEA
		' (set) Token: 0x06008452 RID: 33874 RVA: 0x00040BF4 File Offset: 0x0003EDF4
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x17003085 RID: 12421
		' (get) Token: 0x06008453 RID: 33875 RVA: 0x00040BFD File Offset: 0x0003EDFD
		' (set) Token: 0x06008454 RID: 33876 RVA: 0x00040C07 File Offset: 0x0003EE07
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x17003086 RID: 12422
		' (get) Token: 0x06008455 RID: 33877 RVA: 0x00040C10 File Offset: 0x0003EE10
		' (set) Token: 0x06008456 RID: 33878 RVA: 0x00040C1A File Offset: 0x0003EE1A
		Friend Overridable Property Column36 As DataGridViewTextBoxColumn

		' Token: 0x17003087 RID: 12423
		' (get) Token: 0x06008457 RID: 33879 RVA: 0x00040C23 File Offset: 0x0003EE23
		' (set) Token: 0x06008458 RID: 33880 RVA: 0x00040C2D File Offset: 0x0003EE2D
		Friend Overridable Property Column37 As DataGridViewTextBoxColumn

		' Token: 0x17003088 RID: 12424
		' (get) Token: 0x06008459 RID: 33881 RVA: 0x00040C36 File Offset: 0x0003EE36
		' (set) Token: 0x0600845A RID: 33882 RVA: 0x00040C40 File Offset: 0x0003EE40
		Friend Overridable Property Column38 As DataGridViewTextBoxColumn

		' Token: 0x17003089 RID: 12425
		' (get) Token: 0x0600845B RID: 33883 RVA: 0x00040C49 File Offset: 0x0003EE49
		' (set) Token: 0x0600845C RID: 33884 RVA: 0x00040C53 File Offset: 0x0003EE53
		Friend Overridable Property Column39 As DataGridViewTextBoxColumn

		' Token: 0x1700308A RID: 12426
		' (get) Token: 0x0600845D RID: 33885 RVA: 0x00040C5C File Offset: 0x0003EE5C
		' (set) Token: 0x0600845E RID: 33886 RVA: 0x00040C66 File Offset: 0x0003EE66
		Friend Overridable Property Column40 As DataGridViewTextBoxColumn

		' Token: 0x1700308B RID: 12427
		' (get) Token: 0x0600845F RID: 33887 RVA: 0x00040C6F File Offset: 0x0003EE6F
		' (set) Token: 0x06008460 RID: 33888 RVA: 0x00040C79 File Offset: 0x0003EE79
		Friend Overridable Property Column41 As DataGridViewTextBoxColumn

		' Token: 0x1700308C RID: 12428
		' (get) Token: 0x06008461 RID: 33889 RVA: 0x00040C82 File Offset: 0x0003EE82
		' (set) Token: 0x06008462 RID: 33890 RVA: 0x00040C8C File Offset: 0x0003EE8C
		Friend Overridable Property Column42 As DataGridViewTextBoxColumn

		' Token: 0x1700308D RID: 12429
		' (get) Token: 0x06008463 RID: 33891 RVA: 0x00040C95 File Offset: 0x0003EE95
		' (set) Token: 0x06008464 RID: 33892 RVA: 0x00040C9F File Offset: 0x0003EE9F
		Friend Overridable Property Column52 As DataGridViewTextBoxColumn

		' Token: 0x1700308E RID: 12430
		' (get) Token: 0x06008465 RID: 33893 RVA: 0x00040CA8 File Offset: 0x0003EEA8
		' (set) Token: 0x06008466 RID: 33894 RVA: 0x00040CB2 File Offset: 0x0003EEB2
		Friend Overridable Property Column53 As DataGridViewTextBoxColumn

		' Token: 0x1700308F RID: 12431
		' (get) Token: 0x06008467 RID: 33895 RVA: 0x00040CBB File Offset: 0x0003EEBB
		' (set) Token: 0x06008468 RID: 33896 RVA: 0x00040CC5 File Offset: 0x0003EEC5
		Friend Overridable Property Column55 As DataGridViewTextBoxColumn

		' Token: 0x17003090 RID: 12432
		' (get) Token: 0x06008469 RID: 33897 RVA: 0x00040CCE File Offset: 0x0003EECE
		' (set) Token: 0x0600846A RID: 33898 RVA: 0x00040CD8 File Offset: 0x0003EED8
		Friend Overridable Property Column56 As DataGridViewTextBoxColumn

		' Token: 0x17003091 RID: 12433
		' (get) Token: 0x0600846B RID: 33899 RVA: 0x00040CE1 File Offset: 0x0003EEE1
		' (set) Token: 0x0600846C RID: 33900 RVA: 0x00040CEB File Offset: 0x0003EEEB
		Friend Overridable Property Column57 As DataGridViewImageColumn

		' Token: 0x17003092 RID: 12434
		' (get) Token: 0x0600846D RID: 33901 RVA: 0x00040CF4 File Offset: 0x0003EEF4
		' (set) Token: 0x0600846E RID: 33902 RVA: 0x00040CFE File Offset: 0x0003EEFE
		Friend Overridable Property Column58 As DataGridViewTextBoxColumn

		' Token: 0x17003093 RID: 12435
		' (get) Token: 0x0600846F RID: 33903 RVA: 0x00040D07 File Offset: 0x0003EF07
		' (set) Token: 0x06008470 RID: 33904 RVA: 0x00040D11 File Offset: 0x0003EF11
		Friend Overridable Property Column59 As DataGridViewTextBoxColumn

		' Token: 0x17003094 RID: 12436
		' (get) Token: 0x06008471 RID: 33905 RVA: 0x00040D1A File Offset: 0x0003EF1A
		' (set) Token: 0x06008472 RID: 33906 RVA: 0x00040D24 File Offset: 0x0003EF24
		Friend Overridable Property Status As DataGridViewTextBoxColumn

		' Token: 0x06008473 RID: 33907 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmProductwiseProfit_Load(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06008474 RID: 33908 RVA: 0x00040D2D File Offset: 0x0003EF2D
		Public Sub New(dt As DataTable)
			AddHandler MyBase.Load, AddressOf Me.frmProductwiseProfit_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmProductwiseProfit_KeyDown
			Me.InitializeComponent()
			Me.BindData(dt)
		End Sub

		' Token: 0x06008475 RID: 33909 RVA: 0x00622D4C File Offset: 0x00620F4C
		Private Sub BindData(dt As DataTable)
			' The following expression was wrapped in a checked-statement
			Try
				Me.DataGridView1.Rows.Clear()
				Dim flag As Boolean = Me.DataGridView1.Columns.Count = 0
				If flag Then
					Try
						For Each obj As Object In dt.Columns
							Dim dataColumn As DataColumn = CType(obj, DataColumn)
							Dim flag2 As Boolean = dataColumn.DataType Is GetType(Byte())
							If Not flag2 Then
								Me.DataGridView1.Columns.Add(dataColumn.ColumnName, dataColumn.ColumnName)
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Dim flag3 As Boolean = Not Me.DataGridView1.Columns.Contains("Status")
					If flag3 Then
						Me.DataGridView1.Columns.Add("Status", "Status")
					End If
				End If
				Dim i As Integer = 0
				Dim num As Decimal = 0D
				Dim num2 As Decimal = 0D
				While i < dt.Rows.Count
					Dim array As Object() = New Object(Me.DataGridView1.Columns.Count - 1 + 1 - 1) {}
					Dim num3 As Integer = 0
					Try
						For Each obj2 As Object In dt.Columns
							Dim dataColumn2 As DataColumn = CType(obj2, DataColumn)
							Dim flag4 As Boolean = dataColumn2.DataType Is GetType(Byte())
							If Not flag4 Then
								Dim objectValue As Object = RuntimeHelpers.GetObjectValue(dt.Rows(i)(dataColumn2))
								Dim flag5 As Boolean = Information.IsDBNull(RuntimeHelpers.GetObjectValue(objectValue))
								If flag5 Then
									array(num3) = ""
								Else
									array(num3) = objectValue.ToString()
									Dim flag6 As Boolean = num3 = 16
									If flag6 Then
										num = Decimal.Add(num, Convert.ToDecimal(objectValue.ToString()))
									End If
									Dim flag7 As Boolean = num3 = 18
									If flag7 Then
										num2 = Decimal.Add(num2, Convert.ToDecimal(objectValue.ToString()))
									End If
								End If
								num3 += 1
							End If
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
					array(Me.DataGridView1.Columns("Status").Index) = ""
					Dim num4 As Integer = Me.DataGridView1.Rows.Add(array)
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.Rows(num4)
					Dim num5 As Decimal = 0D
					Dim flag8 As Boolean = dt.Columns.Contains("Column19") AndAlso Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(dt.Rows(i)("Column19")))
					If flag8 Then
						Decimal.TryParse(dt.Rows(i)("Column19").ToString(), num5)
					End If
					Dim flag9 As Boolean = Decimal.Compare(num5, 0D) < 0
					If flag9 Then
						dataGridViewRow.Cells("Status").Value = "LOSS"
						dataGridViewRow.Cells("Status").Style.ForeColor = Color.Red
					Else
						dataGridViewRow.Cells("Status").Value = "PROFIT"
						dataGridViewRow.Cells("Status").Style.ForeColor = Color.Green
					End If
					i += 1
				End While
				Dim num6 As Integer = Me.DataGridView1.Rows.Add()
				Dim dataGridViewRow2 As DataGridViewRow = Me.DataGridView1.Rows(num6)
				dataGridViewRow2.DefaultCellStyle.BackColor = Color.LightYellow
				dataGridViewRow2.DefaultCellStyle.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
				dataGridViewRow2.Cells(4).Value = "TOTAL:"
				Dim flag10 As Boolean = Me.DataGridView1.Columns.Contains("Column6")
				If flag10 Then
					dataGridViewRow2.Cells("Column6").Value = num.ToString("N2")
				End If
				Dim flag11 As Boolean = Me.DataGridView1.Columns.Contains("Column19")
				If flag11 Then
					dataGridViewRow2.Cells("Column19").Value = num2.ToString("N2")
				End If
				Dim flag12 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow2.Cells("Column19").Value, 0, False)
				If flag12 Then
					dataGridViewRow2.Cells("Status").Value = "Profit"
					dataGridViewRow2.Cells("Status").Style.ForeColor = Color.Green
				Else
					dataGridViewRow2.Cells("Status").Value = "Loss"
					dataGridViewRow2.Cells("Status").Style.ForeColor = Color.Red
				End If
			Catch ex As Exception
				MessageBox.Show("Error while binding data row by row: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008476 RID: 33910 RVA: 0x006232E8 File Offset: 0x006214E8
		Private Sub frmProductwiseProfit_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				MyBase.Dispose()
			End If
		End Sub
	End Class
End Namespace
