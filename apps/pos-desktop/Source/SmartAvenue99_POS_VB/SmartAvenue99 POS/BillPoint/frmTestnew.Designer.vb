Namespace BillPoint
	' Token: 0x0200020C RID: 524
		Public Partial Class frmTestnew
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06009899 RID: 39065 RVA: 0x006D90D4 File Offset: 0x006D72D4
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

		' Token: 0x0600989A RID: 39066 RVA: 0x006D9124 File Offset: 0x006D7324
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column29 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.txtProductID = New Global.System.Windows.Forms.TextBox()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.PictureBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.PictureBox1.Location = New Global.System.Drawing.Point(74, 46)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(301, 238)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 0
			Me.PictureBox1.TabStop = False
			Me.Button1.Location = New Global.System.Drawing.Point(88, 303)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(75, 23)
			Me.Button1.TabIndex = 1
			Me.Button1.Text = "image"
			Me.Button1.UseVisualStyleBackColor = True
			Me.Button2.Location = New Global.System.Drawing.Point(642, 334)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(75, 23)
			Me.Button2.TabIndex = 2
			Me.Button2.Text = "print"
			Me.Button2.UseVisualStyleBackColor = True
			Me.DataGridView1.AllowUserToAddRows = False
			Me.DataGridView1.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.DataGridView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.DataGridView1.BackgroundColor = Global.System.Drawing.Color.White
			Me.DataGridView1.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.DataGridView1.ColumnHeadersHeight = 29
			Me.DataGridView1.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column29 })
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 64)
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.DefaultCellStyle = dataGridViewCellStyle3
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Me.DataGridView1.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView1.Location = New Global.System.Drawing.Point(443, 73)
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.[ReadOnly] = True
			Me.DataGridView1.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.DataGridView1.RowHeadersWidth = 25
			Me.DataGridView1.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.Khaki
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.Black
			Me.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.DataGridView1.RowTemplate.Height = 18
			Me.DataGridView1.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView1.Size = New Global.System.Drawing.Size(222, 188)
			Me.DataGridView1.TabIndex = 88
			Me.DataGridView1.TabStop = False
			Me.Column1.HeaderText = "PID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column29.HeaderText = "Product Image"
			Me.Column29.ImageLayout = Global.System.Windows.Forms.DataGridViewImageCellLayout.Zoom
			Me.Column29.Name = "Column29"
			Me.Column29.[ReadOnly] = True
			Me.TextBox1.Location = New Global.System.Drawing.Point(74, 13)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(100, 20)
			Me.TextBox1.TabIndex = 89
			Me.Button3.Location = New Global.System.Drawing.Point(318, 290)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(75, 23)
			Me.Button3.TabIndex = 90
			Me.Button3.Text = "Add"
			Me.Button3.UseVisualStyleBackColor = True
			Me.txtProductID.Location = New Global.System.Drawing.Point(196, 12)
			Me.txtProductID.Name = "txtProductID"
			Me.txtProductID.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtProductID.TabIndex = 91
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(800, 450)
			MyBase.Controls.Add(Me.txtProductID)
			MyBase.Controls.Add(Me.Button3)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.Controls.Add(Me.DataGridView1)
			MyBase.Controls.Add(Me.Button2)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.PictureBox1)
			MyBase.Name = "frmTestnew"
			Me.Text = "frmTest"
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x0400437F RID: 17279
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
