Namespace BillPoint
	' Token: 0x020001AD RID: 429
		Public Partial Class frmPostImport
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06006530 RID: 25904 RVA: 0x00499300 File Offset: 0x00497500
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

		' Token: 0x06006531 RID: 25905 RVA: 0x00499350 File Offset: 0x00497550
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmPostImport))
			Me.Panel7 = New Global.System.Windows.Forms.Panel()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Button17 = New Global.GelButtons.GelButton()
			Me.btnCategory = New Global.GelButtons.GelButton()
			Me.btnSupplierOs = New Global.GelButtons.GelButton()
			Me.btnProduct = New Global.GelButtons.GelButton()
			Me.btnSubCat = New Global.GelButtons.GelButton()
			Me.btnSupplier = New Global.GelButtons.GelButton()
			Me.btnCustomers = New Global.GelButtons.GelButton()
			Me.btnCustomerOs = New Global.GelButtons.GelButton()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Panel7.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel7.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel7.BackColor = Global.System.Drawing.Color.White
			Me.Panel7.Controls.Add(Me.lblUser)
			Me.Panel7.Controls.Add(Me.Button17)
			Me.Panel7.Controls.Add(Me.btnCategory)
			Me.Panel7.Controls.Add(Me.btnSupplierOs)
			Me.Panel7.Controls.Add(Me.btnProduct)
			Me.Panel7.Controls.Add(Me.btnSubCat)
			Me.Panel7.Controls.Add(Me.btnSupplier)
			Me.Panel7.Controls.Add(Me.btnCustomers)
			Me.Panel7.Controls.Add(Me.btnCustomerOs)
			Me.Panel7.Location = New Global.System.Drawing.Point(30, 40)
			Me.Panel7.Name = "Panel7"
			Me.Panel7.Size = New Global.System.Drawing.Size(248, 464)
			Me.Panel7.TabIndex = 506
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(46, 438)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 522
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.Button17.Anchor = Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button17.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button17.FlatAppearance.BorderSize = 0
			Me.Button17.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button17.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button17.ForeColor = Global.System.Drawing.Color.White
			Me.Button17.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.Button17.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.Button17.Image = CType(componentResourceManager.GetObject("Button17.Image"), Global.System.Drawing.Image)
			Me.Button17.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button17.Location = New Global.System.Drawing.Point(14, 384)
			Me.Button17.Name = "Button17"
			Me.Button17.Size = New Global.System.Drawing.Size(222, 47)
			Me.Button17.TabIndex = 521
			Me.Button17.Text = "Product Stock"
			Me.Button17.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button17.UseVisualStyleBackColor = False
			Me.btnCategory.Anchor = Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnCategory.BackColor = Global.System.Drawing.SystemColors.MenuBar
			Me.btnCategory.FlatAppearance.BorderSize = 0
			Me.btnCategory.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnCategory.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnCategory.ForeColor = Global.System.Drawing.Color.White
			Me.btnCategory.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnCategory.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnCategory.Image = CType(componentResourceManager.GetObject("btnCategory.Image"), Global.System.Drawing.Image)
			Me.btnCategory.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnCategory.Location = New Global.System.Drawing.Point(14, 6)
			Me.btnCategory.Name = "btnCategory"
			Me.btnCategory.Size = New Global.System.Drawing.Size(222, 47)
			Me.btnCategory.TabIndex = 514
			Me.btnCategory.Text = "Category"
			Me.btnCategory.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnCategory.UseVisualStyleBackColor = False
			Me.btnSupplierOs.Anchor = Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnSupplierOs.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnSupplierOs.FlatAppearance.BorderSize = 0
			Me.btnSupplierOs.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSupplierOs.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSupplierOs.ForeColor = Global.System.Drawing.Color.White
			Me.btnSupplierOs.GradientBottom = Global.System.Drawing.Color.Red
			Me.btnSupplierOs.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnSupplierOs.Image = CType(componentResourceManager.GetObject("btnSupplierOs.Image"), Global.System.Drawing.Image)
			Me.btnSupplierOs.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSupplierOs.Location = New Global.System.Drawing.Point(14, 265)
			Me.btnSupplierOs.Name = "btnSupplierOs"
			Me.btnSupplierOs.Size = New Global.System.Drawing.Size(222, 47)
			Me.btnSupplierOs.TabIndex = 520
			Me.btnSupplierOs.Text = "Supplier Outstanding "
			Me.btnSupplierOs.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSupplierOs.UseVisualStyleBackColor = False
			Me.btnProduct.Anchor = Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnProduct.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnProduct.FlatAppearance.BorderSize = 0
			Me.btnProduct.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnProduct.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnProduct.ForeColor = Global.System.Drawing.Color.White
			Me.btnProduct.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnProduct.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnProduct.Image = CType(componentResourceManager.GetObject("btnProduct.Image"), Global.System.Drawing.Image)
			Me.btnProduct.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnProduct.Location = New Global.System.Drawing.Point(14, 316)
			Me.btnProduct.Name = "btnProduct"
			Me.btnProduct.Size = New Global.System.Drawing.Size(222, 64)
			Me.btnProduct.TabIndex = 515
			Me.btnProduct.Text = "Product"
			Me.btnProduct.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnProduct.UseVisualStyleBackColor = False
			Me.btnSubCat.Anchor = Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnSubCat.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnSubCat.FlatAppearance.BorderSize = 0
			Me.btnSubCat.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSubCat.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSubCat.ForeColor = Global.System.Drawing.Color.White
			Me.btnSubCat.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnSubCat.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnSubCat.Image = CType(componentResourceManager.GetObject("btnSubCat.Image"), Global.System.Drawing.Image)
			Me.btnSubCat.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSubCat.Location = New Global.System.Drawing.Point(14, 57)
			Me.btnSubCat.Name = "btnSubCat"
			Me.btnSubCat.Size = New Global.System.Drawing.Size(222, 47)
			Me.btnSubCat.TabIndex = 516
			Me.btnSubCat.Text = "Sub Category / Brand"
			Me.btnSubCat.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSubCat.UseVisualStyleBackColor = False
			Me.btnSupplier.Anchor = Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnSupplier.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnSupplier.FlatAppearance.BorderSize = 0
			Me.btnSupplier.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSupplier.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSupplier.ForeColor = Global.System.Drawing.Color.White
			Me.btnSupplier.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnSupplier.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnSupplier.Image = CType(componentResourceManager.GetObject("btnSupplier.Image"), Global.System.Drawing.Image)
			Me.btnSupplier.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSupplier.Location = New Global.System.Drawing.Point(14, 213)
			Me.btnSupplier.Name = "btnSupplier"
			Me.btnSupplier.Size = New Global.System.Drawing.Size(222, 47)
			Me.btnSupplier.TabIndex = 519
			Me.btnSupplier.Text = "Supplier"
			Me.btnSupplier.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSupplier.UseVisualStyleBackColor = False
			Me.btnCustomers.Anchor = Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnCustomers.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnCustomers.FlatAppearance.BorderSize = 0
			Me.btnCustomers.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnCustomers.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnCustomers.ForeColor = Global.System.Drawing.Color.White
			Me.btnCustomers.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnCustomers.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnCustomers.Image = CType(componentResourceManager.GetObject("btnCustomers.Image"), Global.System.Drawing.Image)
			Me.btnCustomers.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnCustomers.Location = New Global.System.Drawing.Point(14, 108)
			Me.btnCustomers.Name = "btnCustomers"
			Me.btnCustomers.Size = New Global.System.Drawing.Size(222, 47)
			Me.btnCustomers.TabIndex = 517
			Me.btnCustomers.Text = "Customers"
			Me.btnCustomers.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnCustomers.UseVisualStyleBackColor = False
			Me.btnCustomerOs.Anchor = Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnCustomerOs.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnCustomerOs.FlatAppearance.BorderSize = 0
			Me.btnCustomerOs.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnCustomerOs.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnCustomerOs.ForeColor = Global.System.Drawing.Color.White
			Me.btnCustomerOs.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnCustomerOs.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnCustomerOs.Image = CType(componentResourceManager.GetObject("btnCustomerOs.Image"), Global.System.Drawing.Image)
			Me.btnCustomerOs.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnCustomerOs.Location = New Global.System.Drawing.Point(14, 160)
			Me.btnCustomerOs.Name = "btnCustomerOs"
			Me.btnCustomerOs.Size = New Global.System.Drawing.Size(222, 47)
			Me.btnCustomerOs.TabIndex = 518
			Me.btnCustomerOs.Text = "Customer Outstanding "
			Me.btnCustomerOs.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnCustomerOs.UseVisualStyleBackColor = False
			Me.Label1.AutoSize = True
			Me.Label1.ForeColor = Global.System.Drawing.Color.Red
			Me.Label1.Location = New Global.System.Drawing.Point(2, 9)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(294, 13)
			Me.Label1.TabIndex = 507
			Me.Label1.Text = "This Page only for NextGen OS Staff software updation purpose."
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.SystemColors.ControlLightLight
			MyBase.ClientSize = New Global.System.Drawing.Size(305, 531)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.Panel7)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmPostImport"
			Me.Text = "frmPostImport"
			Me.Panel7.ResumeLayout(False)
			Me.Panel7.PerformLayout()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04002CE8 RID: 11496
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
