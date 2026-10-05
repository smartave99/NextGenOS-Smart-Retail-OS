Namespace BillPoint
	' Token: 0x020000D3 RID: 211
		Public Partial Class frmCouponApply
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060025C6 RID: 9670 RVA: 0x0017EF68 File Offset: 0x0017D168
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

		' Token: 0x060025C7 RID: 9671 RVA: 0x0017EFB8 File Offset: 0x0017D1B8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			MyBase.SuspendLayout()
			Me.TextBox1.CharacterCasing = Global.System.Windows.Forms.CharacterCasing.Upper
			Me.TextBox1.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 18F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.ForeColor = Global.System.Drawing.Color.Blue
			Me.TextBox1.Location = New Global.System.Drawing.Point(55, 60)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(223, 35)
			Me.TextBox1.TabIndex = 0
			Me.TextBox1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label1.AutoSize = True
			Me.Label1.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(52, 30)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(227, 22)
			Me.Label1.TabIndex = 1
			Me.Label1.Text = "ENTER COUPON CODE"
			Me.Button1.BackColor = Global.System.Drawing.Color.GhostWhite
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.FromArgb(64, 0, 0)
			Me.Button1.Location = New Global.System.Drawing.Point(114, 101)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(101, 41)
			Me.Button1.TabIndex = 2
			Me.Button1.Text = "Search"
			Me.Button1.UseVisualStyleBackColor = False
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.White
			Me.Label2.Location = New Global.System.Drawing.Point(12, 159)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(63, 18)
			Me.Label2.TabIndex = 3
			Me.Label2.Text = "Name :"
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.ForeColor = Global.System.Drawing.Color.White
			Me.Label3.Location = New Global.System.Drawing.Point(12, 191)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(81, 18)
			Me.Label3.TabIndex = 4
			Me.Label3.Text = "Contact :"
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.ForeColor = Global.System.Drawing.Color.White
			Me.Label4.Location = New Global.System.Drawing.Point(12, 223)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(79, 18)
			Me.Label4.TabIndex = 5
			Me.Label4.Text = "Amount :"
			Me.Label5.AutoSize = True
			Me.Label5.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.ForeColor = Global.System.Drawing.Color.White
			Me.Label5.Location = New Global.System.Drawing.Point(12, 255)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(69, 18)
			Me.Label5.TabIndex = 6
			Me.Label5.Text = "Status :"
			Me.Label6.AutoSize = True
			Me.Label6.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label6.ForeColor = Global.System.Drawing.Color.White
			Me.Label6.Location = New Global.System.Drawing.Point(12, 287)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(102, 18)
			Me.Label6.TabIndex = 7
			Me.Label6.Text = "Issue Date :"
			Me.Button2.BackColor = Global.System.Drawing.Color.GhostWhite
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.FromArgb(64, 0, 0)
			Me.Button2.Location = New Global.System.Drawing.Point(114, 317)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(101, 41)
			Me.Button2.TabIndex = 8
			Me.Button2.Text = "USE IT"
			Me.Button2.UseVisualStyleBackColor = False
			Me.Label7.AutoSize = True
			Me.Label7.ForeColor = Global.System.Drawing.Color.Gray
			Me.Label7.Location = New Global.System.Drawing.Point(251, 4)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(78, 13)
			Me.Label7.TabIndex = 9
			Me.Label7.Text = "ESC to CLOSE"
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(12, 317)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(28, 13)
			Me.Label8.TabIndex = 10
			Me.Label8.Text = "0.00"
			Me.Label8.Visible = False
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(4, 5)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(39, 13)
			Me.Label9.TabIndex = 11
			Me.Label9.Text = "Label9"
			Me.Label9.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			MyBase.ClientSize = New Global.System.Drawing.Size(333, 370)
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
			Me.DoubleBuffered = True
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.None
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmCouponApply"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04000F5F RID: 3935
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
