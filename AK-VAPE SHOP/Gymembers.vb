Imports System.IO

Public Class Gymembers
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()

        Dashboard.Show()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub
    Sub searchACTIVE()
        Dim i As Integer
        DataGridView2.Rows.Clear()
        str = "Select * from GYMEMBERSHIP where MEMBERSHIP_STATUS like '%" & Label31.Text & "%' "
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView2.Rows.Add(dr("UID"), dr("MEMBERSHIP_STATUS"))
        End While
    End Sub

    Sub searchACTIVE1()
        Dim i As Integer
        DataGridView3.Rows.Clear()
        str = "Select * from GYMEMBERSHIP where MEMBERSHIP_STATUS like '%" & Label32.Text & "%' "
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView3.Rows.Add(dr("UID"), dr("MEMBERSHIP_STATUS"))
        End While
    End Sub

    Private Sub Gymembers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        readdataclient()
        rowheight()
        searchACTIVE()
        searchACTIVE1()


        Label13.Text = DataGridView1.RowCount
        Label33.Text = DataGridView2.RowCount
        'Counting Active Function
        Dim intcount As Integer = 0
        For Each Row As DataGridViewRow In DataGridView2.Rows
            If DataGridView2.Rows(intcount).Cells(1).Value = "ACTIVE" Then
                'Do Something
                intcount += 1
            End If
        Next
        Label14.Text = intcount

        For i = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(11).Value = "ACTIVE" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Lime
            End If


            If DataGridView1.Rows(i).Cells(11).Value = "INACTIVE" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End If

            If DataGridView1.Rows(i).Cells(11).Value = "CANCELLED" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If

            If DataGridView1.Rows(i).Cells(11).Value = "DEACTIVATED" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.DarkRed
            End If

            If DataGridView1.Rows(i).Cells(11).Value = "WARNING" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Gold
            End If





        Next

    End Sub

    Sub COLORDATA()
        'Counting Active Function
        Dim intcount As Integer = 0
        For Each Row As DataGridViewRow In DataGridView2.Rows
            If DataGridView2.Rows(intcount).Cells(1).Value = "ACTIVE" Then
                'Do Something
                intcount += 1
            End If
        Next
        Label14.Text = intcount

        For i = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(11).Value = "ACTIVE" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Lime
            End If


            If DataGridView1.Rows(i).Cells(11).Value = "INACTIVE" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End If

            If DataGridView1.Rows(i).Cells(11).Value = "CANCELLED" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If

            If DataGridView1.Rows(i).Cells(11).Value = "DEACTIVATED" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.DarkRed
            End If

            If DataGridView1.Rows(i).Cells(11).Value = "WARNING" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Gold
            End If





        Next

    End Sub
    Sub rowheight()
        For i = 0 To DataGridView1.Rows.Count - 1
            Dim r As DataGridViewRow = DataGridView1.Rows(i)
            r.Height = 70
        Next
    End Sub


    Sub readdataclient()
        DataGridView1.Rows.Clear()
        str = "Select * from GYMEMBERSHIP"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr("UID"), dr("FIRSTNAME"), dr("MIDDLENAME"), dr("LASTNAME"), dr("AGE"), dr("GENDER"), dr("CONTACT_NO"), dr("BIRTHDATE"), dr("EMAIL"), dr("ADDRESS"), dr("MEMBERSHIP_PLAN"), dr("MEMBERSHIP_STATUS"), dr("EXPIRATION"), dr("TIME_IN"), dr("TIME_DATE"), dr("IMAGE_USER"), dr("RFID"))


        End While
        dr.Close()
        cmd.Dispose()

    End Sub

    Sub viewimage()
        Dim img() As Byte
        str = "Select * from GYMEMBERSHIP where UID = '" & Label15.Text & "'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            img = dr("IMAGE_USER")
            Dim ms As New MemoryStream(img)
            PictureBox3.Image = Image.FromStream(ms)
            EDIT1.Guna2CirclePictureBox1.Image = Image.FromStream(ms)


        End While
        dr.Close()
        cmd.Dispose()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            If DataGridView1.Columns(e.ColumnIndex).Name = "EDIT" Then



                viewimage()

                EDIT1.Show()
            ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "DELETE" Then

                Dim dialog As DialogResult
                dialog = MessageBox.Show("Do you really Want to DELETE?", "Exit", MessageBoxButtons.YesNo)
                If dialog = DialogResult.No Then
                    Me.Hide()
                    Me.Show()
                Else

                    Dim i As Integer = DataGridView1.CurrentRow.Index
                    Deleteclient(DataGridView1.Item(0, i).Value)
                    Deleteclient1(DataGridView1.Item(0, i).Value)
                    Dim frm = New Gymembers
                    Me.Close()
                    frm.Show()
                    readdataclient()
                    MsgBox("Successfully Deleted", MsgBoxStyle.Information, "Not Safe")

                End If






            End If



        Catch ex As Exception

        End Try
    End Sub

    Sub Deleteclient(ByVal CID As String)
        query = "Delete from GYMEMBERSHIP where UID = @UID"
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@UID", CID)







        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub

    Sub Deleteclient1(ByVal CID As String)
        query = "Delete from [TRANSACTION] where UID = @UID"
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@UID", CID)







        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub
    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub




    Sub AUTO()

        Dim i As Integer = DataGridView1.CurrentRow.Index

        Label15.Text = DataGridView1.Item(0, i).Value
        Label17.Text = DataGridView1.Item(1, i).Value
        Label28.Text = DataGridView1.Item(2, i).Value
        Label29.Text = DataGridView1.Item(3, i).Value
        Label18.Text = DataGridView1.Item(4, i).Value
        Label19.Text = DataGridView1.Item(5, i).Value
        Label20.Text = DataGridView1.Item(6, i).Value
        Label21.Text = DataGridView1.Item(7, i).Value
        Label22.Text = DataGridView1.Item(8, i).Value
        TextBox2.Text = DataGridView1.Item(9, i).Value
        Label23.Text = DataGridView1.Item(10, i).Value
        Label24.Text = DataGridView1.Item(11, i).Value
        Label25.Text = DataGridView1.Item(12, i).Value
        Label30.Text = DataGridView1.Item(16, i).Value
        viewimage()

    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer = DataGridView1.CurrentRow.Index

        Label15.Text = DataGridView1.Item(0, i).Value
        Label17.Text = DataGridView1.Item(1, i).Value
        Label28.Text = DataGridView1.Item(2, i).Value
        Label29.Text = DataGridView1.Item(3, i).Value
        Label18.Text = DataGridView1.Item(4, i).Value
        Label19.Text = DataGridView1.Item(5, i).Value
        Label20.Text = DataGridView1.Item(6, i).Value
        Label21.Text = DataGridView1.Item(7, i).Value
        Label22.Text = DataGridView1.Item(8, i).Value
        TextBox2.Text = DataGridView1.Item(9, i).Value
        Label23.Text = DataGridView1.Item(10, i).Value
        Label24.Text = DataGridView1.Item(11, i).Value
        Label25.Text = DataGridView1.Item(12, i).Value
        Label30.Text = DataGridView1.Item(16, i).Value


        EDIT1.TextBox1.Text = DataGridView1.Item(0, i).Value
        EDIT1.TextBox2.Text = DataGridView1.Item(1, i).Value
        EDIT1.TextBox3.Text = DataGridView1.Item(2, i).Value
        EDIT1.TextBox4.Text = DataGridView1.Item(3, i).Value
        EDIT1.TextBox5.Text = DataGridView1.Item(4, i).Value
        EDIT1.TextBox6.Text = DataGridView1.Item(5, i).Value
        EDIT1.TextBox7.Text = DataGridView1.Item(6, i).Value
        EDIT1.DateTimePicker1.Value = DataGridView1.Item(7, i).Value
        EDIT1.TextBox8.Text = DataGridView1.Item(8, i).Value
        EDIT1.TextBox9.Text = DataGridView1.Item(9, i).Value
        EDIT1.ComboBox1.SelectedItem = DataGridView1.Item(10, i).Value
        EDIT1.ComboBox2.SelectedItem = DataGridView1.Item(11, i).Value
        EDIT1.TextBox12.Text = DataGridView1.Item(12, i).Value
        EDIT1.TextBox10.Text = DataGridView1.Item(16, i).Value

        viewimage()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        NEWMEMBERS.Show()
    End Sub

    Private Sub Button2_ClientSizeChanged(sender As Object, e As EventArgs) Handles Button2.ClientSizeChanged

    End Sub

    Private Sub DataGridView1_CellStyleChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellStyleChanged
        viewimage()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Me.Show()

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick, DataGridView3.CellContentClick

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label42.Text = Date.Now.ToString("h:mm tt")
        Label43.Text = Date.Now.ToString("ss") + " Seconds"
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label44.Text = Date.Now.ToString("dddd, MMMM d, yyyy")
    End Sub

    Sub searchMENU()
        Dim i As Integer

        DataGridView1.Rows.Clear()
        str = "Select * from GYMEMBERSHIP where FIRSTNAME like '%" & TextBox1.Text & "%' or MIDDLENAME like '%" & TextBox1.Text & "%' or LASTNAME like '%" & TextBox1.Text & "%'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader

        While dr.Read
            DataGridView1.Rows.Add(dr("UID"), dr("FIRSTNAME"), dr("MIDDLENAME"), dr("LASTNAME"), dr("AGE"), dr("GENDER"), dr("CONTACT_NO"), dr("BIRTHDATE"), dr("EMAIL"), dr("ADDRESS"), dr("MEMBERSHIP_PLAN"), dr("MEMBERSHIP_STATUS"), dr("EXPIRATION"), dr("TIME_IN"), dr("TIME_DATE"), dr("IMAGE_USER"), dr("RFID"))

        End While

        If DataGridView1.Rows.Count = 0 Then

        End If


        dr.Close()
        cmd.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        searchMENU()
        rowheight()
        COLORDATA()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        searchMENU()
        rowheight()
        COLORDATA()

    End Sub
End Class