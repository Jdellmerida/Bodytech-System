Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Register
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        TextBox8.Text = encrypt(TextBox3.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If TextBox3.Text = "" Then
            MsgBox("PLEASE INPUT PASSWORD FIELD")
        Else
            Clipboard.SetText(TextBox8.Text)
            MsgBox("Encrypt Coppied")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As String
        Dim b As Boolean = False
        Dim c As Char
        Dim d As Integer



        a = TextBox3.Text

        If a.Length < 8 Then
            MessageBox.Show("Password must be at least 8 characters long.")
            TextBox3.Focus()

        Else
            For d = 0 To a.Length - 1
                c = a.Chars(d)
                If Not Char.IsLetterOrDigit(c) Then
                    b = True
                    Exit For
                End If
            Next
            If b Then


                MsgBox("Account Succesfuly Created")

                LOGGED()
            Else
                MsgBox("Your password must contain at least one special characters")

            End If
        End If

    End Sub

    Sub LOGGED()
        Dim cntun, cntflb As String

        str = "Select COUNT(UID) as cntun from ACCOUNTS where UID = '" & TextBox1.Text & "' and USERNAME = '" & TextBox2.Text & "'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            cntun = dr.GetValue(0)
        End While
        dr.Close()
        cmd.Dispose()

        If cntun = "1" Then
            MsgBox("Username Already Exist")
        End If

        str = "Select COUNT(UID) as cntflb from ACCOUNTS where PASSWORD = '" & TextBox3.Text & "' and FNAME = '" & TextBox4.Text & "' and MNAME = '" & TextBox5.Text & "' and LNAME = '" & TextBox6.Text & "' and USERLEVEL = '" & Label7.Text & "'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            cntflb = dr.GetValue(0)
        End While
        dr.Close()
        cmd.Dispose()

        If cntflb = "1" Then
            MsgBox("User Already Exist")
        End If

        If cntun = "0" And cntflb = "0" Then


            query = "insert into ACCOUNTS (UID,USERNAME,PASSWORD,FNAME,MNAME,LNAME,USERLEVEL) values (@UID,@USERNAME,@PASSWORD,@FNAME,@MNAME,@LNAME,@USERLEVEL)"
            cmd = New SqlClient.SqlCommand(query, sqlconn)

            With cmd

                .Parameters.AddWithValue("@UID", TextBox1.Text)
                .Parameters.AddWithValue("@USERNAME", TextBox2.Text)
                .Parameters.AddWithValue("@PASSWORD", TextBox3.Text)
                .Parameters.AddWithValue("@FNAME", TextBox4.Text)
                .Parameters.AddWithValue("@MNAME", TextBox5.Text)
                .Parameters.AddWithValue("@LNAME", TextBox6.Text)
                .Parameters.AddWithValue("@USERLEVEL", Label7.Text)





            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End If
        dr.Close()
        cmd.Dispose()


        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox8.Clear()


        Me.Close()
    End Sub

    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class