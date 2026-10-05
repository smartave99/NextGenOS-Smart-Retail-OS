Option Infer On
Option Explicit On
Option Strict On
Imports System.Drawing
Imports System.Linq
Imports System.Reflection
Imports System.Windows.Forms

Namespace BillPoint
    Public Module RetailAdvancedLayouts
        ' Visible includes every ancestor. Read the local flag so inactive tabs do not erase
        ' business-controlled visibility when their existing controls gain a layout wrapper.
        Private ReadOnly VisibilityState As MethodInfo = GetType(Control).GetMethod("GetState", BindingFlags.Instance Or BindingFlags.NonPublic)

        Public Function OwnVisible(control As Control) As Boolean
            Return CBool(VisibilityState.Invoke(control, New Object() {&H2}))
        End Function

        Public Sub BuildTools(form As frmPOS, tabs As TabControl)
            form.Panel1.Dock = DockStyle.Top
            form.Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            form.Panel1.AutoScroll = False
            Dim commands As New Dictionary(Of String, String) From {
                {"btnFirst", "First invoice"}, {"txtPrev", "Previous invoice"},
                {"btnNext", "Next invoice"}, {"btnLast", "Last invoice"},
                {"btnPhonePe", "Collect by UPI · Alt+&Y"}, {"Button17", "Set bill discount"},
                {"Button31", "Browse touch products"}, {"Button6", "Prepare SMS"},
                {"Button35", "Open reminders"}, {"Button34", "Read cart aloud"},
                {"Button25", "Enable weighing scale"}, {"Button32", "Disable weighing scale"},
                {"Button24", "Previous sales"}, {"Button21", "Open calculator"},
                {"Button20", "Lock screen"}, {"Button22", "Add customer"},
                {"Button5", "WhatsApp invoice"}, {"btnSelectSalesman", "Choose salesperson · F8"},
                {"btnNew", "New sale · F1"}, {"btnUpdate", "Update invoice · F3"},
                {"btnDelete", "Delete invoice · F4"}, {"btnGetData", "Find invoice · F5"},
                {"btnPrint", "Print invoice · F6"}, {"btnScanItems", "Scan items · F7"},
                {"btnhold", "Hold sale"}, {"btnunhold", "Recall sale"},
                {"Button19", "Customer ledger"}, {"Button23", "Add product"},
                {"Button33", "Product ledger"}, {"Button30", "Calculate sale amount"},
                {"Button38", "Copy quotation"}, {"Button37", "Copy estimate"},
                {"btnClose", "Back to sale"}}
            For Each entry In commands
                Dim action = TryCast(form.Controls.Find(entry.Key, True).FirstOrDefault(), Button)
                If action IsNot Nothing Then action.Text = entry.Value
            Next
            AddHandler form.btnClose.Click, Sub(sender, e) tabs.SelectedIndex = 0
            form.Label1.Text = "Invoice tools"
            ' The fields moved into New sale already have captions there.
            For Each caption As Label In {form.Label3, form.Label9, form.Label19, form.Label21, form.Label18, form.lblUnit, form.Label17, form.Label31, form.Label35, form.Label34, form.Label59, form.Label61, form.Label100, form.Label37}
                caption.Visible = False
            Next
            Dim captions = MatchCaptions(form.Panel1)
            Reflow(form.Panel1, True, captions)
        End Sub

        Public Function GroupTools(form As frmPOS, page As TabPage) As TabControl
            Dim groups As New TabControl With {.Name = "RetailToolGroups", .Dock = DockStyle.Fill, .Font = RetailUI.TypeFont("subhead"), .Padding = New Point(RetailUI.Space * 2, RetailUI.Space), .ItemSize = New Size(RetailUI.FieldHeight, RetailUI.TouchHeight)}
            Dim sections As Control()() = {
                New Control() {form.TableLayoutPanel1, form.TableLayoutPanel8},
                New Control() {form.Panel10},
                New Control() {form.Panel11, form.Panel3},
                New Control() {form.Panel13, form.Panel14, form.TableLayoutPanel10, form.TabControl1, form.TabControl2},
                New Control() {form.Panel2},
                New Control() {form.Panel1, form.TabControl3}}
            Dim titles = {"Invoice", "Customer", "Items", "Charges", "Utilities", "More details"}
            For index As Integer = 0 To titles.Length - 1
                Dim group As New TabPage(titles(index)) With {.AutoScroll = True, .Padding = New Padding(RetailUI.Space), .BackColor = RetailUI.Tone("surface")}
                RetailUI.StyleSurface(group, "surface")
                groups.TabPages.Add(group)
                Dim stack = RetailUI.Stack()
                stack.Padding = New Padding(RetailUI.Space)
                group.Controls.Add(stack)
                For Each section As Control In sections(index)
                    Dim row = stack.RowCount
                    stack.RowCount += 1
                    stack.RowStyles.Add(New RowStyle(SizeType.AutoSize))
                    section.Dock = DockStyle.Top
                    If section Is form.TabControl3 OrElse section Is form.Panel3 Then
                        Dim retained As New Panel With {.Dock = DockStyle.Top, .AutoSize = True, .Visible = False, .Name = "RetailRetained_" & section.Name}
                        retained.Controls.Add(section)
                        stack.Controls.Add(retained, 0, row)
                        If section Is form.Panel3 Then
                            retained.Visible = OwnVisible(form.dgw)
                            AddHandler form.dgw.VisibleChanged, Sub(sender, e) retained.Visible = OwnVisible(form.dgw)
                        End If
                    Else
                        stack.Controls.Add(section, 0, row)
                    End If
                Next
            Next
            page.Controls.Add(groups)
            groups.BringToFront()
            Return groups
        End Function

        Private Sub Reflow(container As Control, vertical As Boolean, captions As Dictionary(Of Control, Label))
            Dim children = container.Controls.Cast(Of Control)().OrderBy(Function(child) child.Top).ThenBy(Function(child) child.Left).ToArray()
            Dim table = TryCast(container, TableLayoutPanel)
            If table IsNot Nothing Then
                table.ColumnStyles.Clear()
                table.RowStyles.Clear()
                table.ColumnCount = 1
                table.RowCount = 1
                table.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
                table.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            End If
            container.SuspendLayout()
            container.BackgroundImage = Nothing
            Dim surface = TryCast(container, Panel)
            If surface IsNot Nothing Then surface.BorderStyle = BorderStyle.None
            If table IsNot Nothing Then table.CellBorderStyle = TableLayoutPanelCellBorderStyle.None
            Dim flow As New FlowLayoutPanel With {.Name = "RetailTools_" & container.Name, .Dock = DockStyle.Top, .AutoSize = True, .AutoSizeMode = AutoSizeMode.GrowAndShrink, .WrapContents = Not vertical, .FlowDirection = If(vertical, FlowDirection.TopDown, FlowDirection.LeftToRight), .Margin = New Padding(0), .Padding = New Padding(RetailUI.Space), .BackColor = RetailUI.Tone("surface")}
            For Each child In children
                If TypeOf child Is Label AndAlso captions.ContainsValue(DirectCast(child, Label)) Then Continue For
                Dim item = LayoutItem(child, captions)
                flow.Controls.Add(item)
            Next
            container.Controls.Add(flow)
            container.Padding = New Padding(0)
            container.Margin = New Padding(RetailUI.Space)
            Dim resize As Action = Sub()
                                       Dim width = Math.Max(RetailUI.FieldHeight * 3, container.ClientSize.Width - flow.Padding.Horizontal - RetailUI.Space * 2)
                                       For Each item As Control In flow.Controls
                                           If (TypeOf item Is Panel AndAlso Not item.Name.StartsWith("RetailToolsField_", StringComparison.Ordinal)) OrElse TypeOf item Is TabControl Then item.Width = width
                                       Next
                                       Dim height = flow.GetPreferredSize(New Size(container.ClientSize.Width, 0)).Height + RetailUI.Space
                                       If Not TypeOf container Is TabPage AndAlso container.Height <> height Then container.Height = height
                                   End Sub
            AddHandler container.SizeChanged, Sub(sender, e) resize()
            AddHandler container.VisibleChanged, Sub(sender, e) resize()
            AddHandler flow.Layout, Sub(sender, e) resize()
            resize()
            container.ResumeLayout(True)
        End Sub

        Private Function LayoutItem(control As Control, captions As Dictionary(Of Control, Label)) As Control
            Dim tabs = TryCast(control, TabControl)
            If tabs IsNot Nothing Then
                tabs.Dock = DockStyle.None
                tabs.Font = RetailUI.TypeFont("subhead")
                tabs.ItemSize = New Size(RetailUI.FieldHeight, RetailUI.TouchHeight)
                tabs.Padding = New Point(RetailUI.Space, RetailUI.Space)
                tabs.Height = RetailUI.FieldHeight * 4
                For Each page As TabPage In tabs.TabPages
                    page.AutoScroll = True
                    Reflow(page, False, captions)
                Next
                Return tabs
            End If
            If TypeOf control Is Panel Then
                control.Dock = DockStyle.None
                Reflow(control, False, captions)
                Return control
            End If
            Dim field = TypeOf control Is TextBoxBase OrElse TypeOf control Is ComboBox OrElse TypeOf control Is DateTimePicker OrElse TypeOf control Is NumericUpDown
            If field Then Return InputFrame(control, captions)
            control.Dock = DockStyle.None
            control.Anchor = AnchorStyles.Top Or AnchorStyles.Left
            control.Margin = New Padding(RetailUI.Space)
            Dim action = TryCast(control, Button)
            If action IsNot Nothing Then
                action.MinimumSize = New Size(RetailUI.TouchHeight, RetailUI.TouchHeight)
                action.Size = New Size(RetailUI.FieldHeight * 2, RetailUI.TouchHeight)
                action.TabStop = True
                If Not String.IsNullOrWhiteSpace(action.Text) Then RetailUI.StyleButton(action)
                Return action
            End If
            Dim label = TryCast(control, Label)
            If label IsNot Nothing Then
                label.AutoSize = False
                label.Font = RetailUI.TypeFont("footnote")
                label.Size = New Size(RetailUI.FieldHeight * 3, RetailUI.TouchHeight)
                label.TextAlign = ContentAlignment.MiddleLeft
                Return label
            End If
            If TypeOf control Is CheckBox OrElse TypeOf control Is RadioButton Then
                control.AutoSize = False
                control.Font = RetailUI.TypeFont("subhead")
                control.Size = New Size(RetailUI.FieldHeight * 3, RetailUI.TouchHeight)
                control.MinimumSize = New Size(RetailUI.TouchHeight, RetailUI.TouchHeight)
            ElseIf TypeOf control Is DataGridView Then
                control.Size = New Size(RetailUI.FieldHeight * 3, RetailUI.TouchHeight + RetailUI.RowHeight * 4)
            ElseIf TypeOf control Is PictureBox Then
                DirectCast(control, PictureBox).SizeMode = PictureBoxSizeMode.Zoom
                control.Size = New Size(RetailUI.FieldHeight * 2, RetailUI.RowHeight * 2)
            End If
            Return control
        End Function

        Private Function InputFrame(input As Control, captions As Dictionary(Of Control, Label)) As Control
            Dim visible = OwnVisible(input)
            Dim frame As New RetailUI.FieldFrame(input) With {.Name = "RetailToolsField_" & input.Name, .Dock = DockStyle.None, .Size = New Size(RetailUI.FieldHeight * 3, RetailUI.TouchHeight), .Margin = New Padding(RetailUI.Space), .Visible = visible}
            input.TabStop = Not (TypeOf input Is TextBoxBase AndAlso DirectCast(input, TextBoxBase).ReadOnly)
            AddHandler input.VisibleChanged, Sub(sender, e) frame.Visible = OwnVisible(input)
            Dim caption As Label = Nothing
            If captions.TryGetValue(input, caption) Then
                Dim tile As New TableLayoutPanel With {.Name = frame.Name, .ColumnCount = 1, .RowCount = 2, .Size = New Size(RetailUI.FieldHeight * 3, RetailUI.FieldHeight), .Margin = New Padding(RetailUI.Space), .Visible = visible}
                tile.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
                tile.RowStyles.Add(New RowStyle(SizeType.Absolute, RetailUI.Inset))
                tile.RowStyles.Add(New RowStyle(SizeType.Absolute, RetailUI.TouchHeight))
                caption.Dock = DockStyle.Fill
                caption.Margin = New Padding(0)
                caption.AutoSize = False
                caption.Font = RetailUI.TypeFont("footnote")
                caption.TextAlign = ContentAlignment.MiddleLeft
                frame.Dock = DockStyle.Fill
                frame.Margin = New Padding(0)
                tile.Controls.Add(caption, 0, 0)
                tile.Controls.Add(frame, 0, 1)
                input.AccessibleName = caption.Text.Trim().TrimEnd(":"c)
                AddHandler input.VisibleChanged, Sub(sender, e) tile.Visible = OwnVisible(input)
                Return tile
            End If
            Return frame
        End Function

        Private Function MatchCaptions(root As Control) As Dictionary(Of Control, Label)
            Dim controls = Descendants(root).ToArray()
            Dim labels = controls.OfType(Of Label)().Where(Function(caption) Not TypeOf caption Is LinkLabel AndAlso OwnVisible(caption) AndAlso caption.Text.Any(Function(character) Char.IsLetter(character))).ToList()
            Dim result As New Dictionary(Of Control, Label)()
            For Each input As Control In controls.Where(Function(candidate) (TypeOf candidate Is TextBoxBase OrElse TypeOf candidate Is ComboBox OrElse TypeOf candidate Is DateTimePicker OrElse TypeOf candidate Is NumericUpDown) AndAlso OwnVisible(candidate))
                Dim inputBounds = OriginalBounds(input, root)
                Dim best As Label = Nothing
                Dim bestScore = Integer.MaxValue
                For Each caption As Label In labels
                    If OriginalSection(input, root) IsNot OriginalSection(caption, root) Then Continue For
                    Dim bounds = OriginalBounds(caption, root)
                    Dim score = CaptionDistance(bounds, inputBounds)
                    If score >= bestScore Then Continue For
                    best = caption
                    bestScore = score
                Next
                If best Is Nothing OrElse bestScore = Integer.MaxValue Then Continue For
                result.Add(input, best)
                labels.Remove(best)
            Next
            Return result
        End Function

        Private Function CaptionDistance(caption As Rectangle, input As Rectangle) As Integer
            If Math.Abs(caption.Top - input.Top) <= RetailUI.Inset AndAlso caption.Right <= input.Left + RetailUI.Space Then
                Return Math.Abs(caption.Top - input.Top) * RetailUI.Space * 2 + Math.Abs(input.Left - caption.Right)
            End If
            If Math.Abs(caption.Left - input.Left) <= RetailUI.Space * 2 AndAlso caption.Top <= input.Top AndAlso input.Top - caption.Bottom <= RetailUI.Inset Then
                Return Math.Abs(caption.Left - input.Left) * RetailUI.Space + Math.Abs(input.Top - caption.Bottom) * RetailUI.Space
            End If
            Return Integer.MaxValue
        End Function

        Private Function OriginalSection(control As Control, root As Control) As Control
            While control.Parent IsNot Nothing AndAlso control.Parent IsNot root
                If TypeOf control.Parent Is TabPage Then Return control.Parent
                control = control.Parent
            End While
            Return control
        End Function

        Private Function OriginalBounds(control As Control, root As Control) As Rectangle
            Dim location = control.Location
            Dim parent = control.Parent
            While parent IsNot Nothing AndAlso parent IsNot root
                location.Offset(parent.Location)
                parent = parent.Parent
            End While
            Return New Rectangle(location, control.Size)
        End Function

        Private Iterator Function Descendants(parent As Control) As Collections.Generic.IEnumerable(Of Control)
            For Each child As Control In parent.Controls
                Yield child
                If TypeOf child Is DataGridView OrElse TypeOf child Is TextBoxBase OrElse TypeOf child Is NumericUpDown Then Continue For
                For Each descendant In Descendants(child)
                    Yield descendant
                Next
            Next
        End Function

        Public Sub BuildPaymentOverlay(form As frmPOS)
            Dim panel = form.PanelUPI
            panel.SuspendLayout()
            panel.Size = New Size(RetailUI.LoginWidth, RetailUI.FieldHeight * 8)
            panel.BorderStyle = BorderStyle.FixedSingle
            Dim original = panel.Controls.Cast(Of Control)().ToArray()
            Dim stack = RetailUI.Stack()
            stack.Padding = New Padding(RetailUI.Space * 2)
            stack.Margin = New Padding(0)
            stack.Dock = DockStyle.Top
            panel.Controls.Add(stack)
            Dim heading As New TableLayoutPanel With {.ColumnCount = 2, .RowCount = 1, .Dock = DockStyle.Fill, .Margin = New Padding(0)}
            heading.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 65))
            heading.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 35))
            heading.Controls.Add(RetailUI.Label("UPI payment", "title-2"), 0, 0)
            form.btnHideP6.Text = "Close · Alt+&Z"
            RetailUI.StyleButton(form.btnHideP6)
            form.btnHideP6.Dock = DockStyle.Fill
            form.btnHideP6.Margin = New Padding(0)
            heading.Controls.Add(form.btnHideP6, 1, 0)
            RetailUI.AddRow(stack, heading, RetailUI.TouchHeight + RetailUI.Space)
            AddPaymentIdentity(stack, form)
            Dim identity = New TableLayoutPanel With {.ColumnCount = 2, .RowCount = 1, .Dock = DockStyle.Fill, .Margin = New Padding(0)}
            identity.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50))
            identity.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50))
            identity.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
            Dim orderField = RetailUI.Field(form.tBoxOrderId, "Order ID")
            Dim amountField = RetailUI.Field(form.tBoxAmount, "Amount")
            orderField.Margin = New Padding(0, 0, RetailUI.Space, 0)
            amountField.Margin = New Padding(0)
            identity.Controls.Add(orderField, 0, 0)
            identity.Controls.Add(amountField, 1, 0)
            RetailUI.AddRow(stack, identity, RetailUI.FieldHeight)
            AddOverlayField(stack, form.tBoxConfirmation, "Status")
            Dim actions = New Button() {form.buttonReloadUPIId, form.btnLastTxns, form.btnCancel}
            form.buttonReloadUPIId.Text = "Refresh UPI ID"
            form.btnLastTxns.Text = "Recent payments"
            form.btnCancel.Text = "Cancel payment"
            AddOverlayActions(stack, actions)
            Dim links As New FlowLayoutPanel With {.Dock = DockStyle.Fill, .Margin = New Padding(0)}
            form.LinkLabel1.Text = "Turn on customer display"
            form.LinkLabel2.Text = "Turn off customer display"
            For Each link In {form.LinkLabel1, form.LinkLabel2}
                link.AutoSize = False
                link.Size = New Size(RetailUI.FieldHeight * 3, RetailUI.TouchHeight)
                link.Font = RetailUI.TypeFont("footnote")
                link.Margin = New Padding(0, 0, RetailUI.Space, 0)
                links.Controls.Add(link)
            Next
            RetailUI.AddRow(stack, links, RetailUI.TouchHeight + RetailUI.Space)
            Dim log = New RetailUI.FieldFrame(form.tBoxLog)
            RetailUI.AddRow(stack, log, RetailUI.RowHeight * 2)
            ' Keep QR and initialization controls with their own business visibility flags.
            Dim provider As New FlowLayoutPanel With {.Dock = DockStyle.Top, .AutoSize = True, .WrapContents = True, .Margin = New Padding(0)}
            For Each child In original.Where(Function(candidate) candidate.Parent Is panel)
                If TypeOf child Is Label AndAlso Not TypeOf child Is LinkLabel Then
                    child.Visible = False
                Else
                    provider.Controls.Add(LayoutItem(child, New Dictionary(Of Control, Label)()))
                End If
            Next
            Dim providerRow = stack.RowCount
            stack.RowCount += 1
            stack.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            stack.Controls.Add(provider, 0, providerRow)
            panel.AutoScroll = True
            panel.ResumeLayout(True)
        End Sub

        Private Sub AddPaymentIdentity(stack As TableLayoutPanel, form As frmPOS)
            Dim row As New TableLayoutPanel With {.ColumnCount = 2, .RowCount = 1, .Dock = DockStyle.Fill, .Margin = New Padding(0)}
            row.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 35))
            row.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 65))
            form.lblMyUPIID.Text = "UPI ID"
            For Each identityLabel As Label In {form.lblMyUPIID, form.lblValUPIId}
                identityLabel.AutoSize = False
                identityLabel.Font = RetailUI.TypeFont("subhead")
                identityLabel.Dock = DockStyle.Fill
                identityLabel.TextAlign = ContentAlignment.MiddleLeft
            Next
            row.Controls.Add(form.lblMyUPIID, 0, 0)
            row.Controls.Add(form.lblValUPIId, 1, 0)
            RetailUI.AddRow(stack, row, RetailUI.TouchHeight)
        End Sub

        Private Sub AddOverlayField(stack As TableLayoutPanel, input As Control, caption As String)
            RetailUI.AddRow(stack, RetailUI.Field(input, caption), RetailUI.FieldHeight)
        End Sub

        Private Sub AddOverlayActions(stack As TableLayoutPanel, actions As Button())
            Dim row As New TableLayoutPanel With {.ColumnCount = actions.Length, .RowCount = 1, .Dock = DockStyle.Fill, .Margin = New Padding(0)}
            For index As Integer = 0 To actions.Length - 1
                row.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F / actions.Length))
                RetailUI.StyleButton(actions(index))
                actions(index).Dock = DockStyle.Fill
                actions(index).Margin = New Padding(0, 0, If(index = actions.Length - 1, 0, RetailUI.Space), 0)
                row.Controls.Add(actions(index), index, 0)
            Next
            RetailUI.AddRow(stack, row, RetailUI.TouchHeight + RetailUI.Space)
        End Sub
    End Module
End Namespace
