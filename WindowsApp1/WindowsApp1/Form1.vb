Imports System.Data.OleDb
Public Class Form1
    Dim con As New OleDb.OleDbConnection
    Dim dbProvider As String = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"
    Dim dbSource As String = "Data Source=E:\Users\Home\Documents\Database2.accdb"
    Dim adapter As OleDbDataAdapter
    Dim ds As DataSet
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con.ConnectionString = dbProvider & dbSource
        ds = New DataSet
        adapter = New OleDbDataAdapter("SELECT * FROM [user] where [Username]='" & TextBox1.Text & "' and [Password]='" & TextBox2.Text & "'", con)
        adapter.Fill(ds, "User")

        If ds.Tables("User").Rows.Count > 0 Then
            MessageBox.Show("Logged in successfully!")
            Form2.Show()
            Me.Hide()

            TextBox1.Clear()
            TextBox2.Clear()

        Else
            MessageBox.Show("Username or Password is Incorrect")
            TextBox1.Clear()
            TextBox2.Clear()

        End If

        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Please fill up the necessary fields")
        Else
            MsgBox("Data successfully saved to the DB")



        End If


    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form3.Show()
        Me.Hide()

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox2.PasswordChar = "*"
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
