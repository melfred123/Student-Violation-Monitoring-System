Imports System.Data.OleDb
Public Class Form2
    Sub displayData(ByVal isSearch As Boolean)
        Try
            Dim query As String

            If isSearch Then
                query = "SELECT * FROM students WHERE nname LIKE '" & TextBox1.Text & "%'"
            Else
                query = "SELECT * FROM students"
            End If

            Dim dr As OleDbDataReader

            cmd = New OleDbCommand(query, con)
            dr = cmd.ExecuteReader

            DataGridView1.Rows.Clear()

            While dr.Read
                DataGridView1.Rows.Add(dr("Student_ID"), dr("studentn"), dr("nname"), dr("ddate"), dr("sviolation"), dr("typee"), "Edit", "Delete")
            End While

            dr.Close()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Addedit()
        TextBox2.Clear()
        TextBox1.Clear()
        TextBox3.Clear()
    End Sub
    Sub Addedit()
        Try
            Dim query As String 'variable for sql query
            If isEdit Then
                query = "UPDATE students SET studentn ='" & TextBox4.Text & "', nname ='" & TextBox2.Text & "',ddate ='" & DateTimePicker1.Text & "',sviolation ='" & TextBox3.Text & "' ,typee ='" & ComboBox1.Text & "' WHERE Student_ID = " & StudentID & ""
            Else
                query = "INSERT INTO students (studentn,nname,ddate,sviolation,typee) VALUES ('" & TextBox4.Text & "','" & TextBox2.Text & "','" & DateTimePicker1.Text & "','" & TextBox3.Text & "' ,'" & ComboBox1.Text & "')"
            End If


            If InsertUpdateDelete(query) Then
                If isEdit Then
                    MsgBox("Data successfully updated to the DB!", MsgBoxStyle.Information, "Success")
                    isEdit = False
                    Reset()
                Else
                    MsgBox("Data successfully inserted to the DB!", MsgBoxStyle.Information, "Success")
                    Reset()
                End If
                TabControl1.SelectedIndex = 1
                displayData(False)

            Else
                If isEdit Then
                    MsgBox("Failed to update!", MsgBoxStyle.Critical, "Error")
                    isEdit = False
                Else
                    MsgBox("Failed to insert!", MsgBoxStyle.Critical, "Error")
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        testCon()
        displayData(False)
        Return

    End Sub

    Private Sub sname_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        displayData(True)
    End Sub

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            If e.RowIndex < 0 Then
                Exit Sub
            End If

            Dim grid = DirectCast(sender, DataGridView)

            If TypeOf grid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If grid.Columns(e.ColumnIndex).Name = "btnEdit" Then
                    TabControl1.SelectedIndex = 0
                    TextBox4.Text = CStr(grid.Rows(e.RowIndex).Cells(1).Value)
                    TextBox2.Text = CStr(grid.Rows(e.RowIndex).Cells(2).Value)
                    DateTimePicker1.Text = CDate(grid.Rows(e.RowIndex).Cells(3).Value)
                    TextBox3.Text = CStr(grid.Rows(e.RowIndex).Cells(4).Value)
                    ComboBox1.Text = CStr(grid.Rows(e.RowIndex).Cells(5).Value)
                    isEdit = True
                    StudentID = CInt(grid.Rows(e.RowIndex).Cells(0).Value)
                ElseIf grid.Columns(e.ColumnIndex).Name = "btndelete" Then
                    If MsgBox("Are you sure do you want to delete the record of " & CStr(grid.Rows(e.RowIndex).Cells(2).Value) & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                        If InsertUpdateDelete("DELETE FROM students WHERE Student_ID = " & grid.Rows(e.RowIndex).Cells(0).Value & "") Then
                            MsgBox("Successfully Deleted!", MsgBoxStyle.Information, "Success")
                            displayData(False)
                        Else
                            MsgBox("Failed to delete!", MsgBoxStyle.Critical, "Error")
                            displayData(False)
                        End If

                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub
End Class