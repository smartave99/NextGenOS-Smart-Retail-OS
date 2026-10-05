Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Net

Namespace BillPoint
	' Token: 0x02000019 RID: 25
	Public Class ApiRequestor
		' Token: 0x06000770 RID: 1904 RVA: 0x0000A172 File Offset: 0x00008372
		Public Sub New()
			Me.baseurl = "https://web.raintechherbals.com/api/"
		End Sub

		' Token: 0x06000771 RID: 1905 RVA: 0x0009E518 File Offset: 0x0009C718
		Public Function GetMEthods(url As String) As Dictionary(Of String, Object)
			Dim text As String = "https://web.raintechherbals.com/api/" + url
			Dim dictionary As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
			Try
				Dim webRequest As WebRequest = WebRequest.Create(text)
				webRequest.Method = "GET"
				Using response As WebResponse = webRequest.GetResponse()
					Using responseStream As Stream = response.GetResponseStream()
						Using streamReader As StreamReader = New StreamReader(responseStream)
							dictionary("success") = True
							dictionary("result") = streamReader.ReadToEnd()
						End Using
					End Using
				End Using
			Catch ex As Exception
				dictionary("success") = False
				dictionary("message") = ex.Message
			End Try
			Return dictionary
		End Function

		' Token: 0x06000772 RID: 1906 RVA: 0x0009E630 File Offset: 0x0009C830
		Public Shared Function RequestGetMethods(url As String) As String
			Dim text As String = ""
			Try
				Dim uri As Uri = New Uri(url)
				Dim webRequest As WebRequest = WebRequest.Create(uri)
				webRequest.Method = "GET"
				Dim response As WebResponse = webRequest.GetResponse()
				Dim streamReader As StreamReader = New StreamReader(response.GetResponseStream())
				Dim text2 As String = streamReader.ReadToEnd().Trim()
				text = text2
			Catch ex As Exception
				text = "-1"
			End Try
			Return text
		End Function

		' Token: 0x040002CA RID: 714
		Private baseurl As String
	End Class
End Namespace
