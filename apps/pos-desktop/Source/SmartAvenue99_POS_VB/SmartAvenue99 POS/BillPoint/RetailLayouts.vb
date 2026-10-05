Option Infer On
Option Explicit On
Option Strict On
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Linq

Namespace BillPoint
    Public Module RetailLayouts
        Private ReadOnly Rebuilt As New Runtime.CompilerServices.ConditionalWeakTable(Of System.Windows.Forms.Form, Object)()
        Private Installed As Boolean

        Public Sub Install()
            If Installed Then Return
            Installed = True
            AddHandler Application.Idle, Sub(sender, e)
                                             For Each form As System.Windows.Forms.Form In Application.OpenForms
                                                 If form.GetType().Namespace = "BillPoint" Then Apply(form)
                                             Next
                                         End Sub
        End Sub

        Public Sub Apply(form As System.Windows.Forms.Form)
            Dim marker As Object = Nothing
            If Rebuilt.TryGetValue(form, marker) Then Return
            form.SuspendLayout()
            RetailUI.StyleTree(form)
            Select Case form.GetType().Name
                Case "frmLogin" : BuildLogin(DirectCast(form, frmLogin))
                Case "frmPOS" : BuildSale(DirectCast(form, frmPOS))
                Case "frmMainMenu" : BuildHome(DirectCast(form, frmMainMenu))
                Case "frmSplash" : BuildSplash(DirectCast(form, frmSplash))
                Case "frmSqlServerSetting" : BuildConnection(DirectCast(form, frmSqlServerSetting))
                Case Else : RetailWorkspaceLayouts.Build(form)
            End Select
            Rebuilt.Add(form, New Object())
            form.ResumeLayout(True)
        End Sub


        Private Function Button(text As String, Optional primary As Boolean = False) As Button
            Dim action As New Button With {.Text = text, .Dock = DockStyle.Fill, .MinimumSize = New Size(RetailUI.TouchHeight, RetailUI.TouchHeight), .Margin = New Padding(RetailUI.Space)}
            RetailUI.StyleButton(action, primary)
            Return action
        End Function



        Private Function ScrollContent(form As System.Windows.Forms.Form, name As String) As Panel
            Dim scroll As New Panel With {.Name = name, .Dock = DockStyle.Fill, .AutoScroll = True, .BackColor = RetailUI.Tone("canvas"), .Padding = New Padding(RetailUI.Inset)}
            RetailUI.StyleSurface(scroll, "canvas")
            form.Controls.Add(scroll)
            scroll.BringToFront()
            Return scroll
        End Function

        Private Function BrandHeading(title As String, subtitle As String) As Control
            Dim header = RetailUI.Columns(2)
            header.ColumnStyles(0).SizeType = SizeType.Absolute
            header.ColumnStyles(0).Width = RetailUI.FieldHeight
            header.ColumnStyles(1).Width = 100
            header.Controls.Add(RetailAssets.Picture(RetailIllustration.Storefront, "RetailBrandArtwork"), 0, 0)
            Dim copy = RetailUI.Stack()
            copy.Padding = New Padding(RetailUI.Space, 0, 0, 0)
            copy.Margin = New Padding(0)
            RetailUI.AddRow(copy, RetailUI.Label(title, "title-1"), RetailUI.RowHeight)
            RetailUI.AddRow(copy, RetailUI.Label(subtitle, "subhead"), RetailUI.SectionHeight)
            header.Controls.Add(copy, 1, 0)
            Return header
        End Function

        Private Sub BuildLogin(form As frmLogin)
            form.Panel1.Visible = False
            form.Text = "Sign in · Smart Retail OS"
            form.FormBorderStyle = FormBorderStyle.Sizable
            form.MaximizeBox = False
            form.ClientSize = New Size(RetailUI.LoginWidth, RetailUI.LoginHeight)
            form.MinimumSize = New Size(RetailUI.LoginWidth, RetailUI.LoginHeight)
            Dim scroll = ScrollContent(form, "RetailSignIn")
            Dim stack = RetailUI.Stack()
            scroll.Controls.Add(stack)
            RetailUI.AddRow(stack, BrandHeading("Smart Retail OS", "Sign in to your store"), RetailUI.RowHeight + RetailUI.SectionHeight)
            RetailUI.FieldRow(stack, {"Store"}, form.cmbCompany)
            RetailUI.FieldRow(stack, {"Username"}, form.UserID)
            Dim passwordRow = RetailUI.Columns(2)
            passwordRow.ColumnStyles(0).Width = 75
            passwordRow.ColumnStyles(1).Width = 25
            passwordRow.Controls.Add(RetailUI.Field(form.Password, "Password"), 0, 0)
            Dim visibility As New Panel With {.Dock = DockStyle.Fill, .Margin = New Padding(0), .Padding = New Padding(RetailUI.Space, RetailUI.Inset, 0, 0), .BackColor = RetailUI.Tone("surface")}
            visibility.Controls.Add(form.Button4)
            visibility.Controls.Add(form.Button5)
            form.Button4.Dock = DockStyle.Fill
            form.Button5.Dock = DockStyle.Fill
            form.Button4.Text = "Hide"
            form.Button5.Text = "Show"
            form.Button4.TabStop = True
            form.Button5.TabStop = True
            form.Button4.TabIndex = 0
            form.Button5.TabIndex = 0
            RetailUI.StyleButton(form.Button4)
            RetailUI.StyleButton(form.Button5)
            passwordRow.Controls.Add(visibility, 1, 0)
            RetailUI.AddRow(stack, passwordRow, RetailUI.FieldHeight)
            form.Password.PasswordChar = ChrW(&H25CF)
            If form.UserID.Text = "Enter the User Name" Then form.UserID.Clear()
            If form.Password.Text = "Enter the Password" Then form.Password.Clear()
            form.OK.Text = "Sign in"
            form.Cancel.Text = "Exit"
            RetailUI.StyleButton(form.OK, True)
            RetailUI.StyleButton(form.Cancel)
            RetailUI.ActionRow(stack, form.OK)
            Dim attempts = form.lblAttempt
            If attempts.Text.Trim("."c).Length = 0 Then attempts.Text = "Enter your store username and password."
            attempts.AutoSize = False
            attempts.Font = RetailUI.TypeFont("footnote")
            attempts.ForeColor = RetailUI.Tone("secondary")
            RetailUI.AddRow(stack, attempts, RetailUI.SectionHeight)
            form.btnRecoveryPassword.Text = "Recover password"
            form.btnChangePassword.Text = "Change password"
            form.btnCompany.Text = "Manage stores"
            form.btnKeyboard.Text = "Open keyboard"
            For Each action In {form.btnRecoveryPassword, form.btnChangePassword, form.btnCompany, form.btnKeyboard}
                RetailUI.StyleButton(action)
            Next
            RetailUI.StyleTextButton(form.btnRecoveryPassword)
            RetailUI.ActionRow(stack, form.btnRecoveryPassword)
            Dim options = RetailCheckoutLayouts.Navigation("Store options", "RetailToggleStoreOptions")
            RetailUI.ActionRow(stack, options)
            Dim settings = RetailUI.Stack()
            settings.Name = "RetailStoreOptions"
            settings.Padding = New Padding(0)
            settings.Margin = New Padding(0)
            RetailUI.ActionRow(settings, form.btnChangePassword, form.btnCompany)
            RetailUI.ActionRow(settings, form.btnKeyboard, form.Cancel)
            RetailUI.FieldRow(settings, {"Language"}, form.cmbLang)
            Dim settingsRow = stack.RowCount
            RetailUI.AddRow(stack, settings, 0)
            settings.Visible = False
            AddHandler options.Click, Sub(sender, e)
                                          settings.Visible = Not settings.Visible
                                          stack.RowStyles(settingsRow).Height = If(settings.Visible, RetailUI.FieldHeight + (RetailUI.TouchHeight + RetailUI.Space) * 2, 0)
                                          options.Text = If(settings.Visible, "Hide store options", "Store options")
                                          options.AccessibleName = options.Text
                                      End Sub
            form.AcceptButton = form.OK
            form.CancelButton = form.Cancel
            form.cmbCompany.TabIndex = 0
            form.UserID.TabIndex = 1
            form.Password.TabIndex = 2
        End Sub

        Private Function WorkspaceTabs(form As System.Windows.Forms.Form, originals As Control(), title As String) As TabControl
            Dim tabs As New RetailPageHost With {.Name = "RetailWorkspace", .Dock = DockStyle.Fill, .Font = RetailUI.TypeFont("subhead")}
            Dim main As New TabPage(title) With {.BackColor = RetailUI.Tone("canvas"), .Padding = New Padding(RetailUI.Space)}
            Dim details As New TabPage("Store tools") With {.BackColor = RetailUI.Tone("canvas"), .AutoScroll = True}
            RetailUI.StyleSurface(main, "canvas")
            RetailUI.StyleSurface(details, "canvas")
            tabs.TabPages.Add(main)
            tabs.TabPages.Add(details)
            For Each original In originals
                details.Controls.Add(original)
                original.Anchor = AnchorStyles.Top Or AnchorStyles.Left
            Next
            form.Controls.Add(tabs)
            tabs.BringToFront()
            Return tabs
        End Function

        Private Sub FitDesktop(form As System.Windows.Forms.Form)
            form.MinimumSize = New Size(RetailUI.MinimumWidth, RetailUI.MinimumHeight)
            If form.WindowState = FormWindowState.Maximized Then Return
            Dim workArea = Screen.FromControl(form).WorkingArea
            form.ClientSize = New Size(Math.Min(RetailUI.DesktopWidth, workArea.Width - RetailUI.Inset * 2), Math.Min(RetailUI.DesktopHeight, workArea.Height - SystemInformation.CaptionHeight - RetailUI.Inset * 2))
        End Sub

        Private Sub BuildSale(form As frmPOS)
            form.Text = "New sale · Smart Retail OS"
            FitDesktop(form)
            RetailCheckoutLayouts.Build(form)
        End Sub







        Private Sub BuildHome(form As frmMainMenu)
            form.Text = "Smart Retail OS"
            FitDesktop(form)
            Dim tabs = WorkspaceTabs(form, {form.Panel6, form.flpItemsCategory, form.flpItems_BV}, "Home")
            Dim shell As New TableLayoutPanel With {.Name = "RetailHomeShell", .Dock = DockStyle.Fill, .ColumnCount = 1, .RowCount = 3, .BackColor = RetailUI.Tone("canvas"), .Margin = New Padding(0)}
            RetailUI.StyleSurface(shell, "canvas")
            shell.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
            shell.RowStyles.Add(New RowStyle(SizeType.Absolute, RetailUI.TouchHeight))
            shell.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
            shell.RowStyles.Add(New RowStyle(SizeType.Absolute, RetailUI.Space * 4))
            form.MenuStrip2.Dock = DockStyle.Fill
            form.MenuStrip2.Visible = True
            For Each item As ToolStripItem In form.MenuStrip2.Items
                item.DisplayStyle = ToolStripItemDisplayStyle.Text
            Next
            Dim header = RetailUI.Columns(3)
            header.ColumnStyles(0).Width = 50
            header.ColumnStyles(1).Width = 25
            header.ColumnStyles(2).Width = 25
            Dim brand = RetailUI.Label("Smart Retail OS", "headline")
            brand.Padding = New Padding(RetailUI.Inset, 0, 0, 0)
            Dim home = RetailCheckoutLayouts.Navigation("Back to Home", "RetailBackHome")
            Dim browse = RetailCheckoutLayouts.Navigation("Browse all commands", "RetailAllCommands")
            header.Controls.Add(brand, 0, 0)
            header.Controls.Add(home, 1, 0)
            header.Controls.Add(browse, 2, 0)
            shell.Controls.Add(header, 0, 0)
            AddHandler home.Click, Sub(sender, e) tabs.SelectedIndex = 0
            AddHandler browse.Click, Sub(sender, e) tabs.SelectedIndex = 1
            home.Visible = False
            AddHandler tabs.SelectedIndexChanged, Sub(sender, e) home.Visible = tabs.SelectedIndex <> 0
            Dim toolsShell As New TableLayoutPanel With {.Dock = DockStyle.Fill, .ColumnCount = 1, .RowCount = 3, .Margin = New Padding(0)}
            toolsShell.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
            toolsShell.RowStyles.Add(New RowStyle(SizeType.Absolute, RetailUI.TouchHeight))
            toolsShell.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
            toolsShell.RowStyles.Add(New RowStyle(SizeType.Absolute, RetailUI.Space * 4))
            Dim legacy As New Panel With {.Dock = DockStyle.Fill, .AutoScroll = True}
            For Each original As Control In {form.Panel6, form.flpItemsCategory, form.flpItems_BV}
                legacy.Controls.Add(original)
            Next
            toolsShell.Controls.Add(form.MenuStrip2, 0, 0)
            Dim commandPages As New TabControl With {.Name = "RetailCommandPages", .Dock = DockStyle.Fill, .Font = RetailUI.TypeFont("subhead"), .ItemSize = New Size(RetailUI.Inset * 8, RetailUI.TouchHeight), .SizeMode = TabSizeMode.Fixed}
            Dim commandPage As New TabPage("Command browser")
            commandPage.Controls.Add(RetailCommandBrowser.Create(form.MenuStrip2))
            Dim legacyPage As New TabPage("Store workspace")
            legacyPage.Controls.Add(legacy)
            commandPages.TabPages.Add(commandPage)
            commandPages.TabPages.Add(legacyPage)
            toolsShell.Controls.Add(commandPages, 0, 1)
            tabs.TabPages(1).Controls.Add(toolsShell)
            shell.Controls.Add(tabs, 0, 1)
            form.StatusStrip1.Dock = DockStyle.Fill
            toolsShell.Controls.Add(form.StatusStrip1, 0, 2)
            Dim status = RetailUI.Label("Store workspace", "footnote")
            status.Name = "RetailAccountStatus"
            status.Padding = New Padding(RetailUI.Inset, 0, RetailUI.Inset, 0)
            RetailUI.StyleSurface(status, "canvas")
            status.ForeColor = RetailUI.Tone("secondary")
            shell.Controls.Add(status, 0, 2)
            Dim refreshStatus As Action = Sub()
                                             Dim user = form.lblUser.Text.Trim()
                                             status.Text = If(user.Length = 0 OrElse user = "User Name", "Store workspace", "Signed in as " & user & " · " & form.lblUserType.Text.Trim())
                                         End Sub
            AddHandler form.lblUser.TextChanged, Sub(sender, e) refreshStatus()
            AddHandler form.lblUserType.TextChanged, Sub(sender, e) refreshStatus()
            refreshStatus()
            form.Controls.Add(shell)
            shell.BringToFront()
            Dim scroll As New Panel With {.Dock = DockStyle.Fill, .AutoScroll = True, .Padding = New Padding(RetailUI.Inset), .BackColor = RetailUI.Tone("canvas")}
            RetailUI.StyleSurface(scroll, "canvas")
            tabs.TabPages(0).Controls.Add(scroll)
            Dim stack = RetailUI.Stack()
            scroll.Controls.Add(stack)
            Dim hero = RetailUI.Columns(2)
            hero.ColumnStyles(0).Width = 100
            hero.ColumnStyles(1).SizeType = SizeType.Absolute
            hero.ColumnStyles(1).Width = RetailUI.FieldHeight * 3
            Dim welcome = RetailUI.Stack()
            welcome.Padding = New Padding(0)
            welcome.Margin = New Padding(0)
            RetailUI.AddRow(welcome, RetailUI.Label("Ready for your next sale.", "title-1"), RetailUI.RowHeight)
            RetailUI.AddRow(welcome, RetailUI.Label("Your everyday store tasks, in one place.", "subhead"), RetailUI.Space * 4)
            Dim start = MenuAction(form.PointOfSaleToolStripMenuItem, "Start a sale", True)
            RetailUI.ActionRow(welcome, start)
            start.Dock = DockStyle.Left
            start.Width = RetailUI.LoginWidth \ 2
            hero.Controls.Add(welcome, 0, 0)
            hero.Controls.Add(RetailAssets.Picture(RetailIllustration.Storefront, "RetailWelcomeArtwork"), 1, 0)
            RetailUI.AddRow(stack, hero, RetailUI.FieldHeight * 2)
            Dim access = RetailUI.Label(If(start.Enabled, "", "Starting a sale is unavailable. Ask your store administrator to check access."), "footnote")
            Dim accessRow = stack.RowCount
            RetailUI.AddRow(stack, access, RetailUI.SectionHeight)
            Dim refreshAccess As Action = Sub()
                                              access.Visible = Not start.Enabled
                                              stack.RowStyles(accessRow).Height = If(start.Enabled, 0, RetailUI.SectionHeight)
                                              access.Text = If(start.Enabled, "", "Starting a sale is unavailable. Ask your store administrator to check access.")
                                          End Sub
            AddHandler start.EnabledChanged, Sub(sender, e) refreshAccess()
            refreshAccess()
            Dim taskHeader = RetailUI.Columns(2)
            taskHeader.ColumnStyles(0).Width = 70
            taskHeader.ColumnStyles(1).Width = 30
            Dim heading = RetailUI.Label("Everyday tasks", "headline")
            taskHeader.Controls.Add(heading, 0, 0)
            Dim appearance = Button(If(RetailUI.IsDark, "Use light appearance", "Use dark appearance"))
            RetailUI.StyleTextButton(appearance)
            appearance.Name = "RetailAppearance"
            appearance.Margin = New Padding(0)
            taskHeader.Controls.Add(appearance, 1, 0)
            RetailUI.AddRow(stack, taskHeader, RetailUI.TouchHeight + RetailUI.Space)
            Dim search As New TextBox With {.Name = "RetailTaskSearch"}
            RetailUI.FieldRow(stack, {"Search products, invoices, stock, reports, or settings"}, search)
            Dim results As New FlowLayoutPanel With {.Name = "RetailTaskResults", .Dock = DockStyle.Fill, .AutoScroll = True, .BackColor = RetailUI.Tone("surface"), .WrapContents = True}
            Dim resultsRow = stack.RowCount
            RetailUI.AddRow(stack, results, RetailUI.FieldHeight * 2)
            Dim commands As New List(Of ToolStripMenuItem)()
            For Each item As ToolStripItem In form.MenuStrip2.Items
                CollectCommands(TryCast(item, ToolStripMenuItem), commands)
            Next
            Dim preferred = {form.ProductsToolStripMenuItem1, form.CustomerToolStripMenuItem1, form.SalesToolStripMenuItem2, form.StockStatusToolStripMenuItem, form.PurchaseEntryToolStripMenuItem, form.ToolStripMenuItem19}
            Dim resultStatus = RetailUI.Label("", "footnote")
            Dim statusRow = stack.RowCount
            RetailUI.AddRow(stack, resultStatus, RetailUI.SectionHeight)
            Dim fitTasks As Action = Sub()
                                         Dim columns = If(results.ClientSize.Width >= RetailUI.Inset * 24, 3, If(results.ClientSize.Width >= RetailUI.Inset * 16, 2, 1))
                                         For Each action As Control In results.Controls
                                             action.Width = Math.Max(RetailUI.TouchHeight, (results.ClientSize.Width - RetailUI.Space * 2 * columns - SystemInformation.VerticalScrollBarWidth) \ columns)
                                         Next
                                         Dim rows = (results.Controls.Count + columns - 1) \ columns
                                         Dim height = If(rows = 0, 0, rows * (RetailUI.FieldHeight + RetailUI.Space * 2) + RetailUI.Space)
                                         height = Math.Min(height, RetailUI.FieldHeight * 3 + RetailUI.Space * 4)
                                         If stack.RowStyles(resultsRow).Height <> height Then stack.RowStyles(resultsRow).Height = height
                                     End Sub
            Dim refresh As Action = Sub()
                                        For Each previous As Control In results.Controls.Cast(Of Control)().ToArray()
                                            previous.Dispose()
                                        Next
                                        results.Controls.Clear()
                                        Dim query = search.Text.Trim()
                                        Dim matches = If(query.Length = 0, preferred.Where(Function(item) IsAvailable(item)).ToArray(), commands.Where(Function(item) IsAvailable(item) AndAlso MatchesTask(item, query)).ToArray())
                                        For Each command As ToolStripMenuItem In matches
                                            Dim action = MenuAction(command, TaskCaption(command))
                                            action.Name = "RetailTask_" & command.Name
                                            RetailUI.StyleButton(action, False, False, CommandPath(command))
                                            action.Dock = DockStyle.None
                                            action.Size = New Size(RetailUI.Inset * 8, RetailUI.FieldHeight)
                                            results.Controls.Add(action)
                                        Next
                                        heading.Text = If(query.Length = 0, "Everyday tasks", "Matching tasks")
                                        resultStatus.Text = If(matches.Length = 0, If(query.Length = 0, "No everyday tasks are available. Browse all commands or ask your store administrator to check access.", "No matching task. Try a different name or browse all commands."), matches.Length.ToString() & " matching tasks shown. Browse all commands for more.")
                                        resultStatus.Visible = query.Length > 0 OrElse matches.Length = 0
                                        stack.RowStyles(statusRow).Height = If(resultStatus.Visible, RetailUI.SectionHeight, 0)
                                        fitTasks()
                                    End Sub
            AddHandler search.TextChanged, Sub(sender, e) refresh()
            AddHandler tabs.SelectedIndexChanged, Sub(sender, e) refresh()
            AddHandler results.SizeChanged, Sub(sender, e) fitTasks()
            refresh()
            AddHandler appearance.Click, Sub(sender, e)
                                             RetailUI.IsDark = Not RetailUI.IsDark
                                             For Each opened As System.Windows.Forms.Form In Application.OpenForms
                                                 RetailUI.StyleTree(opened)
                                             Next
                                             RetailUI.StyleButton(start, True)
                                             appearance.Text = If(RetailUI.IsDark, "Use light appearance", "Use dark appearance")
                                         End Sub
        End Sub

        Private Function TaskCaption(command As ToolStripMenuItem) As String
            Select Case command.Name
                Case "ProductsToolStripMenuItem1" : Return "Manage products"
                Case "CustomerToolStripMenuItem1" : Return "Manage customers"
                Case "SalesToolStripMenuItem2" : Return "Find invoices"
                Case "StockStatusToolStripMenuItem" : Return "Review stock"
                Case "PurchaseEntryToolStripMenuItem" : Return "Record a purchase"
                Case "ToolStripMenuItem19" : Return "View sales dashboard"
                Case Else : Return command.Text.Trim()
            End Select
        End Function

        Private Function CommandPath(command As ToolStripItem) As String
            Dim parts As New List(Of String) From {command.Text.Trim()}
            Dim ancestor = command.OwnerItem
            While ancestor IsNot Nothing
                parts.Insert(0, ancestor.Text.Trim())
                ancestor = ancestor.OwnerItem
            End While
            Return String.Join(" · ", parts)
        End Function

        Private Function MatchesTask(command As ToolStripMenuItem, query As String) As Boolean
            Return (TaskCaption(command) & " " & CommandPath(command)).IndexOf(query, StringComparison.CurrentCultureIgnoreCase) >= 0
        End Function

        Private Sub CollectCommands(menu As ToolStripMenuItem, commands As List(Of ToolStripMenuItem))
            If menu Is Nothing Then Return
            If menu.DropDownItems.Count = 0 Then
                commands.Add(menu)
                Return
            End If
            For Each item As ToolStripItem In menu.DropDownItems
                CollectCommands(TryCast(item, ToolStripMenuItem), commands)
            Next
        End Sub

        Private Function IsAvailable(item As ToolStripItem) As Boolean
            If Not item.Available OrElse Not item.Enabled Then Return False
            If item.OwnerItem IsNot Nothing Then Return IsAvailable(item.OwnerItem)
            Return True
        End Function

        Private Function MenuAction(command As ToolStripMenuItem, text As String, Optional primary As Boolean = False) As Button
            Dim action = Button(text, primary)
            action.Enabled = IsAvailable(command)
            AddHandler action.Click, Sub(sender, e)
                                         If IsAvailable(command) Then command.PerformClick()
                                     End Sub
            Dim sync As EventHandler = Sub(sender, e) action.Enabled = IsAvailable(command)
            Dim ancestry As New List(Of ToolStripItem)()
            Dim ancestor As ToolStripItem = command
            While ancestor IsNot Nothing
                ancestry.Add(ancestor)
                AddHandler ancestor.EnabledChanged, sync
                AddHandler ancestor.AvailableChanged, sync
                ancestor = ancestor.OwnerItem
            End While
            AddHandler action.Disposed, Sub(sender, e)
                                            For Each item In ancestry
                                                RemoveHandler item.EnabledChanged, sync
                                                RemoveHandler item.AvailableChanged, sync
                                            Next
                                        End Sub
            Return action
        End Function

        Private Sub BuildSplash(form As frmSplash)
            form.Text = "Starting Smart Retail OS"
            For Each original As Control In form.Controls
                original.Visible = False
            Next
            form.ClientSize = New Size(RetailUI.LoginWidth, RetailUI.FieldHeight * 4)
            Dim scroll = ScrollContent(form, "RetailStartup")
            Dim stack = RetailUI.Stack()
            scroll.Controls.Add(stack)
            RetailUI.AddRow(stack, BrandHeading("Smart Retail OS", "By NextGen OS"), RetailUI.RowHeight + RetailUI.SectionHeight)
            form.Label1.Font = RetailUI.TypeFont("subhead")
            form.Label1.AutoSize = False
            form.Label1.TextAlign = ContentAlignment.MiddleLeft
            Dim storeRow = stack.RowCount
            RetailUI.AddRow(stack, form.Label1, RetailUI.RowHeight)
            Dim refreshStore As Action = Sub()
                                             form.Label1.Visible = form.Label1.Text.Length > 0 AndAlso form.Label1.Text <> "Smart Retail OS"
                                             stack.RowStyles(storeRow).Height = If(form.Label1.Visible, RetailUI.RowHeight, 0)
                                         End Sub
            AddHandler form.Label1.TextChanged, Sub(sender, e) refreshStore()
            refreshStore()
            form.lblSet2.Visible = True
            form.lblSet2.AutoSize = False
            form.lblSet2.Font = RetailUI.TypeFont("footnote")
            form.lblSet2.TextAlign = ContentAlignment.MiddleLeft
            If form.lblSet2.Text.Trim("."c).Length = 0 Then form.lblSet2.Text = "Preparing your store…"
            RetailUI.AddRow(stack, form.lblSet2, RetailUI.SectionHeight)
            form.LabelVersion.Visible = True
            form.LabelVersion.AutoSize = False
            form.LabelVersion.MaximumSize = Size.Empty
            form.LabelVersion.Font = RetailUI.TypeFont("footnote")
            RetailUI.AddRow(stack, form.LabelVersion, RetailUI.SectionHeight)
            form.ProgressBar2.Height = RetailUI.Space
            form.ProgressBar2.Visible = True
        End Sub

        Private Sub BuildConnection(form As frmSqlServerSetting)
            form.Panel1.Visible = False
            form.Text = "Connect your store · Smart Retail OS"
            form.ClientSize = New Size(RetailUI.LoginWidth, RetailUI.LoginHeight)
            form.MinimumSize = New Size(RetailUI.LoginWidth, RetailUI.LoginHeight)
            form.FormBorderStyle = FormBorderStyle.Sizable
            Dim scroll = ScrollContent(form, "RetailConnection")
            Dim stack = RetailUI.Stack()
            scroll.Controls.Add(stack)
            RetailUI.AddRow(stack, BrandHeading("Connect your store", "Smart Retail OS"), RetailUI.RowHeight + RetailUI.SectionHeight)
            RetailUI.AddRow(stack, RetailUI.Label("Enter the database details provided by your administrator.", "subhead"), RetailUI.FieldHeight)
            RetailUI.FieldRow(stack, {"SQL Server"}, form.cmbServerName)
            RetailUI.FieldRow(stack, {"Database username"}, form.txtUserName)
            RetailUI.FieldRow(stack, {"Database password"}, form.txtPassword)
            form.btnTestConnection.Text = "Test connection"
            form.btnCreateDemoDataDB.Text = "Save connection"
            form.Button1.Text = "Reset fields"
            form.btnClose.Text = "Close"
            RetailUI.StyleButton(form.btnTestConnection)
            RetailUI.StyleButton(form.btnCreateDemoDataDB, True)
            RetailUI.StyleButton(form.Button1)
            RetailUI.StyleButton(form.btnClose)
            RetailUI.ActionRow(stack, form.btnTestConnection)
            RetailUI.ActionRow(stack, form.btnCreateDemoDataDB)
            RetailUI.ActionRow(stack, form.Button1, form.btnClose)
            form.LinkLabel1.Text = "Find SQL Servers on this computer"
            form.LinkLabel1.LinkColor = RetailUI.Tone("accent-text")
            form.LinkLabel1.AutoSize = False
            form.LinkLabel1.Font = RetailUI.TypeFont("subhead")
            RetailUI.AddRow(stack, form.LinkLabel1, RetailUI.TouchHeight + RetailUI.Space)
        End Sub
    End Module
End Namespace
