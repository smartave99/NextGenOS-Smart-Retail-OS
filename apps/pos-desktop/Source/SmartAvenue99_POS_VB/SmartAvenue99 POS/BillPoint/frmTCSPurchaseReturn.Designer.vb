Namespace BillPoint
	' Token: 0x020004E2 RID: 1250
		Public Partial Class frmTCSPurchaseReturn
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600FF18 RID: 65304 RVA: 0x00985C60 File Offset: 0x00983E60
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

		' Token: 0x0600FF19 RID: 65305 RVA: 0x00985CB0 File Offset: 0x00983EB0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle8 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmTCSPurchaseReturn))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column28 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column20 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column21 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.btnExportExcel = New Global.System.Windows.Forms.Button()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.btnGetData = New Global.System.Windows.Forms.Button()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.Panel1.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox2.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.btnExportExcel)
			Me.Panel1.Controls.Add(Me.Label3)
			Me.Panel1.Controls.Add(Me.TextBox1)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Location = New Global.System.Drawing.Point(12, 12)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(957, 498)
			Me.Panel1.TabIndex = 3
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dgw.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.dgw.AutoSizeRowsMode = Global.System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 30
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column28, Me.Column2, Me.Column20, Me.Column21, Me.Column5, Me.Column6, Me.Column8, Me.Column15 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(4, 119)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 25
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(947, 374)
			Me.dgw.TabIndex = 412
			Me.dgw.TabStop = False
			Me.Column1.HeaderText = "PR ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			Me.Column28.HeaderText = "PR No."
			Me.Column28.Name = "Column28"
			Me.Column28.[ReadOnly] = True
			dataGridViewCellStyle6.Format = "dd/MM/yyyy"
			Me.Column2.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column2.HeaderText = "PR Date"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column20.HeaderText = "Purchase Invoice No."
			Me.Column20.Name = "Column20"
			Me.Column20.[ReadOnly] = True
			dataGridViewCellStyle7.Format = "dd/MM/yyyy"
			Me.Column21.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column21.HeaderText = "Purchase Date"
			Me.Column21.Name = "Column21"
			Me.Column21.[ReadOnly] = True
			Me.Column5.HeaderText = "Supplier ID"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column6.HeaderText = "Supplier Name"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column8.DefaultCellStyle = dataGridViewCellStyle8
			Me.Column8.HeaderText = "TCS Amount"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Column15.HeaderText = "Bill Sundry Type"
			Me.Column15.Name = "Column15"
			Me.Column15.[ReadOnly] = True
			Me.btnExportExcel.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnExportExcel.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnExportExcel.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnExportExcel.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnExportExcel.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnExportExcel.ForeColor = Global.System.Drawing.Color.White
			Me.btnExportExcel.Image = CType(componentResourceManager.GetObject("btnExportExcel.Image"), Global.System.Drawing.Image)
			Me.btnExportExcel.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnExportExcel.Location = New Global.System.Drawing.Point(395, 60)
			Me.btnExportExcel.Name = "btnExportExcel"
			Me.btnExportExcel.Size = New Global.System.Drawing.Size(80, 41)
			Me.btnExportExcel.TabIndex = 411
			Me.btnExportExcel.Text = "&Export Excel"
			Me.btnExportExcel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnExportExcel.TextImageRelation = Global.System.Windows.Forms.TextImageRelation.ImageBeforeText
			Me.btnExportExcel.UseVisualStyleBackColor = False
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.Location = New Global.System.Drawing.Point(625, 93)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(147, 20)
			Me.Label3.TabIndex = 409
			Me.Label3.Text = "Total TCS Amount :"
			Me.TextBox1.BackColor = Global.System.Drawing.Color.White
			Me.TextBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.ForeColor = Global.System.Drawing.Color.Blue
			Me.TextBox1.Location = New Global.System.Drawing.Point(778, 91)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.[ReadOnly] = True
			Me.TextBox1.Size = New Global.System.Drawing.Size(171, 22)
			Me.TextBox1.TabIndex = 410
			Me.TextBox1.TabStop = False
			Me.TextBox1.Text = "0.00"
			Me.GroupBox2.Controls.Add(Me.dtpDateTo)
			Me.GroupBox2.Controls.Add(Me.Label2)
			Me.GroupBox2.Controls.Add(Me.btnGetData)
			Me.GroupBox2.Controls.Add(Me.Label4)
			Me.GroupBox2.Controls.Add(Me.dtpDateFrom)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(4, 40)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(372, 75)
			Me.GroupBox2.TabIndex = 407
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Search by Date :"
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(156, 41)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateTo.TabIndex = 14
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(153, 22)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label2.TabIndex = 13
			Me.Label2.Text = "To :"
			Me.btnGetData.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnGetData.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnGetData.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnGetData.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnGetData.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnGetData.ForeColor = Global.System.Drawing.Color.White
			Me.btnGetData.Location = New Global.System.Drawing.Point(281, 39)
			Me.btnGetData.Name = "btnGetData"
			Me.btnGetData.Size = New Global.System.Drawing.Size(76, 24)
			Me.btnGetData.TabIndex = 16
			Me.btnGetData.Text = "Get Data"
			Me.btnGetData.UseVisualStyleBackColor = False
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(13, 22)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label4.TabIndex = 12
			Me.Label4.Text = "From :"
			Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateFrom.Location = New Global.System.Drawing.Point(16, 41)
			Me.dtpDateFrom.Name = "dtpDateFrom"
			Me.dtpDateFrom.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateFrom.TabIndex = 11
			Me.Label1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(4, 4)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(947, 33)
			Me.Label1.TabIndex = 404
			Me.Label1.Text = "TCS Received Record (Purchase Return)"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(981, 522)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmTCSPurchaseReturn"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040061B8 RID: 25016
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
