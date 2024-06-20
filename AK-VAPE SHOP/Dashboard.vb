Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Dashboard
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = Date.Now.ToString("dddd, MMMM d, yyyy")
        Label9.Text = Date.Now.ToString("ss") + " Seconds"
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label2.Text = Date.Now.ToString("h:mm tt")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really Want to Log out?", "Exit", MessageBoxButtons.YesNo)
        If dialog = DialogResult.No Then
            Me.Hide()
            Me.Show()
        Else

            Application.Restart()

        End If




    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        If Label8.Text = "STAFF" Then
            MsgBox("ONLY OWNER CAN ACCESS TO THIS FORM!", vbCritical, "unauthorized access")

        Else
            USERMANAGEMENT.Show()
        End If

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim img() As Byte
        str = "Select * from ACCOUNTS where UID = '" & Label3.Text & "'"
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

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Settings.Show()


    End Sub

    Private Sub PictureBox6_MouseHover(sender As Object, e As EventArgs) Handles PictureBox6.MouseHover
        PictureBox7.Visible = True
        TextBox1.Visible = True
    End Sub

    Private Sub Dashboard_MouseHover(sender As Object, e As EventArgs) Handles Me.MouseHover
        PictureBox7.Visible = False
        TextBox1.Visible = False
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Transaction.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs) Handles PictureBox1.MouseHover
        PictureBox7.Visible = False
        TextBox1.Visible = False
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Gymembers.Show()
        Me.Hide()

    End Sub

    Private Sub PictureBox3_MouseHover(sender As Object, e As EventArgs) Handles PictureBox3.MouseHover
        PictureBox7.Visible = False
        TextBox1.Visible = False
    End Sub

    Private Sub PictureBox4_MouseHover(sender As Object, e As EventArgs) Handles PictureBox4.MouseHover
        PictureBox7.Visible = False
        TextBox1.Visible = False
    End Sub

    Private Sub PictureBox5_MouseHover(sender As Object, e As EventArgs) Handles PictureBox5.MouseHover
        PictureBox7.Visible = False
        TextBox1.Visible = False
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Restart()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Report.Show()
    End Sub
End Class