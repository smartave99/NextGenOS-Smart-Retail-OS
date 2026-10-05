Namespace BillPoint
	' Token: 0x02000338 RID: 824
		Public Partial Class frmChat2
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600C0F7 RID: 49399 RVA: 0x007AC500 File Offset: 0x007AA700
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

		' Token: 0x0600C0F8 RID: 49400 RVA: 0x007AC550 File Offset: 0x007AA750
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim chartArea As Global.System.Windows.Forms.DataVisualization.Charting.ChartArea = New Global.System.Windows.Forms.DataVisualization.Charting.ChartArea()
			Dim legend As Global.System.Windows.Forms.DataVisualization.Charting.Legend = New Global.System.Windows.Forms.DataVisualization.Charting.Legend()
			Dim series As Global.System.Windows.Forms.DataVisualization.Charting.Series = New Global.System.Windows.Forms.DataVisualization.Charting.Series()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmChat2))
			Me.Chart3 = New Global.System.Windows.Forms.DataVisualization.Charting.Chart()
			CType(Me.Chart3, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			chartArea.Area3DStyle.Enable3D = True
			chartArea.Name = "ChartArea1"
			Me.Chart3.ChartAreas.Add(chartArea)
			Me.Chart3.Dock = Global.System.Windows.Forms.DockStyle.Fill
			legend.BackColor = Global.System.Drawing.Color.White
			legend.BackImageAlignment = Global.System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center
			legend.BorderColor = Global.System.Drawing.Color.Green
			legend.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			legend.Name = "Legend1"
			Me.Chart3.Legends.Add(legend)
			Me.Chart3.Location = New Global.System.Drawing.Point(0, 0)
			Me.Chart3.Name = "Chart3"
			Me.Chart3.Palette = Global.System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel
			series.ChartArea = "ChartArea1"
			series.ChartType = Global.System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pyramid
			series.IsXValueIndexed = True
			series.LabelForeColor = Global.System.Drawing.Color.White
			series.Legend = "Legend1"
			series.Name = "A"
			series.XValueType = Global.System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Double]
			Me.Chart3.Series.Add(series)
			Me.Chart3.Size = New Global.System.Drawing.Size(1152, 623)
			Me.Chart3.TabIndex = 139
			Me.Chart3.TabStop = False
			Me.Chart3.Text = "Chart3"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			MyBase.ClientSize = New Global.System.Drawing.Size(1152, 623)
			MyBase.Controls.Add(Me.Chart3)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MinimizeBox = False
			MyBase.Name = "frmChat2"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			MyBase.WindowState = Global.System.Windows.Forms.FormWindowState.Maximized
			CType(Me.Chart3, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04004D66 RID: 19814
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
