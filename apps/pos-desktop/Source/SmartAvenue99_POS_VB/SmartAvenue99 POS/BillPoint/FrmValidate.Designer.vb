Namespace BillPoint
	' Token: 0x02000212 RID: 530
		Public Partial Class FrmValidate
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600994B RID: 39243 RVA: 0x006E091C File Offset: 0x006DEB1C
		<Global.System.Diagnostics.DebuggerNonUserCode()>
		Protected Overrides Sub Dispose(disposing As Boolean)
			Try
				Dim flag As Boolean = disposing AndAlso Me.components IsNot Nothing
				If flag Then
					Me.components.Dispose()
				End If
			Finally
				MyBase.Dispose(disposing)
			End Try
		End Sub

		' Token: 0x0600994C RID: 39244 RVA: 0x006E096C File Offset: 0x006DEB6C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.FrmValidate))
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.TBoxGSTIN = New Global.System.Windows.Forms.TextBox()
			Me.BtnValidate = New Global.CButtonLib.CButton()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.ValCanDate = New Global.System.Windows.Forms.Label()
			Me.ValRegDate = New Global.System.Windows.Forms.Label()
			Me.ValCoB = New Global.System.Windows.Forms.Label()
			Me.ValType = New Global.System.Windows.Forms.Label()
			Me.ValState = New Global.System.Windows.Forms.Label()
			Me.ValLegalName = New Global.System.Windows.Forms.Label()
			Me.ValTradeName = New Global.System.Windows.Forms.Label()
			Me.Label24 = New Global.System.Windows.Forms.Label()
			Me.ValPPoB = New Global.System.Windows.Forms.TextBox()
			Me.BtnChkOnGSTINPortal = New Global.CButtonLib.CButton()
			Me.Button1 = New Global.CButtonLib.CButton()
			Me.Button2 = New Global.CButtonLib.CButton()
			Me.txtNat = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			MyBase.SuspendLayout()
			Me.Label1.AutoSize = True
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.FromArgb(64, 0, 64)
			Me.Label1.Location = New Global.System.Drawing.Point(30, 28)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(91, 15)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Specify GSTIN :"
			Me.TBoxGSTIN.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TBoxGSTIN.Location = New Global.System.Drawing.Point(127, 28)
			Me.TBoxGSTIN.Name = "TBoxGSTIN"
			Me.TBoxGSTIN.Size = New Global.System.Drawing.Size(244, 21)
			Me.TBoxGSTIN.TabIndex = 0
			Me.BtnValidate.BackColor = Global.System.Drawing.Color.Transparent
			Me.BtnValidate.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BtnValidate.Corners.All = 5
			Me.BtnValidate.Corners.LowerLeft = 5
			Me.BtnValidate.Corners.LowerRight = 5
			Me.BtnValidate.Corners.UpperLeft = 5
			Me.BtnValidate.Corners.UpperRight = 5
			Me.BtnValidate.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BtnValidate.DesignerSelected = False
			Me.BtnValidate.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BtnValidate.ImageIndex = 0
			Me.BtnValidate.ImageSize = New Global.System.Drawing.Size(22, 22)
			Me.BtnValidate.Location = New Global.System.Drawing.Point(427, 28)
			Me.BtnValidate.Name = "BtnValidate"
			Me.BtnValidate.Size = New Global.System.Drawing.Size(75, 23)
			Me.BtnValidate.TabIndex = 2
			Me.BtnValidate.Text = "Validate"
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.ForeColor = Global.System.Drawing.Color.Maroon
			Me.Label3.Location = New Global.System.Drawing.Point(30, 74)
			Me.Label3.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(82, 15)
			Me.Label3.TabIndex = 4
			Me.Label3.Text = "Trade Name :"
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.ForeColor = Global.System.Drawing.Color.Maroon
			Me.Label4.Location = New Global.System.Drawing.Point(30, 100)
			Me.Label4.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(81, 15)
			Me.Label4.TabIndex = 5
			Me.Label4.Text = "Legal Name :"
			Me.Label5.AutoSize = True
			Me.Label5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.ForeColor = Global.System.Drawing.Color.Maroon
			Me.Label5.Location = New Global.System.Drawing.Point(30, 126)
			Me.Label5.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(41, 15)
			Me.Label5.TabIndex = 6
			Me.Label5.Text = "State :"
			Me.Label6.AutoSize = True
			Me.Label6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label6.ForeColor = Global.System.Drawing.Color.Maroon
			Me.Label6.Location = New Global.System.Drawing.Point(30, 152)
			Me.Label6.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(71, 15)
			Me.Label6.TabIndex = 7
			Me.Label6.Text = "Entity Type :"
			Me.Label7.AutoSize = True
			Me.Label7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label7.ForeColor = Global.System.Drawing.Color.Maroon
			Me.Label7.Location = New Global.System.Drawing.Point(30, 178)
			Me.Label7.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(92, 15)
			Me.Label7.TabIndex = 8
			Me.Label7.Text = "Business Type :"
			Me.Label8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label8.ForeColor = Global.System.Drawing.Color.Maroon
			Me.Label8.Location = New Global.System.Drawing.Point(30, 204)
			Me.Label8.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(110, 38)
			Me.Label8.TabIndex = 9
			Me.Label8.Text = "Registration Date (MM/DD/YYYY) :"
			Me.Label9.AutoSize = True
			Me.Label9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label9.ForeColor = Global.System.Drawing.Color.Maroon
			Me.Label9.Location = New Global.System.Drawing.Point(30, 253)
			Me.Label9.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(37, 15)
			Me.Label9.TabIndex = 10
			Me.Label9.Text = "PAN :"
			Me.Label12.AutoSize = True
			Me.Label12.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label12.ForeColor = Global.System.Drawing.Color.Maroon
			Me.Label12.Location = New Global.System.Drawing.Point(30, 279)
			Me.Label12.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(110, 15)
			Me.Label12.TabIndex = 13
			Me.Label12.Text = "Place of Business :"
			Me.ValCanDate.AutoSize = True
			Me.ValCanDate.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ValCanDate.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ValCanDate.ForeColor = Global.System.Drawing.Color.Black
			Me.ValCanDate.Location = New Global.System.Drawing.Point(190, 253)
			Me.ValCanDate.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.ValCanDate.Name = "ValCanDate"
			Me.ValCanDate.Size = New Global.System.Drawing.Size(24, 13)
			Me.ValCanDate.TabIndex = 21
			Me.ValCanDate.Text = "NA"
			Me.ValRegDate.AutoSize = True
			Me.ValRegDate.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ValRegDate.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ValRegDate.ForeColor = Global.System.Drawing.Color.Black
			Me.ValRegDate.Location = New Global.System.Drawing.Point(190, 204)
			Me.ValRegDate.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.ValRegDate.Name = "ValRegDate"
			Me.ValRegDate.Size = New Global.System.Drawing.Size(24, 13)
			Me.ValRegDate.TabIndex = 20
			Me.ValRegDate.Text = "NA"
			Me.ValCoB.AutoSize = True
			Me.ValCoB.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ValCoB.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ValCoB.ForeColor = Global.System.Drawing.Color.Black
			Me.ValCoB.Location = New Global.System.Drawing.Point(190, 178)
			Me.ValCoB.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.ValCoB.Name = "ValCoB"
			Me.ValCoB.Size = New Global.System.Drawing.Size(24, 13)
			Me.ValCoB.TabIndex = 19
			Me.ValCoB.Text = "NA"
			Me.ValType.AutoSize = True
			Me.ValType.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ValType.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ValType.ForeColor = Global.System.Drawing.Color.Black
			Me.ValType.Location = New Global.System.Drawing.Point(190, 152)
			Me.ValType.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.ValType.Name = "ValType"
			Me.ValType.Size = New Global.System.Drawing.Size(24, 13)
			Me.ValType.TabIndex = 18
			Me.ValType.Text = "NA"
			Me.ValState.AutoSize = True
			Me.ValState.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ValState.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ValState.ForeColor = Global.System.Drawing.Color.Black
			Me.ValState.Location = New Global.System.Drawing.Point(190, 126)
			Me.ValState.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.ValState.Name = "ValState"
			Me.ValState.Size = New Global.System.Drawing.Size(24, 13)
			Me.ValState.TabIndex = 17
			Me.ValState.Text = "NA"
			Me.ValLegalName.AutoSize = True
			Me.ValLegalName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ValLegalName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ValLegalName.ForeColor = Global.System.Drawing.Color.Black
			Me.ValLegalName.Location = New Global.System.Drawing.Point(190, 100)
			Me.ValLegalName.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.ValLegalName.Name = "ValLegalName"
			Me.ValLegalName.Size = New Global.System.Drawing.Size(24, 13)
			Me.ValLegalName.TabIndex = 16
			Me.ValLegalName.Text = "NA"
			Me.ValTradeName.AutoSize = True
			Me.ValTradeName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ValTradeName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ValTradeName.ForeColor = Global.System.Drawing.Color.Black
			Me.ValTradeName.Location = New Global.System.Drawing.Point(190, 76)
			Me.ValTradeName.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.ValTradeName.Name = "ValTradeName"
			Me.ValTradeName.Size = New Global.System.Drawing.Size(24, 13)
			Me.ValTradeName.TabIndex = 15
			Me.ValTradeName.Text = "NA"
			Me.Label24.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.Label24.Location = New Global.System.Drawing.Point(33, 60)
			Me.Label24.Name = "Label24"
			Me.Label24.Size = New Global.System.Drawing.Size(469, 3)
			Me.Label24.TabIndex = 26
			Me.ValPPoB.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ValPPoB.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.ValPPoB.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ValPPoB.ForeColor = Global.System.Drawing.Color.Black
			Me.ValPPoB.Location = New Global.System.Drawing.Point(193, 283)
			Me.ValPPoB.Multiline = True
			Me.ValPPoB.Name = "ValPPoB"
			Me.ValPPoB.[ReadOnly] = True
			Me.ValPPoB.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.ValPPoB.Size = New Global.System.Drawing.Size(325, 47)
			Me.ValPPoB.TabIndex = 27
			Me.ValPPoB.TabStop = False
			Me.ValPPoB.Text = "NA"
			Me.BtnChkOnGSTINPortal.BackColor = Global.System.Drawing.Color.Transparent
			Me.BtnChkOnGSTINPortal.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BtnChkOnGSTINPortal.Corners.All = 5
			Me.BtnChkOnGSTINPortal.Corners.LowerLeft = 5
			Me.BtnChkOnGSTINPortal.Corners.LowerRight = 5
			Me.BtnChkOnGSTINPortal.Corners.UpperLeft = 5
			Me.BtnChkOnGSTINPortal.Corners.UpperRight = 5
			Me.BtnChkOnGSTINPortal.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BtnChkOnGSTINPortal.DesignerSelected = False
			Me.BtnChkOnGSTINPortal.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BtnChkOnGSTINPortal.ImageIndex = 0
			Me.BtnChkOnGSTINPortal.ImageSize = New Global.System.Drawing.Size(22, 22)
			Me.BtnChkOnGSTINPortal.Location = New Global.System.Drawing.Point(338, 401)
			Me.BtnChkOnGSTINPortal.Name = "BtnChkOnGSTINPortal"
			Me.BtnChkOnGSTINPortal.Size = New Global.System.Drawing.Size(164, 30)
			Me.BtnChkOnGSTINPortal.TabIndex = 4
			Me.BtnChkOnGSTINPortal.Text = "Check on GSTIN Portal"
			Me.Button1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Corners.All = 5
			Me.Button1.Corners.LowerLeft = 5
			Me.Button1.Corners.LowerRight = 5
			Me.Button1.Corners.UpperLeft = 5
			Me.Button1.Corners.UpperRight = 5
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.DesignerSelected = True
			Me.Button1.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ImageIndex = 0
			Me.Button1.ImageSize = New Global.System.Drawing.Size(22, 22)
			Me.Button1.Location = New Global.System.Drawing.Point(33, 388)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(88, 41)
			Me.Button1.TabIndex = 3
			Me.Button1.Text = "Copy Forward"
			Me.Button2.BackColor = Global.System.Drawing.Color.Transparent
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Corners.All = 5
			Me.Button2.Corners.LowerLeft = 5
			Me.Button2.Corners.LowerRight = 5
			Me.Button2.Corners.UpperLeft = 5
			Me.Button2.Corners.UpperRight = 5
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.DesignerSelected = False
			Me.Button2.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ImageIndex = 0
			Me.Button2.ImageSize = New Global.System.Drawing.Size(22, 22)
			Me.Button2.Location = New Global.System.Drawing.Point(376, 28)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(46, 23)
			Me.Button2.TabIndex = 1
			Me.Button2.TabStop = False
			Me.Button2.Text = "Paste"
			Me.txtNat.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtNat.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.txtNat.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold)
			Me.txtNat.Location = New Global.System.Drawing.Point(193, 341)
			Me.txtNat.Multiline = True
			Me.txtNat.Name = "txtNat"
			Me.txtNat.[ReadOnly] = True
			Me.txtNat.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtNat.Size = New Global.System.Drawing.Size(325, 38)
			Me.txtNat.TabIndex = 28
			Me.txtNat.Text = "NA"
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.Maroon
			Me.Label2.Location = New Global.System.Drawing.Point(30, 339)
			Me.Label2.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(116, 15)
			Me.Label2.TabIndex = 29
			Me.Label2.Text = "Nature of Business :"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.LavenderBlush
			MyBase.ClientSize = New Global.System.Drawing.Size(549, 441)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.txtNat)
			MyBase.Controls.Add(Me.Button2)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.BtnChkOnGSTINPortal)
			MyBase.Controls.Add(Me.ValPPoB)
			MyBase.Controls.Add(Me.Label24)
			MyBase.Controls.Add(Me.ValCanDate)
			MyBase.Controls.Add(Me.ValRegDate)
			MyBase.Controls.Add(Me.ValCoB)
			MyBase.Controls.Add(Me.ValType)
			MyBase.Controls.Add(Me.ValState)
			MyBase.Controls.Add(Me.ValLegalName)
			MyBase.Controls.Add(Me.ValTradeName)
			MyBase.Controls.Add(Me.Label12)
			MyBase.Controls.Add(Me.Label9)
			MyBase.Controls.Add(Me.Label8)
			MyBase.Controls.Add(Me.Label7)
			MyBase.Controls.Add(Me.Label6)
			MyBase.Controls.Add(Me.Label5)
			MyBase.Controls.Add(Me.Label4)
			MyBase.Controls.Add(Me.Label3)
			MyBase.Controls.Add(Me.BtnValidate)
			MyBase.Controls.Add(Me.TBoxGSTIN)
			MyBase.Controls.Add(Me.Label1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "FrmValidate"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "GSTIN Validation"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040043CF RID: 17359
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
