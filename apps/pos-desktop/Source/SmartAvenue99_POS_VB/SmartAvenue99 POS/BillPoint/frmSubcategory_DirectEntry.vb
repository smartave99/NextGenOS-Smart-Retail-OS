Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000201 RID: 513
	<DesignerGenerated()>
	Public Partial Class frmSubcategory_DirectEntry
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060093AB RID: 37803 RVA: 0x00048470 File Offset: 0x00046670
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSubcategory_DirectEntry_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x170036C7 RID: 14023
		' (get) Token: 0x060093AE RID: 37806 RVA: 0x00048490 File Offset: 0x00046690
		' (set) Token: 0x060093AF RID: 37807 RVA: 0x0004849A File Offset: 0x0004669A
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170036C8 RID: 14024
		' (get) Token: 0x060093B0 RID: 37808 RVA: 0x000484A3 File Offset: 0x000466A3
		' (set) Token: 0x060093B1 RID: 37809 RVA: 0x000484AD File Offset: 0x000466AD
		Friend Overridable Property CheckBox1 As CheckBox

		' Token: 0x170036C9 RID: 14025
		' (get) Token: 0x060093B2 RID: 37810 RVA: 0x000484B6 File Offset: 0x000466B6
		' (set) Token: 0x060093B3 RID: 37811 RVA: 0x000484C0 File Offset: 0x000466C0
		Friend Overridable Property cmbSubCategory As ComboBox

		' Token: 0x170036CA RID: 14026
		' (get) Token: 0x060093B4 RID: 37812 RVA: 0x000484C9 File Offset: 0x000466C9
		' (set) Token: 0x060093B5 RID: 37813 RVA: 0x000484D3 File Offset: 0x000466D3
		Friend Overridable Property cmbCategory As ComboBox

		' Token: 0x170036CB RID: 14027
		' (get) Token: 0x060093B6 RID: 37814 RVA: 0x000484DC File Offset: 0x000466DC
		' (set) Token: 0x060093B7 RID: 37815 RVA: 0x000484E6 File Offset: 0x000466E6
		Friend Overridable Property Label2 As Label

		' Token: 0x170036CC RID: 14028
		' (get) Token: 0x060093B8 RID: 37816 RVA: 0x000484EF File Offset: 0x000466EF
		' (set) Token: 0x060093B9 RID: 37817 RVA: 0x006ACFAC File Offset: 0x006AB1AC
		Private _btnSave As GelButton
		Friend Overridable Property btnSave As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSave = value
				gelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170036CD RID: 14029
		' (get) Token: 0x060093BA RID: 37818 RVA: 0x000484F9 File Offset: 0x000466F9
		' (set) Token: 0x060093BB RID: 37819 RVA: 0x00048503 File Offset: 0x00046703
		Friend Overridable Property txtID As TextBox

		' Token: 0x170036CE RID: 14030
		' (get) Token: 0x060093BC RID: 37820 RVA: 0x0004850C File Offset: 0x0004670C
		' (set) Token: 0x060093BD RID: 37821 RVA: 0x00048516 File Offset: 0x00046716
		Public Overridable Property Picture As PictureBox

		' Token: 0x170036CF RID: 14031
		' (get) Token: 0x060093BE RID: 37822 RVA: 0x0004851F File Offset: 0x0004671F
		' (set) Token: 0x060093BF RID: 37823 RVA: 0x00048529 File Offset: 0x00046729
		Friend Overridable Property lblUser As Label

		' Token: 0x170036D0 RID: 14032
		' (get) Token: 0x060093C0 RID: 37824 RVA: 0x00048532 File Offset: 0x00046732
		' (set) Token: 0x060093C1 RID: 37825 RVA: 0x0004853C File Offset: 0x0004673C
		Public Property POSForm As frmPOSNewTuch

		' Token: 0x170036D1 RID: 14033
		' (get) Token: 0x060093C2 RID: 37826 RVA: 0x00048545 File Offset: 0x00046745
		' (set) Token: 0x060093C3 RID: 37827 RVA: 0x0004854F File Offset: 0x0004674F
		Public Property POSForm1 As frmPOSNewTuch_Service

		' Token: 0x170036D2 RID: 14034
		' (get) Token: 0x060093C4 RID: 37828 RVA: 0x00048558 File Offset: 0x00046758
		' (set) Token: 0x060093C5 RID: 37829 RVA: 0x00048562 File Offset: 0x00046762
		Public Property POSForm2 As frmPOSNewTuch_StockTransfer

		' Token: 0x170036D3 RID: 14035
		' (get) Token: 0x060093C6 RID: 37830 RVA: 0x0004856B File Offset: 0x0004676B
		' (set) Token: 0x060093C7 RID: 37831 RVA: 0x00048575 File Offset: 0x00046775
		Public Property POSForm3 As frmPOSNewTuch_StockInward

		' Token: 0x170036D4 RID: 14036
		' (get) Token: 0x060093C8 RID: 37832 RVA: 0x0004857E File Offset: 0x0004677E
		' (set) Token: 0x060093C9 RID: 37833 RVA: 0x00048588 File Offset: 0x00046788
		Public Property POSForm4 As frmPOSNewTuch_Quotation

		' Token: 0x060093CA RID: 37834 RVA: 0x00048591 File Offset: 0x00046791
		Private Sub frmSubcategory_DirectEntry_Load(sender As Object, e As EventArgs)
			Me.cmbCategory.SelectedIndex = 0
			Me.auto()
		End Sub

		' Token: 0x060093CB RID: 37835 RVA: 0x006ACFF0 File Offset: 0x006AB1F0
		Private Sub auto()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT MAX(ID) FROM SubCategory"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim flag As Boolean = Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.cmd.ExecuteScalar()))
				If flag Then
					Dim num As Integer = 1
					Me.txtID.Text = num.ToString()
				Else
					Dim num As Integer = Conversions.ToInteger(Operators.AddObject(ModCommonClasses.cmd.ExecuteScalar(), 1))
					Me.txtID.Text = num.ToString()
				End If
				ModCommonClasses.cmd.Dispose()
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060093CC RID: 37836 RVA: 0x006AD0F4 File Offset: 0x006AB2F4
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbSubCategory.Text)) = 0
			If flag Then
				MessageBox.Show("Please enter sub category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbSubCategory.Focus()
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.cmbCategory.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbCategory.Focus()
				Else
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "select SubCategoryName,Category from SubCategory where SubCategoryName=@d1 and Category=@d2"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbSubCategory.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbCategory.Text)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
						If flag3 Then
							MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.cmbSubCategory.Text = ""
							Me.cmbSubCategory.Focus()
							Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag4 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							Dim checked As Boolean = Me.CheckBox1.Checked
							If checked Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text2 As String = "select IsDefault from SubCategory where IsDefault='Yes'"
								ModCommonClasses.cmd = New SqlCommand(text2)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
								If flag5 Then
									MessageBox.Show("Sub Category is already set as default", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag6 Then
										ModCommonClasses.rdr.Close()
									End If
									Return
								End If
							End If
							Dim text3 As String = "No"
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text4 As String = "insert into SubCategory(SubCategoryName,Category,ID,SCPhoto, IsDefault) VALUES (@d1,@d2," + Me.txtID.Text + ",@d3, @d4)"
							ModCommonClasses.cmd = New SqlCommand(text4)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbSubCategory.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbCategory.Text)
							Dim memoryStream As MemoryStream = New MemoryStream()
							Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
							bitmap.Save(memoryStream, ImageFormat.Jpeg)
							Dim buffer As Byte() = memoryStream.GetBuffer()
							Dim sqlParameter As SqlParameter = New SqlParameter("@d3", SqlDbType.Image)
							sqlParameter.Value = buffer
							ModCommonClasses.cmd.Parameters.Add(sqlParameter)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", text3)
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							ModFunc.LogFunc(Me.lblUser.Text, String.Concat(New String() { "added the new subcategory '", Me.cmbSubCategory.Text, "' having Category '", Me.cmbCategory.Text, "'" }))
							MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Dim flag7 As Boolean = Me.POSForm IsNot Nothing
							If flag7 Then
								Me.POSForm.FillCategory()
							End If
							Dim flag8 As Boolean = Me.POSForm1 IsNot Nothing
							If flag8 Then
								Me.POSForm1.FillCategory()
							End If
							MyBase.Dispose()
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub
	End Class
End Namespace
