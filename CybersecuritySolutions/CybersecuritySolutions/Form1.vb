Imports System.Configuration
Imports Microsoft.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Drawing.Text
Public Class Form1
    Public connectionString As String = "Data Source=localhost\SQLEXPRESS;Database=CybersecuritySolutions;Integrated Security=True;Encrypt=False;"
    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                MessageBox.Show("Connection Successful")
            End Using
        Catch ex As SqlException
            MessageBox.Show("SQL Error: " & ex.Message)
        Catch ex As Exception
            MessageBox.Show($"Connection Failed:{ex.Message}")
        End Try
    End Sub

    Private Sub btnOpenClients_Click(sender As Object, e As EventArgs) Handles btnOpenClients.Click
        Clients.Show()
        Me.Hide()
    End Sub

    Private Sub btnOpenAccounts_Click(sender As Object, e As EventArgs) Handles btnOpenAccounts.Click
        Accounts.Show()
        Me.Hide()
    End Sub

    Private Sub btnOpenServices_Click(sender As Object, e As EventArgs) Handles btnOpenServices.Click
        ServicesProvided.Show()
        Me.Hide()
    End Sub

    Private Sub btnOpencyberIncidents_Click(sender As Object, e As EventArgs) Handles btnOpencyberIncidents.Click
        CybersecurityIncidents.Show()
        Me.Hide()
    End Sub

    Private Sub btnSubscriptions_Click(sender As Object, e As EventArgs) Handles btnSubscriptions.Click
        Subscriptions.Show()
        Me.Hide()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
