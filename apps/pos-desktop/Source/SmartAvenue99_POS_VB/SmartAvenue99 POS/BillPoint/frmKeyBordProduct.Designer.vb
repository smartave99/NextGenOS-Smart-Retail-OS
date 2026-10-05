Namespace BillPoint
	' Token: 0x02000126 RID: 294
		Public Partial Class frmKeyBordProduct
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600327D RID: 12925 RVA: 0x001F2D08 File Offset: 0x001F0F08
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

		' Token: 0x0600327E RID: 12926 RVA: 0x001F2D58 File Offset: 0x001F0F58
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmKeyBordProduct))
			Me.TableLayoutPanel6 = New Global.System.Windows.Forms.TableLayoutPanel()
			Me.btnWallet = New Global.GelButtons.GelButton()
			Me.btnDebitCard = New Global.GelButtons.GelButton()
			Me.btnCreditCard = New Global.GelButtons.GelButton()
			Me.btnCash = New Global.GelButtons.GelButton()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.GelButton5 = New Global.GelButtons.GelButton()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.GelButton7 = New Global.GelButtons.GelButton()
			Me.GelButton8 = New Global.GelButtons.GelButton()
			Me.GelButton9 = New Global.GelButtons.GelButton()
			Me.GelButton10 = New Global.GelButtons.GelButton()
			Me.GelButton11 = New Global.GelButtons.GelButton()
			Me.GelButton12 = New Global.GelButtons.GelButton()
			Me.GelButton13 = New Global.GelButtons.GelButton()
			Me.GelButton14 = New Global.GelButtons.GelButton()
			Me.GelButton15 = New Global.GelButtons.GelButton()
			Me.GelButton16 = New Global.GelButtons.GelButton()
			Me.GelButton17 = New Global.GelButtons.GelButton()
			Me.GelButton18 = New Global.GelButtons.GelButton()
			Me.GelButton19 = New Global.GelButtons.GelButton()
			Me.GelButton20 = New Global.GelButtons.GelButton()
			Me.GelButton21 = New Global.GelButtons.GelButton()
			Me.GelButton22 = New Global.GelButtons.GelButton()
			Me.GelButton23 = New Global.GelButtons.GelButton()
			Me.GelButton6 = New Global.GelButtons.GelButton()
			Me.GelButton26 = New Global.GelButtons.GelButton()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.TableLayoutPanel6.SuspendLayout()
			MyBase.SuspendLayout()
			Me.TableLayoutPanel6.ColumnCount = 6
			Me.TableLayoutPanel6.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle())
			Me.TableLayoutPanel6.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Absolute, 135F))
			Me.TableLayoutPanel6.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Absolute, 138F))
			Me.TableLayoutPanel6.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Absolute, 127F))
			Me.TableLayoutPanel6.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Absolute, 117F))
			Me.TableLayoutPanel6.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Absolute, 31F))
			Me.TableLayoutPanel6.Controls.Add(Me.btnWallet, 0, 3)
			Me.TableLayoutPanel6.Controls.Add(Me.btnDebitCard, 0, 2)
			Me.TableLayoutPanel6.Controls.Add(Me.btnCreditCard, 0, 1)
			Me.TableLayoutPanel6.Controls.Add(Me.btnCash, 0, 0)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton3, 1, 0)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton5, 2, 0)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton1, 3, 0)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton7, 4, 0)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton8, 5, 0)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton9, 1, 1)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton10, 2, 1)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton11, 3, 1)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton12, 4, 1)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton13, 5, 1)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton14, 1, 2)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton15, 2, 2)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton16, 3, 2)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton17, 4, 2)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton18, 5, 2)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton19, 1, 3)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton20, 2, 3)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton21, 3, 3)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton22, 4, 3)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton23, 5, 3)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton6, 2, 4)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton26, 3, 4)
			Me.TableLayoutPanel6.Controls.Add(Me.GelButton2, 5, 4)
			Me.TableLayoutPanel6.Controls.Add(Me.Label1, 0, 4)
			Me.TableLayoutPanel6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TableLayoutPanel6.Location = New Global.System.Drawing.Point(12, 9)
			Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
			Me.TableLayoutPanel6.RowCount = 5
			Me.TableLayoutPanel6.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 19.9992F))
			Me.TableLayoutPanel6.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 19.9992F))
			Me.TableLayoutPanel6.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 19.9992F))
			Me.TableLayoutPanel6.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 19.9992F))
			Me.TableLayoutPanel6.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 20.0032F))
			Me.TableLayoutPanel6.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Absolute, 20F))
			Me.TableLayoutPanel6.Size = New Global.System.Drawing.Size(776, 432)
			Me.TableLayoutPanel6.TabIndex = 504
			Me.btnWallet.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnWallet.BackColor = Global.System.Drawing.Color.SaddleBrown
			Me.btnWallet.FlatAppearance.BorderSize = 0
			Me.btnWallet.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnWallet.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnWallet.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.btnWallet.GradientBottom = Global.System.Drawing.Color.MediumVioletRed
			Me.btnWallet.GradientTop = Global.System.Drawing.Color.DeepPink
			Me.btnWallet.Image = CType(componentResourceManager.GetObject("btnWallet.Image"), Global.System.Drawing.Image)
			Me.btnWallet.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnWallet.Location = New Global.System.Drawing.Point(3, 261)
			Me.btnWallet.Name = "btnWallet"
			Me.btnWallet.Size = New Global.System.Drawing.Size(139, 80)
			Me.btnWallet.TabIndex = 17
			Me.btnWallet.Text = "S"
			Me.btnWallet.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnWallet.UseVisualStyleBackColor = False
			Me.btnDebitCard.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnDebitCard.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnDebitCard.FlatAppearance.BorderSize = 0
			Me.btnDebitCard.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnDebitCard.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnDebitCard.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.btnDebitCard.GradientBottom = Global.System.Drawing.Color.DarkMagenta
			Me.btnDebitCard.GradientTop = Global.System.Drawing.Color.Purple
			Me.btnDebitCard.Image = CType(componentResourceManager.GetObject("btnDebitCard.Image"), Global.System.Drawing.Image)
			Me.btnDebitCard.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnDebitCard.Location = New Global.System.Drawing.Point(3, 175)
			Me.btnDebitCard.Name = "btnDebitCard"
			Me.btnDebitCard.Size = New Global.System.Drawing.Size(139, 80)
			Me.btnDebitCard.TabIndex = 16
			Me.btnDebitCard.Text = "M"
			Me.btnDebitCard.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnDebitCard.UseVisualStyleBackColor = False
			Me.btnCreditCard.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnCreditCard.BackColor = Global.System.Drawing.Color.SlateBlue
			Me.btnCreditCard.FlatAppearance.BorderSize = 0
			Me.btnCreditCard.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnCreditCard.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnCreditCard.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.btnCreditCard.GradientBottom = Global.System.Drawing.Color.DarkOrchid
			Me.btnCreditCard.GradientTop = Global.System.Drawing.Color.DarkViolet
			Me.btnCreditCard.Image = CType(componentResourceManager.GetObject("btnCreditCard.Image"), Global.System.Drawing.Image)
			Me.btnCreditCard.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnCreditCard.Location = New Global.System.Drawing.Point(3, 89)
			Me.btnCreditCard.Name = "btnCreditCard"
			Me.btnCreditCard.Size = New Global.System.Drawing.Size(139, 80)
			Me.btnCreditCard.TabIndex = 15
			Me.btnCreditCard.Text = "G"
			Me.btnCreditCard.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnCreditCard.UseVisualStyleBackColor = False
			Me.btnCash.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnCash.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.btnCash.FlatAppearance.BorderSize = 0
			Me.btnCash.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnCash.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnCash.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.btnCash.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnCash.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnCash.Image = CType(componentResourceManager.GetObject("btnCash.Image"), Global.System.Drawing.Image)
			Me.btnCash.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnCash.Location = New Global.System.Drawing.Point(3, 3)
			Me.btnCash.Name = "btnCash"
			Me.btnCash.Size = New Global.System.Drawing.Size(139, 80)
			Me.btnCash.TabIndex = 14
			Me.btnCash.Text = "A"
			Me.btnCash.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnCash.UseVisualStyleBackColor = False
			Me.GelButton3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton3.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.GelButton3.FlatAppearance.BorderSize = 0
			Me.GelButton3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton3.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton3.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton3.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton3.Image = CType(componentResourceManager.GetObject("GelButton3.Image"), Global.System.Drawing.Image)
			Me.GelButton3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton3.Location = New Global.System.Drawing.Point(148, 3)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(129, 80)
			Me.GelButton3.TabIndex = 515
			Me.GelButton3.Text = "B"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.GelButton5.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton5.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.GelButton5.FlatAppearance.BorderSize = 0
			Me.GelButton5.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton5.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton5.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton5.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton5.Image = CType(componentResourceManager.GetObject("GelButton5.Image"), Global.System.Drawing.Image)
			Me.GelButton5.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton5.Location = New Global.System.Drawing.Point(283, 3)
			Me.GelButton5.Name = "GelButton5"
			Me.GelButton5.Size = New Global.System.Drawing.Size(132, 80)
			Me.GelButton5.TabIndex = 516
			Me.GelButton5.Text = "C"
			Me.GelButton5.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton5.UseVisualStyleBackColor = False
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(421, 3)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(121, 80)
			Me.GelButton1.TabIndex = 513
			Me.GelButton1.Text = "D"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.GelButton7.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton7.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.GelButton7.FlatAppearance.BorderSize = 0
			Me.GelButton7.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton7.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton7.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton7.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton7.Image = CType(componentResourceManager.GetObject("GelButton7.Image"), Global.System.Drawing.Image)
			Me.GelButton7.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton7.Location = New Global.System.Drawing.Point(548, 3)
			Me.GelButton7.Name = "GelButton7"
			Me.GelButton7.Size = New Global.System.Drawing.Size(111, 80)
			Me.GelButton7.TabIndex = 518
			Me.GelButton7.Text = "E"
			Me.GelButton7.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton7.UseVisualStyleBackColor = False
			Me.GelButton8.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton8.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.GelButton8.FlatAppearance.BorderSize = 0
			Me.GelButton8.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton8.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton8.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton8.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton8.Image = CType(componentResourceManager.GetObject("GelButton8.Image"), Global.System.Drawing.Image)
			Me.GelButton8.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton8.Location = New Global.System.Drawing.Point(665, 3)
			Me.GelButton8.Name = "GelButton8"
			Me.GelButton8.Size = New Global.System.Drawing.Size(108, 80)
			Me.GelButton8.TabIndex = 520
			Me.GelButton8.Text = "F"
			Me.GelButton8.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton8.UseVisualStyleBackColor = False
			Me.GelButton9.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton9.BackColor = Global.System.Drawing.Color.SlateBlue
			Me.GelButton9.FlatAppearance.BorderSize = 0
			Me.GelButton9.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton9.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton9.GradientBottom = Global.System.Drawing.Color.DarkOrchid
			Me.GelButton9.GradientTop = Global.System.Drawing.Color.DarkViolet
			Me.GelButton9.Image = CType(componentResourceManager.GetObject("GelButton9.Image"), Global.System.Drawing.Image)
			Me.GelButton9.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton9.Location = New Global.System.Drawing.Point(148, 89)
			Me.GelButton9.Name = "GelButton9"
			Me.GelButton9.Size = New Global.System.Drawing.Size(129, 80)
			Me.GelButton9.TabIndex = 521
			Me.GelButton9.Text = "H"
			Me.GelButton9.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton9.UseVisualStyleBackColor = False
			Me.GelButton10.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton10.BackColor = Global.System.Drawing.Color.SlateBlue
			Me.GelButton10.FlatAppearance.BorderSize = 0
			Me.GelButton10.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton10.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton10.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton10.GradientBottom = Global.System.Drawing.Color.DarkOrchid
			Me.GelButton10.GradientTop = Global.System.Drawing.Color.DarkViolet
			Me.GelButton10.Image = CType(componentResourceManager.GetObject("GelButton10.Image"), Global.System.Drawing.Image)
			Me.GelButton10.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton10.Location = New Global.System.Drawing.Point(283, 89)
			Me.GelButton10.Name = "GelButton10"
			Me.GelButton10.Size = New Global.System.Drawing.Size(132, 80)
			Me.GelButton10.TabIndex = 522
			Me.GelButton10.Text = "I"
			Me.GelButton10.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton10.UseVisualStyleBackColor = False
			Me.GelButton11.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton11.BackColor = Global.System.Drawing.Color.SlateBlue
			Me.GelButton11.FlatAppearance.BorderSize = 0
			Me.GelButton11.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton11.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton11.GradientBottom = Global.System.Drawing.Color.DarkOrchid
			Me.GelButton11.GradientTop = Global.System.Drawing.Color.DarkViolet
			Me.GelButton11.Image = CType(componentResourceManager.GetObject("GelButton11.Image"), Global.System.Drawing.Image)
			Me.GelButton11.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton11.Location = New Global.System.Drawing.Point(421, 89)
			Me.GelButton11.Name = "GelButton11"
			Me.GelButton11.Size = New Global.System.Drawing.Size(121, 80)
			Me.GelButton11.TabIndex = 523
			Me.GelButton11.Text = "J"
			Me.GelButton11.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton11.UseVisualStyleBackColor = False
			Me.GelButton12.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton12.BackColor = Global.System.Drawing.Color.SlateBlue
			Me.GelButton12.FlatAppearance.BorderSize = 0
			Me.GelButton12.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton12.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton12.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton12.GradientBottom = Global.System.Drawing.Color.DarkOrchid
			Me.GelButton12.GradientTop = Global.System.Drawing.Color.DarkViolet
			Me.GelButton12.Image = CType(componentResourceManager.GetObject("GelButton12.Image"), Global.System.Drawing.Image)
			Me.GelButton12.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton12.Location = New Global.System.Drawing.Point(548, 89)
			Me.GelButton12.Name = "GelButton12"
			Me.GelButton12.Size = New Global.System.Drawing.Size(111, 80)
			Me.GelButton12.TabIndex = 524
			Me.GelButton12.Text = "K"
			Me.GelButton12.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton12.UseVisualStyleBackColor = False
			Me.GelButton13.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton13.BackColor = Global.System.Drawing.Color.SlateBlue
			Me.GelButton13.FlatAppearance.BorderSize = 0
			Me.GelButton13.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton13.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton13.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton13.GradientBottom = Global.System.Drawing.Color.DarkOrchid
			Me.GelButton13.GradientTop = Global.System.Drawing.Color.DarkViolet
			Me.GelButton13.Image = CType(componentResourceManager.GetObject("GelButton13.Image"), Global.System.Drawing.Image)
			Me.GelButton13.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton13.Location = New Global.System.Drawing.Point(665, 89)
			Me.GelButton13.Name = "GelButton13"
			Me.GelButton13.Size = New Global.System.Drawing.Size(108, 80)
			Me.GelButton13.TabIndex = 525
			Me.GelButton13.Text = "L"
			Me.GelButton13.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton13.UseVisualStyleBackColor = False
			Me.GelButton14.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton14.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.GelButton14.FlatAppearance.BorderSize = 0
			Me.GelButton14.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton14.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton14.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton14.GradientBottom = Global.System.Drawing.Color.DarkMagenta
			Me.GelButton14.GradientTop = Global.System.Drawing.Color.Purple
			Me.GelButton14.Image = CType(componentResourceManager.GetObject("GelButton14.Image"), Global.System.Drawing.Image)
			Me.GelButton14.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton14.Location = New Global.System.Drawing.Point(148, 175)
			Me.GelButton14.Name = "GelButton14"
			Me.GelButton14.Size = New Global.System.Drawing.Size(129, 80)
			Me.GelButton14.TabIndex = 526
			Me.GelButton14.Text = "N"
			Me.GelButton14.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton14.UseVisualStyleBackColor = False
			Me.GelButton15.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton15.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.GelButton15.FlatAppearance.BorderSize = 0
			Me.GelButton15.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton15.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton15.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton15.GradientBottom = Global.System.Drawing.Color.DarkMagenta
			Me.GelButton15.GradientTop = Global.System.Drawing.Color.Purple
			Me.GelButton15.Image = CType(componentResourceManager.GetObject("GelButton15.Image"), Global.System.Drawing.Image)
			Me.GelButton15.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton15.Location = New Global.System.Drawing.Point(283, 175)
			Me.GelButton15.Name = "GelButton15"
			Me.GelButton15.Size = New Global.System.Drawing.Size(132, 80)
			Me.GelButton15.TabIndex = 527
			Me.GelButton15.Text = "O"
			Me.GelButton15.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton15.UseVisualStyleBackColor = False
			Me.GelButton16.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton16.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.GelButton16.FlatAppearance.BorderSize = 0
			Me.GelButton16.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton16.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton16.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton16.GradientBottom = Global.System.Drawing.Color.DarkMagenta
			Me.GelButton16.GradientTop = Global.System.Drawing.Color.Purple
			Me.GelButton16.Image = CType(componentResourceManager.GetObject("GelButton16.Image"), Global.System.Drawing.Image)
			Me.GelButton16.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton16.Location = New Global.System.Drawing.Point(421, 175)
			Me.GelButton16.Name = "GelButton16"
			Me.GelButton16.Size = New Global.System.Drawing.Size(121, 80)
			Me.GelButton16.TabIndex = 528
			Me.GelButton16.Text = "P"
			Me.GelButton16.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton16.UseVisualStyleBackColor = False
			Me.GelButton17.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton17.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.GelButton17.FlatAppearance.BorderSize = 0
			Me.GelButton17.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton17.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton17.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton17.GradientBottom = Global.System.Drawing.Color.DarkMagenta
			Me.GelButton17.GradientTop = Global.System.Drawing.Color.Purple
			Me.GelButton17.Image = CType(componentResourceManager.GetObject("GelButton17.Image"), Global.System.Drawing.Image)
			Me.GelButton17.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton17.Location = New Global.System.Drawing.Point(548, 175)
			Me.GelButton17.Name = "GelButton17"
			Me.GelButton17.Size = New Global.System.Drawing.Size(111, 80)
			Me.GelButton17.TabIndex = 529
			Me.GelButton17.Text = "Q"
			Me.GelButton17.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton17.UseVisualStyleBackColor = False
			Me.GelButton18.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton18.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.GelButton18.FlatAppearance.BorderSize = 0
			Me.GelButton18.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton18.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton18.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton18.GradientBottom = Global.System.Drawing.Color.DarkMagenta
			Me.GelButton18.GradientTop = Global.System.Drawing.Color.Purple
			Me.GelButton18.Image = CType(componentResourceManager.GetObject("GelButton18.Image"), Global.System.Drawing.Image)
			Me.GelButton18.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton18.Location = New Global.System.Drawing.Point(665, 175)
			Me.GelButton18.Name = "GelButton18"
			Me.GelButton18.Size = New Global.System.Drawing.Size(108, 80)
			Me.GelButton18.TabIndex = 530
			Me.GelButton18.Text = "R"
			Me.GelButton18.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton18.UseVisualStyleBackColor = False
			Me.GelButton19.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton19.BackColor = Global.System.Drawing.Color.SaddleBrown
			Me.GelButton19.FlatAppearance.BorderSize = 0
			Me.GelButton19.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton19.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton19.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton19.GradientBottom = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton19.GradientTop = Global.System.Drawing.Color.DeepPink
			Me.GelButton19.Image = CType(componentResourceManager.GetObject("GelButton19.Image"), Global.System.Drawing.Image)
			Me.GelButton19.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton19.Location = New Global.System.Drawing.Point(148, 261)
			Me.GelButton19.Name = "GelButton19"
			Me.GelButton19.Size = New Global.System.Drawing.Size(129, 80)
			Me.GelButton19.TabIndex = 531
			Me.GelButton19.Text = "T"
			Me.GelButton19.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton19.UseVisualStyleBackColor = False
			Me.GelButton20.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton20.BackColor = Global.System.Drawing.Color.SaddleBrown
			Me.GelButton20.FlatAppearance.BorderSize = 0
			Me.GelButton20.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton20.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton20.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton20.GradientBottom = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton20.GradientTop = Global.System.Drawing.Color.DeepPink
			Me.GelButton20.Image = CType(componentResourceManager.GetObject("GelButton20.Image"), Global.System.Drawing.Image)
			Me.GelButton20.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton20.Location = New Global.System.Drawing.Point(283, 261)
			Me.GelButton20.Name = "GelButton20"
			Me.GelButton20.Size = New Global.System.Drawing.Size(132, 80)
			Me.GelButton20.TabIndex = 532
			Me.GelButton20.Text = "U"
			Me.GelButton20.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton20.UseVisualStyleBackColor = False
			Me.GelButton21.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton21.BackColor = Global.System.Drawing.Color.SaddleBrown
			Me.GelButton21.FlatAppearance.BorderSize = 0
			Me.GelButton21.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton21.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton21.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton21.GradientBottom = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton21.GradientTop = Global.System.Drawing.Color.DeepPink
			Me.GelButton21.Image = CType(componentResourceManager.GetObject("GelButton21.Image"), Global.System.Drawing.Image)
			Me.GelButton21.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton21.Location = New Global.System.Drawing.Point(421, 261)
			Me.GelButton21.Name = "GelButton21"
			Me.GelButton21.Size = New Global.System.Drawing.Size(121, 80)
			Me.GelButton21.TabIndex = 533
			Me.GelButton21.Text = "V"
			Me.GelButton21.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton21.UseVisualStyleBackColor = False
			Me.GelButton22.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton22.BackColor = Global.System.Drawing.Color.SaddleBrown
			Me.GelButton22.FlatAppearance.BorderSize = 0
			Me.GelButton22.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton22.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton22.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton22.GradientBottom = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton22.GradientTop = Global.System.Drawing.Color.DeepPink
			Me.GelButton22.Image = CType(componentResourceManager.GetObject("GelButton22.Image"), Global.System.Drawing.Image)
			Me.GelButton22.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton22.Location = New Global.System.Drawing.Point(548, 261)
			Me.GelButton22.Name = "GelButton22"
			Me.GelButton22.Size = New Global.System.Drawing.Size(111, 80)
			Me.GelButton22.TabIndex = 534
			Me.GelButton22.Text = "W"
			Me.GelButton22.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton22.UseVisualStyleBackColor = False
			Me.GelButton23.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton23.BackColor = Global.System.Drawing.Color.SaddleBrown
			Me.GelButton23.FlatAppearance.BorderSize = 0
			Me.GelButton23.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton23.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton23.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton23.GradientBottom = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton23.GradientTop = Global.System.Drawing.Color.DeepPink
			Me.GelButton23.Image = CType(componentResourceManager.GetObject("GelButton23.Image"), Global.System.Drawing.Image)
			Me.GelButton23.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton23.Location = New Global.System.Drawing.Point(665, 261)
			Me.GelButton23.Name = "GelButton23"
			Me.GelButton23.Size = New Global.System.Drawing.Size(108, 80)
			Me.GelButton23.TabIndex = 535
			Me.GelButton23.Text = "X"
			Me.GelButton23.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton23.UseVisualStyleBackColor = False
			Me.GelButton6.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton6.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton6.FlatAppearance.BorderSize = 0
			Me.GelButton6.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton6.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton6.GradientBottom = Global.System.Drawing.Color.OrangeRed
			Me.GelButton6.GradientTop = Global.System.Drawing.Color.OrangeRed
			Me.GelButton6.Image = CType(componentResourceManager.GetObject("GelButton6.Image"), Global.System.Drawing.Image)
			Me.GelButton6.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton6.Location = New Global.System.Drawing.Point(283, 347)
			Me.GelButton6.Name = "GelButton6"
			Me.GelButton6.Size = New Global.System.Drawing.Size(132, 82)
			Me.GelButton6.TabIndex = 519
			Me.GelButton6.Text = "Y"
			Me.GelButton6.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton6.UseVisualStyleBackColor = False
			Me.GelButton26.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton26.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton26.FlatAppearance.BorderSize = 0
			Me.GelButton26.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton26.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 30F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton26.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton26.GradientBottom = Global.System.Drawing.Color.OrangeRed
			Me.GelButton26.GradientTop = Global.System.Drawing.Color.OrangeRed
			Me.GelButton26.Image = CType(componentResourceManager.GetObject("GelButton26.Image"), Global.System.Drawing.Image)
			Me.GelButton26.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton26.Location = New Global.System.Drawing.Point(421, 347)
			Me.GelButton26.Name = "GelButton26"
			Me.GelButton26.Size = New Global.System.Drawing.Size(121, 82)
			Me.GelButton26.TabIndex = 538
			Me.GelButton26.Text = "Z"
			Me.GelButton26.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton26.UseVisualStyleBackColor = False
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton2.GradientBottom = Global.System.Drawing.Color.Lime
			Me.GelButton2.GradientTop = Global.System.Drawing.Color.OrangeRed
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(665, 347)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(108, 82)
			Me.GelButton2.TabIndex = 539
			Me.GelButton2.Text = "CLEAR"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(3, 344)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(71, 25)
			Me.Label1.TabIndex = 540
			Me.Label1.Text = "Label1"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(800, 450)
			MyBase.Controls.Add(Me.TableLayoutPanel6)
			MyBase.Name = "frmKeyBordProduct"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "frmKeyBordProduct"
			Me.TableLayoutPanel6.ResumeLayout(False)
			Me.TableLayoutPanel6.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040015DA RID: 5594
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
