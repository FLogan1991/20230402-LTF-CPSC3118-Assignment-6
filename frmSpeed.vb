Public Class frmSpeedTest
    Dim strSpeed As String
    Dim decSpeed As Decimal
    Dim decSumOfSpeeds As Decimal
    Dim decAverage As Decimal = 0D

    Dim strIBoxMsg As String = "Enter the number of Mbps of your home Internet speed user #"
    Dim strIBoxTitle As String = "Internet Speed"
    Dim strNotNumericErrMsg As String = "Error - Enter the speed of your home Internet connection"
    Dim strNegErrMsg As String = "Error - Enter a valid speed"

    Dim intMaxEntries As Integer = 10
    Dim intEntries As Integer = 1

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click, MyBase.Load

        'clears the labels, listbox, and enables btnSpeed is also used on load of the form
        lstSpeed.Items.Clear()
        lblSpeed.Text = ""
        btnSpeed.Enabled = True

    End Sub

    Private Sub btnSpeed_Click(sender As Object, e As EventArgs) Handles btnSpeed.Click

        'Takes input from the user and initializes the variable
        strSpeed = InputBox(strIBoxMsg & intEntries, strIBoxTitle)

        'Do loop set for the number of entries to not pass the number of max entries
        Do Until intEntries > intMaxEntries Or strSpeed = ""
            If IsNumeric(strSpeed) Then
                decSpeed = Convert.ToDecimal(strSpeed)
                strIBoxMsg = "Enter the number of Mbps of your home Internet speed user #"
                If decSpeed > 0 Then
                    lstSpeed.Items.Add(decSpeed)
                    decSumOfSpeeds += decSpeed
                    intEntries += 1
                    strIBoxMsg = "Enter the number of Mbps of your home Internet speed user #"
                Else
                    strIBoxMsg = strNegErrMsg
                End If
            Else
                strIBoxMsg = strNotNumericErrMsg
            End If
            If intEntries <= intMaxEntries Then
                strSpeed = InputBox(strIBoxMsg & intEntries, strIBoxTitle)
            End If
        Loop

        lblSpeed.Visible = True

        'calculates and displays the average of the speed
        If intEntries > 1 Then
            decAverage = decSumOfSpeeds / (intEntries - 1)
            lblSpeed.Text = "Average Internet Speed: " & decAverage.ToString("F2") & " Mbps "
        Else
            lblSpeed.Text = "No Speed Values Entered"
        End If


        btnSpeed.Enabled = False
    End Sub
End Class
