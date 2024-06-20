Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class NewSubmissionForm
    Private stopwatch As New Stopwatch()

    Public Sub New()
        InitializeComponent()
        Me.KeyPreview = True
    End Sub

    Private Async Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim newSubmission As New Submission With {
            .FullName = txtName.Text,
            .Email = txtEmail.Text,
            .Phone = txtPhone.Text,
            .GithubLink = txtGithubLink.Text,
            .StopwatchTime = txtStopwatchTime.Text
        }

        Dim json As String = JsonConvert.SerializeObject(newSubmission)
        Dim content As New StringContent(json, Encoding.UTF8, "application/json")
        Dim client As New HttpClient()

        Dim response As HttpResponseMessage = Await client.PostAsync("http://localhost:3000/submit", content)
        If response.IsSuccessStatusCode Then
            MessageBox.Show("Submission successful!")
        Else
            MessageBox.Show("Submission failed.")
        End If
    End Sub

    Private Sub btnStopwatch_Click(sender As Object, e As EventArgs) Handles btnStopwatch.Click
        If stopwatch.IsRunning Then
            stopwatch.Stop()
            btnStopwatch.Text = "Resume"
        Else
            stopwatch.Start()
            btnStopwatch.Text = "Pause"
        End If
        txtStopwatchTime.Text = stopwatch.Elapsed.ToString("hh\:mm\:ss")
    End Sub

    Private Sub NewSubmissionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.S Then
            btnSubmit.PerformClick()
        End If
    End Sub
End Class
