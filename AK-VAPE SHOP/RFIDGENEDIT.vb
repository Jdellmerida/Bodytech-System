Public Class RFIDGENEDIT
    Private Sub RFIDGENEDIT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Length > 9 Then
            MsgBox("d")
            MessageBox.Show("SUCCESFULLY SCANNED", "RFID")
            Label1.Text = "GENERATED RFID"
            Label1.ForeColor = Color.DarkGreen
            TextBox1.Enabled = False

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        EDIT1.Hide()
        EDIT1.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        EDIT1.TextBox10.Text = TextBox1.Text
        Me.Close()
        EDIT1.Hide()
        EDIT1.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub
End Class