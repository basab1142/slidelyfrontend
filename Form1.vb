Imports System.Windows.Forms

Public Class Form1
    Private Sub btnViewSubmissions_Click(sender As Object, e As EventArgs) Handles btnViewSubmissions.Click
        Dim viewSubmissionsForm As New ViewSubmissionsForm()
        viewSubmissionsForm.Show()
    End Sub

    Private Sub btnCreateNewSubmission_Click(sender As Object, e As EventArgs) Handles btnCreateNewSubmission.Click
        Dim newSubmissionForm As New NewSubmissionForm()
        newSubmissionForm.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(400, 200)
        btnViewSubmissions.BackColor = Color.LightYellow
        btnCreateNewSubmission.BackColor = Color.LightBlue

        Dim lblName As New Label()
        lblName.Text = "Basab Ghosh Slidely Task-2 Slidely Form App"
        lblName.Font = New Font("Arial", 10, FontStyle.Bold)
        lblName.AutoSize = True
        lblName.Location = New Point(10, 10)
        Me.Controls.Add(lblName)
        Me.KeyPreview = True
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            btnViewSubmissions.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.N Then
            btnCreateNewSubmission.PerformClick()
        End If
    End Sub
End Class
