Namespace BillPoint
	' Token: 0x0200029D RID: 669
		Public Partial Class frmCustomiseBarcode
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600A958 RID: 43352 RVA: 0x00713DF0 File Offset: 0x00711FF0
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

		' Token: 0x0600A959 RID: 43353 RVA: 0x00713E40 File Offset: 0x00712040
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmCustomiseBarcode))
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.txtNoOfCopies = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.ComboBox2 = New Global.System.Windows.Forms.ComboBox()
			Me.Label44 = New Global.System.Windows.Forms.Label()
			Me.txtCompany = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.chkSelectAll = New Global.System.Windows.Forms.CheckBox()
			Me.listView1 = New Global.System.Windows.Forms.ListView()
			Me.columnHeader1 = New Global.System.Windows.Forms.ColumnHeader()
			Me.columnHeader3 = New Global.System.Windows.Forms.ColumnHeader()
			Me.Category = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader2 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader4 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader5 = New Global.System.Windows.Forms.ColumnHeader()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.txtPcode = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.txtScode = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.txtBarcode = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txtProductName = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.RadioButton1 = New Global.System.Windows.Forms.RadioButton()
			Me.RadioButton2 = New Global.System.Windows.Forms.RadioButton()
			Me.GroupBox2.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.GroupBox2.BackColor = Global.System.Drawing.Color.White
			Me.GroupBox2.Controls.Add(Me.GelButton1)
			Me.GroupBox2.Controls.Add(Me.GelButton3)
			Me.GroupBox2.Controls.Add(Me.txtNoOfCopies)
			Me.GroupBox2.Controls.Add(Me.Label6)
			Me.GroupBox2.Controls.Add(Me.ComboBox2)
			Me.GroupBox2.Controls.Add(Me.Label44)
			Me.GroupBox2.Controls.Add(Me.txtCompany)
			Me.GroupBox2.Controls.Add(Me.Label1)
			Me.GroupBox2.ForeColor = Global.System.Drawing.Color.Black
			Me.GroupBox2.Location = New Global.System.Drawing.Point(502, 9)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(334, 96)
			Me.GroupBox2.TabIndex = 75
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Generate Barcode"
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(226, 60)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(102, 29)
			Me.GelButton1.TabIndex = 1684
			Me.GelButton1.Text = "Generate"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.GelButton3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton3.FlatAppearance.BorderSize = 0
			Me.GelButton3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton3.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton3.GradientBottom = Global.System.Drawing.Color.Red
			Me.GelButton3.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton3.Image = CType(componentResourceManager.GetObject("GelButton3.Image"), Global.System.Drawing.Image)
			Me.GelButton3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton3.Location = New Global.System.Drawing.Point(116, 59)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(104, 29)
			Me.GelButton3.TabIndex = 1685
			Me.GelButton3.Text = "&Reset"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.txtNoOfCopies.BackColor = Global.System.Drawing.Color.White
			Me.txtNoOfCopies.Location = New Global.System.Drawing.Point(9, 33)
			Me.txtNoOfCopies.Name = "txtNoOfCopies"
			Me.txtNoOfCopies.Size = New Global.System.Drawing.Size(90, 20)
			Me.txtNoOfCopies.TabIndex = 0
			Me.txtNoOfCopies.Text = "1"
			Me.txtNoOfCopies.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label6.AutoSize = True
			Me.Label6.ForeColor = Global.System.Drawing.Color.Black
			Me.Label6.Location = New Global.System.Drawing.Point(100, 17)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(84, 13)
			Me.Label6.TabIndex = 1682
			Me.Label6.Text = "Template Type :"
			Me.ComboBox2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox2.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox2.FormattingEnabled = True
			Me.ComboBox2.Items.AddRange(New Object() { "A4 Size - Single", "A4 Size - Quadrat", "Thermal Size - Single", "Thermal Size - Double" })
			Me.ComboBox2.Location = New Global.System.Drawing.Point(103, 33)
			Me.ComboBox2.Name = "ComboBox2"
			Me.ComboBox2.Size = New Global.System.Drawing.Size(225, 21)
			Me.ComboBox2.TabIndex = 1
			Me.Label44.AutoSize = True
			Me.Label44.ForeColor = Global.System.Drawing.Color.Red
			Me.Label44.Location = New Global.System.Drawing.Point(84, 22)
			Me.Label44.Name = "Label44"
			Me.Label44.Size = New Global.System.Drawing.Size(11, 13)
			Me.Label44.TabIndex = 1677
			Me.Label44.Text = "*"
			Me.txtCompany.Location = New Global.System.Drawing.Point(252, 7)
			Me.txtCompany.Name = "txtCompany"
			Me.txtCompany.[ReadOnly] = True
			Me.txtCompany.Size = New Global.System.Drawing.Size(39, 20)
			Me.txtCompany.TabIndex = 70
			Me.txtCompany.TabStop = False
			Me.txtCompany.Visible = False
			Me.Label1.AutoSize = True
			Me.Label1.ForeColor = Global.System.Drawing.Color.Black
			Me.Label1.Location = New Global.System.Drawing.Point(6, 17)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(79, 13)
			Me.Label1.TabIndex = 28
			Me.Label1.Text = "No. Of Copies :"
			Me.chkSelectAll.AutoSize = True
			Me.chkSelectAll.BackColor = Global.System.Drawing.Color.Lime
			Me.chkSelectAll.Checked = True
			Me.chkSelectAll.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.chkSelectAll.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkSelectAll.Location = New Global.System.Drawing.Point(9, 90)
			Me.chkSelectAll.Name = "chkSelectAll"
			Me.chkSelectAll.Size = New Global.System.Drawing.Size(70, 17)
			Me.chkSelectAll.TabIndex = 73
			Me.chkSelectAll.TabStop = False
			Me.chkSelectAll.Text = "Select All"
			Me.chkSelectAll.UseVisualStyleBackColor = False
			Me.listView1.BackColor = Global.System.Drawing.Color.FromArgb(255, 220, 128)
			Me.listView1.CheckBoxes = True
			Me.listView1.Columns.AddRange(New Global.System.Windows.Forms.ColumnHeader() { Me.columnHeader1, Me.columnHeader3, Me.Category, Me.ColumnHeader2, Me.ColumnHeader4, Me.ColumnHeader5 })
			Me.listView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.listView1.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.listView1.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.listView1.GridLines = True
			Me.listView1.HideSelection = False
			Me.listView1.Location = New Global.System.Drawing.Point(9, 111)
			Me.listView1.Name = "listView1"
			Me.listView1.Size = New Global.System.Drawing.Size(827, 471)
			Me.listView1.TabIndex = 74
			Me.listView1.TabStop = False
			Me.listView1.UseCompatibleStateImageBehavior = False
			Me.listView1.View = Global.System.Windows.Forms.View.Details
			Me.columnHeader1.Text = "Product Code"
			Me.columnHeader1.Width = 100
			Me.columnHeader3.Text = "Product Name"
			Me.columnHeader3.Width = 195
			Me.Category.Text = "Supplier Code"
			Me.Category.Width = 105
			Me.ColumnHeader2.Text = "Barcode"
			Me.ColumnHeader2.Width = 120
			Me.ColumnHeader4.Text = "Sticker Code"
			Me.ColumnHeader4.Width = 200
			Me.ColumnHeader5.Text = "Sale Price"
			Me.ColumnHeader5.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader5.Width = 102
			Me.GroupBox1.BackColor = Global.System.Drawing.Color.White
			Me.GroupBox1.Controls.Add(Me.txtPcode)
			Me.GroupBox1.Controls.Add(Me.Label5)
			Me.GroupBox1.Controls.Add(Me.txtScode)
			Me.GroupBox1.Controls.Add(Me.Label4)
			Me.GroupBox1.Controls.Add(Me.txtBarcode)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.txtProductName)
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.ForeColor = Global.System.Drawing.Color.Black
			Me.GroupBox1.Location = New Global.System.Drawing.Point(9, 9)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(494, 77)
			Me.GroupBox1.TabIndex = 72
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Search"
			Me.txtPcode.BackColor = Global.System.Drawing.Color.White
			Me.txtPcode.Location = New Global.System.Drawing.Point(369, 40)
			Me.txtPcode.Name = "txtPcode"
			Me.txtPcode.Size = New Global.System.Drawing.Size(117, 20)
			Me.txtPcode.TabIndex = 30
			Me.Label5.AutoSize = True
			Me.Label5.ForeColor = Global.System.Drawing.Color.Black
			Me.Label5.Location = New Global.System.Drawing.Point(366, 21)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(78, 13)
			Me.Label5.TabIndex = 29
			Me.Label5.Text = "Product Code :"
			Me.txtScode.BackColor = Global.System.Drawing.Color.White
			Me.txtScode.Location = New Global.System.Drawing.Point(248, 40)
			Me.txtScode.Name = "txtScode"
			Me.txtScode.Size = New Global.System.Drawing.Size(117, 20)
			Me.txtScode.TabIndex = 28
			Me.Label4.AutoSize = True
			Me.Label4.ForeColor = Global.System.Drawing.Color.Black
			Me.Label4.Location = New Global.System.Drawing.Point(245, 21)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(79, 13)
			Me.Label4.TabIndex = 27
			Me.Label4.Text = "Supplier Code :"
			Me.txtBarcode.BackColor = Global.System.Drawing.Color.White
			Me.txtBarcode.Location = New Global.System.Drawing.Point(128, 40)
			Me.txtBarcode.Name = "txtBarcode"
			Me.txtBarcode.Size = New Global.System.Drawing.Size(117, 20)
			Me.txtBarcode.TabIndex = 26
			Me.Label2.AutoSize = True
			Me.Label2.ForeColor = Global.System.Drawing.Color.Black
			Me.Label2.Location = New Global.System.Drawing.Point(125, 21)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(53, 13)
			Me.Label2.TabIndex = 25
			Me.Label2.Text = "Barcode :"
			Me.txtProductName.BackColor = Global.System.Drawing.Color.White
			Me.txtProductName.Location = New Global.System.Drawing.Point(7, 40)
			Me.txtProductName.Name = "txtProductName"
			Me.txtProductName.Size = New Global.System.Drawing.Size(117, 20)
			Me.txtProductName.TabIndex = 24
			Me.Label3.AutoSize = True
			Me.Label3.ForeColor = Global.System.Drawing.Color.Black
			Me.Label3.Location = New Global.System.Drawing.Point(4, 21)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(81, 13)
			Me.Label3.TabIndex = 22
			Me.Label3.Text = "Product Name :"
			Me.RadioButton1.AutoSize = True
			Me.RadioButton1.BackColor = Global.System.Drawing.Color.Yellow
			Me.RadioButton1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.RadioButton1.Location = New Global.System.Drawing.Point(99, 90)
			Me.RadioButton1.Name = "RadioButton1"
			Me.RadioButton1.Size = New Global.System.Drawing.Size(52, 17)
			Me.RadioButton1.TabIndex = 76
			Me.RadioButton1.Text = "Retail"
			Me.RadioButton1.UseVisualStyleBackColor = False
			Me.RadioButton2.AutoSize = True
			Me.RadioButton2.BackColor = Global.System.Drawing.Color.Yellow
			Me.RadioButton2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.RadioButton2.Location = New Global.System.Drawing.Point(160, 90)
			Me.RadioButton2.Name = "RadioButton2"
			Me.RadioButton2.Size = New Global.System.Drawing.Size(75, 17)
			Me.RadioButton2.TabIndex = 77
			Me.RadioButton2.Text = "Wholesale"
			Me.RadioButton2.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			MyBase.ClientSize = New Global.System.Drawing.Size(845, 590)
			MyBase.Controls.Add(Me.RadioButton2)
			MyBase.Controls.Add(Me.RadioButton1)
			MyBase.Controls.Add(Me.GroupBox2)
			MyBase.Controls.Add(Me.chkSelectAll)
			MyBase.Controls.Add(Me.listView1)
			MyBase.Controls.Add(Me.GroupBox1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmCustomiseBarcode"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Cipher Barcode Label Printing"
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040046DC RID: 18140
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
