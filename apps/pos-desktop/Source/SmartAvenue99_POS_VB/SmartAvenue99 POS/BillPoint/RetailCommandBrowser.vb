Option Infer On
Option Explicit On
Option Strict On
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Namespace BillPoint
    Public Module RetailCommandBrowser
        Public Function Create(menu As MenuStrip) As Control
            Dim commands = menu.Items.OfType(Of ToolStripMenuItem)().SelectMany(Function(item) Leaves(item)).ToArray()
            Dim layout As New TableLayoutPanel With {.Name = "RetailCommandBrowser", .Dock = DockStyle.Fill, .ColumnCount = 1, .RowCount = 4,
                .Padding = New Padding(RetailUI.Inset), .Margin = New Padding(0)}
            layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
            layout.RowStyles.Add(New RowStyle(SizeType.Absolute, RetailUI.FieldHeight + RetailUI.Space))
            layout.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
            layout.RowStyles.Add(New RowStyle(SizeType.Absolute, RetailUI.SectionHeight))
            layout.RowStyles.Add(New RowStyle(SizeType.Absolute, RetailUI.TouchHeight + RetailUI.Space))
            Dim filters = RetailUI.Columns(2)
            Dim search As New TextBox With {.Name = "RetailCommandSearch"}
            Dim category As New ComboBox With {.Name = "RetailCommandCategory", .DropDownStyle = ComboBoxStyle.DropDownList}
            filters.Controls.Add(RetailUI.Field(search, "Find a command"), 0, 0)
            filters.Controls.Add(RetailUI.Field(category, "Category"), 1, 0)
            category.Items.Add("All categories")
            For Each caption As String In commands.Select(Function(item) CategoryName(item)).Distinct()
                category.Items.Add(caption)
            Next
            category.SelectedIndex = 0
            layout.Controls.Add(filters, 0, 0)
            Dim grid As New DataGridView With {.Name = "RetailCommandList", .Dock = DockStyle.Fill, .ReadOnly = True,
                .AllowUserToAddRows = False, .AllowUserToDeleteRows = False, .MultiSelect = False, .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, .RowHeadersVisible = False, .AccessibleName = "Available store commands"}
            grid.Columns.Add("Command", "Command")
            grid.Columns.Add("Category", "Location")
            grid.Columns.Add("Shortcut", "Shortcut")
            grid.Columns(0).FillWeight = 40
            grid.Columns(1).FillWeight = 50
            grid.Columns(2).FillWeight = 10
            RetailUI.NormalizeGridAppearance(grid)
            layout.Controls.Add(grid, 0, 1)
            Dim status = RetailUI.Label("", "footnote")
            status.Name = "RetailCommandStatus"
            layout.Controls.Add(status, 0, 2)
            Dim open As New Button With {.Name = "RetailOpenCommand", .Text = "Open selected command", .Dock = DockStyle.Fill, .Enabled = False}
            RetailUI.StyleButton(open)
            layout.Controls.Add(open, 0, 3)
            Dim selected As Func(Of ToolStripMenuItem) = Function()
                                                            If grid.CurrentRow Is Nothing Then
                                                                If grid.Rows.Count = 0 Then Return Nothing
                                                                Return TryCast(grid.Rows(0).Tag, ToolStripMenuItem)
                                                            End If
                                                            Return TryCast(grid.CurrentRow.Tag, ToolStripMenuItem)
                                                        End Function
            Dim refresh As Action = Sub()
                                        Dim previous = selected()
                                        grid.Rows.Clear()
                                        Dim matches = commands.Where(Function(item) CanExecute(item) AndAlso
                                            (category.SelectedIndex <= 0 OrElse CategoryName(item) = CStr(category.SelectedItem)) AndAlso
                                            Path(item).IndexOf(search.Text.Trim(), StringComparison.CurrentCultureIgnoreCase) >= 0)
                                        For Each command As ToolStripMenuItem In matches
                                            Dim row = grid.Rows.Add(Caption(command), Path(command), If(command.ShortcutKeys = Keys.None, "", New KeysConverter().ConvertToString(command.ShortcutKeys)))
                                            grid.Rows(row).Tag = command
                                            If command Is previous Then grid.CurrentCell = grid.Rows(row).Cells(0)
                                        Next
                                        status.Text = If(grid.Rows.Count = 0, "No available command matches. Try another search or category.",
                                                         grid.Rows.Count.ToString() & " available commands. Select one and choose Open, or press Enter.")
                                        open.Enabled = selected() IsNot Nothing AndAlso CanExecute(selected())
                                    End Sub
            AddHandler search.TextChanged, Sub(sender, e) refresh()
            AddHandler category.SelectedIndexChanged, Sub(sender, e) refresh()
            AddHandler grid.SelectionChanged, Sub(sender, e) open.Enabled = selected() IsNot Nothing AndAlso CanExecute(selected())
            Dim execute As Action = Sub()
                                        Dim command = selected()
                                        If command Is Nothing OrElse Not CanExecute(command) Then
                                            refresh()
                                            Return
                                        End If
                                        command.PerformClick()
                                    End Sub
            AddHandler open.Click, Sub(sender, e) execute()
            AddHandler grid.CellDoubleClick, Sub(sender, e)
                                                 If e.RowIndex >= 0 Then execute()
                                             End Sub
            AddHandler grid.KeyDown, Sub(sender, e)
                                         If e.KeyCode <> Keys.Enter Then Return
                                         e.Handled = True
                                         e.SuppressKeyPress = True
                                         execute()
                                     End Sub
            Dim tracked = menu.Items.OfType(Of ToolStripMenuItem)().SelectMany(Function(item) MenuTree(item)).ToArray()
            Dim sync As EventHandler = Sub(sender, e) refresh()
            For Each item In tracked
                AddHandler item.EnabledChanged, sync
                AddHandler item.AvailableChanged, sync
            Next
            AddHandler layout.Disposed, Sub(sender, e)
                                            For Each item In tracked
                                                RemoveHandler item.EnabledChanged, sync
                                                RemoveHandler item.AvailableChanged, sync
                                            Next
                                        End Sub
            refresh()
            Return layout
        End Function

        Public Function CanExecute(item As ToolStripItem) As Boolean
            If item Is Nothing OrElse Not item.Available OrElse Not item.Enabled Then Return False
            Return item.OwnerItem Is Nothing OrElse CanExecute(item.OwnerItem)
        End Function

        Private Function Leaves(item As ToolStripMenuItem) As IEnumerable(Of ToolStripMenuItem)
            If item.DropDownItems.Count = 0 Then Return New ToolStripMenuItem() {item}
            Return item.DropDownItems.OfType(Of ToolStripMenuItem)().SelectMany(Function(child) Leaves(child))
        End Function

        Private Function MenuTree(item As ToolStripMenuItem) As IEnumerable(Of ToolStripMenuItem)
            Return New ToolStripMenuItem() {item}.Concat(item.DropDownItems.OfType(Of ToolStripMenuItem)().SelectMany(Function(child) MenuTree(child)))
        End Function

        Private Function Caption(item As ToolStripItem) As String
            Return item.Text.Replace("&", "").Trim()
        End Function

        Private Function CategoryName(item As ToolStripItem) As String
            While item.OwnerItem IsNot Nothing
                item = item.OwnerItem
            End While
            Return Caption(item)
        End Function

        Private Function Path(item As ToolStripItem) As String
            Dim parts As New List(Of String)()
            While item IsNot Nothing
                parts.Insert(0, Caption(item))
                item = item.OwnerItem
            End While
            Return String.Join(" · ", parts)
        End Function
    End Module
End Namespace
