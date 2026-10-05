Namespace BillPoint
	' Token: 0x02000018 RID: 24
		Public Partial Class frmMine
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600070D RID: 1805 RVA: 0x0009C544 File Offset: 0x0009A744
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

		' Token: 0x0600070E RID: 1806 RVA: 0x0009C594 File Offset: 0x0009A794
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Me.ContextMenuStrip1 = New Global.System.Windows.Forms.ContextMenuStrip(Me.components)
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
			Me.EditTextToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.ToolStripTextBox2 = New Global.System.Windows.Forms.ToolStripTextBox()
			Me.DeleteToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.btnAddLabel = New Global.System.Windows.Forms.Button()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.cmbFonts = New Global.System.Windows.Forms.ComboBox()
			Me.cmbFontSize = New Global.System.Windows.Forms.ComboBox()
			Me.btnBold = New Global.System.Windows.Forms.Button()
			Me.btnItalic = New Global.System.Windows.Forms.Button()
			Me.btnUnderline = New Global.System.Windows.Forms.Button()
			Me.btnColor = New Global.System.Windows.Forms.Button()
			Me.cmbAlignment = New Global.System.Windows.Forms.ComboBox()
			Me.lblHidden = New Global.System.Windows.Forms.Label()
			Me.FontFamilyToolStripMenuItem = New Global.System.Windows.Forms.ToolStripMenuItem()
			Me.ToolStripCmbFonts = New Global.System.Windows.Forms.ToolStripComboBox()
			Me.ContextMenuStrip1.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.ContextMenuStrip1.Items.AddRange(New Global.System.Windows.Forms.ToolStripItem() { Me.FontFamilyToolStripMenuItem, Me.TextSizeToolStripMenuItem, Me.FontSizeToolStripMenuItem, Me.TextColorToolStripMenuItem, Me.AlignmentToolStripMenuItem, Me.EditTextToolStripMenuItem, Me.DeleteToolStripMenuItem })
			Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
			Me.ContextMenuStrip1.Size = New Global.System.Drawing.Size(153, 180)
			Me.TextSizeToolStripMenuItem.DropDownItems.AddRange(New Global.System.Windows.Forms.ToolStripItem() { Me.BoldToolStripMenuItem, Me.ItalicToolStripMenuItem, Me.BoldItalicToolStripMenuItem, Me.RegularToolStripMenuItem, Me.UnderlineToolStripMenuItem1, Me.BoldUnderlineToolStripMenuItem })
			Me.TextSizeToolStripMenuItem.Name = "TextSizeToolStripMenuItem"
			Me.TextSizeToolStripMenuItem.Size = New Global.System.Drawing.Size(152, 22)
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
			Me.FontSizeToolStripMenuItem.Size = New Global.System.Drawing.Size(152, 22)
			Me.FontSizeToolStripMenuItem.Text = "Font Size"
			Me.ToolStripTextBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
			Me.ToolStripTextBox1.Size = New Global.System.Drawing.Size(100, 23)
			Me.TextColorToolStripMenuItem.Name = "TextColorToolStripMenuItem"
			Me.TextColorToolStripMenuItem.Size = New Global.System.Drawing.Size(152, 22)
			Me.TextColorToolStripMenuItem.Text = "Text Color"
			Me.AlignmentToolStripMenuItem.DropDownItems.AddRange(New Global.System.Windows.Forms.ToolStripItem() { Me.LeftToolStripMenuItem, Me.CenterToolStripMenuItem, Me.RightToolStripMenuItem })
			Me.AlignmentToolStripMenuItem.Name = "AlignmentToolStripMenuItem"
			Me.AlignmentToolStripMenuItem.Size = New Global.System.Drawing.Size(152, 22)
			Me.AlignmentToolStripMenuItem.Text = "Alignment"
			Me.AlignmentToolStripMenuItem.Visible = False
			Me.LeftToolStripMenuItem.Name = "LeftToolStripMenuItem"
			Me.LeftToolStripMenuItem.Size = New Global.System.Drawing.Size(109, 22)
			Me.LeftToolStripMenuItem.Text = "Left"
			Me.CenterToolStripMenuItem.Name = "CenterToolStripMenuItem"
			Me.CenterToolStripMenuItem.Size = New Global.System.Drawing.Size(109, 22)
			Me.CenterToolStripMenuItem.Text = "Center"
			Me.RightToolStripMenuItem.Name = "RightToolStripMenuItem"
			Me.RightToolStripMenuItem.Size = New Global.System.Drawing.Size(109, 22)
			Me.RightToolStripMenuItem.Text = "Right"
			Me.EditTextToolStripMenuItem.DropDownItems.AddRange(New Global.System.Windows.Forms.ToolStripItem() { Me.ToolStripTextBox2 })
			Me.EditTextToolStripMenuItem.Name = "EditTextToolStripMenuItem"
			Me.EditTextToolStripMenuItem.Size = New Global.System.Drawing.Size(152, 22)
			Me.EditTextToolStripMenuItem.Text = "Edit"
			Me.ToolStripTextBox2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
			Me.ToolStripTextBox2.Size = New Global.System.Drawing.Size(100, 23)
			Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
			Me.DeleteToolStripMenuItem.Size = New Global.System.Drawing.Size(152, 22)
			Me.DeleteToolStripMenuItem.Text = "Delete"
			Me.Panel1.AutoSize = True
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 79)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(760, 344)
			Me.Panel1.TabIndex = 2
			Me.btnAddLabel.Location = New Global.System.Drawing.Point(191, 5)
			Me.btnAddLabel.Name = "btnAddLabel"
			Me.btnAddLabel.Size = New Global.System.Drawing.Size(75, 23)
			Me.btnAddLabel.TabIndex = 3
			Me.btnAddLabel.Text = "New Label"
			Me.btnAddLabel.UseVisualStyleBackColor = True
			Me.GroupBox1.Controls.Add(Me.cmbAlignment)
			Me.GroupBox1.Controls.Add(Me.btnColor)
			Me.GroupBox1.Controls.Add(Me.btnUnderline)
			Me.GroupBox1.Controls.Add(Me.btnItalic)
			Me.GroupBox1.Controls.Add(Me.btnBold)
			Me.GroupBox1.Controls.Add(Me.cmbFontSize)
			Me.GroupBox1.Controls.Add(Me.cmbFonts)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(287, 5)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(461, 57)
			Me.GroupBox1.TabIndex = 4
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Font Style"
			Me.cmbFonts.FormattingEnabled = True
			Me.cmbFonts.Items.AddRange(New Object() { "Select Font" })
			Me.cmbFonts.Location = New Global.System.Drawing.Point(7, 20)
			Me.cmbFonts.Name = "cmbFonts"
			Me.cmbFonts.Size = New Global.System.Drawing.Size(167, 21)
			Me.cmbFonts.TabIndex = 0
			Me.cmbFontSize.FormattingEnabled = True
			Me.cmbFontSize.Items.AddRange(New Object() { "Size" })
			Me.cmbFontSize.Location = New Global.System.Drawing.Point(180, 20)
			Me.cmbFontSize.Name = "cmbFontSize"
			Me.cmbFontSize.Size = New Global.System.Drawing.Size(54, 21)
			Me.cmbFontSize.TabIndex = 1
			Me.btnBold.BackColor = Global.System.Drawing.Color.White
			Me.btnBold.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.None
			Me.btnBold.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnBold.Location = New Global.System.Drawing.Point(240, 18)
			Me.btnBold.Name = "btnBold"
			Me.btnBold.Size = New Global.System.Drawing.Size(28, 23)
			Me.btnBold.TabIndex = 4
			Me.btnBold.Text = "B"
			Me.btnBold.UseVisualStyleBackColor = False
			Me.btnItalic.BackColor = Global.System.Drawing.Color.White
			Me.btnItalic.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.None
			Me.btnItalic.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Italic, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnItalic.Location = New Global.System.Drawing.Point(274, 18)
			Me.btnItalic.Name = "btnItalic"
			Me.btnItalic.Size = New Global.System.Drawing.Size(28, 23)
			Me.btnItalic.TabIndex = 5
			Me.btnItalic.Text = "I"
			Me.btnItalic.UseVisualStyleBackColor = False
			Me.btnUnderline.BackColor = Global.System.Drawing.Color.White
			Me.btnUnderline.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.None
			Me.btnUnderline.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Underline, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnUnderline.Location = New Global.System.Drawing.Point(308, 18)
			Me.btnUnderline.Name = "btnUnderline"
			Me.btnUnderline.Size = New Global.System.Drawing.Size(28, 23)
			Me.btnUnderline.TabIndex = 6
			Me.btnUnderline.Text = "U"
			Me.btnUnderline.UseVisualStyleBackColor = False
			Me.btnColor.BackColor = Global.System.Drawing.Color.White
			Me.btnColor.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.None
			Me.btnColor.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnColor.Location = New Global.System.Drawing.Point(342, 18)
			Me.btnColor.Name = "btnColor"
			Me.btnColor.Size = New Global.System.Drawing.Size(46, 23)
			Me.btnColor.TabIndex = 7
			Me.btnColor.Text = "Color"
			Me.btnColor.UseVisualStyleBackColor = False
			Me.cmbAlignment.FormattingEnabled = True
			Me.cmbAlignment.Items.AddRange(New Object() { "Left", "Right", "Center", "Justify" })
			Me.cmbAlignment.Location = New Global.System.Drawing.Point(394, 18)
			Me.cmbAlignment.Name = "cmbAlignment"
			Me.cmbAlignment.Size = New Global.System.Drawing.Size(54, 21)
			Me.cmbAlignment.TabIndex = 8
			Me.lblHidden.AutoSize = True
			Me.lblHidden.Location = New Global.System.Drawing.Point(175, 48)
			Me.lblHidden.Name = "lblHidden"
			Me.lblHidden.Size = New Global.System.Drawing.Size(61, 13)
			Me.lblHidden.TabIndex = 5
			Me.lblHidden.Text = "LabelName"
			Me.lblHidden.Visible = False
			Me.FontFamilyToolStripMenuItem.DropDownItems.AddRange(New Global.System.Windows.Forms.ToolStripItem() { Me.ToolStripCmbFonts })
			Me.FontFamilyToolStripMenuItem.Name = "FontFamilyToolStripMenuItem"
			Me.FontFamilyToolStripMenuItem.Size = New Global.System.Drawing.Size(152, 22)
			Me.FontFamilyToolStripMenuItem.Text = "Font Family"
			Me.ToolStripCmbFonts.FlatStyle = Global.System.Windows.Forms.FlatStyle.Standard
			Me.ToolStripCmbFonts.Items.AddRange(New Object() { "Select Font" })
			Me.ToolStripCmbFonts.Name = "ToolStripCmbFonts"
			Me.ToolStripCmbFonts.Size = New Global.System.Drawing.Size(121, 23)
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(760, 423)
			MyBase.Controls.Add(Me.lblHidden)
			MyBase.Controls.Add(Me.GroupBox1)
			MyBase.Controls.Add(Me.btnAddLabel)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.Name = "Form1"
			Me.Text = "Form1"
			Me.ContextMenuStrip1.ResumeLayout(False)
			Me.GroupBox1.ResumeLayout(False)
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040002A8 RID: 680
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
