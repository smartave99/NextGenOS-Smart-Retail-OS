Namespace BillPoint
	' Token: 0x020004AF RID: 1199
		Public Partial Class frmCipherSetting
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600F054 RID: 61524 RVA: 0x00906D1C File Offset: 0x00904F1C
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

		' Token: 0x0600F055 RID: 61525 RVA: 0x00906D6C File Offset: 0x00904F6C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmCipherSetting))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.CheckBox1 = New Global.System.Windows.Forms.CheckBox()
			Me.TableLayoutPanel3 = New Global.System.Windows.Forms.TableLayoutPanel()
			Me.Label19 = New Global.System.Windows.Forms.Label()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.TextBox13 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox14 = New Global.System.Windows.Forms.TextBox()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.TableLayoutPanel2 = New Global.System.Windows.Forms.TableLayoutPanel()
			Me.TextBox11 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox12 = New Global.System.Windows.Forms.TextBox()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.TableLayoutPanel1 = New Global.System.Windows.Forms.TableLayoutPanel()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox4 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox5 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox6 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox7 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox8 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox9 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox10 = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.Panel1.SuspendLayout()
			Me.TableLayoutPanel3.SuspendLayout()
			Me.TableLayoutPanel2.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.TableLayoutPanel1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.CheckBox1)
			Me.Panel1.Controls.Add(Me.TableLayoutPanel3)
			Me.Panel1.Controls.Add(Me.Label16)
			Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.txtID)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(411, 359)
			Me.Panel1.TabIndex = 0
			Me.CheckBox1.AutoSize = True
			Me.CheckBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.CheckBox1.Location = New Global.System.Drawing.Point(232, 268)
			Me.CheckBox1.Name = "CheckBox1"
			Me.CheckBox1.Size = New Global.System.Drawing.Size(160, 19)
			Me.CheckBox1.TabIndex = 13
			Me.CheckBox1.TabStop = False
			Me.CheckBox1.Text = "(Num Code / Char Code)"
			Me.CheckBox1.UseVisualStyleBackColor = True
			Me.CheckBox1.Visible = False
			Me.TableLayoutPanel3.CellBorderStyle = Global.System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
			Me.TableLayoutPanel3.ColumnCount = 2
			Me.TableLayoutPanel3.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 60.97561F))
			Me.TableLayoutPanel3.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 39.02439F))
			Me.TableLayoutPanel3.Controls.Add(Me.Label19, 0, 2)
			Me.TableLayoutPanel3.Controls.Add(Me.Label18, 0, 1)
			Me.TableLayoutPanel3.Controls.Add(Me.Label17, 0, 0)
			Me.TableLayoutPanel3.Controls.Add(Me.TextBox13, 1, 0)
			Me.TableLayoutPanel3.Controls.Add(Me.TextBox14, 1, 1)
			Me.TableLayoutPanel3.Controls.Add(Me.ComboBox1, 1, 2)
			Me.TableLayoutPanel3.Location = New Global.System.Drawing.Point(228, 108)
			Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
			Me.TableLayoutPanel3.RowCount = 3
			Me.TableLayoutPanel3.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 50F))
			Me.TableLayoutPanel3.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 50F))
			Me.TableLayoutPanel3.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Absolute, 26F))
			Me.TableLayoutPanel3.Size = New Global.System.Drawing.Size(165, 84)
			Me.TableLayoutPanel3.TabIndex = 3
			Me.Label19.AutoSize = True
			Me.Label19.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Label19.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label19.ForeColor = Global.System.Drawing.Color.White
			Me.Label19.Location = New Global.System.Drawing.Point(4, 57)
			Me.Label19.Name = "Label19"
			Me.Label19.Size = New Global.System.Drawing.Size(92, 26)
			Me.Label19.TabIndex = 18
			Me.Label19.Text = "Activate"
			Me.Label19.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Label18.AutoSize = True
			Me.Label18.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Label18.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label18.ForeColor = Global.System.Drawing.Color.White
			Me.Label18.Location = New Global.System.Drawing.Point(4, 29)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(92, 27)
			Me.Label18.TabIndex = 16
			Me.Label18.Text = "W.Sale Price (+/-)"
			Me.Label18.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Label17.AutoSize = True
			Me.Label17.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Label17.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label17.ForeColor = Global.System.Drawing.Color.White
			Me.Label17.Location = New Global.System.Drawing.Point(4, 1)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(92, 27)
			Me.Label17.TabIndex = 15
			Me.Label17.Text = "Retail Price (+/-)"
			Me.Label17.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.TextBox13.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.TextBox13.Location = New Global.System.Drawing.Point(103, 4)
			Me.TextBox13.Name = "TextBox13"
			Me.TextBox13.Size = New Global.System.Drawing.Size(58, 20)
			Me.TextBox13.TabIndex = 13
			Me.TextBox13.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox14.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.TextBox14.Location = New Global.System.Drawing.Point(103, 32)
			Me.TextBox14.Name = "TextBox14"
			Me.TextBox14.Size = New Global.System.Drawing.Size(58, 20)
			Me.TextBox14.TabIndex = 14
			Me.TextBox14.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ComboBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "No", "Yes" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(103, 60)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(58, 21)
			Me.ComboBox1.TabIndex = 17
			Me.Label16.ForeColor = Global.System.Drawing.Color.Crimson
			Me.Label16.Location = New Global.System.Drawing.Point(229, 199)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(164, 69)
			Me.Label16.TabIndex = 12
			Me.Label16.Text = "*Note : If makes any modification here, you should update in ""Product Entry"" form unless data can be mismatched in ""Cipher Barcode"" generation."
			Me.Label16.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.TableLayoutPanel2.CellBorderStyle = Global.System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
			Me.TableLayoutPanel2.ColumnCount = 2
			Me.TableLayoutPanel2.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 60.97561F))
			Me.TableLayoutPanel2.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 39.02439F))
			Me.TableLayoutPanel2.Controls.Add(Me.TextBox11, 1, 0)
			Me.TableLayoutPanel2.Controls.Add(Me.TextBox12, 1, 1)
			Me.TableLayoutPanel2.Controls.Add(Me.Label14, 0, 0)
			Me.TableLayoutPanel2.Controls.Add(Me.Label15, 0, 1)
			Me.TableLayoutPanel2.Location = New Global.System.Drawing.Point(228, 42)
			Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
			Me.TableLayoutPanel2.RowCount = 2
			Me.TableLayoutPanel2.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Absolute, 27F))
			Me.TableLayoutPanel2.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Absolute, 23F))
			Me.TableLayoutPanel2.Size = New Global.System.Drawing.Size(165, 56)
			Me.TableLayoutPanel2.TabIndex = 2
			Me.TextBox11.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.TextBox11.Location = New Global.System.Drawing.Point(103, 4)
			Me.TextBox11.Name = "TextBox11"
			Me.TextBox11.Size = New Global.System.Drawing.Size(58, 20)
			Me.TextBox11.TabIndex = 4
			Me.TextBox11.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox12.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.TextBox12.Location = New Global.System.Drawing.Point(103, 32)
			Me.TextBox12.Name = "TextBox12"
			Me.TextBox12.Size = New Global.System.Drawing.Size(58, 20)
			Me.TextBox12.TabIndex = 5
			Me.TextBox12.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label14.AutoSize = True
			Me.Label14.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Label14.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label14.ForeColor = Global.System.Drawing.Color.White
			Me.Label14.Location = New Global.System.Drawing.Point(4, 1)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(92, 27)
			Me.Label14.TabIndex = 2
			Me.Label14.Text = "1 st Dummy No. :"
			Me.Label14.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Label15.AutoSize = True
			Me.Label15.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Label15.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label15.ForeColor = Global.System.Drawing.Color.White
			Me.Label15.Location = New Global.System.Drawing.Point(4, 29)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(92, 26)
			Me.Label15.TabIndex = 3
			Me.Label15.Text = "2 nd Dummy No. :"
			Me.Label15.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GroupBox2.Controls.Add(Me.GelButton1)
			Me.GroupBox2.Controls.Add(Me.GelButton3)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(229, 281)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(164, 60)
			Me.GroupBox2.TabIndex = 4
			Me.GroupBox2.TabStop = False
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
			Me.GelButton1.Location = New Global.System.Drawing.Point(86, 14)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(72, 37)
			Me.GelButton1.TabIndex = 525
			Me.GelButton1.Text = "&Save"
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
			Me.GelButton3.Location = New Global.System.Drawing.Point(6, 14)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(74, 37)
			Me.GelButton3.TabIndex = 526
			Me.GelButton3.Text = "&Reset"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.TableLayoutPanel1.CellBorderStyle = Global.System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
			Me.TableLayoutPanel1.ColumnCount = 2
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 50F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 50F))
			Me.TableLayoutPanel1.Controls.Add(Me.Label13, 0, 10)
			Me.TableLayoutPanel1.Controls.Add(Me.Label12, 0, 9)
			Me.TableLayoutPanel1.Controls.Add(Me.Label11, 0, 8)
			Me.TableLayoutPanel1.Controls.Add(Me.Label10, 0, 7)
			Me.TableLayoutPanel1.Controls.Add(Me.Label9, 0, 6)
			Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 5)
			Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 4)
			Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 3)
			Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 2)
			Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 1)
			Me.TableLayoutPanel1.Controls.Add(Me.TextBox1, 1, 1)
			Me.TableLayoutPanel1.Controls.Add(Me.Label3, 1, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.TextBox2, 1, 2)
			Me.TableLayoutPanel1.Controls.Add(Me.TextBox3, 1, 3)
			Me.TableLayoutPanel1.Controls.Add(Me.TextBox4, 1, 4)
			Me.TableLayoutPanel1.Controls.Add(Me.TextBox5, 1, 5)
			Me.TableLayoutPanel1.Controls.Add(Me.TextBox6, 1, 6)
			Me.TableLayoutPanel1.Controls.Add(Me.TextBox7, 1, 7)
			Me.TableLayoutPanel1.Controls.Add(Me.TextBox8, 1, 8)
			Me.TableLayoutPanel1.Controls.Add(Me.TextBox9, 1, 9)
			Me.TableLayoutPanel1.Controls.Add(Me.TextBox10, 1, 10)
			Me.TableLayoutPanel1.Location = New Global.System.Drawing.Point(5, 42)
			Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
			Me.TableLayoutPanel1.RowCount = 11
			Me.TableLayoutPanel1.RowStyles.Add(New Global.System.Windows.Forms.RowStyle())
			Me.TableLayoutPanel1.RowStyles.Add(New Global.System.Windows.Forms.RowStyle())
			Me.TableLayoutPanel1.RowStyles.Add(New Global.System.Windows.Forms.RowStyle())
			Me.TableLayoutPanel1.RowStyles.Add(New Global.System.Windows.Forms.RowStyle())
			Me.TableLayoutPanel1.RowStyles.Add(New Global.System.Windows.Forms.RowStyle())
			Me.TableLayoutPanel1.RowStyles.Add(New Global.System.Windows.Forms.RowStyle())
			Me.TableLayoutPanel1.RowStyles.Add(New Global.System.Windows.Forms.RowStyle())
			Me.TableLayoutPanel1.RowStyles.Add(New Global.System.Windows.Forms.RowStyle())
			Me.TableLayoutPanel1.RowStyles.Add(New Global.System.Windows.Forms.RowStyle())
			Me.TableLayoutPanel1.RowStyles.Add(New Global.System.Windows.Forms.RowStyle())
			Me.TableLayoutPanel1.RowStyles.Add(New Global.System.Windows.Forms.RowStyle())
			Me.TableLayoutPanel1.Size = New Global.System.Drawing.Size(218, 299)
			Me.TableLayoutPanel1.TabIndex = 1
			Me.Label13.AutoSize = True
			Me.Label13.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label13.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label13.Location = New Global.System.Drawing.Point(4, 270)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(101, 28)
			Me.Label13.TabIndex = 21
			Me.Label13.Text = "9"
			Me.Label13.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label12.AutoSize = True
			Me.Label12.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label12.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label12.Location = New Global.System.Drawing.Point(4, 242)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(101, 27)
			Me.Label12.TabIndex = 20
			Me.Label12.Text = "8"
			Me.Label12.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label11.AutoSize = True
			Me.Label11.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label11.Location = New Global.System.Drawing.Point(4, 214)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(101, 27)
			Me.Label11.TabIndex = 19
			Me.Label11.Text = "7"
			Me.Label11.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label10.AutoSize = True
			Me.Label10.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label10.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label10.Location = New Global.System.Drawing.Point(4, 186)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(101, 27)
			Me.Label10.TabIndex = 18
			Me.Label10.Text = "6"
			Me.Label10.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label9.AutoSize = True
			Me.Label9.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label9.Location = New Global.System.Drawing.Point(4, 158)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(101, 27)
			Me.Label9.TabIndex = 17
			Me.Label9.Text = "5"
			Me.Label9.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label8.AutoSize = True
			Me.Label8.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label8.Location = New Global.System.Drawing.Point(4, 130)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(101, 27)
			Me.Label8.TabIndex = 16
			Me.Label8.Text = "4"
			Me.Label8.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label7.AutoSize = True
			Me.Label7.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label7.Location = New Global.System.Drawing.Point(4, 102)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(101, 27)
			Me.Label7.TabIndex = 15
			Me.Label7.Text = "3"
			Me.Label7.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label6.AutoSize = True
			Me.Label6.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label6.Location = New Global.System.Drawing.Point(4, 74)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(101, 27)
			Me.Label6.TabIndex = 14
			Me.Label6.Text = "2"
			Me.Label6.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label5.AutoSize = True
			Me.Label5.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.Location = New Global.System.Drawing.Point(4, 46)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(101, 27)
			Me.Label5.TabIndex = 13
			Me.Label5.Text = "1"
			Me.Label5.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label4.AutoSize = True
			Me.Label4.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.Location = New Global.System.Drawing.Point(4, 18)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(101, 27)
			Me.Label4.TabIndex = 2
			Me.Label4.Text = "0"
			Me.Label4.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.TextBox1.CharacterCasing = Global.System.Windows.Forms.CharacterCasing.Upper
			Me.TextBox1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(112, 21)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(102, 21)
			Me.TextBox1.TabIndex = 2
			Me.TextBox1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label3.AutoSize = True
			Me.Label3.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Label3.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.ForeColor = Global.System.Drawing.Color.White
			Me.Label3.Location = New Global.System.Drawing.Point(112, 1)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(102, 16)
			Me.Label3.TabIndex = 3
			Me.Label3.Text = "Code"
			Me.Label3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label2.AutoSize = True
			Me.Label2.BackColor = Global.System.Drawing.Color.Yellow
			Me.Label2.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.Location = New Global.System.Drawing.Point(4, 1)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(101, 16)
			Me.Label2.TabIndex = 2
			Me.Label2.Text = "Serial Number"
			Me.Label2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.TextBox2.CharacterCasing = Global.System.Windows.Forms.CharacterCasing.Upper
			Me.TextBox2.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.TextBox2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox2.Location = New Global.System.Drawing.Point(112, 49)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(102, 21)
			Me.TextBox2.TabIndex = 4
			Me.TextBox2.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox3.CharacterCasing = Global.System.Windows.Forms.CharacterCasing.Upper
			Me.TextBox3.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.TextBox3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox3.Location = New Global.System.Drawing.Point(112, 77)
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.Size = New Global.System.Drawing.Size(102, 21)
			Me.TextBox3.TabIndex = 5
			Me.TextBox3.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox4.CharacterCasing = Global.System.Windows.Forms.CharacterCasing.Upper
			Me.TextBox4.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.TextBox4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox4.Location = New Global.System.Drawing.Point(112, 105)
			Me.TextBox4.Name = "TextBox4"
			Me.TextBox4.Size = New Global.System.Drawing.Size(102, 21)
			Me.TextBox4.TabIndex = 6
			Me.TextBox4.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox5.CharacterCasing = Global.System.Windows.Forms.CharacterCasing.Upper
			Me.TextBox5.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.TextBox5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox5.Location = New Global.System.Drawing.Point(112, 133)
			Me.TextBox5.Name = "TextBox5"
			Me.TextBox5.Size = New Global.System.Drawing.Size(102, 21)
			Me.TextBox5.TabIndex = 7
			Me.TextBox5.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox6.CharacterCasing = Global.System.Windows.Forms.CharacterCasing.Upper
			Me.TextBox6.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.TextBox6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox6.Location = New Global.System.Drawing.Point(112, 161)
			Me.TextBox6.Name = "TextBox6"
			Me.TextBox6.Size = New Global.System.Drawing.Size(102, 21)
			Me.TextBox6.TabIndex = 8
			Me.TextBox6.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox7.CharacterCasing = Global.System.Windows.Forms.CharacterCasing.Upper
			Me.TextBox7.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.TextBox7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox7.Location = New Global.System.Drawing.Point(112, 189)
			Me.TextBox7.Name = "TextBox7"
			Me.TextBox7.Size = New Global.System.Drawing.Size(102, 21)
			Me.TextBox7.TabIndex = 9
			Me.TextBox7.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox8.CharacterCasing = Global.System.Windows.Forms.CharacterCasing.Upper
			Me.TextBox8.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.TextBox8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox8.Location = New Global.System.Drawing.Point(112, 217)
			Me.TextBox8.Name = "TextBox8"
			Me.TextBox8.Size = New Global.System.Drawing.Size(102, 21)
			Me.TextBox8.TabIndex = 10
			Me.TextBox8.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox9.CharacterCasing = Global.System.Windows.Forms.CharacterCasing.Upper
			Me.TextBox9.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.TextBox9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox9.Location = New Global.System.Drawing.Point(112, 245)
			Me.TextBox9.Name = "TextBox9"
			Me.TextBox9.Size = New Global.System.Drawing.Size(102, 21)
			Me.TextBox9.TabIndex = 11
			Me.TextBox9.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox10.CharacterCasing = Global.System.Windows.Forms.CharacterCasing.Upper
			Me.TextBox10.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.TextBox10.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox10.Location = New Global.System.Drawing.Point(112, 273)
			Me.TextBox10.Name = "TextBox10"
			Me.TextBox10.Size = New Global.System.Drawing.Size(102, 21)
			Me.TextBox10.TabIndex = 12
			Me.TextBox10.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(411, 31)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Cipher Code Setting"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.txtID.Location = New Global.System.Drawing.Point(236, 306)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(31, 20)
			Me.txtID.TabIndex = 11
			Me.txtID.TabStop = False
			Me.txtID.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(411, 359)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmCipherSetting"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.TableLayoutPanel3.ResumeLayout(False)
			Me.TableLayoutPanel3.PerformLayout()
			Me.TableLayoutPanel2.ResumeLayout(False)
			Me.TableLayoutPanel2.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.TableLayoutPanel1.ResumeLayout(False)
			Me.TableLayoutPanel1.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04005BBE RID: 23486
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
