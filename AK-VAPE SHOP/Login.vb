Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Cryptography
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Login
    Dim trynumber As Integer
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
    End Sub


    Sub LOGGED()
        If sqlconn.State <> ConnectionState.Open Then
            sqlconn.Open()
        End If
        Dim da As New SqlDataAdapter("select * from ACCOUNTS ", sqlconn)
        Dim dt As New DataTable
        dt.Clear()
        da.Fill(dt)
        Dim resultat As Integer
        For i = 0 To dt.Rows.Count - 1
            If TextBox1.Text = Convert.ToString(dt.Rows(i)("USERNAME")) And
                TextBox2.Text = Convert.ToString(dt.Rows(i)("PASSWORD")) Then

                fname = Convert.ToString(dt.Rows(i)("FNAME"))
                lname = Convert.ToString(dt.Rows(i)("LNAME"))
                mname = Convert.ToString(dt.Rows(i)("MNAME"))
                userlevel = Convert.ToString(dt.Rows(i)("USERLEVEL"))
                ' uid = Convert.ToString(dt.Rows(i)("uid"))
                'oldpass.Label5.Text = Convert.ToString(dt.Rows(i)("Password"))
                ' username.Label3.Text = Convert.ToString(dt.Rows(i)("Username"))
                uid = Convert.ToString(dt.Rows(i)("UID"))
                imageE = Convert.ToString(dt.Rows(i)("IMAGE"))


                Me.Hide()

                Dashboard.Label4.Text = fname + " " + mname + " " + lname


                Form2.Label1.Text = (fname + " " + mname + " " + lname)
                Form2.Show()
                'Dashboard.Show()
                'Dashboard.Label5.Text = fname + " " + lname
                USERMANAGEMENT.Label13.Text = uid
                USERMANAGEMENT.Label14.Text = userlevel
                Dashboard.Label3.Text = uid
                Dashboard.Label8.Text = userlevel



                resultat = 1

                Try
                    str = "Select * from ACCOUNTS where PASSWORD = @PASSWORD"
                    cmd = New SqlClient.SqlCommand(str, sqlconn)
                    With cmd
                        .Parameters.AddWithValue("@USERNAME", TextBox1.Text)
                        .Parameters.AddWithValue("@PASSWORD", TextBox2.Text)
                    End With

                    dr = cmd.ExecuteReader
                    If (dr.Read()) Then

                    End If
                    cmd.Dispose()
                    dr.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        Next
        If resultat <> 1 Then

            MsgBox("Invalid Credentials", MsgBoxStyle.Critical)
            trynumber += 1


            If trynumber >= 3 Then
                MsgBox(" You are now Locked! Please Try again", MsgBoxStyle.Critical)
                '
            End If
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If sqlconn.State <> ConnectionState.Open Then
            sqlconn.Open()
        End If
        Dim da As New SqlDataAdapter("select * from ACCOUNTS ", sqlconn)
        Dim dt As New DataTable
        dt.Clear()
        da.Fill(dt)
        Dim resultat As Integer
        For i = 0 To dt.Rows.Count - 1
            If TextBox1.Text = Convert.ToString(dt.Rows(i)("USERNAME")) And
                TextBox2.Text = Convert.ToString(dt.Rows(i)("PASSWORD")) Then

                fname = Convert.ToString(dt.Rows(i)("FNAME"))
                lname = Convert.ToString(dt.Rows(i)("LNAME"))
                mname = Convert.ToString(dt.Rows(i)("MNAME"))
                userlevel = Convert.ToString(dt.Rows(i)("USERLEVEL"))
                ' uid = Convert.ToString(dt.Rows(i)("uid"))
                'oldpass.Label5.Text = Convert.ToString(dt.Rows(i)("Password"))
                ' username.Label3.Text = Convert.ToString(dt.Rows(i)("Username"))
                uid = Convert.ToString(dt.Rows(i)("UID"))
                imageE = Convert.ToString(dt.Rows(i)("IMAGE"))
                BIO = Convert.ToString(dt.Rows(i)("BIO"))
                password = Convert.ToString(dt.Rows(i)("PASSWORD"))
                username = Convert.ToString(dt.Rows(i)("USERNAME"))
                RFID = Convert.ToString(dt.Rows(i)("RFID"))
                Me.Hide()

                Dashboard.Label4.Text = fname + " " + mname + " " + lname
                Personal.Label10.Text = fname
                Personal.Label11.Text = mname
                Personal.Label12.Text = lname
                Personal.TextBox1.Text = password
                Personal.Label9.Text = username
                Personal.TextBox2.Text = RFID
                Personal.Label15.Text = password
                Form2.Label2.Text = uid


                Form2.Label1.Text = (fname + " " + mname + " " + lname)
                Form2.Show()
                'Dashboard.Show()
                'Dashboard.Label5.Text = fname + " " + lname
                USERMANAGEMENT.Label13.Text = uid
                Personal.Label14.Text = uid
                USERMANAGEMENT.Label14.Text = userlevel
                Dashboard.Label3.Text = uid
                Dashboard.Label8.Text = userlevel
                Settings.Label7.Text = uid
                Settings.TextBox1.Text = BIO
                Dashboard.TextBox1.Text = BIO
                Personal.Label17.Text = uid




                resultat = 1

                Try
                    str = "Select * from ACCOUNTS where PASSWORD = @PASSWORD"
                    cmd = New SqlClient.SqlCommand(str, sqlconn)
                    With cmd
                        .Parameters.AddWithValue("@USERNAME", TextBox1.Text)
                        .Parameters.AddWithValue("@PASSWORD", TextBox2.Text)
                    End With

                    dr = cmd.ExecuteReader
                    If (dr.Read()) Then

                    End If
                    cmd.Dispose()
                    dr.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        Next
        If resultat <> 1 Then

            MsgBox("Invalid Credentials", MsgBoxStyle.Critical)
            trynumber += 1


            If trynumber >= 3 Then
                MsgBox(" You are now Locked! Please Try again", MsgBoxStyle.Critical)
                '
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "*"
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Register.Show()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        '''
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = Label3.Text + 1
        If Label3.Text > 8 Then Label3.Text = 0

        Select Case Label3.Text
            Case 0
                PictureBox1.Image = My.Resources.PIC1
                PictureBox3.BackColor = Color.Yellow
                PictureBox4.BackColor = Color.WhiteSmoke
                PictureBox5.BackColor = Color.WhiteSmoke
            Case 3
                PictureBox1.Image = My.Resources.PIC2
                PictureBox3.BackColor = Color.WhiteSmoke
                PictureBox4.BackColor = Color.Yellow
                PictureBox5.BackColor = Color.WhiteSmoke
            Case 6
                PictureBox1.Image = My.Resources.PIC3
                PictureBox3.BackColor = Color.WhiteSmoke
                PictureBox4.BackColor = Color.WhiteSmoke
                PictureBox5.BackColor = Color.Yellow
        End Select
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        ACCESS.Show()
        ACCESS.TextBox1.Select()
    End Sub
    Sub searchMENU()
        Dim i As Integer
        DataGridView1.Rows.Clear()
        str = "Select * from ACCOUNTS where RFID like '%" & TextBox3.Text & "%' "
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr("UID"), dr("USERNAME"), dr("PASSWORD"), dr("RFID"))
        End While
    End Sub


    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text.Length > 9 Then
            MsgBox("d")

            searchMENU()

            If DataGridView1.Rows.Count = 0 Then
                Panel2.Show()
                TextBox3.Clear()
                Panel1.Hide()

            Else
                Dim i As Integer = DataGridView1.CurrentRow.Index

                TextBox1.Text = DataGridView1.Item(1, i).Value
                TextBox2.Text = DataGridView1.Item(2, i).Value

                Button1.PerformClick()


            End If


        End If
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Panel1.Show()
        TextBox3.Select()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel1.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel2.Hide()
    End Sub
End Class