Namespace BillPoint
	' Token: 0x02000213 RID: 531
		Public Partial Class FrmValidate1
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600998F RID: 39311 RVA: 0x006E2C18 File Offset: 0x006E0E18
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

		' Token: 0x06009990 RID: 39312 RVA: 0x006E2C68 File Offset: 0x006E0E68
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.TBoxGSTIN = New Global.System.Windows.Forms.TextBox()
			Me.BtnValidate = New Global.System.Windows.Forms.Button()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.ValFilFreq = New Global.System.Windows.Forms.Label()
			Me.ValLstValOn = New Global.System.Windows.Forms.Label()
			Me.ValCanDate = New Global.System.Windows.Forms.Label()
			Me.ValRegDate = New Global.System.Windows.Forms.Label()
			Me.ValCoB = New Global.System.Windows.Forms.Label()
			Me.ValType = New Global.System.Windows.Forms.Label()
			Me.ValState = New Global.System.Windows.Forms.Label()
			Me.ValLegalName = New Global.System.Windows.Forms.Label()
			Me.ValTradeName = New Global.System.Windows.Forms.Label()
			Me.ValStatus = New Global.System.Windows.Forms.Label()
			Me.BtnQuit = New Global.System.Windows.Forms.Button()
			Me.Label24 = New Global.System.Windows.Forms.Label()
			Me.ValPPoB = New Global.System.Windows.Forms.TextBox()
			Me.BtnChkOnGSTINPortal = New Global.System.Windows.Forms.Button()
			MyBase.SuspendLayout()
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(30, 31)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(78, 13)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Specify GSTIN"
			Me.TBoxGSTIN.Location = New Global.System.Drawing.Point(127, 28)
			Me.TBoxGSTIN.Name = "TBoxGSTIN"
			Me.TBoxGSTIN.Size = New Global.System.Drawing.Size(240, 20)
			Me.TBoxGSTIN.TabIndex = 1
			Me.BtnValidate.Location = New Global.System.Drawing.Point(373, 26)
			Me.BtnValidate.Name = "BtnValidate"
			Me.BtnValidate.Size = New Global.System.Drawing.Size(75, 23)
			Me.BtnValidate.TabIndex = 2
			Me.BtnValidate.Text = "Validate"
			Me.BtnValidate.UseVisualStyleBackColor = True
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(30, 75)
			Me.Label2.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(37, 13)
			Me.Label2.TabIndex = 3
			Me.Label2.Text = "Status"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(30, 98)
			Me.Label3.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(66, 13)
			Me.Label3.TabIndex = 4
			Me.Label3.Text = "Trade Name"
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(30, 121)
			Me.Label4.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(64, 13)
			Me.Label4.TabIndex = 5
			Me.Label4.Text = "Legal Name"
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(30, 144)
			Me.Label5.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(32, 13)
			Me.Label5.TabIndex = 6
			Me.Label5.Text = "State"
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(30, 167)
			Me.Label6.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(31, 13)
			Me.Label6.TabIndex = 7
			Me.Label6.Text = "Type"
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(30, 190)
			Me.Label7.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(119, 13)
			Me.Label7.TabIndex = 8
			Me.Label7.Text = "Constitution of Business"
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(30, 213)
			Me.Label8.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(89, 13)
			Me.Label8.TabIndex = 9
			Me.Label8.Text = "Registration Date"
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(30, 236)
			Me.Label9.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(91, 13)
			Me.Label9.TabIndex = 10
			Me.Label9.Text = "Cancellation Date"
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(30, 259)
			Me.Label10.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(91, 13)
			Me.Label10.TabIndex = 11
			Me.Label10.Text = "Last Validated On"
			Me.Label11.AutoSize = True
			Me.Label11.Location = New Global.System.Drawing.Point(30, 282)
			Me.Label11.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(58, 13)
			Me.Label11.TabIndex = 12
			Me.Label11.Text = "Filing Freq."
			Me.Label12.AutoSize = True
			Me.Label12.Location = New Global.System.Drawing.Point(30, 305)
			Me.Label12.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(134, 13)
			Me.Label12.TabIndex = 13
			Me.Label12.Text = "Principal Place of Business"
			Me.ValFilFreq.AutoSize = True
			Me.ValFilFreq.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ValFilFreq.Location = New Global.System.Drawing.Point(174, 282)
			Me.ValFilFreq.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.ValFilFreq.Name = "ValFilFreq"
			Me.ValFilFreq.Size = New Global.System.Drawing.Size(24, 13)
			Me.ValFilFreq.TabIndex = 23
			Me.ValFilFreq.Text = "NA"
			Me.ValLstValOn.AutoSize = True
			Me.ValLstValOn.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ValLstValOn.Location = New Global.System.Drawing.Point(174, 259)
			Me.ValLstValOn.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.ValLstValOn.Name = "ValLstValOn"
			Me.ValLstValOn.Size = New Global.System.Drawing.Size(24, 13)
			Me.ValLstValOn.TabIndex = 22
			Me.ValLstValOn.Text = "NA"
			Me.ValCanDate.AutoSize = True
			Me.ValCanDate.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ValCanDate.Location = New Global.System.Drawing.Point(174, 236)
			Me.ValCanDate.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.ValCanDate.Name = "ValCanDate"
			Me.ValCanDate.Size = New Global.System.Drawing.Size(24, 13)
			Me.ValCanDate.TabIndex = 21
			Me.ValCanDate.Text = "NA"
			Me.ValRegDate.AutoSize = True
			Me.ValRegDate.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ValRegDate.Location = New Global.System.Drawing.Point(174, 213)
			Me.ValRegDate.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.ValRegDate.Name = "ValRegDate"
			Me.ValRegDate.Size = New Global.System.Drawing.Size(24, 13)
			Me.ValRegDate.TabIndex = 20
			Me.ValRegDate.Text = "NA"
			Me.ValCoB.AutoSize = True
			Me.ValCoB.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ValCoB.Location = New Global.System.Drawing.Point(174, 190)
			Me.ValCoB.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.ValCoB.Name = "ValCoB"
			Me.ValCoB.Size = New Global.System.Drawing.Size(24, 13)
			Me.ValCoB.TabIndex = 19
			Me.ValCoB.Text = "NA"
			Me.ValType.AutoSize = True
			Me.ValType.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ValType.Location = New Global.System.Drawing.Point(174, 167)
			Me.ValType.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.ValType.Name = "ValType"
			Me.ValType.Size = New Global.System.Drawing.Size(24, 13)
			Me.ValType.TabIndex = 18
			Me.ValType.Text = "NA"
			Me.ValState.AutoSize = True
			Me.ValState.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ValState.Location = New Global.System.Drawing.Point(174, 144)
			Me.ValState.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.ValState.Name = "ValState"
			Me.ValState.Size = New Global.System.Drawing.Size(24, 13)
			Me.ValState.TabIndex = 17
			Me.ValState.Text = "NA"
			Me.ValLegalName.AutoSize = True
			Me.ValLegalName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ValLegalName.Location = New Global.System.Drawing.Point(174, 121)
			Me.ValLegalName.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.ValLegalName.Name = "ValLegalName"
			Me.ValLegalName.Size = New Global.System.Drawing.Size(24, 13)
			Me.ValLegalName.TabIndex = 16
			Me.ValLegalName.Text = "NA"
			Me.ValTradeName.AutoSize = True
			Me.ValTradeName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ValTradeName.Location = New Global.System.Drawing.Point(174, 98)
			Me.ValTradeName.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.ValTradeName.Name = "ValTradeName"
			Me.ValTradeName.Size = New Global.System.Drawing.Size(24, 13)
			Me.ValTradeName.TabIndex = 15
			Me.ValTradeName.Text = "NA"
			Me.ValStatus.AutoSize = True
			Me.ValStatus.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ValStatus.Location = New Global.System.Drawing.Point(174, 75)
			Me.ValStatus.Margin = New Global.System.Windows.Forms.Padding(5)
			Me.ValStatus.Name = "ValStatus"
			Me.ValStatus.Size = New Global.System.Drawing.Size(24, 13)
			Me.ValStatus.TabIndex = 14
			Me.ValStatus.Text = "NA"
			Me.BtnQuit.Location = New Global.System.Drawing.Point(377, 399)
			Me.BtnQuit.Name = "BtnQuit"
			Me.BtnQuit.Size = New Global.System.Drawing.Size(100, 30)
			Me.BtnQuit.TabIndex = 25
			Me.BtnQuit.Text = "Quit"
			Me.BtnQuit.UseVisualStyleBackColor = True
			Me.Label24.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.Label24.Location = New Global.System.Drawing.Point(33, 60)
			Me.Label24.Name = "Label24"
			Me.Label24.Size = New Global.System.Drawing.Size(415, 2)
			Me.Label24.TabIndex = 26
			Me.ValPPoB.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.ValPPoB.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ValPPoB.Location = New Global.System.Drawing.Point(177, 303)
			Me.ValPPoB.Multiline = True
			Me.ValPPoB.Name = "ValPPoB"
			Me.ValPPoB.[ReadOnly] = True
			Me.ValPPoB.Size = New Global.System.Drawing.Size(300, 90)
			Me.ValPPoB.TabIndex = 27
			Me.ValPPoB.Text = "NA"
			Me.BtnChkOnGSTINPortal.Location = New Global.System.Drawing.Point(177, 399)
			Me.BtnChkOnGSTINPortal.Name = "BtnChkOnGSTINPortal"
			Me.BtnChkOnGSTINPortal.Size = New Global.System.Drawing.Size(194, 30)
			Me.BtnChkOnGSTINPortal.TabIndex = 28
			Me.BtnChkOnGSTINPortal.Text = "Check on GSTIN Portal"
			Me.BtnChkOnGSTINPortal.UseVisualStyleBackColor = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(489, 441)
			MyBase.Controls.Add(Me.BtnChkOnGSTINPortal)
			MyBase.Controls.Add(Me.ValPPoB)
			MyBase.Controls.Add(Me.Label24)
			MyBase.Controls.Add(Me.BtnQuit)
			MyBase.Controls.Add(Me.ValFilFreq)
			MyBase.Controls.Add(Me.ValLstValOn)
			MyBase.Controls.Add(Me.ValCanDate)
			MyBase.Controls.Add(Me.ValRegDate)
			MyBase.Controls.Add(Me.ValCoB)
			MyBase.Controls.Add(Me.ValType)
			MyBase.Controls.Add(Me.ValState)
			MyBase.Controls.Add(Me.ValLegalName)
			MyBase.Controls.Add(Me.ValTradeName)
			MyBase.Controls.Add(Me.ValStatus)
			MyBase.Controls.Add(Me.Label12)
			MyBase.Controls.Add(Me.Label11)
			MyBase.Controls.Add(Me.Label10)
			MyBase.Controls.Add(Me.Label9)
			MyBase.Controls.Add(Me.Label8)
			MyBase.Controls.Add(Me.Label7)
			MyBase.Controls.Add(Me.Label6)
			MyBase.Controls.Add(Me.Label5)
			MyBase.Controls.Add(Me.Label4)
			MyBase.Controls.Add(Me.Label3)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.BtnValidate)
			MyBase.Controls.Add(Me.TBoxGSTIN)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Name = "FrmValidate"
			Me.Text = "Validate"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040043EB RID: 17387
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
