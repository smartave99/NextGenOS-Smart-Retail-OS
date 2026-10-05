Option Infer On
Option Explicit On
Option Strict On
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Namespace BillPoint
    ' The existing handlers own validation, money and persistence. This module owns navigation.
    Public Module RetailCheckoutLayouts
        Private ReadOnly Sessions As New Runtime.CompilerServices.ConditionalWeakTable(Of frmPOS, CheckoutSession)()

        Private Class CheckoutSession
            Public Pages As TabControl
            Public Groups As TabControl
        End Class

        Public Sub Build(form As frmPOS)
            Dim pages As New RetailPageHost With {.Name = "RetailWorkspace", .Dock = DockStyle.Fill}
            For Each pageTitle As String In {"Cart", "Payment", "Invoice tools"}
                Dim page As New TabPage(pageTitle) With {.Padding = New Padding(0), .BackColor = RetailUI.Tone("surface")}
                RetailUI.StyleSurface(page, "surface")
                pages.TabPages.Add(page)
            Next
            pages.TabPages(2).Controls.Add(form.Panel1)
            Dim shell As New TableLayoutPanel With {.ColumnCount = 1, .Margin = New Padding(0), .BackColor = RetailUI.Tone("canvas")}
            shell.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
            RetailUI.StyleSurface(shell, "canvas")
            RetailUI.StyleSurface(form, "canvas")
            shell.Name = "RetailCheckoutShell"
            shell.Dock = DockStyle.Fill
            shell.AutoSize = False
            shell.Padding = New Padding(RetailUI.Space)
            shell.RowCount = 3
            shell.RowStyles.Add(New RowStyle(SizeType.Absolute, RetailUI.TouchHeight + RetailUI.Space))
            shell.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
            shell.RowStyles.Add(New RowStyle(SizeType.Absolute, RetailUI.TouchHeight + RetailUI.Space * 2))
            Dim body = RetailUI.Columns(2)
            body.ColumnStyles(0).Width = 66
            body.ColumnStyles(1).Width = 34
            body.Controls.Add(pages, 0, 0)
            Dim context = CustomerAndTotals(form)
            context.Margin = New Padding(RetailUI.Space, 0, 0, 0)
            body.Controls.Add(context, 1, 0)
            shell.Controls.Add(body, 0, 1)
            form.Controls.Add(shell)
            shell.BringToFront()

            BuildCart(form, pages)
            BuildPayment(form, pages)
            BuildPopups(form, pages)
            RetailAdvancedLayouts.BuildTools(form, pages)
            Dim groups = RetailAdvancedLayouts.GroupTools(form, pages.TabPages(2))
            Sessions.Add(form, New CheckoutSession With {.Pages = pages, .Groups = groups})

            Dim header = RetailUI.Columns(3)
            header.ColumnStyles(0).Width = 50
            header.ColumnStyles(1).Width = 25
            header.ColumnStyles(2).Width = 25
            Dim title = RetailUI.Label("New sale", "title-2")
            title.Padding = New Padding(RetailUI.Space * 2, 0, 0, 0)
            Dim back = Navigation("Back to cart", "RetailBackToCart")
            Dim newSaleHost As New Panel With {.Name = "RetailNewSaleHost", .Dock = DockStyle.Fill, .Margin = New Padding(0)}
            form.btnNew.Text = "New sale · F1"
            form.btnNew.Dock = DockStyle.Fill
            RetailUI.StyleTextButton(form.btnNew)
            newSaleHost.Controls.Add(form.btnNew)
            Dim tools = Navigation("Invoice tools", "RetailOpenTools")
            header.Controls.Add(title, 0, 0)
            Dim navigationHost As New Panel With {.Dock = DockStyle.Fill, .Margin = New Padding(0)}
            navigationHost.Controls.Add(back)
            navigationHost.Controls.Add(newSaleHost)
            header.Controls.Add(navigationHost, 1, 0)
            header.Controls.Add(tools, 2, 0)
            shell.Controls.Add(header, 0, 0)
            AddHandler back.Click, Sub(sender, e) pages.SelectedIndex = 0
            AddHandler tools.Click, Sub(sender, e) pages.SelectedIndex = 2

            Dim footer = RetailUI.Columns(2)
            footer.ColumnStyles(0).Width = 66
            footer.ColumnStyles(1).Width = 34
            footer.Padding = New Padding(RetailUI.Space * 2, RetailUI.Space, RetailUI.Space * 2, RetailUI.Space)
            Dim guidance = RetailUI.Label("Choose the customer, then scan or find items.", "footnote")
            guidance.ForeColor = RetailUI.Tone("secondary")
            footer.Controls.Add(guidance, 0, 0)
            Dim actions As New Panel With {.Dock = DockStyle.Fill, .Margin = New Padding(0)}
            Dim review = Navigation("Review payment · F2", "RetailReviewPayment")
            RetailUI.StyleButton(review, True)
            form.btnSave.Text = "Save invoice · F2"
            form.btnSave.Dock = DockStyle.Fill
            form.btnSave.Margin = New Padding(0)
            RetailUI.StyleButton(form.btnSave, True)
            ' Hide the wrapper, preserving the business-controlled local flag on Save.
            Dim saveHost As New Panel With {.Name = "RetailSaveHost", .Dock = DockStyle.Fill}
            saveHost.Controls.Add(form.btnSave)
            Dim pending = Navigation("Record payment first", "RetailPaymentRequired")
            RetailUI.StyleButton(pending)
            pending.Enabled = False
            actions.Controls.Add(review)
            actions.Controls.Add(saveHost)
            actions.Controls.Add(pending)
            footer.Controls.Add(actions, 1, 0)
            shell.Controls.Add(footer, 0, 2)
            AddHandler review.Click, Sub(sender, e) pages.SelectedIndex = 1
            Dim refresh As Action = Sub()
                                       title.Text = If(pages.SelectedIndex = 0, "New sale", If(pages.SelectedIndex = 1, "Review payment", "Invoice tools"))
                                       back.Visible = pages.SelectedIndex <> 0
                                       newSaleHost.Visible = pages.SelectedIndex = 0
                                       tools.Visible = pages.SelectedIndex <> 2
                                       Dim hasPayments = HasItems(form.DataGridView2)
                                       saveHost.Visible = pages.SelectedIndex = 1 AndAlso hasPayments AndAlso HasItems(form.DataGridView1)
                                       pending.Visible = pages.SelectedIndex = 1 AndAlso Not saveHost.Visible
                                       pending.Text = If(HasItems(form.DataGridView1), "Record payment first", "Add items to the cart first")
                                       review.Visible = pages.SelectedIndex <> 1
                                       review.Enabled = HasItems(form.DataGridView1)
                                       body.ColumnStyles(1).SizeType = If(pages.SelectedIndex = 2, SizeType.Absolute, SizeType.Percent)
                                       body.ColumnStyles(1).Width = If(pages.SelectedIndex = 2, 0, 34)
                                       context.Visible = pages.SelectedIndex <> 2
                                       guidance.Text = If(pages.SelectedIndex = 0, "Choose the customer, then scan or find items.", If(pages.SelectedIndex = 1, "Record the payment below, then save the invoice.", "Invoice changes and extra actions are grouped by task."))
                                       If pages.SelectedIndex = 1 AndAlso Not form.btnSave.Enabled Then guidance.Text = "Saving is unavailable. Review the invoice status in Invoice tools."
                                   End Sub
            AddHandler pages.SelectedIndexChanged, Sub(sender, e) refresh()
            AddHandler form.btnSave.EnabledChanged, Sub(sender, e) refresh()
            AddHandler form.DataGridView1.RowsAdded, Sub(sender, e) refresh()
            AddHandler form.DataGridView1.RowsRemoved, Sub(sender, e) refresh()
            AddHandler form.DataGridView2.RowsAdded, Sub(sender, e) refresh()
            AddHandler form.DataGridView2.RowsRemoved, Sub(sender, e) refresh()
            refresh()
        End Sub

        Public Function Navigation(text As String, name As String) As Button
            Dim action As New Button With {.Text = text, .Name = name, .Dock = DockStyle.Fill, .Margin = New Padding(0), .TabStop = True}
            RetailUI.StyleTextButton(action)
            Return action
        End Function

        Private Function CustomerAndTotals(form As frmPOS) As TableLayoutPanel
            Dim card = RetailUI.Stack()
            card.Name = "RetailSaleContext"
            card.Dock = DockStyle.Fill
            card.AutoSize = False
            card.Padding = New Padding(RetailUI.Space * 2, RetailUI.Space, RetailUI.Space * 2, RetailUI.Space)
            Dim heading = RetailUI.Columns(2)
            heading.ColumnStyles(0).Width = 70
            heading.ColumnStyles(1).Width = 30
            heading.Controls.Add(RetailUI.Field(form.cmbCustomerName, "Customer · required"), 0, 0)
            Dim chooseHost As New Panel With {.Dock = DockStyle.Fill, .Padding = New Padding(RetailUI.Space, RetailUI.Inset, 0, 0), .Margin = New Padding(0)}
            form.btnCustomerSelection.Text = "Choose · F9"
            form.btnCustomerSelection.Dock = DockStyle.Fill
            form.btnCustomerSelection.Margin = New Padding(0)
            RetailUI.StyleTextButton(form.btnCustomerSelection)
            chooseHost.Controls.Add(form.btnCustomerSelection)
            heading.Controls.Add(chooseHost, 1, 0)
            RetailUI.AddRow(card, heading, RetailUI.FieldHeight)
            RetailUI.FieldRow(card, {"Phone · required"}, form.txtContactNo)
            RetailUI.FieldRow(card, {"State · required"}, form.cmbCustomerState)
            RetailUI.AddRow(card, RetailUI.Label("Sale total", "headline"), RetailUI.Space * 4)
            form.txtGrandTotal.Font = RetailUI.TypeFont("display")
            form.txtGrandTotal.BorderStyle = BorderStyle.None
            form.txtGrandTotal.TextAlign = HorizontalAlignment.Right
            AddHandler form.txtGrandTotal.TextChanged, Sub(sender, e) FitAmount(form.txtGrandTotal)
            AddHandler form.txtGrandTotal.SizeChanged, Sub(sender, e) FitAmount(form.txtGrandTotal)
            RetailUI.AddRow(card, form.txtGrandTotal, RetailUI.RowHeight)
            SummaryRow(card, "Subtotal", form.txtSubTotal)
            SummaryRow(card, "Tax", form.TextBox12)
            SummaryRow(card, "Discount", form.txtBillDiscount)
            SummaryRow(card, "Round off", form.txtRoundOff)
            SummaryRow(card, "Paid", form.txtTotalPayment)
            SummaryRow(card, "Balance due", form.txtPaymentDue)
            card.RowCount += 1
            card.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
            Return card
        End Function

        Private Sub BuildCart(form As frmPOS, pages As TabControl)
            Dim cart = RetailUI.Stack()
            cart.Name = "RetailCartWorkspace"
            cart.Dock = DockStyle.Fill
            cart.AutoSize = False
            cart.Padding = New Padding(RetailUI.Space * 2)
            pages.TabPages(0).Controls.Add(cart)
            Dim find = RetailUI.Columns(3)
            find.ColumnStyles(0).Width = 30
            find.ColumnStyles(1).Width = 45
            find.ColumnStyles(2).Width = 25
            find.Controls.Add(RetailUI.Field(form.txtBarcode, "Scan barcode"), 0, 0)
            find.Controls.Add(RetailUI.Field(form.TextBox20, "Find a product · Ctrl+P"), 1, 0)
            Dim browse As New Panel With {.Dock = DockStyle.Fill, .Padding = New Padding(RetailUI.Space, RetailUI.Inset, 0, 0), .Margin = New Padding(0)}
            form.btnProductSelection.Text = "Browse · F10"
            form.btnProductSelection.Dock = DockStyle.Fill
            RetailUI.StyleButton(form.btnProductSelection)
            browse.Controls.Add(form.btnProductSelection)
            find.Controls.Add(browse, 2, 0)
            RetailUI.AddRow(cart, find, RetailUI.FieldHeight)
            Dim entry = RetailUI.Columns(4)
            For index As Integer = 0 To 3
                entry.ColumnStyles(index).Width = If(index = 3, 31, 23)
            Next
            entry.Controls.Add(RetailUI.Field(form.txtQty, "Quantity"), 0, 0)
            entry.Controls.Add(RetailUI.Field(form.cmbUnit, "Unit"), 1, 0)
            entry.Controls.Add(RetailUI.Field(form.txtSalesRate, "Price"), 2, 0)
            Dim addHost As New Panel With {.Dock = DockStyle.Fill, .Padding = New Padding(RetailUI.Space, RetailUI.Inset, 0, 0), .Margin = New Padding(0)}
            form.btnAdd.Text = "Add item · F11"
            form.btnAdd.Dock = DockStyle.Fill
            RetailUI.StyleButton(form.btnAdd)
            addHost.Controls.Add(form.btnAdd)
            entry.Controls.Add(addHost, 3, 0)
            RetailUI.AddRow(cart, entry, RetailUI.FieldHeight)
            Dim header = RetailUI.Columns(2)
            Dim cartTitle = RetailUI.Label("Cart", "headline")
            header.Controls.Add(cartTitle, 0, 0)
            Dim details = Navigation("Item details", "RetailItemDetails")
            header.Controls.Add(details, 1, 0)
            RetailUI.AddRow(cart, header, RetailUI.TouchHeight + RetailUI.Space)
            RetailUI.NormalizeGridAppearance(form.DataGridView1)
            Dim columns = form.DataGridView1.Columns.Cast(Of DataGridViewColumn)().ToDictionary(Function(column) column, Function(column) column.Visible)
            ConfigureCart(form.DataGridView1)
            Dim expanded As Boolean = False
            AddHandler details.Click, Sub(sender, e)
                                          expanded = Not expanded
                                          If expanded Then
                                              For Each column As DataGridViewColumn In form.DataGridView1.Columns
                                                  column.Visible = columns(column)
                                              Next
                                          Else
                                              ConfigureCart(form.DataGridView1)
                                          End If
                                          details.Text = If(expanded, "Compact cart", "Item details")
                                      End Sub
            Dim gridRow = cart.RowCount
            cart.RowCount += 1
            cart.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
            Dim cartBody As New Panel With {.Name = "RetailCartBody", .Dock = DockStyle.Fill, .Margin = New Padding(0)}
            form.DataGridView1.Dock = DockStyle.Fill
            form.DataGridView1.Margin = New Padding(0)
            cartBody.Controls.Add(form.DataGridView1)
            cart.Controls.Add(cartBody, 0, gridRow)
            Dim empty = RetailUI.Columns(2)
            empty.Name = "RetailEmptyCart"
            empty.ColumnStyles(0).SizeType = SizeType.Absolute
            empty.ColumnStyles(0).Width = RetailUI.FieldHeight
            empty.Dock = DockStyle.None
            empty.Controls.Add(RetailAssets.Picture(RetailIllustration.EmptyBag, "RetailEmptyCartArtwork"), 0, 0)
            Dim copy = RetailUI.Stack()
            copy.Padding = New Padding(RetailUI.Space, 0, 0, 0)
            copy.Margin = New Padding(0)
            RetailUI.AddRow(copy, RetailUI.Label("Your cart is empty", "headline"), RetailUI.Space * 4)
            RetailUI.AddRow(copy, RetailUI.Label("Scan a barcode or find a product above.", "footnote"), RetailUI.SectionHeight)
            empty.Controls.Add(copy, 1, 0)
            cartBody.Controls.Add(empty)
            Dim refresh As Action = Sub()
                                       Dim populated = form.DataGridView1.Rows.Cast(Of DataGridViewRow)().Any(Function(row) Not row.IsNewRow)
                                       Dim itemCount = form.DataGridView1.Rows.Cast(Of DataGridViewRow)().Count(Function(row) Not row.IsNewRow)
                                       cartTitle.Text = If(populated, "Cart · " & itemCount.ToString() & " items", "Cart")
                                       form.DataGridView1.Visible = populated
                                       empty.Visible = Not populated
                                       empty.SetBounds(RetailUI.Space, Math.Max(0, (cartBody.Height - RetailUI.RowHeight * 2) \ 2), Math.Max(0, cartBody.Width - RetailUI.Space * 2), Math.Min(cartBody.Height, RetailUI.RowHeight * 2))
                                       empty.BringToFront()
                                   End Sub
            AddHandler form.DataGridView1.RowsAdded, Sub(sender, e) refresh()
            AddHandler form.DataGridView1.RowsRemoved, Sub(sender, e) refresh()
            AddHandler cartBody.SizeChanged, Sub(sender, e) refresh()
            Dim footer = RetailUI.Columns(2)
            Dim hint = RetailUI.Label("Review quantities and prices.", "footnote")
            hint.ForeColor = RetailUI.Tone("secondary")
            footer.Controls.Add(hint, 0, 0)
            form.btnRemove.Text = "Remove selected item"
            form.btnRemove.Dock = DockStyle.Fill
            form.btnRemove.Margin = New Padding(0)
            RetailUI.StyleButton(form.btnRemove, False, True)
            footer.Controls.Add(form.btnRemove, 1, 0)
            RetailUI.AddRow(cart, footer, RetailUI.TouchHeight + RetailUI.Space)
            refresh()
        End Sub

        Private Sub BuildPayment(form As frmPOS, pages As TabControl)
            Dim payment = RetailUI.Stack()
            payment.Name = "RetailPaymentWorkspace"
            payment.Dock = DockStyle.Fill
            payment.AutoSize = False
            payment.Padding = New Padding(RetailUI.Space * 2)
            pages.TabPages(1).Controls.Add(payment)
            RetailUI.AddRow(payment, RetailUI.Label("How is the customer paying?", "headline"), RetailUI.Space * 4)
            RetailUI.FieldRow(payment, {"Payment method", "Amount"}, form.cmbPaymentMode, form.txtPayment)
            RetailUI.FieldRow(payment, {"Payment date", "Bank account"}, form.dtpPaymentDate, form.cmbAccountNo)
            form.btnAdd1.Text = "Record payment · F12"
            form.btnRemove1.Text = "Remove selected payment"
            RetailUI.StyleButton(form.btnAdd1)
            RetailUI.StyleTextButton(form.btnRemove1)
            RetailUI.ActionRow(payment, form.btnAdd1, form.btnRemove1)
            Dim header = RetailUI.Columns(2)
            header.Controls.Add(RetailUI.Label("Recorded payments", "headline"), 0, 0)
            form.btnPhonePe.Text = "Collect by UPI · Alt+Y"
            form.btnPhonePe.Dock = DockStyle.Fill
            form.btnPhonePe.Margin = New Padding(0)
            RetailUI.StyleTextButton(form.btnPhonePe)
            header.Controls.Add(form.btnPhonePe, 1, 0)
            RetailUI.AddRow(payment, header, RetailUI.TouchHeight + RetailUI.Space)
            RetailUI.NormalizeGridAppearance(form.DataGridView2)
            form.DataGridView2.Dock = DockStyle.Fill
            form.DataGridView2.Margin = New Padding(0)
            form.DataGridView2.RowHeadersVisible = False
            For Each column As DataGridViewColumn In form.DataGridView2.Columns
                If column.Visible Then column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Next
            Dim row = payment.RowCount
            payment.RowCount += 1
            payment.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
            Dim payments As New Panel With {.Dock = DockStyle.Fill, .Margin = New Padding(0)}
            payments.Controls.Add(form.DataGridView2)
            Dim empty = RetailUI.Label("No payment recorded. Choose a method and amount, then record the payment.", "footnote")
            empty.Name = "RetailEmptyPayments"
            empty.Dock = DockStyle.None
            empty.TextAlign = ContentAlignment.MiddleCenter
            empty.ForeColor = RetailUI.Tone("secondary")
            payments.Controls.Add(empty)
            payment.Controls.Add(payments, 0, row)
            Dim refresh As Action = Sub()
                                       empty.Visible = Not HasItems(form.DataGridView2)
                                       empty.SetBounds(RetailUI.Space, form.DataGridView2.ColumnHeadersHeight, Math.Max(0, payments.Width - RetailUI.Space * 2), Math.Max(0, payments.Height - form.DataGridView2.ColumnHeadersHeight))
                                       empty.BringToFront()
                                       RetailUI.StyleButton(form.btnAdd1, Not HasItems(form.DataGridView2))
                                   End Sub
            AddHandler payments.SizeChanged, Sub(sender, e) refresh()
            AddHandler form.DataGridView2.RowsAdded, Sub(sender, e) refresh()
            AddHandler form.DataGridView2.RowsRemoved, Sub(sender, e) refresh()
            refresh()
        End Sub

        Private Sub ConfigureCart(grid As DataGridView)
            ' Only presentation changes: column indexes, values, and tax computation stay intact.
            Dim essentials As String() = {"Column3", "Column4", "Column5", "Column6"}
            For Each column As DataGridViewColumn In grid.Columns
                column.Visible = essentials.Contains(column.Name)
                column.HeaderCell.Style.WrapMode = DataGridViewTriState.False
                column.AutoSizeMode = If(column.Visible, DataGridViewAutoSizeColumnMode.Fill, DataGridViewAutoSizeColumnMode.None)
                column.MinimumWidth = RetailUI.Space * 8
                column.Width = RetailUI.FieldHeight + RetailUI.Inset
            Next
            grid.Columns("Column3").FillWeight = 50
            grid.Columns("Column4").FillWeight = 10
            grid.Columns("Column5").FillWeight = 20
            grid.Columns("Column6").FillWeight = 20
            grid.Columns("Column3").HeaderText = "Product"
            grid.Columns("Column4").HeaderText = "Qty"
            grid.Columns("Column5").HeaderText = "Price"
            grid.Columns("Column17").HeaderText = "Discount"
            grid.Columns("Column6").HeaderText = "Total"
            grid.RowHeadersVisible = False
        End Sub

        Private Sub FitAmount(amount As TextBox)
            If amount.ClientSize.Width = 0 Then Return
            Dim chosen = RetailUI.TypeFont("headline")
            For Each style In {"display", "title-1", "title-2", "headline"}
                Dim font = RetailUI.TypeFont(style)
                If TextRenderer.MeasureText(amount.Text, font).Width > amount.ClientSize.Width Then Continue For
                chosen = font
                Exit For
            Next
            ' Choose first, assign once: font changes also raise SizeChanged.
            If Not amount.Font.Equals(chosen) Then amount.Font = chosen
        End Sub

        Private Sub SummaryRow(stack As TableLayoutPanel, caption As String, amount As TextBox)
            Dim row = RetailUI.Columns(2)
            row.Controls.Add(RetailUI.Label(caption, "subhead"), 0, 0)
            amount.Font = RetailUI.TypeFont("subhead")
            amount.BorderStyle = BorderStyle.None
            amount.TextAlign = HorizontalAlignment.Right
            amount.AutoSize = False
            amount.Margin = New Padding(0)
            amount.Dock = DockStyle.Fill
            row.Controls.Add(amount, 1, 0)
            RetailUI.AddRow(stack, row, RetailUI.Space * 4)
        End Sub

        Private Function HasItems(grid As DataGridView) As Boolean
            Return grid.Rows.Cast(Of DataGridViewRow)().Any(Function(row) Not row.IsNewRow)
        End Function

        Public Function ConfirmNewSale(form As frmPOS) As Boolean
            If Not HasItems(form.DataGridView1) Then Return True
            Return MessageBox.Show(form, "Start a new sale and clear the current cart?", "New sale", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes
        End Function

        Private Sub BuildPopups(form As frmPOS, pages As TabControl)
            form.dgw4.Parent = pages.TabPages(0)
            form.dgwsale.Parent = pages.TabPages(0)
            RetailUI.NormalizeGridAppearance(form.dgwsale)
            Dim place As Action(Of Control, Control) = Sub(popup, anchor)
                                                          Dim page = pages.TabPages(0)
                                                          Dim origin = page.PointToClient(anchor.PointToScreen(New Point(0, anchor.Height)))
                                                          Dim height = Math.Min(RetailUI.TouchHeight + RetailUI.RowHeight * 3, page.ClientSize.Height - RetailUI.Space * 4)
                                                          popup.SetBounds(RetailUI.Space * 2, Math.Max(RetailUI.Space * 2, Math.Min(origin.Y + RetailUI.Space, page.Height - height - RetailUI.Space * 2)), Math.Max(RetailUI.TouchHeight, page.Width - RetailUI.Space * 4), height)
                                                          popup.BringToFront()
                                                      End Sub
            AddHandler form.dgw4.VisibleChanged, Sub(sender, e)
                                                   If Not RetailAdvancedLayouts.OwnVisible(form.dgw4) Then Return
                                                   pages.SelectedIndex = 0
                                                   place(form.dgw4, form.TextBox20)
                                               End Sub
            AddHandler form.dgwsale.VisibleChanged, Sub(sender, e)
                                                       If Not RetailAdvancedLayouts.OwnVisible(form.dgwsale) Then Return
                                                       pages.SelectedIndex = 0
                                                       place(form.dgwsale, form.txtSalesRate)
                                                   End Sub
            AddHandler pages.TabPages(0).SizeChanged, Sub(sender, e)
                                                       If form.dgw4.Visible Then place(form.dgw4, form.TextBox20)
                                                       If form.dgwsale.Visible Then place(form.dgwsale, form.txtSalesRate)
                                                   End Sub
            RetailAdvancedLayouts.BuildPaymentOverlay(form)
            form.PanelUPI.Parent = pages.TabPages(1)
            Dim placeUPI As Action = Sub()
                                        Dim page = pages.TabPages(1)
                                        form.PanelUPI.SetBounds(RetailUI.Space, RetailUI.Space, Math.Max(RetailUI.TouchHeight, page.Width - RetailUI.Space * 2), Math.Max(RetailUI.TouchHeight, page.Height - RetailUI.Space * 2))
                                        form.PanelUPI.BringToFront()
                                    End Sub
            AddHandler form.PanelUPI.VisibleChanged, Sub(sender, e)
                                                       If Not RetailAdvancedLayouts.OwnVisible(form.PanelUPI) Then Return
                                                       pages.SelectedIndex = 1
                                                       placeUPI()
                                                   End Sub
            AddHandler pages.TabPages(1).SizeChanged, Sub(sender, e)
                                                       If form.PanelUPI.Visible Then placeUPI()
                                                   End Sub
        End Sub

        Public Function HandleShortcut(form As frmPOS, e As KeyEventArgs) As Boolean
            Dim session As CheckoutSession = Nothing
            If Not Sessions.TryGetValue(form, session) Then Return False
            If e.KeyCode = Keys.F2 AndAlso session.Pages.SelectedIndex <> 1 Then
                If HasItems(form.DataGridView1) Then session.Pages.SelectedIndex = 1
                e.Handled = True
                e.SuppressKeyPress = True
                Return True
            End If
            If e.KeyCode = Keys.F2 AndAlso (Not HasItems(form.DataGridView1) OrElse Not HasItems(form.DataGridView2)) Then
                e.Handled = True
                e.SuppressKeyPress = True
                Return True
            End If
            Select Case e.KeyCode
                Case Keys.F1
                    session.Pages.SelectedIndex = 0
                Case Keys.F9, Keys.F10, Keys.F11
                    session.Pages.SelectedIndex = 0
                Case Keys.F12
                    session.Pages.SelectedIndex = 1
                Case Keys.F3, Keys.F4, Keys.F5, Keys.F6, Keys.F7, Keys.F8
                    session.Pages.SelectedIndex = 2
                    session.Groups.SelectedIndex = 0
            End Select
            If e.Control AndAlso (e.KeyCode = Keys.P OrElse e.KeyCode = Keys.C) Then session.Pages.SelectedIndex = 0
            If e.Alt AndAlso e.KeyCode = Keys.Y Then session.Pages.SelectedIndex = 1
            Return False
        End Function
    End Module

    ' TCM_ADJUSTRECT is the native TabControl message for its content rectangle.
    ' Navigation uses labelled buttons, while native pages retain control identity and tab order.
    Public Class RetailPageHost
        Inherits TabControl
        Private Const AdjustRectangleMessage As Integer = &H1328

        Public Sub New()
            Appearance = TabAppearance.FlatButtons
            SizeMode = TabSizeMode.Fixed
            ItemSize = New Size(1, 1)
            TabStop = False
            Margin = New Padding(0)
        End Sub

        Public Overrides ReadOnly Property DisplayRectangle As Rectangle
            Get
                Return ClientRectangle
            End Get
        End Property

        Protected Overrides Sub WndProc(ByRef message As Message)
            If message.Msg = AdjustRectangleMessage Then
                message.Result = New IntPtr(1)
                Return
            End If
            MyBase.WndProc(message)
        End Sub
    End Class
End Namespace
