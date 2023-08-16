Imports System.IO

Public Class Form1
    Dim fnum As Decimal
    Dim snum As Decimal
    Dim result As Decimal

    Private Sub ButtonClickMethod(sender As Object, e As EventArgs) Handles btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn0.Click, btnaddition.Click, btnsubstruct.Click, btnmultiply.Click, btndivide.Click, btn12.Click, btnleft.Click, btnright.Click, btnAC.Click
        Dim button As Button = CType(sender, Button)
        TextBox1.Text = TextBox1.Text & button.Text
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If TextBox1.Text.Length > 0 Then
            TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1, 1)
        End If
    End Sub

    Private Sub btnsquared_Click(sender As Object, e As EventArgs) Handles btnsquared.Click
        If Decimal.TryParse(TextBox1.Text, fnum) Then
            TextBox1.Text = TextBox1.Text & "^2"
            result = fnum ^ 2
            TextBox2.Text = result.ToString()
        Else
            TextBox2.Text = "Invalid input"
        End If
    End Sub

    Private Sub btncube_Click(sender As Object, e As EventArgs) Handles btncube.Click
        If Decimal.TryParse(TextBox1.Text, fnum) Then
            TextBox1.Text = TextBox1.Text & "^3"
            result = fnum ^ 3
            TextBox2.Text = result.ToString()
        Else
            TextBox2.Text = "Invalid input"
        End If
    End Sub

    Private Sub btnmod_Click(sender As Object, e As EventArgs) Handles btnmod.Click
        If Decimal.TryParse(TextBox1.Text, fnum) AndAlso Decimal.TryParse(TextBox1.Text, snum) Then
            TextBox1.Text = TextBox1.Text & "%"
            result = fnum Mod snum
            TextBox2.Text = result.ToString()
        Else
            TextBox2.Text = "Invalid input"
        End If
    End Sub

    Private Sub btnln_Click(sender As Object, e As EventArgs) Handles btnln.Click
        If Double.TryParse(TextBox1.Text, fnum) Then
            result = Math.Log(fnum)
            TextBox2.Text = "ln(" & fnum.ToString() & ") = " & result.ToString()
        Else
            TextBox2.Text = "Invalid input"
        End If
    End Sub

    Private Sub btnlog_Click(sender As Object, e As EventArgs) Handles btnlog.Click
        If Double.TryParse(TextBox1.Text, fnum) Then
            result = Math.Log10(fnum)
            TextBox2.Text = "Log(" & fnum.ToString() & ") = " & result.ToString()
        Else
            TextBox2.Text = "Invalid input"
        End If
    End Sub

    Private Sub btnfactorial_Click(sender As Object, e As EventArgs) Handles btnfactorial.Click
        If Integer.TryParse(TextBox1.Text, fnum) Then
            result = 1
            If fnum >= 0 Then
                For i As Integer = 1 To fnum
                    result *= i
                Next
                TextBox2.Text = fnum.ToString() & "! = " & result.ToString()
            Else
                TextBox2.Text = "Invalid input"
            End If
        Else
            TextBox2.Text = "Invalid input"
        End If
    End Sub

    Private Sub btnsquareroot_Click(sender As Object, e As EventArgs) Handles btnsquareroot.Click
        If Double.TryParse(TextBox1.Text, fnum) AndAlso fnum >= 0 Then
            result = Math.Sqrt(fnum)
            TextBox2.Text = "√" & fnum.ToString() & " = " & result.ToString()
        Else
            TextBox2.Text = "Invalid input"
        End If
    End Sub

    Private Sub btnpi_Click(sender As Object, e As EventArgs) Handles btnpi.Click
        If Double.TryParse(TextBox1.Text, fnum) Then
            TextBox2.Text = fnum.ToString() & "π = " & (fnum * Math.PI).ToString()
        Else
            TextBox2.Text = "Invalid input"
        End If
    End Sub

    Private Sub btnsin_Click(sender As Object, e As EventArgs) Handles btnsin.Click
        If Double.TryParse(TextBox1.Text, fnum) Then
            result = Math.Sin(fnum)
            TextBox2.Text = "Sin(" & fnum.ToString() & ") = " & result.ToString()
        Else
            TextBox2.Text = "Invalid input"
        End If
    End Sub

    Private Sub btncos_Click(sender As Object, e As EventArgs) Handles btncos.Click
        If Double.TryParse(TextBox1.Text, fnum) Then
            result = Math.Cos(fnum)
            TextBox2.Text = "Cos(" & fnum.ToString() & ") = " & result.ToString()
        Else
            TextBox2.Text = "Invalid input"
        End If
    End Sub

    Private Sub btntan_Click(sender As Object, e As EventArgs) Handles btntan.Click
        If Double.TryParse(TextBox1.Text, fnum) Then
            result = Math.Tan(fnum)
            TextBox2.Text = "Tan(" & fnum.ToString() & ") = " & result.ToString()
        Else
            TextBox2.Text = "Invalid input"
        End If
    End Sub

    Private Sub btnpercent_Click(sender As Object, e As EventArgs) Handles btnpercent.Click
        If Double.TryParse(TextBox1.Text, fnum) Then
            result = fnum / 100
            TextBox2.Text = fnum.ToString() & "% = " & result.ToString()
        Else
            TextBox2.Text = "Invalid input"
        End If
    End Sub

    Private Sub btn10_Click(sender As Object, e As EventArgs) Handles btn10.Click
        Form2.Show()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            btnanswer.PerformClick()
            e.Handled = True ' Prevent the "beep" sound
        End If
    End Sub

    Private Sub btnanswer_Click(sender As Object, e As EventArgs) Handles btnanswer.Click
        Dim equation As String = TextBox1.Text
        Try
            result = New DataTable().Compute(equation, Nothing)
            TextBox2.Text = result.ToString()
        Catch ex As Exception
            TextBox2.Text = "Syntax Error"
        End Try
    End Sub

    Private Sub btnAC_Click(sender As Object, e As EventArgs) Handles btnAC.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
End Class
