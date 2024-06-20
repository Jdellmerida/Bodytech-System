Imports System.IO

Public Class PAYMENT
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



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        NEWMEMBERS.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click, Label8.Click, Label12.Click, Label10.Click, Label14.Click, Label16.Click, Label20.Click, Label18.Click, Label21.Click, Label40.Click

    End Sub

    Private Sub Label33_Click(sender As Object, e As EventArgs) Handles Label33.Click, Label41.Click

    End Sub

    Private Sub PAYMENT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If NEWMEMBERS.ComboBox1.SelectedItem = "MONTHLY" Then
            Label33.Text = "700₱"
            Label34.Text = "700"
        Else
            Label33.Text = "6,999₱"
            Label34.Text = "6,999"
        End If
    End Sub

    Sub addMEMBERS()
        Dim cntun, cntflb As String
        Dim ms As New MemoryStream
        Guna2CirclePictureBox1.Image.Save(ms, Guna2CirclePictureBox1.Image.RawFormat)

        str = "Select COUNT(UID) as cntun from GYMEMBERSHIP where FIRSTNAME = '" & Label5.Text & "'"
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

        str = "Select COUNT(UID) as cntflb from GYMEMBERSHIP where MIDDLENAME = '" & Label6.Text & "' and LASTNAME = '" & Label7.Text & "' and AGE = '" & Label9.Text & "' and GENDER = '" & Label11.Text & "' and ADDRESS = '" & TextBox1.Text & "' and CONTACT_NO = '" & Label13.Text & "' and BIRTHDATE = '" & Label15.Text & "' and EMAIL = '" & Label17.Text & "' and MEMBERSHIP_PLAN = '" & Label19.Text & "' and MEMBERSHIP_STATUS = '" & NEWMEMBERS.ComboBox2.SelectedItem & "' and EXPIRATION = '" & Label22.Text & "' and RFID = '" & Label32.Text & "'"
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


            query = "insert into GYMEMBERSHIP (UID,FIRSTNAME,MIDDLENAME,LASTNAME,AGE,GENDER,ADDRESS,CONTACT_NO,BIRTHDATE,EMAIL,MEMBERSHIP_PLAN,MEMBERSHIP_STATUS,EXPIRATION,IMAGE_USER,RFID) values (@UID,@FIRSTNAME,@MIDDLENAME,@LASTNAME,@AGE,@GENDER,@ADDRESS,@CONTACT_NO,@BIRTHDATE,@EMAIL,@MEMBERSHIP_PLAN,@MEMBERSHIP_STATUS,@EXPIRATION,@IMAGE_USER,@RFID)"
            cmd = New SqlClient.SqlCommand(query, sqlconn)

            With cmd


                .Parameters.AddWithValue("@UID", Label3.Text)
                .Parameters.AddWithValue("@FIRSTNAME", Label5.Text)
                .Parameters.AddWithValue("@MIDDLENAME", Label6.Text)
                .Parameters.AddWithValue("@LASTNAME", Label7.Text)
                .Parameters.AddWithValue("@AGE", Label9.Text)
                .Parameters.AddWithValue("@GENDER", Label11.Text)
                .Parameters.AddWithValue("@ADDRESS", TextBox1.Text)
                .Parameters.AddWithValue("@CONTACT_NO", Label13.Text)
                .Parameters.AddWithValue("@BIRTHDATE", Label15.Text)
                .Parameters.AddWithValue("@EMAIL", Label17.Text)
                .Parameters.AddWithValue("@MEMBERSHIP_PLAN", Label19.Text)
                .Parameters.AddWithValue("@MEMBERSHIP_STATUS", NEWMEMBERS.ComboBox2.SelectedItem)
                .Parameters.AddWithValue("@EXPIRATION", Label22.Text)
                .Parameters.AddWithValue("@IMAGE_USER", ms.ToArray)
                .Parameters.AddWithValue("@RFID", Label32.Text)



            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End If
        dr.Close()
        cmd.Dispose()

    End Sub


    Sub addTRansac()
        Dim cntun, cntflb As String


        str = "Select COUNT(UID) as cntun from [TRANSACTION] where FIRSTNAME = '" & Label5.Text & "'"
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

        str = "Select COUNT(UID) as cntflb from [TRANSACTION] where MIDDLENAME = '" & Label6.Text & "' and LASTNAME = '" & Label7.Text & "' and MEMBERSHIP_SUBS = '" & Label19.Text & "' and AMOUNT_DUE = '" & Label33.Text & "' and PAYMENT = '" & TextBox2.Text & "' and CHANGE = '" & Label38.Text & "' and USERSTAMP = '" & TextBox3.Text & "' and DATE = '" & Label27.Text & "'"
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


            query = "insert into [TRANSACTION] (UID,FIRSTNAME,MIDDLENAME,LASTNAME,MEMBERSHIP_SUBS,AMOUNT_DUE,PAYMENT,CHANGE,USERSTAMP,DATE) values (@UID,@FIRSTNAME,@MIDDLENAME,@LASTNAME,@MEMBERSHIP_SUBS,@AMOUNT_DUE,@PAYMENT,@CHANGE,@USERSTAMP,@DATE)"
            cmd = New SqlClient.SqlCommand(query, sqlconn)

            With cmd


                .Parameters.AddWithValue("@UID", Label3.Text)
                .Parameters.AddWithValue("@FIRSTNAME", Label5.Text)
                .Parameters.AddWithValue("@MIDDLENAME", Label6.Text)
                .Parameters.AddWithValue("@LASTNAME", Label7.Text)
                .Parameters.AddWithValue("@MEMBERSHIP_SUBS", Label19.Text)
                .Parameters.AddWithValue("@AMOUNT_DUE", Label33.Text)
                .Parameters.AddWithValue("@PAYMENT", TextBox2.Text)
                .Parameters.AddWithValue("@CHANGE", Label38.Text)
                .Parameters.AddWithValue("@USERSTAMP", TextBox3.Text)
                .Parameters.AddWithValue("@DATE", Label27.Text)





            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End If
        dr.Close()
        cmd.Dispose()

    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim p As Integer
        Dim sum As Integer
        If TextBox2.Text = "" Then
            MsgBox("PLEASE INPUT AMOUNT!!", vbCritical, "PAYMENT FAILED")
        Else
            p = Val(TextBox2.Text)

            If (p < Label36.Text) Then
                MsgBox("PAYMENT UNABLE TO PROCESS", vbCritical, "PAYMENT FAILED")

            Else

                sum = TextBox2.Text - Label36.Text
                Label38.Text = sum
                MsgBox("PAYMENT RECEIVED!")
                TextBox3.Text = "COMPLETE"
                addMEMBERS()
                addTRansac()
                Button2.Hide()
                Button1.Visible = False
                Button5.Visible = True
                'TextBox2.Enabled = False
                ComboBox1.Enabled = False
                Button4.Enabled = False
                NEWMEMBERS.Close()
                Gymembers.Close()
                Gymembers.Show()
                Transaction.Close()
                Me.Hide()
                Me.Show()


            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        If Label19.Text = "YEARLY" Then
            If ComboBox1.SelectedItem = "STUDENT" Then
                Label35.Text = "125"

                Dim sum As Integer
                sum = Label34.Text - Label35.Text
                Label36.Text = sum
                TextBox2.Enabled = True


            End If

        Else
            If ComboBox1.SelectedItem = "STUDENT" Then
                Label35.Text = "50"

                Dim sum As Integer
                sum = Label34.Text - Label35.Text
                Label36.Text = sum
                TextBox2.Enabled = True

            End If
        End If

        If Label19.Text = "YEARLY" Then
            If ComboBox1.SelectedItem = "PWD" Then
                Label35.Text = "200"

                Dim sum As Integer
                sum = Label34.Text - Label35.Text
                Label36.Text = sum
                TextBox2.Enabled = True

            End If



        Else
            If ComboBox1.SelectedItem = "PWD" Then
                Label35.Text = "95"

                Dim sum As Integer
                sum = Label34.Text - Label35.Text
                Label36.Text = sum
                TextBox2.Enabled = True

            End If
        End If

        If Label19.Text = "YEARLY" Then

            If ComboBox1.SelectedItem = "ANNIVERSARY PROMO" Then
                Label35.Text = "4,000"

                Dim sum As Integer
                sum = Label34.Text - Label35.Text
                Label36.Text = sum
                TextBox2.Enabled = True
            End If
        Else
            If ComboBox1.SelectedItem = "ANNIVERSARY PROMO" Then
                Label35.Text = "250"

                Dim sum As Integer
                sum = Label34.Text - Label35.Text
                Label36.Text = sum
                TextBox2.Enabled = True
            End If
        End If

        If ComboBox1.SelectedItem = "NONE" Then
            Label35.Text = "0"

            Label36.Text = Label34.Text
            TextBox2.Enabled = True
        End If

        If Label19.Text = "YEARLY" Then

            If ComboBox1.SelectedItem = "SENIOR CITIZEN" Then
                Label35.Text = "190"

                Dim sum As Integer
                sum = Label34.Text - Label35.Text
                Label36.Text = sum
                TextBox2.Enabled = True
            End If
        Else
            If ComboBox1.SelectedItem = "SENIOR CITIZEN" Then
                Label35.Text = "80"

                Dim sum As Integer
                sum = Label34.Text - Label35.Text
                Label36.Text = sum
                TextBox2.Enabled = True
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label27.Text = Date.Now.ToString("dddd, MMMM d, yyyy")
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Label34_Click(sender As Object, e As EventArgs) Handles Label34.Click

    End Sub
End Class