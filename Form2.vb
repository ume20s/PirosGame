Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            Form1.Timer2.Interval = 5
            Form1.LevelLabel.Text = "HARD"
            Form1.LevelLabel.Left = 290
        ElseIf RadioButton2.Checked = True Then
            Form1.Timer2.Interval = 50
            Form1.LevelLabel.Text = "NORMAL"
            Form1.LevelLabel.Left = 260
        Else
            Form1.Timer2.Interval = 500
            Form1.LevelLabel.Text = "EASY"
            Form1.LevelLabel.Left = 290
        End If
        Form1.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class