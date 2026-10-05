Namespace BillPoint
	' Token: 0x02000339 RID: 825
		Public Partial Class frmChat3
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600C0FE RID: 49406 RVA: 0x007AC7B4 File Offset: 0x007AA9B4
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

		' Token: 0x0600C0FF RID: 49407 RVA: 0x007AC804 File Offset: 0x007AAA04
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim chartArea As Global.System.Windows.Forms.DataVisualization.Charting.ChartArea = New Global.System.Windows.Forms.DataVisualization.Charting.ChartArea()
			Dim legend As Global.System.Windows.Forms.DataVisualization.Charting.Legend = New Global.System.Windows.Forms.DataVisualization.Charting.Legend()
			Dim series As Global.System.Windows.Forms.DataVisualization.Charting.Series = New Global.System.Windows.Forms.DataVisualization.Charting.Series()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmChat3))
			Me.Chart2 = New Global.System.Windows.Forms.DataVisualization.Charting.Chart()
			CType(Me.Chart2, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			chartArea.Area3DStyle.Enable3D = True
			chartArea.BackColor = Global.System.Drawing.Color.FromArgb(192, 255, 255)
			chartArea.Name = "ChartArea1"
			Me.Chart2.ChartAreas.Add(chartArea)
			Me.Chart2.Dock = Global.System.Windows.Forms.DockStyle.Fill
			legend.BackColor = Global.System.Drawing.Color.White
			legend.BackImageAlignment = Global.System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center
			legend.BorderColor = Global.System.Drawing.Color.Green
			legend.Enabled = False
			legend.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			legend.Name = "Legend1"
			Me.Chart2.Legends.Add(legend)
			Me.Chart2.Location = New Global.System.Drawing.Point(0, 0)
			Me.Chart2.Name = "Chart2"
			Me.Chart2.Palette = Global.System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones
			series.ChartArea = "ChartArea1"
			series.ChartType = Global.System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area
			series.IsXValueIndexed = True
			series.LabelForeColor = Global.System.Drawing.Color.White
			series.Legend = "Legend1"
			series.Name = "A"
			series.XValueType = Global.System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Double]
			series.YValuesPerPoint = 2
			Me.Chart2.Series.Add(series)
			Me.Chart2.Size = New Global.System.Drawing.Size(1152, 623)
			Me.Chart2.TabIndex = 138
			Me.Chart2.TabStop = False
			Me.Chart2.Text = "Chart2"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1152, 623)
			MyBase.Controls.Add(Me.Chart2)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MinimizeBox = False
			MyBase.Name = "frmChat3"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			MyBase.WindowState = Global.System.Windows.Forms.FormWindowState.Maximized
			CType(Me.Chart2, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04004D68 RID: 19816
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
