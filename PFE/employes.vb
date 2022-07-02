Imports System.Data.OleDb
Imports System.IO
Imports QRCoder

Public Class employes
    Dim z As Integer
    Dim Nfonction As String
    Dim Ndiplome As String
    Dim Nservice As String
    '__________________________




    Private conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\BD.accdb")
    Dim dr As OleDbDataReader
    Public da As New OleDbDataAdapter
    Public dt As New DataTable





    Sub servbox()

        conn.Open()
        inf12.Items.Clear()
        Dim cmd As New OleDbCommand
        cmd.CommandText = "select * from service "
        cmd.Connection = conn
        dr = cmd.ExecuteReader
        While dr.Read
            inf12.Items.Add(dr.GetString(1))

        End While
        conn.Close()



    End Sub
    Sub fenbox()

        conn.Open()
        inf13.Items.Clear()
        Dim cmd As New OleDbCommand
        cmd.CommandText = "select * from fonction "
        cmd.Connection = conn
        dr = cmd.ExecuteReader
        While dr.Read
            inf13.Items.Add(dr.GetString(1))

        End While
        conn.Close()



    End Sub

    Sub dipbox()

        conn.Open()
        inf14.Items.Clear()
        Dim cmd As New OleDbCommand
        cmd.CommandText = "select * from diplome  "
        cmd.Connection = conn
        dr = cmd.ExecuteReader
        While dr.Read
            inf14.Items.Add(dr.GetString(1))

        End While
        conn.Close()



    End Sub
    Sub aff()

        'con()
        'tab = db.CreateCommand
        'tab.CommandText = "select * from enr"
        'enr = tab.ExecuteReader

        'While enr.Read
        '    DG.Rows.Add(enr(0), enr(1), enr(2), enr(3), enr(4), enr(5), enr(6), enr(7), enr(8), enr(9), enr(10), enr(11), enr(12))
        'End While
        'db.Close()






    End Sub

    Private Sub valider2_Click(sender As Object, e As EventArgs)
        '----------------------------تعديل

        'con()
        'tab = db.CreateCommand
        'tab.CommandText = " update Employe Set cin ='" & inf2.Text & "'  ,  Nom = '" & inf3.Text & "' , pre_nom = '" & inf4.Text & "' , Aderesse  = '" & inf5.Text & "' , Sexe = '" & inf6.Text & "' , Date_naissance =  '" & inf7.Text & "' , Etat_civile = '" & inf8.Text & "' , Email = '" & inf9.Text & "' , Num_tele = '" & inf10.Text & "' , contrat = '" & inf11.Text & "' , service  = '" & inf12.Text & "' , fonction = '" & inf13.Text & "' , diplom = '" & inf14.Text & "' where ID = '" & tex.Text & "'"
        'tab.ExecuteNonQuery()

        'db.Close()
        ''----------------------------------------
        'DG.Rows.Clear()
        'aff()


    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        '-----------------------بحت
        'P5.Left = 559
        'P5.Top = 550

        'con()
        'Dim tr As Boolean = False
        'tab = db.CreateCommand
        'tab.CommandText = "select * from Employe where ID ='" & tex.Text & "'"

        'enr = tab.ExecuteReader
        'While enr.Read
        '    tr = True

        '    GB.Visible = True
        '    GB.Enabled = False
        '    P2.Visible = True
        '    P3.Visible = True
        '    P5.Visible = True
        '    valider1.Visible = False



        '    inf1.Text = enr(0)
        '    inf2.Text = enr(1)
        '    inf3.Text = enr(2)
        '    inf4.Text = enr(3)
        '    inf5.Text = enr(4)
        '    inf6.Text = enr(5)
        '    inf7.Text = enr(6)
        '    inf8.Text = enr(7)
        '    inf9.Text = enr(8)
        '    inf10.Text = enr(9)
        '    inf11.Text = enr(10)
        '    inf12.Text = enr(11)
        '    inf13.Text = enr(12)
        '    inf14.Text = enr(13)
        '    MsgBox("J'ai trouvé " & tex.Text)
        'End While

        'If tr = False Then
        '    P2.Visible = False
        '    P3.Visible = False
        '    P5.Visible = False
        '    GB.Visible = False
        '    MsgBox("pas trouve")
        'End If
        'db.Close()
    End Sub

    Private Sub P1_Click(sender As Object, e As EventArgs)
        '____________زر الاضافة 
        GB.Enabled = True
        GB.Visible = True
        valider1.Visible = True
        P5.Visible = True
        P5.Left = 559
        P5.Top = 476
    End Sub
    Private Sub employes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '___________
        servbox()
        '__________
        fenbox()
        '___________
        aff()
        '__________
        dipbox()
        '__________

    End Sub



    Private Sub p4_Click(sender As Object, e As EventArgs)
        '______________زر البحت 


        pic2.Visible = True
        pic3.Visible = True
        tex.Visible = True

    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs)
        '----------------زر الرجوع 1

        pic2.Visible = False
        pic3.Visible = False
        tex.Visible = False
    End Sub


    Private Sub GunaGradientButton4_Click(sender As Object, e As EventArgs) Handles p1.Click
        '____________زر الاضافة 
        con()
        Dim tr As Boolean = False
        tab = db.CreateCommand
        tab.CommandText = "select ID from  Employe "

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



        GB.Enabled = True
        GB.Visible = True
        valider1.Visible = True
        P5.Visible = True

        P5.Left = 565
        P5.Top = 308

    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        '______________زر البحت 


        pic2.Visible = True
        pic3.Visible = True
        tex.Visible = True
        tex.Select()


    End Sub

    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles pic2.Click



        ''-----------------------بحت
        P5.Left = 565
        P5.Top = 380

        GB.Text = "EMPLOYES"




        con()
        Dim tr As Boolean = False
        tab = db.CreateCommand
        tab.CommandText = "select * from Employe where ID ='" & tex.Text & "'"

        enr = tab.ExecuteReader
        While enr.Read
            tr = True

            GB.Visible = True
            GB.Enabled = False
            P2.Visible = True
            P3.Visible = True
            P5.Visible = True
            valider1.Visible = False
            valider2.Visible = False



            inf1.Text = enr(0)
            inf2.Text = enr(1)
            inf3.Text = enr(2)
            inf4.Text = enr(3)
            inf5.Text = enr(4)
            inf6.Text = enr(5)
            inf7.Text = enr(6)
            inf8.Text = enr(7)
            inf9.Text = enr(8)
            inf10.Text = enr(9)


        End While

        If tr = False Then
            P2.Visible = False
            P3.Visible = False
            P5.Visible = False
            GB.Visible = False
            MsgBox("pas trouve")

        End If
        db.Close()


        con()
        Dim Nserv As String
        Dim serv As String

        tab = db.CreateCommand
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

        db.Close()
        inf12.Text = serv

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
        db.Close()
        inf13.Text = fon

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
        db.Close()
        inf14.Text = dip

        '_________________photo rech
        ph.Image = Nothing


        Dim conn As New OleDbConnection
        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\BD.accdb"

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
        conn.Close()
        MsgBox("J'ai trouvé " & tex.Text)
    End Sub

    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs) Handles pic3.Click
        '----------------زر الرجوع 1
        pic2.Visible = False
        pic3.Visible = False
        tex.Visible = False
        tex.Text = ""
    End Sub

    Private Sub GunaGradientButton2_Click_1(sender As Object, e As EventArgs) Handles valider2.Click
        ''----------------------------تعديل
        con()
        Dim rep As String
        rep = MsgBox("Etes vous sur ?", MsgBoxStyle.YesNo, "Attention")
        If rep = vbYes Then
            tab = db.CreateCommand
            tab.CommandText = " update Employe Set cin ='" & inf2.Text & "'  ,  Nom = '" & inf3.Text & "' , pre_nom = '" & inf4.Text & "' , Aderesse  = '" & inf5.Text & "' , Sexe = '" & inf6.Text & "' , Date_naissance =  '" & inf7.Text & "' , Etat_civile = '" & inf8.Text & "' , Email = '" & inf9.Text & "' , Num_tele = '" & inf10.Text & "' where ID = '" & tex.Text & "'"
            tab.ExecuteNonQuery()

            tab = db.CreateCommand
            tab.CommandText = " update ser_historique Set nser ='" & Nservice & "'  where ID = '" & tex.Text & "'"
            tab.ExecuteNonQuery()

            tab = db.CreateCommand
            tab.CommandText = " update fon_historique Set nfon ='" & Nfonction & "'  where ID = '" & tex.Text & "'"
            tab.ExecuteNonQuery()

            tab = db.CreateCommand
            tab.CommandText = " update dip_historique Set ndip ='" & Ndiplome & "'  where ID = '" & tex.Text & "'"
            tab.ExecuteNonQuery()
            db.Close()

            MsgBox("client bien modifier")
        End If
        db.Close()

        '----------------------------------------
        DG.Rows.Clear()
        aff()

    End Sub

    Private Sub GunaGradientButton7_Click(sender As Object, e As EventArgs) Handles valider1.Click
        Dim c As String
        con()
        Dim tr As Boolean = False
        tab = db.CreateCommand
        tab.CommandText = "select idc from  contrat "

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

        con1.Text = c

        db.Close()



        con2.Text = inf1.Text
        con3.Text = inf2.Text

        CONT.Visible = True


    End Sub


    Private Sub GunaGradientButton4_Click_1(sender As Object, e As EventArgs) Handles P2.Click
        '-------------------------زر التعديل 
        GB.Text = "MODIFIER LES INFORMATIONS SUR LES EMPLOYES"
        'P8.Visible = True
        GB.Enabled = True
        valider2.Visible = True
        valider1.Visible = False

    End Sub

    Private Sub GunaGradientButton6_Click(sender As Object, e As EventArgs) Handles P3.Click
        '__________________________مسح

        con()
        Dim rep As String
        rep = MsgBox("Etes vous sur ?", MsgBoxStyle.YesNo, "Attention")
        If rep = vbYes Then

            tab = db.CreateCommand
            tab.CommandText = "delete * from  Employe where ID='" & inf1.Text & "'"
            tab.ExecuteNonQuery()

            MsgBox("client bien supprime")
            tex.Text = ""
            inf1.Text = ""
            inf2.Text = ""
            inf3.Text = ""
            inf4.Text = ""
            inf5.Text = ""
            inf6.Text = ""
            inf7.Text = ""
            inf8.Text = ""
            inf9.Text = ""
            inf10.Text = ""
            inf11.Text = ""
            inf12.Text = ""
            inf13.Text = ""
            inf14.Text = ""
        End If
        db.Close()


        '-----------------------------------
        DG.Rows.Clear()
        aff()

    End Sub

    Private Sub GunaGradientButton5_Click(sender As Object, e As EventArgs) Handles P5.Click
        '--------------زر الرجوع 
        tex.Text = ""
        inf1.Text = ""
        inf2.Text = ""
        inf3.Text = ""
        inf4.Text = ""
        inf5.Text = ""
        inf6.Text = ""
        inf7.Text = ""
        inf8.Text = ""
        inf9.Text = ""
        inf10.Text = ""
        inf11.Text = ""
        inf12.Text = ""
        inf13.Text = ""
        inf14.Text = ""

        P2.Visible = False
        P3.Visible = False
        P5.Visible = False
        GB.Visible = False

    End Sub


    Private Sub add_ph_Click(sender As Object, e As EventArgs) Handles add_ph.Click
        '____________________felter_______________________
        OpenFileDialog1.Filter = "image formats (*.PNG;*.JPG;*.BMP) | *.PNG;*.JPG;*.BMP  | all fles (*.*) | *.*"
        With OpenFileDialog1
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                ph.Image = Image.FromFile(.FileName)
            Else
                Return
            End If
        End With
    End Sub
    Private Sub P8_Click(sender As Object, e As EventArgs)
        tex.Text = ""
        inf1.Text = ""
        inf2.Text = ""
        inf3.Text = ""
        inf4.Text = ""
        inf5.Text = ""
        inf6.Text = ""
        inf7.Text = ""
        inf8.Text = ""
        inf9.Text = ""
        inf10.Text = ""
        inf11.Text = ""
        inf12.Text = ""
        inf13.Text = ""
        inf14.Text = ""

    End Sub



    Private Sub GunaGradientButton13_Click_1(sender As Object, e As EventArgs) Handles GunaGradientButton13.Click
        Me.Close()
    End Sub


    Private Sub inf12_SelectedIndexChanged(sender As Object, e As EventArgs) Handles inf12.SelectedIndexChanged
        Dim service As String
        service = inf12.Text
        con()
        tab.CommandText = "select  * from service where service ='" & service & "'"
        enr = tab.ExecuteReader
        enr.Read()
        Nservice = enr(0)
        db.Close()

    End Sub

    Private Sub inf13_SelectedIndexChanged(sender As Object, e As EventArgs) Handles inf13.SelectedIndexChanged
        Dim fonction As String
        fonction = inf13.Text
        con()

        tab.CommandText = "select  * from fonction where fonction ='" & fonction & "'"
        enr = tab.ExecuteReader
        enr.Read()
        Nfonction = enr(0)
        db.Close()

    End Sub

    Private Sub inf14_SelectedIndexChanged(sender As Object, e As EventArgs) Handles inf14.SelectedIndexChanged
        Dim diplome As String
        diplome = inf14.Text
        con()

        tab.CommandText = "select  * from diplome where diplome ='" & diplome & "'"
        enr = tab.ExecuteReader
        enr.Read()
        Ndiplome = enr(0)
        db.Close()

    End Sub


    Private Sub GunaGradientButton3_Click_1(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click

        '______________QR__________________
        Dim gen As New QRCodeGenerator
        Dim data = gen.CreateQrCode(inf1.Text, QRCodeGenerator.ECCLevel.Q)
        Dim code As New QRCode(data)
        qr.Image = code.GetGraphic(6)
        '_______________sv______________
        Dim SD As New SaveFileDialog
        SD.FileName = inf1.Text
        SD.Filter = "PNG Files Only(*.png)|*.png"
        If SD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                qr.Image.Save(SD.FileName, System.Drawing.Imaging.ImageFormat.Png)
            Catch ex As Exception
            End Try
        End If
        ''-----------------اضافة
        Dim arrImage() As Byte
        Dim NmImage As String
        Dim myMs As New IO.MemoryStream
        Dim myM As New IO.MemoryStream

        If Not IsNothing(ph.Image) Then
            ph.Image.Save(myMs, ph.Image.RawFormat)
            arrImage = myMs.GetBuffer
            NmImage = "?"
        Else
            arrImage = Nothing
            NmImage = "NULL"
        End If

        conn.Open()
        Dim cmd As New OleDbCommand
        cmd.Connection = conn

        If NmImage = "?" Then

            cmd.CommandText = "INSERT INTO employe ( ID, cin, nom, pre_nom, aderesse, sexe, Date_naissance, Etat_civile, Email, Num_tele,photo) VALUES( @ID, @cin, @nom, @pre_nom, @aderesse, @sexe, @Date_naissance, @Etat_civile, @Email, @Num_tele, @photo )"

            cmd.Parameters.Add("@ID", OleDbType.VarChar).Value = inf1.Text
            cmd.Parameters.Add("@cin", OleDbType.VarChar).Value = inf2.Text
            cmd.Parameters.Add("@nom", OleDbType.VarChar).Value = inf3.Text
            cmd.Parameters.Add("@pre_nom", OleDbType.VarChar).Value = inf4.Text
            cmd.Parameters.Add("@aderesse", OleDbType.VarChar).Value = inf5.Text
            cmd.Parameters.Add("sex", OleDbType.VarChar).Value = inf6.Text
            cmd.Parameters.Add("@Date_naissance", OleDbType.VarChar).Value = inf7.Text
            cmd.Parameters.Add("@Etat_civile", OleDbType.VarChar).Value = inf8.Text
            cmd.Parameters.Add("@Email", OleDbType.VarChar).Value = inf9.Text
            cmd.Parameters.Add("@Num_tele", OleDbType.VarChar).Value = inf10.Text
            cmd.Parameters.Add("@photo", OleDbType.Binary).Value = arrImage
            cmd.ExecuteNonQuery()
            conn.Close()

            If inf12.Text <> "" Then
                con()
                tab = db.CreateCommand
                tab.CommandText = "INSERT INTO ser_historique VALUES ( '" & Nservice & "' , '" & inf1.Text & "' , '" & Date.Now & "') "
                tab.ExecuteNonQuery()
                db.Close()
            End If



            If inf13.Text <> "" Then
                con()
                tab = db.CreateCommand
                tab.CommandText = "INSERT INTO fon_historique VALUES ( '" & Nfonction & "' , '" & inf1.Text & "' , '" & Date.Now & "') "
                tab.ExecuteNonQuery()
                db.Close()
            End If

            If inf14.Text <> "" Then
                con()
                tab = db.CreateCommand
                tab.CommandText = "INSERT INTO dip_historique VALUES ( '" & Ndiplome & "' , '" & inf1.Text & "' , '" & Date.Now & "') "
                tab.ExecuteNonQuery()
                db.Close()
            End If


            If con6.Text <> "" Then
                con()
                tab = db.CreateCommand
                tab.CommandText = "INSERT INTO contrat VALUES ( '" & con1.Text & "' , '" & con2.Text & "' , '" & con3.Text & "','" & con4.Text & "','" & con5.Text & "', '" & con6.Text & "')"
                tab.ExecuteNonQuery()
                db.Close()
            End If

        Else


            cmd.CommandText = "INSERT INTO employe ( ID, cin, nom, pre_nom, aderesse, sexe, Date_naissance, Etat_civile, Email, Num_tele) VALUES( @ID, @cin, @nom, @pre_nom, @aderesse, @sexe, @Date_naissance, @Etat_civile, @Email, @Num_tele)"

            cmd.Parameters.Add("@ID", OleDbType.VarChar).Value = inf1.Text
            cmd.Parameters.Add("@cin", OleDbType.VarChar).Value = inf2.Text
            cmd.Parameters.Add("@nom", OleDbType.VarChar).Value = inf3.Text
            cmd.Parameters.Add("@pre_nom", OleDbType.VarChar).Value = inf4.Text
            cmd.Parameters.Add("@aderesse", OleDbType.VarChar).Value = inf5.Text
            cmd.Parameters.Add("sex", OleDbType.VarChar).Value = inf6.Text
            cmd.Parameters.Add("@Date_naissance", OleDbType.VarChar).Value = inf7.Text
            cmd.Parameters.Add("@Etat_civile", OleDbType.VarChar).Value = inf8.Text
            cmd.Parameters.Add("@Email", OleDbType.VarChar).Value = inf9.Text
            cmd.Parameters.Add("@Num_tele", OleDbType.VarChar).Value = inf10.Text
            cmd.ExecuteNonQuery()
            conn.Close()



            If inf12.Text <> "" Then
                con()
                tab = db.CreateCommand
                tab.CommandText = "INSERT INTO ser_historique VALUES ( '" & Nservice & "' , '" & inf1.Text & "' , '" & Date.Now & "') "
                tab.ExecuteNonQuery()
                db.Close()
            End If



            If inf13.Text <> "" Then
                con()
                tab = db.CreateCommand
                tab.CommandText = "INSERT INTO fon_historique VALUES ( '" & Nfonction & "' , '" & inf1.Text & "' , '" & Date.Now & "') "
                tab.ExecuteNonQuery()
                db.Close()
            End If

            If inf14.Text <> "" Then
                con()
                tab = db.CreateCommand
                tab.CommandText = "INSERT INTO dip_historique VALUES ( '" & Ndiplome & "' , '" & inf1.Text & "' , '" & Date.Now & "') "
                tab.ExecuteNonQuery()
                db.Close()
            End If


            If con6.Text <> "" Then
                con()
                tab = db.CreateCommand
                tab.CommandText = "INSERT INTO contrat VALUES ( '" & con1.Text & "' , '" & con2.Text & "' , '" & con3.Text & "','" & con4.Text & "','" & con5.Text & "', '" & con6.Text & "')"
                tab.ExecuteNonQuery()
                db.Close()
            End If


        End If


        MsgBox("operation reussite")

        tex.Text = ""
        inf1.Text = ""
        inf2.Text = ""
        inf3.Text = ""
        inf4.Text = ""
        inf5.Text = ""
        inf6.Text = ""
        inf7.Text = ""
        inf8.Text = ""
        inf9.Text = ""
        inf10.Text = ""
        inf11.Text = ""
        inf12.Text = ""
        inf13.Text = ""
        inf14.Text = ""

        '-------------------------
        DG.Rows.Clear()
        aff()
        CONT.Visible = False
        GB.Visible = False
        P5.Visible = False
    End Sub
End Class