Namespace BillPoint
	' Token: 0x02000080 RID: 128
		Public Partial Class frmCategoryPopup
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06001537 RID: 5431 RVA: 0x000E3D40 File Offset: 0x000E1F40
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

		' Token: 0x06001538 RID: 5432 RVA: 0x000E3D90 File Offset: 0x000E1F90
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.grdState = New Global.System.Windows.Forms.DataGridView()
			Me.txtCategoryName = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.DataGridViewTextBoxColumn57 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			CType(Me.grdState, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.grdState.AllowUserToAddRows = False
			Me.grdState.AllowUserToDeleteRows = False
			dataGridViewCellStyle.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.grdState.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.grdState.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.grdState.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.grdState.BackgroundColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FromArgb(228, 255, 142)
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 14F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.FromArgb(228, 255, 142)
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.ControlDarkDark
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.grdState.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.grdState.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.grdState.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn57 })
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.grdState.DefaultCellStyle = dataGridViewCellStyle3
			Me.grdState.EnableHeadersVisualStyles = False
			Me.grdState.Location = New Global.System.Drawing.Point(3, 1)
			Me.grdState.Name = "grdState"
			Me.grdState.RowTemplate.Height = 30
			Me.grdState.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.grdState.Size = New Global.System.Drawing.Size(501, 697)
			Me.grdState.TabIndex = 1829
			Me.txtCategoryName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCategoryName.Location = New Global.System.Drawing.Point(198, 3)
			Me.txtCategoryName.Name = "txtCategoryName"
			Me.txtCategoryName.Size = New Global.System.Drawing.Size(306, 30)
			Me.txtCategoryName.TabIndex = 1830
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(12, 9)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(39, 13)
			Me.Label1.TabIndex = 1831
			Me.Label1.Text = "Label1"
			Me.Label1.Visible = False
			Me.DataGridViewTextBoxColumn57.DataPropertyName = "CategoryName"
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.DataGridViewTextBoxColumn57.DefaultCellStyle = dataGridViewCellStyle4
			Me.DataGridViewTextBoxColumn57.FillWeight = 208.1594F
			Me.DataGridViewTextBoxColumn57.HeaderText = "Select Category"
			Me.DataGridViewTextBoxColumn57.Name = "DataGridViewTextBoxColumn57"
			Me.DataGridViewTextBoxColumn57.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn57.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(502, 699)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.txtCategoryName)
			MyBase.Controls.Add(Me.grdState)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmCategoryPopup"
			Me.Text = "frmState"
			CType(Me.grdState, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04000746 RID: 1862
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
