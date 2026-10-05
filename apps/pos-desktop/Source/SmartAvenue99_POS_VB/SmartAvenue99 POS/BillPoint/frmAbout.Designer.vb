Namespace BillPoint
	' Token: 0x020005DE RID: 1502
		Public NotInheritable Partial Class frmAbout
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06012709 RID: 75529 RVA: 0x00A9CE60 File Offset: 0x00A9B060
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

		' Token: 0x06012718 RID: 75544 RVA: 0x00A9CEB0 File Offset: 0x00A9B0B0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmAbout))
			Me.TableLayoutPanel = New Global.System.Windows.Forms.TableLayoutPanel()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.LogoPictureBox = New Global.System.Windows.Forms.PictureBox()
			Me.LabelProductName = New Global.System.Windows.Forms.Label()
			Me.LabelVersion = New Global.System.Windows.Forms.Label()
			Me.LabelCopyright = New Global.System.Windows.Forms.Label()
			Me.LabelCompanyName = New Global.System.Windows.Forms.Label()
			Me.TextBoxDescription = New Global.System.Windows.Forms.TextBox()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.LinkLabel1 = New Global.System.Windows.Forms.LinkLabel()
			Me.TableLayoutPanel.SuspendLayout()
			CType(Me.LogoPictureBox, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.TableLayoutPanel.ColumnCount = 2
			Me.TableLayoutPanel.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 33F))
			Me.TableLayoutPanel.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 67F))
			Me.TableLayoutPanel.Controls.Add(Me.Label6, 1, 5)
			Me.TableLayoutPanel.Controls.Add(Me.LogoPictureBox, 0, 0)
			Me.TableLayoutPanel.Controls.Add(Me.LabelProductName, 1, 0)
			Me.TableLayoutPanel.Controls.Add(Me.LabelVersion, 1, 1)
			Me.TableLayoutPanel.Controls.Add(Me.LabelCopyright, 1, 2)
			Me.TableLayoutPanel.Controls.Add(Me.LabelCompanyName, 1, 3)
			Me.TableLayoutPanel.Controls.Add(Me.TextBoxDescription, 1, 4)
			Me.TableLayoutPanel.Location = New Global.System.Drawing.Point(9, 70)
			Me.TableLayoutPanel.Name = "TableLayoutPanel"
			Me.TableLayoutPanel.RowCount = 6
			Me.TableLayoutPanel.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 10F))
			Me.TableLayoutPanel.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 10F))
			Me.TableLayoutPanel.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 10F))
			Me.TableLayoutPanel.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 10F))
			Me.TableLayoutPanel.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 52.83843F))
			Me.TableLayoutPanel.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 8.733624F))
			Me.TableLayoutPanel.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Absolute, 20F))
			Me.TableLayoutPanel.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Absolute, 20F))
			Me.TableLayoutPanel.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Absolute, 20F))
			Me.TableLayoutPanel.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Absolute, 20F))
			Me.TableLayoutPanel.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Absolute, 20F))
			Me.TableLayoutPanel.Size = New Global.System.Drawing.Size(613, 229)
			Me.TableLayoutPanel.TabIndex = 0
			Me.Label6.AutoSize = True
			Me.Label6.Dock = Global.System.Windows.Forms.DockStyle.Right
			Me.Label6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F)
			Me.Label6.ForeColor = Global.System.Drawing.Color.Purple
			Me.Label6.Location = New Global.System.Drawing.Point(598, 207)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(12, 22)
			Me.Label6.TabIndex = 6
			Me.Label6.Text = "."
			Me.LogoPictureBox.Image = Nothing
			Me.LogoPictureBox.Location = New Global.System.Drawing.Point(3, 3)
			Me.LogoPictureBox.Name = "LogoPictureBox"
			Me.TableLayoutPanel.SetRowSpan(Me.LogoPictureBox, 6)
			Me.LogoPictureBox.Size = New Global.System.Drawing.Size(196, 201)
			Me.LogoPictureBox.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.LogoPictureBox.TabIndex = 0
			Me.LogoPictureBox.TabStop = False
			Me.LabelProductName.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.LabelProductName.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LabelProductName.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 192)
			Me.LabelProductName.Location = New Global.System.Drawing.Point(208, 0)
			Me.LabelProductName.Margin = New Global.System.Windows.Forms.Padding(6, 0, 3, 0)
			Me.LabelProductName.MaximumSize = New Global.System.Drawing.Size(0, 17)
			Me.LabelProductName.Name = "LabelProductName"
			Me.LabelProductName.Size = New Global.System.Drawing.Size(402, 17)
			Me.LabelProductName.TabIndex = 0
			Me.LabelProductName.Text = "Product Name"
			Me.LabelProductName.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.LabelVersion.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.LabelVersion.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LabelVersion.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 192)
			Me.LabelVersion.Location = New Global.System.Drawing.Point(208, 22)
			Me.LabelVersion.Margin = New Global.System.Windows.Forms.Padding(6, 0, 3, 0)
			Me.LabelVersion.MaximumSize = New Global.System.Drawing.Size(0, 17)
			Me.LabelVersion.Name = "LabelVersion"
			Me.LabelVersion.Size = New Global.System.Drawing.Size(402, 17)
			Me.LabelVersion.TabIndex = 0
			Me.LabelVersion.Text = "Version"
			Me.LabelVersion.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.LabelCopyright.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.LabelCopyright.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LabelCopyright.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 192)
			Me.LabelCopyright.Location = New Global.System.Drawing.Point(208, 44)
			Me.LabelCopyright.Margin = New Global.System.Windows.Forms.Padding(6, 0, 3, 0)
			Me.LabelCopyright.MaximumSize = New Global.System.Drawing.Size(0, 17)
			Me.LabelCopyright.Name = "LabelCopyright"
			Me.LabelCopyright.Size = New Global.System.Drawing.Size(402, 17)
			Me.LabelCopyright.TabIndex = 0
			Me.LabelCopyright.Text = "Copyright"
			Me.LabelCopyright.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.LabelCompanyName.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.LabelCompanyName.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LabelCompanyName.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 192)
			Me.LabelCompanyName.Location = New Global.System.Drawing.Point(208, 66)
			Me.LabelCompanyName.Margin = New Global.System.Windows.Forms.Padding(6, 0, 3, 0)
			Me.LabelCompanyName.MaximumSize = New Global.System.Drawing.Size(0, 17)
			Me.LabelCompanyName.Name = "LabelCompanyName"
			Me.LabelCompanyName.Size = New Global.System.Drawing.Size(402, 17)
			Me.LabelCompanyName.TabIndex = 0
			Me.LabelCompanyName.Text = "Company Name"
			Me.LabelCompanyName.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.TextBoxDescription.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBoxDescription.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.TextBoxDescription.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBoxDescription.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 192)
			Me.TextBoxDescription.Location = New Global.System.Drawing.Point(208, 91)
			Me.TextBoxDescription.Margin = New Global.System.Windows.Forms.Padding(6, 3, 3, 3)
			Me.TextBoxDescription.Multiline = True
			Me.TextBoxDescription.Name = "TextBoxDescription"
			Me.TextBoxDescription.[ReadOnly] = True
			Me.TextBoxDescription.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.TextBoxDescription.Size = New Global.System.Drawing.Size(402, 113)
			Me.TextBoxDescription.TabIndex = 0
			Me.TextBoxDescription.TabStop = False
			Me.TextBoxDescription.Text = "NextGen OS" & vbCrLf & "Smart Retail OS" & vbCrLf & "Email : support@nextgenos.com" & vbCrLf & "Website : https://nextgenos.com" & vbCrLf & "Phone : +918606093110"
			Me.Panel1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Controls.Add(Me.Label4)
			Me.Panel1.Controls.Add(Me.Label3)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Location = New Global.System.Drawing.Point(9, 9)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(613, 55)
			Me.Panel1.TabIndex = 1
			Me.Label5.AutoSize = True
			Me.Label5.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.ForeColor = Global.System.Drawing.Color.Yellow
			Me.Label5.Location = New Global.System.Drawing.Point(411, 32)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(76, 17)
			Me.Label5.TabIndex = 4
			Me.Label5.Text = "Days Left"
			Me.Label5.Visible = False
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.ForeColor = Global.System.Drawing.Color.White
			Me.Label4.Location = New Global.System.Drawing.Point(178, 32)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(61, 17)
			Me.Label4.TabIndex = 3
			Me.Label4.Text = "Validity"
			Me.Label4.Visible = False
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.ForeColor = Global.System.Drawing.Color.White
			Me.Label3.Location = New Global.System.Drawing.Point(178, 6)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(50, 17)
			Me.Label3.TabIndex = 2
			Me.Label3.Text = "Name"
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.White
			Me.Label2.Location = New Global.System.Drawing.Point(1, 32)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(152, 17)
			Me.Label2.TabIndex = 1
			Me.Label2.Text = "License Valid Upto :"
			Me.Label2.Visible = False
			Me.Label1.AutoSize = True
			Me.Label1.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(1, 6)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(180, 17)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "License Registered To :"
			Me.LinkLabel1.AutoSize = True
			Me.LinkLabel1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.LinkLabel1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LinkLabel1.Location = New Global.System.Drawing.Point(9, 277)
			Me.LinkLabel1.Name = "LinkLabel1"
			Me.LinkLabel1.Size = New Global.System.Drawing.Size(75, 18)
			Me.LinkLabel1.TabIndex = 5
			Me.LinkLabel1.TabStop = True
			Me.LinkLabel1.Text = "Download"
			Me.LinkLabel1.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			MyBase.ClientSize = New Global.System.Drawing.Size(631, 309)
			MyBase.Controls.Add(Me.LinkLabel1)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.Controls.Add(Me.TableLayoutPanel)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedDialog
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmAbout"
			MyBase.Padding = New Global.System.Windows.Forms.Padding(9)
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.TableLayoutPanel.ResumeLayout(False)
			Me.TableLayoutPanel.PerformLayout()
			CType(Me.LogoPictureBox, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04006EF3 RID: 28403
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
