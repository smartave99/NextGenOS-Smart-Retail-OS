Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO

Namespace BillPoint
	' Token: 0x0200035A RID: 858
	Public Class TiffImage
		' Token: 0x0600CB6B RID: 52075 RVA: 0x007F3E70 File Offset: 0x007F2070
		Public Sub New(path As String)
			Me.myImages = New ArrayList()
			Me.myPath = path
			Dim fileStream As FileStream = New FileStream(Me.myPath, FileMode.Open)
			Dim image As Image = Image.FromStream(fileStream)
			Me.myGuid = image.FrameDimensionsList(0)
			Me.myDimension = New FrameDimension(Me.myGuid)
			Me.myPageCount = image.GetFrameCount(Me.myDimension)
			Dim num As Integer = Me.myPageCount - 1
			For i As Integer = 0 To num
				Dim memoryStream As MemoryStream = New MemoryStream()
				image.SelectActiveFrame(Me.myDimension, i)
				image.Save(memoryStream, ImageFormat.Bmp)
				Me.myBMP = New Bitmap(memoryStream)
				Me.myImages.Add(Me.myBMP)
				memoryStream.Close()
			Next
			fileStream.Close()
		End Sub

		' Token: 0x04005186 RID: 20870
		Private myPath As String

		' Token: 0x04005187 RID: 20871
		Private myGuid As Guid

		' Token: 0x04005188 RID: 20872
		Private myDimension As FrameDimension

		' Token: 0x04005189 RID: 20873
		Public myImages As ArrayList

		' Token: 0x0400518A RID: 20874
		Private myPageCount As Integer

		' Token: 0x0400518B RID: 20875
		Private myBMP As Bitmap
	End Class
End Namespace
