Public Class Form1

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            G2.PasswordChar = ""
        Else
            G2.PasswordChar = "●"
        End If
    End Sub


    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        meme.Show()
        Me.Hide()

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        admin_mod.Checked = False
        Me.Width = pl1.Width





    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Width = Me.Width + 10
        If Me.Width = 584 Then Timer1.Enabled = False

    End Sub

    Private Sub GunaLabel8_Click(sender As Object, e As EventArgs)
        pl2.Visible = False
        admin.Visible = True

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        'pl2.Hide()
        'admin.Visible = True
        'admin.Top = 0
        'admin.Left = 273

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        admin.Hide()
        'pl2.Visible = True
        pl2.Show()
        pl2.Top = 0
        pl2.Left = 273

    End Sub

    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        admin.Hide()

        edet.Show()
        edet.Top = 0
        edet.Left = 273
        edet.Width = 308
        edet.Height = 456
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        edet.Hide()
        pl2.Show()
        pl2.Top = 0
        pl2.Left = 273

    End Sub

    Private Sub GunaGradientButton6_Click(sender As Object, e As EventArgs) Handles GunaGradientButton6.Click
        con()
        tab = db.CreateCommand
        tab.CommandText = "INSERT INTO Mot_de_pass VALUES ( '" & uti3.Text & "' , '" & mdp3.Text & "') "
        tab.ExecuteNonQuery()
        db.Close()
        MsgBox("operation reussite")
        uti3.Text = ""
        mdp3.Text = ""

    End Sub

    Private Sub GunaGradientButton5_Click(sender As Object, e As EventArgs) Handles GunaGradientButton5.Click
        edet.Hide()

        ajoute.Show()
        ajoute.Top = 0
        ajoute.Left = 273
        ajoute.Width = 308
        ajoute.Height = 456
    End Sub

    Private Sub PS1_Click(sender As Object, e As EventArgs) Handles PS1.Click
        con()
        Dim tr As Boolean = False
        tab = db.CreateCommand
        tab.CommandText = "select * from Mot_de_pass where Utilisateur ='" & Tex1.Text & "'"

        enr = tab.ExecuteReader
        While enr.Read
            tr = True
            uti3 = enr(0)
            mdp3 = enr(1)
        End While

        If tr = False Then

            MsgBox("pas trouve")

        End If
        db.Close()



        db.Close()
        MsgBox("J'ai trouvé " & Tex1.Text)

    End Sub

    Private Sub GunaGradientButton7_Click(sender As Object, e As EventArgs) Handles GunaGradientButton7.Click
        con()
        Dim rep As String
        rep = MsgBox("Etes vous sur ?", MsgBoxStyle.YesNo, "Attention")
        If rep = vbYes Then
            tab = db.CreateCommand
            tab.CommandText = " update Mot_de_pass Set Utilisateur ='" & uti3.Text & "'  ,  Mot de passe = '" & mdp3.Text & "' ,  where Utilisateur = '" & Tex1.Text & "'"
            tab.ExecuteNonQuery()

            db.Close()

            MsgBox(" bien modifier")
        End If
        db.Close()


    End Sub

    Private Sub GunaGradientButton4_Click(sender As Object, e As EventArgs) Handles GunaGradientButton4.Click
        edet.Hide()

        modifier.Show()
        modifier.Top = 0
        modifier.Left = 273
        modifier.Width = 308
        modifier.Height = 456
    End Sub

    Private Sub GunaSwitch1_CheckedChanged(sender As Object, e As EventArgs) Handles admin_mod.CheckedChanged
        If admin_mod.Checked = True Then
            pl2.Hide()
            admin.Visible = True
            admin.Top = 0
            admin.Left = 273
        End If
    End Sub

    Private Sub admin_Paint(sender As Object, e As PaintEventArgs) Handles admin.Paint
        If admin_mod.Checked = True Then
            adminMod2.Checked = True
        End If
    End Sub

    Private Sub adminMod2_CheckedChanged(sender As Object, e As EventArgs) Handles adminMod2.CheckedChanged
        If adminMod2.Checked = False Then
            admin_mod.Checked = False
            admin.Hide()
            pl2.Show()
            pl2.Top = 0
            pl2.Left = 273

        End If
    End Sub

End Class
