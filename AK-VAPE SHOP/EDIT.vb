
Imports System.IO
Imports System.Net.Security

Public Class EDIT1

    Private Sub EDIT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        TextBox11.Clear()
        If TextBox10.Text = "Deactivated" Then
            TextBox10.ForeColor = Color.Red
        End If




    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        updateclient()
        MsgBox("Successfully Update", MsgBoxStyle.Information, "Safe")
        Gymembers.readdataclient()
        Gymembers.rowheight()
        Gymembers.Close()
        Gymembers.Show()
        Gymembers.viewimage()
        Gymembers.AUTO()
        Me.Close()

    End Sub


    Sub updateclient()
        Dim ms As New MemoryStream
        Guna2CirclePictureBox1.Image.Save(ms, Guna2CirclePictureBox1.Image.RawFormat)
        query = "Update GYMEMBERSHIP set FIRSTNAME = @FIRSTNAME ,MIDDLENAME = @MIDDLENAME ,LASTNAME = @LASTNAME,AGE = @AGE,GENDER = @GENDER, ADDRESS = @ADDRESS, CONTACT_NO = @CONTACT_NO, BIRTHDATE = @BIRTHDATE, EMAIL = @EMAIL, MEMBERSHIP_PLAN = @MEMBERSHIP_PLAN, MEMBERSHIP_STATUS = @MEMBERSHIP_STATUS, EXPIRATION = @EXPIRATION, IMAGE_USER = @IMAGE_USER, RFID = @RFID where UID = @UID "
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@UID", TextBox1.Text)
            .Parameters.AddWithValue("@FIRSTNAME", TextBox2.Text)
            .Parameters.AddWithValue("@MIDDLENAME", TextBox3.Text)
            .Parameters.AddWithValue("@LASTNAME", TextBox4.Text)
            .Parameters.AddWithValue("@AGE", TextBox5.Text)
            .Parameters.AddWithValue("@GENDER", TextBox6.Text)
            .Parameters.AddWithValue("@CONTACT_NO", TextBox7.Text)
            .Parameters.AddWithValue("@BIRTHDATE", DateTimePicker1.Value)
            .Parameters.AddWithValue("@EMAIL", TextBox8.Text)
            .Parameters.AddWithValue("@ADDRESS", TextBox9.Text)
            .Parameters.AddWithValue("@MEMBERSHIP_PLAN", ComboBox1.SelectedItem)
            .Parameters.AddWithValue("@MEMBERSHIP_STATUS", ComboBox2.SelectedItem)
            .Parameters.AddWithValue("@EXPIRATION", TextBox12.Text)
            .Parameters.AddWithValue("@IMAGE_USER", ms.ToArray)
            .Parameters.AddWithValue("@RFID", TextBox10.Text)




        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub

    Private Sub Guna2CirclePictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2CirclePictureBox1.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg"

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Guna2CirclePictureBox1.Image = System.Drawing.Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label14.Text = Date.Now.ToString("MM") + 1
        Label15.Text = Date.Now.ToString("MM/dd/yyyy")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "MONTHLY" Then
            TextBox11.Text = Label14.Text + "/" + Date.Now.ToString("dd/yyyy")

        End If
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RFIDGENEDIT.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        RENEW.Label2.Text = TextBox1.Text
        Me.Hide()
        RENEW.Show()

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub
End Class