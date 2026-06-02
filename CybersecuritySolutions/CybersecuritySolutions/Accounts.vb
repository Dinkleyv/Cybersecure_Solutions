Imports System.Configuration
Imports Microsoft.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Drawing.Text

Public Class Accounts
    Public connectionString As String = "Data Source=localhost\SQLEXPRESS;Database=CybersecuritySolutions;Integrated Security=True;Encrypt=False;"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BacktoMainMenu.Click
        Form1.Show()
        Me.Hide()


    End Sub
    Private Sub ClearForm()
        cboAccount.SelectedIndex = -1
        cboClient.SelectedIndex = -1
        'considerign that the date should be automatically  inserted into the database 
        'the user should not have the option of selecting
        'date will be automatically updated
        ' to make it appear blank
        dtpDateCreated.Format = DateTimePickerFormat.Custom
        'dtpDateCreated.CustomFormat = " "
        dtpDateCreated.ShowCheckBox = False
        dtpDateCreated.Checked = False
        '
        dtpLastUpdated.Format = DateTimePickerFormat.Custom
        'dtpLastUpdated.CustomFormat = " "
        dtpLastUpdated.ShowCheckBox = True
        dtpLastUpdated.Checked = False


    End Sub
    Private Sub ExecuteStoredProcedure(query As String, parameters As Dictionary(Of String, Object))
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.CommandType = CommandType.StoredProcedure
                For Each Param In parameters
                    command.Parameters.AddWithValue(Param.Key, Param.Value)
                Next
                'opens the connection to the database
                connection.Open()
                'executes the query
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Private Sub cboAccountIDs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAccountIDs.SelectedIndexChanged
        If cboAccountIDs.SelectedValue Is Nothing Then Exit Sub

        Dim selectedID As Integer
        If Integer.TryParse(cboAccountIDs.SelectedValue.ToString(), selectedID) Then
            Using connection As New SqlConnection(connectionString)
                Dim query As String = "SELECT * FROM Accounts WHERE AccountID = @AccountID"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@AccountID", selectedID)
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            cboAccount.SelectedItem = reader("AccountName").ToString()
                            cboClient.SelectedValue = reader("ClientID")
                            'dtpLastUpdated.Value = reader("DateCreated")
                            dtpDateCreated.Value = reader("DateCreated")
                            dtpDateCreated.Format = DateTimePickerFormat.Short
                            dtpDateCreated.Checked = True
                            If Not Convert.IsDBNull(reader("lastModifiedDate")) Then
                                dtpLastUpdated.Value = Convert.ToDateTime(reader("lastModifiedDate"))
                                dtpLastUpdated.Format = DateTimePickerFormat.Short
                                dtpLastUpdated.Checked = True
                            Else
                                dtpLastUpdated.Checked = False
                                dtpLastUpdated.Format = DateTimePickerFormat.Custom
                                dtpLastUpdated.CustomFormat = " "
                            End If
                        Else
                            ClearForm()
                        End If
                    End Using
                End Using
            End Using
        End If
    End Sub
    Private Sub LoadAccountIDs()
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM Accounts"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim table As New DataTable()
            adapter.Fill(table)
            'calculate the new id in the table
            Dim nextID As Integer = 1
            If table.Rows.Count > 0 Then
                Dim lastID As Integer = CInt(table.Rows(table.Rows.Count - 1)("AccountID"))
                nextID = lastID + 1
            End If
            Dim newRow As DataRow = table.NewRow()
            newRow("AccountID") = nextID
            table.Rows.Add(newRow)

            cboAccountIDs.DataSource = table
            cboAccountIDs.DisplayMember = "AccountID"
            cboAccountIDs.ValueMember = "AccountID"

            If cboAccountIDs.Items.Count > 0 Then


            End If

            'show the new ID that is to be added in the combo Box
            cboAccountIDs.SelectedIndex = cboAccountIDs.Items.Count - 1
        End Using
    End Sub
    Private Sub LoadClientNames()
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT ClientID, Client FROM Clients"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim table As New DataTable()
            adapter.Fill(table)
            Dim nextID As Integer = 1
            If table.Rows.Count > 0 Then
                Dim lastID As Integer = CInt(table.Rows(table.Rows.Count - 1)("ClientID"))
                nextID = lastID + 1
            End If
            Dim newRow As DataRow = table.NewRow()
            newRow("ClientID") = nextID
            table.Rows.Add(newRow)

            cboClient.DataSource = table
            cboClient.DisplayMember = "Client"
            cboClient.ValueMember = "ClientID"
            cboClient.SelectedIndex = -1
            ToggleNoDataLabel(table.Rows.Count = 0, "No subscriptions for this client.")
        End Using
    End Sub
    Private Sub LoadAccountNames()
        cboAccount.Items.Clear()
        cboAccount.Items.Add("")
        cboAccount.Items.Add("Main Account")
        cboAccount.Items.Add("Hybrid Account")
        cboAccount.Items.Add("Service Account")
        cboAccount.Items.Add("Fixed Account")
        cboAccount.SelectedIndex = 0
    End Sub
    Private Sub Accounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAccountIDs()
        LoadAccountNames()
        LoadClientNames()
        lblNoAccounts.AutoSize = False
        lblNoAccounts.BackColor = Color.White
        lblNoAccounts.ForeColor = Color.Gray
        lblNoAccounts.Font = New Font("Algerian", 14, FontStyle.Italic)
        lblNoAccounts.Visible = False

    End Sub

    Private Sub ToggleNoDataLabel(show As Boolean, Optional message As String = "No data found.")
        lblNoAccounts.Visible = show
        lblNoAccounts.Text = message
        lblNoAccounts.Size = dvgShowAccountsByClients.Size
        lblNoAccounts.Location = dvgShowAccountsByClients.Location
        lblNoAccounts.BringToFront()
    End Sub

    Private Sub btnUpdateAccount_Click(sender As Object, e As EventArgs) Handles btnUpdateAccount.Click
        Dim accountID As Integer
        Dim accountName As String = ""
        Dim clientID As Integer

        ' First try to get from combo boxes
        Dim hasComboSelection As Boolean =
        cboAccountIDs.SelectedIndex <> -1 AndAlso
        cboClient.SelectedIndex <> -1 AndAlso
        cboAccount.SelectedItem IsNot Nothing
        'get information from the data grid view
        If hasComboSelection Then
            accountID = CType(cboAccountIDs.SelectedValue, Integer)
            accountName = cboAccount.SelectedItem.ToString()
            clientID = CType(cboClient.SelectedValue, Integer)
        ElseIf dvgShowAccountsByClients.CurrentRow IsNot Nothing Then
            Dim row As DataGridViewRow = dvgShowAccountsByClients.CurrentRow

            If row.Cells("AccountID").Value IsNot Nothing AndAlso Integer.TryParse(row.Cells("AccountID").Value.ToString(), accountID) AndAlso
           row.Cells("AccountName").Value IsNot Nothing AndAlso
           row.Cells("ClientID").Value IsNot Nothing AndAlso Integer.TryParse(row.Cells("ClientID").Value.ToString(), clientID) Then

                accountName = row.Cells("AccountName").Value.ToString()

            Else
                MessageBox.Show("Incomplete or invalid data selected from the grid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Else
            MessageBox.Show("Please select account info from either the drop-downs or the grid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Create parameter dictionary for the stored procedure
        Dim parameters As New Dictionary(Of String, Object) From {
        {"@AccountID", accountID},
        {"@AccountName", accountName},
        {"@ClientID", clientID}
    }

        ' Execute the update
        ExecuteStoredProcedure("usp_UpdateAccounts", parameters)
        'if successful
        MessageBox.Show("Updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ClearForm()
    End Sub

    Private Sub btnDeleteAccount_Click(sender As Object, e As EventArgs) Handles btnDeleteAccount.Click

        Dim accountID As Integer = -1

        ' First try to get AccountID from ComboBox
        If cboAccountIDs.SelectedValue IsNot Nothing AndAlso IsNumeric(cboAccountIDs.SelectedValue) Then
            accountID = CInt(cboAccountIDs.SelectedValue)
        ElseIf dvgShowAccountsByClients.CurrentRow IsNot Nothing AndAlso
           dvgShowAccountsByClients.CurrentRow.Cells("AccountID").Value IsNot Nothing AndAlso
           IsNumeric(dvgShowAccountsByClients.CurrentRow.Cells("AccountID").Value) Then
            ' Try to get AccountID from selected row in DataGridView
            accountID = CInt(dvgShowAccountsByClients.CurrentRow.Cells("AccountID").Value)
        Else
            MessageBox.Show("Please select a valid Account ID from the dropdown or the table.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        'ensure that both the ID and the in the data is in the fields
        If String.IsNullOrWhiteSpace(cboAccount.Text) OrElse
            String.IsNullOrWhiteSpace(cboClient.Text) Then
            MessageBox.Show("No account has been selected to delete", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Confirm deletion
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this account?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Dim query As String = "DELETE FROM Accounts WHERE AccountID = @AccountID"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@AccountID", accountID}
        }

            Try
                ExecuteNonQuery(query, parameters)
                MessageBox.Show("Account deleted successfully.")

                LoadAccountIDs()
                ClearForm()
            Catch ex As SqlException When ex.Number = 547 ' Foreign key constraint violation
                MessageBox.Show("Cannot delete this account because it is referenced in other records (e.g., subscriptions).", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("An error occurred during deletion: " & ex.Message)
            End Try
        End If
    End Sub
    Private Sub ExecuteNonQuery(query As String, parameters As Dictionary(Of String, Object))
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                For Each Param In parameters
                    command.Parameters.AddWithValue(Param.Key, Param.Value)
                Next
                'opens the connection to the database
                connection.Open()
                'executes the query
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub btnAddAccount_Click(sender As Object, e As EventArgs) Handles btnAddAccount.Click
        'to ensure that there are no discrepancies with the dates
        Dim dateCreated As Date = dtpDateCreated.Value.Date
        Dim lastUpdated As Date = dtpLastUpdated.Value.Date
        Dim today As Date = Date.Today




        Dim query As String = "INSERT INTO Accounts (AccountName, ClientID, DateCreated) VALUES(@AccountName, @ClientID, @DateCreated)"
        If String.IsNullOrWhiteSpace(cboAccount.Text) OrElse
            String.IsNullOrWhiteSpace(cboClient.Text) Then
            MessageBox.Show("Please input data", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'checking for duplicate accountNames for individual clients
        ' Check for duplicate AccountName for the same Client
        Dim checkQuery As String = "SELECT COUNT(*) FROM Accounts WHERE AccountName = @AccountName AND ClientID = @ClientID"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(checkQuery, connection)
                command.Parameters.AddWithValue("@AccountName", cboAccount.SelectedItem.ToString())
                command.Parameters.AddWithValue("@ClientID", CType(cboClient.SelectedValue, Integer))
                connection.Open()
                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                If count > 0 Then
                    MessageBox.Show("This client already has an account with the same name.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End Using
        End Using






        Dim parameters As New Dictionary(Of String, Object) From
            {
            {"@AccountName", cboAccount.SelectedItem.ToString()},
            {"@ClientID", CType(cboClient.SelectedValue, Integer)},
            {"@DateCreated", DateTime.Now.Date}
            }
        ExecuteNonQuery(query, parameters)
        MessageBox.Show("Data Inserted Successfully")
        ClearForm()
    End Sub
    'to show which accounts a client has 
    Private Sub LoadAccountsByClient(clientID As Integer)
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT a.AccountID ,c.Client, a.AccountName, a.DateCreated, a.lastModifiedDate
                                    FROM Accounts a
                                    INNER JOIN Clients c
                                    ON a.ClientID = c.ClientID
                                    WHERE a.ClientID = @ClientID"
            Dim adapter As New SqlDataAdapter(query, connection)

            adapter.SelectCommand.Parameters.AddWithValue("@ClientID", clientID)

            Dim table As New DataTable()
            adapter.Fill(table)

            dvgShowAccountsByClients.DataSource = table
            ToggleNoDataLabel(table.Rows.Count = 0, "This client has no accounts.")
        End Using
    End Sub

    Private Sub cboClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClient.SelectedIndexChanged
        If cboClient.SelectedValue Is Nothing OrElse Not IsNumeric(cboClient.SelectedValue) Then Exit Sub

        Dim clientID As Integer = CInt(cboClient.SelectedValue)
        LoadAccountsByClient(clientID)
    End Sub

    Private Sub btnViewAccountSubscriptions_Click(sender As Object, e As EventArgs) Handles btnViewAccountSubscriptions.Click
        SubAccounts.Show()
    End Sub
    'depending on the row selected the text fields will be populated
    Private Sub dvgShowAccountsByClients_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dvgShowAccountsByClients.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        Dim selectedRow As DataGridViewRow = dvgShowAccountsByClients.Rows(e.RowIndex)
        'select the row by the Account ID
        If selectedRow.Cells("AccountID").Value Is Nothing Then Exit Sub

        Dim selectedID As Integer
        If Integer.TryParse(selectedRow.Cells("AccountID").Value.ToString(), selectedID) Then
            Using connection As New SqlConnection(connectionString)
                Dim query As String = "SELECT * FROM Accounts WHERE AccountID = @AccountID"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@AccountID", selectedID)
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            cboAccount.SelectedItem = reader("AccountName").ToString()
                            cboClient.SelectedValue = reader("ClientID")
                            'dtpLastUpdated.Value = reader("DateCreated")
                            dtpDateCreated.Value = reader("DateCreated")
                            dtpDateCreated.Format = DateTimePickerFormat.Short
                            dtpDateCreated.Checked = True

                            If Not Convert.IsDBNull(reader("lastModifiedDate")) Then
                                dtpLastUpdated.Value = Convert.ToDateTime(reader("lastModifiedDate"))
                                dtpLastUpdated.Format = DateTimePickerFormat.Short
                                dtpLastUpdated.Checked = True
                            Else
                                dtpLastUpdated.Checked = False
                                dtpLastUpdated.Format = DateTimePickerFormat.Custom
                                dtpLastUpdated.CustomFormat = " "
                            End If

                            ' Optional: sync ComboBox for ID if you're using it
                            cboAccountIDs.SelectedValue = selectedID
                        Else
                            ClearForm()
                        End If
                    End Using
                End Using
            End Using
        End If
    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub dtpLastUpdated_ValueChanged(sender As Object, e As EventArgs) Handles dtpLastUpdated.ValueChanged
        If dtpLastUpdated.Checked Then
            dtpLastUpdated.Format = DateTimePickerFormat.Short
        Else
            dtpLastUpdated.Format = DateTimePickerFormat.Custom
            dtpLastUpdated.CustomFormat = " "
        End If
    End Sub

    Private Sub dtpDateCreated_ValueChanged(sender As Object, e As EventArgs) Handles dtpDateCreated.ValueChanged
        'irrespective of any changes to the date the Current date will be uploaded into the table 
        ' Only restrict if user is entering a new date (not loading old data)
        If dtpDateCreated.Value >= Date.Today Then
            dtpLastUpdated.MinDate = dtpDateCreated.Value.AddDays(1)

            If dtpLastUpdated.Value <= dtpDateCreated.Value Then
                dtpLastUpdated.Value = dtpDateCreated.Value.AddDays(1)
            End If
        Else
            dtpLastUpdated.MinDate = Date.MinValue ' allow past values when loading
        End If
    End Sub
    Private Sub dtpDateCreated_Leave(sender As Object, e As EventArgs) Handles dtpDateCreated.Leave
        If dtpLastUpdated.Value <= dtpDateCreated.Value Then
            dtpLastUpdated.Value = dtpDateCreated.Value.AddDays(1)
        End If
    End Sub
End Class