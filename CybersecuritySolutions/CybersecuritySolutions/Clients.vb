Imports System.Configuration
Imports Microsoft.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Drawing.Text
Imports System.Text.RegularExpressions

Public Class Clients
    Public connectionString As String = "Data Source=localhost\SQLEXPRESS;Database=CybersecuritySolutions;Integrated Security=True;Encrypt=False;"
    Private allClientNames As New List(Of String)
    Private Sub Clients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadClientNames()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If String.IsNullOrWhiteSpace(txtClientName.Text) OrElse
           String.IsNullOrWhiteSpace(txtEmail.Text) OrElse
           String.IsNullOrWhiteSpace(txtPhone.Text) OrElse
           String.IsNullOrWhiteSpace(txtAddress.Text) Then
            MessageBox.Show("Please input data", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If NameExists("Clients", "Client", txtClientName.Text.Trim()) Then
            MessageBox.Show("Client name already exists. Please enter a unique name.", "Duplicate Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@Client", txtClientName.Text},
            {"@Email", txtEmail.Text},
            {"@phone", txtPhone.Text},
            {"@ClientAddress", txtAddress.Text}
        }

        ExecuteStoredProcedure("usp_AddNewClient", parameters)
        MessageBox.Show("Data Inserted Successfully")
        LoadClientNames()
        ClearForm()
    End Sub

    Private Function NameExists(tableName As String, columnName As String, nameToCheck As String) As Boolean
        Using connection As New SqlConnection(connectionString)
            Dim query As String = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = @Name"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Name", nameToCheck)
                connection.Open()
                Dim result As Object = command.ExecuteScalar()
                Return result IsNot Nothing AndAlso Convert.ToInt32(result) > 0
            End Using
        End Using
    End Function

    Private Sub ExecuteStoredProcedure(query As String, parameters As Dictionary(Of String, Object))
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.CommandType = CommandType.StoredProcedure
                For Each Param In parameters
                    command.Parameters.AddWithValue(Param.Key, Param.Value)
                Next
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub ExecuteNonQuery(query As String, parameters As Dictionary(Of String, Object))
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                For Each Param In parameters
                    command.Parameters.AddWithValue(Param.Key, Param.Value)
                Next
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub LoadClientNames()
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT DISTINCT Client FROM Clients ORDER BY Client"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim table As New DataTable()
            adapter.Fill(table)

            allClientNames.Clear()
            For Each row As DataRow In table.Rows
                allClientNames.Add(row("Client").ToString())
            Next

            cboClientName.AutoCompleteCustomSource.Clear()
            cboClientName.AutoCompleteCustomSource.AddRange(allClientNames.ToArray())
            cboClientName.DataSource = allClientNames.ToList() ' Use a copy so filtering doesn't change the original
            cboClientName.SelectedIndex = -1
        End Using
    End Sub
    Private Sub cboClientName_TextChanged(sender As Object, e As EventArgs) Handles cboClientName.TextChanged
        Dim filterText = cboClientName.Text.Trim().ToLower()
        If String.IsNullOrWhiteSpace(filterText) Then
            cboClientName.DataSource = allClientNames.ToList()
            Return
        End If

        Dim filtered = allClientNames.Where(Function(name) name.ToLower().StartsWith(filterText)).ToList()

        If filtered.Count > 0 Then
            cboClientName.DataSource = filtered
            cboClientName.DroppedDown = True
            cboClientName.SelectionStart = cboClientName.Text.Length
            cboClientName.SelectionLength = 0
        End If
    End Sub
    Private Sub cboClientName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClientName.SelectedIndexChanged
        If cboClientName.SelectedIndex = -1 Then Exit Sub

        Dim selectedClient As String = cboClientName.Text ' Not .SelectedValue for text filtering
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT Email, Phone, ClientAddress FROM Clients WHERE Client = @Client"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Client", selectedClient)
                connection.Open()
                Using reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        txtClientName.Text = selectedClient
                        txtEmail.Text = reader("Email").ToString()
                        txtPhone.Text = reader("Phone").ToString()
                        txtAddress.Text = reader("ClientAddress").ToString()
                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If cboClientName.SelectedIndex = -1 Then
            MessageBox.Show("Please select a client to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtEmail.Text) OrElse
           String.IsNullOrWhiteSpace(txtPhone.Text) OrElse
           String.IsNullOrWhiteSpace(txtAddress.Text) Then
            MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim query As String = "UPDATE Clients SET Email = @Email, Phone = @Phone, ClientAddress = @Address WHERE Client = @Client"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@Client", cboClientName.SelectedValue.ToString()},
            {"@Email", txtEmail.Text},
            {"@Phone", txtPhone.Text},
            {"@Address", txtAddress.Text}
        }

        ExecuteNonQuery(query, parameters)
        MessageBox.Show("Client updated successfully.")
        LoadClientNames()
        ClearForm()
    End Sub

    Private Sub btnDeleteClient_Click(sender As Object, e As EventArgs) Handles btnDeleteClient.Click
        If cboClientName.SelectedIndex = -1 Then
            MessageBox.Show("Please select a client to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtClientName.Text) OrElse
           String.IsNullOrWhiteSpace(txtEmail.Text) OrElse
           String.IsNullOrWhiteSpace(txtPhone.Text) OrElse
           String.IsNullOrWhiteSpace(txtAddress.Text) Then
            MessageBox.Show("There is no data to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim clientName As String = cboClientName.SelectedValue.ToString()
        Dim query As String = "DELETE FROM Clients WHERE Client = @Client"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@Client", clientName}
        }

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this client?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Try
                ExecuteNonQuery(query, parameters)
                MessageBox.Show("Client deleted successfully.")
                LoadClientNames()
                ClearForm()
            Catch ex As SqlException When ex.Number = 547
                MessageBox.Show("Cannot delete this client because it is referenced in other records (e.g., accounts, subscriptions, etc.).", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("An error occurred during deletion: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnShowClients_Click(sender As Object, e As EventArgs) Handles btnShowClients.Click
        Dim query As String = "SELECT * FROM Clients"
        Using connection As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, connection)
                Using adapter As New SqlDataAdapter(cmd)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    dgvClients.DataSource = table
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
        ClearForm()
    End Sub

    Private Sub BacktoMainMenu_Click(sender As Object, e As EventArgs) Handles BacktoMainMenu.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub ClearForm()
        txtClientName.Clear()
        txtEmail.Clear()
        txtPhone.Clear()
        txtAddress.Clear()
        cboClientName.SelectedIndex = -1
    End Sub
End Class