Namespace BillPoint
	' Token: 0x020000B1 RID: 177
		Public Partial Class frmCreditDebit
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060019D2 RID: 6610 RVA: 0x0011C104 File Offset: 0x0011A304
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

		' Token: 0x060019D3 RID: 6611 RVA: 0x0011C154 File Offset: 0x0011A354
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.grdCreditDebit = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridViewTextBoxColumn57 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			CType(Me.grdCreditDebit, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.grdCreditDebit.AllowUserToAddRows = False
			Me.grdCreditDebit.AllowUserToDeleteRows = False
			dataGridViewCellStyle.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.grdCreditDebit.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.grdCreditDebit.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.grdCreditDebit.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.grdCreditDebit.BackgroundColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FromArgb(228, 255, 142)
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 14F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.FromArgb(228, 255, 142)
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.ControlDarkDark
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.grdCreditDebit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.grdCreditDebit.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.grdCreditDebit.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn57 })
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.grdCreditDebit.DefaultCellStyle = dataGridViewCellStyle3
			Me.grdCreditDebit.EnableHeadersVisualStyles = False
			Me.grdCreditDebit.Location = New Global.System.Drawing.Point(1, 2)
			Me.grdCreditDebit.Name = "grdCreditDebit"
			Me.grdCreditDebit.RowTemplate.Height = 30
			Me.grdCreditDebit.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.grdCreditDebit.Size = New Global.System.Drawing.Size(348, 120)
			Me.grdCreditDebit.TabIndex = 1829
			Me.DataGridViewTextBoxColumn57.DataPropertyName = "StateName"
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.DataGridViewTextBoxColumn57.DefaultCellStyle = dataGridViewCellStyle4
			Me.DataGridViewTextBoxColumn57.FillWeight = 208.1594F
			Me.DataGridViewTextBoxColumn57.HeaderText = " Select Cr/Dr"
			Me.DataGridViewTextBoxColumn57.Name = "DataGridViewTextBoxColumn57"
			Me.DataGridViewTextBoxColumn57.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn57.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(12, 9)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(39, 13)
			Me.Label1.TabIndex = 1831
			Me.Label1.Text = "Label1"
			Me.Label1.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(350, 124)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.grdCreditDebit)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmCreditDebit"
			Me.Text = "frmState"
			CType(Me.grdCreditDebit, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04000A04 RID: 2564
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
