Option Infer On
Option Explicit On
Option Strict On
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.Win32

Namespace BillPoint
    ' Native port of the apple-grade-ui token and component states. Sizes are logical pixels.
    Public Module RetailUI
        Public Const Space As Integer = 8
        Public Const Inset As Integer = 24
        Public Const TouchHeight As Integer = 44
        Public Const RowHeight As Integer = 48
        Public Const FieldHeight As Integer = TouchHeight + Inset + Space
        Public Const SectionHeight As Integer = 40
        Public Const ButtonRadius As Integer = 12
        Public Const CardRadius As Integer = 20
        Public Const LoginWidth As Integer = 560
        Public Const LoginHeight As Integer = 720
        Public Const DesktopWidth As Integer = 1440
        Public Const DesktopHeight As Integer = 960
        Public Const MinimumWidth As Integer = 1024
        Public Const MinimumHeight As Integer = 720
        Public Property IsDark As Boolean = ReadSystemDarkMode()
        Private ReadOnly Styled As New ConditionalWeakTable(Of Control, Object)()
        Private ReadOnly ButtonRoles As New ConditionalWeakTable(Of Button, ButtonRole)()
        Private ReadOnly SurfaceRoles As New ConditionalWeakTable(Of Control, SurfaceRole)()
        Private ReadOnly NormalizedGrids As New ConditionalWeakTable(Of DataGridView, Object)()
        Private Class SurfaceRole
            Public Name As String
        End Class
        Private Class ButtonRole
            Public Primary As Boolean
            Public Destructive As Boolean
            Public Detail As String
            Public Quiet As Boolean
        End Class
        Private ReadOnly Fonts As New Dictionary(Of String, Font)()
        Private ReadOnly TypePixels As Single() = {34, 28, 22, 20, 17, 17, 16, 15, 13, 12, 11}
        Private ReadOnly TypeNames As String() = {"display", "title-1", "title-2", "title-3", "headline", "body", "callout", "subhead", "footnote", "caption-1", "caption-2"}

        Private Function ReadSystemDarkMode() As Boolean
            Return Convert.ToInt32(Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1)) = 0
        End Function

        Public Function Tone(name As String) As Color
            If SystemInformation.HighContrast Then
                Select Case name
                    Case "accent", "accent-hover" : Return SystemColors.Highlight
                    Case "on-accent" : Return SystemColors.HighlightText
                    Case "label", "secondary", "danger", "warning", "accent-text" : Return SystemColors.WindowText
                    Case "control", "separator" : Return SystemColors.WindowText
                    Case Else : Return SystemColors.Window
                End Select
            End If
            Select Case name
                Case "canvas" : Return If(IsDark, Color.FromArgb(0, 0, 0), Color.FromArgb(242, 242, 247))
                Case "surface" : Return If(IsDark, Color.FromArgb(28, 28, 30), Color.White)
                Case "fill" : Return If(IsDark, Color.FromArgb(44, 44, 46), Color.FromArgb(242, 242, 247))
                Case "hover" : Return If(IsDark, Color.FromArgb(58, 58, 60), Color.FromArgb(229, 229, 234))
                Case "label" : Return If(IsDark, Color.FromArgb(245, 245, 247), Color.FromArgb(29, 29, 31))
                Case "secondary" : Return If(IsDark, Color.FromArgb(174, 174, 181), Color.FromArgb(99, 99, 105))
                Case "accent" : Return If(IsDark, Color.FromArgb(31, 111, 235), Color.FromArgb(10, 90, 255))
                Case "accent-hover" : Return If(IsDark, Color.FromArgb(25, 100, 220), Color.FromArgb(3, 68, 204))
                Case "accent-text" : Return If(IsDark, Color.FromArgb(77, 162, 255), Color.FromArgb(10, 90, 255))
                Case "selection" : Return If(IsDark, Color.FromArgb(28, 55, 89), Color.FromArgb(232, 240, 254))
                Case "control" : Return If(IsDark, Color.FromArgb(140, 140, 147), Color.FromArgb(134, 134, 140))
                Case "separator" : Return If(IsDark, Color.FromArgb(58, 58, 60), Color.FromArgb(229, 229, 234))
                Case "danger" : Return If(IsDark, Color.FromArgb(255, 105, 97), Color.FromArgb(185, 28, 28))
                Case "warning" : Return If(IsDark, Color.FromArgb(255, 190, 82), Color.FromArgb(142, 79, 0))
                Case "on-accent" : Return Color.White
                Case Else : Throw New ArgumentException("Unknown UI token: " & name)
            End Select
        End Function

        Public Function TypeFont(Optional name As String = "body") As Font
            If Not Fonts.ContainsKey(name) Then
                Dim index = Array.IndexOf(TypeNames, name)
                If index < 0 Then Throw New ArgumentException("Unknown type token: " & name)
                Dim weight = If(index < 5 OrElse index = 10, FontStyle.Bold, FontStyle.Regular)
                Fonts.Add(name, New Font(AppleUITheme.GetFontFamily(), TypePixels(index) * 0.75F, weight, GraphicsUnit.Point))
            End If
            Return Fonts(name)
        End Function

        Public Function RoundedPath(bounds As Rectangle, radius As Integer) As GraphicsPath
            Dim path As New GraphicsPath()
            Dim diameter = Math.Min(radius * 2, Math.Min(bounds.Width, bounds.Height))
            path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90)
            path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90)
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90)
            path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90)
            path.CloseFigure()
            Return path
        End Function

        Public Sub StyleButton(button As Button, Optional primary As Boolean = False, Optional destructive As Boolean = False, Optional detail As String = "")
            button.MinimumSize = New Size(TouchHeight, TouchHeight)
            Dim role = ButtonRoles.GetOrCreateValue(button)
            role.Primary = primary
            role.Destructive = destructive
            role.Detail = detail
            role.Quiet = False
            button.BackgroundImage = Nothing
            button.Image = Nothing
            button.UseVisualStyleBackColor = False
            button.FlatStyle = FlatStyle.Flat
            button.FlatAppearance.BorderSize = 0
            button.BackColor = Tone(If(primary, "accent", "fill"))
            button.ForeColor = Tone(If(primary, "on-accent", If(destructive, "danger", "label")))
            button.Font = TypeFont("subhead")
            button.TextAlign = ContentAlignment.MiddleCenter
            button.TextImageRelation = TextImageRelation.Overlay
            ' Recovered GelButton paints its own gradient after the standard Paint event.
            For Each name As String In {"GradientTop", "GradientBottom"}
                Dim colorProperty = button.GetType().GetProperty(name)
                If colorProperty IsNot Nothing AndAlso colorProperty.CanWrite AndAlso colorProperty.PropertyType Is GetType(Color) Then
                    colorProperty.SetValue(button, button.BackColor, Nothing)
                End If
            Next
            button.Cursor = Cursors.Hand
            If Not String.IsNullOrWhiteSpace(button.Text) Then
                button.AccessibleName = button.Text.Replace("&", "").Trim()
            ElseIf String.IsNullOrWhiteSpace(button.AccessibleName) Then
                button.AccessibleName = System.Text.RegularExpressions.Regex.Replace(button.Name, "^btn", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            End If
            button.AccessibleDescription = detail
            Dim marker As Object = Nothing
            If Styled.TryGetValue(button, marker) Then Return
            Styled.Add(button, New Object())
            AddHandler button.Paint, AddressOf PaintButton
            AddHandler button.GotFocus, Sub(sender, e) button.Invalidate()
            AddHandler button.LostFocus, Sub(sender, e) button.Invalidate()
        End Sub

        Public Sub StyleTextButton(button As Button)
            StyleButton(button)
            ButtonRoles.GetOrCreateValue(button).Quiet = True
            button.BackColor = Tone("surface")
            button.ForeColor = Tone("accent-text")
        End Sub

        Private Sub PaintButton(sender As Object, e As PaintEventArgs)
            Dim button = DirectCast(sender, Button)
            Dim isPrimary = button.BackColor.ToArgb() = Tone("accent").ToArgb()
            Dim hovering = button.ClientRectangle.Contains(button.PointToClient(Cursor.Position))
            Dim pressed = hovering AndAlso (Control.MouseButtons And MouseButtons.Left) <> MouseButtons.None
            Dim background = If(hovering AndAlso button.Enabled, Tone(If(isPrimary, "accent-hover", "hover")), button.BackColor)
            If pressed Then background = Tone(If(isPrimary, "accent-hover", "selection"))
            e.Graphics.Clear(If(button.Parent Is Nothing, Tone("surface"), button.Parent.BackColor))
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            Dim bounds = Rectangle.Inflate(button.ClientRectangle, -1, -1)
            Using path = RoundedPath(bounds, ButtonRadius), brush As New SolidBrush(background)
                e.Graphics.FillPath(brush, path)
            End Using
            If button.Focused Then
                Using path = RoundedPath(Rectangle.Inflate(bounds, -2, -2), ButtonRadius - 2), pen As New Pen(Tone(If(isPrimary, "on-accent", "accent-text")), 2)
                    e.Graphics.DrawPath(pen, path)
                End Using
            End If
            Dim role = ButtonRoles.GetOrCreateValue(button)
            If String.IsNullOrEmpty(role.Detail) Then
                TextRenderer.DrawText(e.Graphics, button.Text, button.Font, bounds, If(button.Enabled, button.ForeColor, Tone("secondary")), TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter Or TextFormatFlags.WordBreak)
            Else
                PaintTaskText(button, role.Detail, e.Graphics, bounds)
            End If
        End Sub

        Private Sub PaintTaskText(button As Button, detail As String, graphics As Graphics, bounds As Rectangle)
            Dim top = bounds.Top + (bounds.Height - Inset * 2) \ 2
            Dim title = New Rectangle(bounds.Left + Space * 2, top, bounds.Width - Space * 4, Inset)
            Dim context = New Rectangle(title.Left, title.Bottom, title.Width, Inset)
            Dim flags = TextFormatFlags.Left Or TextFormatFlags.VerticalCenter Or TextFormatFlags.EndEllipsis Or TextFormatFlags.SingleLine
            TextRenderer.DrawText(graphics, button.Text, TypeFont("headline"), title, If(button.Enabled, Tone("label"), Tone("secondary")), flags)
            TextRenderer.DrawText(graphics, detail, TypeFont("footnote"), context, Tone("secondary"), flags)
        End Sub

        Public Function Label(text As String, Optional style As String = "subhead") As Label
            Return New Label With {.Text = text, .AutoSize = False, .Dock = DockStyle.Fill, .Font = TypeFont(style), .ForeColor = Tone("label"), .BackColor = Tone("surface"), .TextAlign = ContentAlignment.MiddleLeft, .Margin = New Padding(0)}
        End Function

        Public Sub StyleSurface(control As Control, token As String)
            SurfaceRoles.GetOrCreateValue(control).Name = token
            control.BackColor = Tone(token)
        End Sub

        Public Function Stack() As TableLayoutPanel
            Dim panel As New TableLayoutPanel With {.Dock = DockStyle.Top, .AutoSize = True, .AutoSizeMode = AutoSizeMode.GrowAndShrink, .ColumnCount = 1, .RowCount = 0, .BackColor = Tone("surface"), .Padding = New Padding(Inset), .Margin = New Padding(Space)}
            panel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
            AddHandler panel.SizeChanged, Sub(sender, e)
                                              If panel.Width < CardRadius OrElse panel.Height < CardRadius Then Return
                                              Using path = RoundedPath(panel.ClientRectangle, CardRadius)
                                                  Dim previous = panel.Region
                                                  panel.Region = New Region(path)
                                                  If previous IsNot Nothing Then previous.Dispose()
                                              End Using
                                          End Sub
            Return panel
        End Function

        Public Sub AddRow(stackPanel As TableLayoutPanel, control As Control, height As Integer)
            Dim row = stackPanel.RowCount
            stackPanel.RowCount += 1
            stackPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, height))
            control.Dock = DockStyle.Fill
            control.Margin = New Padding(0, 0, 0, Space)
            stackPanel.Controls.Add(control, 0, row)
        End Sub

        Public Function Field(input As Control, caption As String) As Control
            Dim panel As New TableLayoutPanel With {.Dock = DockStyle.Fill, .ColumnCount = 1, .RowCount = 2, .Margin = New Padding(0), .BackColor = Tone("surface")}
            panel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
            panel.RowStyles.Add(New RowStyle(SizeType.Absolute, Inset))
            panel.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
            panel.Controls.Add(Label(caption, "footnote"), 0, 0)
            Dim frame As New FieldFrame(input)
            input.AccessibleName = caption
            panel.Controls.Add(frame, 0, 1)
            Return panel
        End Function

        Public Sub StyleTree(control As Control)
            control.ForeColor = Tone("label")
            If TypeOf control Is Button Then
                Dim action = DirectCast(control, Button)
                Dim role As ButtonRole = Nothing
                If ButtonRoles.TryGetValue(action, role) Then
                    If role.Quiet Then
                        StyleTextButton(action)
                    Else
                        StyleButton(action, role.Primary, role.Destructive, role.Detail)
                    End If
                Else
                    ' Existing bitmap icons carry meaning on hundreds of legacy commands.
                    ' Keep them until their form receives an explicit layout rebuild.
                    action.FlatStyle = FlatStyle.Flat
                    action.FlatAppearance.BorderColor = Tone("control")
                    action.BackColor = Tone("fill")
                    action.ForeColor = Tone("label")
                    If action.Text.Trim().Length > 1 Then action.BackgroundImage = Nothing
                End If
            ElseIf TypeOf control Is DataGridView Then
                StyleGrid(DirectCast(control, DataGridView))
            ElseIf TypeOf control Is TextBoxBase OrElse TypeOf control Is ComboBox Then
                control.BackColor = Tone("surface")
            ElseIf TypeOf control Is ToolStrip Then
                Dim strip = DirectCast(control, ToolStrip)
                strip.Renderer = New RetailMenuRenderer()
                strip.BackColor = Tone("surface")
                strip.Font = TypeFont("subhead")
                For Each item As ToolStripItem In strip.Items
                    StyleMenuItem(item)
                Next
            Else
                Dim surface As SurfaceRole = Nothing
                Dim token = If(SurfaceRoles.TryGetValue(control, surface), surface.Name, If(TypeOf control Is System.Windows.Forms.Form, "canvas", "surface"))
                control.BackColor = Tone(token)
            End If
            ' Retain legacy geometry and fonts outside rebuilt layouts; changing them here clips labels.
            For Each child As Control In control.Controls
                StyleTree(child)
            Next
        End Sub

        Private Sub StyleMenuItem(item As ToolStripItem)
            item.Text = item.Text.Trim()
            item.BackColor = Tone("surface")
            item.ForeColor = Tone("label")
            item.Font = TypeFont("subhead")
            Dim menu = TryCast(item, ToolStripMenuItem)
            If menu Is Nothing Then Return
            For Each child As ToolStripItem In menu.DropDownItems
                child.Padding = New Padding(Space)
                StyleMenuItem(child)
            Next
        End Sub

        Public Sub StyleGrid(grid As DataGridView)
            grid.BackgroundColor = Tone("surface")
            grid.BorderStyle = BorderStyle.None
            grid.EnableHeadersVisualStyles = False
            grid.GridColor = Tone("separator")
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            grid.ColumnHeadersDefaultCellStyle.BackColor = Tone("fill")
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Tone("secondary")
            grid.ColumnHeadersDefaultCellStyle.Font = TypeFont("footnote")
            grid.ColumnHeadersHeight = TouchHeight
            grid.DefaultCellStyle.BackColor = Tone("surface")
            grid.DefaultCellStyle.ForeColor = Tone("label")
            grid.DefaultCellStyle.SelectionBackColor = Tone("selection")
            grid.DefaultCellStyle.SelectionForeColor = Tone("label")
            grid.DefaultCellStyle.Font = TypeFont("subhead")
            Dim marker As Object = Nothing
            If NormalizedGrids.TryGetValue(grid, marker) Then ResetColumnAppearance(grid)
            grid.AlternatingRowsDefaultCellStyle.BackColor = Tone("surface")
            grid.AlternatingRowsDefaultCellStyle.ForeColor = Tone("label")
            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = Tone("selection")
            grid.AlternatingRowsDefaultCellStyle.SelectionForeColor = Tone("label")
            grid.RowTemplate.Height = RowHeight
            grid.RowTemplate.MinimumHeight = RowHeight
            For Each row As DataGridViewRow In grid.Rows
                row.MinimumHeight = RowHeight
                row.Height = RowHeight
            Next
        End Sub

        Public Sub NormalizeGridAppearance(grid As DataGridView)
            Dim marker As Object = Nothing
            If Not NormalizedGrids.TryGetValue(grid, marker) Then NormalizedGrids.Add(grid, New Object())
            StyleGrid(grid)
        End Sub

        Private Sub ResetColumnAppearance(grid As DataGridView)
            ' Row and column styles outrank the grid defaults. Keep formats and alignment intact.
            ResetCellAppearance(grid.RowsDefaultCellStyle)
            ResetCellAppearance(grid.AlternatingRowsDefaultCellStyle)
            For Each column As DataGridViewColumn In grid.Columns
                ResetCellAppearance(column.DefaultCellStyle)
            Next
        End Sub

        Private Sub ResetCellAppearance(style As DataGridViewCellStyle)
            style.Font = Nothing
            style.BackColor = Color.Empty
            style.ForeColor = Color.Empty
            style.SelectionBackColor = Color.Empty
            style.SelectionForeColor = Color.Empty
        End Sub

        Public Function Columns(count As Integer) As TableLayoutPanel
            Dim panel As New TableLayoutPanel With {.Dock = DockStyle.Fill, .ColumnCount = count, .RowCount = 1, .Margin = New Padding(0), .BackColor = RetailUI.Tone("surface")}
            For index As Integer = 1 To count
                panel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F / count))
            Next
            panel.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
            Return panel
        End Function

        Public Sub ActionRow(stack As TableLayoutPanel, ParamArray actions As Button())
            Dim row = Columns(actions.Length)
            For index As Integer = 0 To actions.Length - 1
                Dim action = actions(index)
                action.Dock = DockStyle.Fill
                action.Margin = New Padding(0, 0, If(index = actions.Length - 1, 0, RetailUI.Space), 0)
                action.TabStop = True
                row.Controls.Add(action, index, 0)
            Next
            RetailUI.AddRow(stack, row, RetailUI.TouchHeight + RetailUI.Space)
        End Sub

        Public Sub FieldRow(stack As TableLayoutPanel, captions As String(), ParamArray inputs As Control())
            Dim row = Columns(inputs.Length)
            For index As Integer = 0 To inputs.Length - 1
                Dim field = RetailUI.Field(inputs(index), captions(index))
                field.Margin = New Padding(0, 0, If(index = inputs.Length - 1, 0, RetailUI.Space), 0)
                row.Controls.Add(field, index, 0)
                inputs(index).TabStop = True
            Next
            RetailUI.AddRow(stack, row, RetailUI.FieldHeight)
        End Sub

        Public Class FieldFrame
            Inherits Panel
            Private ReadOnly Input As Control
            Public Sub New(control As Control)
                Input = control
                Dock = DockStyle.Fill
                BackColor = Tone("surface")
                Padding = New Padding(Space)
                MinimumSize = New Size(TouchHeight, TouchHeight)
                Margin = New Padding(0)
                Controls.Add(control)
                control.Font = TypeFont("callout")
                control.Dock = DockStyle.None
                control.Anchor = AnchorStyles.Left Or AnchorStyles.Right
                Dim text = TryCast(control, TextBox)
                If text IsNot Nothing Then text.BorderStyle = BorderStyle.None
                Dim selectInput = TryCast(control, ComboBox)
                If selectInput IsNot Nothing Then selectInput.FlatStyle = FlatStyle.Flat
                AddHandler control.GotFocus, Sub(sender, e) Invalidate()
                AddHandler control.LostFocus, Sub(sender, e) Invalidate()
                AddHandler control.EnabledChanged, Sub(sender, e) Invalidate()
                AddHandler MouseDown, Sub(sender, e)
                                          If Not Input.Enabled Then Return
                                          Input.Focus()
                                          Dim combo = TryCast(Input, ComboBox)
                                          If combo IsNot Nothing Then combo.DroppedDown = True
                                      End Sub
                SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint, True)
            End Sub
            Protected Overrides Sub OnLayout(e As LayoutEventArgs)
                MyBase.OnLayout(e)
                Input.SetBounds(Space * 2, Math.Max(Space, (ClientSize.Height - Input.Height) \ 2), Math.Max(TouchHeight, ClientSize.Width - Space * 4), Input.Height)
            End Sub
            Protected Overrides Sub OnPaint(e As PaintEventArgs)
                MyBase.OnPaint(e)
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
                Using path = RoundedPath(Rectangle.Inflate(ClientRectangle, -1, -1), ButtonRadius), pen As New Pen(Tone(If(Input.ContainsFocus, "accent-text", "control")), If(Input.ContainsFocus, 2, 1))
                    e.Graphics.DrawPath(pen, path)
                End Using
            End Sub
        End Class

        Public Class RetailMenuRenderer
            Inherits ToolStripProfessionalRenderer
            Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
                Using brush As New SolidBrush(Tone(If(e.Item.Selected OrElse e.Item.Pressed, "selection", "surface")))
                    e.Graphics.FillRectangle(brush, New Rectangle(Point.Empty, e.Item.Size))
                End Using
                e.Item.ForeColor = Tone("label")
            End Sub
            Protected Overrides Sub OnRenderToolStripBackground(e As ToolStripRenderEventArgs)
                e.Graphics.Clear(Tone("surface"))
            End Sub
        End Class
    End Module
End Namespace
