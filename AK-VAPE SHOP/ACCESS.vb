Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement


Public Class ACCESS
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()

    End Sub

    ''//SEARCHING MENU OF DATABASES''
    Sub searchMENU()
        Dim i As Integer
        DataGridView1.Rows.Clear()
        str = "Select * from GYMEMBERSHIP where RFID like '%" & TextBox1.Text & "%' "
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr("UID"), dr("FIRSTNAME"), dr("MIDDLENAME"), dr("LASTNAME"), dr("AGE"), dr("GENDER"), dr("CONTACT_NO"), dr("BIRTHDATE"), dr("EMAIL"), dr("ADDRESS"), dr("MEMBERSHIP_PLAN"), dr("MEMBERSHIP_STATUS"), dr("EXPIRATION"), dr("TIME_IN"), dr("IMAGE_USER"), dr("RFID"))
        End While
    End Sub

    Sub readdataclient()
        DataGridView1.Rows.Clear()
        str = "Select * from GYMEMBERSHIP"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr("UID"), dr("FIRSTNAME"), dr("MIDDLENAME"), dr("LASTNAME"), dr("AGE"), dr("GENDER"), dr("CONTACT_NO"), dr("BIRTHDATE"), dr("EMAIL"), dr("ADDRESS"), dr("MEMBERSHIP_PLAN"), dr("MEMBERSHIP_STATUS"), dr("EXPIRATION"), dr("TIME_IN"), dr("IMAGE_USER"), dr("RFID"))


        End While
        dr.Close()
        cmd.Dispose()

    End Sub
    Private Sub ACCESS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        TextBox1.Select()
        'readdataclient()
        Panel1.Hide()
    End Sub

    Sub viewimage()
        Dim img() As Byte
        str = "Select * from GYMEMBERSHIP where RFID = '" & TextBox1.Text & "'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            img = dr("IMAGE_USER")
            Dim ms As New MemoryStream(img)
            Guna2CirclePictureBox1.Image = System.Drawing.Image.FromStream(ms)



        End While
        dr.Close()
        cmd.Dispose()
    End Sub

    Sub matchpreview()

    End Sub


    Sub preview()

        '// CELLCLICK CODE //'

        Dim i As Integer = DataGridView1.CurrentRow.Index
        Label14.Text = DataGridView1.Item(0, i).Value
        Label10.Text = DataGridView1.Item(1, i).Value
        Label11.Text = DataGridView1.Item(2, i).Value
        Label12.Text = DataGridView1.Item(3, i).Value
        Label9.Text = DataGridView1.Item(4, i).Value
        Label3.Text = DataGridView1.Item(5, i).Value
        Label27.Text = DataGridView1.Item(6, i).Value
        Label22.Text = DataGridView1.Item(7, i).Value
        Label15.Text = DataGridView1.Item(8, i).Value
        Label20.Text = DataGridView1.Item(9, i).Value
        Label29.Text = DataGridView1.Item(10, i).Value
        Label19.Text = DataGridView1.Item(12, i).Value
        Label32.Text = DataGridView1.Item(15, i).Value
        viewimage()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Length > 9 Then

            searchMENU()







            If DataGridView1.Rows.Count = 0 Then

                Label17.Text = 0
                Panel2.Show()
                Panel1.Hide()
                Panel3.Hide()
                Panel4.Hide()
                Panel5.Hide()
                ' MsgBox("ACCESS DENIED YOUR RFID DOES NOT EXIST ,PLEASE TRY AGAIN!!", MsgBoxStyle.Critical, "FUNCTION ERROR")
                Timer2.Enabled = True
                TextBox1.Clear()



            Else
                ''// ACCESS CODE WARNING FUNCTION//


                Dim i As Integer = DataGridView1.CurrentRow.Index
                Label38.Text = DataGridView1.Item(11, i).Value

                If Label38.Text = "WARNING" Then
                    Panel4.Show()
                    Panel5.Hide()
                End If
                If Label38.Text = "INACTIVE" Then
                    Panel5.Show()
                    Panel4.Hide()

                End If


                If Label38.Text = "ACTIVE" Then
                    Panel5.Hide()
                    Panel4.Hide()

                End If
                If Label38.Text = "CANCELLED" Then
                    Panel2.Show()
                    Panel4.Hide()
                    Panel5.Hide()
                    Panel3.Hide()
                    Panel1.Hide()
                    Panel6.Hide()
                    Timer2.Enabled = True
                    TextBox1.Clear()

                Else


                    ''\\Deactivatin FUNCTION\\

                    If Label38.Text = "DEACTIVATED" Then
                        Label17.Text = 0
                        Panel3.Show()
                        Panel2.Hide()
                        Panel1.Hide()
                        Panel4.Hide()
                        Panel5.Hide()
                        Panel6.Hide()
                        Timer2.Enabled = True
                        TextBox1.Clear()

                    Else



                        preview()
                        Label17.Text = 0


                        Panel3.Hide()
                        Panel2.Hide()
                        Panel6.Hide()

                        Dim inputDATE As String = Label19.Text
                        Dim expirationDATE As Date
                        If DateTime.TryParse(inputDATE, expirationDATE) Then

                            ''\\EXPIRATION DATE\\

                            If DateTime.Now > expirationDATE Then

                                MessageBox.Show("This user is expired")
                                Panel6.Show()
                                Panel1.Hide()
                                TextBox1.Clear()
                                Timer2.Enabled = True
                                TextBox1.Select()

                            Else


                                History.DataGridView1.Rows.Add(Label14.Text, Label10.Text, Label11.Text, Label12.Text, Label9.Text, Label27.Text, Label19.Text, Label31.Text, Date.Now.ToString("dddd, MMMM d, yyyy"), Guna2CirclePictureBox1.Image)
                                History.rowheight()
                                Gymembers.Close()
                                Gymembers.readdataclient()

                                Label23.Text = Label31.Text

                                If Label38.Text = "INACTIVE" Then

                                    updateACTIVE()
                                    updateTIMEIN()
                                    updateTIMEDATE()
                                    Gymembers.Close()
                                    Gymembers.readdataclient()



                                Else


                                    updateTIMEIN()
                                    updateTIMEDATE()
                                End If

                                TextBox1.Enabled = False
                                Timer1.Enabled = True

                            End If
                        Else
                            MessageBox.Show("Invalid date format. Please enter a valid date.")
                        End If
                    End If
                End If

                End If

        End If
    End Sub

    Sub updateACTIVE()

        query = "Update GYMEMBERSHIP set MEMBERSHIP_STATUS = @MEMBERSHIP_STATUS  where UID = @UID "
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@UID", Label14.Text)
            .Parameters.AddWithValue("@MEMBERSHIP_STATUS", Label43.Text)





        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub

    Sub updateTIMEIN()

        query = "Update GYMEMBERSHIP set TIME_IN = @TIME_IN  where UID = @UID "
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@UID", Label14.Text)
            .Parameters.AddWithValue("@TIME_IN", Label31.Text)





        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub



    ''\\update TIME DATE FUNCTION\\
    Sub updateTIMEDATE()

        query = "Update GYMEMBERSHIP set TIME_DATE = @TIME_DATE  where UID = @UID "
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@UID", Label14.Text)
            .Parameters.AddWithValue("@TIME_DATE", Date.Now.ToString("dddd, MMMM d, yyyy"))





        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Enabled = True
        TextBox1.Clear()
        ProgressBar1.Value = 0
        TextBox1.Select()
        Panel1.Hide()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Value += 50
        If ProgressBar1.Value > 100 Then
            ProgressBar1.Value = 0
            Panel1.Show()
            Timer2.Enabled = True
            Timer1.Enabled = False
            TextBox1.Enabled = True
            TextBox1.Clear()
            TextBox1.Select()
        End If


    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label17.Text += 1

        If Label17.Text > 15 Then
            Timer2.Enabled = False
            Label17.Text = 0
            Panel1.Hide()
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Hide()
            Panel5.Hide()
            Panel6.Hide()
            TextBox1.Enabled = True
            TextBox1.Select()
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Label31.Text = Date.Now.ToString("hh:mm: tt")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)

        TextBox1.Clear()
        TextBox1.Select()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        History.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel2.Hide()
        TextBox1.Enabled = True
        TextBox1.Select()


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Panel3.Hide()
        TextBox1.Select()

    End Sub

    Private Sub Label36_Click(sender As Object, e As EventArgs) Handles Label36.Click

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        Label44.Text = Date.Now.ToString("dddd, MMMM d, yyyy")
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick

    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox1.Clear()
        Timer2.Enabled = True
        TextBox1.Select()
        Panel6.Hide()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class