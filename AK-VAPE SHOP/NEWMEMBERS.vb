Public Class NEWMEMBERS
    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click, Label17.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Are you sure you want to Cancel?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If dialog = DialogResult.No Then
            Me.Hide()
            Me.Show()
        Else

            Me.Close()


        End If
    End Sub

    Sub INPUT()
        PAYMENT.Label3.Text = TextBox1.Text
        PAYMENT.Label5.Text = TextBox2.Text
        PAYMENT.Label6.Text = TextBox3.Text
        PAYMENT.Label7.Text = TextBox4.Text
        PAYMENT.Label9.Text = TextBox5.Text
        PAYMENT.Label11.Text = ComboBox3.SelectedItem
        PAYMENT.Label13.Text = TextBox7.Text
        PAYMENT.Label15.Text = DateTimePicker1.Value
        PAYMENT.Label17.Text = TextBox8.Text
        PAYMENT.TextBox1.Text = TextBox9.Text
        PAYMENT.Label19.Text = ComboBox1.SelectedItem
        PAYMENT.Label22.Text = TextBox12.Text
        PAYMENT.Guna2CirclePictureBox1.Image = Guna2CirclePictureBox1.Image
        PAYMENT.Label32.Text = TextBox10.Text

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        INPUT()

        PAYMENT.Show()
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged
        If TextBox11.Text.Length > 9 Then
            MsgBox("d")
            MessageBox.Show("SUCCESFULLY SCANNED", "RFID")
            Label18.Text = "GENERATED RFID"
            Label18.ForeColor = Color.DarkGreen
            TextBox11.Enabled = False

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel1.Hide()
        Label18.Text = "PLEASE SCAN RFID"
        Label18.ForeColor = Color.Black
        TextBox11.Enabled = True
        TextBox10.Text = TextBox11.Text

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel1.Show()
        TextBox11.Select()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel1.Hide()
        Label18.Text = "PLEASE SCAN RFID"
        Label18.ForeColor = Color.Black
        TextBox11.Enabled = True

    End Sub
    Sub AutoNumberID()
        Dim autoORDERID As Integer
        str = "SELECT COUNT(*) as UID FROM GYMEMBERSHIP"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            autoORDERID = CInt(dr("UID")) + 1
        End While
        dr.Close()


        Dim formattedID As String = autoORDERID.ToString("000")

        TextBox1.Text = "M" & formattedID
    End Sub
    Private Sub NEWMEMBERS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AutoNumberID()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label19.Text = Date.Now.ToString("/d/yyyy")
        Label20.Text = Date.Now.ToString("M/d/")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged, ComboBox3.SelectedIndexChanged
        If ComboBox1.SelectedItem = "MONTHLY" Then
            TextBox12.Text = Date.Now.ToString("MM") + 1 & Label19.Text
            PAYMENT.Label33.Text = "700₱"
            PAYMENT.Label34.Text = "700"
        End If

        If ComboBox1.SelectedItem = "YEARLY" Then
            TextBox12.Text = Label20.Text & Date.Now.ToString("yyyy") + 1
            PAYMENT.Label33.Text = "6,999₱"
            PAYMENT.Label34.Text = "6,999"
        End If
    End Sub

    Private Sub Guna2CirclePictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2CirclePictureBox1.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg"

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Guna2CirclePictureBox1.Image = System.Drawing.Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub TextBox8_MouseLeave(sender As Object, e As EventArgs) Handles TextBox8.MouseLeave

    End Sub

    Private Sub TextBox8_TabStopChanged(sender As Object, e As EventArgs) Handles TextBox8.TabStopChanged

    End Sub

    Private Sub TextBox8_LostFocus(sender As Object, e As EventArgs) Handles TextBox8.LostFocus
        TextBox8.Text = TextBox8.Text + "@Gmail.com"
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub
End Class