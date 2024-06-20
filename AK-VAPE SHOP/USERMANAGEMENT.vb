Imports System.Diagnostics.Tracing
Imports System.IO

Public Class USERMANAGEMENT
    Private Sub CANCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CANCELToolStripMenuItem.Click
        Me.Hide()
        Dashboard.Show()
    End Sub

    Private Sub ADDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ADDToolStripMenuItem.Click



        Dim a As String
        Dim b As Boolean = False
        Dim c As Char
        Dim d As Integer


        Dim password As String = TextBox8.Text
        a = TextBox8.Text
        If Char.IsUpper(password, 0) Then
            If a.Length < 6 Then
                MessageBox.Show("Password must be at least 6 characters long.")
                TextBox8.Focus()

            Else
                For d = 0 To a.Length - 1
                    c = a.Chars(d)
                    If Not Char.IsLetterOrDigit(c) Then
                        b = True
                        Exit For
                    End If
                Next
                If b Then

                    If TextBox10.Text = "" Then
                        MsgBox("YOU NEED TO GENERATED RFID")

                    Else
                        If PictureBox1.Image Is Nothing Then
                            MessageBox.Show("Error: No image loaded in the PictureBox.")
                        Else



                            add()
                            readdataclient()
                            rowheight()
                            CLEAR()
                            MsgBox(" Succesfuly Created")

                        End If

                    End If



                        Else
                    MsgBox("Your password must contain at least one special characters")

                End If
            End If
        Else
            MessageBox.Show("The password must contain at least one Uppercase Letter")
        End If








        ' If ComboBox1.SelectedItem = "SUPER ADMIN" Then
        ' Label12.Text = "1"
        '  Else
        ' Label12.Text = "0"
        ' End If


        ' If Label12.Text <> Label11.Text Then


        ' Else
        ' MsgBox("Only 1 superadmin only")

        ' End If



    End Sub

    Sub CLEAR()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox7.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox8.Clear()
        PictureBox1.Image = My.Resources.NONE
        TextBox10.Clear()


    End Sub
    Sub add()
        Dim cntun, cntflb As String
        Dim ms As New MemoryStream
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)

        str = "Select COUNT(UID) as cntun from ACCOUNTS where USERNAME = '" & TextBox2.Text & "'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            cntun = dr.GetValue(0)
        End While
        dr.Close()
        cmd.Dispose()

        If cntun = "1" Then
            MsgBox("Username Already Exist")
        End If

        str = "Select COUNT(UID) as cntflb from ACCOUNTS where PASSWORD = '" & TextBox8.Text & "' and FNAME = '" & TextBox4.Text & "' and MNAME = '" & TextBox5.Text & "' and LNAME = '" & TextBox6.Text & "' and USERLEVEL = '" & ComboBox1.SelectedItem & "' and BIO = '" & TextBox7.Text & "' and RFID = '" & TextBox10.Text & "'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            cntflb = dr.GetValue(0)
        End While
        dr.Close()
        cmd.Dispose()

        If cntflb = "1" Then
            MsgBox("User Already Exist")
        End If

        If cntun = "0" And cntflb = "0" Then


            query = "insert into ACCOUNTS (USERNAME,PASSWORD,FNAME,MNAME,LNAME,USERLEVEL,IMAGE,BIO,RFID) values (@USERNAME,@PASSWORD,@FNAME,@MNAME,@LNAME,@USERLEVEL,@IMAGE,@BIO,@RFID)"
            cmd = New SqlClient.SqlCommand(query, sqlconn)

            With cmd


                .Parameters.AddWithValue("@USERNAME", TextBox2.Text)
                .Parameters.AddWithValue("@PASSWORD", TextBox8.Text)
                .Parameters.AddWithValue("@FNAME", TextBox4.Text)
                .Parameters.AddWithValue("@MNAME", TextBox5.Text)
                .Parameters.AddWithValue("@LNAME", TextBox6.Text)
                .Parameters.AddWithValue("@USERLEVEL", ComboBox1.SelectedItem)
                .Parameters.AddWithValue("@IMAGE", ms.ToArray)
                .Parameters.AddWithValue("@BIO", TextBox7.Text)
                .Parameters.AddWithValue("@RFID", TextBox10.Text)



            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End If
        dr.Close()
        cmd.Dispose()

    End Sub

    Sub readdataclient()
        DataGridView1.Rows.Clear()
        str = "Select * from ACCOUNTS"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr("UID"), dr("USERNAME"), dr("PASSWORD"), dr("FNAME"), dr("MNAME"), dr("LNAME"), dr("USERLEVEL"), dr("IMAGE"), dr("BIO"), dr("RFID"))


        End While
        dr.Close()
        cmd.Dispose()

    End Sub
    Sub rowheight()
        For i = 0 To DataGridView1.Rows.Count - 1
            Dim r As DataGridViewRow = DataGridView1.Rows(i)
            r.Height = 100
        Next
    End Sub
    Private Sub USERMANAGEMENT_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        connect()
        readdataclient()
        rowheight()
    End Sub

    Private Sub UPDATEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UPDATEToolStripMenuItem.Click
        updateclient()
        MsgBox("Successfully Update", MsgBoxStyle.Information, "Safe")
        readdataclient()
        rowheight()
        CLEAR()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DELETEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DELETEToolStripMenuItem.Click
        If Label13.Text <> TextBox1.Text Then

            If Label14.Text <> ComboBox1.SelectedItem Then

                If Label10.Text = "SUPER ADMIN" Then
                    MsgBox("You cannot delete SuperAdmin")
                Else
                    Dim i As Integer = DataGridView1.CurrentRow.Index
                    Deleteclient(DataGridView1.Item(0, i).Value)
                    readdataclient()
                    rowheight()
                    MsgBox("Successfully Deleted", MsgBoxStyle.Information, "Not Safe")
                End If

            Else

                MsgBox("You cannot delete Same USER LEVEL")

            End If

        Else
            MsgBox("You cannot delete Current user")
        End If

    End Sub
    Sub Deleteclient(ByVal CID As String)
        query = "Delete from ACCOUNTS where UID = @UID"
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@UID", CID)







        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub







    Sub updateclient()
        Dim ms As New MemoryStream
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        query = "Update ACCOUNTS set USERNAME = @USERNAME ,PASSWORD = @PASSWORD ,FNAME = @FNAME,MNAME = @MNAME,LNAME = @LNAME, USERLEVEL = @USERLEVEL, IMAGE = @IMAGE, BIO = @BIO, RFID = @RFID  where UID = @UID "
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@UID", TextBox1.Text)
            .Parameters.AddWithValue("@USERNAME", TextBox2.Text)
            .Parameters.AddWithValue("@PASSWORD", TextBox8.Text)
            .Parameters.AddWithValue("@FNAME", TextBox4.Text)
            .Parameters.AddWithValue("@MNAME", TextBox5.Text)
            .Parameters.AddWithValue("@LNAME", TextBox6.Text)
            .Parameters.AddWithValue("@USERLEVEL", ComboBox1.SelectedItem)
            .Parameters.AddWithValue("@IMAGE", MS.ToArray)
            .Parameters.AddWithValue("@BIO", TextBox7.Text)
            .Parameters.AddWithValue("@RFID", TextBox10.Text)



        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    Sub viewimage()
        Dim img() As Byte
        str = "Select * from ACCOUNTS where UID = '" & TextBox1.Text & "'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            img = dr("IMAGE")
            Dim ms As New MemoryStream(img)
            PictureBox1.Image = Image.FromStream(ms)


        End While
        dr.Close()
        cmd.Dispose()
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer = DataGridView1.CurrentRow.Index

        TextBox1.Text = DataGridView1.Item(0, i).Value
        TextBox2.Text = DataGridView1.Item(1, i).Value
        TextBox8.Text = DataGridView1.Item(2, i).Value
        TextBox4.Text = DataGridView1.Item(3, i).Value
        TextBox5.Text = DataGridView1.Item(4, i).Value
        TextBox6.Text = DataGridView1.Item(5, i).Value
        ComboBox1.SelectedItem = DataGridView1.Item(6, i).Value
        Label10.Text = DataGridView1.Item(6, i).Value
        viewimage()
        TextBox7.Text = DataGridView1.Item(8, i).Value
        TextBox10.Text = DataGridView1.Item(9, i).Value
        ' If Label10.Text = "SUPER ADMIN" Then
        'MsgBox("YOU CAN'T EDIT THIS USER")
        'CLEAR()
        'TextBox8.Clear()
        'omboBox1.SelectedItem = "NONE"
        ' Label11.Text = "1"
        ' End If



    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg"

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.Image = System.Drawing.Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub CLEARToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CLEARToolStripMenuItem.Click
        CLEAR()
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        If TextBox9.Text.Length > 9 Then
            MsgBox("d")
            MessageBox.Show("SUCCESFULLY SCANNED", "RFID")
            Label16.Text = "GENERATED RFID"
            Label16.ForeColor = Color.DarkGreen
            TextBox9.Enabled = False

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox10.Text = TextBox9.Text
        Label16.Text = "PLEASE SCAN RFID"
        Label16.ForeColor = Color.Black
        TextBox9.Enabled = True
        TextBox9.Clear()
        Panel1.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel1.Hide()
    End Sub

    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs) Handles ToolStripComboBox1.Click
        Panel1.Show()
        TextBox9.Select()

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting

        If (e.ColumnIndex = 2 AndAlso e.Value IsNot Nothing) Then
            e.Value = New String("•", e.Value.ToString().Length)
        End If
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox8.PasswordChar = ""
        Else
            TextBox8.PasswordChar = "*"
        End If
    End Sub
End Class