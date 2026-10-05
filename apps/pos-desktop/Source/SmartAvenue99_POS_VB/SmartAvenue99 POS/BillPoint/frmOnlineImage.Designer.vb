Namespace BillPoint
	' Token: 0x020002A4 RID: 676
		Public Partial Class frmOnlineImage
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600AD2E RID: 44334 RVA: 0x0073AE08 File Offset: 0x00739008
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

		' Token: 0x0600AD2F RID: 44335 RVA: 0x0073AE58 File Offset: 0x00739058
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.DataGridView2 = New Global.System.Windows.Forms.DataGridView()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			CType(Me.DataGridView2, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.DataGridView2.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.DataGridView2.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.DataGridView2.BackgroundColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.DataGridView2.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.DataGridView2.GridColor = Global.System.Drawing.SystemColors.ControlDarkDark
			Me.DataGridView2.Location = New Global.System.Drawing.Point(11, 10)
			Me.DataGridView2.Name = "DataGridView2"
			Me.DataGridView2.RowTemplate.Height = 140
			Me.DataGridView2.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView2.Size = New Global.System.Drawing.Size(228, 389)
			Me.DataGridView2.TabIndex = 345
			Me.DataGridView2.TabStop = False
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(12, 9)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(39, 13)
			Me.Label1.TabIndex = 346
			Me.Label1.Text = "Label1"
			Me.Label1.Visible = False
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(12, 27)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(39, 13)
			Me.Label2.TabIndex = 347
			Me.Label2.Text = "Label2"
			Me.Label2.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(250, 410)
			MyBase.Controls.Add(Me.DataGridView2)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.Label1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmOnlineImage"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Online Image Library"
			CType(Me.DataGridView2, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04004873 RID: 18547
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
