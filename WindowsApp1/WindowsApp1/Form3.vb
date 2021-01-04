Imports System.Data.OleDb
Public Class Form3
    Dim con As New OleDb.OleDbConnection
    Dim dbProvider As String = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"
    Dim dbSource As String = "Data Source=E:\Users\Home\Documents\Database2.accdb"
    Dim adapter As OleDbDataAdapter
    Dim ds As DataSet
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con.ConnectionString = dbProvider & dbSource
        ds = New DataSet


        If TextBox2.Text <> TextBox3.Text Then
            MsgBox("Password do not match!")
        ElseIf TextBox1.Text = "" And TextBox2.Text = "" And TextBox3.Text = "" Then
            MsgBox("Please fill up the necessary fields")
        Else
            adapter = New OleDbDataAdapter("INSERT INTO [user] ([Username],[Password]) VALUES " & "('" & TextBox1.Text & "','" & TextBox2.Text & "')", con)
            adapter.Fill(ds, "user")
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            MessageBox.Show("User Registered!")
            Form1.Show()
            Me.Hide()


        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Hide()

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            TextBox2.PasswordChar = "*"
            TextBox3.PasswordChar = "*"
        Else
            TextBox2.PasswordChar = ""
            TextBox3.PasswordChar = ""
        End If
    End Sub
End Class