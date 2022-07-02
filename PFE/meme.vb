Public Class meme
    '___________________________________________________________________________________________________________________'


    Public Sub go(ByRef frm As Form)

        '-------------------------اضهار القوائم
        Pl3.Controls.Clear()
        frm.TopLevel = False
        Pl3.Controls.Add(frm)
        frm.Show()


    End Sub



    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        '---------------------mun botn----------------------------'

        If Pl1.Width < 90 Then
            While Pl1.Width < 165
                Pl1.Width += 20
            End While
            Exit Sub
        End If

        If Pl1.Width > 5 Then
            While Pl1.Width > 1
                Pl1.Width -= 20
            End While
            Exit Sub
        End If

    End Sub



    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        go(employes)
        If Pl1.Width > 5 Then
            While Pl1.Width > 1
                Pl1.Width -= 20
            End While
            Exit Sub
        End If
    End Sub




    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        go(employes)
        If Pl1.Width > 5 Then
            While Pl1.Width > 1
                Pl1.Width -= 20
            End While
            Exit Sub
        End If
    End Sub

    Private Sub GunaGradientButton2_Click_1(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        '---------------------mun botn----------------------------'

        If Pl1.Width < 90 Then
            While Pl1.Width < 165
                Pl1.Width += 20
            End While
            Exit Sub
        End If

        If Pl1.Width > 5 Then
            While Pl1.Width > 1
                Pl1.Width -= 20
            End While
            Exit Sub
        End If
    End Sub

    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click
        go(E_et_S)
        If Pl1.Width > 5 Then
            While Pl1.Width > 1
                Pl1.Width -= 20
            End While
            Exit Sub
        End If
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True


        'Label1.Text = TimeOfDay
        'Label2.Text = DateString
    End Sub

    Private Sub GunaGradientButton4_Click(sender As Object, e As EventArgs) Handles GunaGradientButton4.Click
        go(salaire)
        If Pl1.Width > 5 Then
            While Pl1.Width > 1
                Pl1.Width -= 20
            End While
        End If
        Exit Sub

    End Sub

    Private Sub GunaGradientButton5_Click(sender As Object, e As EventArgs) Handles GunaGradientButton5.Click
        End
    End Sub

    Private Sub Pl2_Paint(sender As Object, e As PaintEventArgs) Handles Pl3.Paint

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = "DATE  " & Date.Now.ToString("dd-MM-yyyy")
        Label2.Text = "TEME  " & Date.Now.ToString("HH-mm")
    End Sub

    Private Sub GunaGradientButton6_Click(sender As Object, e As EventArgs) Handles GunaGradientButton6.Click
        go(affectation)
        If Pl1.Width > 5 Then
            While Pl1.Width > 1
                Pl1.Width -= 20
            End While
            Exit Sub
        End If
    End Sub

    Private Sub GunaGradientButton7_Click(sender As Object, e As EventArgs) Handles GunaGradientButton7.Click
        go(edet)
        If Pl1.Width > 5 Then
            While Pl1.Width > 1
                Pl1.Width -= 20
            End While
            Exit Sub
        End If

    End Sub
End Class