Imports System.Data.SqlClient

Public Class Report
    Private Sub Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Using con As New SqlConnection("Data Source=LAPTOP-CQIQDMO8\MERIDA;Initial Catalog=Bodytech;Integrated Security=True;Encrypt=False")
            Dim dt As New DataTable

            con.Open()
            Using cmd As New SqlCommand("Select * from [TRANSACTION]", con)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd

                da.Fill(dt)
            End Using
            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "C:\Users\crazy\OneDrive\Desktop\Bodytech laptop\AK-VAPE SHOP\Report.rdlc"
                .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
            End With

        End Using
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        Dashboard.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        Using con As New SqlConnection("Data Source=LAPTOP-CQIQDMO8\MERIDA;Initial Catalog=Bodytech;Integrated Security=True;Encrypt=False")
            Dim dt As New DataTable

            con.Open()
            Using cmd As New SqlCommand("Select * from [TRANSACTION] where MEMBERSHIP_SUBS = '" & ComboBox1.SelectedItem & "'", con)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd

                da.Fill(dt)
            End Using
            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "C:\Users\crazy\OneDrive\Desktop\Bodytech laptop\AK-VAPE SHOP\Report.rdlc"
                .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
            End With

        End Using
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Using con As New SqlConnection("Data Source=LAPTOP-CQIQDMO8\MERIDA;Initial Catalog=Bodytech;Integrated Security=True;Encrypt=False")
            Dim dt As New DataTable

            con.Open()
            Using cmd As New SqlCommand("Select * from [TRANSACTION]", con)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd

                da.Fill(dt)
            End Using
            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "C:\Users\crazy\OneDrive\Desktop\Bodytech laptop\AK-VAPE SHOP\Report.rdlc"
                .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
            End With

        End Using
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As String
        Dim b As String

        a = TextBox1.Text
        b = TextBox2.Text

        Using con As New SqlConnection("Data Source=LAPTOP-CQIQDMO8\MERIDA;Initial Catalog=Bodytech;Integrated Security=True;Encrypt=False")
            Dim dt As New DataTable

            con.Open()
            Using cmd As New SqlCommand("Select * from [TRANSACTION] where DATE>='" & b & "' and DATE<='" & a & "' order by DATE desc", con)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd

                da.Fill(dt)
            End Using
            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "C:\Users\crazy\OneDrive\Desktop\Bodytech laptop\AK-VAPE SHOP\Report.rdlc"
                .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
            End With

        End Using
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = Date.Now.ToString("dddd, MMMM d, yyyy")
        TextBox2.Text = Date.Now.ToString("dddd, MMMM d, yyyy")
    End Sub
End Class