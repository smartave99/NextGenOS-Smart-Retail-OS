Namespace BillPoint
	' Token: 0x02000210 RID: 528
		Public Partial Class frmUnitButton
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06009907 RID: 39175 RVA: 0x006DDB88 File Offset: 0x006DBD88
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

		' Token: 0x06009908 RID: 39176 RVA: 0x006DDBD8 File Offset: 0x006DBDD8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.lblBarcode = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.txtDefQty = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Panel1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Button3.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Button3.BackgroundImage = Global.BillPoint.My.Resources.Resources.BlueL
			Me.Button3.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 20.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button3.ForeColor = Global.System.Drawing.Color.White
			Me.Button3.Location = New Global.System.Drawing.Point(253, 118)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(219, 161)
			Me.Button3.TabIndex = 3
			Me.Button3.Text = "."
			Me.Button3.UseVisualStyleBackColor = False
			Me.Button2.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Button2.BackgroundImage = Global.BillPoint.My.Resources.Resources.BlueL
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 20.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.Location = New Global.System.Drawing.Point(4, 118)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(219, 161)
			Me.Button2.TabIndex = 2
			Me.Button2.Text = "."
			Me.Button2.UseVisualStyleBackColor = False
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(10, 54)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(39, 13)
			Me.Label1.TabIndex = 52
			Me.Label1.Text = "Label1"
			Me.Label1.Visible = False
			Me.lblBarcode.AutoSize = True
			Me.lblBarcode.Location = New Global.System.Drawing.Point(10, 41)
			Me.lblBarcode.Name = "lblBarcode"
			Me.lblBarcode.Size = New Global.System.Drawing.Size(57, 13)
			Me.lblBarcode.TabIndex = 53
			Me.lblBarcode.Text = "lblBarcode"
			Me.lblBarcode.Visible = False
			Me.Label2.BackColor = Global.System.Drawing.Color.SpringGreen
			Me.Label2.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 21.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.Purple
			Me.Label2.Location = New Global.System.Drawing.Point(4, 85)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(219, 33)
			Me.Label2.TabIndex = 54
			Me.Label2.Text = "Main Unit"
			Me.Label2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label3.BackColor = Global.System.Drawing.Color.SpringGreen
			Me.Label3.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 21.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.ForeColor = Global.System.Drawing.Color.Purple
			Me.Label3.Location = New Global.System.Drawing.Point(253, 86)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(219, 33)
			Me.Label3.TabIndex = 55
			Me.Label3.Text = "Alter Unit"
			Me.Label3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Label6)
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Controls.Add(Me.txtDefQty)
			Me.Panel1.Controls.Add(Me.Label4)
			Me.Panel1.Controls.Add(Me.Button3)
			Me.Panel1.Controls.Add(Me.lblBarcode)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.Label3)
			Me.Panel1.Controls.Add(Me.Button2)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Location = New Global.System.Drawing.Point(11, 12)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(478, 284)
			Me.Panel1.TabIndex = 0
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(397, 50)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(39, 13)
			Me.Label6.TabIndex = 59
			Me.Label6.Text = "Label6"
			Me.Label6.Visible = False
			Me.Label5.AutoSize = True
			Me.Label5.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.Location = New Global.System.Drawing.Point(155, 50)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(45, 18)
			Me.Label5.TabIndex = 58
			Me.Label5.Text = "Qty :"
			Me.txtDefQty.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtDefQty.Location = New Global.System.Drawing.Point(206, 48)
			Me.txtDefQty.Name = "txtDefQty"
			Me.txtDefQty.Size = New Global.System.Drawing.Size(100, 26)
			Me.txtDefQty.TabIndex = 1
			Me.txtDefQty.Text = "1"
			Me.txtDefQty.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label4.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label4.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 18F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.ForeColor = Global.System.Drawing.Color.White
			Me.Label4.Location = New Global.System.Drawing.Point(4, 3)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(468, 38)
			Me.Label4.TabIndex = 56
			Me.Label4.Text = "Product's Unit Information"
			Me.Label4.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(501, 308)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.None
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmUnitButton"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "frmUnitButton"
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040043B0 RID: 17328
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
