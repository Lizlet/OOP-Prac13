Public Class Form1
    Structure StudentPost
        <VBFixedString(30)> Public sName As String
        <VBFixedString(5)> Public sClass As String
        <VBFixedString(25)> Public sEmail As String
        Public dtDoB As DateTime
    End Structure
    Private myStudent As StudentPost
    Const postLength = 68
    Private count As Integer 'number of posts
    Private position As Integer 'currebt position
    Private fileNumber As Integer
    Private filename As String = "student.dat"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fileNumber = FreeFile()
        FileOpen(fileNumber, filename, OpenMode.Random,,, postLength)
        count = FileLen(filename) / postLength

        If count > 0 Then
            FileGet(fileNumber, myStudent, 1)
            txtName.Text = myStudent.sName
            txtClass.Text = myStudent.sClass
            txtEmail.Text = myStudent.sEmail
            dtpDoB.Value = myStudent.dtDoB
            position = 1
        Else
            position = 0
        End If
        txtCurrentPost.Text = position
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If txtName.TextLength > 0 And txtClass.TextLength > 0 And txtEmail.TextLength > 0 Then
            count = count + 1
            position = count

            With myStudent
                .sName = txtName.Text
                .sClass = txtClass.Text
                .sEmail = txtEmail.Text
                .dtDoB = dtpDoB.Value
            End With

            FilePut(fileNumber, myStudent, position)

            txtName.Text = ""
            txtClass.Text = ""
            txtEmail.Text = ""
            dtpDoB.Value = DateTimePicker.MinimumDateTime
            txtCurrentPost.Text = ""
        Else
            MsgBox("A field is empty")
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If position <= count Then
            If position < count Then
                position += 1
            End If

            FileGet(fileNumber, myStudent, position)
            txtName.Text = myStudent.sName
            txtClass.Text = myStudent.sClass
            txtEmail.Text = myStudent.sEmail
            dtpDoB.Value = myStudent.dtDoB
        End If

        txtCurrentPost.Text = position
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If position >= 1 Then
            If position > 1 Then
                position -= 1
            End If

            FileGet(fileNumber, myStudent, position)
            txtName.Text = myStudent.sName
            txtClass.Text = myStudent.sClass
            txtEmail.Text = myStudent.sEmail
            dtpDoB.Value = myStudent.dtDoB
        End If

        txtCurrentPost.Text = position
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FileClose(fileNumber)
        MsgBox("Filen er lukket")
        End
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtName.Text = ""
        txtClass.Text = ""
        txtEmail.Text = ""
        txtCurrentPost.Text = ""
        dtpDoB.Value = DateTimePicker.MinimumDateTime
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        position = 1
        FileGet(fileNumber, myStudent, position)
        txtName.Text = myStudent.sName
        txtClass.Text = myStudent.sClass
        txtEmail.Text = myStudent.sEmail
        dtpDoB.Value = myStudent.dtDoB
        txtCurrentPost.Text = position
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        position = count
        FileGet(fileNumber, myStudent, position)
        txtName.Text = myStudent.sName
        txtClass.Text = myStudent.sClass
        txtEmail.Text = myStudent.sEmail
        dtpDoB.Value = myStudent.dtDoB
        txtCurrentPost.Text = position
    End Sub
End Class
