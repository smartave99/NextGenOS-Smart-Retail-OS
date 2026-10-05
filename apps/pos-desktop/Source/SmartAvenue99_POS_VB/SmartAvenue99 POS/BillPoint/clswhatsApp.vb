Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Windows.Forms
Imports DevNetWP.Classes
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200001D RID: 29
	Public Class clswhatsApp
		' Token: 0x060007AB RID: 1963 RVA: 0x0009EDF4 File Offset: 0x0009CFF4
		Public Shared Function WhatsAppTextSender(contactNo As String, msg As String) As String
			Dim dataTable As DataTable = New DataTable()
			dataTable = clsfun.ExecDataTable("Select c1,ApiMsg from WappApi where c2='Enabled'")
			Dim text As String = ""
			Try
				Dim flag As Boolean = dataTable.Rows.Count > 0
				If flag Then
					Dim text2 As String = dataTable.Rows(0)("ApiMsg").ToString()
					text2 = text2.Replace("{No}", dataTable.Rows(0)("c1").ToString() + contactNo).Replace("{Msg}", msg)
					Dim uri As Uri = New Uri(text2)
					Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(uri), HttpWebRequest)
					Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
					Dim statusDescription As String = httpWebResponse.StatusDescription
					text = "Sucess"
				End If
			Catch ex As Exception
				text = "Failed"
				MessageBox.Show(ex.Message)
			End Try
			Return text
		End Function

		' Token: 0x060007AC RID: 1964 RVA: 0x0009EF00 File Offset: 0x0009D100
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Public Shared Function GETInstantID() As String
			Dim dataTable As DataTable = New DataTable()
			dataTable = clsfun.ExecDataTable("Select c1,WApi from WappApi where c2='Enabled'")
			Dim text As String = ""
			Dim list As List(Of String) = New List(Of String)()
			Try
				Dim flag As Boolean = dataTable.Rows.Count > 0
				If flag Then
					Dim text2 As String = dataTable.Rows(0)("Wapi").ToString()
					list = text2.Split(New Char() { "&"c }).ToList()
					Try
						For Each text3 As String In list
							Dim flag2 As Boolean = text3.ToLower().ToString().Contains("instance_id")
							If flag2 Then
								text = text3.Split(New Char() { "="c }).Last()
								Return text
							End If
						Next
					Finally
						Dim enumerator As List(Of String).Enumerator
						CType(enumerator, IDisposable).Dispose()
					End Try
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message)
				ProjectData.EndApp()
			End Try
			Return text
		End Function

		' Token: 0x060007AD RID: 1965 RVA: 0x0009F034 File Offset: 0x0009D234
		Public Shared Function WhatsAppSender(contactNo As String, msg As String, FileUrl As String) As String
			Dim text As String = ""
			Dim dataTable As DataTable = New DataTable()
			dataTable = clsfun.ExecDataTable("Select c1,WApi from WappApi where c2='Enabled'")
			Try
				Dim flag As Boolean = dataTable.Rows.Count > 0
				If flag Then
					Dim text2 As String = dataTable.Rows(0)("Wapi").ToString()
					text2 = text2.Replace("{No}", dataTable.Rows(0)("c1").ToString() + contactNo).Replace("{Msg}", msg).Replace("{url}", FileUrl)
					Dim uri As Uri = New Uri(text2)
					Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(uri), HttpWebRequest)
					Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
					text = httpWebResponse.StatusDescription
					MessageBox.Show(httpWebResponse.StatusDescription)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message)
				text = ex.Message
			End Try
			Return text
		End Function

		' Token: 0x060007AE RID: 1966 RVA: 0x0009F154 File Offset: 0x0009D354
		Public Function CheckIfFtpFileExists(fileUri As String) As Boolean
			Dim ftpWebRequest As FtpWebRequest = CType(WebRequest.Create(fileUri), FtpWebRequest)
			ftpWebRequest.Credentials = New NetworkCredential("username", "password")
			ftpWebRequest.Method = "SIZE"
			Try
				Dim ftpWebResponse As FtpWebResponse = CType(ftpWebRequest.GetResponse(), FtpWebResponse)
			Catch ex As WebException
				Dim ftpWebResponse2 As FtpWebResponse = CType(ex.Response, FtpWebResponse)
				Dim flag As Boolean = FtpStatusCode.ActionNotTakenFileUnavailable = ftpWebResponse2.StatusCode
				If flag Then
					Return False
				End If
			End Try
			Return True
		End Function

		' Token: 0x060007AF RID: 1967 RVA: 0x0009F1F0 File Offset: 0x0009D3F0
		Public Shared Function CreateFtpFolder(tmpDir As String, instantid As String, dt As DataTable, name As String, path As String, attach As String, client As WebClient, phone As String, message As String, Attachmode1 As String) As Boolean
			Dim flag As Boolean = False
			Try
				Dim text As String = dt.Rows(0)("FtpUrl").ToString() + frmLogin.InstanceID + "/" + name
				Dim text2 As String = dt.Rows(0)("FtpUrl").ToString() + frmLogin.InstanceID
				Dim flag2 As Boolean = Directory.Exists(tmpDir)
				If flag2 Then
					path = tmpDir + "\" + name
					Dim flag3 As Boolean = Operators.CompareString(Attachmode1, "F", False) = 0
					If flag3 Then
						Dim flag4 As Boolean = clswhatsApp.attachCounter = 0
						If flag4 Then
							Dim flag5 As Boolean = File.Exists(path)
							If flag5 Then
								File.Delete(path)
							End If
							File.Copy(attach, path)
							client.UploadFile(text, path)
							clswhatsApp.attachCounter += 1
						End If
					Else
						Dim flag6 As Boolean = Operators.CompareString(Attachmode1, "L", False) = 0
						If flag6 Then
							clswhatsApp.attachCounter = 0
						Else
							Dim flag7 As Boolean = Operators.CompareString(Attachmode1, "FI", False) = 0
							If flag7 Then
								Dim flag8 As Boolean = File.Exists(path)
								If flag8 Then
									File.Delete(path)
								End If
								File.Copy(attach, path)
								client.UploadFile(text, path)
								clswhatsApp.attachCounter = 0
							Else
								Dim flag9 As Boolean = File.Exists(path)
								If flag9 Then
									File.Delete(path)
								End If
								File.Copy(attach, path)
								client.UploadFile(text, path)
							End If
						End If
					End If
					Dim text3 As String = dt.Rows(0)("FileUrl").ToString() + frmLogin.InstanceID + "/" + name
					Dim wp As DevNetWP.Classes.clsWhatsapp = New DevNetWP.Classes.clsWhatsapp()
					Dim dictionary As Dictionary(Of String, Object) = wp.WhatsAppTextWithFileSender(phone, message, text3, name, frmLogin.InstanceID)
					Dim flag10 As Boolean = Conversions.ToBoolean(dictionary("success"))
					If flag10 Then
						Dim text4 As String = dictionary("result").ToString()
						flag = True
					Else
						Dim text4 As String = dictionary("message").ToString()
						MessageBox.Show(text4)
					End If
				Else
					Directory.CreateDirectory(tmpDir)
					path = tmpDir + "\" + name
					File.Copy(attach, path)
					Dim ftpWebRequest As FtpWebRequest = CType(WebRequest.Create(text2), FtpWebRequest)
					ftpWebRequest.Credentials = New NetworkCredential(dt.Rows(0)("FtpUser").ToString(), dt.Rows(0)("FtpPassword").ToString())
					ftpWebRequest.Method = "MKD"
					Using CType(ftpWebRequest.GetResponse(), FtpWebResponse)
						client.UploadFile(text, path)
						Dim text5 As String = dt.Rows(0)("FileUrl").ToString() + frmLogin.InstanceID + "/" + name
						Dim wp2 As DevNetWP.Classes.clsWhatsapp = New DevNetWP.Classes.clsWhatsapp()
						Dim dictionary2 As Dictionary(Of String, Object) = wp2.WhatsAppTextWithFileSender(phone, message, text5, name, frmLogin.InstanceID)
						Dim flag11 As Boolean = Conversions.ToBoolean(dictionary2("success"))
						If flag11 Then
							Dim text6 As String = dictionary2("result").ToString()
							flag = True
							MessageBox.Show("Success")
						Else
							Dim text6 As String = dictionary2("message").ToString()
							MessageBox.Show(text6)
						End If
					End Using
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
			Return flag
		End Function

		' Token: 0x060007B0 RID: 1968 RVA: 0x0009F5B8 File Offset: 0x0009D7B8
		Public Shared Function CreateFtpFolder2(tmpDir As String, token As String, dt As DataTable, name As String, path As String, attach As String, client As WebClient, phone As String, message As String, Attachmode1 As String) As Boolean
			Dim text As String = ""
			Dim flag As Boolean = False
			Try
				Dim text2 As String = Application.StartupPath + "\2ndW.txt"
				Dim flag2 As Boolean = File.Exists(text2)
				If flag2 Then
					Dim list As List(Of String) = File.ReadAllLines(text2).ToList()
					Dim flag3 As Boolean = list.Count > 0
					If flag3 Then
						text = list(0)
					End If
				Else
					MessageBox.Show("File not found!")
				End If
				Dim text3 As String = dt.Rows(0)("FtpUrl").ToString() + token + "/" + name
				Dim text4 As String = dt.Rows(0)("FtpUrl").ToString() + token
				Dim flag4 As Boolean = Directory.Exists(tmpDir)
				If flag4 Then
					path = tmpDir + "\" + name
					Dim flag5 As Boolean = Operators.CompareString(Attachmode1, "F", False) = 0
					If flag5 Then
						Dim flag6 As Boolean = clswhatsApp.attachCounter = 0
						If flag6 Then
							Dim flag7 As Boolean = File.Exists(path)
							If flag7 Then
								File.Delete(path)
							End If
							File.Copy(attach, path)
							client.UploadFile(text3, path)
							clswhatsApp.attachCounter += 1
						End If
					Else
						Dim flag8 As Boolean = Operators.CompareString(Attachmode1, "L", False) = 0
						If flag8 Then
							clswhatsApp.attachCounter = 0
						Else
							Dim flag9 As Boolean = Operators.CompareString(Attachmode1, "FI", False) = 0
							If flag9 Then
								Dim flag10 As Boolean = File.Exists(path)
								If flag10 Then
									File.Delete(path)
								End If
								File.Copy(attach, path)
								client.UploadFile(text3, path)
								clswhatsApp.attachCounter = 0
							Else
								Dim flag11 As Boolean = File.Exists(path)
								If flag11 Then
									File.Delete(path)
								End If
								File.Copy(attach, path)
								client.UploadFile(text3, path)
							End If
						End If
					End If
					Dim text5 As String = dt.Rows(0)("FileUrl").ToString() + token + "/" + name
					Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create("https://api.ultramsg.com/" + text + "/messages/document"), HttpWebRequest)
					Dim text6 As String = String.Concat(New String() { "token=", token, "&to=", phone, "&filename=", name, "&document=", text5, "&caption=", message })
					Dim utf8Encoding As UTF8Encoding = New UTF8Encoding()
					Dim bytes As Byte() = utf8Encoding.GetBytes(text6)
					httpWebRequest.Method = "POST"
					httpWebRequest.ContentType = "application/x-www-form-urlencoded"
					httpWebRequest.GetRequestStream().Write(bytes, 0, bytes.Length)
					Dim streamReader As StreamReader = New StreamReader(httpWebRequest.GetResponse().GetResponseStream())
					Console.WriteLine(streamReader.ReadToEnd())
				Else
					Directory.CreateDirectory(tmpDir)
					path = tmpDir + "\" + name
					File.Copy(attach, path)
					Dim ftpWebRequest As FtpWebRequest = CType(WebRequest.Create(text4), FtpWebRequest)
					ftpWebRequest.Credentials = New NetworkCredential(dt.Rows(0)("FtpUser").ToString(), dt.Rows(0)("FtpPassword").ToString())
					ftpWebRequest.Method = "MKD"
					Using CType(ftpWebRequest.GetResponse(), FtpWebResponse)
						client.UploadFile(text3, path)
						Dim text7 As String = dt.Rows(0)("FileUrl").ToString() + token + "/" + name
						Dim httpWebRequest2 As HttpWebRequest = CType(WebRequest.Create("https://api.ultramsg.com/" + text + "/messages/document"), HttpWebRequest)
						Dim text8 As String = String.Concat(New String() { "token=", token, "&to=", phone, "&filename=", name, "&document=", text7, "&caption=", message })
						Dim utf8Encoding2 As UTF8Encoding = New UTF8Encoding()
						Dim bytes2 As Byte() = utf8Encoding2.GetBytes(text8)
						httpWebRequest2.Method = "POST"
						httpWebRequest2.ContentType = "application/x-www-form-urlencoded"
						httpWebRequest2.GetRequestStream().Write(bytes2, 0, bytes2.Length)
						Dim streamReader2 As StreamReader = New StreamReader(httpWebRequest2.GetResponse().GetResponseStream())
						Console.WriteLine(streamReader2.ReadToEnd())
						flag = True
					End Using
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
			Return flag
		End Function

		' Token: 0x060007B1 RID: 1969 RVA: 0x0009FA8C File Offset: 0x0009DC8C
		Public Shared Function CreateFtpFolder_link(tmpDir As String, token As String, dt As DataTable, name As String, path As String, attach As String, phone As String, message As String, Attachmode1 As String, ftp_username As String, ftp_password As String, strWa_Name As String, strWa_InvoiceNo As String, strWa_GTotal As String, strWa_InvoiceDt As String, strWa_Company As String) As Boolean
			Dim text As String = ""
			Dim flag As Boolean = False
			Try
				Dim text2 As String = Application.StartupPath + "\2ndW.txt"
				Dim flag2 As Boolean = File.Exists(text2)
				If Not flag2 Then
					MessageBox.Show("File not found!")
					Return False
				End If
				Dim list As List(Of String) = File.ReadAllLines(text2).ToList()
				Dim flag3 As Boolean = list.Count > 0
				If flag3 Then
					text = list(0)
					token = list(1)
				End If
				Dim text3 As String = dt.Rows(0)("FtpUrl").ToString() + token + "/" + name
				Dim text4 As String = dt.Rows(0)("FtpUrl").ToString() + token
				Dim flag4 As Boolean = Directory.Exists(tmpDir)
				If flag4 Then
					path = System.IO.Path.Combine(tmpDir, name)
					If Operators.CompareString(Attachmode1, "F", False) <> 0 Then
						If Operators.CompareString(Attachmode1, "L", False) <> 0 Then
							If Operators.CompareString(Attachmode1, "FI", False) <> 0 Then
								Dim flag5 As Boolean = File.Exists(path)
								If flag5 Then
									File.Delete(path)
								End If
								File.Copy(attach, path)
								clswhatsApp.UploadFileFTP(text3, path, ftp_username, ftp_password)
							Else
								Dim flag6 As Boolean = File.Exists(path)
								If flag6 Then
									File.Delete(path)
								End If
								File.Copy(attach, path)
								clswhatsApp.attachCounter = 0
							End If
						Else
							clswhatsApp.attachCounter = 0
						End If
					Else
						Dim flag7 As Boolean = clswhatsApp.attachCounter = 0
						If flag7 Then
							Dim flag8 As Boolean = File.Exists(path)
							If flag8 Then
								File.Delete(path)
							End If
							File.Copy(attach, path)
							clswhatsApp.attachCounter += 1
						End If
					End If
					Dim text5 As String = dt.Rows(0)("FileUrl").ToString() + token + "/" + name
					Try
						Dim text6 As String = "https://api.ultramsg.com/" + text + "/messages/chat"
						Dim text7 As String = String.Concat(New String() { "Dear ", strWa_Name.Trim(), " ," & vbCrLf & vbCrLf & "Thank you for your recent order at ", strWa_Company, "! Your invoice is now available. 🪄" & vbCrLf & vbCrLf & "🧾 Invoice No : ", strWa_InvoiceNo.Trim(), vbCrLf & "💰 Amount : Rs.", strWa_GTotal.Trim(), vbCrLf & "📅 Date : ", strWa_InvoiceDt.Trim(), vbCrLf & "🔗 View Invoice : ", text5, vbCrLf & vbCrLf & "Loved your experience? Or something to improve? Tap to tell us! 💬✨" })
						Dim text8 As String = Uri.EscapeDataString(text7)
						Dim text9 As String = String.Format("token={0}&to={1}&body={2}", token, phone, text8)
						Dim bytes As Byte() = Encoding.UTF8.GetBytes(text9)
						Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(text6), HttpWebRequest)
						httpWebRequest.Method = "POST"
						httpWebRequest.ContentType = "application/x-www-form-urlencoded"
						Using requestStream As Stream = httpWebRequest.GetRequestStream()
							requestStream.Write(bytes, 0, bytes.Length)
						End Using
						Using response As WebResponse = httpWebRequest.GetResponse()
							Using streamReader As StreamReader = New StreamReader(response.GetResponseStream())
								Dim text10 As String = streamReader.ReadToEnd()
								Console.WriteLine(text10)
							End Using
						End Using
						flag = True
					Catch ex As Exception
						MessageBox.Show("Error sending message: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message)
			End Try
			Return flag
		End Function

		' Token: 0x060007B2 RID: 1970 RVA: 0x0009FE94 File Offset: 0x0009E094
		Private Shared Sub UploadFileFTP(ftpUrl As String, localFilePath As String, username As String, password As String)
			Try
				Dim ftpWebRequest As FtpWebRequest = CType(WebRequest.Create(ftpUrl), FtpWebRequest)
				ftpWebRequest.Method = "STOR"
				ftpWebRequest.Credentials = New NetworkCredential(username, password)
				ftpWebRequest.UseBinary = True
				ftpWebRequest.UsePassive = True
				ftpWebRequest.KeepAlive = False
				Dim array As Byte() = File.ReadAllBytes(localFilePath)
				ftpWebRequest.ContentLength = CLng(array.Length)
				Using requestStream As Stream = ftpWebRequest.GetRequestStream()
					requestStream.Write(array, 0, array.Length)
				End Using
				Using ftpWebResponse As FtpWebResponse = CType(ftpWebRequest.GetResponse(), FtpWebResponse)
					Console.WriteLine("Upload File Complete, status {0}", ftpWebResponse.StatusDescription)
				End Using
			Catch ex As Exception
				MessageBox.Show("FTP Upload Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x040002DE RID: 734
		Public Shared attachCounter As Integer = 0
	End Class
End Namespace
