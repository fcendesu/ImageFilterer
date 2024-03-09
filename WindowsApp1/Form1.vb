Imports System.Drawing.Imaging
Public Class Form1
    Private Sub GrayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GrayToolStripMenuItem.Click
        Try
            OpenFileDialog1.DefaultExt = ".jpg"
            OpenFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"
            OpenFileDialog1.ShowDialog()
            PictureBox1.Load(OpenFileDialog1.FileName)
            PictureBox2.Load(OpenFileDialog1.FileName)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.Hide()
        Label10.Text = "0%"
        Label11.Text = "0%"
        Label12.Text = "0%"
        Label13.Text = "0%"
        Label14.Text = "0"
        Label15.Text = "0"
        Label16.Text = "0"

        HScrollBar1.Maximum = 100
        HScrollBar1.Minimum = 0
        HScrollBar1.LargeChange = 1

        HScrollBar2.Maximum = 100
        HScrollBar2.Minimum = 0
        HScrollBar2.LargeChange = 1

        HScrollBar3.Maximum = 100
        HScrollBar3.Minimum = 0
        HScrollBar3.LargeChange = 1

        HScrollBar4.Maximum = 100
        HScrollBar4.Minimum = 0
        HScrollBar4.LargeChange = 1

        HScrollBar5.Maximum = 255
        HScrollBar5.Minimum = 0
        HScrollBar5.LargeChange = 1

        HScrollBar6.Maximum = 255
        HScrollBar6.Minimum = 0
        HScrollBar6.LargeChange = 1

        HScrollBar7.Maximum = 255
        HScrollBar7.Minimum = 0
        HScrollBar7.LargeChange = 1
    End Sub

    Private Sub GrayScaleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GrayScaleToolStripMenuItem.Click
        Try
            Dim apsis As Integer
            Dim ordinat As Integer
            Dim resim As Bitmap
            Dim renkdegisim As Integer
            resim = PictureBox1.Image
            For apsis = 0 To resim.Width - 1
                For ordinat = 0 To resim.Height - 1
                    renkdegisim = (CInt(resim.GetPixel(apsis, ordinat).R) + resim.GetPixel(apsis, ordinat).G + resim.GetPixel(apsis, ordinat).B) / 3

                    resim.SetPixel(apsis, ordinat, Color.FromArgb(renkdegisim, renkdegisim, renkdegisim))
                Next
            Next
            PictureBox1.Image = resim
        Catch ex As Exception
            MsgBox("Resim seçiniz!")
        End Try
    End Sub

    Private Sub NegativeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NegativeToolStripMenuItem.Click
        Try
            Dim red, green, blue
            Dim apsis, ordinat As Integer
            Dim resim As Bitmap
            resim = PictureBox1.Image
            apsis = resim.Width - 1
            ordinat = resim.Height - 1
            For i = 0 To apsis
                For k = 0 To ordinat
                    red = 255 - resim.GetPixel(i, k).R
                    green = 255 - resim.GetPixel(i, k).G
                    blue = 255 - resim.GetPixel(i, k).B
                    resim.SetPixel(i, k, Color.FromArgb(red, green, blue))
                Next
            Next
            PictureBox1.Image = resim
        Catch ex As Exception
            MsgBox("resim seçiniz!")
        End Try
    End Sub

    Private Sub TToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TToolStripMenuItem.Click
        Try
            Dim red, green, blue
            Dim apsis, ordinat As Integer
            Dim resim As Bitmap
            resim = PictureBox1.Image
            For apsis = 0 To resim.Width - 1
                For ordinat = 0 To resim.Height - 1
                    If resim.GetPixel(apsis, ordinat).R >= 128 Then
                        red = 255
                    Else
                        red = 0
                    End If

                    If resim.GetPixel(apsis, ordinat).G >= 128 Then
                        green = 255
                    Else
                        green = 0
                    End If

                    If resim.GetPixel(apsis, ordinat).B >= 128 Then
                        blue = 255
                    Else
                        blue = 0
                    End If

                    resim.SetPixel(apsis, ordinat, Color.FromArgb(red, green, blue))
                Next
            Next
            PictureBox1.Image = resim
        Catch ex As Exception
            MsgBox("resim seçiniz!")
        End Try
    End Sub

    Private Sub BrightnessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BrightnessToolStripMenuItem.Click
        Try
            Dim red, green, blue, alpha
            Dim r, g, b
            Dim apsis, ordinat As Integer
            Dim resim As Bitmap
            resim = PictureBox1.Image

            For apsis = 0 To resim.Width - 1
                For ordinat = 0 To resim.Height - 1
                    red = resim.GetPixel(apsis, ordinat).R
                    green = resim.GetPixel(apsis, ordinat).G
                    blue = resim.GetPixel(apsis, ordinat).B
                    alpha = resim.GetPixel(apsis, ordinat).A

                    r = CInt((0.393 * red + 0.769 * green + 0.189 * blue))
                    g = CInt((0.349 * red + 0.686 * green + 0.168 * blue))
                    b = CInt((0.272 * red + 0.534 * green + 0.131 * blue))

                    If r > 255 Then
                        red = 255
                    Else
                        red = r
                    End If

                    If g > 255 Then
                        green = 255
                    Else
                        green = g
                    End If

                    If b > 255 Then
                        blue = 255
                    Else
                        blue = b
                    End If

                    resim.SetPixel(apsis, ordinat, Color.FromArgb(alpha, red, green, blue))
                Next
            Next
            PictureBox1.Image = resim
        Catch ex As Exception
            MsgBox("resim seçiniz!")
        End Try
    End Sub

    Private Sub XRayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XRayToolStripMenuItem.Click
        Try
            Dim renkdegisim As Integer
            Dim apsis, ordinat As Integer
            Dim resim As Bitmap
            resim = PictureBox1.Image

            For apsis = 0 To resim.Width - 1
                For ordinat = 0 To resim.Height - 1
                    renkdegisim = (CInt(resim.GetPixel(apsis, ordinat).R) + resim.GetPixel(apsis, ordinat).G + resim.GetPixel(apsis, ordinat).B) / 3
                    resim.SetPixel(apsis, ordinat, Color.FromArgb(renkdegisim, renkdegisim, renkdegisim))
                Next
            Next

            Dim nitelik As New ImageAttributes
            Dim renkmatris As New ColorMatrix

            renkmatris.Matrix00 = -1 : renkmatris.Matrix11 = -1 : renkmatris.Matrix22 = -1
            renkmatris.Matrix40 = 1 : renkmatris.Matrix41 = 1 : renkmatris.Matrix42 = 1
            nitelik.SetColorMatrix(renkmatris)

            Dim dortgen As New Rectangle(0, 0, resim.Width, resim.Height)

            Dim grafik As Graphics = Graphics.FromImage(resim)
            grafik.DrawImage(resim, dortgen, dortgen.X, dortgen.Y, dortgen.Width, dortgen.Height, GraphicsUnit.Pixel, nitelik)
            PictureBox1.Image = resim
        Catch ex As Exception
            MsgBox("resim seçiniz!")
        End Try
    End Sub

    Private Sub RedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedToolStripMenuItem.Click
        Try
            Dim green, blue
            Dim apsis, ordinat As Integer
            Dim resim As Bitmap
            resim = PictureBox1.Image
            For apsis = 0 To resim.Width - 1
                For ordinat = 0 To resim.Height - 1
                    green = resim.GetPixel(apsis, ordinat).G
                    blue = resim.GetPixel(apsis, ordinat).B
                    resim.SetPixel(apsis, ordinat, Color.FromArgb(255, green, blue))
                Next
            Next
            PictureBox1.Image = resim
        Catch ex As Exception
            MsgBox("resim seçiniz!")
        End Try
    End Sub

    Private Sub BlueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlueToolStripMenuItem.Click
        Try
            Dim red, blue
            Dim apsis, ordinat As Integer
            Dim resim As Bitmap
            resim = PictureBox1.Image
            For apsis = 0 To resim.Width - 1
                For ordinat = 0 To resim.Height - 1
                    red = resim.GetPixel(apsis, ordinat).R
                    blue = resim.GetPixel(apsis, ordinat).B
                    resim.SetPixel(apsis, ordinat, Color.FromArgb(red, 255, blue))
                Next
            Next
            PictureBox1.Image = resim
        Catch ex As Exception
            MsgBox("resim seçiniz!")
        End Try
    End Sub

    Private Sub GreenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GreenToolStripMenuItem.Click
        Try
            Dim red, green
            Dim apsis, ordinat As Integer
            Dim resim As Bitmap
            resim = PictureBox1.Image
            For apsis = 0 To resim.Width - 1
                For ordinat = 0 To resim.Height - 1
                    red = resim.GetPixel(apsis, ordinat).R
                    green = resim.GetPixel(apsis, ordinat).G
                    resim.SetPixel(apsis, ordinat, Color.FromArgb(red, green, 255))
                Next
            Next
            PictureBox1.Image = resim
        Catch ex As Exception
            MsgBox("resim seçiniz!")
        End Try
    End Sub

    Private Sub ResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
        PictureBox1.Image = PictureBox2.Image
    End Sub

    Private Sub KaydetToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AverageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AverageToolStripMenuItem.Click
        Try
            Dim apsis As Integer
            Dim ordinat As Integer
            Dim resim As Bitmap
            Dim renkdegisim As Integer
            Dim red, green, blue As Integer
            Dim renk As Color
            resim = PictureBox1.Image
            For apsis = 0 To resim.Width - 1
                For ordinat = 0 To resim.Height - 1
                    renkdegisim = (CInt(resim.GetPixel(apsis, ordinat).R) + resim.GetPixel(apsis, ordinat).G + resim.GetPixel(apsis, ordinat).B) / 3
                    renk = resim.GetPixel(apsis, ordinat)

                    If renkdegisim > renk.R Then
                        red = renkdegisim + renk.R
                        If red > 255 Then
                            red = 255
                        End If
                    Else
                        red = renk.R - renkdegisim
                    End If

                    If renkdegisim > renk.G Then
                        green = renkdegisim + renk.G
                        If green > 255 Then
                            green = 255
                        End If
                    Else
                        green = renk.G - renkdegisim
                    End If

                    If renkdegisim > renk.B Then
                        blue = renkdegisim + renk.B
                        If blue > 255 Then
                            blue = 255
                        End If
                    Else
                        blue = renk.B - renkdegisim
                    End If
                    resim.SetPixel(apsis, ordinat, Color.FromArgb(red, green, blue))
                Next
            Next
            PictureBox1.Image = resim
        Catch ex As Exception
            MsgBox("resim seçiniz")
        End Try
    End Sub

    Private Sub YenidenFiltreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YenidenFiltreToolStripMenuItem.Click
        MsgBox("başka filtre uygulamak istiyorsanız resmi resetleyiniz")
    End Sub

    Private Sub AverageFilterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AverageFilterToolStripMenuItem.Click
        MsgBox("kendim salladım")
    End Sub

    Private Sub EdgeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EdgeToolStripMenuItem.Click
        Try
            Dim tresim As Bitmap = New Bitmap(PictureBox1.Image)
            Dim bresim As Bitmap = New Bitmap(PictureBox1.Image)

            Dim genislik As Integer = tresim.Width
            Dim yukseklik As Integer = tresim.Height

            Dim x As Integer(,) = New Integer(,) {{-1, 0, 1},
             {-2, 0, 2}, {-1, 0, 1}}
            Dim y As Integer(,) = New Integer(,) {{1, 2, 1},
             {0, 0, 0}, {-1, -2, -1}}

            Dim r As Integer(,) = New Integer(genislik - 1,
             yukseklik - 1) {}
            Dim g As Integer(,) = New Integer(genislik - 1,
             yukseklik - 1) {}
            Dim b As Integer(,) = New Integer(genislik - 1,
             yukseklik - 1) {}

            Dim max As Integer = 128 * 128

            For i As Integer = 0 To genislik - 1
                For j As Integer = 0 To yukseklik - 1

                    r(i, j) = tresim.GetPixel(i, j).R
                    g(i, j) = tresim.GetPixel(i, j).G
                    b(i, j) = tresim.GetPixel(i, j).B

                Next
            Next

            Dim rX As Integer = 0
            Dim rY As Integer = 0
            Dim gX As Integer = 0
            Dim gY As Integer = 0
            Dim bX As Integer = 0
            Dim bY As Integer = 0

            Dim rTot As Integer
            Dim gTot As Integer
            Dim bTot As Integer

            For i As Integer = 1 To tresim.Width - 1 - 1

                For j As Integer = 1 To tresim.Height - 1 - 1

                    rX = 0
                    rY = 0
                    gX = 0
                    gY = 0
                    bX = 0
                    bY = 0

                    rTot = 0
                    gTot = 0
                    bTot = 0

                    For width As Integer = -1 To 2 - 1

                        For height As Integer = -1 To 2 - 1

                            rTot = r(i + height, j + width)
                            rX += x(width + 1, height + 1) * rTot
                            rY += y(width + 1, height + 1) * rTot

                            gTot = g(i + height, j + width)
                            gX += x(width + 1, height + 1) * gTot
                            gY += y(width + 1, height + 1) * gTot

                            bTot = b(i + height, j + width)
                            bX += x(width + 1, height + 1) * bTot
                            bY += y(width + 1, height + 1) * bTot

                        Next
                    Next

                    If rX * rX + rY * rY > max OrElse
                   gX * gX + gY * gY > max OrElse
                   bX * bX + bY * bY > max Then

                        bresim.SetPixel(i, j, Color.Black)
                    Else
                        bresim.SetPixel(i, j, Color.Transparent)

                    End If
                Next
            Next
            PictureBox1.Image = bresim
        Catch ex As Exception
            MsgBox("resim seçiniz")
        End Try
    End Sub

    Private Sub AToolStripMenuItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub HocaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HocaToolStripMenuItem.Click
        MsgBox("Kıymetlimiss")
    End Sub
    Public Sub esitlemergb()
        Dim r, g, b As Double
        Dim c, m, y, k As Double
        r = HScrollBar5.Value / 255
        g = HScrollBar6.Value / 255
        b = HScrollBar7.Value / 255

        k = 1 - Math.Max(Math.Max(r, g), b)
        If k < 0 Or Double.IsNaN(k) Then
            k = 0
        End If
        c = (1 - r - k) / (1 - k)
        If c < 0 Or Double.IsNaN(c) Then
            c = 0
        End If
        m = (1 - g - k) / (1 - k)
        If m < 0 Or Double.IsNaN(m) Then
            m = 0
        End If
        y = (1 - b - k) / (1 - k)
        If y < 0 Or Double.IsNaN(y) Then
            y = 0
        End If

        HScrollBar1.Value = c * 100
        HScrollBar2.Value = m * 100
        HScrollBar3.Value = y * 100
        HScrollBar4.Value = k * 100

        PictureBox3.BackColor = Color.FromArgb(HScrollBar5.Value, HScrollBar6.Value, HScrollBar7.Value)
        Label10.Text = Math.Round(c * 100) & "%"
        Label11.Text = Math.Round(m * 100) & "%"
        Label12.Text = Math.Round(y * 100) & "%"
        Label13.Text = Math.Round(k * 100) & "%"
    End Sub
    Public Sub esitlemecmyk()
        Dim c, m, y, k As Double
        Dim r, g, b As Double
        c = HScrollBar1.Value / 100
        m = HScrollBar2.Value / 100
        y = HScrollBar3.Value / 100
        k = HScrollBar4.Value / 100

        r = 255 * (1 - c) * (1 - k)
        g = 255 * (1 - m) * (1 - k)
        b = 255 * (1 - y) * (1 - k)

        HScrollBar5.Value = r
        HScrollBar6.Value = g
        HScrollBar7.Value = b

        PictureBox3.BackColor = Color.FromArgb(r, g, b)
        Label14.Text = Math.Round(r)
        Label15.Text = Math.Round(g)
        Label16.Text = Math.Round(b)
    End Sub
    Public Sub cmykdeger()
        Label10.Text = HScrollBar1.Value & "%"
        Label11.Text = HScrollBar1.Value & "%"
        Label12.Text = HScrollBar1.Value & "%"
        Label13.Text = HScrollBar1.Value & "%"
    End Sub
    Public Sub rgbdeger()
        Label14.Text = HScrollBar5.Value
        Label15.Text = HScrollBar6.Value
        Label16.Text = HScrollBar7.Value
    End Sub
    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        esitlemecmyk()
        cmykdeger()
    End Sub

    Private Sub HScrollBar2_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar2.Scroll
        esitlemecmyk()
        cmykdeger()
    End Sub

    Private Sub HScrollBar3_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar3.Scroll
        esitlemecmyk()
        cmykdeger()
    End Sub

    Private Sub HScrollBar4_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar4.Scroll
        esitlemecmyk()
        cmykdeger()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim red, green, blue As Integer
            Dim c, m, y, k As Double
            Dim r, g, b As Double
            c = HScrollBar1.Value / 100
            m = HScrollBar2.Value / 100
            y = HScrollBar3.Value / 100
            k = HScrollBar4.Value / 100

            r = 255 * (1 - c) * (1 - k)
            g = 255 * (1 - m) * (1 - k)
            b = 255 * (1 - y) * (1 - k)

            Dim apsis, ordinat As Integer
            Dim renk As Color
            Dim resim As Bitmap
            resim = PictureBox1.Image

            For apsis = 0 To resim.Width - 1
                For ordinat = 0 To resim.Height - 1
                    renk = resim.GetPixel(apsis, ordinat)

                    red = r + renk.R
                    If red > 255 Then
                        red = 255
                    End If

                    green = g + renk.G
                    If green > 255 Then
                        green = 255
                    End If

                    blue = r + renk.B
                    If blue > 255 Then
                        blue = 255
                    End If
                    resim.SetPixel(apsis, ordinat, Color.FromArgb(red, green, blue))

                Next
            Next
            PictureBox1.Image = resim
        Catch ex As Exception
            MsgBox("resim seçiniz")
        End Try
    End Sub

    Private Sub HScrollBar5_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar5.Scroll
        esitlemergb()
        rgbdeger()
    End Sub

    Private Sub HScrollBar6_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar6.Scroll
        esitlemergb()
        rgbdeger()
    End Sub

    Private Sub HScrollBar7_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar7.Scroll
        esitlemergb()
        rgbdeger()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim red, green, blue As Integer
            Dim apsis, ordinat As Integer
            Dim renk As Color
            Dim resim As Bitmap
            resim = PictureBox1.Image
            For apsis = 0 To resim.Width - 1
                For ordinat = 0 To resim.Height - 1
                    renk = resim.GetPixel(apsis, ordinat)
                    red = renk.R + HScrollBar5.Value
                    If red > 255 Then
                        red = 255
                    End If

                    green = renk.G + HScrollBar6.Value
                    If green > 255 Then
                        green = 255
                    End If

                    blue = renk.B + HScrollBar7.Value
                    If blue > 255 Then
                        blue = 255
                    End If
                    resim.SetPixel(apsis, ordinat, Color.FromArgb(red, green, blue))
                Next
            Next
            PictureBox1.Image = resim
        Catch ex As Exception
            MsgBox("resim seçiniz!")
        End Try
    End Sub
End Class
