Option Infer On
Option Explicit On
Option Strict On
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Namespace BillPoint
    Public Enum RetailIllustration
        Storefront
        EmptyBag
    End Enum

    Public Module RetailAssets
        Private ReadOnly Images As New Dictionary(Of RetailIllustration, Image)()

        Public Function Picture(illustration As RetailIllustration, name As String) As RetailArtwork
            Return New RetailArtwork(LoadImage(illustration)) With {.Name = name, .Dock = DockStyle.Fill, .Margin = New Padding(0)}
        End Function

        Private Function LoadImage(illustration As RetailIllustration) As Image
            If Images.ContainsKey(illustration) Then Return Images(illustration)
            Dim resource = If(illustration = RetailIllustration.Storefront, "SmartRetail.Assets.Storefront.png", "SmartRetail.Assets.EmptyBag.png")
            Using stream = GetType(RetailArtwork).Assembly.GetManifestResourceStream(resource)
                If stream Is Nothing Then
                    Diagnostics.Trace.TraceWarning("Retail illustration is missing from the application: " & resource)
                    Return Nothing
                End If
                Using source = Image.FromStream(stream)
                    Images.Add(illustration, New Bitmap(source))
                End Using
            End Using
            Return Images(illustration)
        End Function
    End Module

    ' Decorative artwork never owns focus, contains instructions, or replaces an action.
    Public Class RetailArtwork
        Inherits Control
        Private ReadOnly Artwork As Image

        Public Sub New(image As Image)
            Artwork = image
            BackColor = RetailUI.Tone("surface")
            TabStop = False
            AccessibleRole = AccessibleRole.None
            SetStyle(ControlStyles.Selectable, False)
            SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            If SystemInformation.HighContrast OrElse Artwork Is Nothing Then Return
            Dim scale = Math.Min(CSng(ClientSize.Width) / Artwork.Width, CSng(ClientSize.Height) / Artwork.Height)
            If scale <= 0 Then Return
            Dim width = CInt(Artwork.Width * scale)
            Dim height = CInt(Artwork.Height * scale)
            Dim bounds As New Rectangle((ClientSize.Width - width) \ 2, (ClientSize.Height - height) \ 2, width, height)
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality
            e.Graphics.DrawImage(Artwork, bounds)
        End Sub
    End Class
End Namespace
