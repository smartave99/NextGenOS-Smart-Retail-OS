Namespace BillPoint
	' Token: 0x020000B0 RID: 176
		Public Partial Class frmMultiBillPayment
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060019A8 RID: 6568 RVA: 0x0011A150 File Offset: 0x00118350
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

		' Token: 0x060019A9 RID: 6569 RVA: 0x0011A1A0 File Offset: 0x001183A0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmMultiBillPayment))
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridViewTextBoxColumn55 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn57 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewComboBoxColumn1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.btnSettings = New Global.System.Windows.Forms.Button()
			Me.BtnGrandTotal = New Global.GelButtons.GelButton()
			Me.btnPaidAmount = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.System.Windows.Forms.Button()
			Me.lblCustomerId = New Global.System.Windows.Forms.Label()
			Me.lblLimit = New Global.System.Windows.Forms.Label()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dgw.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FromArgb(228, 255, 142)
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 14F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.FromArgb(228, 255, 142)
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.ControlDarkDark
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dgw.ColumnHeadersVisible = False
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn55, Me.DataGridViewTextBoxColumn57, Me.DataGridViewComboBoxColumn1 })
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.Location = New Global.System.Drawing.Point(4, 145)
			Me.dgw.Name = "dgw"
			Me.dgw.RowTemplate.Height = 30
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(413, 478)
			Me.dgw.TabIndex = 1829
			Me.DataGridViewTextBoxColumn55.DataPropertyName = "PID1"
			Me.DataGridViewTextBoxColumn55.HeaderText = "PID"
			Me.DataGridViewTextBoxColumn55.Name = "DataGridViewTextBoxColumn55"
			Me.DataGridViewTextBoxColumn55.Visible = False
			Me.DataGridViewTextBoxColumn57.DataPropertyName = "ProductName1"
			Me.DataGridViewTextBoxColumn57.FillWeight = 180F
			Me.DataGridViewTextBoxColumn57.HeaderText = "Payment Mode"
			Me.DataGridViewTextBoxColumn57.Name = "DataGridViewTextBoxColumn57"
			Me.DataGridViewTextBoxColumn57.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn57.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridViewComboBoxColumn1.FillWeight = 120F
			Me.DataGridViewComboBoxColumn1.HeaderText = "Amount"
			Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
			Me.DataGridViewComboBoxColumn1.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.btnSettings.Location = New Global.System.Drawing.Point(343, 1)
			Me.btnSettings.Name = "btnSettings"
			Me.btnSettings.Size = New Global.System.Drawing.Size(75, 23)
			Me.btnSettings.TabIndex = 1830
			Me.btnSettings.Text = "Settings"
			Me.btnSettings.UseVisualStyleBackColor = True
			Me.BtnGrandTotal.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.BtnGrandTotal.AutoSize = True
			Me.BtnGrandTotal.BackColor = Global.System.Drawing.Color.GreenYellow
			Me.BtnGrandTotal.FlatAppearance.BorderSize = 0
			Me.BtnGrandTotal.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BtnGrandTotal.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold)
			Me.BtnGrandTotal.ForeColor = Global.System.Drawing.Color.Green
			Me.BtnGrandTotal.GradientBottom = Global.System.Drawing.Color.AliceBlue
			Me.BtnGrandTotal.GradientTop = Global.System.Drawing.Color.AliceBlue
			Me.BtnGrandTotal.Image = CType(componentResourceManager.GetObject("BtnGrandTotal.Image"), Global.System.Drawing.Image)
			Me.BtnGrandTotal.Location = New Global.System.Drawing.Point(4, 28)
			Me.BtnGrandTotal.Name = "BtnGrandTotal"
			Me.BtnGrandTotal.Size = New Global.System.Drawing.Size(414, 111)
			Me.BtnGrandTotal.TabIndex = 1831
			Me.BtnGrandTotal.Text = "Net Pay : 0.00"
			Me.BtnGrandTotal.UseVisualStyleBackColor = False
			Me.btnPaidAmount.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnPaidAmount.AutoSize = True
			Me.btnPaidAmount.BackColor = Global.System.Drawing.Color.GreenYellow
			Me.btnPaidAmount.FlatAppearance.BorderSize = 0
			Me.btnPaidAmount.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnPaidAmount.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 21F, Global.System.Drawing.FontStyle.Bold)
			Me.btnPaidAmount.ForeColor = Global.System.Drawing.Color.Green
			Me.btnPaidAmount.GradientBottom = Global.System.Drawing.Color.AliceBlue
			Me.btnPaidAmount.GradientTop = Global.System.Drawing.Color.AliceBlue
			Me.btnPaidAmount.Image = CType(componentResourceManager.GetObject("btnPaidAmount.Image"), Global.System.Drawing.Image)
			Me.btnPaidAmount.Location = New Global.System.Drawing.Point(2, 629)
			Me.btnPaidAmount.Name = "btnPaidAmount"
			Me.btnPaidAmount.Size = New Global.System.Drawing.Size(431, 53)
			Me.btnPaidAmount.TabIndex = 1832
			Me.btnPaidAmount.Text = "Paid Amount : 0.00"
			Me.btnPaidAmount.UseVisualStyleBackColor = False
			Me.btnSave.BackgroundImage = Global.BillPoint.My.Resources.Resources.Save_copy_a1
			Me.btnSave.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnSave.FlatAppearance.BorderSize = 0
			Me.btnSave.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSave.Location = New Global.System.Drawing.Point(85, 688)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(234, 70)
			Me.btnSave.TabIndex = 1833
			Me.btnSave.UseVisualStyleBackColor = True
			Me.lblCustomerId.AutoSize = True
			Me.lblCustomerId.Location = New Global.System.Drawing.Point(155, 9)
			Me.lblCustomerId.Name = "lblCustomerId"
			Me.lblCustomerId.Size = New Global.System.Drawing.Size(70, 13)
			Me.lblCustomerId.TabIndex = 1834
			Me.lblCustomerId.Text = "lblCustomerId"
			Me.lblCustomerId.Visible = False
			Me.lblLimit.AutoSize = True
			Me.lblLimit.Location = New Global.System.Drawing.Point(242, 9)
			Me.lblLimit.Name = "lblLimit"
			Me.lblLimit.Size = New Global.System.Drawing.Size(38, 13)
			Me.lblLimit.TabIndex = 1835
			Me.lblLimit.Text = "lblLimit"
			Me.lblLimit.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(423, 762)
			MyBase.Controls.Add(Me.lblLimit)
			MyBase.Controls.Add(Me.lblCustomerId)
			MyBase.Controls.Add(Me.btnSave)
			MyBase.Controls.Add(Me.btnSettings)
			MyBase.Controls.Add(Me.btnPaidAmount)
			MyBase.Controls.Add(Me.BtnGrandTotal)
			MyBase.Controls.Add(Me.dgw)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmMultiBillPayment"
			MyBase.ShowIcon = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040009F7 RID: 2551
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
