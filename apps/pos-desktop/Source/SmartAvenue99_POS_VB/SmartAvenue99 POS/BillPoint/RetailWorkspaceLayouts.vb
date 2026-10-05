Option Infer On
Option Explicit On
Option Strict On
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Namespace BillPoint
    ' Grouped form/data-workspace adapter. Original controls and containers own business state.
    Public Module RetailWorkspaceLayouts
        Private Const GridHeight As Integer = RetailUI.RowHeight * 6 + RetailUI.TouchHeight
        Private Const DocumentHeight As Integer = RetailUI.RowHeight * 10
        Private ReadOnly LocalState As Reflection.MethodInfo = GetType(Control).GetMethod("GetState", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)

        Public Function IsLocallyVisible(control As Control) As Boolean
            Return CBool(LocalState.Invoke(control, New Object() {&H2}))
        End Function

        Public Sub Build(form As System.Windows.Forms.Form)
            Dim originals = form.Controls.Cast(Of Control)().ToArray()
            Dim isDialog = form.ClientSize.Width <= RetailUI.LoginWidth AndAlso form.ClientSize.Height <= RetailUI.RowHeight * 8 AndAlso Not Descendants(form).OfType(Of DataGridView)().Any()
            Dim primary = Descendants(form).OfType(Of Button)().FirstOrDefault(Function(action) IsLocallyVisible(action) AndAlso
                (action.Name.Equals("btnSave", StringComparison.OrdinalIgnoreCase) OrElse action.Text.Replace("&", "").Trim().Equals("Save", StringComparison.OrdinalIgnoreCase)))
            Dim viewport As New Panel With {.Name = "RetailFormViewport", .Dock = DockStyle.Fill, .AutoScroll = True, .Padding = New Padding(RetailUI.Inset)}
            RetailUI.StyleSurface(viewport, "canvas")
            Dim content = BuildGroup(originals, primary)
            content.Name = "RetailFormContent"
            viewport.Controls.Add(content)
            form.Controls.Add(viewport)
            viewport.BringToFront()
            AddPinnedActions(form, originals)
            For Each control In Descendants(form).Where(Function(child) child.TabStop OrElse TypeOf child Is Button OrElse TypeOf child Is CheckBox OrElse TypeOf child Is RadioButton OrElse TypeOf child Is LinkLabel)
                If String.IsNullOrWhiteSpace(control.AccessibleName) Then
                    control.AccessibleName = If(String.IsNullOrWhiteSpace(control.Text), ReadableName(control.Name), control.Text.Replace("&", "").Trim())
                End If
                If TypeOf control Is Button OrElse TypeOf control Is CheckBox OrElse TypeOf control Is RadioButton OrElse TypeOf control Is LinkLabel Then control.TabStop = True
            Next
            form.AutoScaleMode = AutoScaleMode.None
            form.Font = RetailUI.TypeFont("subhead")
            form.MinimumSize = If(isDialog, New Size(RetailUI.LoginWidth, RetailUI.RowHeight * 8), New Size(RetailUI.MinimumWidth, RetailUI.MinimumHeight))
            form.FormBorderStyle = FormBorderStyle.Sizable
            form.MaximizeBox = True
            form.Size = New Size(Math.Min(If(isDialog, RetailUI.LoginWidth, RetailUI.DesktopWidth), Screen.FromControl(form).WorkingArea.Width),
                                 Math.Min(If(isDialog, RetailUI.RowHeight * 8, RetailUI.DesktopHeight), Screen.FromControl(form).WorkingArea.Height))
            AddHandler viewport.ClientSizeChanged, Sub(sender, e) FitContent(content, viewport.ClientSize.Width)
            FitContent(content, viewport.ClientSize.Width)
            form.AccessibleName = If(String.IsNullOrWhiteSpace(form.Text), ScreenCaption(originals, form.Name), form.Text)
            If String.IsNullOrWhiteSpace(form.Text) Then form.Text = form.AccessibleName
            Dim beginForm As Action = Sub()
                                          Dim first = Descendants(content).FirstOrDefault(Function(control) IsInput(control) AndAlso control.TabStop AndAlso control.Visible AndAlso control.Enabled AndAlso
                                              (Not TypeOf control Is TextBox OrElse Not DirectCast(control, TextBox).ReadOnly))
                                          If first IsNot Nothing Then first.Focus()
                                          viewport.AutoScrollPosition = Point.Empty
                                      End Sub
            AddHandler form.Shown, Sub(sender, e) beginForm()
            If form.Visible Then beginForm()
        End Sub

        Public Function Descendants(parent As Control) As IEnumerable(Of Control)
            Return parent.Controls.Cast(Of Control)().SelectMany(Function(child) New Control() {child}.Concat(Descendants(child)))
        End Function

        Private Sub AddPinnedActions(form As System.Windows.Forms.Form, originals As Control())
            Dim names = {"btnNew", "btnSave", "btnUpdate", "btnDelete", "btnGetData"}
            Dim actions = originals.SelectMany(Function(control) New Control() {control}.Concat(Descendants(control))).OfType(Of Button)().
                Where(Function(action) names.Contains(action.Name) AndAlso Not HasTabAncestor(action)).Distinct().ToArray()
            If actions.Length = 0 Then Return
            Dim footer As New FlowLayoutPanel With {.Name = "RetailPinnedActions", .Dock = DockStyle.Bottom,
                .Height = RetailUI.TouchHeight + RetailUI.Inset, .Padding = New Padding(RetailUI.Inset, RetailUI.Space, RetailUI.Inset, RetailUI.Space), .WrapContents = False}
            RetailUI.StyleSurface(footer, "surface")
            For Each original As Button In actions
                Dim pinned As New Button With {.Name = "RetailPinned_" & original.Name, .Text = original.Text,
                    .Size = New Size(RetailUI.Inset * 7, RetailUI.TouchHeight), .Margin = New Padding(0, 0, RetailUI.Space, 0)}
                RetailUI.StyleButton(original, False, original.Name = "btnDelete")
                RetailUI.StyleButton(pinned, original.Name = "btnSave", original.Name = "btnDelete")
                Dim synchronize As EventHandler = Sub(sender, e)
                                                      pinned.Visible = original.Visible
                                                      pinned.Enabled = original.Enabled
                                                      pinned.Text = original.Text
                                                  End Sub
                AddHandler pinned.Click, Sub(sender, e)
                                             If original.Visible AndAlso original.Enabled Then original.PerformClick()
                                         End Sub
                Dim ancestry As New List(Of Control)()
                Dim ancestor As Control = original
                While ancestor IsNot Nothing
                    ancestry.Add(ancestor)
                    AddHandler ancestor.EnabledChanged, synchronize
                    AddHandler ancestor.VisibleChanged, synchronize
                    ancestor = ancestor.Parent
                End While
                AddHandler original.TextChanged, synchronize
                AddHandler pinned.Disposed, Sub(sender, e)
                                                For Each source In ancestry
                                                    RemoveHandler source.EnabledChanged, synchronize
                                                    RemoveHandler source.VisibleChanged, synchronize
                                                Next
                                                RemoveHandler original.TextChanged, synchronize
                                            End Sub
                footer.Controls.Add(pinned)
                synchronize(Nothing, EventArgs.Empty)
            Next
            form.Controls.Add(footer)
            footer.BringToFront()
        End Sub

        Private Function HasTabAncestor(control As Control) As Boolean
            Dim ancestor = control.Parent
            While ancestor IsNot Nothing
                If TypeOf ancestor Is TabPage Then Return True
                ancestor = ancestor.Parent
            End While
            Return False
        End Function

        Private Function ScreenCaption(controls As Control(), fallback As String) As String
            Dim caption = controls.SelectMany(Function(child) New Control() {child}.Concat(Descendants(child))).OfType(Of Label)().
                FirstOrDefault(Function(label) IsLocallyVisible(label) AndAlso label.Text.Trim().Length > 3 AndAlso label.Font.Bold)
            Return If(caption Is Nothing, fallback, caption.Text.Replace("&", "").Trim())
        End Function

        Private Function BuildGroup(originals As Control(), primary As Button) As TableLayoutPanel
            Dim positions = originals.ToDictionary(Function(control) control, Function(control) control.Bounds)
            Dim labels = originals.OfType(Of Label)().Where(Function(label) Not TypeOf label Is LinkLabel AndAlso IsLocallyVisible(label)).ToList()
            Dim associations As New Dictionary(Of Control, Label)()
            For Each input As Control In originals.Where(Function(control) IsInput(control) AndAlso IsLocallyVisible(control)).OrderBy(Function(control) positions(control).Top).ThenBy(Function(control) positions(control).Left)
                Dim caption = FindCaption(input, labels, positions)
                If caption Is Nothing Then Continue For
                associations.Add(input, caption)
                labels.Remove(caption)
            Next
            Dim used = New HashSet(Of Control)(associations.Values.Cast(Of Control)())
            Dim layout As New TableLayoutPanel With {.Dock = DockStyle.Top, .AutoSize = True, .AutoSizeMode = AutoSizeMode.GrowAndShrink,
                .ColumnCount = 1, .RowCount = 0, .Margin = New Padding(0), .Padding = New Padding(RetailUI.Space)}
            RetailUI.StyleSurface(layout, "surface")
            layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
            Dim fields As FlowLayoutPanel = Nothing
            Dim actions As FlowLayoutPanel = Nothing
            Dim hasFields = originals.SelectMany(Function(control) New Control() {control}.Concat(Descendants(control))).Any(Function(control) IsInput(control) AndAlso IsLocallyVisible(control))
            For Each child In originals.OrderBy(Function(control) If(hasFields AndAlso TypeOf control Is PictureBox, 1, 0)).ThenBy(Function(control) positions(control).Top).ThenBy(Function(control) positions(control).Left)
                If used.Contains(child) Then Continue For
                If IsInput(child) Then
                    If fields Is Nothing Then
                        fields = New FlowLayoutPanel With {.AutoSize = True, .AutoSizeMode = AutoSizeMode.GrowAndShrink, .WrapContents = True, .Dock = DockStyle.Top, .Margin = New Padding(0)}
                        AddBlock(layout, fields)
                        AddHandler fields.ClientSizeChanged, AddressOf FitFields
                    End If
                    Dim caption As Label = Nothing
                    associations.TryGetValue(child, caption)
                    Dim field = BuildField(child, caption)
                    field.TabIndex = fields.Controls.Count
                    fields.Controls.Add(field)
                    Continue For
                End If
                PrepareControl(child, primary)
                If TypeOf child Is Button Then
                    If actions Is Nothing Then
                        actions = New FlowLayoutPanel With {.Dock = DockStyle.Top, .AutoSize = True, .AutoSizeMode = AutoSizeMode.GrowAndShrink, .WrapContents = True}
                        AddBlock(layout, actions)
                    End If
                    child.Dock = DockStyle.None
                    child.Width = RetailUI.Inset * 7
                    child.Margin = New Padding(RetailUI.Space)
                    child.TabIndex = actions.Controls.Count
                    actions.Controls.Add(child)
                    Continue For
                End If
                AddBlock(layout, child)
            Next
            Return layout
        End Function

        Private Function IsInput(control As Control) As Boolean
            Return TypeOf control Is TextBoxBase OrElse TypeOf control Is ComboBox OrElse TypeOf control Is DateTimePicker OrElse TypeOf control Is NumericUpDown
        End Function

        Private Function FindCaption(input As Control, labels As List(Of Label), positions As Dictionary(Of Control, Rectangle)) As Label
            Dim bounds = positions(input)
            Dim leftCaption = labels.Where(Function(label) positions(label).Right <= bounds.Left + RetailUI.Space AndAlso
                Math.Abs(positions(label).Top - bounds.Top) <= RetailUI.Inset).OrderBy(Function(label) bounds.Left - positions(label).Right +
                Math.Abs(positions(label).Top - bounds.Top) * RetailUI.Space).FirstOrDefault()
            If leftCaption IsNot Nothing Then Return leftCaption
            Return labels.Where(Function(label) positions(label).Bottom <= bounds.Top AndAlso bounds.Top - positions(label).Bottom <= RetailUI.Inset AndAlso
                positions(label).Left < bounds.Right AndAlso positions(label).Right > bounds.Left).OrderBy(Function(label) bounds.Top - positions(label).Bottom).FirstOrDefault()
        End Function

        Private Function BuildField(input As Control, caption As Label) As Control
            Dim field As New TableLayoutPanel With {.Height = RetailUI.FieldHeight + RetailUI.Space, .ColumnCount = 1, .RowCount = 2,
                .Margin = New Padding(RetailUI.Space), .TabIndex = input.TabIndex}
            field.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
            field.RowStyles.Add(New RowStyle(SizeType.Absolute, RetailUI.Inset))
            field.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
            If caption Is Nothing Then caption = RetailUI.Label(ReadableName(input.Name), "footnote")
            caption.AutoSize = False
            caption.Dock = DockStyle.Fill
            caption.Font = RetailUI.TypeFont("footnote")
            caption.TextAlign = ContentAlignment.MiddleLeft
            caption.Margin = New Padding(0)
            field.Controls.Add(caption, 0, 0)
            input.AccessibleName = caption.Text.Replace("&", "").Trim().TrimEnd(":"c)
            AddHandler caption.TextChanged, Sub(sender, e) input.AccessibleName = caption.Text.Replace("&", "").Trim().TrimEnd(":"c)
            Dim multiline = TryCast(input, TextBox)
            If multiline IsNot Nothing AndAlso multiline.Multiline Then field.Height = RetailUI.FieldHeight * 2
            field.Controls.Add(New RetailUI.FieldFrame(input), 0, 1)
            input.TabIndex = 0
            field.Visible = IsLocallyVisible(input)
            AddHandler input.VisibleChanged, Sub(sender, e) field.Visible = IsLocallyVisible(input)
            Return field
        End Function

        Private Sub FitFields(sender As Object, e As EventArgs)
            Dim fields = DirectCast(sender, FlowLayoutPanel)
            Dim columns = If(fields.ClientSize.Width >= RetailUI.Inset * 42, 3, If(fields.ClientSize.Width >= RetailUI.Inset * 24, 2, 1))
            Dim width = Math.Max(RetailUI.TouchHeight, (fields.ClientSize.Width - RetailUI.Space * 2 * columns - RetailUI.Space) \ columns)
            For Each field As Control In fields.Controls
                If field.Width <> width Then field.Width = width
            Next
        End Sub

        Private Sub PrepareControl(control As Control, primary As Button)
            If TypeOf control Is Button Then
                Dim action = DirectCast(control, Button)
                RetailUI.StyleButton(action, action Is primary, action.Name.IndexOf("delete", StringComparison.OrdinalIgnoreCase) >= 0)
                action.Height = RetailUI.TouchHeight + RetailUI.Space
                If action.Text.Trim().Length <= 1 Then action.AccessibleName = ReadableName(action.Name)
            ElseIf TypeOf control Is DataGridView Then
                control.Height = GridHeight
                control.AccessibleName = ReadableName(control.Name) & " table"
                RetailUI.NormalizeGridAppearance(DirectCast(control, DataGridView))
            ElseIf TypeOf control Is TabControl Then
                Dim tabs = DirectCast(control, TabControl)
                tabs.Font = RetailUI.TypeFont("subhead")
                tabs.ItemSize = New Size(RetailUI.Inset * 6, RetailUI.TouchHeight)
                tabs.SizeMode = TabSizeMode.Fixed
                tabs.Height = DocumentHeight
                For Each page As TabPage In tabs.TabPages
                    RebuildContainer(page, primary)
                    page.AutoScroll = True
                Next
            ElseIf TypeOf control Is TableLayoutPanel Then
                RetailTableLayouts.Prepare(DirectCast(control, TableLayoutPanel), Sub(child) PrepareControl(child, primary))
            ElseIf TypeOf control Is FlowLayoutPanel Then
                For Each child As Control In control.Controls.Cast(Of Control)().ToArray()
                    PrepareControl(child, primary)
                Next
            ElseIf TypeOf control Is GroupBox OrElse TypeOf control Is Panel Then
                RebuildContainer(control, primary)
            ElseIf TypeOf control Is Label Then
                Dim label = DirectCast(control, Label)
                label.Font = RetailUI.TypeFont(If(label.Font.Bold, "headline", "subhead"))
                label.AutoSize = False
                label.Height = If(TypeOf label Is LinkLabel, RetailUI.TouchHeight, RetailUI.SectionHeight)
                label.TextAlign = ContentAlignment.MiddleLeft
                If TypeOf label Is LinkLabel Then
                    Dim link = DirectCast(label, LinkLabel)
                    link.LinkColor = RetailUI.Tone("accent-text")
                    link.ActiveLinkColor = RetailUI.Tone("accent-text")
                    link.VisitedLinkColor = RetailUI.Tone("accent-text")
                End If
            ElseIf TypeOf control Is CheckBox OrElse TypeOf control Is RadioButton Then
                control.Font = RetailUI.TypeFont("subhead")
                control.Height = RetailUI.TouchHeight
                Dim check = TryCast(control, CheckBox)
                If check IsNot Nothing Then check.AutoSize = False
                Dim radio = TryCast(control, RadioButton)
                If radio IsNot Nothing Then radio.AutoSize = False
            ElseIf TypeOf control Is PictureBox Then
                DirectCast(control, PictureBox).SizeMode = PictureBoxSizeMode.Zoom
                control.Height = Math.Min(DocumentHeight, Math.Max(RetailUI.RowHeight * 2, control.Height))
            ElseIf control.HasChildren Then
                control.Height = DocumentHeight
            End If
            If String.IsNullOrWhiteSpace(control.AccessibleName) AndAlso (control.TabStop OrElse TypeOf control Is Button) Then
                control.AccessibleName = If(String.IsNullOrWhiteSpace(control.Text), ReadableName(control.Name), control.Text.Replace("&", "").Trim())
            End If
        End Sub

        Private Sub RebuildContainer(container As Control, primary As Button)
            Dim children = container.Controls.Cast(Of Control)().ToArray()
            If children.Length = 0 Then Return
            container.SuspendLayout()
            Dim layout = BuildGroup(children, primary)
            container.Controls.Add(layout)
            Dim panel = TryCast(container, Panel)
            If panel IsNot Nothing Then
                panel.AutoSize = True
                panel.AutoSizeMode = AutoSizeMode.GrowAndShrink
                panel.BorderStyle = BorderStyle.None
            End If
            Dim group = TryCast(container, GroupBox)
            If group IsNot Nothing Then
                group.AutoSize = True
                group.AutoSizeMode = AutoSizeMode.GrowAndShrink
                group.Font = RetailUI.TypeFont("headline")
                group.Padding = New Padding(RetailUI.Space, RetailUI.Inset, RetailUI.Space, RetailUI.Space)
            End If
            container.ResumeLayout(True)
        End Sub

        Private Sub AddBlock(layout As TableLayoutPanel, child As Control)
            Dim row = layout.RowCount
            layout.RowCount += 1
            layout.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            child.Dock = DockStyle.Top
            child.Margin = New Padding(0, 0, 0, RetailUI.Space)
            child.TabIndex = row
            layout.Controls.Add(child, 0, row)
        End Sub

        Private Sub FitContent(content As Control, availableWidth As Integer)
            Dim width = Math.Max(RetailUI.Inset * 16, availableWidth - RetailUI.Inset * 2 - SystemInformation.VerticalScrollBarWidth)
            content.Width = width
        End Sub

        Private Function ReadableName(name As String) As String
            Select Case name.ToLowerInvariant()
                Case "txtpermentaddress" : Return "Permanent address"
                Case "txtloyalitypts" : Return "Loyalty points"
                Case "cmbcrlimit" : Return "Credit limit option"
                Case "cboxloyality" : Return "Loyalty points option"
                Case "txthsncode" : Return "HSN code"
            End Select
            Dim value = System.Text.RegularExpressions.Regex.Replace(name, "^(txt|cmb|cbo|btn|chk|rdb|dgw|lbl|num)", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            value = System.Text.RegularExpressions.Regex.Replace(value, "([a-z])([A-Z])", "$1 $2").Replace("_", " ").Trim()
            Return If(value.Length = 0, "Control", value)
        End Function
    End Module
End Namespace
