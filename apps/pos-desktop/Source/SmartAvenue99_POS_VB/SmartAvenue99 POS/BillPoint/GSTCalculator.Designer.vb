Namespace BillPoint
	' Token: 0x020004EE RID: 1262
		Public Partial Class GSTCalculator
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06010347 RID: 66375 RVA: 0x009A66F8 File Offset: 0x009A48F8
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

		' Token: 0x06010348 RID: 66376 RVA: 0x009A6748 File Offset: 0x009A4948
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.GSTCalculator))
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label85 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.Label84 = New Global.System.Windows.Forms.Label()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.TextBox10 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox9 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox8 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox7 = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.TextBox6 = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.TextBox5 = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.TextBox4 = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Panel2.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel2.BackColor = Global.System.Drawing.Color.Snow
			Me.Panel2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel2.Controls.Add(Me.Label14)
			Me.Panel2.Controls.Add(Me.Label13)
			Me.Panel2.Controls.Add(Me.Label2)
			Me.Panel2.Controls.Add(Me.Label85)
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Controls.Add(Me.Button3)
			Me.Panel2.Controls.Add(Me.Label84)
			Me.Panel2.Controls.Add(Me.Label12)
			Me.Panel2.Controls.Add(Me.Label11)
			Me.Panel2.Controls.Add(Me.Label10)
			Me.Panel2.Controls.Add(Me.Label9)
			Me.Panel2.Controls.Add(Me.TextBox10)
			Me.Panel2.Controls.Add(Me.TextBox9)
			Me.Panel2.Controls.Add(Me.TextBox8)
			Me.Panel2.Controls.Add(Me.TextBox7)
			Me.Panel2.Controls.Add(Me.Label8)
			Me.Panel2.Controls.Add(Me.Label7)
			Me.Panel2.Controls.Add(Me.TextBox6)
			Me.Panel2.Controls.Add(Me.Label6)
			Me.Panel2.Controls.Add(Me.TextBox5)
			Me.Panel2.Controls.Add(Me.Label5)
			Me.Panel2.Controls.Add(Me.TextBox4)
			Me.Panel2.Controls.Add(Me.Label4)
			Me.Panel2.Controls.Add(Me.Button1)
			Me.Panel2.Controls.Add(Me.TextBox3)
			Me.Panel2.Controls.Add(Me.TextBox2)
			Me.Panel2.Controls.Add(Me.TextBox1)
			Me.Panel2.Controls.Add(Me.Label3)
			Me.Panel2.Location = New Global.System.Drawing.Point(11, 12)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(369, 224)
			Me.Panel2.TabIndex = 83
			Me.Label14.AutoSize = True
			Me.Label14.Location = New Global.System.Drawing.Point(274, 26)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(57, 13)
			Me.Label14.TabIndex = 46
			Me.Label14.Text = "(Excluded)"
			Me.Label13.AutoSize = True
			Me.Label13.Location = New Global.System.Drawing.Point(164, 26)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(54, 13)
			Me.Label13.TabIndex = 45
			Me.Label13.Text = "(Included)"
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.Red
			Me.Label2.Location = New Global.System.Drawing.Point(6, 93)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(41, 14)
			Me.Label2.TabIndex = 44
			Me.Label2.Text = "GST %"
			Me.Label85.AutoSize = True
			Me.Label85.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label85.ForeColor = Global.System.Drawing.Color.Red
			Me.Label85.Location = New Global.System.Drawing.Point(6, 77)
			Me.Label85.Name = "Label85"
			Me.Label85.Size = New Global.System.Drawing.Size(95, 14)
			Me.Label85.TabIndex = 43
			Me.Label85.Text = "ENTER HERE THE "
			Me.Label1.AutoSize = True
			Me.Label1.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.Red
			Me.Label1.Location = New Global.System.Drawing.Point(6, 42)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(54, 14)
			Me.Label1.TabIndex = 44
			Me.Label1.Text = "AMOUNT"
			Me.Button3.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button3.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button3.ForeColor = Global.System.Drawing.Color.White
			Me.Button3.Location = New Global.System.Drawing.Point(7, 193)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(75, 24)
			Me.Button3.TabIndex = 4
			Me.Button3.Text = "Reset"
			Me.Button3.UseVisualStyleBackColor = False
			Me.Label84.AutoSize = True
			Me.Label84.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label84.ForeColor = Global.System.Drawing.Color.Red
			Me.Label84.Location = New Global.System.Drawing.Point(5, 27)
			Me.Label84.Name = "Label84"
			Me.Label84.Size = New Global.System.Drawing.Size(92, 14)
			Me.Label84.TabIndex = 43
			Me.Label84.Text = "ENTER HERE THE"
			Me.Label12.AutoSize = True
			Me.Label12.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Underline, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label12.Location = New Global.System.Drawing.Point(108, 3)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(161, 18)
			Me.Label12.TabIndex = 22
			Me.Label12.Text = "GST CALCULATOR"
			Me.Label11.AutoSize = True
			Me.Label11.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label11.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label11.Location = New Global.System.Drawing.Point(246, 179)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(37, 14)
			Me.Label11.TabIndex = 21
			Me.Label11.Text = "CGST"
			Me.Label10.AutoSize = True
			Me.Label10.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label10.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label10.Location = New Global.System.Drawing.Point(246, 133)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(36, 14)
			Me.Label10.TabIndex = 20
			Me.Label10.Text = "SGST"
			Me.Label9.AutoSize = True
			Me.Label9.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label9.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label9.Location = New Global.System.Drawing.Point(246, 87)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(32, 14)
			Me.Label9.TabIndex = 19
			Me.Label9.Text = "IGST"
			Me.TextBox10.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox10.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox10.Location = New Global.System.Drawing.Point(249, 196)
			Me.TextBox10.Name = "TextBox10"
			Me.TextBox10.[ReadOnly] = True
			Me.TextBox10.Size = New Global.System.Drawing.Size(112, 20)
			Me.TextBox10.TabIndex = 18
			Me.TextBox10.TabStop = False
			Me.TextBox10.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox9.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox9.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox9.Location = New Global.System.Drawing.Point(249, 151)
			Me.TextBox9.Name = "TextBox9"
			Me.TextBox9.[ReadOnly] = True
			Me.TextBox9.Size = New Global.System.Drawing.Size(112, 20)
			Me.TextBox9.TabIndex = 17
			Me.TextBox9.TabStop = False
			Me.TextBox9.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox8.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox8.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox8.Location = New Global.System.Drawing.Point(249, 104)
			Me.TextBox8.Name = "TextBox8"
			Me.TextBox8.[ReadOnly] = True
			Me.TextBox8.Size = New Global.System.Drawing.Size(112, 20)
			Me.TextBox8.TabIndex = 16
			Me.TextBox8.TabStop = False
			Me.TextBox8.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox7.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox7.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox7.Location = New Global.System.Drawing.Point(249, 56)
			Me.TextBox7.Name = "TextBox7"
			Me.TextBox7.[ReadOnly] = True
			Me.TextBox7.Size = New Global.System.Drawing.Size(112, 20)
			Me.TextBox7.TabIndex = 15
			Me.TextBox7.TabStop = False
			Me.TextBox7.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label8.AutoSize = True
			Me.Label8.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label8.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label8.Location = New Global.System.Drawing.Point(246, 39)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(88, 14)
			Me.Label8.TabIndex = 14
			Me.Label8.Text = "AMOUNT + GST"
			Me.Label7.AutoSize = True
			Me.Label7.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label7.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label7.Location = New Global.System.Drawing.Point(132, 182)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(37, 14)
			Me.Label7.TabIndex = 13
			Me.Label7.Text = "CGST"
			Me.TextBox6.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox6.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox6.Location = New Global.System.Drawing.Point(135, 196)
			Me.TextBox6.Name = "TextBox6"
			Me.TextBox6.[ReadOnly] = True
			Me.TextBox6.Size = New Global.System.Drawing.Size(108, 20)
			Me.TextBox6.TabIndex = 12
			Me.TextBox6.TabStop = False
			Me.TextBox6.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label6.AutoSize = True
			Me.Label6.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label6.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label6.Location = New Global.System.Drawing.Point(132, 134)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(36, 14)
			Me.Label6.TabIndex = 11
			Me.Label6.Text = "SGST"
			Me.TextBox5.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox5.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox5.Location = New Global.System.Drawing.Point(135, 151)
			Me.TextBox5.Name = "TextBox5"
			Me.TextBox5.[ReadOnly] = True
			Me.TextBox5.Size = New Global.System.Drawing.Size(108, 20)
			Me.TextBox5.TabIndex = 10
			Me.TextBox5.TabStop = False
			Me.TextBox5.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label5.AutoSize = True
			Me.Label5.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label5.Location = New Global.System.Drawing.Point(132, 87)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(32, 14)
			Me.Label5.TabIndex = 9
			Me.Label5.Text = "IGST"
			Me.TextBox4.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox4.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox4.Location = New Global.System.Drawing.Point(135, 104)
			Me.TextBox4.Name = "TextBox4"
			Me.TextBox4.[ReadOnly] = True
			Me.TextBox4.Size = New Global.System.Drawing.Size(108, 20)
			Me.TextBox4.TabIndex = 8
			Me.TextBox4.TabStop = False
			Me.TextBox4.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label4.Location = New Global.System.Drawing.Point(132, 40)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(86, 14)
			Me.Label4.TabIndex = 7
			Me.Label4.Text = "AMOUNT - GST"
			Me.Button1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.Location = New Global.System.Drawing.Point(7, 148)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(75, 24)
			Me.Button1.TabIndex = 3
			Me.Button1.Text = "Calculate"
			Me.Button1.UseVisualStyleBackColor = False
			Me.TextBox3.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox3.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox3.Location = New Global.System.Drawing.Point(135, 56)
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.[ReadOnly] = True
			Me.TextBox3.Size = New Global.System.Drawing.Size(108, 20)
			Me.TextBox3.TabIndex = 5
			Me.TextBox3.TabStop = False
			Me.TextBox3.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox2.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox2.Location = New Global.System.Drawing.Point(8, 109)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(103, 20)
			Me.TextBox2.TabIndex = 2
			Me.TextBox2.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox1.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(8, 56)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(103, 20)
			Me.TextBox1.TabIndex = 1
			Me.TextBox1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(199, 40)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(0, 13)
			Me.Label3.TabIndex = 2
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(392, 249)
			MyBase.Controls.Add(Me.Panel2)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.MaximizeBox = False
			MyBase.Name = "GSTCalculator"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "GST Calculator"
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x0400637A RID: 25466
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
