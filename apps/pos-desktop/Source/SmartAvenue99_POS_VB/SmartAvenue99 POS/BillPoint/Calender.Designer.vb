Namespace BillPoint
	' Token: 0x02000315 RID: 789
		Public Partial Class Calender
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600BC8B RID: 48267 RVA: 0x0078EB5C File Offset: 0x0078CD5C
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

		' Token: 0x0600BC8C RID: 48268 RVA: 0x0078EBAC File Offset: 0x0078CDAC
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.Calender))
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.MonthCalendar1 = New Global.System.Windows.Forms.MonthCalendar()
			Me.Label39 = New Global.System.Windows.Forms.Label()
			Me.Label40 = New Global.System.Windows.Forms.Label()
			Me.MaskedTextBox1 = New Global.System.Windows.Forms.MaskedTextBox()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.btnReset = New Global.System.Windows.Forms.Button()
			Me.Panel5.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel5.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Panel5.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel5.Controls.Add(Me.MonthCalendar1)
			Me.Panel5.Location = New Global.System.Drawing.Point(12, 34)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(531, 387)
			Me.Panel5.TabIndex = 88
			Me.MonthCalendar1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 128)
			Me.MonthCalendar1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.MonthCalendar1.Location = New Global.System.Drawing.Point(4, 4)
			Me.MonthCalendar1.Name = "MonthCalendar1"
			Me.MonthCalendar1.TabIndex = 1
			Me.MonthCalendar1.TabStop = False
			Me.Label39.AutoSize = True
			Me.Label39.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 15.75F, Global.System.Drawing.FontStyle.Underline, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label39.ForeColor = Global.System.Drawing.Color.White
			Me.Label39.Location = New Global.System.Drawing.Point(218, 6)
			Me.Label39.Name = "Label39"
			Me.Label39.Size = New Global.System.Drawing.Size(130, 24)
			Me.Label39.TabIndex = 0
			Me.Label39.Text = "CALENDAR"
			Me.Label40.AutoSize = True
			Me.Label40.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label40.ForeColor = Global.System.Drawing.Color.White
			Me.Label40.Location = New Global.System.Drawing.Point(10, 425)
			Me.Label40.Name = "Label40"
			Me.Label40.Size = New Global.System.Drawing.Size(203, 12)
			Me.Label40.TabIndex = 2
			Me.Label40.Text = "Searchable Format :- (DD-MM-YYYY)"
			Me.MaskedTextBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.MaskedTextBox1.Font = New Global.System.Drawing.Font("Arial Narrow", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.MaskedTextBox1.Location = New Global.System.Drawing.Point(12, 441)
			Me.MaskedTextBox1.Mask = "00 - 00 - 0000"
			Me.MaskedTextBox1.Name = "MaskedTextBox1"
			Me.MaskedTextBox1.Size = New Global.System.Drawing.Size(109, 29)
			Me.MaskedTextBox1.TabIndex = 0
			Me.MaskedTextBox1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Button2.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Button2.BackgroundImage = Global.BillPoint.My.Resources.Resources.NewRed
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button2.Location = New Global.System.Drawing.Point(135, 438)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(99, 33)
			Me.Button2.TabIndex = 89
			Me.Button2.Text = "&Search"
			Me.Button2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button2.UseVisualStyleBackColor = False
			Me.btnReset.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.btnReset.BackgroundImage = Global.BillPoint.My.Resources.Resources.NewGreen
			Me.btnReset.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnReset.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnReset.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnReset.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnReset.ForeColor = Global.System.Drawing.Color.White
			Me.btnReset.Image = CType(componentResourceManager.GetObject("btnReset.Image"), Global.System.Drawing.Image)
			Me.btnReset.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnReset.Location = New Global.System.Drawing.Point(253, 438)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(99, 33)
			Me.btnReset.TabIndex = 90
			Me.btnReset.Text = "&Reset"
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReset.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			MyBase.ClientSize = New Global.System.Drawing.Size(555, 479)
			MyBase.Controls.Add(Me.Button2)
			MyBase.Controls.Add(Me.btnReset)
			MyBase.Controls.Add(Me.Label39)
			MyBase.Controls.Add(Me.MaskedTextBox1)
			MyBase.Controls.Add(Me.Panel5)
			MyBase.Controls.Add(Me.Label40)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.MaximizeBox = False
			MyBase.Name = "Calender"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Calendar"
			Me.Panel5.ResumeLayout(False)
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04004BED RID: 19437
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
