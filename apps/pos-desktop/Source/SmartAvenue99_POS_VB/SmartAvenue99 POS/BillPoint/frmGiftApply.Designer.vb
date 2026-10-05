Namespace BillPoint
	' Token: 0x02000115 RID: 277
		Public Partial Class frmGiftApply
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06002F7B RID: 12155 RVA: 0x001D3940 File Offset: 0x001D1B40
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

		' Token: 0x06002F7C RID: 12156 RVA: 0x001D3990 File Offset: 0x001D1B90
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			MyBase.SuspendLayout()
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(4, 9)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(39, 13)
			Me.Label9.TabIndex = 23
			Me.Label9.Text = "Label9"
			Me.Label9.Visible = False
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(12, 321)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(28, 13)
			Me.Label8.TabIndex = 22
			Me.Label8.Text = "0.00"
			Me.Label8.Visible = False
			Me.Label7.AutoSize = True
			Me.Label7.ForeColor = Global.System.Drawing.Color.Gray
			Me.Label7.Location = New Global.System.Drawing.Point(251, 8)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(78, 13)
			Me.Label7.TabIndex = 21
			Me.Label7.Text = "ESC to CLOSE"
			Me.Button2.BackColor = Global.System.Drawing.Color.GhostWhite
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.FromArgb(64, 0, 0)
			Me.Button2.Location = New Global.System.Drawing.Point(114, 321)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(101, 41)
			Me.Button2.TabIndex = 20
			Me.Button2.Text = "USE IT"
			Me.Button2.UseVisualStyleBackColor = False
			Me.Label6.AutoSize = True
			Me.Label6.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label6.ForeColor = Global.System.Drawing.Color.White
			Me.Label6.Location = New Global.System.Drawing.Point(2, 263)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(75, 18)
			Me.Label6.TabIndex = 19
			Me.Label6.Text = "Validity :"
			Me.Label5.AutoSize = True
			Me.Label5.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.ForeColor = Global.System.Drawing.Color.White
			Me.Label5.Location = New Global.System.Drawing.Point(2, 238)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(69, 18)
			Me.Label5.TabIndex = 18
			Me.Label5.Text = "Status :"
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.ForeColor = Global.System.Drawing.Color.White
			Me.Label4.Location = New Global.System.Drawing.Point(2, 213)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(79, 18)
			Me.Label4.TabIndex = 17
			Me.Label4.Text = "Amount :"
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.ForeColor = Global.System.Drawing.Color.White
			Me.Label3.Location = New Global.System.Drawing.Point(2, 188)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(81, 18)
			Me.Label3.TabIndex = 16
			Me.Label3.Text = "Contact :"
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.White
			Me.Label2.Location = New Global.System.Drawing.Point(2, 163)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(63, 18)
			Me.Label2.TabIndex = 15
			Me.Label2.Text = "Name :"
			Me.Button1.BackColor = Global.System.Drawing.Color.GhostWhite
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.FromArgb(64, 0, 0)
			Me.Button1.Location = New Global.System.Drawing.Point(114, 105)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(101, 41)
			Me.Button1.TabIndex = 14
			Me.Button1.Text = "Search"
			Me.Button1.UseVisualStyleBackColor = False
			Me.Label1.AutoSize = True
			Me.Label1.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(24, 34)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(288, 22)
			Me.Label1.TabIndex = 13
			Me.Label1.Text = "ENTER GIFT VOUCHER CODE"
			Me.TextBox1.CharacterCasing = Global.System.Windows.Forms.CharacterCasing.Upper
			Me.TextBox1.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 18F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.ForeColor = Global.System.Drawing.Color.Blue
			Me.TextBox1.Location = New Global.System.Drawing.Point(55, 64)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(223, 35)
			Me.TextBox1.TabIndex = 12
			Me.TextBox1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label10.AutoSize = True
			Me.Label10.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label10.ForeColor = Global.System.Drawing.Color.White
			Me.Label10.Location = New Global.System.Drawing.Point(2, 288)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(67, 18)
			Me.Label10.TabIndex = 24
			Me.Label10.Text = "Bill No :"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.DodgerBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(333, 370)
			MyBase.Controls.Add(Me.Label10)
			MyBase.Controls.Add(Me.Label9)
			MyBase.Controls.Add(Me.Label8)
			MyBase.Controls.Add(Me.Label7)
			MyBase.Controls.Add(Me.Button2)
			MyBase.Controls.Add(Me.Label6)
			MyBase.Controls.Add(Me.Label5)
			MyBase.Controls.Add(Me.Label4)
			MyBase.Controls.Add(Me.Label3)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.None
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmGiftApply"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04001444 RID: 5188
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
