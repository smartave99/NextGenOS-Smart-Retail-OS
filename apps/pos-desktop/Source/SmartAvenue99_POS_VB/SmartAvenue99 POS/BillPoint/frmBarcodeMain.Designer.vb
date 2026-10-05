Namespace BillPoint
	' Token: 0x02000017 RID: 23
		Public Partial Class frmBarcodeMain
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060005A3 RID: 1443 RVA: 0x0008F4F4 File Offset: 0x0008D6F4
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

		' Token: 0x060005A4 RID: 1444 RVA: 0x0008F544 File Offset: 0x0008D744
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmBarcodeMain))
			Me.ToolStripCmbFonts = New Global.System.Windows.Forms.ToolStripComboBox()
			Me.ContextMenuStrip1 = New Global.System.Windows.Forms.ContextMenuStrip(Me.components)
			Me.FontFamilyToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.TextSizeToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.BoldToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.ItalicToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.BoldItalicToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.RegularToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.UnderlineToolStripMenuItem1 = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.BoldUnderlineToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.FontSizeToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.ToolStripTextBox1 = New Global.System.Windows.Forms.ToolStripTextBox()
			Me.TextColorToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.AlignmentToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.LeftToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.CenterToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.RightToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.JustifyToolStripMenuItem1 = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.EditTextToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.ToolStripTextBox2 = New Global.System.Windows.Forms.ToolStripTextBox()
			Me.DeleteToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.AllignmentToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.LeftToolStripMenuItem1 = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.RightToolStripMenuItem1 = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.CenterToolStripMenuItem1 = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.JustifyToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.cbxPurInv = New Global.System.Windows.Forms.CheckBox()
			Me.cbxQrBarcode = New Global.System.Windows.Forms.CheckBox()
			Me.cbxColour = New Global.System.Windows.Forms.CheckBox()
			Me.cbxGST = New Global.System.Windows.Forms.CheckBox()
			Me.cbxExp = New Global.System.Windows.Forms.CheckBox()
			Me.cbxSize = New Global.System.Windows.Forms.CheckBox()
			Me.cbxMfg = New Global.System.Windows.Forms.CheckBox()
			Me.cbxWholesalePrice = New Global.System.Windows.Forms.CheckBox()
			Me.cbxBatch = New Global.System.Windows.Forms.CheckBox()
			Me.cbxMRP = New Global.System.Windows.Forms.CheckBox()
			Me.panel1 = New Global.System.Windows.Forms.Panel()
			Me.btnTestPrint = New Global.System.Windows.Forms.Button()
			Me.btnClose = New Global.System.Windows.Forms.Button()
			Me.btnClear = New Global.System.Windows.Forms.Button()
			Me.btnSave = New Global.System.Windows.Forms.Button()
			Me.gbxPosition = New Global.System.Windows.Forms.GroupBox()
			Me.lblY = New Global.System.Windows.Forms.Label()
			Me.lblX = New Global.System.Windows.Forms.Label()
			Me.lblDiamensionY = New Global.System.Windows.Forms.Label()
			Me.lblDiamensionX = New Global.System.Windows.Forms.Label()
			Me.cbxSalePrice = New Global.System.Windows.Forms.CheckBox()
			Me.cbxHSNC = New Global.System.Windows.Forms.CheckBox()
			Me.cbxAvlQty = New Global.System.Windows.Forms.CheckBox()
			Me.cbxNoCopy = New Global.System.Windows.Forms.CheckBox()
			Me.cbxCategory = New Global.System.Windows.Forms.CheckBox()
			Me.cbxBarcode = New Global.System.Windows.Forms.CheckBox()
			Me.cbxPCode = New Global.System.Windows.Forms.CheckBox()
			Me.cbxProductName = New Global.System.Windows.Forms.CheckBox()
			Me.PrintDocument1 = New Global.System.Drawing.Printing.PrintDocument()
			Me.cbxPartNo = New Global.System.Windows.Forms.CheckBox()
			Me.dgvLabels = New Global.System.Windows.Forms.DataGridView()
			Me.PrintPreviewDialog1 = New Global.System.Windows.Forms.PrintPreviewDialog()
			Me.PrintDialog1 = New Global.System.Windows.Forms.PrintDialog()
			Me.pbQrBarCode = New Global.System.Windows.Forms.PictureBox()
			Me.pbQrCode = New Global.System.Windows.Forms.PictureBox()
			Me.gbxOptions = New Global.System.Windows.Forms.GroupBox()
			Me.toolTip = New Global.System.Windows.Forms.ToolTip(Me.components)
			Me.lblMandatory = New Global.System.Windows.Forms.Label()
			Me.ttPanelCheque = New Global.System.Windows.Forms.ToolTip(Me.components)
			Me.pnlCheque = New Global.System.Windows.Forms.Panel()
			Me.lblChequeHeight = New Global.System.Windows.Forms.Label()
			Me.lblChequeWidth = New Global.System.Windows.Forms.Label()
			Me.nudChequeLeafWidth = New Global.System.Windows.Forms.NumericUpDown()
			Me.nudChequeHeight = New Global.System.Windows.Forms.NumericUpDown()
			Me.nudLeft = New Global.System.Windows.Forms.NumericUpDown()
			Me.lblLeft = New Global.System.Windows.Forms.Label()
			Me.nudTop = New Global.System.Windows.Forms.NumericUpDown()
			Me.nudHeight = New Global.System.Windows.Forms.NumericUpDown()
			Me.nudWidth = New Global.System.Windows.Forms.NumericUpDown()
			Me.lnklblSetDefault = New Global.System.Windows.Forms.LinkLabel()
			Me.lblTop = New Global.System.Windows.Forms.Label()
			Me.lblHeight = New Global.System.Windows.Forms.Label()
			Me.lblLayOutName = New Global.System.Windows.Forms.Label()
			Me.gbxAlignMent = New Global.System.Windows.Forms.GroupBox()
			Me.lblWidth = New Global.System.Windows.Forms.Label()
			Me.txtLayoutName = New Global.System.Windows.Forms.TextBox()
			Me.ComboBox3 = New Global.System.Windows.Forms.ComboBox()
			Me.cmbFontSize = New Global.System.Windows.Forms.ComboBox()
			Me.btnUnderline = New Global.System.Windows.Forms.CheckBox()
			Me.btnItalic = New Global.System.Windows.Forms.CheckBox()
			Me.btnColor = New Global.System.Windows.Forms.Button()
			Me.btnBold = New Global.System.Windows.Forms.CheckBox()
			Me.cmbFonts = New Global.System.Windows.Forms.ComboBox()
			Me.btnRevert = New Global.System.Windows.Forms.Button()
			Me.lblHiddenImage = New Global.System.Windows.Forms.Label()
			Me.btnZoom = New Global.System.Windows.Forms.Button()
			Me.btnAddImage = New Global.System.Windows.Forms.Button()
			Me.cmbLayouts = New Global.System.Windows.Forms.ComboBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.lblHidden = New Global.System.Windows.Forms.Label()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.panel2 = New Global.System.Windows.Forms.Panel()
			Me.btnAddLabel = New Global.System.Windows.Forms.Button()
			Me.gbxChequeSize = New Global.System.Windows.Forms.GroupBox()
			Me.btnBgColor_Layout = New Global.System.Windows.Forms.Button()
			Me.lblBg = New Global.System.Windows.Forms.Label()
			Me.rulerCtrlLeft = New Global.Lyquidity.UtilityLibrary.Controls.RulerControl()
			Me.rulerCtrlTop = New Global.Lyquidity.UtilityLibrary.Controls.RulerControl()
			Me.pnlWorkSpace = New Global.System.Windows.Forms.Panel()
			Me.ContextMenuStrip1.SuspendLayout()
			Me.panel1.SuspendLayout()
			Me.gbxPosition.SuspendLayout()
			CType(Me.dgvLabels, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.pbQrBarCode, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.pbQrCode, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.gbxOptions.SuspendLayout()
			CType(Me.nudChequeLeafWidth, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nudChequeHeight, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nudLeft, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nudTop, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nudHeight, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nudWidth, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.gbxAlignMent.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			Me.panel2.SuspendLayout()
			Me.gbxChequeSize.SuspendLayout()
			Me.pnlWorkSpace.SuspendLayout()
			MyBase.SuspendLayout()
			Me.ToolStripCmbFonts.FlatStyle = Global.System.Windows.Forms.FlatStyle.Standard
			Me.ToolStripCmbFonts.Items.AddRange(New Object() { "Select Font" })
			Me.ToolStripCmbFonts.Name = "ToolStripCmbFonts"
			Me.ToolStripCmbFonts.Size = New Global.System.Drawing.Size(121, 23)
			Me.ContextMenuStrip1.Items.AddRange(New Global.System.Windows.Forms.ToolStripItem() { Me.FontFamilyToolStripMenuItem, Me.TextSizeToolStripMenuItem, Me.FontSizeToolStripMenuItem, Me.TextColorToolStripMenuItem, Me.AlignmentToolStripMenuItem, Me.EditTextToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.AllignmentToolStripMenuItem })
			Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
			Me.ContextMenuStrip1.Size = New Global.System.Drawing.Size(137, 180)
			Me.FontFamilyToolStripMenuItem.DropDownItems.AddRange(New Global.System.Windows.Forms.ToolStripItem() { Me.ToolStripCmbFonts })
			Me.FontFamilyToolStripMenuItem.Name = "FontFamilyToolStripMenuItem"
			Me.FontFamilyToolStripMenuItem.Size = New Global.System.Drawing.Size(136, 22)
			Me.FontFamilyToolStripMenuItem.Text = "Font Family"
			Me.TextSizeToolStripMenuItem.DropDownItems.AddRange(New Global.System.Windows.Forms.ToolStripItem() { Me.BoldToolStripMenuItem, Me.ItalicToolStripMenuItem, Me.BoldItalicToolStripMenuItem, Me.RegularToolStripMenuItem, Me.UnderlineToolStripMenuItem1, Me.BoldUnderlineToolStripMenuItem })
			Me.TextSizeToolStripMenuItem.Name = "TextSizeToolStripMenuItem"
			Me.TextSizeToolStripMenuItem.Size = New Global.System.Drawing.Size(136, 22)
			Me.TextSizeToolStripMenuItem.Text = "Font Style"
			Me.BoldToolStripMenuItem.Name = "BoldToolStripMenuItem"
			Me.BoldToolStripMenuItem.Size = New Global.System.Drawing.Size(157, 22)
			Me.BoldToolStripMenuItem.Text = "Bold"
			Me.ItalicToolStripMenuItem.Name = "ItalicToolStripMenuItem"
			Me.ItalicToolStripMenuItem.Size = New Global.System.Drawing.Size(157, 22)
			Me.ItalicToolStripMenuItem.Text = "Italic"
			Me.BoldItalicToolStripMenuItem.Name = "BoldItalicToolStripMenuItem"
			Me.BoldItalicToolStripMenuItem.Size = New Global.System.Drawing.Size(157, 22)
			Me.BoldItalicToolStripMenuItem.Text = "Bold+Italic"
			Me.RegularToolStripMenuItem.Name = "RegularToolStripMenuItem"
			Me.RegularToolStripMenuItem.Size = New Global.System.Drawing.Size(157, 22)
			Me.RegularToolStripMenuItem.Text = "Regular"
			Me.UnderlineToolStripMenuItem1.Name = "UnderlineToolStripMenuItem1"
			Me.UnderlineToolStripMenuItem1.Size = New Global.System.Drawing.Size(157, 22)
			Me.UnderlineToolStripMenuItem1.Text = "Underline"
			Me.BoldUnderlineToolStripMenuItem.Name = "BoldUnderlineToolStripMenuItem"
			Me.BoldUnderlineToolStripMenuItem.Size = New Global.System.Drawing.Size(157, 22)
			Me.BoldUnderlineToolStripMenuItem.Text = "Bold+Underline"
			Me.FontSizeToolStripMenuItem.DropDownItems.AddRange(New Global.System.Windows.Forms.ToolStripItem() { Me.ToolStripTextBox1 })
			Me.FontSizeToolStripMenuItem.Name = "FontSizeToolStripMenuItem"
			Me.FontSizeToolStripMenuItem.Size = New Global.System.Drawing.Size(136, 22)
			Me.FontSizeToolStripMenuItem.Text = "Font Size"
			Me.ToolStripTextBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.ToolStripTextBox1.Font = New Global.System.Drawing.Font("Segoe UI", 9F)
			Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
			Me.ToolStripTextBox1.Size = New Global.System.Drawing.Size(100, 23)
			Me.TextColorToolStripMenuItem.Name = "TextColorToolStripMenuItem"
			Me.TextColorToolStripMenuItem.Size = New Global.System.Drawing.Size(136, 22)
			Me.TextColorToolStripMenuItem.Text = "Text Color"
			Me.AlignmentToolStripMenuItem.DropDownItems.AddRange(New Global.System.Windows.Forms.ToolStripItem() { Me.LeftToolStripMenuItem, Me.CenterToolStripMenuItem, Me.RightToolStripMenuItem, Me.JustifyToolStripMenuItem1 })
			Me.AlignmentToolStripMenuItem.Name = "AlignmentToolStripMenuItem"
			Me.AlignmentToolStripMenuItem.Size = New Global.System.Drawing.Size(136, 22)
			Me.AlignmentToolStripMenuItem.Text = "Alignment"
			Me.LeftToolStripMenuItem.Name = "LeftToolStripMenuItem"
			Me.LeftToolStripMenuItem.Size = New Global.System.Drawing.Size(109, 22)
			Me.LeftToolStripMenuItem.Text = "Left"
			Me.CenterToolStripMenuItem.Name = "CenterToolStripMenuItem"
			Me.CenterToolStripMenuItem.Size = New Global.System.Drawing.Size(109, 22)
			Me.CenterToolStripMenuItem.Text = "Center"
			Me.RightToolStripMenuItem.Name = "RightToolStripMenuItem"
			Me.RightToolStripMenuItem.Size = New Global.System.Drawing.Size(109, 22)
			Me.RightToolStripMenuItem.Text = "Right"
			Me.JustifyToolStripMenuItem1.Name = "JustifyToolStripMenuItem1"
			Me.JustifyToolStripMenuItem1.Size = New Global.System.Drawing.Size(109, 22)
			Me.JustifyToolStripMenuItem1.Text = "Justify"
			Me.EditTextToolStripMenuItem.DropDownItems.AddRange(New Global.System.Windows.Forms.ToolStripItem() { Me.ToolStripTextBox2 })
			Me.EditTextToolStripMenuItem.Name = "EditTextToolStripMenuItem"
			Me.EditTextToolStripMenuItem.Size = New Global.System.Drawing.Size(136, 22)
			Me.EditTextToolStripMenuItem.Text = "Edit"
			Me.ToolStripTextBox2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.ToolStripTextBox2.Font = New Global.System.Drawing.Font("Segoe UI", 9F)
			Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
			Me.ToolStripTextBox2.Size = New Global.System.Drawing.Size(100, 23)
			Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
			Me.DeleteToolStripMenuItem.Size = New Global.System.Drawing.Size(136, 22)
			Me.DeleteToolStripMenuItem.Text = "Delete"
			Me.AllignmentToolStripMenuItem.DropDownItems.AddRange(New Global.System.Windows.Forms.ToolStripItem() { Me.LeftToolStripMenuItem1, Me.RightToolStripMenuItem1, Me.CenterToolStripMenuItem1, Me.JustifyToolStripMenuItem })
			Me.AllignmentToolStripMenuItem.Name = "AllignmentToolStripMenuItem"
			Me.AllignmentToolStripMenuItem.Size = New Global.System.Drawing.Size(136, 22)
			Me.AllignmentToolStripMenuItem.Text = "Allignment"
			Me.AllignmentToolStripMenuItem.Visible = False
			Me.LeftToolStripMenuItem1.Name = "LeftToolStripMenuItem1"
			Me.LeftToolStripMenuItem1.Size = New Global.System.Drawing.Size(109, 22)
			Me.LeftToolStripMenuItem1.Text = "Left"
			Me.RightToolStripMenuItem1.Name = "RightToolStripMenuItem1"
			Me.RightToolStripMenuItem1.Size = New Global.System.Drawing.Size(109, 22)
			Me.RightToolStripMenuItem1.Text = "Right"
			Me.CenterToolStripMenuItem1.Name = "CenterToolStripMenuItem1"
			Me.CenterToolStripMenuItem1.Size = New Global.System.Drawing.Size(109, 22)
			Me.CenterToolStripMenuItem1.Text = "Center"
			Me.JustifyToolStripMenuItem.Name = "JustifyToolStripMenuItem"
			Me.JustifyToolStripMenuItem.Size = New Global.System.Drawing.Size(109, 22)
			Me.JustifyToolStripMenuItem.Text = "Justify"
			Me.cbxPurInv.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbxPurInv.Location = New Global.System.Drawing.Point(6, 331)
			Me.cbxPurInv.Name = "cbxPurInv"
			Me.cbxPurInv.Size = New Global.System.Drawing.Size(115, 17)
			Me.cbxPurInv.TabIndex = 18
			Me.cbxPurInv.Text = "PurInv"
			Me.cbxPurInv.UseVisualStyleBackColor = True
			Me.cbxQrBarcode.AutoSize = True
			Me.cbxQrBarcode.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbxQrBarcode.Location = New Global.System.Drawing.Point(6, 350)
			Me.cbxQrBarcode.Name = "cbxQrBarcode"
			Me.cbxQrBarcode.Size = New Global.System.Drawing.Size(77, 17)
			Me.cbxQrBarcode.TabIndex = 17
			Me.cbxQrBarcode.Text = "QrBarcode"
			Me.cbxQrBarcode.UseVisualStyleBackColor = True
			Me.cbxColour.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbxColour.Location = New Global.System.Drawing.Point(6, 293)
			Me.cbxColour.Name = "cbxColour"
			Me.cbxColour.Size = New Global.System.Drawing.Size(115, 17)
			Me.cbxColour.TabIndex = 16
			Me.cbxColour.Text = "Colour"
			Me.cbxColour.UseVisualStyleBackColor = True
			Me.cbxGST.AutoSize = True
			Me.cbxGST.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbxGST.Location = New Global.System.Drawing.Point(6, 312)
			Me.cbxGST.Name = "cbxGST"
			Me.cbxGST.Size = New Global.System.Drawing.Size(45, 17)
			Me.cbxGST.TabIndex = 15
			Me.cbxGST.Text = "GST"
			Me.cbxGST.UseVisualStyleBackColor = True
			Me.cbxExp.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbxExp.Location = New Global.System.Drawing.Point(6, 256)
			Me.cbxExp.Name = "cbxExp"
			Me.cbxExp.Size = New Global.System.Drawing.Size(115, 17)
			Me.cbxExp.TabIndex = 14
			Me.cbxExp.Text = "Exp"
			Me.cbxExp.UseVisualStyleBackColor = True
			Me.cbxSize.AutoSize = True
			Me.cbxSize.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbxSize.Location = New Global.System.Drawing.Point(6, 275)
			Me.cbxSize.Name = "cbxSize"
			Me.cbxSize.Size = New Global.System.Drawing.Size(45, 17)
			Me.cbxSize.TabIndex = 13
			Me.cbxSize.Text = "Size"
			Me.cbxSize.UseVisualStyleBackColor = True
			Me.cbxMfg.AutoSize = True
			Me.cbxMfg.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbxMfg.Location = New Global.System.Drawing.Point(6, 238)
			Me.cbxMfg.Name = "cbxMfg"
			Me.cbxMfg.Size = New Global.System.Drawing.Size(44, 17)
			Me.cbxMfg.TabIndex = 12
			Me.cbxMfg.Text = "Mfg"
			Me.cbxMfg.UseVisualStyleBackColor = True
			Me.cbxWholesalePrice.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbxWholesalePrice.Location = New Global.System.Drawing.Point(6, 201)
			Me.cbxWholesalePrice.Name = "cbxWholesalePrice"
			Me.cbxWholesalePrice.Size = New Global.System.Drawing.Size(115, 17)
			Me.cbxWholesalePrice.TabIndex = 11
			Me.cbxWholesalePrice.Text = "WholesalePrice"
			Me.cbxWholesalePrice.UseVisualStyleBackColor = True
			Me.cbxBatch.AutoSize = True
			Me.cbxBatch.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbxBatch.Location = New Global.System.Drawing.Point(6, 220)
			Me.cbxBatch.Name = "cbxBatch"
			Me.cbxBatch.Size = New Global.System.Drawing.Size(53, 17)
			Me.cbxBatch.TabIndex = 10
			Me.cbxBatch.Text = "Batch"
			Me.cbxBatch.UseVisualStyleBackColor = True
			Me.cbxMRP.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbxMRP.Location = New Global.System.Drawing.Point(6, 164)
			Me.cbxMRP.Name = "cbxMRP"
			Me.cbxMRP.Size = New Global.System.Drawing.Size(115, 17)
			Me.cbxMRP.TabIndex = 9
			Me.cbxMRP.Text = "MRP"
			Me.cbxMRP.UseVisualStyleBackColor = True
			Me.panel1.Controls.Add(Me.btnTestPrint)
			Me.panel1.Controls.Add(Me.btnClose)
			Me.panel1.Controls.Add(Me.btnClear)
			Me.panel1.Controls.Add(Me.btnSave)
			Me.panel1.Controls.Add(Me.gbxPosition)
			Me.panel1.Dock = Global.System.Windows.Forms.DockStyle.Bottom
			Me.panel1.Location = New Global.System.Drawing.Point(0, 571)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New Global.System.Drawing.Size(1116, 41)
			Me.panel1.TabIndex = 122
			Me.btnTestPrint.Location = New Global.System.Drawing.Point(12, 6)
			Me.btnTestPrint.Name = "btnTestPrint"
			Me.btnTestPrint.Size = New Global.System.Drawing.Size(75, 23)
			Me.btnTestPrint.TabIndex = 112
			Me.btnTestPrint.Text = "Test Print"
			Me.btnTestPrint.UseVisualStyleBackColor = True
			Me.btnClose.Location = New Global.System.Drawing.Point(727, 8)
			Me.btnClose.Name = "btnClose"
			Me.btnClose.Size = New Global.System.Drawing.Size(75, 23)
			Me.btnClose.TabIndex = 115
			Me.btnClose.Text = "Close"
			Me.btnClose.UseVisualStyleBackColor = True
			Me.btnClear.Location = New Global.System.Drawing.Point(646, 8)
			Me.btnClear.Name = "btnClear"
			Me.btnClear.Size = New Global.System.Drawing.Size(75, 23)
			Me.btnClear.TabIndex = 114
			Me.btnClear.Text = "Clear"
			Me.btnClear.UseVisualStyleBackColor = True
			Me.btnSave.Location = New Global.System.Drawing.Point(566, 8)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(75, 23)
			Me.btnSave.TabIndex = 113
			Me.btnSave.Text = "Save"
			Me.btnSave.UseVisualStyleBackColor = True
			Me.gbxPosition.BackColor = Global.System.Drawing.Color.Transparent
			Me.gbxPosition.Controls.Add(Me.lblY)
			Me.gbxPosition.Controls.Add(Me.lblX)
			Me.gbxPosition.Controls.Add(Me.lblDiamensionY)
			Me.gbxPosition.Controls.Add(Me.lblDiamensionX)
			Me.gbxPosition.Location = New Global.System.Drawing.Point(135, 0)
			Me.gbxPosition.Name = "gbxPosition"
			Me.gbxPosition.Size = New Global.System.Drawing.Size(170, 36)
			Me.gbxPosition.TabIndex = 8
			Me.gbxPosition.TabStop = False
			Me.lblY.AutoSize = True
			Me.lblY.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 7F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblY.Location = New Global.System.Drawing.Point(85, 14)
			Me.lblY.Name = "lblY"
			Me.lblY.Size = New Global.System.Drawing.Size(17, 13)
			Me.lblY.TabIndex = 7
			Me.lblY.Text = "Y:"
			Me.lblX.AutoSize = True
			Me.lblX.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 7F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblX.Location = New Global.System.Drawing.Point(36, 14)
			Me.lblX.Name = "lblX"
			Me.lblX.Size = New Global.System.Drawing.Size(17, 13)
			Me.lblX.TabIndex = 6
			Me.lblX.Text = "X:"
			Me.lblDiamensionY.AutoSize = True
			Me.lblDiamensionY.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 7F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblDiamensionY.Location = New Global.System.Drawing.Point(105, 14)
			Me.lblDiamensionY.Name = "lblDiamensionY"
			Me.lblDiamensionY.Size = New Global.System.Drawing.Size(22, 13)
			Me.lblDiamensionY.TabIndex = 5
			Me.lblDiamensionY.Text = "0.0"
			Me.lblDiamensionX.AutoSize = True
			Me.lblDiamensionX.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 7F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblDiamensionX.Location = New Global.System.Drawing.Point(56, 14)
			Me.lblDiamensionX.Name = "lblDiamensionX"
			Me.lblDiamensionX.Size = New Global.System.Drawing.Size(22, 13)
			Me.lblDiamensionX.TabIndex = 4
			Me.lblDiamensionX.Text = "0.0"
			Me.cbxSalePrice.AutoSize = True
			Me.cbxSalePrice.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbxSalePrice.Location = New Global.System.Drawing.Point(6, 183)
			Me.cbxSalePrice.Name = "cbxSalePrice"
			Me.cbxSalePrice.Size = New Global.System.Drawing.Size(69, 17)
			Me.cbxSalePrice.TabIndex = 8
			Me.cbxSalePrice.Text = "SalePrice"
			Me.cbxSalePrice.UseVisualStyleBackColor = True
			Me.cbxHSNC.AutoSize = True
			Me.cbxHSNC.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbxHSNC.Location = New Global.System.Drawing.Point(6, 145)
			Me.cbxHSNC.Name = "cbxHSNC"
			Me.cbxHSNC.Size = New Global.System.Drawing.Size(53, 17)
			Me.cbxHSNC.TabIndex = 6
			Me.cbxHSNC.Text = "HSNC"
			Me.cbxHSNC.UseVisualStyleBackColor = True
			Me.cbxAvlQty.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbxAvlQty.Location = New Global.System.Drawing.Point(6, 89)
			Me.cbxAvlQty.Name = "cbxAvlQty"
			Me.cbxAvlQty.Size = New Global.System.Drawing.Size(115, 17)
			Me.cbxAvlQty.TabIndex = 5
			Me.cbxAvlQty.Text = "AvlQty"
			Me.cbxAvlQty.UseVisualStyleBackColor = True
			Me.cbxNoCopy.AutoSize = True
			Me.cbxNoCopy.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbxNoCopy.Location = New Global.System.Drawing.Point(6, 108)
			Me.cbxNoCopy.Name = "cbxNoCopy"
			Me.cbxNoCopy.Size = New Global.System.Drawing.Size(64, 17)
			Me.cbxNoCopy.TabIndex = 4
			Me.cbxNoCopy.Text = "NoCopy"
			Me.cbxNoCopy.UseVisualStyleBackColor = True
			Me.cbxCategory.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbxCategory.Location = New Global.System.Drawing.Point(6, 52)
			Me.cbxCategory.Name = "cbxCategory"
			Me.cbxCategory.Size = New Global.System.Drawing.Size(115, 17)
			Me.cbxCategory.TabIndex = 3
			Me.cbxCategory.Text = "Category"
			Me.cbxCategory.UseVisualStyleBackColor = True
			Me.cbxBarcode.AutoSize = True
			Me.cbxBarcode.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbxBarcode.Location = New Global.System.Drawing.Point(6, 71)
			Me.cbxBarcode.Name = "cbxBarcode"
			Me.cbxBarcode.Size = New Global.System.Drawing.Size(65, 17)
			Me.cbxBarcode.TabIndex = 2
			Me.cbxBarcode.Text = "Barcode"
			Me.cbxBarcode.UseVisualStyleBackColor = True
			Me.cbxPCode.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbxPCode.Location = New Global.System.Drawing.Point(6, 14)
			Me.cbxPCode.Name = "cbxPCode"
			Me.cbxPCode.Size = New Global.System.Drawing.Size(115, 17)
			Me.cbxPCode.TabIndex = 1
			Me.cbxPCode.Text = "PCode"
			Me.cbxPCode.UseVisualStyleBackColor = True
			Me.cbxProductName.AutoSize = True
			Me.cbxProductName.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbxProductName.Location = New Global.System.Drawing.Point(6, 33)
			Me.cbxProductName.Name = "cbxProductName"
			Me.cbxProductName.Size = New Global.System.Drawing.Size(90, 17)
			Me.cbxProductName.TabIndex = 0
			Me.cbxProductName.Text = "ProductName"
			Me.cbxProductName.UseVisualStyleBackColor = True
			Me.cbxPartNo.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cbxPartNo.Location = New Global.System.Drawing.Point(6, 126)
			Me.cbxPartNo.Name = "cbxPartNo"
			Me.cbxPartNo.Size = New Global.System.Drawing.Size(115, 17)
			Me.cbxPartNo.TabIndex = 7
			Me.cbxPartNo.Text = "PartNo"
			Me.cbxPartNo.UseVisualStyleBackColor = True
			Me.dgvLabels.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dgvLabels.Location = New Global.System.Drawing.Point(688, 120)
			Me.dgvLabels.Name = "dgvLabels"
			Me.dgvLabels.Size = New Global.System.Drawing.Size(240, 150)
			Me.dgvLabels.TabIndex = 117
			Me.dgvLabels.Visible = False
			Me.PrintPreviewDialog1.AutoScrollMargin = New Global.System.Drawing.Size(0, 0)
			Me.PrintPreviewDialog1.AutoScrollMinSize = New Global.System.Drawing.Size(0, 0)
			Me.PrintPreviewDialog1.ClientSize = New Global.System.Drawing.Size(400, 300)
			Me.PrintPreviewDialog1.Enabled = True
			Me.PrintPreviewDialog1.Icon = CType(componentResourceManager.GetObject("PrintPreviewDialog1.Icon"), Global.System.Drawing.Icon)
			Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
			Me.PrintPreviewDialog1.Visible = False
			Me.PrintDialog1.UseEXDialog = True
			Me.pbQrBarCode.Location = New Global.System.Drawing.Point(713, 307)
			Me.pbQrBarCode.Name = "pbQrBarCode"
			Me.pbQrBarCode.Size = New Global.System.Drawing.Size(100, 50)
			Me.pbQrBarCode.TabIndex = 0
			Me.pbQrBarCode.TabStop = False
			Me.pbQrBarCode.Visible = False
			Me.pbQrCode.Location = New Global.System.Drawing.Point(713, 404)
			Me.pbQrCode.Name = "pbQrCode"
			Me.pbQrCode.Size = New Global.System.Drawing.Size(100, 50)
			Me.pbQrCode.TabIndex = 118
			Me.pbQrCode.TabStop = False
			Me.pbQrCode.Visible = False
			Me.gbxOptions.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.gbxOptions.BackColor = Global.System.Drawing.Color.WhiteSmoke
			Me.gbxOptions.Controls.Add(Me.cbxPurInv)
			Me.gbxOptions.Controls.Add(Me.cbxQrBarcode)
			Me.gbxOptions.Controls.Add(Me.cbxColour)
			Me.gbxOptions.Controls.Add(Me.cbxGST)
			Me.gbxOptions.Controls.Add(Me.cbxExp)
			Me.gbxOptions.Controls.Add(Me.cbxSize)
			Me.gbxOptions.Controls.Add(Me.cbxMfg)
			Me.gbxOptions.Controls.Add(Me.cbxWholesalePrice)
			Me.gbxOptions.Controls.Add(Me.cbxBatch)
			Me.gbxOptions.Controls.Add(Me.cbxMRP)
			Me.gbxOptions.Controls.Add(Me.cbxSalePrice)
			Me.gbxOptions.Controls.Add(Me.cbxPartNo)
			Me.gbxOptions.Controls.Add(Me.cbxHSNC)
			Me.gbxOptions.Controls.Add(Me.cbxAvlQty)
			Me.gbxOptions.Controls.Add(Me.cbxNoCopy)
			Me.gbxOptions.Controls.Add(Me.cbxCategory)
			Me.gbxOptions.Controls.Add(Me.cbxBarcode)
			Me.gbxOptions.Controls.Add(Me.cbxPCode)
			Me.gbxOptions.Controls.Add(Me.cbxProductName)
			Me.gbxOptions.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.gbxOptions.Location = New Global.System.Drawing.Point(923, 120)
			Me.gbxOptions.Name = "gbxOptions"
			Me.gbxOptions.Size = New Global.System.Drawing.Size(188, 411)
			Me.gbxOptions.TabIndex = 116
			Me.gbxOptions.TabStop = False
			Me.gbxOptions.Text = "Options"
			Me.lblMandatory.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblMandatory.ForeColor = Global.System.Drawing.Color.Red
			Me.lblMandatory.Location = New Global.System.Drawing.Point(412, 12)
			Me.lblMandatory.Name = "lblMandatory"
			Me.lblMandatory.Size = New Global.System.Drawing.Size(15, 15)
			Me.lblMandatory.TabIndex = 111
			Me.toolTip.SetToolTip(Me.lblMandatory, "This field is required")
			Me.pnlCheque.BackColor = Global.System.Drawing.Color.White
			Me.pnlCheque.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.pnlCheque.Location = New Global.System.Drawing.Point(21, 123)
			Me.pnlCheque.MaximumSize = New Global.System.Drawing.Size(895, 399)
			Me.pnlCheque.Name = "pnlCheque"
			Me.pnlCheque.Size = New Global.System.Drawing.Size(669, 331)
			Me.pnlCheque.TabIndex = 1
			Me.ttPanelCheque.SetToolTip(Me.pnlCheque, "Click to select ")
			Me.lblChequeHeight.AutoSize = True
			Me.lblChequeHeight.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblChequeHeight.Location = New Global.System.Drawing.Point(117, 19)
			Me.lblChequeHeight.Name = "lblChequeHeight"
			Me.lblChequeHeight.Size = New Global.System.Drawing.Size(38, 13)
			Me.lblChequeHeight.TabIndex = 23
			Me.lblChequeHeight.Text = "Height"
			Me.lblChequeWidth.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblChequeWidth.Location = New Global.System.Drawing.Point(4, 20)
			Me.lblChequeWidth.Name = "lblChequeWidth"
			Me.lblChequeWidth.Size = New Global.System.Drawing.Size(39, 15)
			Me.lblChequeWidth.TabIndex = 22
			Me.lblChequeWidth.Text = "Width"
			Me.nudChequeLeafWidth.DecimalPlaces = 1
			Me.nudChequeLeafWidth.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.nudChequeLeafWidth.Increment = New Decimal(New Integer() { 10, 0, 0, 131072 })
			Me.nudChequeLeafWidth.Location = New Global.System.Drawing.Point(50, 16)
			Dim nudChequeLeafWidth As Global.System.Windows.Forms.NumericUpDown = Me.nudChequeLeafWidth
			Dim array As Integer() = New Integer(3) {}
			array(0) = 2000
			nudChequeLeafWidth.Maximum = New Decimal(array)
			Dim nudChequeLeafWidth2 As Global.System.Windows.Forms.NumericUpDown = Me.nudChequeLeafWidth
			Dim array2 As Integer() = New Integer(3) {}
			array2(0) = 1
			nudChequeLeafWidth2.Minimum = New Decimal(array2)
			Me.nudChequeLeafWidth.Name = "nudChequeLeafWidth"
			Me.nudChequeLeafWidth.Size = New Global.System.Drawing.Size(61, 21)
			Me.nudChequeLeafWidth.TabIndex = 0
			Dim nudChequeLeafWidth3 As Global.System.Windows.Forms.NumericUpDown = Me.nudChequeLeafWidth
			Dim array3 As Integer() = New Integer(3) {}
			array3(0) = 5
			nudChequeLeafWidth3.Value = New Decimal(array3)
			Me.nudChequeHeight.DecimalPlaces = 1
			Me.nudChequeHeight.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.nudChequeHeight.Increment = New Decimal(New Integer() { 10, 0, 0, 131072 })
			Me.nudChequeHeight.Location = New Global.System.Drawing.Point(161, 15)
			Dim nudChequeHeight As Global.System.Windows.Forms.NumericUpDown = Me.nudChequeHeight
			Dim array4 As Integer() = New Integer(3) {}
			array4(0) = 2000
			nudChequeHeight.Maximum = New Decimal(array4)
			Dim nudChequeHeight2 As Global.System.Windows.Forms.NumericUpDown = Me.nudChequeHeight
			Dim array5 As Integer() = New Integer(3) {}
			array5(0) = 1
			nudChequeHeight2.Minimum = New Decimal(array5)
			Me.nudChequeHeight.Name = "nudChequeHeight"
			Me.nudChequeHeight.Size = New Global.System.Drawing.Size(61, 21)
			Me.nudChequeHeight.TabIndex = 1
			Me.nudChequeHeight.Value = New Decimal(New Integer() { 87, 0, 0, 65536 })
			Me.nudLeft.DecimalPlaces = 1
			Me.nudLeft.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.nudLeft.Location = New Global.System.Drawing.Point(140, 40)
			Dim nudLeft As Global.System.Windows.Forms.NumericUpDown = Me.nudLeft
			Dim array6 As Integer() = New Integer(3) {}
			array6(0) = 5000
			nudLeft.Maximum = New Decimal(array6)
			Me.nudLeft.Name = "nudLeft"
			Me.nudLeft.Size = New Global.System.Drawing.Size(63, 21)
			Me.nudLeft.TabIndex = 3
			Dim nudLeft2 As Global.System.Windows.Forms.NumericUpDown = Me.nudLeft
			Dim array7 As Integer() = New Integer(3) {}
			array7(0) = 16
			nudLeft2.Value = New Decimal(array7)
			Me.lblLeft.AutoSize = True
			Me.lblLeft.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblLeft.Location = New Global.System.Drawing.Point(114, 47)
			Me.lblLeft.Name = "lblLeft"
			Me.lblLeft.Size = New Global.System.Drawing.Size(26, 13)
			Me.lblLeft.TabIndex = 19
			Me.lblLeft.Text = "Left"
			Me.nudTop.DecimalPlaces = 1
			Me.nudTop.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.nudTop.Location = New Global.System.Drawing.Point(140, 12)
			Dim nudTop As Global.System.Windows.Forms.NumericUpDown = Me.nudTop
			Dim array8 As Integer() = New Integer(3) {}
			array8(0) = 5000
			nudTop.Maximum = New Decimal(array8)
			Me.nudTop.Name = "nudTop"
			Me.nudTop.Size = New Global.System.Drawing.Size(63, 21)
			Me.nudTop.TabIndex = 2
			Dim nudTop2 As Global.System.Windows.Forms.NumericUpDown = Me.nudTop
			Dim array9 As Integer() = New Integer(3) {}
			array9(0) = 18
			nudTop2.Value = New Decimal(array9)
			Me.nudHeight.DecimalPlaces = 1
			Me.nudHeight.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.nudHeight.Location = New Global.System.Drawing.Point(47, 40)
			Dim nudHeight As Global.System.Windows.Forms.NumericUpDown = Me.nudHeight
			Dim array10 As Integer() = New Integer(3) {}
			array10(0) = 5000
			nudHeight.Maximum = New Decimal(array10)
			Me.nudHeight.Name = "nudHeight"
			Me.nudHeight.Size = New Global.System.Drawing.Size(62, 21)
			Me.nudHeight.TabIndex = 1
			Dim nudHeight2 As Global.System.Windows.Forms.NumericUpDown = Me.nudHeight
			Dim array11 As Integer() = New Integer(3) {}
			array11(0) = 23
			nudHeight2.Value = New Decimal(array11)
			Me.nudWidth.DecimalPlaces = 1
			Me.nudWidth.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.nudWidth.Location = New Global.System.Drawing.Point(48, 14)
			Dim nudWidth As Global.System.Windows.Forms.NumericUpDown = Me.nudWidth
			Dim array12 As Integer() = New Integer(3) {}
			array12(0) = 5000
			nudWidth.Maximum = New Decimal(array12)
			Me.nudWidth.Name = "nudWidth"
			Me.nudWidth.Size = New Global.System.Drawing.Size(61, 21)
			Me.nudWidth.TabIndex = 0
			Dim nudWidth2 As Global.System.Windows.Forms.NumericUpDown = Me.nudWidth
			Dim array13 As Integer() = New Integer(3) {}
			array13(0) = 100
			nudWidth2.Value = New Decimal(array13)
			Me.lnklblSetDefault.AutoSize = True
			Me.lnklblSetDefault.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lnklblSetDefault.Location = New Global.System.Drawing.Point(47, 45)
			Me.lnklblSetDefault.Name = "lnklblSetDefault"
			Me.lnklblSetDefault.Size = New Global.System.Drawing.Size(74, 13)
			Me.lnklblSetDefault.TabIndex = 2
			Me.lnklblSetDefault.TabStop = True
			Me.lnklblSetDefault.Text = "Set to Default"
			Me.lblTop.AutoSize = True
			Me.lblTop.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblTop.Location = New Global.System.Drawing.Point(114, 16)
			Me.lblTop.Name = "lblTop"
			Me.lblTop.Size = New Global.System.Drawing.Size(25, 13)
			Me.lblTop.TabIndex = 10
			Me.lblTop.Text = "Top"
			Me.lblHeight.AutoSize = True
			Me.lblHeight.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblHeight.Location = New Global.System.Drawing.Point(8, 45)
			Me.lblHeight.Name = "lblHeight"
			Me.lblHeight.Size = New Global.System.Drawing.Size(38, 13)
			Me.lblHeight.TabIndex = 9
			Me.lblHeight.Text = "Height"
			Me.lblLayOutName.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblLayOutName.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblLayOutName.Location = New Global.System.Drawing.Point(280, 9)
			Me.lblLayOutName.Name = "lblLayOutName"
			Me.lblLayOutName.Size = New Global.System.Drawing.Size(79, 15)
			Me.lblLayOutName.TabIndex = 0
			Me.lblLayOutName.Text = "Layout Name:"
			Me.gbxAlignMent.BackColor = Global.System.Drawing.Color.Transparent
			Me.gbxAlignMent.Controls.Add(Me.nudLeft)
			Me.gbxAlignMent.Controls.Add(Me.lblLeft)
			Me.gbxAlignMent.Controls.Add(Me.nudTop)
			Me.gbxAlignMent.Controls.Add(Me.nudHeight)
			Me.gbxAlignMent.Controls.Add(Me.nudWidth)
			Me.gbxAlignMent.Controls.Add(Me.lblTop)
			Me.gbxAlignMent.Controls.Add(Me.lblHeight)
			Me.gbxAlignMent.Controls.Add(Me.lblWidth)
			Me.gbxAlignMent.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.gbxAlignMent.Location = New Global.System.Drawing.Point(245, 30)
			Me.gbxAlignMent.Name = "gbxAlignMent"
			Me.gbxAlignMent.Size = New Global.System.Drawing.Size(213, 65)
			Me.gbxAlignMent.TabIndex = 4
			Me.gbxAlignMent.TabStop = False
			Me.gbxAlignMent.Text = "Positon"
			Me.lblWidth.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblWidth.Location = New Global.System.Drawing.Point(8, 17)
			Me.lblWidth.Name = "lblWidth"
			Me.lblWidth.Size = New Global.System.Drawing.Size(39, 15)
			Me.lblWidth.TabIndex = 0
			Me.lblWidth.Text = "Width"
			Me.txtLayoutName.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtLayoutName.Location = New Global.System.Drawing.Point(362, 6)
			Me.txtLayoutName.Name = "txtLayoutName"
			Me.txtLayoutName.Size = New Global.System.Drawing.Size(276, 21)
			Me.txtLayoutName.TabIndex = 0
			Me.ComboBox3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ComboBox3.FormattingEnabled = True
			Me.ComboBox3.Items.AddRange(New Object() { "Left", "Right", "Center", "justify " })
			Me.ComboBox3.Location = New Global.System.Drawing.Point(373, 14)
			Me.ComboBox3.Name = "ComboBox3"
			Me.ComboBox3.Size = New Global.System.Drawing.Size(83, 26)
			Me.ComboBox3.TabIndex = 121
			Me.cmbFontSize.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbFontSize.FormattingEnabled = True
			Me.cmbFontSize.Items.AddRange(New Object() { "Size", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100", "101", "102", "103", "104", "105", "106", "107", "108", "109", "110", "111", "112", "113", "114", "115", "116", "117", "118", "119", "120", "121", "122", "123", "124", "125", "126", "127", "128", "129", "130", "131", "132", "133", "134", "135", "136", "137", "138", "139", "140", "141", "142", "143", "144", "145", "146", "147", "148", "149", "150", "151", "152", "153", "154", "155", "156", "157", "158", "159", "160", "161", "162", "163", "164", "165", "166", "167", "168", "169", "170", "171", "172", "173", "174", "175", "176", "177", "178", "179", "180", "181", "182", "183", "184", "185", "186", "187", "188", "189", "190", "191", "192", "193", "194", "195", "196", "197", "198", "199", "200", "201", "202", "203", "204", "205" })
			Me.cmbFontSize.Location = New Global.System.Drawing.Point(146, 14)
			Me.cmbFontSize.Name = "cmbFontSize"
			Me.cmbFontSize.Size = New Global.System.Drawing.Size(62, 26)
			Me.cmbFontSize.TabIndex = 119
			Me.cmbFontSize.Text = "8.5"
			Me.btnUnderline.Appearance = Global.System.Windows.Forms.Appearance.Button
			Me.btnUnderline.AutoSize = True
			Me.btnUnderline.FlatAppearance.BorderSize = 0
			Me.btnUnderline.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Underline, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnUnderline.Location = New Global.System.Drawing.Point(271, 11)
			Me.btnUnderline.Name = "btnUnderline"
			Me.btnUnderline.Size = New Global.System.Drawing.Size(31, 30)
			Me.btnUnderline.TabIndex = 117
			Me.btnUnderline.Text = "U"
			Me.btnUnderline.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.btnUnderline.UseVisualStyleBackColor = True
			Me.btnItalic.Appearance = Global.System.Windows.Forms.Appearance.Button
			Me.btnItalic.FlatAppearance.BorderSize = 0
			Me.btnItalic.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Italic, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnItalic.Location = New Global.System.Drawing.Point(242, 11)
			Me.btnItalic.Name = "btnItalic"
			Me.btnItalic.Size = New Global.System.Drawing.Size(29, 30)
			Me.btnItalic.TabIndex = 116
			Me.btnItalic.Text = "I"
			Me.btnItalic.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.btnItalic.UseVisualStyleBackColor = True
			Me.btnColor.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnColor.Location = New Global.System.Drawing.Point(302, 12)
			Me.btnColor.Name = "btnColor"
			Me.btnColor.Size = New Global.System.Drawing.Size(68, 30)
			Me.btnColor.TabIndex = 117
			Me.btnColor.Text = "Color"
			Me.btnColor.UseVisualStyleBackColor = True
			Me.btnBold.Appearance = Global.System.Windows.Forms.Appearance.Button
			Me.btnBold.AutoSize = True
			Me.btnBold.FlatAppearance.BorderSize = 0
			Me.btnBold.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnBold.Location = New Global.System.Drawing.Point(211, 11)
			Me.btnBold.Name = "btnBold"
			Me.btnBold.Size = New Global.System.Drawing.Size(31, 30)
			Me.btnBold.TabIndex = 115
			Me.btnBold.Text = "B"
			Me.btnBold.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.btnBold.UseVisualStyleBackColor = True
			Me.cmbFonts.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbFonts.Location = New Global.System.Drawing.Point(6, 14)
			Me.cmbFonts.Name = "cmbFonts"
			Me.cmbFonts.Size = New Global.System.Drawing.Size(134, 26)
			Me.cmbFonts.TabIndex = 122
			Me.cmbFonts.Text = "Arial"
			Me.btnRevert.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnRevert.Location = New Global.System.Drawing.Point(791, 6)
			Me.btnRevert.Name = "btnRevert"
			Me.btnRevert.Size = New Global.System.Drawing.Size(75, 30)
			Me.btnRevert.TabIndex = 127
			Me.btnRevert.Text = "Revert"
			Me.btnRevert.UseVisualStyleBackColor = True
			Me.btnRevert.Visible = False
			Me.lblHiddenImage.AutoSize = True
			Me.lblHiddenImage.Location = New Global.System.Drawing.Point(643, 32)
			Me.lblHiddenImage.Name = "lblHiddenImage"
			Me.lblHiddenImage.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblHiddenImage.TabIndex = 126
			Me.lblHiddenImage.Text = "Label2"
			Me.lblHiddenImage.Visible = False
			Me.btnZoom.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnZoom.Location = New Global.System.Drawing.Point(710, 6)
			Me.btnZoom.Name = "btnZoom"
			Me.btnZoom.Size = New Global.System.Drawing.Size(75, 30)
			Me.btnZoom.TabIndex = 125
			Me.btnZoom.Text = "Zoom"
			Me.btnZoom.UseVisualStyleBackColor = True
			Me.btnZoom.Visible = False
			Me.btnAddImage.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnAddImage.Location = New Global.System.Drawing.Point(462, 31)
			Me.btnAddImage.Name = "btnAddImage"
			Me.btnAddImage.Size = New Global.System.Drawing.Size(75, 30)
			Me.btnAddImage.TabIndex = 124
			Me.btnAddImage.Text = "Add Image"
			Me.btnAddImage.UseVisualStyleBackColor = True
			Me.cmbLayouts.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbLayouts.Items.AddRange(New Object() { "Select" })
			Me.cmbLayouts.Location = New Global.System.Drawing.Point(94, 4)
			Me.cmbLayouts.Name = "cmbLayouts"
			Me.cmbLayouts.Size = New Global.System.Drawing.Size(134, 26)
			Me.cmbLayouts.TabIndex = 123
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.Location = New Global.System.Drawing.Point(8, 9)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(79, 15)
			Me.Label1.TabIndex = 118
			Me.Label1.Text = "Select Layout:"
			Me.lblHidden.AutoSize = True
			Me.lblHidden.Location = New Global.System.Drawing.Point(644, 14)
			Me.lblHidden.Name = "lblHidden"
			Me.lblHidden.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblHidden.TabIndex = 114
			Me.lblHidden.Text = "Label1"
			Me.lblHidden.Visible = False
			Me.GroupBox1.Controls.Add(Me.ComboBox3)
			Me.GroupBox1.Controls.Add(Me.cmbFontSize)
			Me.GroupBox1.Controls.Add(Me.btnUnderline)
			Me.GroupBox1.Controls.Add(Me.btnItalic)
			Me.GroupBox1.Controls.Add(Me.btnColor)
			Me.GroupBox1.Controls.Add(Me.btnBold)
			Me.GroupBox1.Controls.Add(Me.cmbFonts)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(543, 48)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(469, 47)
			Me.GroupBox1.TabIndex = 113
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Font Style"
			Me.panel2.Controls.Add(Me.btnRevert)
			Me.panel2.Controls.Add(Me.lblHiddenImage)
			Me.panel2.Controls.Add(Me.btnZoom)
			Me.panel2.Controls.Add(Me.btnAddImage)
			Me.panel2.Controls.Add(Me.cmbLayouts)
			Me.panel2.Controls.Add(Me.Label1)
			Me.panel2.Controls.Add(Me.lblHidden)
			Me.panel2.Controls.Add(Me.GroupBox1)
			Me.panel2.Controls.Add(Me.btnAddLabel)
			Me.panel2.Controls.Add(Me.lblLayOutName)
			Me.panel2.Controls.Add(Me.gbxChequeSize)
			Me.panel2.Controls.Add(Me.gbxAlignMent)
			Me.panel2.Controls.Add(Me.txtLayoutName)
			Me.panel2.Controls.Add(Me.lblMandatory)
			Me.panel2.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.panel2.Location = New Global.System.Drawing.Point(0, 0)
			Me.panel2.Name = "panel2"
			Me.panel2.Size = New Global.System.Drawing.Size(1116, 103)
			Me.panel2.TabIndex = 123
			Me.btnAddLabel.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnAddLabel.Location = New Global.System.Drawing.Point(462, 62)
			Me.btnAddLabel.Name = "btnAddLabel"
			Me.btnAddLabel.Size = New Global.System.Drawing.Size(75, 30)
			Me.btnAddLabel.TabIndex = 112
			Me.btnAddLabel.Text = "New Label"
			Me.btnAddLabel.UseVisualStyleBackColor = True
			Me.gbxChequeSize.BackColor = Global.System.Drawing.Color.Transparent
			Me.gbxChequeSize.Controls.Add(Me.btnBgColor_Layout)
			Me.gbxChequeSize.Controls.Add(Me.lnklblSetDefault)
			Me.gbxChequeSize.Controls.Add(Me.lblChequeHeight)
			Me.gbxChequeSize.Controls.Add(Me.lblChequeWidth)
			Me.gbxChequeSize.Controls.Add(Me.nudChequeLeafWidth)
			Me.gbxChequeSize.Controls.Add(Me.nudChequeHeight)
			Me.gbxChequeSize.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.gbxChequeSize.Location = New Global.System.Drawing.Point(6, 29)
			Me.gbxChequeSize.Name = "gbxChequeSize"
			Me.gbxChequeSize.Size = New Global.System.Drawing.Size(232, 66)
			Me.gbxChequeSize.TabIndex = 3
			Me.gbxChequeSize.TabStop = False
			Me.gbxChequeSize.Text = "Cheque Size"
			Me.btnBgColor_Layout.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnBgColor_Layout.Location = New Global.System.Drawing.Point(161, 38)
			Me.btnBgColor_Layout.Name = "btnBgColor_Layout"
			Me.btnBgColor_Layout.Size = New Global.System.Drawing.Size(65, 24)
			Me.btnBgColor_Layout.TabIndex = 118
			Me.btnBgColor_Layout.Text = "BG Color"
			Me.btnBgColor_Layout.UseVisualStyleBackColor = True
			Me.lblBg.BackColor = Global.System.Drawing.Color.Moccasin
			Me.lblBg.Location = New Global.System.Drawing.Point(1, 103)
			Me.lblBg.Name = "lblBg"
			Me.lblBg.Size = New Global.System.Drawing.Size(17, 17)
			Me.lblBg.TabIndex = 3
			Me.rulerCtrlLeft.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.rulerCtrlLeft.BackColor = Global.System.Drawing.Color.Moccasin
			Me.rulerCtrlLeft.DivisionMarkFactor = 5
			Me.rulerCtrlLeft.Divisions = 10
			Me.rulerCtrlLeft.ForeColor = Global.System.Drawing.Color.Black
			Me.rulerCtrlLeft.Location = New Global.System.Drawing.Point(0, 120)
			Me.rulerCtrlLeft.MajorInterval = 1
			Me.rulerCtrlLeft.MiddleMarkFactor = 3
			Me.rulerCtrlLeft.MouseTrackingOn = False
			Me.rulerCtrlLeft.Name = "rulerCtrlLeft"
			Me.rulerCtrlLeft.Orientation = Global.Lyquidity.UtilityLibrary.Controls.enumOrientation.orVertical
			Me.rulerCtrlLeft.RulerAlignment = Global.Lyquidity.UtilityLibrary.Controls.enumRulerAlignment.raBottomOrRight
			Me.rulerCtrlLeft.ScaleMode = Global.Lyquidity.UtilityLibrary.Controls.enumScaleMode.smCentimetres
			Me.rulerCtrlLeft.Size = New Global.System.Drawing.Size(20, 593)
			Me.rulerCtrlLeft.StartValue = 0.0
			Me.rulerCtrlLeft.TabIndex = 2
			Me.rulerCtrlLeft.Text = "rulerControl2"
			Me.rulerCtrlLeft.VerticalNumbers = False
			Me.rulerCtrlLeft.ZoomFactor = 1.0
			Me.rulerCtrlTop.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.rulerCtrlTop.BackColor = Global.System.Drawing.Color.Moccasin
			Me.rulerCtrlTop.DivisionMarkFactor = 5
			Me.rulerCtrlTop.Divisions = 10
			Me.rulerCtrlTop.ForeColor = Global.System.Drawing.Color.Black
			Me.rulerCtrlTop.Location = New Global.System.Drawing.Point(18, 102)
			Me.rulerCtrlTop.MajorInterval = 1
			Me.rulerCtrlTop.MiddleMarkFactor = 3
			Me.rulerCtrlTop.MouseTrackingOn = False
			Me.rulerCtrlTop.Name = "rulerCtrlTop"
			Me.rulerCtrlTop.Orientation = Global.Lyquidity.UtilityLibrary.Controls.enumOrientation.orHorizontal
			Me.rulerCtrlTop.RulerAlignment = Global.Lyquidity.UtilityLibrary.Controls.enumRulerAlignment.raBottomOrRight
			Me.rulerCtrlTop.ScaleMode = Global.Lyquidity.UtilityLibrary.Controls.enumScaleMode.smCentimetres
			Me.rulerCtrlTop.Size = New Global.System.Drawing.Size(1097, 20)
			Me.rulerCtrlTop.StartValue = 0.0
			Me.rulerCtrlTop.TabIndex = 1
			Me.rulerCtrlTop.Text = "rulerControl1"
			Me.rulerCtrlTop.VerticalNumbers = False
			Me.rulerCtrlTop.ZoomFactor = 1.0
			Me.pnlWorkSpace.AutoScroll = True
			Me.pnlWorkSpace.BackColor = Global.System.Drawing.SystemColors.AppWorkspace
			Me.pnlWorkSpace.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.pnlWorkSpace.Controls.Add(Me.pbQrCode)
			Me.pnlWorkSpace.Controls.Add(Me.pbQrBarCode)
			Me.pnlWorkSpace.Controls.Add(Me.dgvLabels)
			Me.pnlWorkSpace.Controls.Add(Me.gbxOptions)
			Me.pnlWorkSpace.Controls.Add(Me.lblBg)
			Me.pnlWorkSpace.Controls.Add(Me.rulerCtrlLeft)
			Me.pnlWorkSpace.Controls.Add(Me.rulerCtrlTop)
			Me.pnlWorkSpace.Controls.Add(Me.pnlCheque)
			Me.pnlWorkSpace.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.pnlWorkSpace.Location = New Global.System.Drawing.Point(0, 0)
			Me.pnlWorkSpace.Name = "pnlWorkSpace"
			Me.pnlWorkSpace.Size = New Global.System.Drawing.Size(1116, 612)
			Me.pnlWorkSpace.TabIndex = 121
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1116, 612)
			MyBase.Controls.Add(Me.panel1)
			MyBase.Controls.Add(Me.panel2)
			MyBase.Controls.Add(Me.pnlWorkSpace)
			MyBase.Name = "frmBarcodeMain"
			Me.Text = "frmBarcodeMain"
			Me.ContextMenuStrip1.ResumeLayout(False)
			Me.panel1.ResumeLayout(False)
			Me.gbxPosition.ResumeLayout(False)
			Me.gbxPosition.PerformLayout()
			CType(Me.dgvLabels, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.pbQrBarCode, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.pbQrCode, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.gbxOptions.ResumeLayout(False)
			Me.gbxOptions.PerformLayout()
			CType(Me.nudChequeLeafWidth, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nudChequeHeight, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nudLeft, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nudTop, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nudHeight, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nudWidth, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.gbxAlignMent.ResumeLayout(False)
			Me.gbxAlignMent.PerformLayout()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.panel2.ResumeLayout(False)
			Me.panel2.PerformLayout()
			Me.gbxChequeSize.ResumeLayout(False)
			Me.gbxChequeSize.PerformLayout()
			Me.pnlWorkSpace.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04000223 RID: 547
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
