Imports System.Windows.Forms
Imports System.Net.Http
Imports Newtonsoft.Json

Public Class ViewSubmissionsForm
    Private currentIndex As Integer = 0
    Private submissions As List(Of Submission)

    Public Sub New()
        InitializeComponent()
        Me.KeyPreview = True
    End Sub

    Private Async Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(400, 200)
        Dim lblName As New Label()
        lblName.Text = "Basab Ghosh Slidely Task-2 Slidely Form App"
        lblName.Font = New Font("Arial", 10, FontStyle.Bold)
        lblName.AutoSize = True
        lblName.Location = New Point(10, 10)
        Me.Controls.Add(lblName)
        Me.KeyPreview = True
        Dim client As New HttpClient()
        Dim response As String = Await client.GetStringAsync("http://localhost:3000/submissions")
        submissions = JsonConvert.DeserializeObject(Of List(Of Submission))(response)
        DisplaySubmission()
    End Sub

    Private Sub DisplaySubmission()
        If submissions IsNot Nothing AndAlso submissions.Count > 0 AndAlso currentIndex >= 0 AndAlso currentIndex < submissions.Count Then
            txtName.Text = submissions(currentIndex).FullName
            txtEmail.Text = submissions(currentIndex).Email
            txtPhone.Text = submissions(currentIndex).Phone
            txtGithubLink.Text = submissions(currentIndex).GithubLink
            txtStopwatchTime.Text = submissions(currentIndex).StopwatchTime
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentIndex < submissions.Count - 1 Then
            currentIndex += 1
            DisplaySubmission()
        End If
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            DisplaySubmission()
        End If
    End Sub

    Private Sub ViewSubmissionsForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.Right Then
            btnNext.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.Left Then
            btnPrevious.PerformClick()
        End If
    End Sub
End Class

Public Class Submission
    Public Property FullName As String
    Public Property Email As String
    Public Property Phone As String
    Public Property GithubLink As String
    Public Property StopwatchTime As String
End Class
