Imports System.Data.OleDb
Imports System.Media
Public Class E_et_S
    Dim z As Integer
    Dim k As String
    Dim m As String

    Sub aff()

        lid.Text = ""
        Lnom.Text = ""
        Lprenom.Text = ""

        con()
        tab = db.CreateCommand
        tab.CommandText = "select * from d "
        enr = tab.ExecuteReader
        While enr.Read
            DG.Rows.Add(enr(3), enr(4), enr(5), enr(6))
            lid.Text = enr(0)
            Lnom.Text = enr(1)
            Lprenom.Text = enr(2)
        End While
        db.Close()
    End Sub

    Private Sub SER_CheckedChanged(sender As Object, e As EventArgs) Handles SER.CheckedChanged
        If SER.Checked = True Then
            ENT.Checked = False
            VALI.Text = ""
            VALI.Select()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        '___________aout___________

        Dim se As New SoundPlayer("ent.wav")
        Dim ss As New SoundPlayer("11.wav")
        Dim time As String
        Dim dat As String
        time = TimeOfDay
        dat = DateString


        con()
        tab = db.CreateCommand
        Dim tr As Boolean = False
        tab = db.CreateCommand
        tab.CommandText = "select max(num_pres) from presence"

        enr = tab.ExecuteReader
        While enr.Read
            tr = True
            z = enr(0)
        End While

        If tr = False Then
            z = 1
        End If
        z = z + 1

        n.Text = z

        db.Close()

        con()
        tab = db.CreateCommand


        If ENT.Checked = True Then

            tab.CommandText = "INSERT INTO presence( num_pres, ID, jour, entre)values( @num_pres, @ID, @jour, @entre)"
            tab.Parameters.Add("@num_pres", OleDbType.VarChar).Value = n.Text
            tab.Parameters.Add("@ID", OleDbType.VarChar).Value = VALI.Text
            tab.Parameters.Add("@jour", OleDbType.VarChar).Value = dat
            tab.Parameters.Add("@entre", OleDbType.VarChar).Value = time
            se.Play()
            tab.ExecuteNonQuery()

        End If

        If SER.Checked = True Then
            'tab = db.CreateCommand
            'tab.CommandText = " update  presence Set  sortir = '" & time & "' where num_pres='" & k & "'"
            'tab.ExecuteNonQuery
            'ss.Play()
            ''''''''''''''''''''''''''
            Dim startTime As DateTime
            Dim endTime As DateTime


            tab = db.CreateCommand
            tab.CommandText = " update  presence Set  sortir = '" & time & "' where num_pres='" & k & "'"
            tab.ExecuteNonQuery()

            tab = db.CreateCommand
            tab.CommandText = "select entre,sortir from presence where num_pres ='" & k & "'"
            enr = tab.ExecuteReader

            While enr.Read

                startTime = enr(0)
                endTime = enr(1)
            End While
            Dim duration As TimeSpan = endTime - startTime
            Console.WriteLine(duration)

            tab = db.CreateCommand
            tab.CommandText = " update  presence Set  ht= '" & duration.Hours & ":" & duration.Minutes & "' where num_pres='" & k & "'"
            tab.ExecuteNonQuery()
            ss.Play()
        End If

        db.Close()
        VALI.Text = ""
        n.Text = ""

    End Sub

    Private Sub VALI_TextChanged(sender As Object, e As EventArgs) Handles VALI.TextChanged

        If Not VALI.Text = "" Then
            Button1.Select()
            Button1.PerformClick()
            VALI.Select()
        End If
    End Sub

    Private Sub VALI_LostFocus(sender As Object, e As EventArgs) Handles VALI.LostFocus
        con()
        tab = db.CreateCommand
        Dim tr As Boolean = False
        tab = db.CreateCommand
        tab.CommandText = "select * from presence where ID='" & VALI.Text & "'"

        enr = tab.ExecuteReader
        While enr.Read
            tr = True
            k = enr(0)
        End While
        db.Close()
    End Sub


    Private Sub pic2_Click(sender As Object, e As EventArgs) Handles pic2.Click
        '_______________man______________


        Dim monthe As String
        Dim time As String
        Dim dat As String



        time = TimeOfDay
        'dat = DateString
        'Console.WriteLine("Hello world")
        'Console.WriteLine(dat)
        ''Console.WriteLine(dat.())
        'monthe = dat.Split("-")
        ''time = Date.Now.ToString("HH-mm")
        dat = Date.Now.Day

        con()
        Dim tr As Boolean = False
        tab = db.CreateCommand
        tab.CommandText = "select num_pres from presence"

        enr = tab.ExecuteReader
        While enr.Read
            tr = True
            z = enr(0)
        End While

        If tr = False Then
            z = 1
        Else
            z = z + 1
        End If

        inf1.Text = z
        db.Close()





        con()
        tab = db.CreateCommand
        If ent2.Checked = True Then
            tab.CommandText = "INSERT INTO presence( num_pres, ID, jour, entre)values( @num_pres, @ID, @jour, @entre)"
            tab.Parameters.Add("@num_pres", OleDbType.VarChar).Value = inf1.Text
            tab.Parameters.Add("@ID", OleDbType.VarChar).Value = inf2.Text
            tab.Parameters.Add("@jour", OleDbType.VarChar).Value = dat
            tab.Parameters.Add("@entre", OleDbType.VarChar).Value = time
            tab.ExecuteNonQuery()

            tab = db.CreateCommand
            tab.CommandText = "select * from d where ID='" & inf2.Text & "'"
            enr = tab.ExecuteReader
            db.Close()
            MsgBox("operation reussite")
        End If
        DG.Rows.Clear()
        'aff()


        If ser2.Checked = True Then
            Dim startTime As DateTime
            Dim endTime As DateTime


            tab = db.CreateCommand
            tab.CommandText = " update  presence Set  sortir = '" & time & "' where num_pres='" & m & "'"
            tab.ExecuteNonQuery()

            tab = db.CreateCommand
            tab.CommandText = "select entre,sortir from presence where num_pres ='" & m & "'"
            enr = tab.ExecuteReader

            While enr.Read

                startTime = enr(0)
                endTime = enr(1)
            End While
            Dim duration As TimeSpan = endTime - startTime
            Console.WriteLine(duration)

            tab = db.CreateCommand
            tab.CommandText = " update  presence Set  ht= '" & duration.Hours & "," & duration.Minutes & "' where num_pres='" & m & "'"
            tab.ExecuteNonQuery()

            tab = db.CreateCommand
            tab.CommandText = "select * from d where ID='" & inf2.Text & "'"
            enr = tab.ExecuteReader
            db.Close()

            DG.Rows.Clear()
            MsgBox("operation reussite")
        End If
        'aff()
        inf1.Text = ""
        inf2.Text = ""


    End Sub

    Private Sub man_CheckedChanged(sender As Object, e As EventArgs) Handles man.CheckedChanged
        If man.Checked = True Then
            aout.Checked = False
            Panel2.Visible = True
        End If
        If man.Checked = False Then
            Panel2.Visible = False
        End If

    End Sub


    Private Sub inf2_LostFocus(sender As Object, e As EventArgs) Handles inf2.LostFocus
        con()
        tab = db.CreateCommand
        Dim tr As Boolean = False
        tab = db.CreateCommand
        tab.CommandText = "select * from presence where ID='" & inf2.Text & "'"

        enr = tab.ExecuteReader
        While enr.Read
            tr = True
            m = enr(0)
        End While
        db.Close()

    End Sub

    Private Sub ent2_CheckedChanged(sender As Object, e As EventArgs) Handles ent2.CheckedChanged
        If ent2.Checked = True Then
            ser2.Checked = False
        End If
    End Sub

    Private Sub ser2_CheckedChanged(sender As Object, e As EventArgs) Handles ser2.CheckedChanged
        If ser2.Checked = True Then
            ent2.Checked = False
        End If
    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs)
        con()
        tab = db.CreateCommand
        tab.CommandText = "select * from d where ID='" & inf2.Text & "'"
        enr = tab.ExecuteReader

        While enr.Read
            DG.Rows.Add(enr(3), enr(4), enr(5), enr(6))
            lid.Text = enr(0)
            Lnom.Text = enr(1)
            Lprenom.Text = enr(2)
        End While
        db.Close()
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim n = DateTime.Now
        Dim s = DateTime.Today.AddHours(18).AddMinutes(54)
        Dim st = DateTime.Today.AddHours(18).AddMinutes(55)
        If aout.Checked = True Then
            If n >= s Then
                ENT.Checked = True
                SER.Checked = False
            End If
            If n >= st Then
                SER.Checked = True
                ENT.Checked = False
            End If
        End If
    End Sub

    Private Sub ENT_CheckedChanged(sender As Object, e As EventArgs) Handles ENT.CheckedChanged
        If ENT.Checked = True Then
            SER.Checked = False
            VALI.Text = ""
            VALI.Select()
        End If

    End Sub

    Private Sub GunaGradientButton13_Click(sender As Object, e As EventArgs) Handles GunaGradientButton13.Click
        Me.Close()
    End Sub

    Private Sub E_et_S_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'aff()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class