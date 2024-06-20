Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class RENEW
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedItem = "MONTHLY" Then
            Label36.Text = "600"

            TextBox12.Text = Date.Now.ToString("MM") + 1 & Label19.Text

            TextBox2.Enabled = True



        End If

        If ComboBox2.SelectedItem = "YEARLY" Then
            Label36.Text = "6500"

            TextBox12.Text = Label20.Text & Date.Now.ToString("yyyy") + 1

            TextBox2.Enabled = True



        End If


    End Sub
    Sub updateTRA()

        query = "Update [TRANSACTION] set AMOUNT_DUE = @AMOUNT_DUE ,PAYMENT = @PAYMENT ,CHANGE = @CHANGE,USERSTAMP = @USERSTAMP,DATE = @DATE where UID = @UID "
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@UID", Label2.Text)
            .Parameters.AddWithValue("@AMOUNT_DUE", Label36.Text)
            .Parameters.AddWithValue("@PAYMENT", TextBox2.Text)
            .Parameters.AddWithValue("@CHANGE", Label38.Text)
            .Parameters.AddWithValue("@USERSTAMP", TextBox3.Text)
            .Parameters.AddWithValue("@DATE", Date.Now.ToString("dddd, MMMM d, yyyy"))




        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub
    Sub updateMEMBER()

        query = "Update GYMEMBERSHIP set MEMBERSHIP_PLAN = @MEMBERSHIP_PLAN ,MEMBERSHIP_STATUS = @MEMBERSHIP_STATUS ,EXPIRATION = @EXPIRATION where UID = @UID "
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@UID", Label2.Text)
            .Parameters.AddWithValue("@MEMBERSHIP_PLAN", ComboBox2.SelectedItem)
            .Parameters.AddWithValue("@MEMBERSHIP_STATUS", Label4.Text)
            .Parameters.AddWithValue("@EXPIRATION", TextBox12.Text)





        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim p As Integer
        Dim sum As Integer
        p = Val(TextBox2.Text)

        If (p < Label36.Text) Then
            MsgBox("PAYMENT UNABLE TO PROCESS", vbCritical, "PAYMENT FAILED")

        Else
            MsgBox("PAYMENT SUCCESFULLY",)
            TextBox3.Text = "RENEWED"
            sum = TextBox2.Text - Label36.Text
            Label38.Text = sum
            updateTRA()
            updateMEMBER()
            Transaction.Close()
            TextBox2.Enabled = False
            ComboBox2.Enabled = False
            Button5.Visible = False
            Button1.Visible = True
            Button4.Visible = False

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        EDIT1.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Gymembers.Close()
        Gymembers.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label19.Text = Date.Now.ToString("/d/yyyy")
        Label20.Text = Date.Now.ToString("M/d/")
    End Sub

    Private Sub RENEW_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class