<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Clients
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
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        txtClientName = New TextBox()
        txtEmail = New TextBox()
        txtPhone = New TextBox()
        txtAddress = New TextBox()
        btnDeleteClient = New Button()
        btnSubmit = New Button()
        btnUpdate = New Button()
        btnShowClients = New Button()
        dgvClients = New DataGridView()
        BacktoMainMenu = New Button()
        cboShowID = New ComboBox()
        btnClearFields = New Button()
        Label6 = New Label()
        cboClientName = New ComboBox()
        CType(dgvClients, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(64, 205)
        Label1.Name = "Label1"
        Label1.Size = New Size(56, 25)
        Label1.TabIndex = 0
        Label1.Text = "Client"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(64, 264)
        Label2.Name = "Label2"
        Label2.Size = New Size(54, 25)
        Label2.TabIndex = 1
        Label2.Text = "Email"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(64, 314)
        Label3.Name = "Label3"
        Label3.Size = New Size(62, 25)
        Label3.TabIndex = 2
        Label3.Text = "Phone"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(67, 360)
        Label4.Name = "Label4"
        Label4.Size = New Size(77, 25)
        Label4.TabIndex = 3
        Label4.Text = "Address"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(12, 9)
        Label5.Name = "Label5"
        Label5.Size = New Size(109, 25)
        Label5.TabIndex = 4
        Label5.Text = "Client ID no."
        ' 
        ' txtClientName
        ' 
        txtClientName.Location = New Point(145, 205)
        txtClientName.Name = "txtClientName"
        txtClientName.Size = New Size(228, 31)
        txtClientName.TabIndex = 5
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(145, 261)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(228, 31)
        txtEmail.TabIndex = 6
        ' 
        ' txtPhone
        ' 
        txtPhone.Location = New Point(145, 308)
        txtPhone.Name = "txtPhone"
        txtPhone.Size = New Size(228, 31)
        txtPhone.TabIndex = 7
        ' 
        ' txtAddress
        ' 
        txtAddress.Location = New Point(150, 360)
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(228, 31)
        txtAddress.TabIndex = 8
        ' 
        ' btnDeleteClient
        ' 
        btnDeleteClient.Location = New Point(570, 445)
        btnDeleteClient.Name = "btnDeleteClient"
        btnDeleteClient.Size = New Size(112, 34)
        btnDeleteClient.TabIndex = 10
        btnDeleteClient.Text = "DELETE"
        btnDeleteClient.UseVisualStyleBackColor = True
        ' 
        ' btnSubmit
        ' 
        btnSubmit.Location = New Point(123, 445)
        btnSubmit.Name = "btnSubmit"
        btnSubmit.Size = New Size(164, 34)
        btnSubmit.TabIndex = 11
        btnSubmit.Text = "ADD CLIENT"
        btnSubmit.UseVisualStyleBackColor = True
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Location = New Point(372, 445)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(112, 34)
        btnUpdate.TabIndex = 12
        btnUpdate.Text = "UPDATE"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' btnShowClients
        ' 
        btnShowClients.Location = New Point(541, 118)
        btnShowClients.Name = "btnShowClients"
        btnShowClients.Size = New Size(112, 34)
        btnShowClients.TabIndex = 13
        btnShowClients.Text = "ViewClients"
        btnShowClients.UseVisualStyleBackColor = True
        ' 
        ' dgvClients
        ' 
        dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvClients.Location = New Point(394, 158)
        dgvClients.Name = "dgvClients"
        dgvClients.RowHeadersWidth = 62
        dgvClients.Size = New Size(382, 281)
        dgvClients.TabIndex = 14
        ' 
        ' BacktoMainMenu
        ' 
        BacktoMainMenu.Location = New Point(686, 12)
        BacktoMainMenu.Name = "BacktoMainMenu"
        BacktoMainMenu.Size = New Size(112, 34)
        BacktoMainMenu.TabIndex = 15
        BacktoMainMenu.Text = "Back"
        BacktoMainMenu.UseVisualStyleBackColor = True
        ' 
        ' cboShowID
        ' 
        cboShowID.FormattingEnabled = True
        cboShowID.Location = New Point(170, 6)
        cboShowID.Name = "cboShowID"
        cboShowID.Size = New Size(91, 33)
        cboShowID.TabIndex = 16
        ' 
        ' btnClearFields
        ' 
        btnClearFields.BackColor = SystemColors.GradientInactiveCaption
        btnClearFields.Font = New Font("Segoe UI", 11F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        btnClearFields.Location = New Point(648, 515)
        btnClearFields.Name = "btnClearFields"
        btnClearFields.Size = New Size(128, 40)
        btnClearFields.TabIndex = 17
        btnClearFields.Text = "ClearFields"
        btnClearFields.UseVisualStyleBackColor = False
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(34, 90)
        Label6.Name = "Label6"
        Label6.Size = New Size(63, 25)
        Label6.TabIndex = 18
        Label6.Text = "Label6"
        ' 
        ' cboClientName
        ' 
        cboClientName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboClientName.AutoCompleteSource = AutoCompleteSource.CustomSource
        cboClientName.FormattingEnabled = True
        cboClientName.Location = New Point(150, 82)
        cboClientName.Name = "cboClientName"
        cboClientName.Size = New Size(365, 33)
        cboClientName.TabIndex = 19
        ' 
        ' Clients
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(822, 574)
        Controls.Add(cboClientName)
        Controls.Add(Label6)
        Controls.Add(btnClearFields)
        Controls.Add(cboShowID)
        Controls.Add(BacktoMainMenu)
        Controls.Add(dgvClients)
        Controls.Add(btnShowClients)
        Controls.Add(btnUpdate)
        Controls.Add(btnSubmit)
        Controls.Add(btnDeleteClient)
        Controls.Add(txtAddress)
        Controls.Add(txtPhone)
        Controls.Add(txtEmail)
        Controls.Add(txtClientName)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "Clients"
        Text = "Clients"
        CType(dgvClients, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtClientName As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents btnDeleteClient As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnShowClients As Button
    Friend WithEvents dgvClients As DataGridView
    Friend WithEvents BacktoMainMenu As Button
    Friend WithEvents cboShowID As ComboBox
    Friend WithEvents btnClearFields As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents cboClientName As ComboBox
End Class
