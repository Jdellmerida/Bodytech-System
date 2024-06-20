Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Personal
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
    End Sub

    Private Sub Personal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel3.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click




        ' Retrieve the entered passwords
        Dim Password As String = TextBox3.Text
        Dim oldPassword As String = Label15.Text

        ' Check if the passwords match
        If Password = oldPassword Then
            ' Perform the password reset logic here
            ' For example, update the password in the database
            ' ...
            Panel2.Show()
            TextBox4.Select()
            Panel1.Hide()
            TextBox3.Clear()
            ' Display success message

        Else
            ' Display error message
            MsgBox("WRONG PASSWORD PLEASE TRY AGAIN", vbCritical, "CREDENTIALS FAILED")
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged, TextBox5.TextChanged, TextBox6.TextChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel2.Hide()
    End Sub
    Sub updateRFID()


        query = "Update ACCOUNTS set RFID = @RFID where UID = @UID "
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@UID", Label17.Text)
            .Parameters.AddWithValue("@RFID", TextBox4.Text)




        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub



    '' rfid function textbox
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If TextBox4.Text.Length > 9 Then
            MsgBox("d")
            MsgBox("YOUR RFID SUCCESFULLY CHANGED")


        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel1.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        updateRFID()

        Panel2.Hide()
        Application.Restart()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click


        ' Retrieve the entered passwords
        Dim Password As String = TextBox5.Text
        Dim oldPassword As String = Label15.Text

        ' Check if the passwords match
        If Password = oldPassword Then
            Label18.Text = "Enter Your New Password"
            TextBox5.Clear()
            Button8.Visible = True
            Label19.Text = "CONFIRM PASSWORD"
            Button7.Visible = False
            TextBox6.Visible = True




        Else
            ' Display error message
            MsgBox("WRONG PASSWORD PLEASE TRY AGAIN", vbCritical, "CREDENTIALS FAILED")
        End If
    End Sub
    Sub updatePASS()


        query = "Update ACCOUNTS set PASSWORD = @PASSWORD where UID = @UID "
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@UID", Label17.Text)
            .Parameters.AddWithValue("@PASSWORD", TextBox5.Text)




        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub
    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click

        ' Retrieve the entered passwords
        Dim NEWPassword As String = TextBox5.Text
        Dim conPassword As String = TextBox6.Text

        ' Check if the passwords match
        If NEWPassword = conPassword Then
            Label18.Text = "Enter Your Current Password"

            TextBox6.Visible = False
            Button8.Visible = False
            Label19.Text = ""
            Button7.Visible = True
            Panel3.Hide()
            updatePASS()
            TextBox5.Clear()
            TextBox6.Clear()
            MsgBox("SUCCESFULLY PASSWORD CHANGED")
            Application.Restart()


        Else
            ' Display error message
            MsgBox("WRONG PASSWORD PLEASE TRY AGAIN", vbCritical, "CREDENTIALS FAILED")
        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs) Handles Button9.Click
        Panel1.Hide()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Label18.Text = "Enter Your Current Password"
        TextBox6.Visible = False
        Button8.Visible = False
        Label19.Text = ""
        Button7.Visible = True
        Panel3.Hide()
        TextBox5.Clear()
        TextBox6.Clear()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class