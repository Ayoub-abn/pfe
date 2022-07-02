Imports System.Data.OleDb
Module Module1

    Public db As New OleDbConnection
    Public tab As OleDbCommand
    Public enr As OleDbDataReader

    Public Sub con()
        db.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BD.accdb"
        db.Open()
    End Sub

End Module
