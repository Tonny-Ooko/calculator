Public Class CalculatorForm
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        Operand1TextBox.Clear()
        Operand2TextBox.Clear()
        ResultTextBox.Clear()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub CalculateButton_Click(sender As Object, e As EventArgs) Handles CalculateButton.Click
        Dim operand1 As Double
        Dim operand2 As Double

        If Double.TryParse(Operand1TextBox.Text, operand1) AndAlso Double.TryParse(Operand2TextBox.Text, operand2) Then
            Dim result As Double
            Dim operatorSymbol As String = OperatorComboBox.SelectedItem.ToString()

            Select Case operatorSymbol
                Case "+"
                    result = operand1 + operand2
                Case "-"
                    result = operand1 - operand2
                Case "*"
                    result = operand1 * operand2
                Case "/"
                    If operand2 <> 0 Then
                        result = operand1 / operand2
                    Else
                        MessageBox.Show("Error: Division by zero is not allowed.")
                        Return
                    End If
                Case "\"
                    If operand2 <> 0 Then
                        result = Math.Floor(operand1 / operand2)
                    Else
                        MessageBox.Show("Error: Division by zero is not allowed.")
                        Return
                    End If
                Case "^"
                    result = Math.Pow(operand1, operand2)
                Case "Mod"
                    If operand2 <> 0 Then
                        result = operand1 Mod operand2
                    Else
                        MessageBox.Show("Error: Division by zero is not allowed.")
                        Return
                    End If
                Case Else
                    MessageBox.Show("Error: Invalid operator selected.")
                    Return
            End Select

            ResultTextBox.Text = result.ToString()
        Else
            MessageBox.Show("Error: Invalid operands entered.")
        End If
    End Sub
End Class
