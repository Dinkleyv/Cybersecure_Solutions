Imports System.Configuration
Imports Microsoft.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Drawing.Text
Public Class ServicesProvided
    Public connectionString As String = "Data Source=localhost\SQLEXPRESS;Database=CybersecuritySolutions;Integrated Security=True;Encrypt=False;"
    Private Sub btnBacktoMainMenu_Click(sender As Object, e As EventArgs) Handles btnBacktoMainMenu.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub btnAddService_Click(sender As Object, e As EventArgs) Handles btnAddService.Click
        Dim query As String = "INSERT INTO CsServices(ServiceName, ServiceDescription)
                                    VALUES(@Service, @Description)"

        If String.IsNullOrWhiteSpace(txtServiceName.Text) OrElse
            String.IsNullOrWhiteSpace(txtServiceDescription.Text) Then
            MessageBox.Show("There is no data to insert", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim parameters As New Dictionary(Of String, Object) From
            {
            {"@Service", txtServiceName.Text},
            {"@Description", txtServiceDescription.Text}
            }
        ExecuteNonQuery(query, parameters)
        MessageBox.Show("Data Inserted Successfully")
        ClearForm()
    End Sub



    Private Sub ServicesProvided_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'on Form Load, load all the the CsServices ID in the comboBox
        LoadServiceIDs()
    End Sub
    'get IDs from the CsServices place in the comboBox
    Private Sub LoadServiceIDs()
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT ServiceID FROM CsServices"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim table As New DataTable()
            adapter.Fill(table)
            'calculate the new Id in the table
            Dim nextID As Integer = 1
            If table.Rows.Count > 0 Then
                Dim lastID As Integer = CInt(table.Rows(table.Rows.Count - 1)("ServiceID"))
                nextID = lastID + 1
            End If
            'add the new row to the combo box
            Dim newRow As DataRow = table.NewRow()
            newRow("ServiceID") = nextID
            table.Rows.Add(newRow)

            cboServicesID.DataSource = table
            cboServicesID.DisplayMember = "ServiceID"
            cboServicesID.ValueMember = "ServiceID"

            If cboServicesID.Items.Count > 0 Then
                cboServicesID.SelectedIndex = 0
            End If

            cboServicesID.SelectedIndex = cboServicesID.Items.Count - 1
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
    'Update the service
    Private Sub btnUpdateService_Click(sender As Object, e As EventArgs) Handles btnUpdateService.Click
        Dim query As String = "UPDATE CsServices SET ServiceName = @Service, ServiceDescription = @Description
                                    WHERE ServiceID = @ServiceID"
        'if the textfields are blank, don't update
        If String.IsNullOrWhiteSpace(txtServiceName.Text) OrElse
            String.IsNullOrWhiteSpace(txtServiceDescription.Text) Then
            MessageBox.Show("There is no data to update", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        Dim parameters As New Dictionary(Of String, Object) From
            {
            {"@ServiceID", CType(cboServicesID.SelectedValue, Integer)},
            {"@Service", txtServiceName.Text},
            {"@Description", txtServiceDescription.Text}
            }
        ExecuteNonQuery(query, parameters)
        MessageBox.Show("Data Successfully Updated")
        LoadServiceIDs()
        ClearForm()
    End Sub
    Private Sub ClearForm()
        txtServiceDescription.Clear()
        txtServiceName.Clear()
    End Sub
    'delete a service
    Private Sub btnDeleteService_Click(sender As Object, e As EventArgs) Handles btnDeleteService.Click
        If cboServicesID.SelectedValue Is Nothing OrElse Not IsNumeric(cboServicesID.SelectedValue) Then
            MessageBox.Show("Please select a valid Service Id to delete")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtServiceName.Text) OrElse
            String.IsNullOrWhiteSpace(txtServiceDescription.Text) Then
            MessageBox.Show("You have to select an ID to delete", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim serviceID As Integer = CInt(cboServicesID.SelectedValue)

        Dim query As String = "DELETE FROM CsServices WHERE ServiceID = @ServiceID"
        Dim parameters As New Dictionary(Of String, Object) From
            {
            {"ServiceID", CType(cboServicesID.SelectedValue, Integer)}
            }
        Dim result As DialogResult = MessageBox.Show("Are you sure you wish to delete this service?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Try
                ExecuteNonQuery(query, parameters)
                MessageBox.Show("Service Deleted Successfully")
                LoadServiceIDs()
                ClearForm()
            Catch ex As SqlException When ex.Number = 547 ' Foreign key constraint violation
                MessageBox.Show("Cannot delete this service because it is referenced in other records (e.g.,accounts, subcriptins, etc.).", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("An error occurred during deletion: " & ex.Message)
            End Try
        End If
    End Sub
    'load all the service names from the table
    Private Sub cboServicesID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboServicesID.SelectedIndexChanged
        If cboServicesID.SelectedValue Is Nothing OrElse Not IsNumeric(cboServicesID.SelectedValue) Then Exit Sub

        Dim serviceID As Integer = CInt(cboServicesID.SelectedValue)
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT ServiceName, ServiceDescription FROM CsServices WHERE ServiceID = @ServiceID"
            Using command As New SqlCommand(query, connection)
                'select on the basis of the ServiceID
                command.Parameters.AddWithValue("@ServiceID", serviceID)
                connection.Open()
                Using reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        txtServiceName.Text = reader("ServiceName").ToString()
                        txtServiceDescription.Text = reader("ServiceDescription").ToString()
                    End If
                End Using
            End Using
        End Using
    End Sub
    'select button to show all the data from the table
    Private Sub btnViewServices_Click(sender As Object, e As EventArgs) Handles btnViewServices.Click
        Dim query As String = "SELECT ServiceID, ServiceName, ServiceDescription FROM CsServices"
        Using connection As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, connection)
                Using adapter As New SqlDataAdapter(cmd)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    dgvShowServices.DataSource = table
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        Form1.Show()
        Me.Hide()

    End Sub
End Class