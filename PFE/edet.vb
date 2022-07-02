Public Class edet

    Sub aff3()
        Dim c As String
        con()
        Dim tr As Boolean = False
        tab = db.CreateCommand
        tab.CommandText = "select nfon from fonction "

        enr = tab.ExecuteReader
        While enr.Read
            tr = True
            c = enr(0)
        End While

        If tr = False Then
            c = 1
        Else
            c = c + 1
        End If

        fen1.Text = c

        db.Close()

        con()
        tab = db.CreateCommand
        tab.CommandText = "select * from fonction"
        enr = tab.ExecuteReader

        While enr.Read
            DG3.Rows.Add(enr(0), enr(1))
        End While
        db.Close()

    End Sub
    Sub aff2()
        Dim c As String
        con()
        Dim tr As Boolean = False
        tab = db.CreateCommand
        tab.CommandText = "select nser from service "

        enr = tab.ExecuteReader
        While enr.Read
            tr = True
            c = enr(0)
        End While

        If tr = False Then
            c = 1
        Else
            c = c + 1
        End If

        ser1.Text = c

        db.Close()

        con()
        tab = db.CreateCommand
        tab.CommandText = "select * from service"
        enr = tab.ExecuteReader

        While enr.Read
            DG2.Rows.Add(enr(0), enr(1))
        End While
        db.Close()

    End Sub



    Sub aff1()
        Dim c As String
        con()
        Dim tr As Boolean = False
        tab = db.CreateCommand
        tab.CommandText = "select ndip from diplome "

        enr = tab.ExecuteReader
        While enr.Read
            tr = True
            c = enr(0)
        End While

        If tr = False Then
            c = 1
        Else
            c = c + 1
        End If

        dip1.Text = c

        db.Close()


        con()
        tab = db.CreateCommand
        tab.CommandText = "select * from diplome"
        enr = tab.ExecuteReader

        While enr.Read
            DG1.Rows.Add(enr(0), enr(1))
        End While
        db.Close()

    End Sub

    Private Sub GunaGradientButton6_Click(sender As Object, e As EventArgs) Handles GunaGradientButton6.Click

        '_______delete serv________
        con()
        tab = db.CreateCommand
        tab.CommandText = "delete * from  service  where nser='" & Tex1.Text & "'"
        tab.ExecuteNonQuery()

        db.Close()
        MsgBox("sup")
        ''-------------------------
        DG2.Rows.Clear()
        aff2()




    End Sub

    Private Sub GunaGradientButton5_Click(sender As Object, e As EventArgs) Handles GunaGradientButton5.Click
        '____________________delte fon______________

        con()
        tab = db.CreateCommand
        tab.CommandText = "delete * from fonction where nfon='" & tex2.Text & "'"
        tab.ExecuteNonQuery()

        db.Close()

        ''-------------------------
        DG3.Rows.Clear()
        aff3()





    End Sub

    Private Sub PS1_Click(sender As Object, e As EventArgs) Handles PS1.Click
        '-----------------------servبحت
        con()
        Dim tr As Boolean = False
        tab = db.CreateCommand
        tab.CommandText = "select * from service where nser='" & Tex1.Text & "'"

        enr = tab.ExecuteReader
        While enr.Read
            tr = True
            MsgBox("J'ai trouvé ")
            ser1.Text = enr(0)
            ser2.Text = enr(1)

        End While

        If tr = False Then
            MsgBox("pas trouve")
        End If
        db.Close()
    End Sub

    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click
        '------------------اضافة serve
        con()
        tab = db.CreateCommand
        tab.CommandText = "insert into service values('" & ser1.Text & "' , '" & ser2.Text & "')"
        tab.ExecuteNonQuery()
        db.Close()


        ''-------------------------
        DG2.Rows.Clear()
        aff2()




        ser1.Text = ""
        ser2.Text = ""
    End Sub

    Private Sub G1_Click(sender As Object, e As EventArgs) Handles G1.Click
        '___________________rech fen
        con()
        Dim tr As Boolean = False
        tab = db.CreateCommand
        tab.CommandText = "select * from fonction where nfon='" & tex2.Text & "'"

        enr = tab.ExecuteReader
        While enr.Read
            tr = True
            MsgBox("J'ai trouvé ")
            fen1.Text = enr(0)
            fen2.Text = enr(1)

        End While

        If tr = False Then
            MsgBox("pas trouve")
        End If
        db.Close()
    End Sub

    Private Sub GunaGradientButton10_Click(sender As Object, e As EventArgs) Handles GunaGradientButton10.Click
        '------------------اضافة fen
        con()
        tab = db.CreateCommand
        tab.CommandText = "insert into  fonction  values('" & fen1.Text & "' , '" & fen2.Text & "')"
        tab.ExecuteNonQuery()
        db.Close()


        ''-------------------------
        DG3.Rows.Clear()
        aff3()

        fen1.Text = ""
        fen2.Text = ""

    End Sub

    Private Sub edet_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

        aff1()
        aff2()
        aff3()

    End Sub

    Private Sub GunaGradientButton8_Click(sender As Object, e As EventArgs) Handles GunaGradientButton8.Click
        con()
        tab = db.CreateCommand
        tab.CommandText = "insert into  diplome  values('" & dip1.Text & "' , '" & dip2.Text & "')"
        tab.ExecuteNonQuery()
        db.Close()


        ''-------------------------
        DG1.Rows.Clear()
        aff1()

        dip1.Text = ""
        dip2.Text = ""

    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        '___________________rech dip
        con()
        Dim tr As Boolean = False
        tab = db.CreateCommand
        tab.CommandText = "select * from diplome where ndip='" & tex3.Text & "'"
        enr = tab.ExecuteReader
        While enr.Read
            tr = True
            MsgBox("J'ai trouvé ")
            dip1.Text = enr(0)
            dip2.Text = enr(1)

        End While

        If tr = False Then
            MsgBox("pas trouve")
        End If
        db.Close()
    End Sub

    Private Sub GunaGradientButton13_Click(sender As Object, e As EventArgs) Handles GunaGradientButton13.Click
        '____________________delte dip______________

        con()
        tab = db.CreateCommand
        tab.CommandText = "delete * from  diplome where ndip='" & tex2.Text & "'"
        tab.ExecuteNonQuery()

        db.Close()

        ''-------------------------
        DG1.Rows.Clear()
        aff1()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class