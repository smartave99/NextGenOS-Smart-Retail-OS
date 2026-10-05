Option Infer On
Option Explicit On
Option Strict On
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Namespace BillPoint
    Public Module RetailTableLayouts
        Public Sub Prepare(table As TableLayoutPanel, prepareChild As Action(Of Control))
            Dim children = table.Controls.Cast(Of Control)().ToArray()
            For Each child In children
                Dim position = table.GetPositionFromControl(child)
                Dim rows = table.GetRowSpan(child)
                Dim columns = table.GetColumnSpan(child)
                Dim height As Integer
                Dim isField = TypeOf child Is TextBoxBase OrElse TypeOf child Is ComboBox OrElse TypeOf child Is DateTimePicker OrElse TypeOf child Is NumericUpDown
                If isField Then
                    Dim caption = children.OfType(Of Label)().Where(Function(label) Not TypeOf label Is LinkLabel AndAlso
                        table.GetPositionFromControl(label).Row = position.Row AndAlso table.GetPositionFromControl(label).Column < position.Column).
                        OrderByDescending(Function(label) table.GetPositionFromControl(label).Column).FirstOrDefault()
                    If caption IsNot Nothing Then child.AccessibleName = caption.Text.Replace("&", "").Trim().TrimEnd(":"c)
                    If String.IsNullOrWhiteSpace(child.AccessibleName) Then child.AccessibleName = child.Name
                    Dim visible = RetailWorkspaceLayouts.IsLocallyVisible(child)
                    Dim frame As New RetailUI.FieldFrame(child)
                    frame.Dock = DockStyle.Fill
                    frame.TabIndex = child.TabIndex
                    frame.Visible = visible
                    AddHandler child.VisibleChanged, Sub(sender, e) frame.Visible = RetailWorkspaceLayouts.IsLocallyVisible(child)
                    table.Controls.Add(frame, position.Column, position.Row)
                    table.SetColumnSpan(frame, columns)
                    table.SetRowSpan(frame, rows)
                    height = RetailUI.TouchHeight + RetailUI.Space
                    Dim text = TryCast(child, TextBox)
                    If text IsNot Nothing AndAlso text.Multiline Then height = RetailUI.FieldHeight * 2
                Else
                    prepareChild(child)
                    height = If(child.AutoSize, child.PreferredSize.Height, child.Height) + child.Margin.Vertical
                End If
                If position.Row < 0 Then Continue For
                While table.RowStyles.Count < table.RowCount
                    table.RowStyles.Add(New RowStyle(SizeType.AutoSize))
                End While
                For index = position.Row To Math.Min(table.RowCount - 1, position.Row + rows - 1)
                    Dim style = table.RowStyles(index)
                    style.SizeType = SizeType.Absolute
                    style.Height = Math.Max(style.Height, CSng(Math.Ceiling(height / CDbl(rows))))
                Next
            Next
            table.AutoSize = True
            table.AutoSizeMode = AutoSizeMode.GrowAndShrink
            table.Dock = DockStyle.Top
            table.Font = RetailUI.TypeFont("subhead")
        End Sub
    End Module
End Namespace
