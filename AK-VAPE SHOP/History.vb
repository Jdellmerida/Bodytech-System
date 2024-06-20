Public Class History
    Private Sub History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        ' readdataclient()
        rowheight()
    End Sub
    Sub rowheight()
        For i = 0 To DataGridView1.Rows.Count - 1
            Dim r As DataGridViewRow = DataGridView1.Rows(i)
            r.Height = 60
        Next
    End Sub
    Sub readdataclient()
        DataGridView1.Rows.Clear()
        str = "Select * from GYMEMBERSHIP"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr("UID"), dr("FIRSTNAME"), dr("MIDDLENAME"), dr("LASTNAME"), dr("AGE"), dr("CONTACT_NO"), dr("EXPIRATION"), dr("TIME_IN"), dr("IMAGE_USER"))


        End While
        dr.Close()
        cmd.Dispose()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        ACCESS.TextBox1.Select()
    End Sub
End Class