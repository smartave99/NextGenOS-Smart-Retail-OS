Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace BillPoint
	' Token: 0x02000013 RID: 19
	Public Class DragLabel
		' Token: 0x060004D1 RID: 1233 RVA: 0x0008715C File Offset: 0x0008535C
		Public Sub New()
			Me.BoxColor = Color.Lime
			Me.lbl = New Label(7) {}
			Me.arrArrow = New Cursor() { Cursors.SizeNWSE, Cursors.SizeNS, Cursors.SizeNESW, Cursors.SizeWE, Cursors.SizeNWSE, Cursors.SizeNS, Cursors.SizeNESW, Cursors.SizeWE }
			Dim num As Integer = 0
			Do
				Me.lbl(num) = New Label()
				Me.lbl(num).TabIndex = num
				Me.lbl(num).FlatStyle = FlatStyle.Flat
				Me.lbl(num).BorderStyle = BorderStyle.FixedSingle
				Me.lbl(num).BackColor = Me.BoxColor
				Me.lbl(num).Cursor = Me.arrArrow(num)
				Me.lbl(num).Text = ""
				Me.lbl(num).BringToFront()
				AddHandler Me.lbl(num).MouseDown, AddressOf Me.lbl_MouseDown
				AddHandler Me.lbl(num).MouseMove, AddressOf Me.lbl_MouseMove
				AddHandler Me.lbl(num).MouseUp, AddressOf Me.lbl_MouseUp
				num += 1
			Loop While num <= 7
		End Sub

		' Token: 0x060004D2 RID: 1234 RVA: 0x000093AA File Offset: 0x000075AA
		Public Sub WireControl(ctl As Control)
			AddHandler ctl.Click, AddressOf Me.SelectControl
		End Sub

		' Token: 0x060004D3 RID: 1235 RVA: 0x000872B4 File Offset: 0x000854B4
		Private Sub SelectControl(sender As Object, e As EventArgs)
			Dim flag As Boolean = TypeOf Me.ctrlControl Is Control
			If flag Then
				Me.ctrlControl.Cursor = Me.oldCursor
				RemoveHandler Me.ctrlControl.MouseDown, AddressOf Me.ctl_MouseDown
				RemoveHandler Me.ctrlControl.MouseMove, AddressOf Me.ctl_MouseMove
				RemoveHandler Me.ctrlControl.MouseUp, AddressOf Me.ctl_MouseUp
				Me.ctrlControl = Nothing
			End If
			Me.ctrlControl = CType(sender, Control)
			AddHandler Me.ctrlControl.MouseDown, AddressOf Me.ctl_MouseDown
			AddHandler Me.ctrlControl.MouseMove, AddressOf Me.ctl_MouseMove
			AddHandler Me.ctrlControl.MouseUp, AddressOf Me.ctl_MouseUp
			Dim num As Integer = 0
			Do
				Me.ctrlControl.Parent.Controls.Add(Me.lbl(num))
				Me.lbl(num).BringToFront()
				num += 1
			Loop While num <= 7
			Me.MoveHandles()
			Me.ShowHandles()
			Me.oldCursor = Me.ctrlControl.Cursor
			Me.ctrlControl.Cursor = Cursors.SizeAll
		End Sub

		' Token: 0x060004D4 RID: 1236 RVA: 0x000093C0 File Offset: 0x000075C0
		Public Sub Remove()
			Me.HideHandles()
			Me.ctrlControl.Cursor = Me.oldCursor
		End Sub

		' Token: 0x060004D5 RID: 1237 RVA: 0x000873F4 File Offset: 0x000855F4
		Private Sub ShowHandles()
			Dim flag As Boolean = Me.ctrlControl IsNot Nothing
			If flag Then
				Dim num As Integer = 0
				Do
					Me.lbl(num).Visible = True
					num += 1
				Loop While num <= 7
			End If
		End Sub

		' Token: 0x060004D6 RID: 1238 RVA: 0x0008742C File Offset: 0x0008562C
		Private Sub HideHandles()
			Dim num As Integer = 0
			Do
				Me.lbl(num).Visible = False
				num += 1
			Loop While num <= 7
		End Sub

		' Token: 0x060004D7 RID: 1239 RVA: 0x00087454 File Offset: 0x00085654
		Private Sub MoveHandles()
			' The following expression was wrapped in a checked-statement
			Dim num As Integer = Me.ctrlControl.Left - 5
			Dim num2 As Integer = Me.ctrlControl.Top - 5
			Dim num3 As Integer = Me.ctrlControl.Width + 5
			Dim num4 As Integer = Me.ctrlControl.Height + 5
			Dim num5 As Integer = 2
			Dim array As Integer() = New Integer() { num + num5, num + num3 / 2, num + num3 - num5, num + num3 - num5, num + num3 - num5, num + num3 / 2, num + num5, num + num5 }
			Dim array2 As Integer() = New Integer() { num2 + num5, num2 + num5, num2 + num5, num2 + num4 / 2, num2 + num4 - num5, num2 + num4 - num5, num2 + num4 - num5, num2 + num4 / 2 }
			Dim num6 As Integer = 0
			Do
				Me.lbl(num6).SetBounds(array(num6), array2(num6), 5, 5)
				num6 += 1
			Loop While num6 <= 7
		End Sub

		' Token: 0x060004D8 RID: 1240 RVA: 0x00087558 File Offset: 0x00085758
		Private Sub lbl_MouseDown(sender As Object, e As MouseEventArgs)
			Me.isDragging = True
			Me.intStartl = Me.ctrlControl.Left
			Me.intStartt = Me.ctrlControl.Top
			Me.intStartw = Me.ctrlControl.Width
			Me.intStarth = Me.ctrlControl.Height
			Me.HideHandles()
		End Sub

		' Token: 0x060004D9 RID: 1241 RVA: 0x000875B8 File Offset: 0x000857B8
		Private Sub lbl_MouseMove(sender As Object, e As MouseEventArgs)
			Dim num As Integer = Me.ctrlControl.Left
			Dim num2 As Integer = Me.ctrlControl.Width
			Dim num3 As Integer = Me.ctrlControl.Top
			Dim num4 As Integer = Me.ctrlControl.Height
			Dim flag As Boolean = Me.isDragging
			If flag Then
				Select Case CType(sender, Label).TabIndex
					Case 0
						num = If((Me.intStartl + e.X < Me.intStartl + Me.intStartw - 20), (Me.intStartl + e.X), (Me.intStartl + Me.intStartw - 20))
						num3 = If((Me.intStartt + e.Y < Me.intStartt + Me.intStarth - 20), (Me.intStartt + e.Y), (Me.intStartt + Me.intStarth - 20))
						num2 = Me.intStartl + Me.intStartw - Me.ctrlControl.Left
						num4 = Me.intStartt + Me.intStarth - Me.ctrlControl.Top
					Case 1
						num3 = If((Me.intStartt + e.Y < Me.intStartt + Me.intStarth - 20), (Me.intStartt + e.Y), (Me.intStartt + Me.intStarth - 20))
						num4 = Me.intStartt + Me.intStarth - Me.ctrlControl.Top
					Case 2
						num2 = If((Me.intStartw + e.X > 20), (Me.intStartw + e.X), 20)
						num3 = If((Me.intStartt + e.Y < Me.intStartt + Me.intStarth - 20), (Me.intStartt + e.Y), (Me.intStartt + Me.intStarth - 20))
						num4 = Me.intStartt + Me.intStarth - Me.ctrlControl.Top
					Case 3
						num2 = If((Me.intStartw + e.X > 20), (Me.intStartw + e.X), 20)
					Case 4
						num2 = If((Me.intStartw + e.X > 20), (Me.intStartw + e.X), 20)
						num4 = If((Me.intStarth + e.Y > 20), (Me.intStarth + e.Y), 20)
					Case 5
						num4 = If((Me.intStarth + e.Y > 20), (Me.intStarth + e.Y), 20)
					Case 6
						num = If((Me.intStartl + e.X < Me.intStartl + Me.intStartw - 20), (Me.intStartl + e.X), (Me.intStartl + Me.intStartw - 20))
						num2 = Me.intStartl + Me.intStartw - Me.ctrlControl.Left
						num4 = If((Me.intStarth + e.Y > 20), (Me.intStarth + e.Y), 20)
					Case 7
						num = If((Me.intStartl + e.X < Me.intStartl + Me.intStartw - 20), (Me.intStartl + e.X), (Me.intStartl + Me.intStartw - 20))
						num2 = Me.intStartl + Me.intStartw - Me.ctrlControl.Left
				End Select
				num = If((num < 0), 0, num)
				num3 = If((num3 < 0), 0, num3)
				Me.ctrlControl.SetBounds(num, num3, num2, num4)
			End If
		End Sub

		' Token: 0x060004DA RID: 1242 RVA: 0x000093DC File Offset: 0x000075DC
		Private Sub lbl_MouseUp(sender As Object, e As MouseEventArgs)
			Me.isDragging = False
			Me.MoveHandles()
			Me.ShowHandles()
		End Sub

		' Token: 0x060004DB RID: 1243 RVA: 0x000093F4 File Offset: 0x000075F4
		Private Sub ctl_MouseDown(sender As Object, e As MouseEventArgs)
			Me.isDragging = True
			Me.intStartx = e.X
			Me.intStarty = e.Y
			Me.HideHandles()
		End Sub

		' Token: 0x060004DC RID: 1244 RVA: 0x00087978 File Offset: 0x00085B78
		Private Sub ctl_MouseMove(sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = Me.isDragging
			If flag Then
				Dim num As Integer = Me.ctrlControl.Left + e.X - Me.intStartx
				Dim num2 As Integer = Me.ctrlControl.Top + e.Y - Me.intStarty
				Dim width As Integer = Me.ctrlControl.Width
				Dim height As Integer = Me.ctrlControl.Height
				num = If((num < 0), 0, If((num + width > Me.ctrlControl.Parent.ClientRectangle.Width), (Me.ctrlControl.Parent.ClientRectangle.Width - width), num))
				num2 = If((num2 < 0), 0, If((num2 + height > Me.ctrlControl.Parent.ClientRectangle.Height), (Me.ctrlControl.Parent.ClientRectangle.Height - height), num2))
				Me.ctrlControl.Left = num
				Me.ctrlControl.Top = num2
			End If
		End Sub

		' Token: 0x060004DD RID: 1245 RVA: 0x000093DC File Offset: 0x000075DC
		Private Sub ctl_MouseUp(sender As Object, e As MouseEventArgs)
			Me.isDragging = False
			Me.MoveHandles()
			Me.ShowHandles()
		End Sub

		' Token: 0x040001C7 RID: 455
		Private Const intBoxSize As Integer = 5

		' Token: 0x040001C8 RID: 456
		Private BoxColor As Color

		' Token: 0x040001C9 RID: 457
		Private ctrlControl As Control

		' Token: 0x040001CA RID: 458
		Private lbl As Label()

		' Token: 0x040001CB RID: 459
		Private intStartl As Integer

		' Token: 0x040001CC RID: 460
		Private intStartt As Integer

		' Token: 0x040001CD RID: 461
		Private intStartw As Integer

		' Token: 0x040001CE RID: 462
		Private intStarth As Integer

		' Token: 0x040001CF RID: 463
		Private intStartx As Integer

		' Token: 0x040001D0 RID: 464
		Private intStarty As Integer

		' Token: 0x040001D1 RID: 465
		Private isDragging As Boolean

		' Token: 0x040001D2 RID: 466
		Private arrArrow As Cursor()

		' Token: 0x040001D3 RID: 467
		Private oldCursor As Cursor

		' Token: 0x040001D4 RID: 468
		Private Const inMinSize As Integer = 20
	End Class
End Namespace
