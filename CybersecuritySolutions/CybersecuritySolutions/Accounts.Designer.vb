<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Accounts
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        cboClient = New ComboBox()
        Label3 = New Label()
        BacktoMainMenu = New Button()
        Label4 = New Label()
        cboAccountIDs = New ComboBox()
        cboAccount = New ComboBox()
        btnAddAccount = New Button()
        btnUpdateAccount = New Button()
        btnDeleteAccount = New Button()
        dvgShowAccountsByClients = New DataGridView()
        btnViewAccountSubscriptions = New Button()
        btnMainMenu = New Button()
        dtpDateCreated = New DateTimePicker()
        dtpLastUpdated = New DateTimePicker()
        Label5 = New Label()
        Label6 = New Label()
        lblNoAccounts = New Label()
        CType(dvgShowAccountsByClients, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(13, 267)
        Label1.Name = "Label1"
        Label1.Size = New Size(129, 25)
        Label1.TabIndex = 1
        Label1.Text = "Account Name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft Sans Serif", 8.25F)
        Label2.Location = New Point(90, 198)
        Label2.Name = "Label2"
        Label2.Size = New Size(52, 20)
        Label2.TabIndex = 2
        Label2.Text = "Client"
        ' 
        ' cboClient
        ' 
        cboClient.FormattingEnabled = True
        cboClient.Location = New Point(172, 198)
        cboClient.Name = "cboClient"
        cboClient.Size = New Size(182, 33)
        cboClient.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 15)
        Label3.Name = "Label3"
        Label3.Size = New Size(128, 25)
        Label3.TabIndex = 4
        Label3.Text = "AccountID No."
        ' 
        ' BacktoMainMenu
        ' 
        BacktoMainMenu.Location = New Point(727, 12)
        BacktoMainMenu.Name = "BacktoMainMenu"
        BacktoMainMenu.Size = New Size(112, 34)
        BacktoMainMenu.TabIndex = 5
        BacktoMainMenu.Text = "Back"
        BacktoMainMenu.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Showcard Gothic", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(187, 92)
        Label4.Name = "Label4"
        Label4.Size = New Size(231, 50)
        Label4.TabIndex = 6
        Label4.Text = "ACCOUNTS"
        ' 
        ' cboAccountIDs
        ' 
        cboAccountIDs.FormattingEnabled = True
        cboAccountIDs.Location = New Point(146, 7)
        cboAccountIDs.Name = "cboAccountIDs"
        cboAccountIDs.Size = New Size(182, 33)
        cboAccountIDs.TabIndex = 7
        ' 
        ' cboAccount
        ' 
        cboAccount.FormattingEnabled = True
        cboAccount.Location = New Point(172, 267)
        cboAccount.Name = "cboAccount"
        cboAccount.Size = New Size(182, 33)
        cboAccount.TabIndex = 8
        ' 
        ' btnAddAccount
        ' 
        btnAddAccount.Location = New Point(24, 415)
        btnAddAccount.Name = "btnAddAccount"
        btnAddAccount.Size = New Size(112, 34)
        btnAddAccount.TabIndex = 11
        btnAddAccount.Text = "ADD"
        btnAddAccount.UseVisualStyleBackColor = True
        ' 
        ' btnUpdateAccount
        ' 
        btnUpdateAccount.Location = New Point(197, 415)
        btnUpdateAccount.Name = "btnUpdateAccount"
        btnUpdateAccount.Size = New Size(112, 34)
        btnUpdateAccount.TabIndex = 14
        btnUpdateAccount.Text = "UPDATE"
        btnUpdateAccount.UseVisualStyleBackColor = True
        ' 
        ' btnDeleteAccount
        ' 
        btnDeleteAccount.Location = New Point(375, 415)
        btnDeleteAccount.Name = "btnDeleteAccount"
        btnDeleteAccount.Size = New Size(112, 34)
        btnDeleteAccount.TabIndex = 15
        btnDeleteAccount.Text = "DELETE"
        btnDeleteAccount.UseVisualStyleBackColor = True
        ' 
        ' dvgShowAccountsByClients
        ' 
        dvgShowAccountsByClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dvgShowAccountsByClients.Location = New Point(498, 173)
        dvgShowAccountsByClients.Name = "dvgShowAccountsByClients"
        dvgShowAccountsByClients.RowHeadersWidth = 62
        dvgShowAccountsByClients.Size = New Size(484, 276)
        dvgShowAccountsByClients.TabIndex = 16
        ' 
        ' btnViewAccountSubscriptions
        ' 
        btnViewAccountSubscriptions.Location = New Point(100, 464)
        btnViewAccountSubscriptions.Name = "btnViewAccountSubscriptions"
        btnViewAccountSubscriptions.Size = New Size(290, 34)
        btnViewAccountSubscriptions.TabIndex = 17
        btnViewAccountSubscriptions.Text = "View Account Subscriptions"
        btnViewAccountSubscriptions.UseVisualStyleBackColor = True
        ' 
        ' btnMainMenu
        ' 
        btnMainMenu.Location = New Point(845, 12)
        btnMainMenu.Name = "btnMainMenu"
        btnMainMenu.Size = New Size(137, 34)
        btnMainMenu.TabIndex = 18
        btnMainMenu.Text = "MAIN MENU"
        btnMainMenu.UseVisualStyleBackColor = True
        ' 
        ' dtpDateCreated
        ' 
        dtpDateCreated.Enabled = False
        dtpDateCreated.Location = New Point(172, 326)
        dtpDateCreated.Name = "dtpDateCreated"
        dtpDateCreated.Size = New Size(300, 31)
        dtpDateCreated.TabIndex = 19
        ' 
        ' dtpLastUpdated
        ' 
        dtpLastUpdated.Enabled = False
        dtpLastUpdated.Location = New Point(172, 378)
        dtpLastUpdated.Name = "dtpLastUpdated"
        dtpLastUpdated.Size = New Size(300, 31)
        dtpLastUpdated.TabIndex = 20
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(27, 326)
        Label5.Name = "Label5"
        Label5.Size = New Size(115, 25)
        Label5.TabIndex = 21
        Label5.Text = "Date Created"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(25, 378)
        Label6.Name = "Label6"
        Label6.Size = New Size(117, 25)
        Label6.TabIndex = 22
        Label6.Text = "Last Updated"
        ' 
        ' lblNoAccounts
        ' 
        lblNoAccounts.BackColor = SystemColors.ButtonShadow
        lblNoAccounts.Font = New Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblNoAccounts.Location = New Point(525, 290)
        lblNoAccounts.Name = "lblNoAccounts"
        lblNoAccounts.Size = New Size(418, 32)
        lblNoAccounts.TabIndex = 23
        lblNoAccounts.Text = "THIS CLIENT HAS NO ACCOUNT HERE"
        lblNoAccounts.TextAlign = ContentAlignment.MiddleCenter
        lblNoAccounts.Visible = False
        ' 
        ' Accounts
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(997, 509)
        Controls.Add(lblNoAccounts)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(dtpLastUpdated)
        Controls.Add(dtpDateCreated)
        Controls.Add(btnMainMenu)
        Controls.Add(btnViewAccountSubscriptions)
        Controls.Add(dvgShowAccountsByClients)
        Controls.Add(btnDeleteAccount)
        Controls.Add(btnUpdateAccount)
        Controls.Add(btnAddAccount)
        Controls.Add(cboAccount)
        Controls.Add(cboAccountIDs)
        Controls.Add(Label4)
        Controls.Add(BacktoMainMenu)
        Controls.Add(Label3)
        Controls.Add(cboClient)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "Accounts"
        Text = "Accounts"
        CType(dvgShowAccountsByClients, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtAccountName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboClient As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BacktoMainMenu As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents cboAccountIDs As ComboBox
    Friend WithEvents cboAccount As ComboBox
    Friend WithEvents btnAddAccount As Button
    Friend WithEvents btnUpdateAccount As Button
    Friend WithEvents btnDeleteAccount As Button
    Friend WithEvents dvgShowAccountsByClients As DataGridView
    Friend WithEvents btnViewAccountSubscriptions As Button
    Friend WithEvents btnMainMenu As Button
    Friend WithEvents dtpDateCreated As DateTimePicker
    Friend WithEvents dtpLastUpdated As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblNoAccounts As Label
End Class
