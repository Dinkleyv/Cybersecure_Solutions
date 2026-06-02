Imports System.Configuration
Imports Microsoft.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Drawing.Text
Public Class Subscriptions
    Public connectionString As String = "Data Source=localhost\SQLEXPRESS;Database=CybersecuritySolutions;Integrated Security=True;Encrypt=False;"
    Private Sub btnToMainMenu_Click(sender As Object, e As EventArgs) Handles btnToMainMenu.Click
        Form1.Show()
        Me.Hide()

    End Sub

    Private Sub btnAddSubscription_Click(sender As Object, e As EventArgs) Handles btnAddSubscription.Click
        'to ensure that there are no discrepancies with the dates
        Dim startDate As Date = dtpStartDate.Value.Date
        Dim endDate As Date = dtpEndDate.Value.Date
        Dim today As Date = Date.Today

        ' Check if start date is today or in the future
        If startDate < today Then
            MessageBox.Show("Start date cannot be in the past.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check if end date is after the start date
        If endDate <= startDate Then
            MessageBox.Show("End date must be after the start date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim query As String = "INSERT INTO Subscriptions(ServiceID, AccountID, StartDate, EndDate) 
                                VALUES (@ServiceID, @AccountID, @StartDate, @EndDate)"

        Dim parameters As New Dictionary(Of String, Object) From
            {
            {"@ServiceID", CType(cboServiceList.SelectedValue, Integer)},
            {"@AccountID", CType(cboAccounts.SelectedValue, Integer)},
            {"@StartDate", dtpStartDate.Value.Date},
            {"@EndDate", dtpEndDate.Value.Date}
        }
        ExecuteNonQuery(query, parameters)
        MessageBox.Show("Data insertted succefully")
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
    Private Sub ClearForm()
        cboAccounts.SelectedIndex = -1
        cboClientList.SelectedIndex = -1
        cboServiceList.SelectedIndex = -1
        'dates
        'dtpEndDate.Value = Date.Today
        dtpStartDate.Value = Date.Today
    End Sub
    Private Sub Subscriptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadServices()
        LoadClients()

    End Sub

    Private Sub LoadServices()
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT ServiceID, ServiceName FROM CsServices"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim table As New DataTable()
            adapter.Fill(table)
            cboServiceList.DataSource = table
            cboServiceList.DisplayMember = "ServiceName"
            cboServiceList.ValueMember = "ServiceID"
            cboServiceList.SelectedIndex = -1
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

    Private Sub cboClientList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClientList.SelectedIndexChanged
        If cboClientList.SelectedValue IsNot Nothing AndAlso IsNumeric(cboClientList.SelectedValue) Then
            Dim selectedClientID As Integer = Convert.ToInt32(cboClientList.SelectedValue)
            LoadAccountsByClient(selectedClientID)
        Else
            cboAccounts.DataSource = Nothing
        End If
    End Sub
    Private Sub LoadAccountsByClient(clientID As Integer)
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT AccountID, AccountName FROM Accounts WHERE ClientID = @ClientID"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ClientID", clientID)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                cboAccounts.DataSource = table
                cboAccounts.DisplayMember = "AccountName"
                cboAccounts.ValueMember = "AccountID"
                cboAccounts.SelectedIndex = -1
            End Using
        End Using
    End Sub

    Private Sub btnViewSubscriptions_Click(sender As Object, e As EventArgs) Handles btnViewSubscriptions.Click
        SubAccounts.Show()
    End Sub

    'Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged

    'End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        Form1.Show()
        Me.Hide()
    End Sub
    'once the StartDate has been selected,
    Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged
        ' Only restrict if user is entering a new date (not loading old data)
        If dtpStartDate.Value >= Date.Today Then
            'restrict selection of enddate prior to startDate. 
            'ensure enddate is 30 days after Start Date
            dtpEndDate.MinDate = dtpStartDate.Value.AddDays(30)
            'Block off dates before 30 day time line
            If dtpEndDate.Value <= dtpStartDate.Value Then
                dtpEndDate.Value = dtpStartDate.Value.AddDays(30)
            End If
        Else
            dtpEndDate.MinDate = Date.MinValue ' allow past values when loading
        End If
    End Sub
    Private Sub dtpStartDate_Leave(sender As Object, e As EventArgs) Handles dtpStartDate.Leave
        If dtpEndDate.Value <= dtpStartDate.Value Then
            dtpEndDate.Value = dtpStartDate.Value.AddDays(30)
        End If
    End Sub
End Class