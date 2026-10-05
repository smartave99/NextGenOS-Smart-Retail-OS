Namespace BillPoint
	' Token: 0x0200012D RID: 301
		Public Partial Class frmMigratedb_auto
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06003452 RID: 13394 RVA: 0x00203B10 File Offset: 0x00201D10
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

		' Token: 0x06003453 RID: 13395 RVA: 0x00203B60 File Offset: 0x00201D60
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridView2 = New Global.System.Windows.Forms.DataGridView()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.Button4 = New Global.System.Windows.Forms.Button()
			Me.Button5 = New Global.System.Windows.Forms.Button()
			Me.Button6 = New Global.System.Windows.Forms.Button()
			Me.Button7 = New Global.System.Windows.Forms.Button()
			Me.Button8 = New Global.System.Windows.Forms.Button()
			Me.Button9 = New Global.System.Windows.Forms.Button()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.DataGridView2, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Button1.Location = New Global.System.Drawing.Point(373, 12)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(75, 23)
			Me.Button1.TabIndex = 0
			Me.Button1.Text = "DB Create"
			Me.Button1.UseVisualStyleBackColor = True
			Me.Button2.Location = New Global.System.Drawing.Point(1335, 12)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(97, 23)
			Me.Button2.TabIndex = 1
			Me.Button2.Text = "Db Schema"
			Me.Button2.UseVisualStyleBackColor = True
			Me.DataGridView1.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.DataGridView1.Location = New Global.System.Drawing.Point(12, 41)
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.Size = New Global.System.Drawing.Size(416, 397)
			Me.DataGridView1.TabIndex = 2
			Me.DataGridView2.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.DataGridView2.Location = New Global.System.Drawing.Point(434, 41)
			Me.DataGridView2.Name = "DataGridView2"
			Me.DataGridView2.Size = New Global.System.Drawing.Size(327, 397)
			Me.DataGridView2.TabIndex = 3
			Me.Button3.Location = New Global.System.Drawing.Point(1438, 12)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(97, 23)
			Me.Button3.TabIndex = 4
			Me.Button3.Text = "Db Migrate"
			Me.Button3.UseVisualStyleBackColor = True
			Me.Button4.Location = New Global.System.Drawing.Point(646, 12)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New Global.System.Drawing.Size(115, 23)
			Me.Button4.TabIndex = 5
			Me.Button4.Text = "Data Migrate"
			Me.Button4.UseVisualStyleBackColor = True
			Me.Button5.Location = New Global.System.Drawing.Point(454, 12)
			Me.Button5.Name = "Button5"
			Me.Button5.Size = New Global.System.Drawing.Size(94, 23)
			Me.Button5.TabIndex = 6
			Me.Button5.Text = "Db Schema"
			Me.Button5.UseVisualStyleBackColor = True
			Me.Button6.Location = New Global.System.Drawing.Point(252, 12)
			Me.Button6.Name = "Button6"
			Me.Button6.Size = New Global.System.Drawing.Size(115, 23)
			Me.Button6.TabIndex = 7
			Me.Button6.Text = "remote column Add"
			Me.Button6.UseVisualStyleBackColor = True
			Me.Button7.Location = New Global.System.Drawing.Point(133, 12)
			Me.Button7.Name = "Button7"
			Me.Button7.Size = New Global.System.Drawing.Size(115, 23)
			Me.Button7.TabIndex = 8
			Me.Button7.Text = "Drop all tables"
			Me.Button7.UseVisualStyleBackColor = True
			Me.Button8.Location = New Global.System.Drawing.Point(12, 12)
			Me.Button8.Name = "Button8"
			Me.Button8.Size = New Global.System.Drawing.Size(115, 23)
			Me.Button8.TabIndex = 9
			Me.Button8.Text = "localDb reset"
			Me.Button8.UseVisualStyleBackColor = True
			Me.Button9.Location = New Global.System.Drawing.Point(554, 12)
			Me.Button9.Name = "Button9"
			Me.Button9.Size = New Global.System.Drawing.Size(86, 23)
			Me.Button9.TabIndex = 10
			Me.Button9.Text = "Db Schema2"
			Me.Button9.UseVisualStyleBackColor = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(777, 449)
			MyBase.Controls.Add(Me.Button9)
			MyBase.Controls.Add(Me.Button8)
			MyBase.Controls.Add(Me.Button7)
			MyBase.Controls.Add(Me.Button6)
			MyBase.Controls.Add(Me.Button5)
			MyBase.Controls.Add(Me.Button4)
			MyBase.Controls.Add(Me.Button3)
			MyBase.Controls.Add(Me.DataGridView2)
			MyBase.Controls.Add(Me.DataGridView1)
			MyBase.Controls.Add(Me.Button2)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Name = "frmMigratedb_auto"
			Me.Text = "frmMigratedb_auto"
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.DataGridView2, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04001688 RID: 5768
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
