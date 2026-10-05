Namespace BillPoint
	' Token: 0x020004A7 RID: 1191
		Public Partial Class FormCamera
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600EC57 RID: 60503 RVA: 0x008E4940 File Offset: 0x008E2B40
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

		' Token: 0x0600EC58 RID: 60504 RVA: 0x008E4990 File Offset: 0x008E2B90
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.FormCamera))
			Me.TableLayoutPanel1 = New Global.System.Windows.Forms.TableLayoutPanel()
			Me.PictureBox2 = New Global.System.Windows.Forms.PictureBox()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.BtnStart = New Global.System.Windows.Forms.Button()
			Me.BtnCapt = New Global.System.Windows.Forms.Button()
			Me.BtnSave = New Global.System.Windows.Forms.Button()
			Me.BtnStop = New Global.System.Windows.Forms.Button()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.BtnRmv = New Global.System.Windows.Forms.Button()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.TableLayoutPanel1.SuspendLayout()
			CType(Me.PictureBox2, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.TableLayoutPanel1.ColumnCount = 2
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 50F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 50F))
			Me.TableLayoutPanel1.Controls.Add(Me.PictureBox2, 1, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.PictureBox1, 0, 0)
			Me.TableLayoutPanel1.Location = New Global.System.Drawing.Point(4, 3)
			Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
			Me.TableLayoutPanel1.RowCount = 1
			Me.TableLayoutPanel1.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 50F))
			Me.TableLayoutPanel1.Size = New Global.System.Drawing.Size(787, 469)
			Me.TableLayoutPanel1.TabIndex = 0
			Me.PictureBox2.BackColor = Global.System.Drawing.Color.PaleGoldenrod
			Me.PictureBox2.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.PictureBox2.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.PictureBox2.Image = CType(componentResourceManager.GetObject("PictureBox2.Image"), Global.System.Drawing.Image)
			Me.PictureBox2.Location = New Global.System.Drawing.Point(396, 3)
			Me.PictureBox2.Name = "PictureBox2"
			Me.PictureBox2.Size = New Global.System.Drawing.Size(388, 463)
			Me.PictureBox2.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.Zoom
			Me.PictureBox2.TabIndex = 1
			Me.PictureBox2.TabStop = False
			Me.PictureBox1.BackColor = Global.System.Drawing.Color.PaleGoldenrod
			Me.PictureBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.PictureBox1.Image = CType(componentResourceManager.GetObject("PictureBox1.Image"), Global.System.Drawing.Image)
			Me.PictureBox1.Location = New Global.System.Drawing.Point(3, 3)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(387, 463)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.Zoom
			Me.PictureBox1.TabIndex = 0
			Me.PictureBox1.TabStop = False
			Me.BtnStart.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.BtnStart.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BtnStart.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BtnStart.ForeColor = Global.System.Drawing.SystemColors.Info
			Me.BtnStart.Location = New Global.System.Drawing.Point(804, 13)
			Me.BtnStart.Name = "BtnStart"
			Me.BtnStart.Size = New Global.System.Drawing.Size(83, 50)
			Me.BtnStart.TabIndex = 1
			Me.BtnStart.Text = "S&tart"
			Me.BtnStart.UseVisualStyleBackColor = False
			Me.BtnCapt.BackColor = Global.System.Drawing.Color.DarkGoldenrod
			Me.BtnCapt.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BtnCapt.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BtnCapt.ForeColor = Global.System.Drawing.Color.White
			Me.BtnCapt.Location = New Global.System.Drawing.Point(804, 69)
			Me.BtnCapt.Name = "BtnCapt"
			Me.BtnCapt.Size = New Global.System.Drawing.Size(83, 50)
			Me.BtnCapt.TabIndex = 2
			Me.BtnCapt.Text = "Capture"
			Me.BtnCapt.UseVisualStyleBackColor = False
			Me.BtnCapt.Visible = False
			Me.BtnSave.BackColor = Global.System.Drawing.Color.LightSeaGreen
			Me.BtnSave.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BtnSave.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BtnSave.ForeColor = Global.System.Drawing.SystemColors.Info
			Me.BtnSave.Location = New Global.System.Drawing.Point(804, 125)
			Me.BtnSave.Name = "BtnSave"
			Me.BtnSave.Size = New Global.System.Drawing.Size(83, 50)
			Me.BtnSave.TabIndex = 3
			Me.BtnSave.Text = "Save"
			Me.BtnSave.UseVisualStyleBackColor = False
			Me.BtnSave.Visible = False
			Me.BtnStop.BackColor = Global.System.Drawing.Color.Red
			Me.BtnStop.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BtnStop.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BtnStop.ForeColor = Global.System.Drawing.SystemColors.Info
			Me.BtnStop.Location = New Global.System.Drawing.Point(804, 13)
			Me.BtnStop.Name = "BtnStop"
			Me.BtnStop.Size = New Global.System.Drawing.Size(83, 50)
			Me.BtnStop.TabIndex = 4
			Me.BtnStop.Text = "Stop &Exit"
			Me.BtnStop.UseVisualStyleBackColor = False
			Me.Button1.BackColor = Global.System.Drawing.Color.FromArgb(192, 0, 0)
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.SystemColors.Info
			Me.Button1.Location = New Global.System.Drawing.Point(804, 420)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(83, 50)
			Me.Button1.TabIndex = 5
			Me.Button1.Text = "&Exit"
			Me.Button1.UseVisualStyleBackColor = False
			Me.BtnRmv.BackColor = Global.System.Drawing.Color.DeepPink
			Me.BtnRmv.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BtnRmv.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BtnRmv.ForeColor = Global.System.Drawing.Color.White
			Me.BtnRmv.Location = New Global.System.Drawing.Point(804, 181)
			Me.BtnRmv.Name = "BtnRmv"
			Me.BtnRmv.Size = New Global.System.Drawing.Size(83, 50)
			Me.BtnRmv.TabIndex = 6
			Me.BtnRmv.Text = "Remove"
			Me.BtnRmv.UseVisualStyleBackColor = False
			Me.BtnRmv.Visible = False
			Me.Panel1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(897, 483)
			Me.Panel1.TabIndex = 7
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.DodgerBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(897, 483)
			MyBase.Controls.Add(Me.BtnRmv)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.BtnSave)
			MyBase.Controls.Add(Me.BtnCapt)
			MyBase.Controls.Add(Me.BtnStart)
			MyBase.Controls.Add(Me.BtnStop)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.None
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "FormCamera"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Camera"
			Me.TableLayoutPanel1.ResumeLayout(False)
			CType(Me.PictureBox2, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel1.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04005A3D RID: 23101
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
