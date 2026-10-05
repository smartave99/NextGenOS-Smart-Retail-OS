Imports System
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005FB RID: 1531
	Friend Module RupModule1
		' Token: 0x06012AC3 RID: 76483 RVA: 0x00AB97F0 File Offset: 0x00AB79F0
		Public Function RupeesToWord(MyNumber As Object) As Object
			Dim obj3 As Object
			Dim num4 As Integer
			Dim num2 As Integer
			Dim obj5 As Object
			Try
				IL_0002:
				Dim num As Integer = 1
				Dim array As String() = New String(9) {}
				IL_000D:
				num = 2
				array(0) = " Thousand "
				IL_0018:
				num = 3
				array(2) = " Lakh "
				IL_0023:
				num = 4
				array(4) = " Crore "
				IL_002E:
				num = 5
				array(6) = " Arab "
				IL_0039:
				num = 6
				array(8) = " Kharab "
				IL_0044:
				ProjectData.ClearProjectError()
				num2 = -2
				IL_004D:
				num = 8
				MyNumber = Strings.Trim(Conversion.Str(RuntimeHelpers.GetObjectValue(MyNumber)))
				IL_0061:
				num = 9
				Dim obj As Object = Strings.InStr(Conversions.ToString(MyNumber), ".", CompareMethod.Binary)
				IL_007C:
				num = 10
				Dim flag As Boolean = Operators.ConditionalCompareObjectGreater(obj, 0, False)
				If Not flag Then
					GoTo IL_011A
				End If
				IL_0096:
				num = 11
				Dim obj2 As Object = Strings.Left(Strings.Mid(Conversions.ToString(MyNumber), Conversions.ToInteger(Operators.AddObject(obj, 1))) + "00", 2)
				IL_00C8:
				num = 12
				Dim text As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(" and ", RupModule1.ConvertTens(RuntimeHelpers.GetObjectValue(obj2))), " Paisa"))
				IL_00F2:
				num = 13
				MyNumber = Strings.Trim(Strings.Left(Conversions.ToString(MyNumber), Conversions.ToInteger(Operators.SubtractObject(obj, 1))))
				IL_0119:
				IL_011A:
				IL_011B:
				num = 15
				Dim text2 As String = Strings.Right(Conversions.ToString(MyNumber), 2)
				IL_012C:
				num = 16
				Dim flag2 As Boolean = (Strings.Len(RuntimeHelpers.GetObjectValue(MyNumber)) > 0) And (Strings.Len(RuntimeHelpers.GetObjectValue(MyNumber)) <= 2)
				If Not flag2 Then
					GoTo IL_01E0
				End If
				IL_0158:
				num = 17
				Dim flag3 As Boolean = Strings.Len(text2) = 1
				Dim text3 As String
				If Not flag3 Then
					IL_019C:
					num = 22
					Dim flag4 As Boolean = Strings.Len(text2) = 2
					If Not flag4 Then
						GoTo IL_01DD
					End If
					IL_01AF:
					num = 23
					text3 = Conversions.ToString(RupModule1.ConvertTens(text2))
					IL_01C0:
					num = 24
					Return "(Rupees " + text3 + text + " Only)"
					IL_01DD:
					IL_01DE:
					IL_01DF:
					GoTo IL_01E0
				End If
				IL_016B:
				num = 18
				text3 = Conversions.ToString(RupModule1.ConvertDigit(text2))
				IL_017C:
				num = 19
				Return "(Rupees " + text3 + text + " Only)"
				IL_01E0:
				IL_01E1:
				num = 29
				Dim text4 As String = Conversions.ToString(RupModule1.ConvertHundreds(Strings.Right(Conversions.ToString(MyNumber), 3)))
				IL_01FC:
				num = 30
				MyNumber = Strings.Left(Conversions.ToString(MyNumber), Strings.Len(RuntimeHelpers.GetObjectValue(MyNumber)) - 3)
				IL_0219:
				num = 31
				Dim obj4 As Object = 0
				IL_0224:
				While True
					IL_05CF:
					num = 33
					If Not Operators.ConditionalCompareObjectNotEqual(MyNumber, "", False) Then
						Exit While
					End If
					IL_0229:
					num = 34
					obj2 = Strings.Right(Conversions.ToString(MyNumber), 2)
					IL_023A:
					num = 35
					Dim flag5 As Boolean = Strings.Len(RuntimeHelpers.GetObjectValue(MyNumber)) = 1
					If flag5 Then
						IL_0254:
						num = 36
						Dim flag6 As Boolean = (Operators.CompareString(Strings.Trim(text3), "Thousand", False) = 0) Or (Operators.CompareString(Strings.Trim(text3), "Lakh  Thousand", False) = 0) Or (Operators.CompareString(Strings.Trim(text3), "Lakh", False) = 0) Or (Operators.CompareString(Strings.Trim(text3), "Crore", False) = 0) Or (Operators.CompareString(Strings.Trim(text3), "Crore  Lakh  Thousand", False) = 0) Or (Operators.CompareString(Strings.Trim(text3), "Arab  Crore  Lakh  Thousand", False) = 0) Or (Operators.CompareString(Strings.Trim(text3), "Arab", False) = 0) Or (Operators.CompareString(Strings.Trim(text3), "Kharab  Arab  Crore  Lakh  Thousand", False) = 0) Or (Operators.CompareString(Strings.Trim(text3), "Kharab", False) = 0)
						If flag6 Then
							IL_0322:
							num = 37
							text3 = Conversions.ToString(Operators.ConcatenateObject(RupModule1.ConvertDigit(RuntimeHelpers.GetObjectValue(obj2)), array(Conversions.ToInteger(obj4))))
							IL_0347:
							num = 38
							MyNumber = Strings.Left(Conversions.ToString(MyNumber), Strings.Len(RuntimeHelpers.GetObjectValue(MyNumber)) - 1)
							IL_0364:
						Else
							IL_0368:
							num = 40
							text3 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(RupModule1.ConvertDigit(RuntimeHelpers.GetObjectValue(obj2)), array(Conversions.ToInteger(obj4))), text3))
							IL_0394:
							num = 41
							MyNumber = Strings.Left(Conversions.ToString(MyNumber), Strings.Len(RuntimeHelpers.GetObjectValue(MyNumber)) - 1)
							IL_03B1:
						End If
						IL_03B2:
					Else
						IL_03B9:
						num = 44
						Dim flag7 As Boolean = (Operators.CompareString(Strings.Trim(text3), "Thousand", False) = 0) Or (Operators.CompareString(Strings.Trim(text3), "Lakh  Thousand", False) = 0) Or (Operators.CompareString(Strings.Trim(text3), "Lakh", False) = 0) Or (Operators.CompareString(Strings.Trim(text3), "Crore", False) = 0) Or (Operators.CompareString(Strings.Trim(text3), "Crore  Lakh  Thousand", False) = 0) Or (Operators.CompareString(Strings.Trim(text3), "Arab  Crore  Lakh  Thousand", False) = 0) Or (Operators.CompareString(Strings.Trim(text3), "Arab", False) = 0)
						If flag7 Then
							IL_045B:
							num = 45
							text3 = Conversions.ToString(Operators.ConcatenateObject(RupModule1.ConvertTens(RuntimeHelpers.GetObjectValue(obj2)), array(Conversions.ToInteger(obj4))))
							IL_0480:
							num = 46
							MyNumber = Strings.Left(Conversions.ToString(MyNumber), Strings.Len(RuntimeHelpers.GetObjectValue(MyNumber)) - 2)
							IL_049D:
						Else
							IL_04A4:
							num = 48
							Dim flag8 As Boolean = (Operators.CompareString(Strings.Trim(Conversions.ToString(Operators.ConcatenateObject(RupModule1.ConvertTens(RuntimeHelpers.GetObjectValue(obj2)), array(Conversions.ToInteger(obj4))))), "Lakh", False) = 0) Or (Operators.CompareString(Strings.Trim(Conversions.ToString(Operators.ConcatenateObject(RupModule1.ConvertTens(RuntimeHelpers.GetObjectValue(obj2)), array(Conversions.ToInteger(obj4))))), "Crore", False) = 0) Or (Operators.CompareString(Strings.Trim(Conversions.ToString(Operators.ConcatenateObject(RupModule1.ConvertTens(RuntimeHelpers.GetObjectValue(obj2)), array(Conversions.ToInteger(obj4))))), "Arab", False) = 0)
							If flag8 Then
								IL_0548:
								num = 49
								text3 = text3
								IL_054F:
								num = 50
								MyNumber = Strings.Left(Conversions.ToString(MyNumber), Strings.Len(RuntimeHelpers.GetObjectValue(MyNumber)) - 2)
								IL_056C:
							Else
								IL_0570:
								num = 52
								text3 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(RupModule1.ConvertTens(RuntimeHelpers.GetObjectValue(obj2)), array(Conversions.ToInteger(obj4))), text3))
								IL_059C:
								num = 53
								MyNumber = Strings.Left(Conversions.ToString(MyNumber), Strings.Len(RuntimeHelpers.GetObjectValue(MyNumber)) - 2)
								IL_05B9:
							End If
							IL_05BA:
						End If
						IL_05BB:
					End If
					IL_05BC:
					num = 57
					obj4 = Operators.AddObject(obj4, 2)
					IL_05CE:
				End While
				Return String.Concat(New String() { "(Rupees ", text3, text4, text, " Only)" })
			Catch ex As Exception
				Return ""
			End Try
		End Function

		' Token: 0x06012AC4 RID: 76484 RVA: 0x00AB9F84 File Offset: 0x00AB8184
		Private Function ConvertHundreds(MyNumber As Object) As Object
			Dim flag As Boolean = Conversion.Val(RuntimeHelpers.GetObjectValue(MyNumber)) = 0.0
			Dim obj As Object
			If Not flag Then
				MyNumber = Strings.Right(Conversions.ToString(Operators.ConcatenateObject("000", MyNumber)), 3)
				Dim flag2 As Boolean = Operators.CompareString(Strings.Left(Conversions.ToString(MyNumber), 1), "0", False) <> 0
				Dim text As String
				If flag2 Then
					text = Conversions.ToString(Operators.ConcatenateObject(RupModule1.ConvertDigit(Strings.Left(Conversions.ToString(MyNumber), 1)), " Hundred "))
				End If
				Dim flag3 As Boolean = Operators.CompareString(Strings.Mid(Conversions.ToString(MyNumber), 2, 1), "0", False) <> 0
				If flag3 Then
					text = Conversions.ToString(Operators.ConcatenateObject(text, RupModule1.ConvertTens(Strings.Mid(Conversions.ToString(MyNumber), 2))))
				Else
					text = Conversions.ToString(Operators.ConcatenateObject(text, RupModule1.ConvertDigit(Strings.Mid(Conversions.ToString(MyNumber), 3))))
				End If
				obj = Strings.Trim(text)
			End If
			Return obj
		End Function

		' Token: 0x06012AC5 RID: 76485 RVA: 0x00ABA074 File Offset: 0x00AB8274
		Private Function ConvertTens(MyTens As Object) As Object
			Dim flag As Boolean = Conversion.Val(Strings.Left(Conversions.ToString(MyTens), 1)) = 1.0
			Dim text As String
			If flag Then
				Dim num As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(MyTens))
				Dim flag2 As Boolean = num = 10.0
				If flag2 Then
					text = "Ten"
				Else
					flag2 = num = 11.0
					If flag2 Then
						text = "Eleven"
					Else
						flag2 = num = 12.0
						If flag2 Then
							text = "Twelve"
						Else
							flag2 = num = 13.0
							If flag2 Then
								text = "Thirteen"
							Else
								flag2 = num = 14.0
								If flag2 Then
									text = "Fourteen"
								Else
									flag2 = num = 15.0
									If flag2 Then
										text = "Fifteen"
									Else
										flag2 = num = 16.0
										If flag2 Then
											text = "Sixteen"
										Else
											flag2 = num = 17.0
											If flag2 Then
												text = "Seventeen"
											Else
												flag2 = num = 18.0
												If flag2 Then
													text = "Eighteen"
												Else
													flag2 = num = 19.0
													If flag2 Then
														text = "Nineteen"
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			Else
				Dim num2 As Double = Conversion.Val(Strings.Left(Conversions.ToString(MyTens), 1))
				Dim flag3 As Boolean = num2 = 2.0
				If flag3 Then
					text = "Twenty "
				Else
					flag3 = num2 = 3.0
					If flag3 Then
						text = "Thirty "
					Else
						flag3 = num2 = 4.0
						If flag3 Then
							text = "Forty "
						Else
							flag3 = num2 = 5.0
							If flag3 Then
								text = "Fifty "
							Else
								flag3 = num2 = 6.0
								If flag3 Then
									text = "Sixty "
								Else
									flag3 = num2 = 7.0
									If flag3 Then
										text = "Seventy "
									Else
										flag3 = num2 = 8.0
										If flag3 Then
											text = "Eighty "
										Else
											flag3 = num2 = 9.0
											If flag3 Then
												text = "Ninety "
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				End If
				text = Conversions.ToString(Operators.ConcatenateObject(text, RupModule1.ConvertDigit(Strings.Right(Conversions.ToString(MyTens), 1))))
			End If
			Return text
		End Function

		' Token: 0x06012AC6 RID: 76486 RVA: 0x00ABA2E8 File Offset: 0x00AB84E8
		Private Function ConvertDigit(MyDigit As Object) As Object
			Dim num As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(MyDigit))
			Dim flag As Boolean = num = 1.0
			Dim obj As Object
			If flag Then
				obj = "One"
			Else
				flag = num = 2.0
				If flag Then
					obj = "Two"
				Else
					flag = num = 3.0
					If flag Then
						obj = "Three"
					Else
						flag = num = 4.0
						If flag Then
							obj = "Four"
						Else
							flag = num = 5.0
							If flag Then
								obj = "Five"
							Else
								flag = num = 6.0
								If flag Then
									obj = "Six"
								Else
									flag = num = 7.0
									If flag Then
										obj = "Seven"
									Else
										flag = num = 8.0
										If flag Then
											obj = "Eight"
										Else
											flag = num = 9.0
											If flag Then
												obj = "Nine"
											Else
												obj = ""
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			End If
			Return obj
		End Function
	End Module
End Namespace
