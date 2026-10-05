Namespace BillPoint
	' Token: 0x02000313 RID: 787
	Public Partial Class Calculator
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600BC2B RID: 48171 RVA: 0x0078BFA4 File Offset: 0x0078A1A4
		Protected Overrides Sub Dispose(disposing As Boolean)
			If disposing Then
				Dim flag As Boolean = Me.components IsNot Nothing
				If flag Then
					Me.components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		' Token: 0x0600BC66 RID: 48230 RVA: 0x0078C6C4 File Offset: 0x0078A8C4
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.Calculator))
			Me.btnSqrt = New Global.System.Windows.Forms.Button()
			Me.btnPercentage = New Global.System.Windows.Forms.Button()
			Me.btnMC = New Global.System.Windows.Forms.Button()
			Me.btn3 = New Global.System.Windows.Forms.Button()
			Me.btnPoint = New Global.System.Windows.Forms.Button()
			Me.btnNegSign = New Global.System.Windows.Forms.Button()
			Me.btn7 = New Global.System.Windows.Forms.Button()
			Me.btn4 = New Global.System.Windows.Forms.Button()
			Me.btn2 = New Global.System.Windows.Forms.Button()
			Me.btnMNeg = New Global.System.Windows.Forms.Button()
			Me.btn5 = New Global.System.Windows.Forms.Button()
			Me.btnBack = New Global.System.Windows.Forms.Button()
			Me.btn8 = New Global.System.Windows.Forms.Button()
			Me.btn6 = New Global.System.Windows.Forms.Button()
			Me.btn9 = New Global.System.Windows.Forms.Button()
			Me.btnMR = New Global.System.Windows.Forms.Button()
			Me.btn0 = New Global.System.Windows.Forms.Button()
			Me.btn1 = New Global.System.Windows.Forms.Button()
			Me.btnMPos = New Global.System.Windows.Forms.Button()
			Me.btnClear = New Global.System.Windows.Forms.Button()
			Me.MainMenu1 = New Global.System.Windows.Forms.MainMenu(Me.components)
			Me.lblMemory = New Global.System.Windows.Forms.Label()
			Me.lblDisplay = New Global.System.Windows.Forms.Label()
			Me.txtHiden = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.btnTimes = New Global.System.Windows.Forms.Button()
			Me.btnEqual = New Global.System.Windows.Forms.Button()
			Me.btnDivide = New Global.System.Windows.Forms.Button()
			Me.btnMinus = New Global.System.Windows.Forms.Button()
			Me.btnAdd = New Global.System.Windows.Forms.Button()
			MyBase.SuspendLayout()
			Me.btnSqrt.BackColor = Global.System.Drawing.Color.White
			Me.btnSqrt.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSqrt.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnSqrt.Font = New Global.System.Drawing.Font("Arial Narrow", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSqrt.Location = New Global.System.Drawing.Point(5, 94)
			Me.btnSqrt.Name = "btnSqrt"
			Me.btnSqrt.Size = New Global.System.Drawing.Size(45, 44)
			Me.btnSqrt.TabIndex = 1
			Me.btnSqrt.TabStop = False
			Me.btnSqrt.Text = "Sqrt"
			Me.btnSqrt.UseVisualStyleBackColor = False
			Me.btnPercentage.BackColor = Global.System.Drawing.Color.White
			Me.btnPercentage.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnPercentage.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnPercentage.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnPercentage.Location = New Global.System.Drawing.Point(56, 94)
			Me.btnPercentage.Name = "btnPercentage"
			Me.btnPercentage.Size = New Global.System.Drawing.Size(45, 44)
			Me.btnPercentage.TabIndex = 2
			Me.btnPercentage.TabStop = False
			Me.btnPercentage.Text = "%"
			Me.btnPercentage.UseVisualStyleBackColor = False
			Me.btnMC.BackColor = Global.System.Drawing.Color.White
			Me.btnMC.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnMC.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnMC.Font = New Global.System.Drawing.Font("Arial Narrow", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnMC.Location = New Global.System.Drawing.Point(5, 144)
			Me.btnMC.Name = "btnMC"
			Me.btnMC.Size = New Global.System.Drawing.Size(45, 44)
			Me.btnMC.TabIndex = 3
			Me.btnMC.TabStop = False
			Me.btnMC.Text = "MC"
			Me.btnMC.UseVisualStyleBackColor = False
			Me.btn3.BackColor = Global.System.Drawing.Color.White
			Me.btn3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btn3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btn3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btn3.Location = New Global.System.Drawing.Point(158, 244)
			Me.btn3.Name = "btn3"
			Me.btn3.Size = New Global.System.Drawing.Size(45, 44)
			Me.btn3.TabIndex = 4
			Me.btn3.TabStop = False
			Me.btn3.Text = "3"
			Me.btn3.UseVisualStyleBackColor = False
			Me.btnPoint.BackColor = Global.System.Drawing.Color.White
			Me.btnPoint.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnPoint.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnPoint.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnPoint.Location = New Global.System.Drawing.Point(158, 294)
			Me.btnPoint.Name = "btnPoint"
			Me.btnPoint.Size = New Global.System.Drawing.Size(45, 44)
			Me.btnPoint.TabIndex = 5
			Me.btnPoint.TabStop = False
			Me.btnPoint.Text = "."
			Me.btnPoint.UseVisualStyleBackColor = False
			Me.btnNegSign.BackColor = Global.System.Drawing.Color.White
			Me.btnNegSign.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnNegSign.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnNegSign.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnNegSign.Location = New Global.System.Drawing.Point(56, 294)
			Me.btnNegSign.Name = "btnNegSign"
			Me.btnNegSign.Size = New Global.System.Drawing.Size(45, 44)
			Me.btnNegSign.TabIndex = 6
			Me.btnNegSign.TabStop = False
			Me.btnNegSign.Text = "+/-"
			Me.btnNegSign.UseVisualStyleBackColor = False
			Me.btn7.BackColor = Global.System.Drawing.Color.White
			Me.btn7.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btn7.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btn7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btn7.Location = New Global.System.Drawing.Point(56, 144)
			Me.btn7.Name = "btn7"
			Me.btn7.Size = New Global.System.Drawing.Size(45, 44)
			Me.btn7.TabIndex = 8
			Me.btn7.TabStop = False
			Me.btn7.Text = "7"
			Me.btn7.UseVisualStyleBackColor = False
			Me.btn4.BackColor = Global.System.Drawing.Color.White
			Me.btn4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btn4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btn4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btn4.Location = New Global.System.Drawing.Point(56, 194)
			Me.btn4.Name = "btn4"
			Me.btn4.Size = New Global.System.Drawing.Size(45, 44)
			Me.btn4.TabIndex = 9
			Me.btn4.TabStop = False
			Me.btn4.Text = "4"
			Me.btn4.UseVisualStyleBackColor = False
			Me.btn2.BackColor = Global.System.Drawing.Color.White
			Me.btn2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btn2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btn2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btn2.Location = New Global.System.Drawing.Point(107, 244)
			Me.btn2.Name = "btn2"
			Me.btn2.Size = New Global.System.Drawing.Size(45, 44)
			Me.btn2.TabIndex = 10
			Me.btn2.TabStop = False
			Me.btn2.Text = "2"
			Me.btn2.UseVisualStyleBackColor = False
			Me.btnMNeg.BackColor = Global.System.Drawing.Color.White
			Me.btnMNeg.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnMNeg.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnMNeg.Font = New Global.System.Drawing.Font("Arial Narrow", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnMNeg.Location = New Global.System.Drawing.Point(5, 244)
			Me.btnMNeg.Name = "btnMNeg"
			Me.btnMNeg.Size = New Global.System.Drawing.Size(45, 44)
			Me.btnMNeg.TabIndex = 11
			Me.btnMNeg.TabStop = False
			Me.btnMNeg.Text = "M-"
			Me.btnMNeg.UseVisualStyleBackColor = False
			Me.btn5.BackColor = Global.System.Drawing.Color.White
			Me.btn5.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btn5.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btn5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btn5.Location = New Global.System.Drawing.Point(107, 194)
			Me.btn5.Name = "btn5"
			Me.btn5.Size = New Global.System.Drawing.Size(45, 44)
			Me.btn5.TabIndex = 12
			Me.btn5.TabStop = False
			Me.btn5.Text = "5"
			Me.btn5.UseVisualStyleBackColor = False
			Me.btnBack.BackColor = Global.System.Drawing.Color.White
			Me.btnBack.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnBack.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnBack.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnBack.Location = New Global.System.Drawing.Point(107, 94)
			Me.btnBack.Name = "btnBack"
			Me.btnBack.Size = New Global.System.Drawing.Size(96, 44)
			Me.btnBack.TabIndex = 13
			Me.btnBack.TabStop = False
			Me.btnBack.Text = "Backspace"
			Me.btnBack.UseVisualStyleBackColor = False
			Me.btn8.BackColor = Global.System.Drawing.Color.White
			Me.btn8.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btn8.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btn8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btn8.Location = New Global.System.Drawing.Point(107, 144)
			Me.btn8.Name = "btn8"
			Me.btn8.Size = New Global.System.Drawing.Size(45, 44)
			Me.btn8.TabIndex = 14
			Me.btn8.TabStop = False
			Me.btn8.Text = "8"
			Me.btn8.UseVisualStyleBackColor = False
			Me.btn6.BackColor = Global.System.Drawing.Color.White
			Me.btn6.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btn6.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btn6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btn6.Location = New Global.System.Drawing.Point(158, 194)
			Me.btn6.Name = "btn6"
			Me.btn6.Size = New Global.System.Drawing.Size(45, 44)
			Me.btn6.TabIndex = 15
			Me.btn6.TabStop = False
			Me.btn6.Text = "6"
			Me.btn6.UseVisualStyleBackColor = False
			Me.btn9.BackColor = Global.System.Drawing.Color.White
			Me.btn9.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btn9.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btn9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btn9.Location = New Global.System.Drawing.Point(158, 144)
			Me.btn9.Name = "btn9"
			Me.btn9.Size = New Global.System.Drawing.Size(45, 44)
			Me.btn9.TabIndex = 16
			Me.btn9.TabStop = False
			Me.btn9.Text = "9"
			Me.btn9.UseVisualStyleBackColor = False
			Me.btnMR.BackColor = Global.System.Drawing.Color.White
			Me.btnMR.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnMR.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnMR.Font = New Global.System.Drawing.Font("Arial Narrow", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnMR.Location = New Global.System.Drawing.Point(5, 194)
			Me.btnMR.Name = "btnMR"
			Me.btnMR.Size = New Global.System.Drawing.Size(45, 44)
			Me.btnMR.TabIndex = 18
			Me.btnMR.TabStop = False
			Me.btnMR.Text = "MR"
			Me.btnMR.UseVisualStyleBackColor = False
			Me.btn0.BackColor = Global.System.Drawing.Color.White
			Me.btn0.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btn0.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btn0.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btn0.Location = New Global.System.Drawing.Point(107, 294)
			Me.btn0.Name = "btn0"
			Me.btn0.Size = New Global.System.Drawing.Size(45, 44)
			Me.btn0.TabIndex = 19
			Me.btn0.TabStop = False
			Me.btn0.Text = "0"
			Me.btn0.UseVisualStyleBackColor = False
			Me.btn1.BackColor = Global.System.Drawing.Color.White
			Me.btn1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btn1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btn1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btn1.Location = New Global.System.Drawing.Point(56, 244)
			Me.btn1.Name = "btn1"
			Me.btn1.Size = New Global.System.Drawing.Size(45, 44)
			Me.btn1.TabIndex = 20
			Me.btn1.TabStop = False
			Me.btn1.Text = "1"
			Me.btn1.UseVisualStyleBackColor = False
			Me.btnMPos.BackColor = Global.System.Drawing.Color.White
			Me.btnMPos.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnMPos.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnMPos.Font = New Global.System.Drawing.Font("Arial Narrow", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnMPos.Location = New Global.System.Drawing.Point(5, 294)
			Me.btnMPos.Name = "btnMPos"
			Me.btnMPos.Size = New Global.System.Drawing.Size(45, 44)
			Me.btnMPos.TabIndex = 21
			Me.btnMPos.TabStop = False
			Me.btnMPos.Text = "M+"
			Me.btnMPos.UseVisualStyleBackColor = False
			Me.btnClear.BackColor = Global.System.Drawing.Color.White
			Me.btnClear.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnClear.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnClear.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnClear.ForeColor = Global.System.Drawing.Color.Red
			Me.btnClear.Location = New Global.System.Drawing.Point(209, 94)
			Me.btnClear.Name = "btnClear"
			Me.btnClear.Size = New Global.System.Drawing.Size(95, 44)
			Me.btnClear.TabIndex = 25
			Me.btnClear.TabStop = False
			Me.btnClear.Text = "CE/C"
			Me.btnClear.UseVisualStyleBackColor = False
			Me.lblMemory.BackColor = Global.System.Drawing.SystemColors.Info
			Me.lblMemory.Font = New Global.System.Drawing.Font("Arial", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblMemory.ForeColor = Global.System.Drawing.Color.Blue
			Me.lblMemory.Location = New Global.System.Drawing.Point(11, 43)
			Me.lblMemory.Name = "lblMemory"
			Me.lblMemory.Size = New Global.System.Drawing.Size(19, 24)
			Me.lblMemory.TabIndex = 26
			Me.lblMemory.Text = "M"
			Me.lblMemory.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lblMemory.Visible = False
			Me.lblDisplay.BackColor = Global.System.Drawing.SystemColors.Info
			Me.lblDisplay.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.lblDisplay.Font = New Global.System.Drawing.Font("Arial", 26.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblDisplay.Location = New Global.System.Drawing.Point(5, 5)
			Me.lblDisplay.Name = "lblDisplay"
			Me.lblDisplay.Size = New Global.System.Drawing.Size(299, 85)
			Me.lblDisplay.TabIndex = 27
			Me.lblDisplay.Text = "0"
			Me.lblDisplay.TextAlign = Global.System.Drawing.ContentAlignment.TopRight
			Me.txtHiden.Location = New Global.System.Drawing.Point(72, 24)
			Me.txtHiden.Name = "txtHiden"
			Me.txtHiden.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtHiden.TabIndex = 28
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.SystemColors.Info
			Me.Label1.ForeColor = Global.System.Drawing.Color.Red
			Me.Label1.Location = New Global.System.Drawing.Point(8, 72)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(10, 13)
			Me.Label1.TabIndex = 31
			Me.Label1.Text = "."
			Me.btnTimes.BackColor = Global.System.Drawing.Color.White
			Me.btnTimes.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnTimes.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnTimes.Image = CType(componentResourceManager.GetObject("btnTimes.Image"), Global.System.Drawing.Image)
			Me.btnTimes.Location = New Global.System.Drawing.Point(259, 194)
			Me.btnTimes.Name = "btnTimes"
			Me.btnTimes.Size = New Global.System.Drawing.Size(45, 44)
			Me.btnTimes.TabIndex = 24
			Me.btnTimes.TabStop = False
			Me.btnTimes.UseVisualStyleBackColor = False
			Me.btnEqual.BackColor = Global.System.Drawing.Color.White
			Me.btnEqual.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnEqual.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnEqual.Image = CType(componentResourceManager.GetObject("btnEqual.Image"), Global.System.Drawing.Image)
			Me.btnEqual.Location = New Global.System.Drawing.Point(209, 244)
			Me.btnEqual.Name = "btnEqual"
			Me.btnEqual.Size = New Global.System.Drawing.Size(95, 94)
			Me.btnEqual.TabIndex = 23
			Me.btnEqual.TabStop = False
			Me.btnEqual.UseVisualStyleBackColor = False
			Me.btnDivide.BackColor = Global.System.Drawing.Color.White
			Me.btnDivide.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnDivide.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnDivide.Image = CType(componentResourceManager.GetObject("btnDivide.Image"), Global.System.Drawing.Image)
			Me.btnDivide.Location = New Global.System.Drawing.Point(260, 144)
			Me.btnDivide.Name = "btnDivide"
			Me.btnDivide.Size = New Global.System.Drawing.Size(44, 44)
			Me.btnDivide.TabIndex = 22
			Me.btnDivide.TabStop = False
			Me.btnDivide.UseVisualStyleBackColor = False
			Me.btnMinus.BackColor = Global.System.Drawing.Color.White
			Me.btnMinus.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnMinus.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnMinus.Image = CType(componentResourceManager.GetObject("btnMinus.Image"), Global.System.Drawing.Image)
			Me.btnMinus.Location = New Global.System.Drawing.Point(209, 144)
			Me.btnMinus.Name = "btnMinus"
			Me.btnMinus.Size = New Global.System.Drawing.Size(45, 44)
			Me.btnMinus.TabIndex = 17
			Me.btnMinus.TabStop = False
			Me.btnMinus.UseVisualStyleBackColor = False
			Me.btnAdd.BackColor = Global.System.Drawing.Color.White
			Me.btnAdd.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnAdd.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnAdd.Image = CType(componentResourceManager.GetObject("btnAdd.Image"), Global.System.Drawing.Image)
			Me.btnAdd.Location = New Global.System.Drawing.Point(209, 194)
			Me.btnAdd.Name = "btnAdd"
			Me.btnAdd.Size = New Global.System.Drawing.Size(45, 44)
			Me.btnAdd.TabIndex = 7
			Me.btnAdd.TabStop = False
			Me.btnAdd.UseVisualStyleBackColor = False
			Me.AutoScaleBaseSize = New Global.System.Drawing.Size(5, 13)
			Me.AutoSize = True
			Me.BackColor = Global.System.Drawing.Color.SkyBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(309, 343)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.lblMemory)
			MyBase.Controls.Add(Me.btnClear)
			MyBase.Controls.Add(Me.btnTimes)
			MyBase.Controls.Add(Me.btnEqual)
			MyBase.Controls.Add(Me.btnDivide)
			MyBase.Controls.Add(Me.btnMPos)
			MyBase.Controls.Add(Me.btn1)
			MyBase.Controls.Add(Me.btn0)
			MyBase.Controls.Add(Me.btnMR)
			MyBase.Controls.Add(Me.btnMinus)
			MyBase.Controls.Add(Me.btn9)
			MyBase.Controls.Add(Me.btn6)
			MyBase.Controls.Add(Me.btn8)
			MyBase.Controls.Add(Me.btnBack)
			MyBase.Controls.Add(Me.btn5)
			MyBase.Controls.Add(Me.btnMNeg)
			MyBase.Controls.Add(Me.btn2)
			MyBase.Controls.Add(Me.btn4)
			MyBase.Controls.Add(Me.btn7)
			MyBase.Controls.Add(Me.btnAdd)
			MyBase.Controls.Add(Me.btnNegSign)
			MyBase.Controls.Add(Me.btnPoint)
			MyBase.Controls.Add(Me.btn3)
			MyBase.Controls.Add(Me.btnMC)
			MyBase.Controls.Add(Me.btnPercentage)
			MyBase.Controls.Add(Me.btnSqrt)
			MyBase.Controls.Add(Me.lblDisplay)
			MyBase.Controls.Add(Me.txtHiden)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.MaximizeBox = False
			MyBase.Menu = Me.MainMenu1
			MyBase.Name = "Calculator"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Calculator"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04004BC8 RID: 19400
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
