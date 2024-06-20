Imports System.IO

Public Class Transaction
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
        Dashboard.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Transaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        readdataclient()
        Label13.Text = DataGridView1.RowCount

        For i = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(8).Value = "COMPLETE" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Lime
            End If


            If DataGridView1.Rows(i).Cells(8).Value = "RENEWED" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.YellowGreen
            End If

            If DataGridView1.Rows(i).Cells(8).Value = "CANCELLED" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If

            If DataGridView1.Rows(i).Cells(8).Value = "EXPIRED" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.DarkRed
            End If





        Next


    End Sub

    Sub readdataclient()
        DataGridView1.Rows.Clear()
        str = "Select * from [TRANSACTION]"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr("UID"), dr("FIRSTNAME"), dr("MIDDLENAME"), dr("LASTNAME"), dr("MEMBERSHIP_SUBS"), dr("AMOUNT_DUE"), dr("PAYMENT"), dr("CHANGE"), dr("USERSTAMP"), dr("DATE"))


        End While
        dr.Close()
        cmd.Dispose()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer = DataGridView1.CurrentRow.Index

        TextBox2.Text = DataGridView1.Item(0, i).Value
        TextBox3.Text = DataGridView1.Item(1, i).Value
        TextBox4.Text = DataGridView1.Item(2, i).Value
        TextBox5.Text = DataGridView1.Item(3, i).Value
        TextBox6.Text = DataGridView1.Item(4, i).Value
        TextBox8.Text = DataGridView1.Item(5, i).Value
        TextBox10.Text = DataGridView1.Item(6, i).Value
        TextBox9.Text = DataGridView1.Item(7, i).Value
        ComboBox1.SelectedItem = DataGridView1.Item(8, i).Value
        TextBox7.Text = DataGridView1.Item(9, i).Value

    End Sub
    Sub Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox8.Clear()
        TextBox10.Clear()
        TextBox9.Clear()
        TextBox7.Clear()

    End Sub
    Sub COLORDATA()
        For i = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(8).Value = "COMPLETE" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Lime
            End If


            If DataGridView1.Rows(i).Cells(8).Value = "RENEWED" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.YellowGreen
            End If

            If DataGridView1.Rows(i).Cells(8).Value = "CANCELLED" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If

            If DataGridView1.Rows(i).Cells(8).Value = "EXPIRED" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.DarkRed
            End If





        Next
    End Sub

    Sub updateclient()
        query = "Update [TRANSACTION] set UID = @UID ,FIRSTNAME = @FIRSTNAME ,MIDDLENAME = @MIDDLENAME ,LASTNAME = @LASTNAME,MEMBERSHIP_SUBS = @MEMBERSHIP_SUBS,AMOUNT_DUE = @AMOUNT_DUE, PAYMENT = @PAYMENT, CHANGE = @CHANGE, USERSTAMP = @USERSTAMP, DATE = @DATE  where UID = @UID "
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@UID", TextBox2.Text)
            .Parameters.AddWithValue("@FIRSTNAME", TextBox3.Text)
            .Parameters.AddWithValue("@MIDDLENAME", TextBox4.Text)
            .Parameters.AddWithValue("@LASTNAME", TextBox5.Text)
            .Parameters.AddWithValue("@MEMBERSHIP_SUBS", TextBox6.Text)
            .Parameters.AddWithValue("@AMOUNT_DUE", TextBox8.Text)
            .Parameters.AddWithValue("@PAYMENT", TextBox10.Text)
            .Parameters.AddWithValue("@CHANGE", TextBox9.Text)
            .Parameters.AddWithValue("@USERSTAMP", ComboBox1.SelectedItem)
            .Parameters.AddWithValue("@DATE", TextBox7.Text)


        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        updateclient()
        MsgBox("Successfully Update", MsgBoxStyle.Information, "Safe")
        readdataclient()
        Dim frm = New Transaction
        Me.Close()
        frm.Show()
        Clear()
    End Sub

    Sub Deleteclient(ByVal CID As String)
        query = "Delete from [TRANSACTION] where UID = @UID"
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@UID", CID)







        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim i As Integer = DataGridView1.CurrentRow.Index
        Deleteclient(DataGridView1.Item(0, i).Value)
        readdataclient()
        COLORDATA()
        Label13.Text = DataGridView1.RowCount




        MsgBox("Successfully Deleted", MsgBoxStyle.Information, "Not Safe")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Report.Show()
    End Sub
    Sub searchMENU()
        Dim i As Integer

        DataGridView1.Rows.Clear()
        str = "Select * from [TRANSACTION] where FIRSTNAME like '%" & TextBox1.Text & "%' or MIDDLENAME like '%" & TextBox1.Text & "%' or LASTNAME like '%" & TextBox1.Text & "%'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader

        While dr.Read
            DataGridView1.Rows.Add(dr("UID"), dr("FIRSTNAME"), dr("MIDDLENAME"), dr("LASTNAME"), dr("MEMBERSHIP_SUBS"), dr("AMOUNT_DUE"), dr("PAYMENT"), dr("CHANGE"), dr("USERSTAMP"), dr("DATE"))

        End While

        If DataGridView1.Rows.Count = 0 Then


        End If


        dr.Close()
        cmd.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        searchMENU()
        COLORDATA()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        searchMENU()
        COLORDATA()
    End Sub
End Class