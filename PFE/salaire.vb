Imports System.Data.OleDb
Public Class salaire
    Private conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\BD.accdb")
    Dim dr As OleDbDataReader
    Public da As New OleDbDataAdapter
    Public dt As New DataTable
    Private Sub GunaGradientButton7_Click(sender As Object, e As EventArgs) Handles GunaGradientButton7.Click
        tex.Visible = True
        f.Visible = True
        pic2.Visible = True
    End Sub
    Private Sub pic2_Click(sender As Object, e As EventArgs) Handles pic2.Click
        L.Text = tex.Text
    End Sub

    Private Sub L_Click(sender As Object, e As EventArgs) Handles L.Click

    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles f.Click
        pic2.Visible = False
        tex.Visible = False
        f.Visible = False

    End Sub

    Private Sub salaire_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'con()
        'tab = db.CreateCommand
        'tab.CommandText = "select * from py "
        'enr = tab.ExecuteReader

        'While enr.Read
        '    ' Dim total As Double
        '    Dim t As Double
        '    t = CDbl(enr(3))

        '    ' total = t + 1

        '    'MsgBox(total)

        '    DG.Rows.Add(enr(0), enr(1), enr(2), t)
        'End While
        'db.Close()
    End Sub

    Private Sub GunaGradientButton13_Click(sender As Object, e As EventArgs) Handles GunaGradientButton13.Click
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub GunaGradientButton1_Click_1(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim total As Double
        Dim t As Double


        total = 0

        con()
        Dim tr As Boolean = False
        tab = db.CreateCommand
        tab.CommandText = "select * from py where ID ='" & rech.Text & "'"

        enr = tab.ExecuteReader
        While enr.Read
            tr = True

            inf1.Text = enr(0)
            inf3.Text = enr(1)
            inf4.Text = enr(2)

            t = CDbl(enr(3))
            total = total + t


            inf5.Text = total


            inf6.Text = Val(total) * Val(L.Text)
            inf7.Text = Date.Now.ToString("dd-MM-yyyy")
        End While

        If tr = False Then

            MsgBox("pas trouve")

        End If
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
        MsgBox("J'ai trouvé " & tex.Text)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GB2.Enter

    End Sub

    Private Sub valider1_Click(sender As Object, e As EventArgs) Handles valider1.Click
        Dim c As String
        con()
        Dim tr As Boolean = False
        tab = db.CreateCommand
        tab.CommandText = "select NUM_RS from payement "

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

        RS1.Text = c

        db.Close()

        GB2.Visible = True
        RS2.Text = inf1.Text
        RS3.Text = inf3.Text
        RS4.Text = inf4.Text
        RS5.Text = inf6.Text
        RS7.Text = Date.Now.ToString("dd-MM-yyyy")
    End Sub

    Private Sub GunaGradientButton4_Click(sender As Object, e As EventArgs) Handles GunaGradientButton4.Click
        con()
        tab = db.CreateCommand
        tab.CommandText = "INSERT INTO payement VALUES ( '" & RS1.Text & "' , '" & RS2.Text & "' ,'" & RS5.Text & "' , '" & Date.Now.ToString("dd-MM-yyyy") & "') "
        tab.ExecuteNonQuery()
        db.Close()
        MsgBox("operation reussite")

    End Sub

    Private Sub GB_Enter(sender As Object, e As EventArgs) Handles GB.Enter

    End Sub

    Private Sub RS7_TextChanged(sender As Object, e As EventArgs) Handles RS7.TextChanged

    End Sub
End Class