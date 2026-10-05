Namespace BillPoint
	' Token: 0x02000316 RID: 790
		Public Partial Class Cashrefund
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600BCA1 RID: 48289 RVA: 0x0078F46C File Offset: 0x0078D66C
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

		' Token: 0x0600BCA2 RID: 48290 RVA: 0x0078F4BC File Offset: 0x0078D6BC
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.Cashrefund))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label39 = New Global.System.Windows.Forms.Label()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Panel1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.DarkViolet
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Controls.Add(Me.Button1)
			Me.Panel1.Controls.Add(Me.TextBox3)
			Me.Panel1.Controls.Add(Me.TextBox2)
			Me.Panel1.Controls.Add(Me.TextBox1)
			Me.Panel1.Controls.Add(Me.Label3)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(465, 286)
			Me.Panel1.TabIndex = 0
			Me.Panel2.BackColor = Global.System.Drawing.Color.Cyan
			Me.Panel2.Controls.Add(Me.Label39)
			Me.Panel2.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Panel2.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(463, 34)
			Me.Panel2.TabIndex = 65
			Me.Label39.AutoSize = True
			Me.Label39.Font = New Global.System.Drawing.Font("Arial Black", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label39.ForeColor = Global.System.Drawing.Color.Black
			Me.Label39.Location = New Global.System.Drawing.Point(95, 2)
			Me.Label39.Name = "Label39"
			Me.Label39.Size = New Global.System.Drawing.Size(281, 30)
			Me.Label39.TabIndex = 0
			Me.Label39.Text = "Cash Refund Calculator"
			Me.Button1.BackColor = Global.System.Drawing.Color.White
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Arial", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.Blue
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.Button1.Location = New Global.System.Drawing.Point(187, 220)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(72, 54)
			Me.Button1.TabIndex = 64
			Me.Button1.Text = "&Reset"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.Button1.UseVisualStyleBackColor = False
			Me.TextBox3.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 128)
			Me.TextBox3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox3.Font = New Global.System.Drawing.Font("Arial", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox3.Location = New Global.System.Drawing.Point(220, 162)
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.[ReadOnly] = True
			Me.TextBox3.Size = New Global.System.Drawing.Size(195, 32)
			Me.TextBox3.TabIndex = 5
			Me.TextBox3.TabStop = False
			Me.TextBox3.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox2.Font = New Global.System.Drawing.Font("Arial", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox2.Location = New Global.System.Drawing.Point(220, 109)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(195, 32)
			Me.TextBox2.TabIndex = 4
			Me.TextBox2.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox1.Font = New Global.System.Drawing.Font("Arial", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(220, 56)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(195, 32)
			Me.TextBox1.TabIndex = 3
			Me.TextBox1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label3.BackColor = Global.System.Drawing.Color.FromArgb(255, 128, 0)
			Me.Label3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Label3.Font = New Global.System.Drawing.Font("Arial", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.Location = New Global.System.Drawing.Point(51, 162)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(168, 32)
			Me.Label3.TabIndex = 2
			Me.Label3.Text = "Refund Cash"
			Me.Label3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label2.BackColor = Global.System.Drawing.Color.FromArgb(255, 128, 0)
			Me.Label2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Label2.Font = New Global.System.Drawing.Font("Arial", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.Location = New Global.System.Drawing.Point(51, 109)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(168, 32)
			Me.Label2.TabIndex = 1
			Me.Label2.Text = "Billed Cash"
			Me.Label2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label1.BackColor = Global.System.Drawing.Color.FromArgb(255, 128, 0)
			Me.Label1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Label1.Font = New Global.System.Drawing.Font("Arial", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.Location = New Global.System.Drawing.Point(51, 56)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(168, 32)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Received Cash"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(465, 286)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.MaximizeBox = False
			MyBase.Name = "Cashrefund"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Cash Refund Calculator"
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04004BF5 RID: 19445
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
