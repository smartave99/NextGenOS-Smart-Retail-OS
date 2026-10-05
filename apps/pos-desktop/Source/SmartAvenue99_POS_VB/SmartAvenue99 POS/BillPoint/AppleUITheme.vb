Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace BillPoint
	''' <summary>
	''' NextGen OS - Apple HIG Design System & UI Modernizer
	''' Provides Apple-inspired color palettes, typography scales,
	''' and modern card/grid/button control polishers for Smart Retail OS.
	''' </summary>
	Public Module AppleUITheme

		' --- 1. Apple Color Palette ---
		Public ReadOnly CanvasBg As Color = Color.FromArgb(245, 245, 247)         ' #F5F5F7 (macOS System Canvas)
		Public ReadOnly CardBg As Color = Color.FromArgb(255, 255, 255)           ' #FFFFFF (Pure White Card Surface)
		Public ReadOnly CardBorder As Color = Color.FromArgb(229, 231, 235)       ' #E5E7EB (Subtle 1px divider)
		Public ReadOnly PrimaryBlue As Color = Color.FromArgb(0, 113, 227)        ' #0071E3 (Apple Signature Blue)
		Public ReadOnly PayGreen As Color = Color.FromArgb(52, 199, 89)           ' #34C759 (Apple Pay Green)
		Public ReadOnly DangerRed As Color = Color.FromArgb(255, 59, 48)          ' #FF3B30 (Apple System Red)
		Public ReadOnly WarningOrange As Color = Color.FromArgb(255, 149, 0)      ' #FF9500 (Apple Warning Orange)
		Public ReadOnly TextPrimary As Color = Color.FromArgb(29, 29, 31)         ' #1D1D1F (Apple Deep Charcoal)
		Public ReadOnly TextSecondary As Color = Color.FromArgb(99, 99, 105)    ' #86868B (Apple Muted Grey)
		Public ReadOnly GhostButtonBg As Color = Color.FromArgb(242, 242, 247)    ' #F2F2F7 (Apple Secondary Button)
		Public ReadOnly GhostButtonHover As Color = Color.FromArgb(229, 229, 234) ' #E5E5EA (Hover)
		Public ReadOnly TableHeaderBg As Color = Color.FromArgb(245, 245, 247)    ' #F5F5F7 (Header Background)
		Public ReadOnly TableAltRowBg As Color = Color.FromArgb(250, 250, 252)    ' #FAFAFC (Zebra Alternate Row)
		Public ReadOnly TableSelectionBg As Color = Color.FromArgb(232, 240, 254) ' #E8F0FE (Soft Blue Selection)

		' --- Flag for Unattended Visual Proof Capture Mode ---
		Public Property IsCapturing As Boolean = False

		Public Sub RebuildForm(form As System.Windows.Forms.Form)
			RetailLayouts.Apply(form)
		End Sub

		' --- 2. Typography Factory ---
		Private _baseFontName As String = Nothing

		Public Function GetFontFamily() As String
			If _baseFontName Is Nothing Then
				Using testFont As New Font("Segoe UI Variable Text", 9F)
					If testFont.Name = "Segoe UI Variable Text" Then
						_baseFontName = "Segoe UI Variable Text"
					Else
						_baseFontName = "Segoe UI"
					End If
				End Using
			End If
			Return _baseFontName
		End Function

		Public Function FontRegular(size As Single) As Font
			Return New Font(GetFontFamily(), size, FontStyle.Regular, GraphicsUnit.Point)
		End Function

		Public Function FontSemiBold(size As Single) As Font
			Return New Font(GetFontFamily(), size, FontStyle.Bold, GraphicsUnit.Point)
		End Function

		Public Function FontHero(size As Single) As Font
			Return New Font("Segoe UI", size, FontStyle.Bold, GraphicsUnit.Point)
		End Function

		' --- 3. Control Stylers ---

		''' <summary>
		''' Applies Apple-style Primary Action styling (Blue or Pay Green).
		''' </summary>
		Public Sub ApplyPrimaryButton(btn As System.Windows.Forms.Button, text As String, Optional isPayGreen As Boolean = False)
			If btn Is Nothing Then Return
			If Not String.IsNullOrEmpty(text) Then btn.Text = text
			RetailUI.StyleButton(btn, True)
		End Sub

		''' <summary>
		''' Applies Apple-style Secondary / Ghost pill button styling.
		''' </summary>
		Public Sub ApplySecondaryButton(btn As System.Windows.Forms.Button, Optional text As String = Nothing)
			If btn Is Nothing Then Return
			If Not String.IsNullOrEmpty(text) Then btn.Text = text
			RetailUI.StyleButton(btn)
		End Sub

		''' <summary>
		''' Applies Apple-style Destructive / Danger button styling.
		''' </summary>
		Public Sub ApplyDangerButton(btn As System.Windows.Forms.Button, Optional text As String = Nothing)
			If btn Is Nothing Then Return
			If Not String.IsNullOrEmpty(text) Then btn.Text = text
			RetailUI.StyleButton(btn, False, True)
		End Sub

		''' <summary>
		''' Formats a Windows Forms DataGridView into a clean, modern Apple table.
		''' </summary>
		Public Sub ApplyAppleDataGrid(dgv As System.Windows.Forms.DataGridView)
			If dgv IsNot Nothing Then RetailUI.StyleGrid(dgv)
		End Sub

		' --- 4. Form-Specific Polishers ---

		''' <summary>
		''' Transforms the Login dialog into an elegant Apple ID / macOS-inspired card.
		''' </summary>
		Public Sub PolishLoginForm(frm As System.Windows.Forms.Form, pnlCard As System.Windows.Forms.Panel,
								   btnOk As System.Windows.Forms.Button, btnCancel As System.Windows.Forms.Button,
								   txtUser As System.Windows.Forms.TextBox, txtPass As System.Windows.Forms.TextBox,
								   lblTitle As System.Windows.Forms.Label)
			If frm IsNot Nothing Then RetailLayouts.Apply(frm)
		End Sub

		''' <summary>
		''' Polishes the core Point-of-Sale (frmPOS) screen into a high-clarity modern workspace.
		''' </summary>
		Public Sub PolishPOSForm(frm As System.Windows.Forms.Form, dgvCart As System.Windows.Forms.DataGridView,
								 dgvSearch As System.Windows.Forms.DataGridView,
								 txtTotal As System.Windows.Forms.TextBox, txtSubTotal As System.Windows.Forms.TextBox,
								 txtDue As System.Windows.Forms.TextBox,
								 btnSave As System.Windows.Forms.Button, btnCheckout As System.Windows.Forms.Button,
								 btnUpi As System.Windows.Forms.Button, btnUpdate As System.Windows.Forms.Button,
								 btnGetData As System.Windows.Forms.Button, btnPrint As System.Windows.Forms.Button,
								 btnNew As System.Windows.Forms.Button, btnDelete As System.Windows.Forms.Button,
								 btnHold As System.Windows.Forms.Button, btnUnhold As System.Windows.Forms.Button,
								 btnScan As System.Windows.Forms.Button, btnGift As System.Windows.Forms.Button,
								 pnlUpi As System.Windows.Forms.Panel)
			If frm IsNot Nothing Then RetailLayouts.Apply(frm)
		End Sub

		''' <summary>
		''' Custom ToolStrip/MenuStrip Apple Minimalist Renderer
		''' </summary>
		Public Class AppleMenuRenderer
			Inherits System.Windows.Forms.ToolStripProfessionalRenderer

			Public Sub New()
				MyBase.New(New AppleColorTable())
			End Sub

			Protected Overrides Sub OnRenderMenuItemBackground(e As System.Windows.Forms.ToolStripItemRenderEventArgs)
				If e.Item.Selected OrElse e.Item.Pressed Then
					Dim rect As New Rectangle(Point.Empty, e.Item.Size)
					Using brush As New SolidBrush(PrimaryBlue)
						e.Graphics.FillRectangle(brush, rect)
					End Using
					e.Item.ForeColor = Color.White
				Else
					Dim rect As New Rectangle(Point.Empty, e.Item.Size)
					Using brush As New SolidBrush(CardBg)
						e.Graphics.FillRectangle(brush, rect)
					End Using
					e.Item.ForeColor = TextPrimary
				End If
			End Sub
		End Class

		Public Class AppleColorTable
			Inherits System.Windows.Forms.ProfessionalColorTable

			Public Overrides ReadOnly Property MenuStripGradientBegin As Color
				Get
					Return CardBg
				End Get
			End Property

			Public Overrides ReadOnly Property MenuStripGradientEnd As Color
				Get
					Return CardBg
				End Get
			End Property

			Public Overrides ReadOnly Property ToolStripBorder As Color
				Get
					Return CardBorder
				End Get
			End Property

			Public Overrides ReadOnly Property MenuItemBorder As Color
				Get
					Return Color.Transparent
				End Get
			End Property

			Public Overrides ReadOnly Property MenuItemSelectedGradientBegin As Color
				Get
					Return PrimaryBlue
				End Get
			End Property

			Public Overrides ReadOnly Property MenuItemSelectedGradientEnd As Color
				Get
					Return PrimaryBlue
				End Get
			End Property

			Public Overrides ReadOnly Property MenuItemPressedGradientBegin As Color
				Get
					Return PrimaryBlue
				End Get
			End Property

			Public Overrides ReadOnly Property MenuItemPressedGradientEnd As Color
				Get
					Return PrimaryBlue
				End Get
			End Property
		End Class

		''' <summary>
		''' Generates high-fidelity visual proofs of the modernized WinForms screens directly to disk.
		''' </summary>
		Public Sub CaptureProofs(outDir As String, Optional splashForm As frmSplash = Nothing)
            IsCapturing = True
            Dim targetDir = System.IO.Path.Combine(outDir, "proofs")
            System.IO.Directory.CreateDirectory(targetDir)
            Try
                If splashForm IsNot Nothing Then CaptureForm(splashForm, targetDir, "splash")
                Using form As New frmLogin()
                    CaptureForm(form, targetDir, "login")
                End Using
                Using form As New frmMainMenu()
                    CaptureForm(form, targetDir, "mainmenu")
                End Using
                Using form As New frmPOS()
                    CaptureForm(form, targetDir, "pos")
                End Using
                Using form As New frmSqlServerSetting()
                    CaptureForm(form, targetDir, "sqlsettings")
                End Using
                System.IO.File.WriteAllText(System.IO.Path.Combine(targetDir, "capture_success.txt"), "All requested forms rendered successfully.")
            Finally
                IsCapturing = False
            End Try
        End Sub

        Private Sub CaptureForm(form As System.Windows.Forms.Form, targetDir As String, name As String)
            form.ShowInTaskbar = False
            form.Show()
            RetailLayouts.Apply(form)
            form.PerformLayout()
            System.Windows.Forms.Application.DoEvents()
            Using bitmap As New Bitmap(form.Width, form.Height)
                form.DrawToBitmap(bitmap, New Rectangle(Point.Empty, bitmap.Size))
                bitmap.Save(System.IO.Path.Combine(targetDir, "proof_" & name & ".png"), System.Drawing.Imaging.ImageFormat.Png)
            End Using
            form.Hide()
        End Sub

	End Module
End Namespace
