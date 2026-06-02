Imports System.Configuration
Imports Microsoft.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Drawing.Text
Imports Microsoft.Identity

Public Class CybersecurityIncidents
    Public connectionString As String = "Data Source=localhost\SQLEXPRESS;Database=CybersecuritySolutions;Integrated Security=True;Encrypt=False;"
    Private Sub BacktoMainMenu_Click(sender As Object, e As EventArgs) Handles BacktoMainMenu.Click
        Form1.Show()
        Me.Hide()
    End Sub
    Private Sub ClearForm()
        'ensure the text fields are blank
        txtIncidentDescription.Clear()
        cboAccountName.SelectedIndex = -1
        cboClient.SelectedIndex = -1
        cboIncidentType.SelectedIndex = -1
        cboIncidentStatus.SelectedIndex = -1
        dtpIncidentDate.Value = Date.Today
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

    Private Sub CybersecurityIncidents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCyberIncidentsIDs()
        LoadIncidentTypes()
        LoadIncidentStatus()
        LoadClients()
    End Sub
    'load the clients in the combo box clients
    'load the Clients will determing which account is being used
    Private Sub LoadClients()
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT ClientID, Client From Clients"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim table As New DataTable()
            adapter.Fill(table)
            cboClient.DataSource = table
            cboClient.DisplayMember = "Client"
            cboClient.ValueMember = "ClientID"
            cboClient.SelectedText = 0


        End Using
    End Sub




    'load the incident status/Note that the table has a check to only Accept the FOUR ITEMS
    Private Sub LoadIncidentStatus()
        cboIncidentStatus.Items.Clear() ' Optional: clear existing items
        cboIncidentStatus.Items.Add("")
        cboIncidentStatus.Items.Add("On hold")
        cboIncidentStatus.Items.Add("Pending")
        cboIncidentStatus.Items.Add("Resolved")
        cboIncidentStatus.Items.Add("Cancelled")
        cboIncidentStatus.SelectedIndex = 0
    End Sub
    'ensure to load the accounts by the ClientID
    Private Sub LoadAccounts(clientID As Integer)
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT AccountID, AccountName FROM Accounts WHERE ClientID = @ClientID"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ClientID", clientID)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                cboAccountName.DataSource = table
                cboAccountName.DisplayMember = "AccountName"
                cboAccountName.ValueMember = "AccountID"
                cboAccountName.SelectedIndex = -1
            End Using
        End Using
    End Sub
    'load all incident types from the database
    Private Sub LoadIncidentTypes()
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT IncidentTypeID, Incident FROM IncidentTypes"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim table As New DataTable()
            adapter.Fill(table)
            cboIncidentType.DataSource = table
            cboIncidentType.DisplayMember = "Incident"
            cboIncidentType.ValueMember = "IncidentTypeID"
            cboIncidentType.SelectedIndex = -1
        End Using
    End Sub
    Private Sub LoadCyberIncidentsIDs()
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT IncidentID FROM CybersecurityIncidents"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim table As New DataTable()
            adapter.Fill(table)
            'calculate the new Id in the table
            Dim nextID As Integer = 1
            If table.Rows.Count > 0 Then
                Dim lastID As Integer = CInt(table.Rows(table.Rows.Count - 1)("IncidentID"))
                nextID = lastID + 1
            End If
            'add the new row to the combo box
            Dim newRow As DataRow = table.NewRow()
            newRow("IncidentID") = nextID
            table.Rows.Add(newRow)

            cboCyberIncidentIDs.DataSource = table
            cboCyberIncidentIDs.DisplayMember = "IncidentID"
            cboCyberIncidentIDs.ValueMember = "IncidentID"

            If cboCyberIncidentIDs.Items.Count > 0 Then

            End If

            'show the new ID that is to be added in the combo Box
            cboCyberIncidentIDs.SelectedIndex = cboCyberIncidentIDs.Items.Count - 1

        End Using

    End Sub

    Private Sub btnAddIncident_Click(sender As Object, e As EventArgs) Handles btnAddIncident.Click
        Dim query As String = "INSERT INTO CybersecurityIncidents(AccountID, IncidentDate, IncidentTypeID, IncidentNotes, IncidentStatus)
                                VALUES(@Account, @IncidentDate, @IncidentType, @Notes, @Status)"

        If String.IsNullOrWhiteSpace(cboAccountName.Text) OrElse
        dtpIncidentDate.Value = DateTimePicker.MinimumDateTime OrElse
        String.IsNullOrWhiteSpace(cboIncidentType.Text) OrElse
        String.IsNullOrWhiteSpace(txtIncidentDescription.Text) OrElse
        String.IsNullOrWhiteSpace(cboIncidentType.Text) Then
            MessageBox.Show("There is no data to update", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim parameters As New Dictionary(Of String, Object) From
            {
            {"@Account", CType(cboAccountName.SelectedValue, Integer)},
            {"@IncidentDate", dtpIncidentDate.Value.Date},
            {"@IncidentType", CType(cboIncidentType.SelectedValue, Integer)},
            {"@Notes", txtIncidentDescription.Text},
            {"@Status", cboIncidentStatus.SelectedItem.ToString()}
            }
        ExecuteNonQuery(query, parameters)
        MessageBox.Show("Data Inserted Successfully")
        ClearForm()

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

    Private Sub btnUpdateIncident_Click(sender As Object, e As EventArgs) Handles btnUpdateIncident.Click
        If cboCyberIncidentIDs.SelectedValue Is Nothing OrElse Not IsNumeric(cboCyberIncidentIDs.SelectedValue) Then
            MessageBox.Show("Please select a valid account to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(cboAccountName.Text) OrElse
        dtpIncidentDate.Value = DateTimePicker.MinimumDateTime OrElse
        String.IsNullOrWhiteSpace(cboIncidentType.Text) OrElse
        String.IsNullOrWhiteSpace(txtIncidentDescription.Text) OrElse
        String.IsNullOrWhiteSpace(cboIncidentType.Text) Then
            MessageBox.Show("There is no data to update", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim query As String = "UPDATE  CybersecurityIncidents SET AccountID= @Account, IncidentDate = @IncidentDate, IncidentTypeID = @IncidentType, IncidentNotes=@Notes, IncidentStatus =@Status
                                WHERE IncidentID = @IncidentID"

        Dim parameters As New Dictionary(Of String, Object) From
         {
            {"IncidentID", CType(cboCyberIncidentIDs.SelectedValue, Integer)},
            {"@Account", CType(cboAccountName.SelectedValue, Integer)},
            {"@IncidentDate", dtpIncidentDate.Value},
            {"@IncidentType", CType(cboIncidentType.SelectedValue, Integer)},
            {"@Notes", txtIncidentDescription.Text},
            {"@Status", cboIncidentStatus.SelectedItem.ToString()}
         }
        ExecuteNonQuery(query, parameters) 'used in initial form without using stored procedures
        MessageBox.Show("Data Updated Successfully")
        LoadCyberIncidentsIDs()
        ClearForm()
    End Sub

    Private Sub cboCyberIncidentIDs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCyberIncidentIDs.SelectedIndexChanged
        If cboCyberIncidentIDs.SelectedValue Is Nothing Then Exit Sub

        Dim selectedID As Integer
        If Integer.TryParse(cboCyberIncidentIDs.SelectedValue.ToString(), selectedID) Then
            Using connection As New SqlConnection(connectionString)
                Dim query As String = "
                SELECT ci.*, a.ClientID 
                FROM CybersecurityIncidents ci
                INNER JOIN Accounts a ON ci.AccountID = a.AccountID
                WHERE ci.IncidentID = @IncidentID"

                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@IncidentID", selectedID)
                    connection.Open()

                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            ' First: Set the client so account list is loaded
                            Dim clientID As Integer = Convert.ToInt32(reader("ClientID"))
                            cboClient.SelectedValue = clientID
                            LoadAccounts(clientID) ' refresh account dropdown

                            ' Now set the account
                            cboAccountName.SelectedValue = Convert.ToInt32(reader("AccountID"))

                            dtpIncidentDate.Value = Convert.ToDateTime(reader("IncidentDate"))
                            cboIncidentType.SelectedValue = Convert.ToInt32(reader("IncidentTypeID"))
                            txtIncidentDescription.Text = reader("IncidentNotes").ToString()
                            cboIncidentStatus.SelectedItem = reader("IncidentStatus").ToString()
                        Else
                            ClearForm()
                        End If
                    End Using
                End Using
            End Using
        End If
    End Sub

    Private Sub btnViewIncidentTypes_Click(sender As Object, e As EventArgs) Handles btnViewIncidentTypes.Click
        IncidentTypes.Show()
    End Sub

    Private Sub btnViewCybesecurityIncidents_Click(sender As Object, e As EventArgs) Handles btnViewCybesecurityIncidents.Click
        ViewCybersecurityIncidents.Show()
    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub cboClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClient.SelectedIndexChanged
        'After the Client has been selected take the value into the cboAccountName. Will be used in the sifting the values
        If cboClient.SelectedValue IsNot Nothing AndAlso IsNumeric(cboClient.SelectedValue) Then
            Dim selectedClientID As Integer = Convert.ToInt32(cboClient.SelectedValue)
            LoadAccounts(selectedClientID)
        Else
            cboAccountName.DataSource = Nothing
        End If
    End Sub

    'Private Sub cboAccountName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAccountName.SelectedIndexChanged

    'End Sub

    'Private Sub cboIncidentStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboIncidentStatus.SelectedIndexChanged

    'End Sub
End Class