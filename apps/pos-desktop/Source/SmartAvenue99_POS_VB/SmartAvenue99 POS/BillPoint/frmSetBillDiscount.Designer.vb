Namespace BillPoint
	' Token: 0x020004DB RID: 1243
		Public Partial Class frmSetBillDiscount
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600FD20 RID: 64800 RVA: 0x00976398 File Offset: 0x00974598
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

		' Token: 0x0600FD21 RID: 64801 RVA: 0x009763E8 File Offset: 0x009745E8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmSetBillDiscount))
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.txtDiscount = New Global.System.Windows.Forms.TextBox()
			Me.btnOkay = New Global.System.Windows.Forms.Button()
			Me.TableLayoutPanel3 = New Global.System.Windows.Forms.TableLayoutPanel()
			Me.btnTAx = New Global.System.Windows.Forms.Button()
			Me.btnTA0 = New Global.System.Windows.Forms.Button()
			Me.btnTAComma = New Global.System.Windows.Forms.Button()
			Me.btnTA9 = New Global.System.Windows.Forms.Button()
			Me.btnTA8 = New Global.System.Windows.Forms.Button()
			Me.btnTA4 = New Global.System.Windows.Forms.Button()
			Me.btnTA6 = New Global.System.Windows.Forms.Button()
			Me.btnTA5 = New Global.System.Windows.Forms.Button()
			Me.btnTA7 = New Global.System.Windows.Forms.Button()
			Me.btnTA3 = New Global.System.Windows.Forms.Button()
			Me.btnTA1 = New Global.System.Windows.Forms.Button()
			Me.btnTA2 = New Global.System.Windows.Forms.Button()
			Me.btnClear = New Global.System.Windows.Forms.Button()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.RadioButton1 = New Global.System.Windows.Forms.RadioButton()
			Me.RadioButton2 = New Global.System.Windows.Forms.RadioButton()
			Me.RadioButton3 = New Global.System.Windows.Forms.RadioButton()
			Me.RadioButton4 = New Global.System.Windows.Forms.RadioButton()
			Me.RadioButton5 = New Global.System.Windows.Forms.RadioButton()
			Me.TableLayoutPanel3.SuspendLayout()
			Me.Panel1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.Yellow
			Me.Label1.Image = CType(componentResourceManager.GetObject("Label1.Image"), Global.System.Drawing.Image)
			Me.Label1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Label1.Location = New Global.System.Drawing.Point(24, 8)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(201, 30)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Enter the Value :"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.txtDiscount.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 18F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtDiscount.Location = New Global.System.Drawing.Point(6, 5)
			Me.txtDiscount.Name = "txtDiscount"
			Me.txtDiscount.Size = New Global.System.Drawing.Size(154, 35)
			Me.txtDiscount.TabIndex = 0
			Me.txtDiscount.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.btnOkay.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.btnOkay.BackgroundImage = CType(componentResourceManager.GetObject("btnOkay.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnOkay.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnOkay.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnOkay.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnOkay.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnOkay.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.btnOkay.Image = CType(componentResourceManager.GetObject("btnOkay.Image"), Global.System.Drawing.Image)
			Me.btnOkay.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnOkay.Location = New Global.System.Drawing.Point(163, 5)
			Me.btnOkay.Name = "btnOkay"
			Me.btnOkay.Size = New Global.System.Drawing.Size(83, 35)
			Me.btnOkay.TabIndex = 1
			Me.btnOkay.Text = "&Okay"
			Me.btnOkay.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnOkay.UseVisualStyleBackColor = False
			Me.TableLayoutPanel3.ColumnCount = 3
			Me.TableLayoutPanel3.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 33.33333F))
			Me.TableLayoutPanel3.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 33.33333F))
			Me.TableLayoutPanel3.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 33.33333F))
			Me.TableLayoutPanel3.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Absolute, 20F))
			Me.TableLayoutPanel3.Controls.Add(Me.btnTAx, 2, 3)
			Me.TableLayoutPanel3.Controls.Add(Me.btnTA0, 1, 3)
			Me.TableLayoutPanel3.Controls.Add(Me.btnTAComma, 0, 3)
			Me.TableLayoutPanel3.Controls.Add(Me.btnTA9, 2, 2)
			Me.TableLayoutPanel3.Controls.Add(Me.btnTA8, 1, 2)
			Me.TableLayoutPanel3.Controls.Add(Me.btnTA4, 0, 1)
			Me.TableLayoutPanel3.Controls.Add(Me.btnTA6, 2, 1)
			Me.TableLayoutPanel3.Controls.Add(Me.btnTA5, 1, 1)
			Me.TableLayoutPanel3.Controls.Add(Me.btnTA7, 0, 2)
			Me.TableLayoutPanel3.Controls.Add(Me.btnTA3, 2, 0)
			Me.TableLayoutPanel3.Controls.Add(Me.btnTA1, 0, 0)
			Me.TableLayoutPanel3.Controls.Add(Me.btnTA2, 1, 0)
			Me.TableLayoutPanel3.Location = New Global.System.Drawing.Point(3, 42)
			Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
			Me.TableLayoutPanel3.RowCount = 4
			Me.TableLayoutPanel3.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 25F))
			Me.TableLayoutPanel3.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 25F))
			Me.TableLayoutPanel3.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 25F))
			Me.TableLayoutPanel3.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 25F))
			Me.TableLayoutPanel3.Size = New Global.System.Drawing.Size(292, 218)
			Me.TableLayoutPanel3.TabIndex = 384
			Me.btnTAx.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.btnTAx.BackgroundImage = CType(componentResourceManager.GetObject("btnTAx.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnTAx.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnTAx.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnTAx.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.btnTAx.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnTAx.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnTAx.ForeColor = Global.System.Drawing.Color.White
			Me.btnTAx.Image = CType(componentResourceManager.GetObject("btnTAx.Image"), Global.System.Drawing.Image)
			Me.btnTAx.Location = New Global.System.Drawing.Point(197, 165)
			Me.btnTAx.Name = "btnTAx"
			Me.btnTAx.Size = New Global.System.Drawing.Size(92, 50)
			Me.btnTAx.TabIndex = 18
			Me.btnTAx.UseVisualStyleBackColor = False
			Me.btnTA0.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.btnTA0.BackgroundImage = CType(componentResourceManager.GetObject("btnTA0.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnTA0.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnTA0.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnTA0.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.btnTA0.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnTA0.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnTA0.ForeColor = Global.System.Drawing.Color.White
			Me.btnTA0.Image = CType(componentResourceManager.GetObject("btnTA0.Image"), Global.System.Drawing.Image)
			Me.btnTA0.Location = New Global.System.Drawing.Point(100, 165)
			Me.btnTA0.Name = "btnTA0"
			Me.btnTA0.Size = New Global.System.Drawing.Size(91, 50)
			Me.btnTA0.TabIndex = 17
			Me.btnTA0.UseVisualStyleBackColor = False
			Me.btnTAComma.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.btnTAComma.BackgroundImage = CType(componentResourceManager.GetObject("btnTAComma.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnTAComma.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnTAComma.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnTAComma.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.btnTAComma.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnTAComma.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnTAComma.ForeColor = Global.System.Drawing.Color.White
			Me.btnTAComma.Image = CType(componentResourceManager.GetObject("btnTAComma.Image"), Global.System.Drawing.Image)
			Me.btnTAComma.Location = New Global.System.Drawing.Point(3, 165)
			Me.btnTAComma.Name = "btnTAComma"
			Me.btnTAComma.Size = New Global.System.Drawing.Size(91, 50)
			Me.btnTAComma.TabIndex = 16
			Me.btnTAComma.Text = "."
			Me.btnTAComma.UseVisualStyleBackColor = False
			Me.btnTA9.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.btnTA9.BackgroundImage = CType(componentResourceManager.GetObject("btnTA9.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnTA9.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnTA9.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnTA9.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.btnTA9.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnTA9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnTA9.ForeColor = Global.System.Drawing.Color.White
			Me.btnTA9.Image = CType(componentResourceManager.GetObject("btnTA9.Image"), Global.System.Drawing.Image)
			Me.btnTA9.Location = New Global.System.Drawing.Point(197, 111)
			Me.btnTA9.Name = "btnTA9"
			Me.btnTA9.Size = New Global.System.Drawing.Size(92, 48)
			Me.btnTA9.TabIndex = 15
			Me.btnTA9.UseVisualStyleBackColor = False
			Me.btnTA8.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.btnTA8.BackgroundImage = CType(componentResourceManager.GetObject("btnTA8.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnTA8.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnTA8.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnTA8.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.btnTA8.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnTA8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnTA8.ForeColor = Global.System.Drawing.Color.White
			Me.btnTA8.Image = CType(componentResourceManager.GetObject("btnTA8.Image"), Global.System.Drawing.Image)
			Me.btnTA8.Location = New Global.System.Drawing.Point(100, 111)
			Me.btnTA8.Name = "btnTA8"
			Me.btnTA8.Size = New Global.System.Drawing.Size(91, 48)
			Me.btnTA8.TabIndex = 14
			Me.btnTA8.UseVisualStyleBackColor = False
			Me.btnTA4.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.btnTA4.BackgroundImage = CType(componentResourceManager.GetObject("btnTA4.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnTA4.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnTA4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnTA4.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.btnTA4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnTA4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnTA4.ForeColor = Global.System.Drawing.Color.White
			Me.btnTA4.Image = CType(componentResourceManager.GetObject("btnTA4.Image"), Global.System.Drawing.Image)
			Me.btnTA4.Location = New Global.System.Drawing.Point(3, 57)
			Me.btnTA4.Name = "btnTA4"
			Me.btnTA4.Size = New Global.System.Drawing.Size(91, 48)
			Me.btnTA4.TabIndex = 30
			Me.btnTA4.UseVisualStyleBackColor = False
			Me.btnTA6.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.btnTA6.BackgroundImage = CType(componentResourceManager.GetObject("btnTA6.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnTA6.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnTA6.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnTA6.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.btnTA6.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnTA6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnTA6.ForeColor = Global.System.Drawing.Color.White
			Me.btnTA6.Image = CType(componentResourceManager.GetObject("btnTA6.Image"), Global.System.Drawing.Image)
			Me.btnTA6.Location = New Global.System.Drawing.Point(197, 57)
			Me.btnTA6.Name = "btnTA6"
			Me.btnTA6.Size = New Global.System.Drawing.Size(92, 48)
			Me.btnTA6.TabIndex = 12
			Me.btnTA6.UseVisualStyleBackColor = False
			Me.btnTA5.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.btnTA5.BackgroundImage = CType(componentResourceManager.GetObject("btnTA5.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnTA5.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnTA5.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnTA5.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.btnTA5.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnTA5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnTA5.ForeColor = Global.System.Drawing.Color.White
			Me.btnTA5.Image = CType(componentResourceManager.GetObject("btnTA5.Image"), Global.System.Drawing.Image)
			Me.btnTA5.Location = New Global.System.Drawing.Point(100, 57)
			Me.btnTA5.Name = "btnTA5"
			Me.btnTA5.Size = New Global.System.Drawing.Size(91, 48)
			Me.btnTA5.TabIndex = 11
			Me.btnTA5.UseVisualStyleBackColor = False
			Me.btnTA7.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.btnTA7.BackgroundImage = CType(componentResourceManager.GetObject("btnTA7.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnTA7.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnTA7.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnTA7.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.btnTA7.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnTA7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnTA7.ForeColor = Global.System.Drawing.Color.White
			Me.btnTA7.Image = CType(componentResourceManager.GetObject("btnTA7.Image"), Global.System.Drawing.Image)
			Me.btnTA7.Location = New Global.System.Drawing.Point(3, 111)
			Me.btnTA7.Name = "btnTA7"
			Me.btnTA7.Size = New Global.System.Drawing.Size(91, 48)
			Me.btnTA7.TabIndex = 13
			Me.btnTA7.UseVisualStyleBackColor = False
			Me.btnTA3.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.btnTA3.BackgroundImage = CType(componentResourceManager.GetObject("btnTA3.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnTA3.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnTA3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnTA3.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.btnTA3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnTA3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnTA3.ForeColor = Global.System.Drawing.Color.White
			Me.btnTA3.Image = CType(componentResourceManager.GetObject("btnTA3.Image"), Global.System.Drawing.Image)
			Me.btnTA3.Location = New Global.System.Drawing.Point(197, 3)
			Me.btnTA3.Name = "btnTA3"
			Me.btnTA3.Size = New Global.System.Drawing.Size(92, 48)
			Me.btnTA3.TabIndex = 9
			Me.btnTA3.UseVisualStyleBackColor = False
			Me.btnTA1.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.btnTA1.BackgroundImage = CType(componentResourceManager.GetObject("btnTA1.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnTA1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnTA1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnTA1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.btnTA1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnTA1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnTA1.ForeColor = Global.System.Drawing.Color.White
			Me.btnTA1.Image = CType(componentResourceManager.GetObject("btnTA1.Image"), Global.System.Drawing.Image)
			Me.btnTA1.Location = New Global.System.Drawing.Point(3, 3)
			Me.btnTA1.Name = "btnTA1"
			Me.btnTA1.Size = New Global.System.Drawing.Size(91, 48)
			Me.btnTA1.TabIndex = 7
			Me.btnTA1.UseVisualStyleBackColor = False
			Me.btnTA2.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.btnTA2.BackgroundImage = CType(componentResourceManager.GetObject("btnTA2.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnTA2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnTA2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnTA2.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.btnTA2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnTA2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnTA2.ForeColor = Global.System.Drawing.Color.White
			Me.btnTA2.Image = CType(componentResourceManager.GetObject("btnTA2.Image"), Global.System.Drawing.Image)
			Me.btnTA2.Location = New Global.System.Drawing.Point(100, 3)
			Me.btnTA2.Name = "btnTA2"
			Me.btnTA2.Size = New Global.System.Drawing.Size(91, 48)
			Me.btnTA2.TabIndex = 8
			Me.btnTA2.UseVisualStyleBackColor = False
			Me.btnClear.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.btnClear.BackgroundImage = CType(componentResourceManager.GetObject("btnClear.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnClear.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnClear.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnClear.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnClear.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnClear.ForeColor = Global.System.Drawing.Color.White
			Me.btnClear.Image = CType(componentResourceManager.GetObject("btnClear.Image"), Global.System.Drawing.Image)
			Me.btnClear.Location = New Global.System.Drawing.Point(250, 5)
			Me.btnClear.Name = "btnClear"
			Me.btnClear.Size = New Global.System.Drawing.Size(42, 35)
			Me.btnClear.TabIndex = 385
			Me.btnClear.UseVisualStyleBackColor = False
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.txtDiscount)
			Me.Panel1.Controls.Add(Me.TableLayoutPanel3)
			Me.Panel1.Controls.Add(Me.btnClear)
			Me.Panel1.Controls.Add(Me.btnOkay)
			Me.Panel1.Location = New Global.System.Drawing.Point(224, 3)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(300, 265)
			Me.Panel1.TabIndex = 388
			Me.RadioButton1.AutoSize = True
			Me.RadioButton1.BackgroundImage = CType(componentResourceManager.GetObject("RadioButton1.BackgroundImage"), Global.System.Drawing.Image)
			Me.RadioButton1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.RadioButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 18F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.RadioButton1.ForeColor = Global.System.Drawing.Color.White
			Me.RadioButton1.Location = New Global.System.Drawing.Point(6, 134)
			Me.RadioButton1.Name = "RadioButton1"
			Me.RadioButton1.Size = New Global.System.Drawing.Size(185, 36)
			Me.RadioButton1.TabIndex = 386
			Me.RadioButton1.Text = "Item Discount"
			Me.RadioButton1.UseVisualStyleBackColor = True
			Me.RadioButton2.AutoSize = True
			Me.RadioButton2.BackgroundImage = CType(componentResourceManager.GetObject("RadioButton2.BackgroundImage"), Global.System.Drawing.Image)
			Me.RadioButton2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.RadioButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 18F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.RadioButton2.ForeColor = Global.System.Drawing.Color.White
			Me.RadioButton2.Location = New Global.System.Drawing.Point(6, 96)
			Me.RadioButton2.Name = "RadioButton2"
			Me.RadioButton2.Size = New Global.System.Drawing.Size(143, 36)
			Me.RadioButton2.TabIndex = 408
			Me.RadioButton2.Text = "Item Price"
			Me.RadioButton2.UseVisualStyleBackColor = True
			Me.RadioButton3.AutoSize = True
			Me.RadioButton3.BackgroundImage = CType(componentResourceManager.GetObject("RadioButton3.BackgroundImage"), Global.System.Drawing.Image)
			Me.RadioButton3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.RadioButton3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 18F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.RadioButton3.ForeColor = Global.System.Drawing.Color.White
			Me.RadioButton3.Location = New Global.System.Drawing.Point(6, 58)
			Me.RadioButton3.Name = "RadioButton3"
			Me.RadioButton3.Size = New Global.System.Drawing.Size(185, 36)
			Me.RadioButton3.TabIndex = 409
			Me.RadioButton3.Text = "Item Quantity"
			Me.RadioButton3.UseVisualStyleBackColor = True
			Me.RadioButton4.AutoSize = True
			Me.RadioButton4.BackgroundImage = CType(componentResourceManager.GetObject("RadioButton4.BackgroundImage"), Global.System.Drawing.Image)
			Me.RadioButton4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.RadioButton4.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 18F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.RadioButton4.ForeColor = Global.System.Drawing.Color.White
			Me.RadioButton4.Location = New Global.System.Drawing.Point(6, 172)
			Me.RadioButton4.Name = "RadioButton4"
			Me.RadioButton4.Size = New Global.System.Drawing.Size(168, 36)
			Me.RadioButton4.TabIndex = 410
			Me.RadioButton4.Text = "Bill Discount"
			Me.RadioButton4.UseVisualStyleBackColor = True
			Me.RadioButton5.AutoSize = True
			Me.RadioButton5.BackgroundImage = CType(componentResourceManager.GetObject("RadioButton5.BackgroundImage"), Global.System.Drawing.Image)
			Me.RadioButton5.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.RadioButton5.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 18F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.RadioButton5.ForeColor = Global.System.Drawing.Color.White
			Me.RadioButton5.Location = New Global.System.Drawing.Point(6, 210)
			Me.RadioButton5.Name = "RadioButton5"
			Me.RadioButton5.Size = New Global.System.Drawing.Size(213, 36)
			Me.RadioButton5.TabIndex = 411
			Me.RadioButton5.Text = "Loyalty Discount"
			Me.RadioButton5.UseVisualStyleBackColor = True
			MyBase.AcceptButton = Me.btnOkay
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.BackgroundImage = Global.BillPoint.My.Resources.Resources.UpdateOrange
			Me.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			MyBase.ClientSize = New Global.System.Drawing.Size(527, 271)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.RadioButton5)
			MyBase.Controls.Add(Me.RadioButton4)
			MyBase.Controls.Add(Me.RadioButton3)
			MyBase.Controls.Add(Me.RadioButton2)
			MyBase.Controls.Add(Me.RadioButton1)
			Me.DoubleBuffered = True
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmSetBillDiscount"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.TableLayoutPanel3.ResumeLayout(False)
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040060E9 RID: 24809
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
