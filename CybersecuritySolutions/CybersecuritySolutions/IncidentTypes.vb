Imports System.Configuration
Imports Microsoft.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Drawing.Text
Public Class IncidentTypes
    Public connectionString As String = "Data Source=localhost\SQLEXPRESS;Database=CybersecuritySolutions;Integrated Security=True;Encrypt=False;"
    Private Sub BacktoMainMenu_Click(sender As Object, e As EventArgs) Handles BacktoMainMenu.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub btnToCyberIncidents_Click(sender As Object, e As EventArgs) Handles btnToCyberIncidents.Click
        CybersecurityIncidents.Show()
        Me.Hide()
    End Sub

    Private Sub IncidentTypes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadIncidentTypes()
        LoadIncidentTypeIDs()

    End Sub

    Private Sub LoadIncidentTypes()
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM IncidentTypes"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim table As New DataTable()
            adapter.Fill(table)
            dvgViewIncidentTypes.DataSource = table
        End Using
    End Sub

    Private Sub cboIncidentTypeIDs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboIncidentTypeIDs.SelectedIndexChanged
        If cboIncidentTypeIDs.SelectedValue Is Nothing Then Exit Sub

        Dim selectedID As Integer
        If Integer.TryParse(cboIncidentTypeIDs.SelectedValue.ToString(), selectedID) Then
            Using connection As New SqlConnection(connectionString)
                Dim query As String = "SELECT * FROM IncidentTypes WHERE IncidentTypeID = @IncidentTypeID"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@IncidentTypeID", selectedID)
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            txtIncidentType.Text = reader("Incident").ToString()
                        Else
                            ClearForm()
                        End If
                    End Using
                End Using
            End Using

        End If
    End Sub

    Private Sub btnAddIncidentType_Click(sender As Object, e As EventArgs) Handles btnAddIncidentType.Click
        If String.IsNullOrWhiteSpace(txtIncidentType.Text) Then
            MessageBox.Show("Incident Type cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim query As String = "INSERT INTO IncidentTypes(Incident) VALUES (@Incident)"
        Dim parameters As New Dictionary(Of String, Object) From
            {
            {"@Incident", txtIncidentType.Text}
            }
        ExecuteNonQuery(query, parameters)
        MessageBox.Show("Data Inserted Successfully")
        LoadIncidentTypeIDs()
        LoadIncidentTypes() 'reload the grid view after adding a new incident type
        ClearForm()
    End Sub
    Private Sub ClearForm()
        txtIncidentType.Clear()

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
    Private Sub btnUpdateIncidentType_Click(sender As Object, e As EventArgs) Handles btnUpdateIncidentType.Click
        If cboIncidentTypeIDs.SelectedValue Is Nothing OrElse String.IsNullOrWhiteSpace(txtIncidentType.Text) Then
            MessageBox.Show("Please select a valid Incident Type ID and ensure the text field is not empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim query As String = "UPDATE IncidentTypes SET Incident= @Incident WHERE IncidentTypeID = @IncidentTypeID"
        Dim parameters As New Dictionary(Of String, Object) From
            {
            {"@IncidentTypeID", CType(cboIncidentTypeIDs.SelectedValue, Integer)},
            {"@Incident", txtIncidentType.Text}
            }
        ExecuteNonQuery(query, parameters) 'used in initial form without using stored procedures
        MessageBox.Show("Data Updated Successfully")
        LoadIncidentTypeIDs()
        LoadIncidentTypes()
        ClearForm()
    End Sub
    Private Sub LoadIncidentTypeIDs()
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT IncidentTypeID FROM IncidentTypes"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim table As New DataTable()
            adapter.Fill(table)
            'calculate the new Id in the table
            Dim nextID As Integer = 1
            If table.Rows.Count > 0 Then
                Dim lastID As Integer = CInt(table.Rows(table.Rows.Count - 1)("IncidentTypeID"))
                nextID = lastID + 1
            End If
            'add the new row to the combo box
            Dim newRow As DataRow = table.NewRow()
            newRow("IncidentTypeID") = nextID
            table.Rows.Add(newRow)

            cboIncidentTypeIDs.DataSource = table
            cboIncidentTypeIDs.DisplayMember = "IncidentTypeID"
            cboIncidentTypeIDs.ValueMember = "IncidentTypeID"

            If cboIncidentTypeIDs.Items.Count > 0 Then

            End If

            'show the new ID that is to be added in the combo Box
            cboIncidentTypeIDs.SelectedIndex = cboIncidentTypeIDs.Items.Count - 1

        End Using
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If cboIncidentTypeIDs.SelectedValue Is Nothing OrElse String.IsNullOrWhiteSpace(txtIncidentType.Text) Then
            MessageBox.Show("Please select a valid Incident Type ID and make sure the Incident field is not empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this Incident Type?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Exit Sub

        Dim selectedID As Integer = CType(cboIncidentTypeIDs.SelectedValue, Integer)
        Dim query As String = "DELETE FROM IncidentTypes WHERE IncidentTypeID = @IncidentTypeID"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@IncidentTypeID", selectedID}
        }

        Try
            ExecuteNonQuery(query, parameters)
            MessageBox.Show("Incident Type deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadIncidentTypeIDs()
            LoadIncidentTypes()
            ClearForm()
        Catch ex As SqlException When ex.Number = 547 ' Foreign key constraint violation
            MessageBox.Show("Cannot delete this Incident Type because it is referenced in another table.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred while deleting the record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'load the data grid view
    Private Sub dvgViewIncidentTypes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dvgViewIncidentTypes.CellContentClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dvgViewIncidentTypes.Rows(e.RowIndex)

            ' Correct way to extract cell values
            Dim incidentTypeID As Integer = CInt(selectedRow.Cells("IncidentTypeID").Value)
            Dim incidentText As String = selectedRow.Cells("Incident").Value.ToString()

            ' Set combo box and text box
            cboIncidentTypeIDs.SelectedValue = incidentTypeID
            txtIncidentType.Text = incidentText
        End If
    End Sub
End Class