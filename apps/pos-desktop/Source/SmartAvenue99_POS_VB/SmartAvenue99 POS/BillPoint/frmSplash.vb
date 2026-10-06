Imports System
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports DevNetLM
Imports DevNetLM.Models
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.Win32

Namespace BillPoint
	' Token: 0x020005CF RID: 1487
	<DesignerGenerated()>
	Public Partial Class frmSplash
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0601223F RID: 74303 RVA: 0x0007C609 File Offset: 0x0007A809
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSplash1_Load
			Me.InitializeComponent()
			AddHandler MyBase.Shown, Sub(sender, e)
				If Not AppleUITheme.IsCapturing Then RetailLayouts.Apply(Me)
			End Sub
		End Sub

		' Token: 0x170070A7 RID: 28839
		' (get) Token: 0x06012242 RID: 74306 RVA: 0x0007C629 File Offset: 0x0007A829
		' (set) Token: 0x06012243 RID: 74307 RVA: 0x00A70F30 File Offset: 0x00A6F130
		Private _Timer1 As Timer
		Friend Overridable Property Timer1 As Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer1_Tick
				Dim timer As Timer = Me._Timer1
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer1 = value
				timer = Me._Timer1
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170070A8 RID: 28840
		' (get) Token: 0x06012244 RID: 74308 RVA: 0x0007C633 File Offset: 0x0007A833
		' (set) Token: 0x06012245 RID: 74309 RVA: 0x0007C63D File Offset: 0x0007A83D
		Friend Overridable Property ProgressBar1 As ProgressBar

		' Token: 0x170070A9 RID: 28841
		' (get) Token: 0x06012246 RID: 74310 RVA: 0x0007C646 File Offset: 0x0007A846
		' (set) Token: 0x06012247 RID: 74311 RVA: 0x0007C650 File Offset: 0x0007A850
		Friend Overridable Property lblSet As Label

		' Token: 0x170070AA RID: 28842
		' (get) Token: 0x06012248 RID: 74312 RVA: 0x0007C659 File Offset: 0x0007A859
		' (set) Token: 0x06012249 RID: 74313 RVA: 0x0007C663 File Offset: 0x0007A863
		Friend Overridable Property LinkLabel1 As LinkLabel

		' Token: 0x170070AB RID: 28843
		' (get) Token: 0x0601224A RID: 74314 RVA: 0x0007C66C File Offset: 0x0007A86C
		' (set) Token: 0x0601224B RID: 74315 RVA: 0x0007C676 File Offset: 0x0007A876
		Friend Overridable Property Label3 As Label

		' Token: 0x170070AC RID: 28844
		' (get) Token: 0x0601224C RID: 74316 RVA: 0x0007C67F File Offset: 0x0007A87F
		' (set) Token: 0x0601224D RID: 74317 RVA: 0x0007C689 File Offset: 0x0007A889
		Friend Overridable Property ProgressBar2 As ProgressBar

		' Token: 0x170070AD RID: 28845
		' (get) Token: 0x0601224E RID: 74318 RVA: 0x0007C692 File Offset: 0x0007A892
		' (set) Token: 0x0601224F RID: 74319 RVA: 0x0007C69C File Offset: 0x0007A89C
		Friend Overridable Property PictureBox2 As PictureBox

		' Token: 0x170070AE RID: 28846
		' (get) Token: 0x06012250 RID: 74320 RVA: 0x0007C6A5 File Offset: 0x0007A8A5
		' (set) Token: 0x06012251 RID: 74321 RVA: 0x0007C6AF File Offset: 0x0007A8AF
		Friend Overridable Property lblSet2 As Label

		' Token: 0x170070AF RID: 28847
		' (get) Token: 0x06012252 RID: 74322 RVA: 0x0007C6B8 File Offset: 0x0007A8B8
		' (set) Token: 0x06012253 RID: 74323 RVA: 0x0007C6C2 File Offset: 0x0007A8C2
		Friend Overridable Property Label2 As Label

		' Token: 0x170070B0 RID: 28848
		' (get) Token: 0x06012254 RID: 74324 RVA: 0x0007C6CB File Offset: 0x0007A8CB
		' (set) Token: 0x06012255 RID: 74325 RVA: 0x0007C6D5 File Offset: 0x0007A8D5
		Friend Overridable Property LabelVersion As Label

		' Token: 0x170070B1 RID: 28849
		' (get) Token: 0x06012256 RID: 74326 RVA: 0x0007C6DE File Offset: 0x0007A8DE
		' (set) Token: 0x06012257 RID: 74327 RVA: 0x0007C6E8 File Offset: 0x0007A8E8
		Friend Overridable Property Label1 As Label

		' Token: 0x170070B2 RID: 28850
		' (get) Token: 0x06012258 RID: 74328 RVA: 0x0007C6F1 File Offset: 0x0007A8F1
		' (set) Token: 0x06012259 RID: 74329 RVA: 0x0007C6FB File Offset: 0x0007A8FB
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170070B3 RID: 28851
		' (get) Token: 0x0601225A RID: 74330 RVA: 0x0007C704 File Offset: 0x0007A904
		' (set) Token: 0x0601225B RID: 74331 RVA: 0x0007C70E File Offset: 0x0007A90E
		Friend Overridable Property Label4 As Label

		' Token: 0x170070B4 RID: 28852
		' (get) Token: 0x0601225C RID: 74332 RVA: 0x0007C717 File Offset: 0x0007A917
		' (set) Token: 0x0601225D RID: 74333 RVA: 0x0007C721 File Offset: 0x0007A921
		Friend Overridable Property Label5 As Label

		' Token: 0x170070B5 RID: 28853
		' (get) Token: 0x0601225E RID: 74334 RVA: 0x0007C72A File Offset: 0x0007A92A
		' (set) Token: 0x0601225F RID: 74335 RVA: 0x0007C734 File Offset: 0x0007A934
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x06012260 RID: 74336 RVA: 0x00A70F74 File Offset: 0x00A6F174
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Public Sub Timer1_Tick(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = File.Exists(Application.StartupPath + "\SQLSettings.dat")
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.ProgressBar2.Visible = True
					Me.ProgressBar2.Value = Me.ProgressBar2.Value + 1
					flag = Me.ProgressBar2.Value = 10
					Dim flag3 As Boolean = flag
					If flag3 Then
						Me.lblSet2.Text = "Reading modules.."
					Else
						flag = Me.ProgressBar2.Value = 20
						Dim flag4 As Boolean = flag
						If flag4 Then
							Me.lblSet2.Text = "Turning on modules."
						Else
							flag = Me.ProgressBar2.Value = 40
							Dim flag5 As Boolean = flag
							If flag5 Then
								Me.lblSet2.Text = "Starting modules.."
							Else
								flag = Me.ProgressBar2.Value = 60
								Dim flag6 As Boolean = flag
								If flag6 Then
									Me.lblSet2.Text = "Loading modules.."
								Else
									flag = Me.ProgressBar2.Value = 80
									Dim flag7 As Boolean = flag
									If flag7 Then
										Me.lblSet2.Text = "Done Loading modules.."
									Else
										flag = Me.ProgressBar2.Value = 100
										Dim flag8 As Boolean = flag
										If flag8 Then
											Me.Timer1.Enabled = False
											ModCommonClasses.con = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
											ModCommonClasses.con.Open()
											Dim text As String = "select * from RaintechMaster"
											ModCommonClasses.cmd = New SqlCommand(text)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											flag = ModCommonClasses.rdr.Read()
											Dim flag9 As Boolean = flag
											If flag9 Then
												Dim licenseResponse As LicenseResponse = DevNetLM.DevNet.Validate()
												Dim flag10 As Boolean = licenseResponse.LicenseData IsNot Nothing
												If flag10 Then
													Dim licenseData As LicenseData = licenseResponse.LicenseData
													MyProject.Forms.frmLogin.Show()
													MyBase.Hide()
												Else
													Dim showActivation As Boolean = licenseResponse.ShowActivation
													If showActivation Then
														DevNetLM.DevNet.ShowActivation()
													Else
														MessageBox.Show(licenseResponse.Message)
													End If
													Environment.[Exit](0)
												End If
											Else
												MyProject.Forms.frmCompany.Show()
												MyBase.Hide()
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				Else
					Me.ProgressBar2.Visible = True
					Me.ProgressBar2.Value = Me.ProgressBar2.Value + 2
					flag = Me.ProgressBar2.Value = 10
					Dim flag11 As Boolean = flag
					If flag11 Then
						Me.lblSet2.Text = "Reading modules.."
					Else
						flag = Me.ProgressBar2.Value = 20
						Dim flag12 As Boolean = flag
						If flag12 Then
							Me.lblSet2.Text = "Turning on modules."
						Else
							flag = Me.ProgressBar2.Value = 40
							Dim flag13 As Boolean = flag
							If flag13 Then
								Me.lblSet2.Text = "Starting modules.."
							Else
								flag = Me.ProgressBar2.Value = 60
								Dim flag14 As Boolean = flag
								If flag14 Then
									Me.lblSet2.Text = "Loading modules.."
								Else
									flag = Me.ProgressBar2.Value = 80
									Dim flag15 As Boolean = flag
									If flag15 Then
										Me.lblSet2.Text = "Done Loading modules.."
									Else
										flag = Me.ProgressBar2.Value = 100
										Dim flag16 As Boolean = flag
										If flag16 Then
											Me.Timer1.Enabled = False
											MyBase.Hide()
											MyProject.Forms.frmSqlServerSetting.Reset()
											MyProject.Forms.frmSqlServerSetting.ShowDialog()
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			Catch ex As Exception
				Try
					File.WriteAllText(Application.StartupPath + "\startup_error.txt", ex.ToString())
				Catch
				End Try
				Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!")
				ProjectData.EndApp()
			End Try
		End Sub

		' Token: 0x06012261 RID: 74337 RVA: 0x0007C73D File Offset: 0x0007A93D
		Private Sub frmSplash1_Load(sender As Object, e As EventArgs)
			If AppleUITheme.IsCapturing Then Return
			Try
				If File.Exists(Application.StartupPath + "\do_capture.flag") Then
					Try
						File.Delete(Application.StartupPath + "\do_capture.flag")
					Catch
					End Try
					If Me.Timer1 IsNot Nothing Then Me.Timer1.Enabled = False
					File.AppendAllText(Application.StartupPath + "\capture_trace.txt", "Starting CaptureProofs single run..." & vbCrLf)
					AppleUITheme.CaptureProofs(Application.StartupPath, Me)
					File.AppendAllText(Application.StartupPath + "\capture_trace.txt", "Finished CaptureProofs successfully!" & vbCrLf)
					Environment.Exit(0)
					Return
				End If
				Me.LabelVersion.Text = String.Format("Version {0}", MyProject.Application.Info.Version.ToString().Substring(0, 3))
				Me.BackColor = AppleUITheme.CardBg
				Me.Label1.Font = AppleUITheme.FontHero(20F)
				Me.Label1.ForeColor = AppleUITheme.TextPrimary
				Me.Label2.Font = AppleUITheme.FontSemiBold(11F)
				Me.Label2.ForeColor = AppleUITheme.TextSecondary
				Me.Label2.Text = "Enterprise Edition"
				Me.LabelVersion.Font = AppleUITheme.FontRegular(9F)
				Me.LabelVersion.ForeColor = AppleUITheme.TextSecondary
				Me.getRegistrydata()
			Catch ex As Exception
				Try
					File.WriteAllText(Application.StartupPath + "\splash_load_error.txt", ex.ToString())
				Catch
				End Try
			End Try
		End Sub

		' The shop's name and logo now come from the signed licence (DevNetLM.CompanyInfo), not from the registry.
		Public Function getRegistrydata() As frmSplash.LicenseDataNew
			Dim licenseDataNew As frmSplash.LicenseDataNew = New frmSplash.LicenseDataNew()
			Try
				Dim info As DevNetLM.CompanyInfo = DevNetLM.CompanyInfo.Read()
				licenseDataNew.LKey = info.LicenceKey
				licenseDataNew.issuedby1 = "NextGenOS"
				licenseDataNew.issued_byid1 = "NextGenOS"
				Me.Label1.Text = info.Company
				licenseDataNew.company = info.Company
				licenseDataNew.name = info.Name
				licenseDataNew.email = info.Email
				licenseDataNew.phone = info.Phone
				licenseDataNew.address = info.Address
				licenseDataNew.state = info.State
				licenseDataNew.country = info.Country
				licenseDataNew.Logo = info.Logo
				If Not String.IsNullOrWhiteSpace(licenseDataNew.Logo) Then
					Dim splashLogo As Image = Me.Base64ToImage(licenseDataNew.Logo)
					If splashLogo IsNot Nothing Then
						Me.PictureBox2.Image = splashLogo
					End If
				End If
				licenseDataNew.MainLogo = info.MainLogo
			Catch ex As Exception
			End Try
			Return licenseDataNew
		End Function

		' Token: 0x06012264 RID: 74340 RVA: 0x00A71678 File Offset: 0x00A6F878
		Public Function Base64ToImage(base64string As String) As Image
			If String.IsNullOrWhiteSpace(base64string) Then
				Return Nothing
			End If
			Try
				Dim text As String = base64string.Trim().Replace(" ", "+")
				Dim commaIndex As Integer = text.IndexOf(","c)
				If commaIndex >= 0 Then
					text = text.Substring(commaIndex + 1)
				End If
				Dim array As Byte() = Convert.FromBase64String(text)
				If array Is Nothing OrElse array.Length = 0 Then
					Return Nothing
				End If
				Using memoryStream As MemoryStream = New MemoryStream(array)
					Using rawImg As Image = Image.FromStream(memoryStream)
						Return New Bitmap(rawImg)
					End Using
				End Using
			Catch ex As Exception
				Return Nothing
			End Try
		End Function

		' Token: 0x020005D0 RID: 1488
		Public Class LicenseDataNew
			' Token: 0x170070B6 RID: 28854
			' (get) Token: 0x06012266 RID: 74342 RVA: 0x0007C778 File Offset: 0x0007A978
			' (set) Token: 0x06012267 RID: 74343 RVA: 0x0007C782 File Offset: 0x0007A982
			Public Property LKey As String

			' Token: 0x170070B7 RID: 28855
			' (get) Token: 0x06012268 RID: 74344 RVA: 0x0007C78B File Offset: 0x0007A98B
			' (set) Token: 0x06012269 RID: 74345 RVA: 0x0007C795 File Offset: 0x0007A995
			Public Property issuedby1 As String

			' Token: 0x170070B8 RID: 28856
			' (get) Token: 0x0601226A RID: 74346 RVA: 0x0007C79E File Offset: 0x0007A99E
			' (set) Token: 0x0601226B RID: 74347 RVA: 0x0007C7A8 File Offset: 0x0007A9A8
			Public Property issued_byid1 As String

			' Token: 0x170070B9 RID: 28857
			' (get) Token: 0x0601226C RID: 74348 RVA: 0x0007C7B1 File Offset: 0x0007A9B1
			' (set) Token: 0x0601226D RID: 74349 RVA: 0x0007C7BB File Offset: 0x0007A9BB
			Public Property company As String

			' Token: 0x170070BA RID: 28858
			' (get) Token: 0x0601226E RID: 74350 RVA: 0x0007C7C4 File Offset: 0x0007A9C4
			' (set) Token: 0x0601226F RID: 74351 RVA: 0x0007C7CE File Offset: 0x0007A9CE
			Public Property name As String

			' Token: 0x170070BB RID: 28859
			' (get) Token: 0x06012270 RID: 74352 RVA: 0x0007C7D7 File Offset: 0x0007A9D7
			' (set) Token: 0x06012271 RID: 74353 RVA: 0x0007C7E1 File Offset: 0x0007A9E1
			Public Property email As String

			' Token: 0x170070BC RID: 28860
			' (get) Token: 0x06012272 RID: 74354 RVA: 0x0007C7EA File Offset: 0x0007A9EA
			' (set) Token: 0x06012273 RID: 74355 RVA: 0x0007C7F4 File Offset: 0x0007A9F4
			Public Property phone As String

			' Token: 0x170070BD RID: 28861
			' (get) Token: 0x06012274 RID: 74356 RVA: 0x0007C7FD File Offset: 0x0007A9FD
			' (set) Token: 0x06012275 RID: 74357 RVA: 0x0007C807 File Offset: 0x0007AA07
			Public Property address As String

			' Token: 0x170070BE RID: 28862
			' (get) Token: 0x06012276 RID: 74358 RVA: 0x0007C810 File Offset: 0x0007AA10
			' (set) Token: 0x06012277 RID: 74359 RVA: 0x0007C81A File Offset: 0x0007AA1A
			Public Property state As String

			' Token: 0x170070BF RID: 28863
			' (get) Token: 0x06012278 RID: 74360 RVA: 0x0007C823 File Offset: 0x0007AA23
			' (set) Token: 0x06012279 RID: 74361 RVA: 0x0007C82D File Offset: 0x0007AA2D
			Public Property country As String

			' Token: 0x170070C0 RID: 28864
			' (get) Token: 0x0601227A RID: 74362 RVA: 0x0007C836 File Offset: 0x0007AA36
			' (set) Token: 0x0601227B RID: 74363 RVA: 0x0007C840 File Offset: 0x0007AA40
			Public Property is_active As Boolean

			' Token: 0x170070C1 RID: 28865
			' (get) Token: 0x0601227C RID: 74364 RVA: 0x0007C849 File Offset: 0x0007AA49
			' (set) Token: 0x0601227D RID: 74365 RVA: 0x0007C853 File Offset: 0x0007AA53
			Public Property Logo As String

			' Token: 0x170070C2 RID: 28866
			' (get) Token: 0x0601227E RID: 74366 RVA: 0x0007C85C File Offset: 0x0007AA5C
			' (set) Token: 0x0601227F RID: 74367 RVA: 0x0007C866 File Offset: 0x0007AA66
			Public Property MainLogo As String
		End Class
	End Class
End Namespace
