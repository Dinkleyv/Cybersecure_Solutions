Imports System.Configuration
Imports Microsoft.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Drawing.Text
Public Class ViewCybersecurityIncidents
    Public connectionString As String = "Data Source=localhost\SQLEXPRESS;Database=CybersecuritySolutions;Integrated Security=True;Encrypt=False;"
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        CybersecurityIncidents.Show()
        Me.Hide()

    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub ViewCybersecurityIncidents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCybersecurityIncidentsView()
        LoadAccountIDs()
        LoadIncidentIDs()
        'setting for labels
        lblnoIncidents.Size = dgvShowCybersecurityIncidents.Size
        lblnoIncidents.Location = dgvShowCybersecurityIncidents.Location
        lblnoIncidents.TextAlign = ContentAlignment.MiddleCenter
        lblnoIncidents.BackColor = Color.White
        lblnoIncidents.ForeColor = Color.Gray
        lblnoIncidents.Font = New Font("Algerian", 14, FontStyle.Italic)
    End Sub

    Private Sub cboCbID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCbID.SelectedIndexChanged
        If cboCbID.SelectedValue IsNot Nothing AndAlso IsNumeric(cboCbID.SelectedValue) Then
            Dim accountID As Integer = Convert.ToInt32(cboCbID.SelectedValue)
            LoadIncidentsByAccountID(accountID)
        Else
            dgvShowCybersecurityIncidents.DataSource = Nothing
        End If
    End Sub

    Private Sub LoadAccountIDs()
        RemoveHandler cboCbID.SelectedIndexChanged, AddressOf cboCbID_SelectedIndexChanged

        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT AccountID, AccountName FROM Accounts"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim table As New DataTable()
            adapter.Fill(table)
            cboCbID.DataSource = table
            cboCbID.DisplayMember = "AccountID"
            cboCbID.ValueMember = "AccountID"
            cboCbID.SelectedIndex = -1
        End Using

        AddHandler cboCbID.SelectedIndexChanged, AddressOf cboCbID_SelectedIndexChanged
    End Sub
    Private Sub LoadCybersecurityIncidentsView()
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM vw_AccountswithcybersecurityIncidents"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvShowCybersecurityIncidents.DataSource = table
        End Using
    End Sub

    Private Sub LoadIncidentsByAccountID(accountID As Integer)
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM CybersecurityIncidents WHERE AccountID = @AccountID"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@AccountID", accountID)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgvShowCybersecurityIncidents.DataSource = table
                ToggleNoDataLabel(table.Rows.Count = 0, "THERE ARE NO INCIDENTS IN THIS ACCOUNT.")
            End Using
        End Using
    End Sub
    'giving the option on wheather selection is from the combo box (going to the dropdown and select the ID)
    'Or select from the data grid view
    ' First try to get AccountID from ComboBox
    Private Sub btnDeleteIncident_Click(sender As Object, e As EventArgs) Handles btnDeleteIncident.Click
        Dim incidentID As Integer = -1

        ' Try to get IncidentID from DataGridView
        If dgvShowCybersecurityIncidents.CurrentRow IsNot Nothing AndAlso
       dgvShowCybersecurityIncidents.CurrentRow.Cells(0).Value IsNot Nothing AndAlso
       IsNumeric(dgvShowCybersecurityIncidents.CurrentRow.Cells(0).Value) Then

            incidentID = CInt(dgvShowCybersecurityIncidents.CurrentRow.Cells(0).Value)
        Else
            MessageBox.Show("Please select a valid incident from the table.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Confirm deletion
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this incident?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Try
                Using conn As New SqlConnection(connectionString)
                    Using cmd As New SqlCommand("usp_DeleteCybersecurityIncidentByIncidentID", conn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@IncidentID", incidentID)

                        conn.Open()
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("Incident deleted successfully.")
                LoadCybersecurityIncidentsView()
                LoadAccountIDs()
            Catch ex As SqlException When ex.Number = 547
                MessageBox.Show("Cannot delete this incident because it is referenced in other records.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("An error occurred during deletion: " & ex.Message)
            End Try
        End If
    End Sub
    Private Sub ClearForm()
        LoadCybersecurityIncidentsView()
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
    Private Sub UpdateStatusToResolved(IncidentID As Integer)
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "UPDATE CybersecurityIncidents SET IncidentStatus = 'RESOLVED' WHERE IncidentID = @IncidentID"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@IncidentID", IncidentID)
                connection.Open()
                Dim rowsAffected As Integer = command.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("Incident Resolved")
                Else
                    MessageBox.Show("No mathching record found")
                End If
            End Using
        End Using
    End Sub
    Private Sub btnResolveIncident_Click(sender As Object, e As EventArgs) Handles btnResolveIncident.Click
        If dgvShowCybersecurityIncidents.CurrentRow IsNot Nothing Then
            Dim incidentID As Integer = Convert.ToInt32(dgvShowCybersecurityIncidents.CurrentRow.Cells(0).Value)

            Dim query As String = "UPDATE CybersecurityIncidents SET IncidentStatus = 'Resolved' WHERE IncidentID = @IncidentID"

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@IncidentID", incidentID)
                    connection.Open()
                    Dim rowsAffected = command.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Incident has been resolved.")
                        LoadCybersecurityIncidentsView() ' Refresh your DataGridView
                    Else
                        MessageBox.Show("No matching incident found.")
                    End If
                End Using
            End Using
        Else
            MessageBox.Show("Please select the incident to be resolved.")
        End If

    End Sub

    Private Sub cboIncidentIDList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboIncidentIDList.SelectedIndexChanged
        If cboIncidentIDList.SelectedValue IsNot Nothing AndAlso IsNumeric(cboIncidentIDList.SelectedValue) Then
            Dim incidentID As Integer = Convert.ToInt32(cboIncidentIDList.SelectedValue)
            LoadIncidentsByIncidentID(incidentID)
        Else
            dgvShowCybersecurityIncidents.DataSource = Nothing
        End If
    End Sub

    Private Sub LoadIncidentsByIncidentID(incidentID As Integer)
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM CybersecurityIncidents WHERE IncidentID = @incidentID"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@incidentID", incidentID)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgvShowCybersecurityIncidents.DataSource = table
            End Using
        End Using
    End Sub
    Private Sub LoadIncidentIDs()
        RemoveHandler cboIncidentIDList.SelectedIndexChanged, AddressOf cboIncidentIDList_SelectedIndexChanged

        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT IncidentID FROM CybersecurityIncidents"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim table As New DataTable()
            adapter.Fill(table)
            cboIncidentIDList.DataSource = table
            cboIncidentIDList.DisplayMember = "IncidentID"
            cboIncidentIDList.ValueMember = "IncidentID"
            cboIncidentIDList.SelectedIndex = -1 ' Optional, to clear selection initially
        End Using

        AddHandler cboIncidentIDList.SelectedIndexChanged, AddressOf cboIncidentIDList_SelectedIndexChanged
    End Sub

    Private Sub ToggleNoDataLabel(show As Boolean, Optional message As String = "No data found.")
        lblnoIncidents.Visible = show
        lblnoIncidents.Text = message
        lblnoIncidents.BringToFront()
    End Sub

End Class