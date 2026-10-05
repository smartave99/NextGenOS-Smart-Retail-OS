Namespace BillPoint
	' Token: 0x020001D1 RID: 465
		Public Partial Class frmPOS_Update
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06007961 RID: 31073 RVA: 0x005AAA18 File Offset: 0x005A8C18
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

		' Token: 0x06007962 RID: 31074 RVA: 0x005AAA68 File Offset: 0x005A8C68
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.btnUpdate = New Global.System.Windows.Forms.Button()
			Me.txtInput = New Global.System.Windows.Forms.TextBox()
			Me.GroupBox1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.GroupBox1.BackColor = Global.System.Drawing.Color.AliceBlue
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.Label1)
			Me.GroupBox1.Controls.Add(Me.btnUpdate)
			Me.GroupBox1.Controls.Add(Me.txtInput)
			Me.GroupBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(18, 13)
			Me.GroupBox1.Margin = New Global.System.Windows.Forms.Padding(4)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Padding = New Global.System.Windows.Forms.Padding(4)
			Me.GroupBox1.Size = New Global.System.Drawing.Size(501, 245)
			Me.GroupBox1.TabIndex = 0
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Qty Update"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(262, 161)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(57, 18)
			Me.Label3.TabIndex = 1831
			Me.Label3.Text = "Label3"
			Me.Label3.Visible = False
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(311, 43)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(57, 18)
			Me.Label2.TabIndex = 1830
			Me.Label2.Text = "Label2"
			Me.Label2.Visible = False
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(311, 25)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(57, 18)
			Me.Label1.TabIndex = 1829
			Me.Label1.Text = "Label1"
			Me.Label1.Visible = False
			Me.btnUpdate.BackgroundImage = Global.BillPoint.My.Resources.Resources.Updaten1
			Me.btnUpdate.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnUpdate.FlatAppearance.BorderSize = 0
			Me.btnUpdate.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnUpdate.Location = New Global.System.Drawing.Point(265, 76)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(229, 80)
			Me.btnUpdate.TabIndex = 1828
			Me.btnUpdate.UseVisualStyleBackColor = True
			Me.txtInput.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 48F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtInput.Location = New Global.System.Drawing.Point(7, 76)
			Me.txtInput.Name = "txtInput"
			Me.txtInput.Size = New Global.System.Drawing.Size(252, 80)
			Me.txtInput.TabIndex = 0
			MyBase.AcceptButton = Me.btnUpdate
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(9F, 18F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.SteelBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(532, 271)
			MyBase.Controls.Add(Me.GroupBox1)
			Me.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			MyBase.Margin = New Global.System.Windows.Forms.Padding(4)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmPOS_Update"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "POS Update"
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040035B1 RID: 13745
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
