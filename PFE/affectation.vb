Imports System.Data.OleDb
Public Class affectation
    Dim Nfonction As String
    Dim Ndiplome As String
    Dim Nservice As String
    '______________________

    Private conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\BD.accdb")
    Dim dr As OleDbDataReader
    Public da As New OleDbDataAdapter
    Public dt As New DataTable
    Sub conbox()

        conn.Open()
        CONTRAT.Items.Clear()
        Dim cmd As New OleDbCommand
        cmd.CommandText = "select * from contrat "
        cmd.Connection = conn
        dr = cmd.ExecuteReader
        While dr.Read
            CONTRAT.Items.Add(dr.GetString(1))
        End While
        conn.Close()
    End Sub

    Sub servbox()

        conn.Open()
        SER.Items.Clear()
        Dim cmd As New OleDbCommand
        cmd.CommandText = "select * from service "
        cmd.Connection = conn
        dr = cmd.ExecuteReader
        While dr.Read
            SER.Items.Add(dr.GetString(1))
        End While
        conn.Close()
    End Sub
    Sub fonbox()

        conn.Open()
        FON.Items.Clear()
        Dim cmd As New OleDbCommand
        cmd.CommandText = "select * from fonction "
        cmd.Connection = conn
        dr = cmd.ExecuteReader
        While dr.Read
            FON.Items.Add(dr.GetString(1))
        End While
        conn.Close()
    End Sub
    Sub dipbox()
        conn.Open()
        DIP.Items.Clear()
        Dim cmd As New OleDbCommand
        cmd.CommandText = "select * from diplome "
        cmd.Connection = conn
        dr = cmd.ExecuteReader
        While dr.Read
            DIP.Items.Add(dr.GetString(1))
        End While
        conn.Close()
    End Sub



    Private Sub pic2_Click(sender As Object, e As EventArgs) Handles pic2.Click

        con()
        Dim tr As Boolean = False
        tab = db.CreateCommand
        tab.CommandText = "select ID,CIN,Nom,Pre_nom from Employe where ID ='" & tex.Text & "'"

        enr = tab.ExecuteReader
        While enr.Read
            tr = True

            inf1.Text = enr(0)
            inf2.Text = enr(1)
            inf3.Text = enr(2)
            inf4.Text = enr(3)


        End While

        If tr = False Then

            MsgBox("pas trouve")

        End If
        db.Close()

        con()
        Dim Nserv As String
        Dim serv As String

        tab.CommandText = "select  * from ser_historique where id ='" & tex.Text & "'"
        enr = tab.ExecuteReader
        enr.Read()
        Nserv = enr(0)
        db.Close()

        con()
        tab.CommandText = "select * from service where nser ='" & Nserv & "'"
        enr = tab.ExecuteReader
        enr.Read()
        serv = enr(1)
        inf6.Text = serv
        db.Close()

        con()

        Dim Nfon As String
        Dim fon As String

        tab.CommandText = "select  * from fon_historique where id ='" & tex.Text & "'"
        enr = tab.ExecuteReader
        enr.Read()
        Nfon = enr(0)
        db.Close()

        con()
        tab.CommandText = "select * from fonction where nfon ='" & Nfon & "'"
        enr = tab.ExecuteReader
        enr.Read()
        fon = enr(1)
        inf7.Text = fon
        db.Close()

        con()

        Dim Ndip As String
        Dim dip As String

        tab.CommandText = "select  * from dip_historique where id ='" & tex.Text & "'"
        enr = tab.ExecuteReader
        enr.Read()
        Ndip = enr(0)
        db.Close()

        con()
        tab.CommandText = "select * from diplome  where ndip ='" & Ndip & "'"
        enr = tab.ExecuteReader
        enr.Read()
        dip = enr(1)
        inf8.Text = dip
        db.Close()








        '_________________photo rech
        ph.Image = Nothing


        Dim ArrImage() As Byte
        Dim MS As New IO.MemoryStream
        Dim da As New OleDbDataAdapter("select photo FROM employe WHERE  ID='" & tex.Text & "'", conn)
        Dim dt As New DataTable
        da.Fill(dt)

        If dt.Rows.Count > 0 Then
            If Not IsDBNull(dt.Rows(0).Item("photo")) Then
                ArrImage = dt.Rows(0).Item("photo")
                For Each a As Byte In ArrImage
                    MS.WriteByte(a)
                Next
                ph.Image = System.Drawing.Image.FromStream(MS)
            End If
        End If
        db.Close()
        GB.Visible = True
        GB2.Visible = False
        MsgBox("J'ai trouvé " & tex.Text)

    End Sub

    Private Sub p1_Click(sender As Object, e As EventArgs) Handles p1.Click
        PL.Top = 7
        PL.Left = 126
        p2.Top = 14
        p2.Left = 376
        PL.Visible = True
        hs.Visible = True
        hs.Visible = False
    End Sub

    Private Sub affectation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dipbox()
        fonbox()
        servbox()
        conbox()
    End Sub

    Private Sub GunaGradientButton9_Click(sender As Object, e As EventArgs) Handles GunaGradientButton9.Click
        con()
        tab = db.CreateCommand
        tab.CommandText = "INSERT INTO ser_historique VALUES ( '" & Nservice & "' , '" & inf1.Text & "' , '" & Date.Now & "') "
        tab.ExecuteNonQuery()
        db.Close()
        MsgBox("operation reussite")

    End Sub

    Private Sub GunaGradientButton11_Click(sender As Object, e As EventArgs) Handles GunaGradientButton11.Click
        con()
        tab = db.CreateCommand
        tab.CommandText = "INSERT INTO fon_historique VALUES ( '" & Nfonction & "' , '" & inf1.Text & "' , '" & Date.Now & "') "
        tab.ExecuteNonQuery()
        db.Close()
        MsgBox("operation reussite")
    End Sub

    Private Sub GunaGradientButton13_Click(sender As Object, e As EventArgs) Handles GunaGradientButton13.Click
        con()
        tab = db.CreateCommand
        tab.CommandText = "INSERT INTO dip_historique VALUES ( '" & Ndiplome & "' , '" & inf1.Text & "' , '" & Date.Now & "') "
        tab.ExecuteNonQuery()
        db.Close()
        MsgBox("operation reussite")
    End Sub

    Private Sub p2_Click(sender As Object, e As EventArgs) Handles p2.Click
        PL.Top = 7
        PL.Left = 248
        p2.Top = 12
        p2.Left = 130
        PL.Visible = True
        hs.Visible = False
        hs.Visible = True
    End Sub

    Private Sub SERVECE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SER.SelectedIndexChanged
        con()
        Dim service As String
        service = SER.Text
        tab.CommandText = "select  * from service where service ='" & service & "'"
        enr = tab.ExecuteReader
        enr.Read()
        Nservice = enr(0)
        db.Close()

    End Sub

    Private Sub FONCTION_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FON.SelectedIndexChanged
        con()
        Dim fonction As String
        fonction = FON.Text
        tab.CommandText = "select  * from fonction where fonction ='" & fonction & "'"
        enr = tab.ExecuteReader
        enr.Read()
        Nfonction = enr(0)
        db.Close()
    End Sub

    Private Sub DIP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DIP.SelectedIndexChanged
        con()
        Dim diplome As String
        diplome = DIP.Text
        tab.CommandText = "select  * from diplome where diplome ='" & diplome & "'"
        enr = tab.ExecuteReader
        enr.Read()
        Ndiplome = enr(0)
        db.Close()

    End Sub

    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs) Handles hs.Click

        con()
        Dim tr As Boolean = False
        tab = db.CreateCommand
        tab.CommandText = "select ID,CIN,Nom,Pre_nom from Employe where ID ='" & tex.Text & "'"

        enr = tab.ExecuteReader
        While enr.Read
            tr = True

            HS1.Text = enr(0)
            HS2.Text = enr(1)
            HS3.Text = enr(2)
            HS4.Text = enr(3)


        End While

        If tr = False Then

            MsgBox("pas trouve")

        End If
        db.Close()



        DG.Rows.Clear()
        DG2.Rows.Clear()
        DG3.Rows.Clear()

        con()
        tab = db.CreateCommand
        tab.CommandText = "select  * from ser_ where id ='" & HS1.Text & "'"
        enr = tab.ExecuteReader
        While enr.Read()

            DG.Rows.Add(enr(1), enr(2))
        End While
        db.Close()





        con()
        tab = db.CreateCommand
        tab.CommandText = "select  * from fon_ where id ='" & HS1.Text & "'"
        enr = tab.ExecuteReader
        While enr.Read()

            DG2.Rows.Add(enr(1), enr(2))
        End While
        db.Close()


        con()
        tab = db.CreateCommand
        tab.CommandText = "select  * from dip_ where id ='" & HS1.Text & "'"
        enr = tab.ExecuteReader
        While enr.Read()
            DG3.Rows.Add(enr(1), enr(2))
        End While
        db.Close()




        '_________________photo rech
        ph.Image = Nothing


        Dim ArrImage() As Byte
        Dim MS As New IO.MemoryStream
        Dim da As New OleDbDataAdapter("select photo FROM employe WHERE  ID='" & tex.Text & "'", conn)
        Dim dt As New DataTable
        da.Fill(dt)

        If dt.Rows.Count > 0 Then
            If Not IsDBNull(dt.Rows(0).Item("photo")) Then
                ArrImage = dt.Rows(0).Item("photo")
                For Each a As Byte In ArrImage
                    MS.WriteByte(a)
                Next
                ph2.Image = System.Drawing.Image.FromStream(MS)
            End If
        End If
        db.Close()
        GB.Visible = False
        GB2.Visible = True
        MsgBox("J'ai trouvé " & tex.Text)


    End Sub

    Private Sub pic3_Click(sender As Object, e As EventArgs) Handles pic3.Click

    End Sub

    Private Sub add_ph_Click(sender As Object, e As EventArgs) Handles add_ph.Click
        Panel2.Visible = True
    End Sub

    Private Sub GunaGradientButton4_Click(sender As Object, e As EventArgs) Handles GunaGradientButton4.Click
        Panel3.Visible = True
    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Panel4.Visible = True
    End Sub

    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        Panel5.Visible = True
    End Sub

    Private Sub GunaGradientButton6_Click(sender As Object, e As EventArgs) Handles GunaGradientButton6.Click
        Panel2.Visible = False
    End Sub

    Private Sub GunaGradientButton8_Click(sender As Object, e As EventArgs) Handles GunaGradientButton8.Click
        Panel3.Visible = False
    End Sub

    Private Sub GunaGradientButton10_Click(sender As Object, e As EventArgs) Handles GunaGradientButton10.Click
        Panel4.Visible = False
    End Sub

    Private Sub GunaGradientButton12_Click(sender As Object, e As EventArgs) Handles GunaGradientButton12.Click
        Panel4.Visible = False
    End Sub
End Class