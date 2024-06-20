Imports System.IO
Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Xml

Public Class Settings
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PictureBox1.Image = My.Resources.switch
        Timer1.Enabled = True


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Label1.Text = Label1.Text + 1
        If Label1.Text > 3 Then
            PictureBox2.Image = My.Resources.TEST_THEME_WHITE
            PictureBox1.Visible = False
            PictureBox2.Visible = True
            Timer1.Enabled = False
            Me.BackColor = Color.RoyalBlue
            Personal.BackColor = Color.RoyalBlue
            About.BackColor = Color.RoyalBlue
            USERMANAGEMENT.BackColor = Color.RoyalBlue

            Label3.Text = "Switch to Black Theme"

            Dashboard.BackgroundImage = My.Resources.DAHS_white_theme

            About.PictureBox1.Image = My.Resources.Tao
            About.PictureBox2.Image = My.Resources._1

            About.PictureBox5.Image = My.Resources._6
            About.PictureBox6.Image = My.Resources._3
            About.PictureBox7.Image = My.Resources._7
        End If



    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Label1.Text = 0
        Label2.Text = 0
        PictureBox2.Image = My.Resources.swtich_2
        Timer2.Enabled = True
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        Label2.Text = Label2.Text + 1
        If Label2.Text > 3 Then
            PictureBox1.Image = My.Resources.TEST_THEME_DARK2
            PictureBox1.Visible = True
            PictureBox2.Visible = False
            Timer2.Enabled = False
            Me.BackColor = Color.MidnightBlue
            Personal.BackColor = Color.MidnightBlue
            About.BackColor = Color.MidnightBlue
            USERMANAGEMENT.BackColor = Color.MidnightBlue
            Label3.Text = "Switch to White Theme"
            Label3.ForeColor = Color.White
            Dashboard.BackgroundImage = My.Resources.DASHBOARD_BG
            Dashboard.Label5.ForeColor = Color.White
            Dashboard.Label3.ForeColor = Color.White
            Dashboard.Label6.ForeColor = Color.White
            Dashboard.Label4.ForeColor = Color.White
            Dashboard.Label7.ForeColor = Color.White
            Dashboard.Label8.ForeColor = Color.White
            Dashboard.Label2.ForeColor = Color.White
            Dashboard.Label1.ForeColor = Color.White
            Dashboard.Button1.ForeColor = Color.White
            Button1.ForeColor = Color.White
            Label4.ForeColor = Color.White
            Label5.ForeColor = Color.White
            Button2.ForeColor = Color.White
            Button3.ForeColor = Color.White
            Button5.ForeColor = Color.White
            Button4.ForeColor = Color.White

            About.Button5.ForeColor = Color.White
            About.Label1.ForeColor = Color.White
            About.Label2.ForeColor = Color.White
            About.Label3.ForeColor = Color.White

            About.Label5.ForeColor = Color.White
            About.Label6.ForeColor = Color.White
            About.Label7.ForeColor = Color.White
            About.PictureBox1.Image = My.Resources.bus
            About.PictureBox2.Image = My.Resources.address

            About.PictureBox5.Image = My.Resources._6
            About.PictureBox6.Image = My.Resources.wifiii
            About.PictureBox7.Image = My.Resources.hours

        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Sub update()
        Dim ms As New MemoryStream
        PictureBox6.Image.Save(ms, PictureBox6.Image.RawFormat)
        query = "Update ACCOUNTS set  IMAGE = @IMAGE, BIO = @BIO  where UID = @UID "
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@UID", Label7.Text)
            .Parameters.AddWithValue("@BIO", TextBox1.Text)
            .Parameters.AddWithValue("@IMAGE", ms.ToArray)





        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        update()
        MsgBox("Apply Changes Please Login Again!")
        Me.Hide()
        Dashboard.Close()

        Application.Restart()


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim a As String
        Dim b As Boolean = False
        Dim c As Char
        Dim d As Integer



        a = TextBox1.Text

        If a.Length > 45 Then
            MessageBox.Show("The characters must be 50 characters only.")
            TextBox1.Focus()
            TextBox1.Clear()



        End If
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim img() As Byte
        str = "Select * from ACCOUNTS where UID = '" & Label7.Text & "'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            img = dr("IMAGE")
            Dim ms As New MemoryStream(img)
            PictureBox6.Image = Image.FromStream(ms)


        End While
        dr.Close()
        cmd.Dispose()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg"

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox6.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        About.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Personal.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
    End Sub
End Class