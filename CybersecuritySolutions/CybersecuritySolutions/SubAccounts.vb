Imports System.Configuration
Imports Microsoft.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Drawing.Text
Public Class SubAccounts
    Public connectionString As String = "Data Source=localhost\SQLEXPRESS;Database=CybersecuritySolutions;Integrated Security=True;Encrypt=False;"
    Private Sub btnAddSubscription_Click(sender As Object, e As EventArgs) Handles btnAddSubscription.Click
        Subscriptions.Show()
        Me.Hide()
    End Sub

    Private Sub cboClientList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClientList.SelectedIndexChanged
        If cboClientList.SelectedValue IsNot Nothing AndAlso IsNumeric(cboClientList.SelectedValue) Then
            Dim selectedClientID As Integer = Convert.ToInt32(cboClientList.SelectedValue)

            ' Load accounts for the selected client
            LoadAccountComboByClient(selectedClientID)

            ' Load all subscriptions for the client regardless of account
            LoadServicesByClient(selectedClientID)
        Else
            cboAccountList.DataSource = Nothing
            dgvShowSubscriptions.DataSource = Nothing
        End If
    End Sub

    Private Sub LoadServicesByClient(clientID As Integer)
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "
        SELECT a.AccountID, s.SubscriptionID, cs.ServiceName, a.AccountName, s.StartDate, s.EndDate,
               DATEDIFF(MONTH, s.StartDate, s.EndDate) AS Duration_Months
        FROM Subscriptions s
        INNER JOIN CsServices cs ON s.ServiceID = cs.ServiceID
        INNER JOIN Accounts a ON s.AccountID = a.AccountID
        WHERE a.ClientID = @ClientID AND s.SubStatus <> 'REMOVED'"

            Dim adapter As New SqlDataAdapter(query, connection)
            adapter.SelectCommand.Parameters.AddWithValue("@ClientID", clientID)

            Dim table As New DataTable()
            adapter.Fill(table)
            dgvShowSubscriptions.DataSource = table
            ToggleNoDataLabel(table.Rows.Count = 0, "No subscriptions for this client.")
        End Using
    End Sub

    Private Sub ToggleNoDataLabel(show As Boolean, Optional message As String = "No data found.")
        lblNoSubscriptions.Visible = show
        lblNoSubscriptions.Text = message
        lblNoSubscriptions.BringToFront()
    End Sub
    Private Sub LoadServicesByAccount(accountID As Integer)
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "
            SELECT s.AccountID, s.SubscriptionID, cs.ServiceName, s.StartDate, s.EndDate, DATEDIFF(month,s.StartDate, s.EndDate) AS Duration_Months 
            FROM Subscriptions s
            INNER JOIN CsServices cs ON s.ServiceID = cs.ServiceID
            WHERE s.AccountID = @AccountID  AND SubStatus <> 'REMOVED'"
            Dim adapter As New SqlDataAdapter(query, connection)
            adapter.SelectCommand.Parameters.AddWithValue("@AccountID", accountID)

            Dim table As New DataTable()
            adapter.Fill(table)

            dgvShowSubscriptions.DataSource = table
            ToggleNoDataLabel(table.Rows.Count = 0, "No subscriptions for this account.")
        End Using
    End Sub

    Private Sub LoadAccountComboByClient(clientID As Integer)
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT AccountID, AccountName FROM Accounts WHERE ClientID = @ClientID"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ClientID", clientID)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                cboAccountList.DataSource = table
                cboAccountList.DisplayMember = "AccountName"
                cboAccountList.ValueMember = "AccountID"
                cboAccountList.SelectedIndex = -1
            End Using
        End Using
    End Sub


    Private Sub LoadAccountGridByClient(clientID As Integer)
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "Select c.Client, a.AccountName ,cs.ServiceName
                                    From Accounts a
                                    INNER JOIN Clients c
                                    ON a.ClientID = c.ClientID
                                    INNER JOIN Subscriptions S
                                    ON s.AccountID = s.AccountID
                                    INNER JOIN CsServices cs
                                    ON s.ServiceID = cs.ServiceID
                                    WHERE a.ClientID = @ClientID
                                    AND SubStatus <> 'REMOVED"
            Dim adapter As New SqlDataAdapter(query, connection)
            adapter.SelectCommand.Parameters.AddWithValue("@ClientID", clientID)

            Dim table As New DataTable()
            adapter.Fill(table)

            dgvShowSubscriptions.DataSource = table
        End Using
    End Sub

    Private Sub SubAccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadClients()
        LoadAccountSubcriptions()

        lblNoSubscriptions.Size = dgvShowSubscriptions.Size
        lblNoSubscriptions.Location = dgvShowSubscriptions.Location
        lblNoSubscriptions.TextAlign = ContentAlignment.MiddleCenter
        lblNoSubscriptions.BackColor = Color.White
        lblNoSubscriptions.ForeColor = Color.Gray
        lblNoSubscriptions.Font = New Font("Algerian", 14, FontStyle.Italic)
    End Sub


    Private Sub LoadAccountSubcriptions()
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT a.AccountID, s.SubscriptionID, 
                                    cs.ServiceName, a.AccountName, 
                                    s.StartDate,s.EndDate, s.Duration   
                                    From Subscriptions s
                                    FULL JOIN Accounts a
                                    ON s.AccountID = a.AccountID
                                    INNER JOIN CsServices cs
                                    ON cs.ServiceID = s.ServiceID"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvShowSubscriptions.DataSource = table
        End Using
    End Sub


    Private Sub LoadClients()
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT ClientID, Client FROM Clients"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim table As New DataTable()
            adapter.Fill(table)
            cboClientList.DataSource = table
            cboClientList.DisplayMember = "Client"
            cboClientList.ValueMember = "ClientID"
            cboClientList.SelectedIndex = -1
        End Using
    End Sub


    Private Sub btnBacktoAccounts_Click(sender As Object, e As EventArgs) Handles btnBacktoAccounts.Click
        Accounts.Show()
        Me.Hide()
    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub cboAccountList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAccountList.SelectedIndexChanged
        If cboAccountList.SelectedValue IsNot Nothing AndAlso IsNumeric(cboAccountList.SelectedValue) Then
            Dim selectedAccountID As Integer = Convert.ToInt32(cboAccountList.SelectedValue)
            LoadServicesByAccount(selectedAccountID)
        End If
    End Sub

    Private Sub btnDeleteSubscription_Click(sender As Object, e As EventArgs) Handles btnDeleteSubscription.Click
        If dgvShowSubscriptions.CurrentRow IsNot Nothing Then
            Dim subscriptionID As Integer = Convert.ToInt32(dgvShowSubscriptions.CurrentRow.Cells("SubscriptionID").Value)

            Dim query As String = "UPDATE Subscriptions SET SubStatus = 'REMOVED' WHERE SubscriptionID = @SubscriptionID"

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@SubscriptionID", subscriptionID)
                    connection.Open()
                    Dim rowsAffected = command.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Subscription marked as removed.")
                        LoadServicesByAccount(CInt(cboAccountList.SelectedValue)) ' Refresh your DataGridView
                    Else
                        MessageBox.Show("No matching subscription found.")
                    End If
                End Using
            End Using
        Else
            MessageBox.Show("Please select a subscription to remove.")
        End If

        '' Refresh the grid
        If cboAccountList.SelectedValue IsNot Nothing Then
            LoadServicesByAccount(CInt(cboAccountList.SelectedValue))
        End If

        MessageBox.Show("Subscription deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
        If dgvShowSubscriptions.CurrentRow Is Nothing Then
            MessageBox.Show("Please select a subscription to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim row = dgvShowSubscriptions.CurrentRow

        ' Ensure the ID exists and is numeric
        If row.Cells("SubscriptionID").Value Is Nothing OrElse Not IsNumeric(row.Cells("SubscriptionID").Value) Then
            MessageBox.Show("Could not determine Subscription ID. Please select a valid row.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim subscriptionId As Integer = row.Cells("SubscriptionID").Value

        ' Validate StartDate and EndDate
        Dim startDate As Date
        Dim endDate As Date

        If Not Date.TryParse(row.Cells("StartDate").Value.ToString, startDate) OrElse
       Not Date.TryParse(row.Cells("EndDate").Value.ToString, endDate) Then
            MessageBox.Show("Invalid start or end date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim query = "UPDATE Subscriptions SET StartDate = @StartDate, EndDate = @EndDate WHERE SubscriptionID = @SubscriptionID"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@StartDate", startDate)
                command.Parameters.AddWithValue("@EndDate", endDate)
                command.Parameters.AddWithValue("@SubscriptionID", subscriptionId)
                command.ExecuteNonQuery()
            End Using
        End Using

        ' Refresh grid
        If cboAccountList.SelectedValue IsNot Nothing Then
            LoadServicesByAccount(cboAccountList.SelectedValue)
        End If

        MessageBox.Show("Subscription updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    'Private Sub lblNoSubscriptions_Click(sender As Object, e As EventArgs) Handles lblNoSubscriptions.Click

    'End Sub
End Class